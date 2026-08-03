// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;

namespace Azure.AI.AgentServer.Invocations.Voice;

/// <summary>
/// One-line entry point for running Voice Live Bridge Protocol 1.0 on the
/// Invocations WebSocket transport.
/// </summary>
public static class VoiceServer
{
    /// <summary>
    /// Builds and runs an Invocations server using the specified voice handler type.
    /// </summary>
    /// <typeparam name="THandler">The <see cref="VoiceHandler"/> implementation.</typeparam>
    /// <param name="args">Optional command-line arguments.</param>
    /// <param name="configure">Optional callback to further configure the builder before running.</param>
    public static void Run<THandler>(
        string[]? args = null,
        Action<AgentHostBuilder>? configure = null)
        where THandler : VoiceHandler
    {
        var builder = AgentHost.CreateBuilder(args);
        builder.AddVoice<THandler>();
        configure?.Invoke(builder);
        builder.Build().Run();
    }
}
