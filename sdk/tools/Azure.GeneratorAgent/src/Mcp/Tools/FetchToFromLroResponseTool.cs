// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Text.Json;
using System.Text.RegularExpressions;
using ModelContextProtocol.Server;

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// MCP tool that replaces legacy Fetch method calls in custom LRO methods
/// with the generated FromLroResponse static method.
/// Pattern: Fetch(response) → ResponseModel.FromLroResponse(response)
/// </summary>
[McpServerToolType]
public static class FetchToFromLroResponseTool
{
    // Matches patterns like: SomeType result = Fetch(response); or var result = Fetch(response);
    private static readonly Regex s_fetchCallRegex = new(
        @"(?<prefix>\w[\w<>,\s]*?\s+\w+\s*=\s*)Fetch\((?<args>[^)]+)\)",
        RegexOptions.Compiled);

    // Simpler match for just the Fetch(...) call itself
    private static readonly Regex s_simpleFetchRegex = new(
        @"\bFetch\((?<args>[^)]+)\)",
        RegexOptions.Compiled);

    // Extracts the type name from a variable assignment prefix (e.g., "MyModel result = ")
    private static readonly Regex s_varTypePrefixRegex = new(
        @"^(?<type>\w+)\s+\w+\s*=\s*$",
        RegexOptions.Compiled);

    // Matches FromLroResponse methods in Generated/ code
    private static readonly Regex s_fromLroResponseRegex = new(
        @"static\s+(?<returnType>\w+)\s+FromLroResponse\s*\(",
        RegexOptions.Compiled);

    [McpServerTool(Name = "fetch_to_fromlro"), Description("Replace legacy Fetch(response) calls with ResponseModel.FromLroResponse(response) in custom LRO methods.")]
    public static string Execute(
        [Description("Absolute path to the SDK project directory")] string projectPath)
    {
        try
        {
            var (success, fixes, error) = ExecuteInProcess(projectPath);
            if (!success)
            {
                return JsonSerializer.Serialize(new { success = false, error });
            }
            return JsonSerializer.Serialize(new { success = true, fixesApplied = fixes });
        }
        catch (Exception ex)
        {
            return JsonSerializer.Serialize(new { success = false, error = ex.Message });
        }
    }

    /// <summary>
    /// In-process execution for the orchestrator.
    /// Scans custom files for Fetch() calls and replaces them with the appropriate
    /// FromLroResponse call discovered from Generated/ code.
    /// </summary>
    public static (bool Success, int FixCount, string? Error) ExecuteInProcess(string projectPath)
    {
        try
        {
            var normalizedPath = Path.GetFullPath(projectPath);
            var srcPath = Path.Combine(normalizedPath, "src");
            if (!Directory.Exists(srcPath))
            {
                return (true, 0, null);
            }

            var generatedPath = Path.Combine(srcPath, "Generated");

            // Step 1: Discover FromLroResponse types from Generated/ code
            var lroResponseTypes = DiscoverLroResponseTypes(generatedPath);

            // Step 2: Scan custom files for Fetch() calls and replace
            var totalFixes = 0;
            var normalizedGenerated = Path.GetFullPath(generatedPath);

            foreach (var file in Directory.GetFiles(srcPath, "*.cs", SearchOption.AllDirectories))
            {
                var normalizedFile = Path.GetFullPath(file);
                if (normalizedFile.StartsWith(normalizedGenerated, StringComparison.OrdinalIgnoreCase))
                {
                    continue; // Skip Generated/ files
                }

                var content = File.ReadAllText(file);
                if (!s_simpleFetchRegex.IsMatch(content))
                {
                    continue;
                }

                var newContent = ReplaceFetchCalls(content, lroResponseTypes);
                if (!string.Equals(content, newContent, StringComparison.Ordinal))
                {
                    File.WriteAllText(file, newContent);
                    totalFixes++;
                }
            }

            return (true, totalFixes, null);
        }
        catch (Exception ex)
        {
            return (false, 0, ex.Message);
        }
    }

    /// <summary>
    /// Replaces Fetch() calls in a single file's content. Exposed for unit testing.
    /// </summary>
    public static string ReplaceFetchCalls(string content, Dictionary<string, string> lroResponseTypes)
    {
        // Strategy: for each Fetch call, try to determine the return type from
        // the variable assignment, then find the matching FromLroResponse type.

        return s_fetchCallRegex.Replace(content, match =>
        {
            var prefix = match.Groups["prefix"].Value;
            var args = match.Groups["args"].Value;

            // Try to extract the type from the prefix (e.g., "MyModel result = ")
            var typeMatch = s_varTypePrefixRegex.Match(prefix.Trim());
            if (typeMatch.Success)
            {
                var varType = typeMatch.Groups["type"].Value;
                if (varType != "var" && lroResponseTypes.ContainsKey(varType))
                {
                    return $"{prefix}{varType}.FromLroResponse({args})";
                }
                // Even if we don't have it in discovered types, use the variable type
                if (varType != "var")
                {
                    return $"{prefix}{varType}.FromLroResponse({args})";
                }
            }

            // Fallback: if we have exactly one FromLroResponse type, use it
            if (lroResponseTypes.Count == 1)
            {
                var singleType = lroResponseTypes.Values.First();
                return $"{prefix}{singleType}.FromLroResponse({args})";
            }

            // Can't determine the type — leave as-is for LLM to handle
            return match.Value;
        });
    }

    /// <summary>
    /// Discovers all types in Generated/ that have a FromLroResponse static method.
    /// Returns a dictionary mapping the return type name to the containing class name.
    /// </summary>
    public static Dictionary<string, string> DiscoverLroResponseTypes(string generatedPath)
    {
        var types = new Dictionary<string, string>(StringComparer.Ordinal);
        if (!Directory.Exists(generatedPath))
        {
            return types;
        }

        var classRegex = CSharpPatterns.ClassDeclaration;

        foreach (var file in Directory.GetFiles(generatedPath, "*.cs", SearchOption.AllDirectories))
        {
            var content = File.ReadAllText(file);
            if (!content.Contains("FromLroResponse", StringComparison.Ordinal))
            {
                continue;
            }

            // Find the class name
            var classMatch = classRegex.Match(content);
            if (!classMatch.Success)
            {
                continue;
            }

            var className = classMatch.Groups["className"].Value;

            // Find FromLroResponse methods
            foreach (Match lroMatch in s_fromLroResponseRegex.Matches(content))
            {
                var returnType = lroMatch.Groups["returnType"].Value;
                types[returnType] = className;
            }
        }

        return types;
    }
}
