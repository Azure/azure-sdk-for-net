// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;
public class Sample_ChatCompletions
{
    [Test]
    public void InferenceChatCompletions()
    {
        var connectionString = Environment.GetEnvironmentVariable("AZURE_AI_CONNECTION_STRING");
        InferenceClient client = new AIProjectClient(connectionString, new DefaultAzureCredential()).GetInferenceClient();

        var test = client.GetChatCompletionsClient();
    }
}
