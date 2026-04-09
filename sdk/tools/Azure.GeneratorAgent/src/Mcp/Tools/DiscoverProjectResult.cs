// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.GeneratorAgent.Mcp.Tools;

/// <summary>
/// Result of project discovery — provides all plane-specific context for a migration.
/// </summary>
public sealed class DiscoverProjectResult
{
    public bool Success { get; set; }
    public string? Error { get; set; }

    /// <summary>"dpg" or "mpg".</summary>
    public string Plane { get; set; } = string.Empty;

    /// <summary>Full NuGet package / directory name (e.g., Azure.ResourceManager.Compute).</summary>
    public string PackageName { get; set; } = string.Empty;

    /// <summary>Service directory name under sdk/ (e.g., "compute").</summary>
    public string ServiceName { get; set; } = string.Empty;

    /// <summary>Workspace-relative library path (e.g., sdk/compute/Azure.ResourceManager.Compute).</summary>
    public string LibraryPath { get; set; } = string.Empty;

    /// <summary>Path to the emitter package.json for this plane.</summary>
    public string EmitterPackageJsonPath { get; set; } = string.Empty;

    /// <summary>Emitter key in tspconfig.yaml (e.g., @azure-typespec/http-client-csharp-mgmt).</summary>
    public string EmitterKey { get; set; } = string.Empty;

    /// <summary>Whether tsp-location.yaml exists (already TypeSpec-based).</summary>
    public bool HasTspLocation { get; set; }

    /// <summary>Whether src/autorest.md exists (legacy Swagger).</summary>
    public bool HasAutorestMd { get; set; }

    /// <summary>Custom code folder name if found (Custom, Customization, or Customized), null if none.</summary>
    public string? CustomCodeFolder { get; set; }

    /// <summary>List of API surface file paths (e.g., api/Azure.ResourceManager.Compute.netstandard2.0.cs).</summary>
    public List<string> ApiSurfaceFiles { get; set; } = [];

    /// <summary>Parsed fields from tsp-location.yaml (commit, directory, repo, etc.), null if no tsp-location.yaml.</summary>
    public Dictionary<string, string>? TspLocationFields { get; set; }

    /// <summary>
    /// Absolute path to the local azure-rest-api-specs clone, or null if not found.
    /// </summary>
    public string? SpecsRepoPath { get; set; }
}
