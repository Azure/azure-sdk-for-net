// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http.Json;
using System.Text.Json;
using Agents.Customized.Integration.Tests;
using Azure.AI.AgentServer.Tests.Utils;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Azure.AI.AgentServer.Tests
{
    public class CustomizedAgentTests
    {
        private WebApplicationFactory<Program> factory = null!;
        private HttpClient client = null!;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.factory = new WebApplicationFactory<Program>();
            this.client = this.factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false,
            });
        }

        [Test]
        public async Task CreateResponse_NonStream()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "/responses")
            {
                Content = JsonContent.Create(new Dictionary<string, object>
                {
                    { "input", "Hello!" },
                }),
            };
            var response = await this.client.SendAsync(request).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            // read response content
            var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            using JsonDocument document = JsonDocument.Parse(responseData);

            // status should be completed
            ResultValidationHelper.ValidateString(document.RootElement.GetProperty("status"), "completed");

            // output should be a non-empty array
            ResultValidationHelper.ValidateNonEmptyArray(document.RootElement.GetProperty("output"));
            var outputArr = document.RootElement.GetProperty("output").EnumerateArray();
            foreach (var outputItem in outputArr)
            {
                Assert.AreEqual(JsonValueKind.Object, outputItem.ValueKind);
                Assert.AreEqual(JsonValueKind.String, outputItem.GetProperty("type").ValueKind);
            }

            // the last output item should be assistant message with weather info
            var lastOutputItem = outputArr.Last();
            ResultValidationHelper.ValidateString(lastOutputItem.GetProperty("type"), "message");
            ResultValidationHelper.ValidateString(lastOutputItem.GetProperty("role"), "assistant");
            ResultValidationHelper.ValidateNonEmptyArray(lastOutputItem.GetProperty("content"));
            var contentArr = lastOutputItem.GetProperty("content").EnumerateArray();
            foreach (var contentItem in contentArr)
            {
                ResultValidationHelper.ValidateString(contentItem.GetProperty("type"), "output_text");
                var text = contentItem.GetProperty("text").GetString();
                Assert.True(text?.Contains("I am a mock agent with no intelligence. You said"));
                Assert.True(text?.Contains("hello", StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}
