// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.AgentServer.Optimization;
using Azure.AI.AgentServer.Optimization.Configuration;

namespace Microsoft.Extensions.Configuration;

/// <summary>
/// Extension methods on <see cref="IConfiguration"/> for reading bound
/// <see cref="OptimizationOptions"/> back out of the configuration tree.
/// </summary>
/// <remarks>
/// These are convenience methods over <see cref="ConfigurationBinder"/>: each call
/// resolves the section that <see cref="AgentConfigurationProvider"/> writes into
/// (<c>Agent</c> for single-agent or <c>Agents:&lt;key&gt;</c> for multi-agent) and
/// returns a freshly bound POCO. Use the standard
/// <c>builder.Services.Configure&lt;OptimizationOptions&gt;(config.GetSection("Agent"))</c>
/// pattern if you need <see cref="Microsoft.Extensions.Options.IOptions{TOptions}"/>
/// integration with reload notifications.
/// </remarks>
public static class OptimizationConfigurationExtensions
{
    private const string SingleAgentSection = "Agent";
    private const string MultiAgentSectionPrefix = "Agents";

    /// <summary>
    /// Reads the single-agent <c>Agent</c> section as an <see cref="OptimizationOptions"/>.
    /// Returns a fresh, empty <see cref="OptimizationOptions"/> if no values are bound.
    /// </summary>
    /// <param name="configuration">The configuration to read from. Required.</param>
    /// <returns>A bound <see cref="OptimizationOptions"/> (never <c>null</c>).</returns>
    public static OptimizationOptions GetOptimizationOptions(this IConfiguration configuration)
    {
        if (configuration is null)
        {
            throw new ArgumentNullException(nameof(configuration));
        }

        return GetOptimizationOptionsForSection(configuration, SingleAgentSection);
    }

    /// <summary>
    /// Reads the multi-agent <c>Agents:&lt;agentKey&gt;</c> section as an <see cref="OptimizationOptions"/>.
    /// Returns a fresh, empty <see cref="OptimizationOptions"/> if no values are bound.
    /// </summary>
    /// <param name="configuration">The configuration to read from. Required.</param>
    /// <param name="agentKey">The agent key. Required, non-empty.</param>
    /// <returns>A bound <see cref="OptimizationOptions"/> (never <c>null</c>).</returns>
    public static OptimizationOptions GetOptimizationOptions(this IConfiguration configuration, string agentKey)
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
        return GetOptimizationOptionsForSection(configuration, section);
    }

    private static OptimizationOptions GetOptimizationOptionsForSection(IConfiguration configuration, string section)
    {
        var opts = new OptimizationOptions();
        configuration.GetSection(section).Bind(opts);
        return opts;
    }
}
