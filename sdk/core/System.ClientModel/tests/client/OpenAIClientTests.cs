// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using OpenAI;

namespace System.ClientModel.Tests;

public class OpenAIClientTests
{
    // This is a "TestSupportProject", so these tests will never be run as part of CIs.
    // It's here now for quick manual validation of client functionality, but we can revisit
    // this story going forward.
    [Test]
    public void TestClientSync()
    {
        string key = Environment.GetEnvironmentVariable("OPENAI_KEY");

        ApiKeyCredential credential = new ApiKeyCredential(key);
        OpenAIClient client = new OpenAIClient(new Uri("https://api.openai.com/"), credential);

        CompletionsOptions input = new(new string[] { "tell me something about life." })
        {
            InternalNonAzureModelName = "text-davinci-003"
        };

        ClientResult<Completions> result = client.GetCompletions(
            "<unused in public service>",
            input);
        Choice choice = result.Value.Choices[0];

        Assert.IsTrue(choice.Text.StartsWith("\n\nLife is"));
    }
}
