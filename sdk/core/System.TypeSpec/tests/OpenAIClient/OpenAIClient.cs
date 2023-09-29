// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ServiceModel.Rest;
using System.ServiceModel.Rest.Core;
using System.Threading;

namespace OpenAI;

public class OpenAIClient
{
    private readonly KeyCredential _credential;
    private readonly OpenAIOptions _options;

    public OpenAIClient(KeyCredential credential, OpenAIOptions options = default)
    {
        _credential = credential;
        _options = options ?? OpenAIOptions.Default;
        _options.GetPipeline();
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

        var pipeline = _options.GetPipeline();
        pipeline.Send(message);
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
    public CancellationToken? CancellationToken { get; set; }

    protected PipelineMessage CreateGetCompletions(BinaryData body, RequestOptions options)
    {
        var pipeline = _options.GetPipeline();
        PipelineMessage message = pipeline.CreateMessage("POST", new Uri("https://api.openai.com/v1/completions"));
        message.CancellationToken = System.Threading.CancellationToken.None;
        if (options.CancellationToken != default) message.CancellationToken = options.CancellationToken;
        message.Request.SetHeaderValue("Content-Type", "application/json");
        message.Request.SetHeaderValue("Authorization", $"Bearer {_credential.Key}");
        message.Request.SetContent(body);
        return message;
    }
}
