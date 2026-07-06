// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using Azure.AI.AgentServer.Optimization.Configuration;
using Microsoft.Extensions.Configuration;

#nullable enable

namespace Azure.AI.AgentServer.Optimization;

public static partial class AgentOptimizationClientHostExtensions
{
    private const string DefaultAgentKey = "AgentOptimization";

    /// <summary>
    /// Adds an optimization configuration source that binds <see cref="AgentOptimizationClientSettings"/>
    /// from <paramref name="sectionName"/> and projects the resolved config into the default
    /// <c>AgentOptimization</c> section.
    /// </summary>
    /// <param name="builder">The configuration builder to add to.</param>
    /// <param name="sectionName">The configuration section used to bind client settings.</param>
    /// <returns>The same <paramref name="builder"/> for chaining.</returns>
    public static IConfigurationBuilder AddOptimizationConfigSource(this IConfigurationBuilder builder, string sectionName)
    {
        return AddOptimizationConfigSourceCore(builder, DefaultAgentKey, sectionName, configureSettings: null);
    }

    /// <summary>
    /// Adds an optimization configuration source that binds <see cref="AgentOptimizationClientSettings"/>
    /// from <paramref name="sectionName"/> and projects the resolved config into <paramref name="agentKey"/>.
    /// </summary>
    /// <param name="builder">The configuration builder to add to.</param>
    /// <param name="agentKey">The section that receives the resolved optimization config.</param>
    /// <param name="sectionName">The configuration section used to bind client settings.</param>
    /// <returns>The same <paramref name="builder"/> for chaining.</returns>
    public static IConfigurationBuilder AddOptimizationConfigSource(this IConfigurationBuilder builder, string agentKey, string sectionName)
    {
        return AddOptimizationConfigSourceCore(builder, agentKey, sectionName, configureSettings: null);
    }

    /// <summary>
    /// Adds an optimization configuration source that binds <see cref="AgentOptimizationClientSettings"/>
    /// from <paramref name="sectionName"/>, applies <paramref name="configureSettings"/>, and projects
    /// the resolved config into the default <c>AgentOptimization</c> section.
    /// </summary>
    /// <param name="builder">The configuration builder to add to.</param>
    /// <param name="sectionName">The configuration section used to bind client settings.</param>
    /// <param name="configureSettings">A callback that can mutate the bound client settings.</param>
    /// <returns>The same <paramref name="builder"/> for chaining.</returns>
    [Experimental("SCME0002")]
    public static IConfigurationBuilder AddOptimizationConfigSource(
        this IConfigurationBuilder builder,
        string sectionName,
        Action<AgentOptimizationClientSettings> configureSettings)
    {
        if (configureSettings is null)
        {
            throw new ArgumentNullException(nameof(configureSettings));
        }

        return AddOptimizationConfigSourceCore(builder, DefaultAgentKey, sectionName, configureSettings);
    }

    /// <summary>
    /// Adds an optimization configuration source that binds <see cref="AgentOptimizationClientSettings"/>
    /// from <paramref name="sectionName"/>, applies <paramref name="configureSettings"/>, and projects
    /// the resolved config into <paramref name="agentKey"/>.
    /// </summary>
    /// <param name="builder">The configuration builder to add to.</param>
    /// <param name="agentKey">The section that receives the resolved optimization config.</param>
    /// <param name="sectionName">The configuration section used to bind client settings.</param>
    /// <param name="configureSettings">A callback that can mutate the bound client settings.</param>
    /// <returns>The same <paramref name="builder"/> for chaining.</returns>
    [Experimental("SCME0002")]
    public static IConfigurationBuilder AddOptimizationConfigSource(
        this IConfigurationBuilder builder,
        string agentKey,
        string sectionName,
        Action<AgentOptimizationClientSettings> configureSettings)
    {
        if (configureSettings is null)
        {
            throw new ArgumentNullException(nameof(configureSettings));
        }

        return AddOptimizationConfigSourceCore(builder, agentKey, sectionName, configureSettings);
    }

#pragma warning disable SCME0002 // Type is for evaluation purposes only
    private static IConfigurationBuilder AddOptimizationConfigSourceCore(
        IConfigurationBuilder builder,
        string? agentKey,
        string? sectionName,
        Action<AgentOptimizationClientSettings>? configureSettings)
#pragma warning restore SCME0002
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        agentKey ??= DefaultAgentKey;
        if (string.IsNullOrEmpty(agentKey))
        {
            throw new ArgumentException("Agent key must not be null or empty.", nameof(agentKey));
        }

        if (string.IsNullOrEmpty(sectionName))
        {
            throw new ArgumentException("Section name must not be null or empty.", nameof(sectionName));
        }

        _ = AgentKeyCanonicalizer.Canonicalize(agentKey, nameof(agentKey));

        builder.Add(new AgentConfigurationSource(agentKey, sectionName!, configureSettings));
        return builder;
    }
}
