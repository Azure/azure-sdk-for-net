// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System.Threading;

namespace System.TypeSpec.Tests;

public class OpenAIClient
{
    private readonly HttpPipeline _pipeline;
    private readonly KeyCredential _credential;

    public OpenAIClient(KeyCredential credential, OpenAIClientOptions options = default)
    {
        _credential = credential;
        _pipeline = new HttpPipeline(new HttpClientTransport());
    }

    public Result<Completions> GetCompletions(CancellationToken cancellationToken = default)
    {
        HttpMessage message = _pipeline.CreateMessage();
        Request request = message.Request;
        request.Uri.Reset(new Uri("https://api.openai.com/v1/completions"));
        request.Method = RequestMethod.Get;
        request.Headers.Add(HttpHeader.Common.JsonContentType);
        request.Headers.Add(HttpHeader.Names.Authorization, $"Bearer {_credential.Key}");

        var body = new {
            model = "text-davinci-003",
            prompt = "Say this is a test",
            max_tokens = 7,
            temperature = 0
        };
        request.Content = RequestContent.Create(body);

        _pipeline.Send(message, cancellationToken);
        if (message.Response.IsError) {
            throw new Exception("");
        }
        var completions = Completions.Deserialize(message.Response.Content);

        return Result.FromValue(completions, message.Response);
    }
}

public class Completions
{
    internal static Completions Deserialize(BinaryData data)
    {
        return new Completions();
    }
}

public class OpenAIClientOptions
{
}
