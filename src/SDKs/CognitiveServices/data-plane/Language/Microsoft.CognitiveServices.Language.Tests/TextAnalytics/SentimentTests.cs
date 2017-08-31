using Language.Tests;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.CognitiveServices.Language.TextAnalytics;
using Microsoft.CognitiveServices.Language.TextAnalytics.Models;
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
                SentimentBatchResultV2 result = client.Sentiment(
                    new MultiLanguageBatchInputV2(
                        new List<MultiLanguageInputV2>()
                        {
                            new MultiLanguageInputV2()
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
