using Language.Tests;

using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

using System.Collections.Generic;
using System.Threading.Tasks;

using Xunit;

namespace Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Tests
{
    public class DetectLanguageTests : BaseTests
    {
        [Fact]
        public async Task LanguageBatchAsync()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "LanguageBatchAsync");
                ITextAnalyticsClient client = GetClient(HttpMockServer.CreateInstance());
                LanguageBatchResult result = await client.DetectLanguageBatchAsync(
                    new LanguageBatchInput(
                        new List<LanguageInput>()
                        {
                            new LanguageInput("en","id","I love my team mates")
                        }));

                Assert.Equal("English", result.Documents[0].DetectedLanguages[0].Name);
                Assert.Equal("en", result.Documents[0].DetectedLanguages[0].Iso6391Name);
                Assert.True(result.Documents[0].DetectedLanguages[0].Score > 0.7);
                context.Stop();
            }
        }

        [Fact]
        public async Task DetectLanguageAsync()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "DetectLanguageAsync");
                ITextAnalyticsClient client = GetClient(HttpMockServer.CreateInstance());
                LanguageResult result = await client.DetectLanguageAsync(
                    "I love my team mates");

                Assert.Equal("English", result.DetectedLanguages[0].Name);
                Assert.Equal("en", result.DetectedLanguages[0].Iso6391Name);
                Assert.True(result.DetectedLanguages[0].Score > 0.7);
                context.Stop();
            }
        }

        [Fact]
        public void DetectLanguageBatch()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "DetectLanguageBatch");
                ITextAnalyticsClient client = GetClient(HttpMockServer.CreateInstance());
                LanguageBatchResult result = client.DetectLanguageBatch(
                    new LanguageBatchInput(
                        new List<LanguageInput>()
                        {
                            new LanguageInput("en","id","I love my team mates")
                        }));

                Assert.Equal("English", result.Documents[0].DetectedLanguages[0].Name);
                Assert.Equal("en", result.Documents[0].DetectedLanguages[0].Iso6391Name);
                Assert.True(result.Documents[0].DetectedLanguages[0].Score > 0.7);
                context.Stop();
            }
        }

        [Fact]
        public void DetectLanguage()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "DetectLanguage");
                ITextAnalyticsClient client = GetClient(HttpMockServer.CreateInstance());
                LanguageResult result = client.DetectLanguage(
                    "I love my team mates");

                Assert.Equal("English", result.DetectedLanguages[0].Name);
                Assert.Equal("en", result.DetectedLanguages[0].Iso6391Name);
                Assert.True(result.DetectedLanguages[0].Score > 0.7);
                context.Stop();
            }
        }
    }
}
