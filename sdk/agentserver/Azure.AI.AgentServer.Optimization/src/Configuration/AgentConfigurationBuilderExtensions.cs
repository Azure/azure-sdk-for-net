// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.AgentServer.Optimization.Configuration;

#nullable enable

namespace Microsoft.Extensions.Configuration;

/// <summary>
/// Extension methods on <see cref="IConfigurationBuilder"/> for adding an
/// <see cref="AgentConfigurationSource"/>.
/// </summary>
public static class AgentConfigurationBuilderExtensions
{
    /// <summary>
    /// Adds an optimization configuration source using all default options.
    /// Resolves a single-agent config into the <c>Agent</c> section.
    /// </summary>
    /// <param name="builder">The configuration builder to add to. Required.</param>
    /// <returns>The same <paramref name="builder"/> for chaining.</returns>
    public static IConfigurationBuilder AddOptimizationConfigSource(this IConfigurationBuilder builder)
    {
        return AddOptimizationConfigSourceCore(builder, agentKey: null, configure: null);
    }

    /// <summary>
    /// Adds an optimization configuration source for the given agent key.
    /// Projects the resolved config into the <c>Agents:&lt;agentKey&gt;</c> section.
    /// </summary>
    /// <param name="builder">The configuration builder to add to. Required.</param>
    /// <param name="agentKey">The logical agent key. Must be ASCII letters / digits / hyphen / underscore.</param>
    /// <returns>The same <paramref name="builder"/> for chaining.</returns>
    public static IConfigurationBuilder AddOptimizationConfigSource(
        this IConfigurationBuilder builder,
        string agentKey)
    {
        if (string.IsNullOrEmpty(agentKey))
        {
            throw new ArgumentException("Agent key must not be null or empty.", nameof(agentKey));
        }

        return AddOptimizationConfigSourceCore(builder, agentKey, configure: null);
    }

    /// <summary>
    /// Adds an optimization configuration source with a configuration callback.
    /// </summary>
    /// <param name="builder">The configuration builder to add to. Required.</param>
    /// <param name="configure">Callback to populate the <see cref="AgentConfigurationOptions"/>. Required.</param>
    /// <returns>The same <paramref name="builder"/> for chaining.</returns>
    public static IConfigurationBuilder AddOptimizationConfigSource(
        this IConfigurationBuilder builder,
        Action<AgentConfigurationOptions> configure)
    {
        if (configure is null)
        {
            throw new ArgumentNullException(nameof(configure));
        }

        return AddOptimizationConfigSourceCore(builder, agentKey: null, configure: configure);
    }

    /// <summary>
    /// Adds an optimization configuration source for the given agent key with a configuration callback.
    /// </summary>
    /// <param name="builder">The configuration builder to add to. Required.</param>
    /// <param name="agentKey">The logical agent key. Must be ASCII letters / digits / hyphen / underscore.</param>
    /// <param name="configure">Callback to populate the <see cref="AgentConfigurationOptions"/>. Required.</param>
    /// <returns>The same <paramref name="builder"/> for chaining.</returns>
    public static IConfigurationBuilder AddOptimizationConfigSource(
        this IConfigurationBuilder builder,
        string agentKey,
        Action<AgentConfigurationOptions> configure)
    {
        if (configure is null)
        {
            throw new ArgumentNullException(nameof(configure));
        }

        if (string.IsNullOrEmpty(agentKey))
        {
            throw new ArgumentException("Agent key must not be null or empty.", nameof(agentKey));
        }

        return AddOptimizationConfigSourceCore(builder, (string?)agentKey, configure);
    }

    private static IConfigurationBuilder AddOptimizationConfigSourceCore(
        IConfigurationBuilder builder,
        string? agentKey,
        Action<AgentConfigurationOptions>? configure)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        var options = new AgentConfigurationOptions { AgentKey = agentKey };
        configure?.Invoke(options);

        // Caller may have overwritten AgentKey via the configure callback; preserve
        // the explicit positional argument (if provided) but only when the callback
        // did not assign a non-null value of its own.
        if (agentKey is not null && options.AgentKey is null)
        {
            options.AgentKey = agentKey;
        }

        builder.Add(new AgentConfigurationSource(options));
        return builder;
    }
}
