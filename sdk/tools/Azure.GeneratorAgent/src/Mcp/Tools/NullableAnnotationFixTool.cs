// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Text.Json;
using System.Text.RegularExpressions;
using ModelContextProtocol.Server;

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// MCP tool that fixes CS8625/CS8600 nullable annotation errors by adding ? to the type
/// declaration on the specified line.
/// </summary>
[McpServerToolType]
public static class NullableAnnotationFixTool
{
    // Matches a type in a variable declaration, parameter, or return type position
    // and adds ? if not already present. Supports PascalCase types AND C# keyword types
    // (string, object, int, etc.) and qualified names.
    private static readonly Regex s_nullableFixRegex = new(
        @"(?<=\s)(?<type>(?:[a-zA-Z]\w*\.)*[a-zA-Z]\w+(?:<[^>]+>)?)(?<nullable>\??)(?=\s+\w+)",
        RegexOptions.Compiled);

    [McpServerTool(Name = "nullable_annotation_fix"), Description("Fix CS8625/CS8600 errors by adding ? nullable annotation to the type on a specified line.")]
    public static string Execute(
        [Description("Absolute path to the C# file")] string filePath,
        [Description("1-based line number where the error occurs")] string line)
    {
        var (success, modified, error) = ExecuteInProcess(filePath, line);
        if (!success)
        {
            return JsonSerializer.Serialize(new { success = false, error });
        }
        return JsonSerializer.Serialize(new { success = true, modified });
    }

    /// <summary>
    /// In-process execution for use by the orchestrator.
    /// </summary>
    public static (bool Success, bool Modified, string? Error) ExecuteInProcess(string filePath, string lineStr)
    {
        try
        {
            var normalizedPath = Path.GetFullPath(filePath);

            var guardError = GeneratedPathGuard.ValidateNotGenerated(normalizedPath);
            if (guardError is not null)
            {
                return (false, false, guardError);
            }

            if (!File.Exists(normalizedPath))
            {
                return (false, false, $"File not found: {normalizedPath}");
            }

            if (!int.TryParse(lineStr, out var lineNum) || lineNum < 1)
            {
                return (false, false, $"Invalid line number: {lineStr}");
            }

            var content = File.ReadAllText(normalizedPath);
            var lines = content.Split('\n');
            if (lineNum > lines.Length)
            {
                return (false, false, $"Line {lineNum} exceeds file length {lines.Length}");
            }

            var targetLine = lines[lineNum - 1];

            // Skip comment-only lines — no type declarations to fix
            var trimmedLine = targetLine.TrimStart();
            if (trimmedLine.StartsWith("//", StringComparison.Ordinal) || trimmedLine.StartsWith("/*", StringComparison.Ordinal))
            {
                return (true, false, null);
            }

            var match = s_nullableFixRegex.Match(targetLine);
            if (!match.Success)
            {
                return (true, false, null);
            }

            // If already nullable, skip
            if (match.Groups["nullable"].Value == "?")
            {
                return (true, false, null);
            }

            // Insert ? after the type name
            var typeGroup = match.Groups["type"];
            var insertPos = typeGroup.Index + typeGroup.Length;
            var newLine = targetLine.Insert(insertPos, "?");
            lines[lineNum - 1] = newLine;

            File.WriteAllText(normalizedPath, string.Join("\n", lines));
            return (true, true, null);
        }
        catch (Exception ex)
        {
            return (false, false, ex.Message);
        }
    }
}
