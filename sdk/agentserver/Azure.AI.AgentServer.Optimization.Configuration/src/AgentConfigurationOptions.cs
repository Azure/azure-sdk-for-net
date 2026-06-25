// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.AI.AgentServer.Optimization.Configuration;

/// <summary>
/// Options controlling how an <see cref="AgentConfigurationSource"/> resolves and
/// projects an optimization configuration into the <see cref="Microsoft.Extensions.Configuration.IConfiguration"/> tree.
/// </summary>
/// <remarks>
/// <para>
/// At <see cref="AgentConfigurationProvider.Load"/> time the source runs the same
/// 4-priority waterfall as <see cref="AgentOptimizationClient.ResolveOptions(LoadOptions)"/>
/// (resolver API → inline JSON → local candidate directory → local baseline directory)
/// and flattens the resulting <see cref="OptimizationOptions"/> into the configuration
/// dictionary under <see cref="SectionName"/>.
/// </para>
/// <para>
/// The single-agent default places keys under the <c>Agent:*</c> section.
/// The multi-agent overload (when <see cref="AgentKey"/> is set) places keys under
/// <c>Agents:&lt;AgentKey&gt;:*</c>.
/// </para>
/// </remarks>
public class AgentConfigurationOptions
{
    /// <summary>
    /// The logical key for this agent in a multi-agent host. When set, the loader
    /// reads per-agent suffixed environment variables (<c>OPTIMIZATION_&lt;VAR&gt;__&lt;CANONICAL_KEY&gt;</c>)
    /// and the configuration values are projected under <c>Agents:&lt;AgentKey&gt;:*</c>.
    /// Leave <c>null</c> for the single-agent default which uses the <c>Agent</c> section.
    /// </summary>
    /// <remarks>
    /// The key must contain only ASCII letters, digits, hyphen, and underscore.
    /// Configuration keys are case-insensitive, so the canonical form follows
    /// <see cref="AgentKeyCanonicalizer"/>'s rules.
    /// </remarks>
    public string? AgentKey { get; set; }

    /// <summary>
    /// Explicit configuration section name to project values into. When set, this
    /// overrides the default derived from <see cref="AgentKey"/>.
    /// </summary>
    /// <remarks>
    /// Use this when you want optimization values under a custom section, or when you
    /// want the multi-agent provider to share a section with values from another source
    /// (e.g. appsettings). Validation rejects null/empty and leading/trailing <c>:</c>.
    /// </remarks>
    public string? SectionName { get; set; }

    /// <summary>
    /// Azure credential used to authenticate the resolver API request (Priority 1)
    /// when <c>OPTIMIZATION_RESOLVE_ENDPOINT</c> is used. When <c>null</c>, the
    /// provider can still resolve inline JSON and local-directory fallbacks, but
    /// resolver endpoint overrides will fail or fall through depending on
    /// <see cref="StrictMode"/>.
    /// </summary>
    public TokenCredential? Credential { get; set; }

    /// <summary>
    /// Maximum time to wait on the resolver API call. Defaults to 30 seconds when unset.
    /// Because <c>IConfigurationProvider.Load</c> runs synchronously at startup, a
    /// hung resolver should never block app start indefinitely — this cap is the
    /// safety net.
    /// </summary>
    public TimeSpan? ResolverTimeout { get; set; }

    /// <summary>
    /// When <c>true</c>, the underlying loader rethrows resolver failures, tools.json
    /// parse errors, and invalid candidate IDs instead of swallowing them as warnings.
    /// Combine with <see cref="FailOnEmpty"/> for a true fail-fast startup contract.
    /// </summary>
    public bool StrictMode { get; set; }

    /// <summary>
    /// In multi-agent mode (<see cref="AgentKey"/> set), whether to fall back to the
    /// un-suffixed environment variables when no per-agent variant is set. Off by
    /// default in multi-agent mode to prevent accidental cross-wiring. Always on in
    /// single-agent mode for back-compat (this property is ignored when
    /// <see cref="AgentKey"/> is <c>null</c>).
    /// </summary>
    public bool FallbackToUnsuffixedEnvVars { get; set; }

    /// <summary>
    /// When <c>true</c>, throws <see cref="InvalidOperationException"/> at <see cref="AgentConfigurationProvider.Load"/>
    /// time if the loader resolved no configuration from any of the four priority sources.
    /// Recommended for production hosts so a misconfigured deployment fails on app start
    /// rather than silently running with the baseline (or no) prompt.
    /// </summary>
    public bool FailOnEmpty { get; set; }
}
