// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.TypeSpec;
using System.TypeSpec.Tests;
using Xunit;

namespace System.Tests;

public class OpenAIClientTests
{
    [Fact]
    public void ClientDoesNotExposeAzureTypes()
    {
        var credential = new KeyCredential("...");
        var client = new OpenAIClient(credential);
        Result<Completions> result = client.GetCompletions();
    }
}
