// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Text.Json;
using System.Text.RegularExpressions;
using ModelContextProtocol.Server;

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// MCP tool that fixes mismatched [CodeGenType] attributes when custom types
/// (e.g., *ModelFactory, *ClientBuilderExtensions) have different names than
/// their generated counterparts. Scans the project for the mismatch and updates
/// the attribute to match the generated type name.
/// </summary>
[McpServerToolType]
public static class RenameCodeGenTypeTool
{
    private static readonly Regex s_codeGenTypeAttrRegex = new(
        @"\[CodeGenType\(""(?<oldName>[^""]+)""\)\]",
        RegexOptions.Compiled);

    [McpServerTool(Name = "rename_codegen_type"), Description("Fix mismatched [CodeGenType] attributes by finding the generated counterpart and updating the custom type's attribute.")]
    public static string Execute(
        [Description("Absolute path to the SDK project directory")] string projectPath,
        [Description("Type suffix to match, e.g. 'ModelFactory' or 'ClientBuilderExtensions'")] string typeSuffix)
    {
        try
        {
            var (success, fixes, error) = ExecuteInProcess(projectPath, typeSuffix);
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
    /// Scans custom files for types ending with the given suffix, finds generated counterparts,
    /// and updates [CodeGenType] attributes to match.
    /// </summary>
    public static (bool Success, List<CodeGenTypeFix> Fixes, string? Error) ExecuteInProcess(string projectPath, string typeSuffix)
    {
        try
        {
            var normalizedPath = Path.GetFullPath(projectPath);
            var srcPath = Path.Combine(normalizedPath, "src");
            if (!Directory.Exists(srcPath))
            {
                return (true, new List<CodeGenTypeFix>(), null);
            }

            var generatedPath = Path.Combine(srcPath, "Generated");

            // Step 1: Find generated types with the suffix
            var generatedTypes = FindTypesWithSuffix(generatedPath, typeSuffix);
            if (generatedTypes.Count == 0)
            {
                return (true, new List<CodeGenTypeFix>(), null);
            }

            // Step 2: Find custom types with the suffix (outside Generated/)
            var customTypes = FindCustomTypesWithSuffix(srcPath, generatedPath, typeSuffix);

            // Step 3: Match and fix
            var fixes = new List<CodeGenTypeFix>();
            foreach (var custom in customTypes)
            {
                // Find the best matching generated type
                var generatedMatch = FindBestMatch(custom.ClassName, generatedTypes);
                if (generatedMatch is null || string.Equals(custom.ClassName, generatedMatch, StringComparison.Ordinal))
                {
                    continue;
                }

                // Check if there's already a [CodeGenType] attribute
                var content = File.ReadAllText(custom.FilePath);
                var attrMatch = s_codeGenTypeAttrRegex.Match(content);

                string newContent;
                if (attrMatch.Success)
                {
                    // Update existing [CodeGenType] attribute
                    if (string.Equals(attrMatch.Groups["oldName"].Value, generatedMatch, StringComparison.Ordinal))
                    {
                        continue; // Already correct
                    }
                    newContent = content.Replace(attrMatch.Value, $"[CodeGenType(\"{generatedMatch}\")]");
                }
                else
                {
                    // Add [CodeGenType] attribute before the class declaration
                    var classMatch = CSharpPatterns.ClassDeclaration.Match(content);
                    if (!classMatch.Success)
                    {
                        continue;
                    }
                    var insertPos = content.LastIndexOf('\n', classMatch.Index) + 1;
                    var indent = GetIndentation(content, classMatch.Index);
                    newContent = content.Insert(insertPos, $"{indent}[CodeGenType(\"{generatedMatch}\")]\n");
                }

                File.WriteAllText(custom.FilePath, newContent);
                fixes.Add(new CodeGenTypeFix(custom.FilePath, custom.ClassName, generatedMatch));
            }

            return (true, fixes, null);
        }
        catch (Exception ex)
        {
            return (false, new List<CodeGenTypeFix>(), ex.Message);
        }
    }

    private static List<string> FindTypesWithSuffix(string generatedPath, string suffix)
    {
        var types = new List<string>();
        if (!Directory.Exists(generatedPath))
        {
            return types;
        }

        foreach (var file in Directory.GetFiles(generatedPath, "*.cs", SearchOption.AllDirectories))
        {
            var content = File.ReadAllText(file);
            foreach (Match match in CSharpPatterns.ClassDeclaration.Matches(content))
            {
                var className = match.Groups["className"].Value;
                if (className.EndsWith(suffix, StringComparison.Ordinal))
                {
                    types.Add(className);
                }
            }
        }

        return types;
    }

    private static List<(string ClassName, string FilePath)> FindCustomTypesWithSuffix(string srcPath, string generatedPath, string suffix)
    {
        var results = new List<(string, string)>();
        var normalizedGenerated = Path.GetFullPath(generatedPath);

        foreach (var file in Directory.GetFiles(srcPath, "*.cs", SearchOption.AllDirectories))
        {
            var normalizedFile = Path.GetFullPath(file);
            if (normalizedFile.StartsWith(normalizedGenerated, StringComparison.OrdinalIgnoreCase))
            {
                continue; // Skip Generated/ files
            }

            var content = File.ReadAllText(file);
            foreach (Match match in CSharpPatterns.ClassDeclaration.Matches(content))
            {
                var className = match.Groups["className"].Value;
                if (className.EndsWith(suffix, StringComparison.Ordinal))
                {
                    results.Add((className, file));
                }
            }
        }

        return results;
    }

    /// <summary>
    /// Finds the best matching generated type for a custom type.
    /// Prefers exact suffix match after stripping common prefixes.
    /// </summary>
    private static string? FindBestMatch(string customName, List<string> generatedTypes)
    {
        if (generatedTypes.Count == 0)
        {
            return null;
        }

        // Exact match
        if (generatedTypes.Contains(customName))
        {
            return customName;
        }

        // If there's only one generated type with this suffix, that's the match
        if (generatedTypes.Count == 1)
        {
            return generatedTypes[0];
        }

        // Try to find closest match by common prefix length
        var bestMatch = generatedTypes[0];
        var bestScore = 0;

        foreach (var gen in generatedTypes)
        {
            var score = CommonPrefixLength(customName, gen);
            if (score > bestScore)
            {
                bestScore = score;
                bestMatch = gen;
            }
        }

        return bestMatch;
    }

    private static int CommonPrefixLength(string a, string b)
    {
        var len = Math.Min(a.Length, b.Length);
        for (var i = 0; i < len; i++)
        {
            if (a[i] != b[i])
            {
                return i;
            }
        }
        return len;
    }

    private static string GetIndentation(string content, int position)
    {
        var lineStart = content.LastIndexOf('\n', position) + 1;
        var indent = 0;
        while (lineStart + indent < content.Length && content[lineStart + indent] == ' ')
        {
            indent++;
        }
        return new string(' ', indent);
    }
}
