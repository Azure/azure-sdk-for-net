// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text;
using OpenAI;
using OpenAI.Realtime;

namespace Azure.AI.Projects;
#pragma warning disable OPENAI002

internal class RealtimeClientHelper
{
    /// <summary>
    /// Builds the WebSocket URI for a specific voice agent's realtime endpoint
    /// (<c>/agents/{agentName}/endpoint/protocols/voice</c>), matching the REST-documented
    /// conversation-history path (<c>/agents/{agentName}/endpoint/protocols/voice/conversations</c>)
    /// exposed by <see cref="Azure.AI.Projects.Agents.BetaVoiceAgentsConversations"/>.
    /// </summary>
    internal static Uri GetAgentWebSocketEndpoint(Uri endpoint, string agentName)
    {
        Argument.AssertNotNull(endpoint, nameof(endpoint));
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));

        UriBuilder uriBuilder = new(endpoint)
        {
            Scheme = endpoint.Scheme.ToLowerInvariant() switch
            {
                "http" => "ws",
                "https" => "wss",
                _ => endpoint.Scheme
            },
            Query = ""
        };
        uriBuilder.Path = $"{endpoint.AbsolutePath.TrimEnd('/')}/agents/{Uri.EscapeDataString(agentName)}/endpoint/protocols/voice";

        return uriBuilder.Uri;
    }

    /// <summary>
    /// Appends a non-empty query parameter to <paramref name="query"/>, matching the format
    /// expected by <see cref="UriBuilder.Query"/> (a leading '?' is not included).
    /// </summary>
    internal static void AppendQueryParameter(StringBuilder query, string name, string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return;
        }

        if (query.Length > 0)
        {
            query.Append('&');
        }
        query.Append(Uri.EscapeDataString(name));
        query.Append('=');
        query.Append(Uri.EscapeDataString(value));
    }

    internal static ClientPipeline CreatePipeline(Uri endpoint, AuthenticationTokenProvider tokenProvider, string experimentalHeaders, string authorizationScope, RealtimeClientOptions options = null)
    {
        options ??= new RealtimeClientOptions();
        BearerTokenPolicy authPolicy = new(tokenProvider, authorizationScope);

        TelemetryDetails telemetryDetails = new(typeof(OpenAIClient).Assembly, default);
        string prefix = "AIProjectClient";
        if (!string.IsNullOrEmpty(options.UserAgentApplicationId))
        {
            prefix = $"{options.UserAgentApplicationId}-AIProjectClient";
        }
        PipelinePolicyHelpers.AddRequestHeaderPolicy(options, "User-Agent", $"{prefix} {telemetryDetails.UserAgent}");
        PipelinePolicyHelpers.AddRequestHeaderPolicy(options, "x-ms-client-request-id", () => Guid.NewGuid().ToString().ToLowerInvariant());
        PipelinePolicyHelpers.AddRequestHeaderPolicy(options, "Foundry-Features", experimentalHeaders);
        PipelinePolicyHelpers.OpenAI.AddResponseItemInputTransformPolicy(options);
        PipelinePolicyHelpers.OpenAI.AddErrorTransformPolicy(options);
        PipelinePolicyHelpers.OpenAI.AddAzureFinetuningParityPolicy(options);
        return ClientPipeline.Create(options: options, perCallPolicies: [], perTryPolicies: [authPolicy], beforeTransportPolicies: []);
    }

    internal static string ExperimentalHeaders(string experimentalHeaders) => string.IsNullOrEmpty(experimentalHeaders) ? "VoiceAgents=V1Preview" : experimentalHeaders;
}
