// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.IO;
using System.Text;
using System.Text.Json.Nodes;
using Azure.Core;
using OpenAI;

namespace Azure.AI.Agents;

internal static partial class PipelinePolicyHelpers
{
    /// <summary>
    /// Adds a policy to <paramref name="options"/> that ensures a query parameter with the provided/key value is present.
    /// </summary>
    /// <param name="options"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public static void AddQueryParameterPolicy(ClientPipelineOptions options, string key, string value)
        => AddQueryParameterPolicy(options, key, () => value);

    /// <summary>
    /// Adds a policy to <paramref name="options"/> that ensures a query parameter with the key is present, delay-invoking the provided value generator.
    /// </summary>
    /// <param name="options"></param>
    /// <param name="key"></param>
    /// <param name="valueGenerator"></param>
    public static void AddQueryParameterPolicy(ClientPipelineOptions options, string key, Func<string> valueGenerator)
    {
        options.AddPolicy(
            new GenericActionPipelinePolicy(
                requestAction: request =>
                {
                    if (request?.Uri is Uri requestUri)
                    {
                        RawRequestUriBuilder builder = new();
                        builder.Reset(requestUri);
                        if (!builder.Query.Contains(key))
                        {
                            string value = valueGenerator.Invoke();
                            if (!string.IsNullOrEmpty(value))
                            {
                                builder.AppendQuery(key, value, escapeValue: true);
                            }
                        }
                        request.Uri = builder.ToUri();
                    }
                }),
                PipelinePosition.PerCall);
    }

    public static void AddRequestHeaderPolicy(ClientPipelineOptions options, string key, string value)
        => AddRequestHeaderPolicy(options, key, () => value);

    public static void AddRequestHeaderPolicy(ClientPipelineOptions options, string key, Func<string> valueGenerator)
    {
        options.AddPolicy(
            new GenericActionPipelinePolicy(
                requestAction: request =>
                {
                    request.Headers.Set(key, valueGenerator.Invoke());
                }),
            PipelinePosition.PerCall);
    }

    internal static partial class OpenAI
    {
        /// <summary>
        /// Adds a policy to <paramref name="options"/> that removes "id" and "status" properties from each item in an array of OpenAIResponse items, as needed for full compatibility in specific operations.
        /// </summary>
        /// <remarks>
        /// This is a workaround for an issue in the OpenAI library: https://github.com/openai/openai-dotnet/issues/779
        /// </remarks>
        /// <param name="options"></param>
        public static void AddResponseItemInputTransformPolicy(OpenAIClientOptions options)
        {
            options.AddPolicy(new GenericActionPipelinePolicy(
                requestAction: request =>
                {
                    if (request.Method == "POST" && (request.Uri?.AbsoluteUri?.EndsWith("/responses") == true || request.Uri?.AbsoluteUri?.Contains("/responses?") == true))
                    {
                        using MemoryStream stream = new();
                        request.Content.WriteTo(stream);
                        stream.Position = 0;
                        JsonNode node = JsonNode.Parse(stream);
                        if (node.AsObject() is JsonObject responseRequestObject
                            && responseRequestObject.TryGetPropertyValue("input", out JsonNode inputNode) == true
                            && inputNode.AsArray() is JsonArray inputArray)
                        {
                            foreach (JsonNode inputItemNode in inputArray)
                            {
                                if (inputItemNode?.AsObject() is JsonObject inputItemObject)
                                {
                                    inputItemObject.Remove("id");
                                    inputItemObject.Remove("status");
                                }
                            }

                            request.Content = BinaryContent.Create(BinaryData.FromString(node.ToJsonString()));
                        }
                    }
                }),
                PipelinePosition.PerCall);
        }

        /// <summary>
        /// Adds a policy to <paramref name="options"/> that aggressively transforms divergent error response payloads into something with user-facing information.
        /// Error response to exception message conversion is handled in the external OpenAI library for Responses and other OpenAI-based calls, so this heavier-weight
        /// content reformatting is necessary (in contrast to internal calls, where we can control the deserialization directly).
        /// </summary>
        /// <remarks>
        /// This is a temporary workaround for internal issue 4771165.
        /// </remarks>
        /// <param name="options"></param>
        public static void AddErrorTransformPolicy(OpenAIClientOptions options)
        {
            options.AddPolicy(
                new GenericActionPipelinePolicy(
                    responseAction: response =>
                    {
                        if (response?.IsError == true)
                        {
                            response.BufferContent();
                            try
                            {
                                if (JsonNode.Parse(response.Content) is JsonObject errorResponseJsonObject)
                                {
                                    if (AgentsApiError.TryCreateFromResponse(response) is AgentsApiError apiErrorInstance)
                                    {
                                        response.ContentStream = new MemoryStream(apiErrorInstance.ToOpenAIError().ToArray());
                                    }
                                    else if (errorResponseJsonObject.TryGetPropertyValue("error", out JsonNode errorNode)
                                        && errorNode is JsonObject errorObject
                                        && (errorObject.TryGetPropertyValue("additional_info", out JsonNode _)
                                            || errorObject.TryGetPropertyValue("details", out JsonNode _)))
                                    {
                                        StringBuilder messageRebuilder = new(errorObject.TryGetPropertyValue("message", out JsonNode messageNode) ? messageNode.ToString() : string.Empty);
                                        messageRebuilder.AppendLine().AppendLine();
                                        messageRebuilder.Append(errorObject.ToString());

                                        response.ContentStream = new MemoryStream(BinaryData.FromString($$"""
                                        {
                                          "error": {
                                            "type": "ServiceError",
                                            "code": {{JsonValue.Create(errorObject.TryGetPropertyValue("code", out JsonNode codeNode) ? codeNode.ToString() : string.Empty).ToJsonString()}},
                                            "param": {{JsonValue.Create(errorObject.TryGetPropertyValue("paramNode", out JsonNode paramNode) ? paramNode.ToString() : string.Empty).ToJsonString()}},
                                            "message": {{JsonValue.Create(messageRebuilder.ToString()).ToJsonString()}}
                                          }
                                        }
                                        """).ToArray());
                                    }
                                }
                            }
                            catch (System.Text.Json.JsonException)
                            { }
                        }
                    }),
                    PipelinePosition.PerTry);
        }
    }
}
