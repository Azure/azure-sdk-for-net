// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenAI;
using System.ServiceModel.Rest;
using Xunit;

namespace System.Tests;

public class OpenAIClientTests
{
    [Fact]
    public void ClientDoesNotExposeAzureTypes()
    {
        var credential = new KeyCredential("...");
        var client = new OpenAIClient(credential);
        Result<Completions> result = client.GetCompletions("tell me something about life.");
        Choice choice = result.Value.Choices[0];
        Console.WriteLine(choice.Text);
    }
}
