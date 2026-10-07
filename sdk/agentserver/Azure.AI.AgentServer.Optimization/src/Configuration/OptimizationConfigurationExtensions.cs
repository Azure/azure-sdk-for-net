// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.AgentServer.Optimization.Configuration;
using Microsoft.Extensions.Configuration;

#nullable enable

namespace Azure.AI.AgentServer.Optimization;

public static partial class AgentOptimizationClientHostExtensions
{
    private const string DefaultSection = "AgentOptimization";

    /// <summary>
    /// Gets the resolved optimization config projected into the default <c>AgentOptimization</c> section.
    /// </summary>
    /// <param name="configuration">The configuration to read from.</param>
    /// <returns>The resolved config, or <c>null</c> when none is available.</returns>
    public static CandidateDeployConfig? GetOptimizationConfig(this IConfiguration configuration)
    {
        if (configuration is null)
        {
            throw new ArgumentNullException(nameof(configuration));
        }

        return GetOptimizationConfigForSection(configuration, DefaultSection);
    }

    /// <summary>
    /// Gets the resolved optimization config projected into <paramref name="agentKey"/>.
    /// </summary>
    /// <param name="configuration">The configuration to read from.</param>
    /// <param name="agentKey">The section that contains the resolved optimization config.</param>
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

        return GetOptimizationConfigForSection(configuration, agentKey);
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
