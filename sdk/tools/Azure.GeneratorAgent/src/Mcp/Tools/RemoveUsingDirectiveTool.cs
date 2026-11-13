// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Text.Json;
using System.Text.RegularExpressions;
using ModelContextProtocol.Server;

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// MCP tool that removes using directives matching a namespace pattern from a C# file.
/// </summary>
[McpServerToolType]
public static class RemoveUsingDirectiveTool
{
    [McpServerTool(Name = "remove_using_directive"), Description("Remove using directives matching a namespace pattern from a C# file.")]
    public static string Execute(
        [Description("Absolute path to the C# file")] string filePath,
        [Description("Regex pattern to match the namespace in using directives to remove (e.g., 'SomeNamespace\\.Rest')")] string namespacePattern)
    {
        var (success, removedCount, error) = ExecuteInProcess(filePath, namespacePattern);
        if (!success)
        {
            return JsonSerializer.Serialize(new { success = false, error });
        }
        return JsonSerializer.Serialize(new { success = true, removed = removedCount });
    }

    /// <summary>
    /// In-process execution for use by the orchestrator.
    /// </summary>
    public static (bool Success, int RemovedCount, string? Error) ExecuteInProcess(string filePath, string namespacePattern)
    {
        try
        {
            var normalizedPath = Path.GetFullPath(filePath);

            var guardError = GeneratedPathGuard.ValidateNotGenerated(normalizedPath);
            if (guardError is not null)
            {
                return (false, 0, guardError);
            }

            if (!File.Exists(normalizedPath))
            {
                return (false, 0, $"File not found: {normalizedPath}");
            }

            var content = File.ReadAllText(normalizedPath);
            var regex = new Regex(
                $@"^\s*using\s+{namespacePattern}\s*;\s*\r?\n?",
                RegexOptions.Multiline);

            var matchCount = regex.Matches(content).Count;
            if (matchCount == 0)
            {
                return (true, 0, null);
            }

            var newContent = regex.Replace(content, string.Empty);
            File.WriteAllText(normalizedPath, newContent);
            return (true, matchCount, null);
        }
        catch (Exception ex)
        {
            return (false, 0, ex.Message);
        }
    }
}
