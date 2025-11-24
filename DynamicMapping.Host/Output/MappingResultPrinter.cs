namespace DynamicMapping.Host.Output;

using System;
using System.Text.Json;

internal static class MappingResultPrinter
{
    private static readonly JsonSerializerOptions _jsonOptions =
        new JsonSerializerOptions { WriteIndented = true };

    public static void PrintSuccess(string sourceType, string targetType, object sourceData, object targetData)
    {
        var input = JsonSerializer.Serialize(sourceData, _jsonOptions);
        var output = JsonSerializer.Serialize(targetData, _jsonOptions);

        Console.WriteLine(
$@"══════════════════════════════════════════════════════════════════════════════
SUCCESS
*********************
Source : {sourceType}
{input}
*********************
Target : {targetType}
{output}
══════════════════════════════════════════════════════════════════════════════
            ");
    }

    public static void PrintError(Exception ex)
    {
        Console.WriteLine(
$@"══════════════════════════════════════════════════════════════════════════════
ERROR
*********************
{ex.Message}
══════════════════════════════════════════════════════════════════════════════
            ");
    }
}
