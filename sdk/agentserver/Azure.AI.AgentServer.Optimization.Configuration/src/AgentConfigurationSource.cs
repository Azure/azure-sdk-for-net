// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Extensions.Configuration;

namespace Azure.AI.AgentServer.Optimization.Configuration;

/// <summary>
/// <see cref="IConfigurationSource"/> that projects optimization configuration
/// into the <see cref="IConfiguration"/> tree.
/// </summary>
public class AgentConfigurationSource : IConfigurationSource
{
    /// <summary>
    /// The options used to build the provider. Exposed for inspection by tests
    /// and diagnostic helpers; treat as read-only after the source is added to
    /// the configuration builder.
    /// </summary>
    public AgentConfigurationOptions Options { get; }

    /// <summary>
    /// Creates a new <see cref="AgentConfigurationSource"/>.
    /// </summary>
    /// <param name="options">Options controlling resolution and projection. Required.</param>
    public AgentConfigurationSource(AgentConfigurationOptions options)
    {
        Options = options ?? throw new ArgumentNullException(nameof(options));
    }

    /// <inheritdoc />
    public IConfigurationProvider Build(IConfigurationBuilder builder)
    {
        return new AgentConfigurationProvider(Options);
    }
}
