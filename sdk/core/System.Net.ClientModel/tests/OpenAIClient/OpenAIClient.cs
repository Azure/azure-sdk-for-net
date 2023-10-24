// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Net.ClientModel;
using System.Threading;

namespace OpenAI;

public class OpenAIClient
{
    private readonly HttpPipeline _pipeline;
    private readonly KeyCredential _credential;

    public OpenAIClient(KeyCredential credential, OpenAIClientOptions? options = default)
    {
        _credential = credential;
        _pipeline = HttpPipelineBuilder.Build(new PipelineBuilderOptions());
    }

    //public Result<Completions> GetCompletions(string prompt, CancellationToken cancellationToken = default)
    //{
    //    HttpMessage message = _pipeline.CreateMessage();
    //    message.BufferResponse = true;
    //    Request request = message.Request;
    //    request.Uri.Reset(new Uri("https://api.openai.com/v1/completions"));
    //    request.Method = RequestMethod.Post;
    //    request.Headers.Add(HttpHeader.Common.JsonContentType);
    //    request.Headers.Add(HttpHeader.Names.Authorization, $"Bearer {_credential.Key}");

    //    var body = new {
    //        model = "text-davinci-003",
    //        prompt = prompt,
    //        max_tokens = 7,
    //        temperature = 0
    //    };
    //    request.Content = RequestContent.Create(body);

    //    _pipeline.Send(message, cancellationToken);
    //    if (message.Response.IsError) {
    //        throw new Exception("");
    //    }
    //    var completions = Completions.Deserialize(message.Response.Content);

    //    return Result.FromValue(completions, message.Response);
    //}

    private class PipelineBuilderOptions : ClientOptions { }
}
