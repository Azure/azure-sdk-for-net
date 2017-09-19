using Language.Tests;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using Xunit;

namespace Language.TextAnalytics.Tests
{
    public class DetectLanguageTests : BaseTests
    {
        [Fact]
        public void DetectLanguage()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "DetectLanguage");
                ITextAnalyticsAPI client = GetClient(HttpMockServer.CreateInstance());
                LanguageBatchResult result = client.DetectLanguage(
                    new BatchInput(
                        new List<Input>()
                        {
                            new Input("id","I love my team mates")
                        }));

                Assert.Equal("English", result.Documents[0].DetectedLanguages[0].Name);
                Assert.Equal("en", result.Documents[0].DetectedLanguages[0].Iso6391Name);
                Assert.True(result.Documents[0].DetectedLanguages[0].Score > 0.7);
                context.Stop();
            }
        }
    }
}
