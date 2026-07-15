// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core;
using Microsoft.Agents.Builder;
using Microsoft.Agents.Hosting.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Azure.AI.AgentServer.Activity.Internal;

/// <summary>
/// Request-time glue between the Foundry Activity endpoint and the native Microsoft 365 Agents SDK
/// adapter. Registered as a dependency-injection singleton and shared by every hosting entry point
/// (the <c>MapFoundryActivity</c> endpoint extension and the <see cref="ActivityServer"/>
/// factory) so the per-turn behavior lives in exactly one place.
/// </summary>
/// <remarks>
/// For each activity it: (1) stamps the required session-id response header and correlation
/// baggage, (2) synthesizes the outbound-auth claims for the Foundry trust model onto
/// <see cref="HttpContext.User"/>, and (3) delegates to the SDK's native
/// <see cref="IAgentHttpAdapter.ProcessAsync"/> exactly as a native Microsoft 365 Agents SDK
/// application would.
/// </remarks>
internal sealed class ActivityEndpointHandler
{
    private readonly bool _digitalWorker;
    private readonly string? _botAppId;
    private readonly ActivityProtocolActivitySource _tracing;

    public ActivityEndpointHandler(IOptions<ActivityServerOptions> options, ActivityProtocolActivitySource tracing)
    {
        ArgumentNullException.ThrowIfNull(options);

        var value = options.Value;
        _digitalWorker = value.DigitalWorker;

        // Resolve the agent-instance client id once so the outbound reply presents claims whose
        // appid/aud match the managed-identity connection. Digital-worker turns are anonymous
        // (the FMI token exchange supplies the reply token).
        if (!_digitalWorker &&
            ActivityStack.GetConnectionConfiguration(value).TryGetValue(ConnectionEnvironment.ClientId, out var clientId))
        {
            _botAppId = clientId;
        }

        _tracing = tracing ?? throw new ArgumentNullException(nameof(tracing));
    }

    /// <summary>
    /// Handles an inbound activity by driving the native SDK adapter, after applying the Foundry
    /// platform response contract and outbound-auth claims.
    /// </summary>
    /// <param name="context">The current request context.</param>
    /// <param name="adapter">The Microsoft 365 Agents SDK HTTP adapter (resolved from DI).</param>
    /// <param name="agent">The agent to run (resolved from DI).</param>
    /// <param name="cancellationToken">The request cancellation token.</param>
    public async Task HandleAsync(
        HttpContext context,
        IAgentHttpAdapter adapter,
        IAgent agent,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(adapter);
        ArgumentNullException.ThrowIfNull(agent);

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

    /// <summary>
    /// Stamps the required session-id response header and promotes the correlation baggage onto the
    /// current request span. Safe to call for custom request handlers that bypass the SDK adapter.
    /// </summary>
    /// <param name="context">The current request context.</param>
    public void StampSessionAndBaggage(HttpContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        // Resolve the session id and stamp the required response header before the adapter (or
        // custom handler) starts writing the response. Sanitize it first so a malicious or
        // malformed value cannot be reflected into the response header (header-injection defense).
        var sessionId = ActivityIdSanitizer.Sanitize(ActivitySessionIdResolver.Resolve(context.Request));
        context.Response.Headers[PlatformHeaders.SessionId] = sessionId;

        // Promote correlation baggage onto the current request span so the core enrichment
        // processor stamps the session id onto every span (and the core log enrichment onto logs).
        _tracing.PropagateActivityBaggage(sessionId);
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
