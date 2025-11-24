namespace DynamicMapping.Host.Demo;

using DynamicMapping.Host.Output;
using DynamicMapping.Host.Data;
using DynamicMapping.Core.Engine;

internal class ModelToGoogleReservationDemo
{
    private readonly MapHandler _mapHandler;

    public ModelToGoogleReservationDemo(MapHandler mapHandler)
    {
        _mapHandler = mapHandler;
    }

    public void RunDemo()
    {
        // Demo01: Passed mapping
        try
        {
            var modelRes = ModelReservationSamples.BasicReservation();
            var googleRes = _mapHandler.Map(modelRes, "Model.Reservation", "Google.Reservation");

            MappingResultPrinter.PrintSuccess("Model.Reservation", "Google.Reservation", modelRes, googleRes);
        }
        catch (Exception ex)
        {
            MappingResultPrinter.PrintError(ex);
        }

        // Demo02: Invalid data -> missing guest name
        try
        {
            var modelRes = ModelReservationSamples.MissingGuestName();
            var googleRes = _mapHandler.Map(modelRes, "Model.Reservation", "Google.Reservation");

            MappingResultPrinter.PrintSuccess("Model.Reservation", "Google.Reservation", modelRes, googleRes);
        }
        catch (Exception ex)
        {
            MappingResultPrinter.PrintError(ex);
        }

        // Demo03: Invalid data -> missing check-in date
        try
        {
            var modelRes = ModelReservationSamples.MissingCheckIn();
            var googleRes = _mapHandler.Map(modelRes, "Model.Reservation", "Google.Reservation");

            MappingResultPrinter.PrintSuccess("Model.Reservation", "Google.Reservation", modelRes, googleRes);
        }
        catch (Exception ex)
        {
            MappingResultPrinter.PrintError(ex);
        }
    }
}
