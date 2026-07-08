// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Security.Claims;
using Azure.AI.AgentServer.Activity.Internal;
using Azure.AI.AgentServer.Core;
using Microsoft.Agents.Builder;
using Microsoft.Agents.Builder.App;
using Microsoft.Agents.Core.Models;
using Microsoft.Agents.Hosting.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.AI.AgentServer.Activity;

/// <summary>
/// Activity protocol host for Azure AI Hosted Agents — the .NET counterpart of the
/// Python package's <c>ActivityAgentServerHost</c>.
/// </summary>
/// <remarks>
/// <para>
/// Create a host with <see cref="ActivityServer.Create()"/> and register handlers on the
/// exposed Microsoft 365 Agents SDK <see cref="AgentApp"/>:
/// </para>
/// <code language="csharp">
/// var host = ActivityServer.Create();
/// var app = host.AgentApp;
/// app.OnActivity(ActivityTypes.Message, async (turn, state, ct) =>
///     await turn.SendActivityAsync($"Echo: {turn.Activity.Text}", ct));
/// host.Run();
/// </code>
/// <para>The host adds the Foundry platform contract (port binding, <c>/readiness</c>,
/// OpenTelemetry, and the <c>POST /activity/messages</c> and <c>POST /api/messages</c>
/// endpoints) around the M365 turn pipeline.</para>
/// </remarks>
public sealed class ActivityServerHost
{
    private readonly AgentApplication? _agentApp;
    private readonly IAgentHttpAdapter? _adapter;
    private readonly RequestDelegate? _requestHandler;
    private readonly bool _digitalWorker;
    private Action<AgentHostBuilder>? _configure;

    /// <summary>Route paths the host exposes for inbound activities.</summary>
    private static readonly string[] s_activityPaths = { "/activity/messages", "/api/messages" };

    /// <summary>Initializes a host that builds or hosts an M365 <see cref="AgentApplication"/>.</summary>
    internal ActivityServerHost(AgentApplication agentApp, IAgentHttpAdapter adapter, bool digitalWorker = false)
    {
        _agentApp = agentApp ?? throw new ArgumentNullException(nameof(agentApp));
        _adapter = adapter ?? throw new ArgumentNullException(nameof(adapter));
        _digitalWorker = digitalWorker;
    }

    /// <summary>Initializes a host that owns the request pipeline (no M365 stack).</summary>
    internal ActivityServerHost(RequestDelegate requestHandler)
    {
        _requestHandler = requestHandler ?? throw new ArgumentNullException(nameof(requestHandler));
    }

    /// <summary>
    /// The Microsoft 365 Agents SDK <see cref="AgentApplication"/> for handler registration.
    /// Register handlers on it, for example
    /// <c>app.OnActivity(ActivityTypes.Message, handler)</c> / <c>app.OnConversationUpdate(...)</c>.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the host was created with a custom request handler
    /// (<see cref="ActivityServer.Create(RequestDelegate)"/>), where no
    /// <see cref="AgentApplication"/> is initialized.
    /// </exception>
    public AgentApplication AgentApp =>
        _agentApp ?? throw new InvalidOperationException(
            "The M365 AgentApplication is not available because the host was created with a " +
            "custom request handler. Use ActivityServer.Create() (optionally with a pre-built " +
            "AgentApplication) to access AgentApp.");

    /// <summary>
    /// Further configure the underlying <see cref="AgentHostBuilder"/> before the server runs
    /// (for example to register services, add middleware, or compose additional protocols).
    /// </summary>
    /// <param name="configure">The configuration callback.</param>
    /// <returns>This host for chaining.</returns>
    public ActivityServerHost Configure(Action<AgentHostBuilder> configure)
    {
        _configure = configure ?? throw new ArgumentNullException(nameof(configure));
        return this;
    }

