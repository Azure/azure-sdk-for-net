// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Optimization;

/// <summary>
/// Result of <see cref="OptimizationConfigLoader.LoadConfig(LoadConfigOptions)"/>.
/// Carries the resolved config (if any), the source that produced it, and any
/// non-fatal warnings encountered along the resolution waterfall.
/// </summary>
public class LoadConfigResult
{
    private static readonly IReadOnlyList<string> s_emptyWarnings = Array.Empty<string>();

    /// <summary>
    /// Initializes a new <see cref="LoadConfigResult"/>.
    /// </summary>
    public LoadConfigResult(OptimizationConfig config, string sourceUsed, IReadOnlyList<string> warnings = null)
    {
        Config = config;
        SourceUsed = sourceUsed;
        Warnings = warnings ?? s_emptyWarnings;
    }

    /// <summary>
    /// The resolved optimization config, or <c>null</c> when no source produced one.
    /// </summary>
    public OptimizationConfig Config { get; }

    /// <summary>
    /// The source string from the priority that produced <see cref="Config"/>, e.g.
    /// <c>api:candidate:abc</c>, <c>env:OPTIMIZATION_CONFIG</c>,
    /// <c>local:/path/cand_abc</c>, or <c>local:/path/baseline</c>. <c>null</c> when
    /// <see cref="Config"/> is <c>null</c>.
    /// </summary>
    public string SourceUsed { get; }

    /// <summary>
    /// Non-fatal warnings produced during resolution. In strict mode these conditions
    /// would have thrown instead; in non-strict mode they are recorded here so callers
    /// can surface them to logs.
    /// </summary>
    public IReadOnlyList<string> Warnings { get; }

    /// <summary>
    /// An empty result indicating no source produced a config and no warnings were raised.
    /// </summary>
    public static LoadConfigResult Empty { get; } = new LoadConfigResult(null, null);
}
