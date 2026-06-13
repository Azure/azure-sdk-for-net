// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Text.Json;
using System.Text.RegularExpressions;
using ModelContextProtocol.Server;

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// MCP tool that performs regex-based replacements in source files.
/// Handles field renames, type pattern replacements, namespace prefix removal, and duplicate namespace fixes.
/// </summary>
[McpServerToolType]
public static class RegexReplacementTool
{
    [McpServerTool(Name = "regex_replacement"), Description("Perform a regex replacement in a source file. Used for field renames, type pattern replacements, namespace prefix removal, and duplicate namespace fixes.")]
    public static string Execute(
        [Description("Absolute path to the file to modify")] string filePath,
        [Description("Regex pattern to search for")] string pattern,
        [Description("Replacement string (may include $1, $2 capture group references)")] string replacement,
        [Description("Set to 'true' to enable Singleline mode (dot matches newlines, for cross-line patterns)")] string? singleLine = null)
    {
        try
        {
            var useSingleLine = string.Equals(singleLine, "true", StringComparison.OrdinalIgnoreCase);
            var (success, count, error) = ExecuteInProcess(filePath, pattern, replacement, useSingleLine);
            if (!success)
            {
                return JsonSerializer.Serialize(new { success = false, error });
            }
            return JsonSerializer.Serialize(new { success = true, modified = count > 0, replacements = count });
        }
        catch (Exception ex)
        {
            return JsonSerializer.Serialize(new { success = false, error = ex.Message });
        }
    }

    /// <summary>
    /// In-process execution for use by the orchestrator (avoids MCP serialization overhead).
    /// </summary>
    public static (bool Success, int ReplacementCount, string? Error) ExecuteInProcess(string filePath, string pattern, string replacement, bool singleLine = false)
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
            var options = singleLine ? RegexOptions.Singleline : RegexOptions.None;
            var regex = new Regex(pattern, options);
            var matchCount = regex.Matches(content).Count;
            if (matchCount == 0)
            {
                return (true, 0, null);
            }

            var newContent = regex.Replace(content, replacement);
            File.WriteAllText(normalizedPath, newContent);
            return (true, matchCount, null);
        }
        catch (Exception ex)
        {
            return (false, 0, ex.Message);
        }
    }
}
