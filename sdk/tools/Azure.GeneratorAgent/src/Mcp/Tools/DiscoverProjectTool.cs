// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Text.Json;
using ModelContextProtocol.Server;

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// MCP tool that discovers project metadata: plane (dpg/mpg), package name, service directory,
/// emitter config, custom code folder, API surface files, and tsp-location.yaml fields.
/// </summary>
[McpServerToolType]
public static class DiscoverProjectTool
{
    private const string MgmtEmitterPackageJsonPath = "eng/azure-typespec-http-client-csharp-mgmt-emitter-package.json";
    private const string DpgEmitterPackageJsonPath = "eng/azure-typespec-http-client-csharp-emitter-package.json";
    private const string MgmtEmitterKey = "@azure-typespec/http-client-csharp-mgmt";
    private const string DpgEmitterKey = "@azure-typespec/http-client-csharp";

    private static readonly string[] s_customCodeFolderNames = ["Custom", "Customization", "Customized"];

    private static readonly string[] s_tspLocationFields = ["directory", "commit", "repo", "cleanup", "additionalDirectories", "emitterPackageJsonPath"];

    [McpServerTool(Name = "discover_project"), Description(
        "Discover project metadata: plane (dpg/mpg), package name, service directory, emitter config, " +
        "custom code folder, API surface files, and tsp-location.yaml fields. " +
        "Call this first to get all context needed for migration.")]
    public static string Execute(
        [Description("Absolute path to the SDK project directory (e.g., C:\\repo\\sdk\\compute\\Azure.ResourceManager.Compute)")] string projectPath)
    {
        var result = ExecuteInProcess(projectPath);
        return JsonSerializer.Serialize(result);
    }

    /// <summary>
    /// In-process execution for the orchestrator and tests.
    /// </summary>
    public static DiscoverProjectResult ExecuteInProcess(string projectPath)
    {
        try
        {
            var normalizedPath = Path.GetFullPath(projectPath);
            if (!Directory.Exists(normalizedPath))
            {
                return new DiscoverProjectResult { Error = $"Directory not found: {normalizedPath}" };
            }

            var packageName = Path.GetFileName(normalizedPath);
            var isMgmt = packageName.StartsWith("Azure.ResourceManager.", StringComparison.Ordinal);

            // Resolve service name: parent directory under sdk/
            var serviceName = ResolveServiceName(normalizedPath);

            // Resolve library path relative to the sdk root
            var libraryPath = ResolveLibraryPath(normalizedPath);

            // Check for tsp-location.yaml
            var tspLocationPath = Path.Combine(normalizedPath, "tsp-location.yaml");
            var hasTspLocation = File.Exists(tspLocationPath);
            Dictionary<string, string>? tspLocationFieldValues = null;

            if (hasTspLocation)
            {
                tspLocationFieldValues = ParseTspLocation(tspLocationPath);

                // Override plane detection from emitterPackageJsonPath if available
                if (tspLocationFieldValues.TryGetValue("emitterPackageJsonPath", out var emitterPath))
                {
                    if (emitterPath.Contains("mgmt", StringComparison.OrdinalIgnoreCase))
                    {
                        isMgmt = true;
                    }
                    else if (emitterPath.Contains("http-client-csharp", StringComparison.OrdinalIgnoreCase)
                             && !emitterPath.Contains("mgmt", StringComparison.OrdinalIgnoreCase))
                    {
                        isMgmt = false;
                    }
                }
            }

            // Check for autorest.md
            var hasAutorestMd = File.Exists(Path.Combine(normalizedPath, "src", "autorest.md"));

            // Find custom code folder
            var customCodeFolder = FindCustomCodeFolder(normalizedPath);

            // Find API surface files
            var apiSurfaceFiles = FindApiSurfaceFiles(normalizedPath);

            // Detect local azure-rest-api-specs clone as sibling of SDK repo root
            var specsRepoPath = FindSpecsRepo(normalizedPath);

            return new DiscoverProjectResult
            {
                Success = true,
                Plane = isMgmt ? "mpg" : "dpg",
                PackageName = packageName,
                ServiceName = serviceName,
                LibraryPath = libraryPath,
                EmitterPackageJsonPath = isMgmt ? MgmtEmitterPackageJsonPath : DpgEmitterPackageJsonPath,
                EmitterKey = isMgmt ? MgmtEmitterKey : DpgEmitterKey,
                HasTspLocation = hasTspLocation,
                HasAutorestMd = hasAutorestMd,
                CustomCodeFolder = customCodeFolder,
                ApiSurfaceFiles = apiSurfaceFiles,
                TspLocationFields = tspLocationFieldValues,
                SpecsRepoPath = specsRepoPath,
            };
        }
        catch (Exception ex)
        {
            return new DiscoverProjectResult { Error = ex.Message };
        }
    }

