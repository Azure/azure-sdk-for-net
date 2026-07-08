// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Activity.Internal;
using Azure.AI.AgentServer.Core;
using Microsoft.Agents.Builder;
using Microsoft.Agents.Builder.App;
using Microsoft.Agents.Hosting.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Azure.AI.AgentServer.Activity;

/// <summary>
/// Hosts an Activity Protocol agent on the Foundry agent server. The activity endpoint delegates to
/// the native Microsoft 365 Agents SDK <see cref="IAgentHttpAdapter.ProcessAsync"/> exactly as a
/// native SDK application would; the Foundry-specific behavior is limited to the platform response
/// contract (session-id header, tracing baggage), outbound-auth claims synthesis, and the
/// <see cref="Internal.FoundryConnections"/> token provider.
/// </summary>
public sealed class ActivityServerHost
{
    private static readonly string[] s_activityPaths = { "/activity/messages", "/api/messages" };

    private readonly AgentApplication? _agentApp;
    private readonly ActivityServerOptions? _options;
    private readonly RequestDelegate? _requestHandler;
    private readonly bool _digitalWorker;
    private readonly string? _botAppId;

    private Action<AgentHostBuilder>? _configure;

    /// <summary>
    /// Initializes a new instance that hosts a Microsoft 365 Agents SDK <see cref="AgentApplication"/>.
    /// </summary>
    /// <param name="agentApp">The agent application to host.</param>
    /// <param name="options">The activity server options (selects the outbound-auth model).</param>
    internal ActivityServerHost(AgentApplication agentApp, ActivityServerOptions options)
    {
        _agentApp = agentApp ?? throw new ArgumentNullException(nameof(agentApp));
        _options = options ?? throw new ArgumentNullException(nameof(options));
        _digitalWorker = options.DigitalWorker;

        // Resolve the agent-instance client id once so the outbound reply presents claims whose
        // appid/aud match the managed-identity connection. Digital-worker turns are anonymous
        // (the FMI token exchange supplies the reply token).
        if (!_digitalWorker &&
            ActivityStack.GetConnectionConfiguration(options).TryGetValue(ConnectionEnvironment.ClientId, out var clientId))
        {
            _botAppId = clientId;
        }
    }

    /// <summary>
    /// Initializes a new instance that hosts a custom request handler for the activity endpoint.
    /// </summary>
    /// <param name="requestHandler">The request handler invoked for each activity request.</param>
    internal ActivityServerHost(RequestDelegate requestHandler)
    {
        _requestHandler = requestHandler ?? throw new ArgumentNullException(nameof(requestHandler));
    }

    /// <summary>
    /// Gets the hosted <see cref="AgentApplication"/> so handlers can be registered before running.
    /// </summary>
    public AgentApplication AgentApp =>
        _agentApp ?? throw new InvalidOperationException("This host was not created with an AgentApplication.");

    /// <summary>
    /// Configures the underlying agent host builder before the server runs.
    /// </summary>
    /// <param name="configure">A callback that customizes the <see cref="AgentHostBuilder"/>.</param>
    /// <returns>This host, for chaining.</returns>
    public ActivityServerHost Configure(Action<AgentHostBuilder> configure)
    {
        _configure = configure ?? throw new ArgumentNullException(nameof(configure));
        return this;
    }

    /// <summary>
    /// Runs the activity server, blocking until the host shuts down.
    /// </summary>
    /// <param name="args">Optional command-line arguments forwarded to the host builder.</param>
    public void Run(string[]? args = null)
    {
        var builder = AgentHost.CreateBuilder(args);
        builder.Services.AddActivityServer();

        if (_agentApp is not null && _options is not null)
        {
            // Overlay the derived M365 connection settings onto the host configuration so the SDK
            // adapter and FoundryConnections read them (never mutating the process environment).
            builder.WebApplicationBuilder.Configuration.AddInMemoryCollection(
                ActivityStack.GetConnectionConfiguration(_options));

            // Register the native Microsoft 365 Agents SDK stack into the real application host so
            // the SDK's CloudAdapter and its background HostedActivityService run for the host's
            // lifetime — this is what lets the endpoint use the SDK's ProcessAsync as-is.
            ActivityStack.RegisterM365Services(builder.Services, _options);

            // Host the pre-built application instance (with its registered handlers) as the agent
            // resolved by both the endpoint and the background activity service.
            builder.Services.AddSingleton(_agentApp);
            builder.Services.AddSingleton<IAgent>(_agentApp);
        }

        builder.RegisterProtocol("Activity", MapActivityEndpoints);
        _configure?.Invoke(builder);
        builder.Build().Run();
    }

    private void MapActivityEndpoints(IEndpointRouteBuilder endpoints)
    {
        foreach (var path in s_activityPaths)
        {
            if (_requestHandler is not null)
            {
                Func<HttpContext, Task> handler = HandleCustomRequestAsync;
                endpoints.MapPost(path, handler).AddEndpointFilter<ActivityErrorSourceFilter>();
            }
            else
            {
                endpoints.MapPost(path, HandleActivityAsync).AddEndpointFilter<ActivityErrorSourceFilter>();
            }
        }
    }

    private async Task HandleCustomRequestAsync(HttpContext context)
    {
        StampSessionAndBaggage(context);
        await _requestHandler!(context).ConfigureAwait(false);
    }

    private async Task HandleActivityAsync(
        HttpContext context,
        IAgentHttpAdapter adapter,
        IAgent agent,
        CancellationToken cancellationToken)
    {
        StampSessionAndBaggage(context);

        // The Foundry gateway is a trusted, network-isolated proxy; inbound requests are not Bot
        // Framework channel JWTs. Set the synthesized outbound claims on the request principal so
        // the SDK's ProcessAsync (via HttpHelper.GetClaimsIdentity) uses them to mint the outbound
        // reply token — replacing inbound channel auth with the Foundry trust model.
        context.User = new ClaimsPrincipal(BuildOutboundClaims());

        // Native Microsoft 365 Agents SDK entry point: reads the activity, runs (or queues) the
        // turn, delivers replies via the connector, and writes the status code / response body.
        await adapter.ProcessAsync(context.Request, context.Response, agent, cancellationToken).ConfigureAwait(false);
    }

    private static void StampSessionAndBaggage(HttpContext context)
    {
        // Resolve the session id and stamp the required response header before the adapter (or
        // custom handler) starts writing the response. Sanitize it first so a malicious or
        // malformed value cannot be reflected into the response header (header-injection defense).
        var sessionId = ActivityIdSanitizer.Sanitize(ActivitySessionIdResolver.Resolve(context.Request));
        context.Response.Headers[PlatformHeaders.SessionId] = sessionId;

        // Promote correlation baggage onto the current request span so the core enrichment
        // processor stamps the session id onto every span (and the core log enrichment onto logs).
        var tracing = context.RequestServices.GetService<ActivityProtocolActivitySource>();
        tracing?.PropagateActivityBaggage(sessionId);
    }

    /// <summary>
    /// Builds the outbound <see cref="ClaimsIdentity"/> for a turn. The digital-worker model uses
    /// anonymous claims (the FMI token exchange supplies the token); the simple model presents
    /// authenticated claims whose <c>appid</c>/<c>aud</c> match the agent-instance client id so the
    /// connector uses the managed-identity connection for the outbound reply.
    /// </summary>
    private ClaimsIdentity BuildOutboundClaims()
    {
        if (_digitalWorker)
        {
            return new ClaimsIdentity();
        }

        var botAppId = _botAppId?.Trim();

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