    /// <summary>Builds and runs the server synchronously (blocks until shutdown).</summary>
    /// <param name="args">Optional command-line arguments.</param>
    public void Run(string[]? args = null)
    {
        var builder = AgentHost.CreateBuilder(args);
        builder.Services.AddActivityServer();

        if (_agentApp is not null && _adapter is not null)
        {
            builder.Services.AddSingleton(_agentApp);
            builder.Services.AddSingleton<IAgent>(_agentApp);
            builder.Services.AddSingleton(_adapter);
        }

        builder.RegisterProtocol("Activity", MapActivityEndpoints);

        _configure?.Invoke(builder);
        builder.Build().Run();
    }

    private void MapActivityEndpoints(IEndpointRouteBuilder endpoints)
    {
        foreach (var path in s_activityPaths)
        {
            endpoints.MapPost(path, HandleActivityAsync);
        }
    }

    private async Task HandleActivityAsync(HttpContext context)
    {
        var cancellationToken = context.RequestAborted;

        // Resolve the session id and stamp the required response header before the
        // adapter (or custom handler) starts writing the response.
        var sessionId = ActivitySessionIdResolver.Resolve(context.Request);
        context.Response.Headers[PlatformHeaders.SessionId] = sessionId;

        // Promote correlation baggage onto the current request span for downstream spans/logs.
        var tracing = context.RequestServices.GetService<ActivityProtocolActivitySource>();
        tracing?.PropagateActivityBaggage(sessionId, sessionId, null, context.Request.Headers);

        if (_requestHandler is not null)
        {
            await _requestHandler(context).ConfigureAwait(false);
            return;
        }

        // Parse the inbound activity from the request body.
        var activity = await HttpHelper.ReadRequestAsync<Microsoft.Agents.Core.Models.Activity>(context.Request).ConfigureAwait(false);
        if (activity is null)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            return;
        }

        // Synthesize the outbound claims for this turn. The Foundry gateway is a trusted,
        // network-isolated proxy — inbound requests are NOT Bot Framework channel JWTs — so we
        // do not rely on inbound authentication. This mirrors the Python bridge's
        // _build_outbound_claims and lets the connector mint the outbound reply token.
        var claims = BuildOutboundClaims();

        // Run the turn synchronously in-request via ProcessActivityAsync. This intentionally
        // bypasses CloudAdapter.ProcessAsync, which (for normal-delivery messages) queues the
        // activity to a background HostedActivityService that is not running in this host —
        // the turn would never execute. Replies are delivered to the channel by the connector
        // during the turn; an InvokeResponse (invoke / expectReplies) is written to the response.
        var invokeResponse = await ((IChannelAdapter)_adapter!)
            .ProcessActivityAsync(claims, activity, _agentApp!.OnTurnAsync, cancellationToken)
            .ConfigureAwait(false);

        if (invokeResponse is not null)
        {
            context.Response.StatusCode = invokeResponse.Status ?? StatusCodes.Status200OK;
            if (invokeResponse.Body is not null)
            {
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(invokeResponse.Body, cancellationToken).ConfigureAwait(false);
            }
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status202Accepted;
        }
    }

    /// <summary>
    /// Builds the outbound <see cref="ClaimsIdentity"/> for a turn. Mirrors the Python bridge's
    /// <c>_build_outbound_claims</c>: the digital-worker model uses anonymous claims (the FMI
    /// patch supplies the token); the simple model presents authenticated claims whose
    /// <c>appid</c>/<c>aud</c> match the agent-instance client id so the connector uses the
    /// managed-identity connection for the outbound reply.
    /// </summary>
    private ClaimsIdentity BuildOutboundClaims()
    {
        if (_digitalWorker)
        {
            return new ClaimsIdentity();
        }

        var botAppId = Environment
            .GetEnvironmentVariable("CONNECTIONS__SERVICE_CONNECTION__SETTINGS__CLIENTID")?
            .Trim();

        if (string.IsNullOrEmpty(botAppId))
        {
            // Local development with no Bot Connector credential: anonymous outbound auth.
            return new ClaimsIdentity();
        }

        return new ClaimsIdentity(
            new[]
            {
                new Claim("appid", botAppId),
                new Claim("aud", botAppId),
            },
            "Bearer");
    }
}