    /// <summary>
    /// Resolves the service directory name (the folder immediately under sdk/).
    /// </summary>
    internal static string ResolveServiceName(string projectPath)
    {
        // Walk up until we find "sdk" as a parent directory name
        var dir = new DirectoryInfo(projectPath);
        while (dir.Parent is not null)
        {
            if (string.Equals(dir.Parent.Name, "sdk", StringComparison.OrdinalIgnoreCase))
            {
                return dir.Name;
            }
            dir = dir.Parent;
        }

        // Fallback: use immediate parent
        var parent = Directory.GetParent(projectPath);
        return parent?.Name ?? string.Empty;
    }

    /// <summary>
    /// Resolves the workspace-relative library path (e.g., sdk/compute/Azure.ResourceManager.Compute).
    /// </summary>
    internal static string ResolveLibraryPath(string projectPath)
    {
        var dir = new DirectoryInfo(projectPath);
        var parts = new List<string>();
        while (dir is not null)
        {
            parts.Add(dir.Name);
            if (string.Equals(dir.Name, "sdk", StringComparison.OrdinalIgnoreCase))
            {
                parts.Reverse();
                return string.Join('/', parts);
            }
            dir = dir.Parent;
        }

        // Fallback: just return the package name
        return Path.GetFileName(projectPath);
    }

    /// <summary>
    /// Parses tsp-location.yaml into a dictionary of known fields.
    /// </summary>
    internal static Dictionary<string, string> ParseTspLocation(string tspLocationPath)
    {
        var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        var content = File.ReadAllText(tspLocationPath);

        foreach (var fieldName in s_tspLocationFields)
        {
            var prefix = $"{fieldName}:";
            foreach (var line in content.Split('\n'))
            {
                var trimmed = line.Trim();
                if (trimmed.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                {
                    var value = trimmed[prefix.Length..].Trim().Trim('"', '\'');
                    if (!string.IsNullOrEmpty(value))
                    {
                        result[fieldName] = value;
                    }
                    break;
                }
            }
        }

        return result;
    }

    /// <summary>
    /// Finds the custom code folder name (Custom, Customization, or Customized) under src/.
    /// </summary>
    internal static string? FindCustomCodeFolder(string projectPath)
    {
        var srcPath = Path.Combine(projectPath, "src");
        if (!Directory.Exists(srcPath))
        {
            return null;
        }

        foreach (var name in s_customCodeFolderNames)
        {
            if (Directory.Exists(Path.Combine(srcPath, name)))
            {
                return name;
            }
        }

        return null;
    }

    /// <summary>
    /// Finds API surface listing files under the api/ directory.
    /// </summary>
    internal static List<string> FindApiSurfaceFiles(string projectPath)
    {
        var apiDir = Path.Combine(projectPath, "api");
        if (!Directory.Exists(apiDir))
        {
            return [];
        }

        return Directory.GetFiles(apiDir, "*.cs")
            .Select(Path.GetFileName)
            .Where(f => f is not null)
            .Select(f => $"api/{f}")
            .ToList()!;
    }

    /// <summary>
    /// Finds the local azure-rest-api-specs clone by looking for a sibling directory
    /// of the SDK repository root. Returns the absolute path, or null if not found.
    /// </summary>
    internal static string? FindSpecsRepo(string projectPath)
    {
        // Walk up to find the git repo root (azure-sdk-for-net)
        var dir = new DirectoryInfo(projectPath);
        string? repoRoot = null;
        while (dir is not null)
        {
            if (Directory.Exists(Path.Combine(dir.FullName, ".git")))
            {
                repoRoot = dir.FullName;
                break;
            }
            dir = dir.Parent;
        }

        if (repoRoot is null)
        {
            return null;
        }

        var parent = Directory.GetParent(repoRoot);
        if (parent is null)
        {
            return null;
        }

        var specsPath = Path.Combine(parent.FullName, "azure-rest-api-specs");
        return Directory.Exists(specsPath) ? Path.GetFullPath(specsPath) : null;
    }
}
