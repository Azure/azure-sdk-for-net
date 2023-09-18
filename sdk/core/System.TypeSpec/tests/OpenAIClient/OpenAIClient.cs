// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.ServiceModel.Rest;

namespace OpenAI;

public class OpenAIClient
{
    private readonly HttpPipeline _pipeline;
    private readonly KeyCredential _credential;
    private readonly OpenAIClientOptions _options;

    public OpenAIClient(KeyCredential credential, OpenAIClientOptions options = default)
    {
        _options = options;
        _credential = credential;
        _pipeline = HttpPipelineBuilder.Build(options);
    }

    public Result<Completions> GetCompletions(string prompt, PipelineOptions options = default)
    {
        options ??= _options;

        HttpMessage message = _pipeline.CreateMessage();
        message.BufferResponse = true;
        Request request = message.Request;
        request.Uri.Reset(new Uri("https://api.openai.com/v1/completions"));
        request.Method = RequestMethod.Post;
        request.Headers.Add(HttpHeader.Common.JsonContentType);
        request.Headers.Add(HttpHeader.Names.Authorization, $"Bearer {_credential.Key}");

        var body = new {
            model = "text-davinci-003",
            prompt = prompt,
            max_tokens = 7,
            temperature = 0
        };
        request.Content = RequestContent.Create(body);

        _pipeline.Send(message, options.CancellationToken);
        if (message.Response.IsError) {
            throw new RequestFailedException(message.Response);
        }
        var completions = Completions.Deserialize(message.Response.Content);

        return Result.FromValue(completions, message.Response);
    }
}
