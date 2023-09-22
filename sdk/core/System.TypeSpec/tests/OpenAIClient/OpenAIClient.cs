// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ServiceModel.Rest;
using System.ServiceModel.Rest.Core;
using System.Threading;

namespace OpenAI;

public class OpenAIClient
{
    private readonly MessagePipeline _pipeline;
    private readonly KeyCredential _credential;
    private readonly OpenAIClientOptions _options;

    public OpenAIClient(KeyCredential credential, OpenAIClientOptions options = default)
    {
        _options = options ?? new OpenAIClientOptions();
        _credential = credential;
        _pipeline = MessagePipeline.Create(new MessagePipelineTransport(), _options);
    }

    public Result GetCompletions(string prompt, RequestOptions options)
    {
        options ??= _options;

        var body = new {
            model = "gpt-3.5-turbo-instruct",
            prompt = prompt,
            max_tokens = 7,
            temperature = 0
        };

        PipelineMessage message = CreateGetCompletions(BinaryData.FromObjectAsJson(body), options);

        _pipeline.Send(message);
        if (message.Response.Status > 299) {
            if (message.Response != null) throw new RequestErrorException(message.Response);
            else throw new Exception("response null");
        }
        return Result.Create(message.Response);
    }
    public Result<Completions> GetCompletions(string prompt)
    {
        Result result = GetCompletions(prompt, null);
        var value = Completions.Deserialize(result.GetRawResponse().Content);
        return new Result<Completions>(value, result.GetRawResponse());
    }

    protected PipelineMessage CreateGetCompletions(BinaryData body, RequestOptions options)
    {
        PipelineMessage message = _pipeline.CreateMessage("POST", new Uri("https://api.openai.com/v1/completions"));
        message.CancellationToken = options.CancellationToken??CancellationToken.None;
        message.Request.SetHeaderValue("Content-Type", "application/json");
        message.Request.SetHeaderValue("Authorization", $"Bearer {_credential.Key}");
        message.Request.SetContent(body);
        return message;
    }
}
