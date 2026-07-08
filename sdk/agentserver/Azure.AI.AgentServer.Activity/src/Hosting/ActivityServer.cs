// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Activity.Internal;
using Microsoft.Agents.Builder.App;
using Microsoft.AspNetCore.Http;

namespace Azure.AI.AgentServer.Activity;

/// <summary>
/// Entry point for creating an Activity protocol host.
/// </summary>
/// <remarks>
/// <para>A single factory selects one of three mutually-exclusive construction modes:</para>
/// <list type="number">
///   <item>
///     <b>Build the M365 stack (default).</b> <see cref="Create()"/> initializes the Microsoft 365
///     Agents SDK from the environment and exposes the built <see cref="AgentApplication"/> as
///     <see cref="ActivityServerHost.AgentApp"/>. Register handlers on it with
///     <c>app.OnActivity(...)</c> / <c>app.OnConversationUpdate(...)</c>.
///   </item>
///   <item>
///     <b>Inject a pre-built <see cref="AgentApplication"/>.</b> <see cref="Create(AgentApplication)"/>
///     hosts an application you built yourself, as-is.
///   </item>
///   <item>
///     <b>Custom request handler.</b> <see cref="Create(RequestDelegate)"/> lets you own the request
///     pipeline entirely; the M365 SDK is not initialized and
///     <see cref="ActivityServerHost.AgentApp"/> is unavailable.
///   </item>
/// </list>
/// </remarks>
public static class ActivityServer
{
    /// <summary>
    /// Creates a host that builds the Microsoft 365 Agents SDK stack from the environment and
    /// exposes the built <see cref="AgentApplication"/> as <see cref="ActivityServerHost.AgentApp"/>.
    /// </summary>
    /// <returns>A configured <see cref="ActivityServerHost"/>.</returns>
    public static ActivityServerHost Create() => Create(configureOptions: null);

    /// <summary>
    /// Creates a host that builds the M365 stack, applying <paramref name="configureOptions"/>
    /// (for example to select the digital-worker outbound-auth model).
    /// </summary>
    /// <param name="configureOptions">Optional callback to configure <see cref="ActivityServerOptions"/>.</param>
    /// <returns>A configured <see cref="ActivityServerHost"/>.</returns>
    public static ActivityServerHost Create(Action<ActivityServerOptions>? configureOptions)
    {
        var options = new ActivityServerOptions();
        configureOptions?.Invoke(options);
        var agentApp = ActivityStack.CreateAgentApplication(options);
        return new ActivityServerHost(agentApp, options);
    }

    /// <summary>
    /// Creates a host that hosts a pre-built Microsoft 365 Agents SDK
    /// <see cref="AgentApplication"/> as-is.
    /// </summary>
    /// <param name="agentApp">The application to host.</param>
    /// <returns>A configured <see cref="ActivityServerHost"/>.</returns>
    public static ActivityServerHost Create(AgentApplication agentApp)
    {
        ArgumentNullException.ThrowIfNull(agentApp);
        return new ActivityServerHost(agentApp, new ActivityServerOptions());
    }

    /// <summary>
    /// Creates a host that owns the request pipeline entirely. The M365 SDK is not initialized;
    /// the supplied delegate receives each inbound <c>POST /activity/messages</c> request.
    /// </summary>
    /// <param name="requestHandler">The request handler that processes inbound activities.</param>
    /// <returns>A configured <see cref="ActivityServerHost"/>.</returns>
    public static ActivityServerHost Create(RequestDelegate requestHandler)
    {
        ArgumentNullException.ThrowIfNull(requestHandler);
        return new ActivityServerHost(requestHandler);
    }
}
