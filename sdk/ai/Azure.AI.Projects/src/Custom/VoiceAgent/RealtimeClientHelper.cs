// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
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

    internal static string WithTransportQuery(string queryString, string transport)
    {
        Argument.AssertNotNullOrEmpty(transport, nameof(transport));

        StringBuilder query = new();
        if (!string.IsNullOrEmpty(queryString))
        {
            foreach (string parameter in queryString.TrimStart('?').Split('&'))
            {
                int separator = parameter.IndexOf('=');
                string name = separator < 0 ? parameter : parameter.Substring(0, separator);
                if (string.Equals(Uri.UnescapeDataString(name), "transport", StringComparison.Ordinal))
                {
                    continue;
                }

                if (query.Length > 0)
                {
                    query.Append('&');
                }
                query.Append(parameter);
            }
        }
        AppendQueryParameter(query, "transport", transport);
        return query.ToString();
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
        if (!string.IsNullOrEmpty(experimentalHeaders))
        {
            PipelinePolicyHelpers.AddRequestHeaderPolicy(options, "Foundry-Features", experimentalHeaders);
        }
        PipelinePolicyHelpers.OpenAI.AddResponseItemInputTransformPolicy(options);
        PipelinePolicyHelpers.OpenAI.AddErrorTransformPolicy(options);
        PipelinePolicyHelpers.OpenAI.AddAzureFinetuningParityPolicy(options);
        return ClientPipeline.Create(options: options, perCallPolicies: [], perTryPolicies: [authPolicy], beforeTransportPolicies: []);
    }

    internal static string ResolveFoundryFeatures(IDictionary<string, string> headers,
        ref string queryString, bool requireVoiceAgentsPreview)
    {
        bool hasFeatureHeader = false;
        string featureHeader = null;
        if (headers != null)
        {
            foreach (KeyValuePair<string, string> header in headers)
            {
                if (header.Key.Equals("Foundry-Features", StringComparison.OrdinalIgnoreCase))
                {
                    if (hasFeatureHeader)
                    {
                        throw new ArgumentException("Only one Foundry-Features header may be supplied.", nameof(headers));
                    }
                    hasFeatureHeader = true;
                    featureHeader = header.Value;
                }
            }
        }

        queryString = queryString?.TrimStart('?');
        string[] parameters = queryString?.Split('&') ?? Array.Empty<string>();
        int featureParameter = -1;
        string featureQuery = null;
        for (int index = 0; index < parameters.Length; index++)
        {
            string parameter = parameters[index];
            int separator = parameter.IndexOf('=');
            string name = Uri.UnescapeDataString(separator < 0 ? parameter : parameter.Substring(0, separator));
            if (!name.Equals("foundry_features", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }
            if (featureParameter >= 0)
            {
                throw new ArgumentException("Only one foundry_features query parameter may be supplied.", nameof(queryString));
            }
            if (separator < 0)
            {
                throw new ArgumentException("The foundry_features query parameter must have a value.", nameof(queryString));
            }
            string encodedFeatures = parameter.Substring(separator + 1);
            for (int character = 0; character < encodedFeatures.Length; character++)
            {
                if (encodedFeatures[character] == '%' &&
                    (character + 2 >= encodedFeatures.Length ||
                        !Uri.IsHexDigit(encodedFeatures[character + 1]) || !Uri.IsHexDigit(encodedFeatures[character + 2])))
                {
                    throw new ArgumentException("The foundry_features query parameter contains invalid percent encoding.", nameof(queryString));
                }
            }
            featureParameter = index;
            featureQuery = Uri.UnescapeDataString(encodedFeatures.Replace("+", " "));
        }
        if (hasFeatureHeader && featureParameter >= 0)
        {
            throw new ArgumentException("Supply Foundry features using either the Foundry-Features header or the foundry_features query parameter, not both.", nameof(headers));
        }
        if (featureParameter >= 0)
        {
            string features = NormalizeFoundryFeatures(featureQuery, requireVoiceAgentsPreview, true, nameof(queryString));
            parameters[featureParameter] = "foundry_features=" + Uri.EscapeDataString(features);
            queryString = string.Join("&", parameters);
            // Use one feature channel for the handshake, including required native Live opt-ins.
            return null;
        }
        return NormalizeFoundryFeatures(featureHeader,
            requireVoiceAgentsPreview, hasFeatureHeader, nameof(headers));
    }

    private static string NormalizeFoundryFeatures(string features, bool requireVoiceAgentsPreview, bool explicitlySupplied, string parameterName)
    {
        const string voiceAgentsPreview = "VoiceAgents=V1Preview";
        if (string.IsNullOrEmpty(features))
        {
            if (explicitlySupplied)
            {
                throw new ArgumentException("Foundry features must contain non-empty name=value tokens.", parameterName);
            }
            return requireVoiceAgentsPreview ? voiceAgentsPreview : null;
        }

        foreach (char character in features)
        {
            if (char.IsControl(character))
            {
                throw new ArgumentException("Foundry feature tokens must not contain control characters.", parameterName);
            }
        }
        Dictionary<string, string> values = new(StringComparer.OrdinalIgnoreCase);
        List<string> normalized = new();
        foreach (string token in features.Split(','))
        {
            string entry = token.Trim();
            int separator = entry.IndexOf('=');
            if (separator <= 0 || separator == entry.Length - 1 || entry.IndexOf('=', separator + 1) >= 0)
            {
                throw new ArgumentException("Foundry features must contain non-empty name=value tokens.", parameterName);
            }
            foreach (char character in entry)
            {
                if (char.IsWhiteSpace(character))
                {
                    throw new ArgumentException("Foundry feature names and values must not contain whitespace.", parameterName);
                }
            }
            string name = entry.Substring(0, separator);
            string value = entry.Substring(separator + 1);
            if (name.Equals("VoiceAgents", StringComparison.OrdinalIgnoreCase))
            {
                if (!value.Equals("V1Preview", StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException("Voice Agents preview requires VoiceAgents=V1Preview.", parameterName);
                }
                entry = voiceAgentsPreview;
                value = "V1Preview";
            }
            if (values.TryGetValue(name, out string previous))
            {
                if (!value.Equals(previous, StringComparison.Ordinal))
                {
                    throw new ArgumentException("Conflicting values were supplied for a Foundry feature.", parameterName);
                }
                continue;
            }
            values.Add(name, value);
            normalized.Add(entry);
        }
        if (requireVoiceAgentsPreview && !values.ContainsKey("VoiceAgents"))
        {
            normalized.Add(voiceAgentsPreview);
        }
        return string.Join(",", normalized);
    }
}
