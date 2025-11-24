# DynamicMapping
2.	Architecture & Design
This section describes the overall architecture, components, and design principles behind the dynamic mapping system. It explains how the system remains extensible, partner-agnostic, and maintainable as new integrations are added.
2.1.	Dynamic Mapping System – Architectural Concept
The mapping system is built as a pluggable architecture, meaning new partner adapters can be introduced without modifying the Core mapping engine or the Host application. Each partner contributes its own mapping profiles, validations, and data models, while the Core provides the runtime machinery to execute mappings consistently across all partners, as illustrated in Figure 1.
 
     Figure-1: Dynamic mapping system conceptual Architectural.
2.2.	Mapping System (Library) Layer
The Mapping System is implemented as a reusable .Net class library considering  “Open for extension, closed for modification” and “Single responsibility” principles, independent of any specific application or host. It contains all the logic required for mappings between different models, without assuming whether it runs in a console app, web API, or background service. 
2.2.1.	DynamicMapping.Core (Mapping Engine)
This library provides the central, partner-agnostic dynamic mapping engine. It manages profile registration, resolution, execution, and mapping error handling. All partner-specific logic lives outside the Core, as shown in Figure 1. Detailed class level diagram illustrated in Figure 2.
 
Figure 2: Core mapping engine (class level) design diagram .
Dependencies: This library works independently and has no partner-specific logic.

IMappingProfile (Contract)
Unified interface for all mappings, exposing: 
  
This common interface allows the core mapping engine to:
•	Dispatch all profiles through a uniform Map(object) entry point using SourceType/TargetType.
•	Treat all partner-specific profiles consistently, regardless of their concrete generic types.
MappingProfileBase<TSourceModel, TTargetModel> (Typed base)
A strongly typed abstract base class that implements ‘IMappingProfile’. It replaces the object-based mapping API with a type-safe generic API by exposing:  
This generic method:
•	Eliminates the need for explicit type-casting in mapping implementations.
•	Provides compile-time type safety for both source and target models.
This makes partner-specific mapping profiles safer, cleaner, and easier to maintain
ProfileRegistry (Internal registry)
Stores all ‘IMappingProfile’ instances in a dictionary, keyed by (sourceType, targetType):
 
It prevents duplicates and resolves the correct profile at runtime.
MapHandler (Execution engine)
Single entry point for the host/ application: 
 
It queries ‘ProfileRegistry’ using the (sourceType, targetType) key to resolve the matching concrete mapping profile, then calls the profile.Map(data) and returns the mapped result.
MappingException
Central Exception type for mapping failures, including SourceType, TargetType, and a user-friendly message, with factory methods for common errors (null input, missing profile, invalid source type, duplicate profile, conversion issues).
2.2.2.	DynamicMapping.Google (Partner Adapter)
The library plugs Google-specific mapping rules as a MappingProfile into the Core to support mappings (Google → internal model) and (internal model → Google), without changing the Core itself. It also provides partner-specific Models, Validations, and DI registration (ServiceCollectionExtensions).

 
Figure 3: Google adapter (class level) design diagram with dependencies.
Dependencies:
1.	DynamicMapping.Core: each partner adapter depends on the Core mapping engine for mapping abstractions and runtime behavior.
2.	DynamicMapping.Model:  all partner adapters require reference to the library for internal models.
3.	DynamicMapping.Shared: contains shared reusable logic across all partners such as: Parsers, Formatting helpers, and Exceptions.
Models 
This directory contains external (partner-specific) models (e.g. GoogleReservation, GoogleRoom).
Mapping Profiles 
This directory contains mapping logic between (Google → internal) or (internal → Google) models as profiles. 
 e.g. GoogleToModelReservationProfile, ModelToGoogleReservationProfile.
Responsibilities:
1.	Concrete Model Types
All mapping profiles implement ’MappingProfileBase’ class located in DynamicMapping.Core.
 
This provides compile-time type safety and eliminates any need for manual casting.
2.	Profile Identity (Profile Key for Resolution)
A mapping profile overrides SourceType and TargetType to provide a unique key for the Core engine.
 
The Core engine uses this key to register and resolve the correct profile at runtime.
3.	Mapping Implementation
Each mapping profile implements the typed base method: 
 
Inside this method, the mapping profile uses:
•	A dedicated validator class per profile, ensuring the source object is valid.
•	Parsers, Helpers, and custom Exception types from DynamicMapping.Shared to convert strings, dates, and names into domain-friendly formats and to handle invalid input consistently.
•	Finaly the transformation logic maps the validated source model to the target model. 
Validations
Provides partner-specific validation logic for source/ target model transformation. Validators perform structural and semantic checks (e.g., required fields, date consistency, data format) before the mapping.
e.g. GoogleToModelReservationValidator, ModelToGoogleReservationValidator.
ServiceCollectionExtension (DI Registration Class)
The ServiceCollectionExtension class wires the Google adapter into the host application via dependency injection. Inside the AddGoogleMappings method, each Google mapping profile is registered as an IMappingProfile, so the Core engine can automatically receive them as IEnumerable<IMappingProfile> and load them into the read-only profile dictionary inside ProfileRegistry.
Further details on how this supports pluggable partners are described in the extensibility guide.
2.2.3.	DynamicMapping.Model (Internal Models)
This library defines the internal domain models (Reservation, Room) that all partner adapters map to and from. These models are independent of any specific partner API and provide a stable, partner-agnostic schema, allowing the host to work with a single unified structure while each partner adapter handles its own validation, parsing, and persistence rules separately.
