// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.AgentServer.Optimization.Configuration;
using Microsoft.Extensions.Configuration;

#nullable enable

namespace Azure.AI.AgentServer.Optimization;

/// <summary>
/// Extension methods on <see cref="IConfiguration"/> for retrieving resolved
/// <see cref="CandidateDeployConfig"/> instances from <see cref="AgentConfigurationProvider"/>.
/// </summary>
public static partial class AgentOptimizationClientHostExtensions
{
    private const string SingleAgentSection = "Agent";
    private const string MultiAgentSectionPrefix = "Agents";

    /// <summary>
    /// Gets the single-agent <see cref="CandidateDeployConfig"/> resolved for the
    /// <c>Agent</c> section, if present.
    /// </summary>
    /// <param name="configuration">The configuration to read from. Required.</param>
    /// <returns>The resolved config, or <c>null</c> when none is available.</returns>
    public static CandidateDeployConfig? GetOptimizationConfig(this IConfiguration configuration)
    {
        if (configuration is null)
        {
            throw new ArgumentNullException(nameof(configuration));
        }

        return GetOptimizationConfigForSection(configuration, SingleAgentSection);
    }

    /// <summary>
    /// Gets the multi-agent <see cref="CandidateDeployConfig"/> resolved for the
    /// <c>Agents:&lt;agentKey&gt;</c> section, if present.
    /// </summary>
    /// <param name="configuration">The configuration to read from. Required.</param>
    /// <param name="agentKey">The agent key. Required, non-empty.</param>
    /// <returns>The resolved config, or <c>null</c> when none is available.</returns>
    public static CandidateDeployConfig? GetOptimizationConfig(this IConfiguration configuration, string agentKey)
    {
        if (configuration is null)
        {
            throw new ArgumentNullException(nameof(configuration));
        }
        if (string.IsNullOrEmpty(agentKey))
        {
            throw new ArgumentException("Agent key must not be null or empty.", nameof(agentKey));
        }

        string section = ConfigurationPath.Combine(MultiAgentSectionPrefix, agentKey);
        return GetOptimizationConfigForSection(configuration, section);
    }

    private static CandidateDeployConfig? GetOptimizationConfigForSection(IConfiguration configuration, string section)
    {
        if (configuration is IConfigurationRoot root)
        {
            foreach (var provider in root.Providers)
            {
                if (provider is AgentConfigurationProvider p &&
                    p.ResolvedConfig != null &&
                    string.Equals(p.SectionName, section, StringComparison.OrdinalIgnoreCase))
                {
                    return p.ResolvedConfig;
                }
            }
        }

        return null;
    }
}
