// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.RegularExpressions;

namespace Azure.GeneratorAgent.Mcp;

/// <summary>
/// Scans the Generated/ folder of a project to build a dynamic type→namespace map.
/// This allows the classifier to resolve CS0246 ("type not found") errors without
/// hardcoding every possible type name. It also discovers public member names for
/// resolving CS1061 / CS0117 errors.
/// </summary>
public sealed class GeneratedCodeIndex
{
    private static readonly Regex s_namespaceRegex = new(
        @"^\s*namespace\s+(?<ns>[A-Za-z_][\w.]*)",
        RegexOptions.Compiled | RegexOptions.Multiline);

    private static readonly Regex s_typeDeclarationRegex = new(
        @"(?:public|internal)\s+(?:static\s+)?(?:partial\s+)?(?:abstract\s+)?(?:partial\s+)?(?:class|struct|enum|interface)\s+(?<typeName>\w+)",
        RegexOptions.Compiled);

    /// <summary>
    /// Map of type name → namespace discovered from Generated/ files.
    /// </summary>
    public IReadOnlyDictionary<string, string> TypeToNamespace { get; }

    private GeneratedCodeIndex(Dictionary<string, string> typeToNamespace)
    {
        TypeToNamespace = typeToNamespace;
    }

    /// <summary>
    /// Builds an index by scanning the Generated/ folder under the given project src path.
    /// Returns an empty index if the folder doesn't exist.
    /// </summary>
    /// <param name="projectSrcPath">
    /// Path to the project directory (containing the .csproj) or the .csproj file itself.
    /// The Generated/ folder is expected at {projectSrcPath}/Generated/ or {parent}/src/Generated/.
    /// </param>
    public static GeneratedCodeIndex Build(string projectSrcPath)
    {
        var typeMap = new Dictionary<string, string>(StringComparer.Ordinal);

        var generatedDir = FindGeneratedDirectory(projectSrcPath);
        if (generatedDir is null || !Directory.Exists(generatedDir))
        {
            return new GeneratedCodeIndex(typeMap);
        }

        foreach (var file in Directory.EnumerateFiles(generatedDir, "*.cs", SearchOption.AllDirectories))
        {
            ScanFile(file, typeMap);
        }

        return new GeneratedCodeIndex(typeMap);
    }

    /// <summary>
    /// Tries to resolve a type name to a namespace using the generated code index.
    /// Returns null if the type is not found.
    /// </summary>
    public string? ResolveNamespace(string typeName)
    {
        return TypeToNamespace.TryGetValue(typeName, out var ns) ? ns : null;
    }

    private static string? FindGeneratedDirectory(string projectPath)
    {
        // If it's a .csproj file, look in its directory
        var dir = File.Exists(projectPath) ? Path.GetDirectoryName(projectPath)! : projectPath;

        // Try direct Generated/
        var candidate = Path.Combine(dir, "Generated");
        if (Directory.Exists(candidate))
        {
            return candidate;
        }

        // Try src/Generated/ (if projectPath is the parent of src/)
        candidate = Path.Combine(dir, "src", "Generated");
        if (Directory.Exists(candidate))
        {
            return candidate;
        }

        return null;
    }

    private static void ScanFile(string filePath, Dictionary<string, string> typeMap)
    {
        string content;
        try
        {
            content = File.ReadAllText(filePath);
        }
        catch
        {
            return;
        }

        // Find the namespace in this file
        var nsMatch = s_namespaceRegex.Match(content);
        if (!nsMatch.Success)
        {
            return;
        }

        var ns = nsMatch.Groups["ns"].Value;

        // Find all type declarations
        foreach (Match typeMatch in s_typeDeclarationRegex.Matches(content))
        {
            var typeName = typeMatch.Groups["typeName"].Value;
            // First one wins — in case of partial classes across files,
            // they should all be in the same namespace anyway.
            typeMap.TryAdd(typeName, ns);
        }
    }
}
