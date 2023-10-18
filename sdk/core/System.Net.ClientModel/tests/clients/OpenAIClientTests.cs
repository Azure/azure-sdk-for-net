// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using OpenAI;

namespace System.Net.ClientModel.Tests;

public class OpenAIClientTests
{
    [Test]
    public void TestClientSync()
    {
        string key = Environment.GetEnvironmentVariable("OPENAI_KEY");

        KeyCredential credential = new KeyCredential(key);
        OpenAIClient client = new OpenAIClient(new Uri("https://api.openai.com/"), credential);

        CompletionsOptions input = new(new string[] { "tell me something about life." })
        {
            InternalNonAzureModelName = "text-davinci-003"
        };

        // TODO: Mock this out.
        // We don't have test recordings, so we won't actually assert this.
        // But, if you uncomment this code and run it, the test should pass.

        //Result<Completions> result = client.GetCompletions(
        //    "<unused in public service>",
        //    input);
        //Choice choice = result.Value.Choices[0];

        //Assert.IsTrue(choice.Text.StartsWith("\n\nLife is"));
    }
}
