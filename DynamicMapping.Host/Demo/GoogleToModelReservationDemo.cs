namespace DynamicMapping.Host.Demo;

using DynamicMapping.Host.Output;
using DynamicMapping.Host.Data;
using DynamicMapping.Core.Engine;

internal class GoogleToModelReservationDemo
{
    private readonly MapHandler _mapHandler;

    public GoogleToModelReservationDemo(MapHandler mapHandler)
    {
        _mapHandler = mapHandler;
    }

    public void RunDemo()
    {
        // Demo01: Passed mapping.
        try
        {
            var googleRes = GoogleReservationSamples.BasicReservation();
            var modelRes = _mapHandler.Map(googleRes, "Google.Reservation", "Model.Reservation");

            MappingResultPrinter.PrintSuccess("Google.Reservation", "Model.Reservation", googleRes, modelRes);
        }
        catch (Exception ex)
        {
            MappingResultPrinter.PrintError(ex);
        }

        // Demo02: Failed mapping -> incorrect source type
        try
        {
            var googleRes = GoogleReservationSamples.BasicReservation();
            var modelRes = _mapHandler.Map(googleRes, "Googl.Reservation", "Model.Reservation");

            MappingResultPrinter.PrintSuccess("Googl.Reservation", "Model.Reservation", googleRes, modelRes);
        }
        catch (Exception ex)
        {
            MappingResultPrinter.PrintError(ex);
        }

        // Demo03: Failed mapping -> null object
        try
        {
            var googleRes = GoogleReservationSamples.BasicReservation();
            var modelRes = _mapHandler.Map(null, "Google.Reservation", "Model.Reservation");

            MappingResultPrinter.PrintSuccess("Google.Reservation", "Model.Reservation", googleRes, modelRes);
        }
        catch (Exception ex)
        {
            MappingResultPrinter.PrintError(ex);
        }

        // Demo04: Invalid data -> invalid date range
        try
        {
            var googleRes = GoogleReservationSamples.InvalidDateRange();
            var modelRes = _mapHandler.Map(googleRes, "Google.Reservation", "Model.Reservation");

            MappingResultPrinter.PrintSuccess("Google.Reservation", "Model.Reservation", googleRes, modelRes);
        }
        catch (Exception ex)
        {
            MappingResultPrinter.PrintError(ex);
        }
    }
}
