// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ServiceModel.Rest;
using System.Text.Json;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.OpenAI
{
    /// <summary> The Render service client. </summary>
    public partial class OpenAIClient
    {
        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        private readonly HttpPipeline _pipeline;
        private readonly KeyCredential _credential;

        // TODO: Diagnostic scopes

        // TODO: What's in the REST client?  DPG client?

        // TODO: XML comments

        public OpenAIClient(KeyCredential credential, OpenAIClientOptions options = default)
        {
            _credential = credential;
            _pipeline = HttpPipelineBuilder.Build(new PipelineBuilderOptions());
        }

        public Result<Completions> GetCompletions(string prompt, CancellationToken cancellationToken = default)
        {
            // TODO: Check args

            HttpMessage message = _pipeline.CreateMessage();
            message.BufferResponse = true;
            Request request = message.Request;
            request.Uri.Reset(new Uri("https://api.openai.com/v1/completions"));
            request.Method = RequestMethod.Post;
            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Headers.Add(HttpHeader.Names.Authorization, $"Bearer {_credential.Key}");

            var body = new
            {
                model = "text-davinci-003",
                prompt = prompt,
                max_tokens = 7,
                temperature = 0
            };
            request.Content = RequestContent.Create(body);

            _pipeline.Send(message, cancellationToken);
            if (message.Response.IsError)
            {
                // TODO: exception
                throw new Exception("");
            }

            using JsonDocument document = JsonDocument.Parse(message.Response.Content);
            Completions completions = Completions.Deserialize(document.RootElement);

            return Result.FromValue(completions, message.Response);
        }

        // TODO: protocol method

        // TODO: refactor
        private class PipelineBuilderOptions : ClientOptions { }
    }
}
