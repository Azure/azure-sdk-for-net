using Language.Tests;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using Xunit;

namespace Language.TextAnalytics.Tests
{
    public class SentimentTests : BaseTests
    {
        [Fact]
        public void Sentiment()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "Sentiment");
                ITextAnalyticsAPI client = GetClient(HttpMockServer.CreateInstance());
                SentimentBatchResult result = client.Sentiment(
                    new MultiLanguageBatchInput(
                        new List<MultiLanguageInput>()
                        {
                            new MultiLanguageInput()
                            {
                                Id ="id",
                                Text ="I love my team mates",
                                Language ="en"
                            }
                        }));

                Assert.True(result.Documents[0].Score > 0);
            }
        }
    }
}
