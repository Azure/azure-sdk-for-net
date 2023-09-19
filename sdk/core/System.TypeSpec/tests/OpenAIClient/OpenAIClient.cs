// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ServiceModel.Rest;

namespace OpenAI;

public class OpenAIClient
{
    private readonly MessagePipeline _pipeline;
    private readonly KeyCredential _credential;
    private readonly OpenAIClientOptions _options;

    public OpenAIClient(KeyCredential credential, OpenAIClientOptions options = default)
    {
        _options = options;
        _credential = credential;
        _pipeline = new MessagePipeline(options);
    }

    public Result<Completions> GetCompletions(string prompt, RequestOptions options = default)
    {
        options ??= _options;

        var body = new {
            model = "text-davinci-003",
            prompt = prompt,
            max_tokens = 7,
            temperature = 0
        };

        PipelineMessage message = CreateGetCompletions(BinaryData.FromObjectAsJson(body), options);

        _pipeline.Send(message);
        if (message.Result.Status > 299) {
            throw new RequestErrorException(message.Result);
        }
        var completions = Completions.Deserialize(message.Result.Content);

        return Result.FromValue(completions, message.Result);
    }

    protected PipelineMessage CreateGetCompletions(BinaryData body, RequestOptions options)
    {
        PipelineMessage message = _pipeline.CreateMessage("POST", new Uri("https://api.openai.com/v1/completions"));
        message.CancellationToken = options.CancellationToken;
        message.AddHeader("ContentType", "application/json");
        message.AddHeader("Authorization", $"Bearer {_credential.Key}");
        message.AddRequestContent(body);
        return message;
    }
}
