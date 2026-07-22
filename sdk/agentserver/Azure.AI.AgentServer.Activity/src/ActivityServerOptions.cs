// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.Agents.Authentication;
using Microsoft.Agents.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.AI.AgentServer.Activity;

/// <summary>
/// Configuration options for the Activity protocol server. Every property is optional; leave the
/// defaults to have the host build the whole Microsoft 365 Agents SDK stack from the environment.
/// </summary>
public class ActivityServerOptions
{
    /// <summary>
    /// Selects the outbound-auth model.
    ///
    /// <list type="bullet">
    ///   <item><c>false</c> (default) — <b>Simple agent</b> model: the agent
    ///     <em>instance</em> identity mints the Bot Connector token directly via
    ///     Managed Identity (<c>FOUNDRY_AGENT_INSTANCE_CLIENT_ID</c>) scoped to
    ///     <c>https://api.botframework.com/.default</c>. This is the standard
    ///     single-tenant Teams bot pattern.</item>
    ///   <item><c>true</c> — <b>Digital worker</b> model: the <em>blueprint</em>
    ///     identity (<c>FOUNDRY_AGENT_BLUEPRINT_CLIENT_ID</c>) performs a
    ///     federated-identity (FMI) token exchange to obtain an agentic user
    ///     token.</item>
    /// </list>
    /// </summary>
    public bool DigitalWorker { get; set; } = false;

    /// <summary>
    /// Optional storage backend for the Microsoft 365 Agents SDK turn state. Leave <c>null</c> to
    /// use the built-in <c>MemoryStorage</c> (suitable for local and development use; conversation
    /// state is not durable or shared across instances).
    /// </summary>
    public IStorage? Storage { get; set; }

    /// <summary>
    /// Optional connection provider used to acquire outbound (Bot Connector) tokens. Leave
    /// <c>null</c> to use the Foundry-native provider that mints tokens from the container's
    /// managed identity. Supply your own to control outbound-auth entirely.
    /// </summary>
    public IConnections? Connections { get; set; }

    /// <summary>
    /// Optional connection configuration (the M365 <c>CONNECTIONS__*</c> mapping) for the built
    /// stack. Leave <c>null</c> to derive the settings from the Foundry-native identity (via
    /// <see cref="ActivityEnvironment.GetHostedAgentConfiguration(bool)"/>). When supplied, these
    /// settings are used as-is instead of the derived values.
    /// </summary>
    public IReadOnlyDictionary<string, string?>? ConnectionConfiguration { get; set; }

    /// <summary>
    /// Optional callback to register additional services into the host's dependency-injection
    /// container before the Microsoft 365 Agents SDK services are added. Because the SDK registers
    /// its defaults only when a service is not already present, anything registered here wins — use
    /// it to plug in a custom adapter, authorization, channel-service factory, or any other service.
    /// </summary>
    public Action<IServiceCollection>? ConfigureServices { get; set; }
}
