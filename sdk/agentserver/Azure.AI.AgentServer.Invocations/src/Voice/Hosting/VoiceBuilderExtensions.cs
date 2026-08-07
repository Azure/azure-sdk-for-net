// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;

namespace Azure.AI.AgentServer.Invocations.Voice;

/// <summary>
/// Extension methods for <see cref="AgentHostBuilder"/> to register typed
/// Voice Live Bridge support on the Invocations WebSocket transport.
/// </summary>
public static class VoiceBuilderExtensions
{
    /// <summary>
    /// Registers the Voice Live Bridge Protocol with the specified
    /// <typeparamref name="THandler"/>. Voice runs on the existing
    /// <c>invocations_ws</c> endpoint.
    /// </summary>
    /// <typeparam name="THandler">The <see cref="VoiceHandler"/> implementation.</typeparam>
    /// <param name="builder">The agent server builder.</param>
    /// <param name="configure">Optional callback to configure <see cref="InvocationsServerOptions"/>.</param>
    /// <returns>The builder for chaining.</returns>
    public static AgentHostBuilder AddVoice<THandler>(
        this AgentHostBuilder builder,
        Action<InvocationsServerOptions>? configure = null)
        where THandler : VoiceHandler
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.AddInvocations<THandler>(configure);
        return builder;
    }
}
