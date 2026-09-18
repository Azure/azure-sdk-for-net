// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using OpenAI;
using OpenAI.Realtime;

namespace Azure.AI.Projects;
#pragma warning disable OPENAI002

internal class RealtimeClientHelper
{
    internal static Uri GetWebSocketEndpoint(Uri endpoint, RealtimeClientOptions options = null)
    {
        if (options?.Endpoint is not null && endpoint is not null)
        {
            throw new InvalidOperationException(
                $"Cannot supply both a {nameof(options)}.{nameof(options.Endpoint)} and {nameof(endpoint)}.");
        }
        else if (options?.Endpoint is null && endpoint is null)
        {
            throw new InvalidOperationException($"Both {nameof(options)}.{nameof(options.Endpoint)} and {nameof(endpoint)} are null.");
        }
        UriBuilder uriBuilder = new(endpoint ?? options?.Endpoint);
        uriBuilder.Scheme = uriBuilder.Scheme.ToLowerInvariant() switch
        {
            "http" => "ws",
            "https" => "wss",
            _ => uriBuilder.Scheme
        };
        uriBuilder.Query = "";
        string path = uriBuilder.Path.TrimEnd('/');
        if (!path.EndsWith("/realtime", StringComparison.Ordinal))
        {
            path += "/realtime";
        }
        uriBuilder.Path = path;

        return uriBuilder.Uri;
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
