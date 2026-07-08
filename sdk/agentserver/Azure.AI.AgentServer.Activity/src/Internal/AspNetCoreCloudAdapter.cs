// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Security.Claims;
using Microsoft.Agents.Builder;
using Microsoft.Agents.Builder.App;
using Microsoft.Agents.Hosting.AspNetCore;
using Microsoft.AspNetCore.Http;

namespace Azure.AI.AgentServer.Activity.Internal;

/// <summary>
/// ASP.NET Core CloudAdapter for the Activity protocol host, modelled on the Microsoft 365
/// Agents SDK per-framework adapter <c>Microsoft.Agents.Hosting.AspNetCore.CloudAdapter</c>.
/// </summary>
/// <remarks>
/// <para>
/// This adapter reads the inbound activity from the ASP.NET Core request, synthesizes the
/// outbound claims, drives a single turn through the M365 pipeline, and writes the response —
/// exactly the sequence the SDK's <c>CloudAdapter.ProcessAsync</c> performs, using the same
/// <see cref="HttpHelper"/> read/write helpers.
/// </para>
/// <para>
/// The one deliberate difference from <c>CloudAdapter.ProcessAsync</c>: the turn is run
/// <b>synchronously in-request</b> via <see cref="IChannelAdapter.ProcessActivityAsync"/> for
/// <em>all</em> delivery modes. The SDK's <c>ProcessAsync</c> queues normal-delivery messages to
/// a background <c>HostedActivityService</c>; the Activity host builds the M365 stack in a
/// standalone container where that background service is not running, so queued turns would never
/// execute. Running inline guarantees the handler runs and the connector delivers the reply during
/// the turn.
/// </para>
/// </remarks>
internal sealed class AspNetCoreCloudAdapter
{
    private readonly IChannelAdapter _adapter;
    private readonly bool _digitalWorker;
    private readonly string? _botAppId;

    /// <summary>Initializes the adapter around the M365 channel adapter.</summary>
    /// <param name="adapter">The M365 channel adapter that runs the turn pipeline.</param>
    /// <param name="digitalWorker">
    /// <c>true</c> for the digital-worker outbound-auth model (anonymous claims; the FMI patch
    /// supplies the token); <c>false</c> for the simple instance-identity model.
    /// </param>
    public AspNetCoreCloudAdapter(IChannelAdapter adapter, bool digitalWorker)
    {
        _adapter = adapter ?? throw new ArgumentNullException(nameof(adapter));
        _digitalWorker = digitalWorker;

        // Resolve the Bot Connector client id from the connection config (never from a mutated
        // environment variable). Only needed for the simple model's authenticated claims.
        var config = ActivityEnvironment.GetHostedAgentConfiguration(digitalWorker);
        _botAppId = config.TryGetValue(ConnectionEnvironment.ClientId, out var clientId) ? clientId : null;
    }

    /// <summary>
    /// Processes a single inbound activity request: read → build claims → run turn → write response.
    /// </summary>
    /// <param name="context">The ASP.NET Core HTTP context.</param>
    /// <param name="agent">The Microsoft 365 Agents SDK application handling the turn.</param>
    /// <param name="cancellationToken">A token to cancel the turn.</param>
    public async Task ProcessAsync(HttpContext context, AgentApplication agent, CancellationToken cancellationToken)
    {
        // Read the inbound activity from the request body (SDK helper).
        var activity = await HttpHelper.ReadRequestAsync<Microsoft.Agents.Core.Models.Activity>(context.Request)
            .ConfigureAwait(false);
        if (activity is null)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            return;
        }

        // Synthesize the outbound claims for this turn. The Foundry gateway is a trusted,
        // network-isolated proxy — inbound requests are NOT Bot Framework channel JWTs — so we do
        // not rely on inbound authentication (HttpHelper.GetClaimsIdentity). The synthesized claims
        // let the connector mint the outbound reply token.
        var claims = BuildOutboundClaims();

        // Run the turn synchronously in-request (see the class remarks for why we bypass the
        // queueing CloudAdapter.ProcessAsync). Replies are delivered to the channel by the
        // connector during the turn; an InvokeResponse (invoke / expectReplies) is written back.
        var invokeResponse = await _adapter
            .ProcessActivityAsync(claims, activity, agent.OnTurnAsync, cancellationToken)
            .ConfigureAwait(false);

        if (invokeResponse is not null)
        {
            // Write the status + JSON body using the SDK helper (invoke / expectReplies).
            await HttpHelper.WriteResponseAsync(context.Response, invokeResponse).ConfigureAwait(false);
        }
        else
        {
            // Normal delivery: the reply was already sent out-of-band during the turn.
            context.Response.StatusCode = StatusCodes.Status202Accepted;
        }
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
