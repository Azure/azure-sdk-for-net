using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace AgentFramework.Integration.Tests
{
    public class BasicWorkflowTests : AgentFrameworkAdapterFixture<BasicWorkflow.Samples.Program>
    {
        public BasicWorkflowTests(WebApplicationFactory<BasicWorkflow.Samples.Program> factory)
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
                    { "input", "Hello world." }
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
            // output should contain multiple messages in different languages
            var hasFrench = false;
            var hasSpanish = false;
            var hasEnglish = false;
            foreach (var outputItem in outputArr)
            {
                Assert.Equal(JsonValueKind.Object, outputItem.ValueKind);
                Assert.Equal(JsonValueKind.String, outputItem.GetProperty("type").ValueKind);

                if (outputItem.GetProperty("type").GetString() == "message"
                    && outputItem.GetProperty("role").ValueKind == JsonValueKind.String
                    && outputItem.GetProperty("role").GetString() == "assistant")
                {
                    // assistant message
                    ResultValidationHelper.ValidateNonEmptyArray(outputItem.GetProperty("content"));

                    var contentArr = outputItem.GetProperty("content").EnumerateArray();
                    foreach (var contentItem in contentArr)
                    {
                        ResultValidationHelper.ValidateString(contentItem.GetProperty("type"), "output_text");
                        var text = contentItem.GetProperty("text").GetString();
                        Assert.NotNull(text);
                        if (text.Contains("hola", StringComparison.OrdinalIgnoreCase))
                        {
                            hasSpanish = true;
                        }
                        else if (text.Contains("bonjour", StringComparison.OrdinalIgnoreCase))
                        {
                            hasFrench = true;
                        }
                        else if (text.Contains("hello", StringComparison.OrdinalIgnoreCase))
                        {
                            hasEnglish = true;
                        }
                    }
                }
            }
            Assert.True(hasFrench, "Output does not contain French translation.");
            Assert.True(hasSpanish, "Output does not contain Spanish translation.");
            Assert.True(hasEnglish, "Output does not contain English translation.");
        }
    }
}
