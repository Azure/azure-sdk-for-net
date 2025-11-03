// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.IO;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using Azure.Core;
using OpenAI;
using OpenAI.Files;

namespace Azure.AI.Agents;

#pragma warning disable CS0618

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

        public static void AddAzureFinetuningParityPolicy(OpenAIClientOptions options)
        {
            options.AddPolicy(
                new GenericActionPipelinePolicy(
                    messageAction: message =>
                    {
                        // Skip this policy for everything except file operations
                        if (message?.Request?.Uri?.AbsoluteUri?.Contains("openai/files") == false)
                        {
                            return;
                        }

                        // When processing the message to send the request (no response yet), perform a fixup to ensure a multipart/form-data Content-Type is
                        // provided for the "file" content part (non-parity limitation)
                        if (message?.Request?.Method == "POST" && message?.Request is not null && message?.Response is null)
                        {
                            using MemoryStream requestStream = new();
                            message.Request.Content.WriteTo(requestStream);
                            requestStream.Position = 0;
                            using StreamReader reader = new(requestStream);

                            MemoryStream newRequestStream = new();
                            StreamWriter newRequestWriter = new(newRequestStream);
                            string previousLine = null;

                            for (string line = reader.ReadLine(); line is not null; line = reader.ReadLine())
                            {
                                if (line == string.Empty
                                    && Regex.Match(
                                        previousLine,
                                        "Content-Disposition: form-data; name=file; filename=([^;]*);.*") is Match fileContentDispositionMatch
                                    && fileContentDispositionMatch.Success)
                                {
                                    // We are explicitly set the line ending as
                                    // WriteLine will add only \n symbol on Unix systems,
                                    // Which will result in error 400 on te service side.
                                    newRequestWriter.Write("Content-Type: application/octet-stream\r\n");
                                }
                                newRequestWriter.Write($"{line}\r\n");
                                previousLine = line;
                            }

                            newRequestWriter.Flush();
                            newRequestStream.Position = 0;
                            message.Request.Content = BinaryContent.Create(newRequestStream);
                            message.ResponseClassifier = PipelineMessageClassifier;
                        }

                        // When processing the message for the response, force non-OpenAI "status" values to "processed" and relocate the extended value
                        // to an additional property
                        if (message?.Response is not null)
                        {
                            message?.Response.BufferContent();

                            // Only parse as JSON if the response Content-Type indicates JSON
                            string contentType = message?.Response?.Headers?.TryGetValue("Content-Type", out string ct) == true ? ct : string.Empty;
                            bool isJsonResponse = contentType.IndexOf("application/json", StringComparison.OrdinalIgnoreCase) >= 0;

                            if (isJsonResponse
                                && JsonNode.Parse(message?.Response?.ContentStream) is JsonObject responseObject
                                && responseObject.TryGetPropertyValue("status", out JsonNode statusNode)
                                && statusNode is JsonValue statusValue
                                && !Enum.TryParse(statusValue.ToString(), out FileStatus _))
                            {
                                responseObject["status"] = "processed";
                                responseObject["_sdk_status"] = statusValue.ToString();
                                message.Response.ContentStream = new MemoryStream(BinaryData.FromString(responseObject.ToJsonString()).ToArray());
                            }
                        }
                    }),
                PipelinePosition.PerCall);
        }

        private static PipelineMessageClassifier s_pipelineMessageClassifier;
        private static PipelineMessageClassifier PipelineMessageClassifier
            => s_pipelineMessageClassifier ??= PipelineMessageClassifier.Create(stackalloc ushort[] { 200, 201 });
    }
}
