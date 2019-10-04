using Language.Tests;

using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

using System.Collections.Generic;
using System.Threading.Tasks;

using Xunit;

namespace Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Tests
{
    public class SentimentTests : BaseTests
    {
        [Fact]
        public async Task SentimentBatchAsync()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "SentimentBatchAsync");
                ITextAnalyticsClient client = GetClient(HttpMockServer.CreateInstance());
                SentimentBatchResult result = await client.SentimentBatchAsync(
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

        [Fact]
        public async Task SentimentAsync()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "SentimentAsync");
                ITextAnalyticsClient client = GetClient(HttpMockServer.CreateInstance());
                SentimentResult result = await client.SentimentAsync("I love my team mates");

                Assert.True(result.Score > 0);
            }
        }

        [Fact]
        public void SentimentBatch()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "SentimentBatch");
                ITextAnalyticsClient client = GetClient(HttpMockServer.CreateInstance());
                SentimentBatchResult result = client.SentimentBatch(
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

        [Fact]
        public void Sentiment()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "Sentiment");
                ITextAnalyticsClient client = GetClient(HttpMockServer.CreateInstance());
                SentimentResult result = client.Sentiment("I love my team mates");

                Assert.True(result.Score > 0);
            }
        }
    }
}
