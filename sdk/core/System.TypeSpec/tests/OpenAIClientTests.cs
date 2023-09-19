// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI;
using System.Diagnostics;
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
        Debug.WriteLine(choice.Text);
    }

    [Fact]
    public void Options()
    {
        RequestOptions.DefaultLoggingPolicy = new LoggingPolicy(isLoggingEnabled: true);
        RequestOptions.DefaultRetryPolicy = new RetryPolicy(maxRetries: 3);

        var options = new OpenAIClientOptions();
        options.RetryPolicy = new CustomRetryPolicy();
        options.LoggingPolicy = new LoggingPolicy(isLoggingEnabled: false);

        var credential = new KeyCredential(Environment.GetEnvironmentVariable("OPENAI_KEY"));
        var client = new OpenAIClient(credential, options);

        var callOptions = new OpenAIClientOptions();
        options.LoggingPolicy = new LoggingPolicy(isLoggingEnabled: true);

        Result<Completions> result = client.GetCompletions("tell me something about life.", callOptions);
        Choice choice = result.Value.Choices[0];
        Debug.WriteLine(choice.Text);
    }
}
