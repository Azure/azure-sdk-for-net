// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Text.Json;
using System.Text.RegularExpressions;
using ModelContextProtocol.Server;

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// MCP tool that adds a using directive to a C# source file if not already present.
/// </summary>
[McpServerToolType]
public static class AddUsingDirectiveTool
{
    private static readonly Regex s_usingBlockRegex = new(
        @"^using\s+[^;]+;\s*$",
        RegexOptions.Compiled | RegexOptions.Multiline);

    [McpServerTool(Name = "add_using_directive"), Description("Add a using directive to a C# file if not already present.")]
    public static string Execute(
        [Description("Absolute path to the C# file")] string filePath,
        [Description("The namespace to add (e.g., 'Azure.Core.Pipeline')")] string @namespace)
    {
        var (success, added, error) = ExecuteInProcess(filePath, @namespace);
        if (!success)
        {
            return JsonSerializer.Serialize(new { success = false, error });
        }
        return JsonSerializer.Serialize(new { success = true, added, @namespace });
    }

    /// <summary>
    /// In-process execution for use by the orchestrator.
    /// </summary>
    public static (bool Success, bool Added, string? Error) ExecuteInProcess(string filePath, string @namespace)
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

            var content = File.ReadAllText(normalizedPath);
            var usingDirective = $"using {@namespace};";

            if (content.Contains(usingDirective, StringComparison.Ordinal))
            {
                return (true, false, null);
            }

            // Find the last using directive and insert after its full line (including newline)
            var matches = s_usingBlockRegex.Matches(content);
            if (matches.Count > 0)
            {
                var lastUsing = matches[^1];
                var insertPos = lastUsing.Index + lastUsing.Length;

                // Skip past the line terminator so the new using starts on its own line
                if (insertPos < content.Length && content[insertPos] == '\r')
                {
                    insertPos++;
                }
                if (insertPos < content.Length && content[insertPos] == '\n')
                {
                    insertPos++;
                }

                var newContent = content.Insert(insertPos, usingDirective + Environment.NewLine);
                File.WriteAllText(normalizedPath, newContent);
                return (true, true, null);
            }

            // No existing usings — insert at the top (after any copyright header)
            var headerEndPos = 0;
            var searchPos = 0;
            while (searchPos < content.Length)
            {
                var lineEnd = content.IndexOf('\n', searchPos);
                var lineContent = lineEnd >= 0
                    ? content[searchPos..lineEnd]
                    : content[searchPos..];
                var trimmed = lineContent.TrimStart();
                if (trimmed.StartsWith("//", StringComparison.Ordinal) || string.IsNullOrWhiteSpace(trimmed))
                {
                    headerEndPos = lineEnd >= 0 ? lineEnd + 1 : content.Length;
                    searchPos = headerEndPos;
                    continue;
                }
                break;
            }

            var newContent2 = content.Insert(headerEndPos, usingDirective + Environment.NewLine);
            File.WriteAllText(normalizedPath, newContent2);
            return (true, true, null);
        }
        catch (Exception ex)
        {
            return (false, false, ex.Message);
        }
    }
}
