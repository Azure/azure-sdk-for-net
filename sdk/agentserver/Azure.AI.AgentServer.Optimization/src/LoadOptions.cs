// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.AgentServer.Optimization;

/// <summary>
/// Options that control how <see cref="OptimizationOptionsLoader.Load(LoadOptions)"/>
/// resolves an <see cref="OptimizationOptions"/> from the environment.
/// </summary>
/// <remarks>
/// <para>
/// The loader executes a 4-priority waterfall (resolver API → inline JSON → local
/// candidate dir → local baseline dir). These options expose knobs for each priority
/// and control diagnostics (strict mode vs. log-and-continue), agent-key scoping
/// (multi-agent env-var suffixes), and timeouts.
/// </para>
/// <para>
/// Backwards compatibility: when no <see cref="AgentKey"/> is set the loader behaves
/// identically to the legacy zero-arg overloads — all four priorities are evaluated
/// against the un-suffixed environment variables.
/// </para>
/// </remarks>
public class LoadOptions
{
    /// <summary>
    /// Logical agent key used to scope environment-variable lookups for multi-agent
    /// hosts. When set, the loader prefers <c>OPTIMIZATION_&lt;VAR&gt;__&lt;CANONICAL_KEY&gt;</c>
    /// over <c>OPTIMIZATION_&lt;VAR&gt;</c>. Canonicalization rules: uppercase the key
    /// and replace <c>-</c> with <c>_</c>.
    /// </summary>
    public string AgentKey { get; set; }

    /// <summary>
    /// Credential for authenticating to the resolver API (Priority 1).
    /// When <c>null</c>, the resolver API is skipped unless both OPTIMIZATION_CANDIDATE_ID
    /// and OPTIMIZATION_RESOLVE_ENDPOINT are set with a valid credential.
    /// </summary>
    public TokenCredential Credential { get; set; }

    /// <summary>
    /// Maximum time the resolver API call is allowed to take before being cancelled.
    /// Defaults to 30 seconds when unset. Applies only to Priority 1.
    /// </summary>
    public TimeSpan? ResolverTimeout { get; set; }

    /// <summary>
    /// When <c>true</c>, propagates resolver API failures and config parse errors as
    /// exceptions instead of silently falling through to the next priority. Defaults
    /// to <c>false</c> for backwards compatibility with existing consumers that rely
    /// on graceful fallback.
    /// </summary>
    /// <remarks>
    /// Strict mode is the recommended setting for production deployments — silent
    /// fall-through can mask credential misconfiguration and produce an agent that
    /// runs with default (un-optimized) instructions.
    /// </remarks>
    public bool StrictMode { get; set; }

    /// <summary>
    /// When <c>false</c> (default in multi-agent mode), an unset suffixed env var
    /// does NOT fall back to the un-suffixed variant. This prevents accidentally
    /// cross-wiring multiple agents to the same global config. Set to <c>true</c>
    /// to enable the legacy fallback behavior in multi-agent mode.
    /// </summary>
    /// <remarks>
    /// Has no effect when <see cref="AgentKey"/> is <c>null</c> — single-agent mode
    /// always uses un-suffixed env vars by design.
    /// </remarks>
    public bool FallbackToUnsuffixedEnvVars { get; set; }
}
