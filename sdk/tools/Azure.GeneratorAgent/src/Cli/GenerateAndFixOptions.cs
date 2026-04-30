// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.GeneratorAgent.Cli;

/// <summary>
/// Inputs to the <see cref="GenerateAndFixOrchestrator"/>.
/// </summary>
public sealed class GenerateAndFixOptions
{
    /// <summary>
    /// Absolute path to the SDK project directory (contains src/ and tsp-location.yaml).
    /// </summary>
    public string ProjectPath { get; init; } = string.Empty;

    /// <summary>
    /// Optional absolute path to a local azure-rest-api-specs clone or a specific spec directory.
    /// When null, generation uses the configured tsp-location.yaml commit.
    /// </summary>
    public string? LocalSpecsPath { get; init; }

    /// <summary>
    /// Maximum number of build → fix iterations. Defaults to 10.
    /// </summary>
    public int MaxIterations { get; init; } = 10;

    /// <summary>
    /// When true, skip the code generation step and run only the build–fix loop.
    /// Useful when CI wants to validate fixes against an already-generated tree.
    /// </summary>
    public bool SkipGeneration { get; init; }
}
