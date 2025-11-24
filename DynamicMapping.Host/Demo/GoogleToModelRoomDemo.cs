namespace DynamicMapping.Host.Demo;

using DynamicMapping.Host.Output;
using DynamicMapping.Host.Data;
using DynamicMapping.Core.Engine;

internal class GoogleToModelRoomDemo
{
    private readonly MapHandler _mapHandler;

    public GoogleToModelRoomDemo(MapHandler mapHandler)
    {
        _mapHandler = mapHandler;
    }

    public void RunDemo()
    {
        // Demo01: Passed mapping
        try
        {
            var googleRoom = GoogleRoomSamples.BasicRoom();
            var modelRoom = _mapHandler.Map(googleRoom, "Google.Room", "Model.Room");

            MappingResultPrinter.PrintSuccess("Google.Room", "Model.Room", googleRoom, modelRoom);
        }
        catch (Exception ex)
        {
            MappingResultPrinter.PrintError(ex);
        }

        // Demo02: Failed mapping -> incorrect target type
        try
        {
            var googleRoom = GoogleRoomSamples.BasicRoom();
            var modelRoom = _mapHandler.Map(googleRoom, "Google.Room", "Model.Roo");

            MappingResultPrinter.PrintSuccess("Google.Room", "Model.Roo", googleRoom, modelRoom);
        }
        catch (Exception ex)
        {
            MappingResultPrinter.PrintError(ex);
        }

        // Demo03: Invalid data -> unknown room capacity
        try
        {
            var googleRoom = GoogleRoomSamples.UnknownCapacity();
            var modelRoom = _mapHandler.Map(googleRoom, "Google.Room", "Model.Room");

            MappingResultPrinter.PrintSuccess("Google.Room", "Model.Room", googleRoom, modelRoom);
        }
        catch (Exception ex)
        {
            MappingResultPrinter.PrintError(ex);
        }
    }
}
