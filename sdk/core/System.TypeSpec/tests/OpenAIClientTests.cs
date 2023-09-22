// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI;
using System.ServiceModel.Rest;
using System.ServiceModel.Rest.Core;
using Xunit;

namespace System.Tests;

public partial class OpenAIClientTests
{
    [Fact]
    public void ClientDoesNotExposeAzureTypes()
    {
        string key = Environment.GetEnvironmentVariable("OPENAI_KEY");
        var credential = new KeyCredential(key);
        var client = new OpenAIClient(credential);
        Result<Completions> result = client.GetCompletions("tell me something about life.");
        Choice choice = result.Value.Choices[0];
        Console.WriteLine(choice.Text);
    }

    [Fact]
    public void Options()
    {
        RequestOptions.DefaultLoggingPolicy = new LoggingPolicy(isLoggingEnabled: true);
        RequestOptions.DefaultRetryPolicy = new RetryPolicy(maxRetries: 3);

        var options = new OpenAIClientOptions();
        options.RetryPolicy = new CustomRetryPolicy();
        options.LoggingPolicy = new LoggingPolicy(isLoggingEnabled: true);

        var credential = new KeyCredential(Environment.GetEnvironmentVariable("OPENAI_KEY"));
        var client = new OpenAIClient(credential, options);

        var callOptions = new OpenAIClientOptions();
        //options.LoggingPolicy = new LoggingPolicy(isLoggingEnabled: false);

        Completions result = client.GetCompletions("tell me something about life.", callOptions);
        Choice choice = result.Choices[0];
        Console.WriteLine(choice.Text);
    }

    [Fact]
    public void Pipeline()
    {
        MessagePipeline pipeline = MessagePipeline.Create(new MessagePipelineTransport(), new RequestOptions());
        PipelineMessage message = pipeline.CreateMessage("GET", new Uri("http://www.google.com"));
        pipeline.Send(message);
        Assert.True(message.Response.Status < 299);
    }
}
