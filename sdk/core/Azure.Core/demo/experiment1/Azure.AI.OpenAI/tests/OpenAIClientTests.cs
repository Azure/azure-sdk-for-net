// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using System.ServiceModel.Rest;
using NUnit.Framework;

namespace Platform.OpenAI.Tests
{
    public class OpenAIClientTests
    {
        [Test]
        public void TestClient()
        {
            string key = Environment.GetEnvironmentVariable("OPENAI_KEY");

            KeyCredential credential = new KeyCredential(key);
            OpenAIClient client = new OpenAIClient(credential);

            Result<Completions> result = client.GetCompletions("tell me something about life.");
            Choice choice = result.Value.Choices[0];
            Debug.WriteLine(choice.Text);
        }
    }
}
