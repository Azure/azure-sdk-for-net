// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Text.Json;
using ModelContextProtocol.Server;

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// MCP tool that moves test samples from tests/Generated/Samples/ to tests/Samples/
/// and cleans up the empty Generated directory.
/// </summary>
[McpServerToolType]
public static class SampleMigrationTool
{
    [McpServerTool(Name = "migrate_test_samples"), Description("Move test samples from tests/Generated/Samples/ to tests/Samples/ and clean up.")]
    public static string Execute(
        [Description("Absolute path to the SDK project directory")] string projectPath)
    {
        var (success, filesMoved, error) = ExecuteInProcess(projectPath);
        if (!success)
        {
            return JsonSerializer.Serialize(new { success = false, error });
        }
        return JsonSerializer.Serialize(new { success = true, filesMoved });
    }

    /// <summary>
    /// In-process execution for the orchestrator.
    /// </summary>
    public static (bool Success, int FilesMoved, string? Error) ExecuteInProcess(string projectPath)
    {
        try
        {
            var normalizedPath = Path.GetFullPath(projectPath);
            var generatedSamplesDir = Path.Combine(normalizedPath, "tests", "Generated", "Samples");

            if (!Directory.Exists(generatedSamplesDir))
            {
                return (true, 0, null);
            }

            var targetSamplesDir = Path.Combine(normalizedPath, "tests", "Samples");
            Directory.CreateDirectory(targetSamplesDir);

            var files = Directory.GetFiles(generatedSamplesDir, "*", SearchOption.AllDirectories);
            var moved = 0;

            foreach (var file in files)
            {
                var relativePath = Path.GetRelativePath(generatedSamplesDir, file);
                var targetFile = Path.Combine(targetSamplesDir, relativePath);

                var targetDir = Path.GetDirectoryName(targetFile)!;
                Directory.CreateDirectory(targetDir);

                File.Move(file, targetFile, overwrite: true);
                moved++;
            }

            // Clean up empty Generated/Samples directory
            TryDeleteEmptyDirectories(generatedSamplesDir);

            var generatedDir = Path.Combine(normalizedPath, "tests", "Generated");
            if (Directory.Exists(generatedDir) && Directory.GetFileSystemEntries(generatedDir).Length == 0)
            {
                Directory.Delete(generatedDir);
            }

            return (true, moved, null);
        }
        catch (Exception ex)
        {
            return (false, 0, ex.Message);
        }
    }

    private static void TryDeleteEmptyDirectories(string path)
    {
        if (!Directory.Exists(path))
        {
            return;
        }

        foreach (var dir in Directory.GetDirectories(path))
        {
            TryDeleteEmptyDirectories(dir);
        }

        if (Directory.GetFileSystemEntries(path).Length == 0)
        {
            Directory.Delete(path);
        }
    }
}
