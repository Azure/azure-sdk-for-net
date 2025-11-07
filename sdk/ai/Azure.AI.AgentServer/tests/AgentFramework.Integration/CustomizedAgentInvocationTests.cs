using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace AgentFramework.Integration.Tests
{
    public class CustomizedAgentInvocationTests : AgentFrameworkAdapterFixture<CustomizedAgentInvocationProgram>
    {
        public CustomizedAgentInvocationTests(WebApplicationFactory<CustomizedAgentInvocationProgram> factory)
            : base(factory)
        {
        }

        [Fact]
        public async Task CreateResponse_NonStream()
        {
            var client = _factory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "/responses")
            {
                Content = JsonContent.Create(new Dictionary<string, object>
                {
                    { "input", "Hello!" }
                })
            };
            var response = await client.SendAsync(request).ConfigureAwait(false);
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
                Assert.Equal(JsonValueKind.Object, outputItem.ValueKind);
                Assert.Equal(JsonValueKind.String, outputItem.GetProperty("type").ValueKind);
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
                Assert.Contains("I am a mock agent with no intelligence. You said", text);
                Assert.Contains("hello", text, StringComparison.OrdinalIgnoreCase);
            }
        }
    }
}
