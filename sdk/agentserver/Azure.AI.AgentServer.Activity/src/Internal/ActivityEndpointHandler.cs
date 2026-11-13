// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Security.Claims;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core;
using Microsoft.Agents.Builder;
using Microsoft.Agents.Hosting.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
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

    public ActivityEndpointHandler(IOptions<ActivityServerOptions> options, IConfiguration configuration, ActivityProtocolActivitySource tracing)
    {
        ArgumentNullException.ThrowIfNull(options);
        ArgumentNullException.ThrowIfNull(configuration);

        var value = options.Value;
        _digitalWorker = value.DigitalWorker;

        // Read from the host's effective configuration (not just what ActivityServerOptions alone
        // would derive) so a host-authored Connections:* override or custom IConnections still
        // yields a matching outbound identity instead of an anonymous one. Digital-worker turns are
        // anonymous (the FMI token exchange supplies the reply token).
        if (!_digitalWorker)
        {
            _botAppId = configuration[ConnectionEnvironment.ClientId];
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

        // Resolve the correlation ids and stamp the required session-id response header before the
        // adapter starts writing the response.
        var (sessionId, conversationId, responseId) = await StampSessionAndBaggageAsync(context).ConfigureAwait(false);

        // Start the per-turn invoke_agent span — the row the Foundry trace UI lists for the turn.
        // Core's FoundryEnrichmentProcessor stamps the agent identity and project id; this span
        // supplies the operation + session/conversation attributes and the response_id (the inbound
        // activity id). The Foundry trace-list query requires a span carrying the agent identity,
        // the project id, AND a response_id in the same trace — without the response_id the turn is
        // not picked up. Kept open across ProcessAsync so the model/tool child spans parent to this
        // turn. In Foundry-hosted (Agent365-only) mode there is no ASP.NET request activity, so this
        // is the trace root.
        using var span = _tracing.StartInvokeAgentSpan(sessionId, conversationId, responseId);

        // The Foundry gateway is a trusted, network-isolated proxy; inbound requests are not Bot
        // Framework channel JWTs. Set the synthesized outbound claims on the request principal so
        // the SDK's ProcessAsync (via HttpHelper.GetClaimsIdentity) uses them to mint the outbound
        // reply token — replacing inbound channel auth with the Foundry trust model.
        context.User = new ClaimsPrincipal(BuildOutboundClaims());

        // CloudAdapter.ProcessAsync absorbs protocol failures internally (invalid activities become
        // 400, processing exceptions become 500) without throwing, so ActivityErrorSourceFilter never
        // observes them. Classify the response here, registered before the adapter starts writing it,
        // so x-platform-error-source is still set for adapter-produced failures.
        context.Response.OnStarting(static state =>
        {
            var ctx = (HttpContext)state;
            if (ctx.Response.StatusCode >= StatusCodes.Status400BadRequest
                && !ctx.Response.Headers.ContainsKey(PlatformHeaders.ErrorSource))
            {
                ctx.Response.Headers[PlatformHeaders.ErrorSource] = ctx.Response.StatusCode >= StatusCodes.Status500InternalServerError
                    ? PlatformHeaders.ErrorSourceUpstream
                    : PlatformHeaders.ErrorSourceUser;
            }

            return Task.CompletedTask;
        }, context);

        // Native Microsoft 365 Agents SDK entry point: reads the activity, runs (or queues) the
        // turn, delivers replies via the connector, and writes the status code / response body.
        await adapter.ProcessAsync(context.Request, context.Response, agent, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Stamps the required session-id response header and promotes the correlation baggage onto the
    /// current request span. Safe to call for custom request handlers that bypass the SDK adapter.
    /// </summary>
    /// <param name="context">The current request context.</param>
    /// <returns>The resolved session id, conversation id (<c>null</c> when absent), and response id
    /// (the inbound activity id; <c>null</c> when absent).</returns>
    public async Task<(string SessionId, string? ConversationId, string? ResponseId)> StampSessionAndBaggageAsync(HttpContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        // Resolve the session id and stamp the required response header before the adapter (or
        // custom handler) starts writing the response. Sanitize it first so a malicious or
        // malformed value cannot be reflected into the response header (header-injection defense).
        var sessionId = ActivityIdSanitizer.Sanitize(ActivitySessionIdResolver.Resolve(context.Request));
        context.Response.Headers[PlatformHeaders.SessionId] = sessionId;

        // Best-effort: resolve the conversation id and the activity id from the inbound activity so
        // traces can correlate a turn to its conversation (surfaced by the Core enrichment processor
        // as gen_ai.conversation.id) and so the invoke_agent span carries a response_id (the inbound
        // activity id) — the field the Foundry trace-list query requires to pick up the turn.
        var (rawConversationId, rawActivityId) = await TryReadActivityIdsAsync(context.Request).ConfigureAwait(false);
        var conversationId = ActivityIdSanitizer.SanitizeOrNull(rawConversationId);
        var responseId = ActivityIdSanitizer.SanitizeOrNull(rawActivityId);

        // Promote correlation baggage onto the current request span so the core enrichment
        // processor stamps the session id (and conversation id, if any) onto every span and log.
        _tracing.PropagateActivityBaggage(sessionId, conversationId);

        return (sessionId, conversationId, responseId);
    }

    /// <summary>
    /// Best-effort extraction of <c>conversation.id</c> and the top-level activity <c>id</c> from the
    /// inbound activity JSON body. Enables request buffering and rewinds the stream so the adapter
    /// (or custom handler) can still read the body. Never throws — correlation is a diagnostic
    /// concern, not a request-failure one.
    /// </summary>
    private static async Task<(string? ConversationId, string? ActivityId)> TryReadActivityIdsAsync(HttpRequest request)
    {
        if (request.ContentLength == 0)
        {
            return (null, null);
        }

        try
        {
            request.EnableBuffering();
            request.Body.Position = 0;
            using var document = await JsonDocument.ParseAsync(request.Body).ConfigureAwait(false);

            if (document.RootElement.ValueKind != JsonValueKind.Object)
            {
                return (null, null);
            }

            string? conversationId = null;
            if (document.RootElement.TryGetProperty("conversation", out var conversation)
                && conversation.ValueKind == JsonValueKind.Object
                && conversation.TryGetProperty("id", out var convId)
                && convId.ValueKind == JsonValueKind.String)
            {
                conversationId = convId.GetString();
            }

            string? activityId = null;
            if (document.RootElement.TryGetProperty("id", out var id)
                && id.ValueKind == JsonValueKind.String)
            {
                activityId = id.GetString();
            }

            return (conversationId, activityId);
        }
        catch (JsonException)
        {
            // Non-JSON or malformed body — no ids to correlate.
            return (null, null);
        }
        finally
        {
            if (request.Body.CanSeek)
            {
                request.Body.Position = 0;
            }
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
