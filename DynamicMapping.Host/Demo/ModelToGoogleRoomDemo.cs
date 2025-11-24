namespace DynamicMapping.Host.Demo;

using DynamicMapping.Host.Output;
using DynamicMapping.Host.Data;
using DynamicMapping.Core.Engine;

internal class ModelToGoogleRoomDemo
{
    private readonly MapHandler _mapHandler;

    public ModelToGoogleRoomDemo(MapHandler mapHandler)
    {
        _mapHandler = mapHandler;
    }

    public void RunDemo()
    {
        // Demo01: Passed mapping.
        try
        {
            var modelRoom = ModelRoomSamples.BasicRoom();
            var googleRoom = _mapHandler.Map(modelRoom, "Model.Room", "Google.Room");

            MappingResultPrinter.PrintSuccess("Model.Room", "Google.Room", modelRoom, googleRoom);
        }
        catch (Exception ex)
        {
            MappingResultPrinter.PrintError(ex);
        }

        // Demo02: Invalid data -> missing RoomCode
        try
        {
            var modelRoom = ModelRoomSamples.MissingRoomCode();
            var googleRoom = _mapHandler.Map(modelRoom, "Model.Room", "Google.Room");

            MappingResultPrinter.PrintSuccess("Model.Room", "Google.Room", modelRoom, googleRoom);
        }
        catch (Exception ex)
        {
            MappingResultPrinter.PrintError(ex);
        }
    }
}
