# Dynamic Mapping System

A lightweight, extensible, partner-agnostic mapping engine built in .NET.  
The system supports bi-directional mappings between external partner models and internal domain models using a clean, pluggable architecture.

---

## 🚀 Features

- **Dynamic mapping engine** with runtime profile resolution  
- **Pluggable partner adapters** (e.g., Partner → Model, Model → Partner)  
- **Strongly typed mapping profiles** (generic base classes + unified contract)  
- **Centralized profile registry** and a single mapping entry point  
- **Shared validation and formatting utilities**  
- **Robust error handling** with clear field-level messages  
- **Easily extensible design** — add new partners without touching the Core  

---

## 📂 Project Structure

DynamicMapping.Core → Core mapping engine
(IMappingProfile, MappingProfileBase, ProfileRegistry,
MapHandler, MappingException, DI extensions)

DynamicMapping.Google → Google partner adapter
(Google models, mapping profiles, validators, DI registration)

DynamicMapping.Model → Internal domain models
(Reservation, Room, other internal types)

DynamicMapping.Shared → Shared, partner-agnostic utilities
(parsers, formatting helpers, common exceptions)

DynamicMapping.Host → .NET console host
(DI setup, sample data, demo scenarios, result printing)

## 🧠 How It Works

1. Each mapping profile inherits from a strongly typed base:  
   `MappingProfileBase<TSource, TTarget>`  
2. All profiles expose a unique `(SourceType, TargetType)` identity.  
3. Profiles register through dependency injection (DI).  
4. At runtime, `MapHandler` resolves the correct profile using the identity keys.  
5. The system executes validation, mapping, and returns the typed result.  
6. All mapping errors or validation issues are raised as structured exceptions.

---

## ➕ Adding a New Partner

The system is designed for easy extensibility:

1. Create a partner adapter project  
2. Add partner-specific models  
3. Implement mapping profiles:  
   - Partner → Internal  
   - Internal → Partner  
4. Add validation logic (recommended)  
5. Register mappings using DI  
6. Use with:

```csharp
_mapHandler.Map(sourceObject, "Partner.Type", "Model.Type");
