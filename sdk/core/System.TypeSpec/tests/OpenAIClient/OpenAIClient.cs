// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ServiceModel.Rest;
using System.ServiceModel.Rest.Core;

namespace OpenAI;

public class OpenAIClient
{
    private readonly MessagePipeline _pipeline;
    private readonly KeyCredential _credential;
    private readonly OpenAIClientOptions _options;

    public OpenAIClient(KeyCredential credential, OpenAIClientOptions options = default)
    {
        if (options == null) {
            options = new OpenAIClientOptions();
        }
        _options = options;
        _credential = credential;
        _pipeline = MessagePipeline.Create(options);
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
            throw new RequestErrorException(message.Response);
        }
        return Result.Create(message.Response);
    }
    public Result<Completions> GetCompletions(string prompt)
    {
        Result result = GetCompletions(prompt, null);
        var value = Completions.Deserialize(result.Response.Content);
        return new Result<Completions>(value, result);
    }

    protected PipelineMessage CreateGetCompletions(BinaryData body, RequestOptions options)
    {
        PipelineMessage message = _pipeline.CreateMessage("POST", new Uri("https://api.openai.com/v1/completions"));
        message.CancellationToken = options.CancellationToken;
        message.SetRequestHeader("Content-Type", "application/json");
        message.SetRequestHeader("Authorization", $"Bearer {_credential.Key}");
        message.SetRequestContent(body);
        return message;
    }
}
