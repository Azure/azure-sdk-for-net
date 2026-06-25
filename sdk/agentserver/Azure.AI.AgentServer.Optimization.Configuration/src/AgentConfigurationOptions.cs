// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
namespace Azure.AI.AgentServer.Optimization.Configuration;

/// <summary>
/// Options controlling how an <see cref="AgentConfigurationSource"/> resolves and
/// projects an optimization configuration into the <see cref="Microsoft.Extensions.Configuration.IConfiguration"/> tree.
/// </summary>
/// <remarks>
/// <para>
/// The single-agent default places keys under the <c>Agent:*</c> section.
/// The multi-agent overload (when <see cref="AgentKey"/> is set) places keys under
/// <c>Agents:&lt;AgentKey&gt;:*</c>.
/// </para>
/// </remarks>
public class AgentConfigurationOptions
{
    /// <summary>
    /// The logical key for this agent in a multi-agent host. When set, the resolved
    /// configuration values are projected under <c>Agents:&lt;AgentKey&gt;:*</c>.
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
    /// When <c>true</c>, throws <see cref="InvalidOperationException"/> at
    /// <see cref="AgentConfigurationProvider.Load"/> time if no configuration was
    /// resolved from the API or <c>OPTIMIZATION_CONFIG</c>.
    /// </summary>
    public bool FailOnEmpty { get; set; }
}
