using Language.Tests;
using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Tests
{
    public class EntitiesTests : BaseTests
    {
        [Fact]
        public async Task EntitiesBatchAsync()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "EntitiesBatchAsync");
                ITextAnalyticsClient client = GetClient(HttpMockServer.CreateInstance());
                EntitiesBatchResult result = await client.EntitiesBatchAsync(
                    new MultiLanguageBatchInput(
                        new List<MultiLanguageInput>()
                        {
                            new MultiLanguageInput()
                            {
                                Id ="id",
                                Text ="Microsoft released Windows 10",
                                Language ="en"
                            }
                        }));

                Assert.Equal("Microsoft", result.Documents[0].Entities[0].Name);
                Assert.Equal("a093e9b9-90f5-a3d5-c4b8-5855e1b01f85", result.Documents[0].Entities[0].BingId);
                Assert.Equal("Microsoft", result.Documents[0].Entities[0].Matches[0].Text);
                Assert.Equal(0.12508682244047509, result.Documents[0].Entities[0].Matches[0].WikipediaScore);
                Assert.Equal(0.99999618530273438, result.Documents[0].Entities[0].Matches[0].EntityTypeScore);
                context.Stop();
            }
        }

        [Fact]
        public async Task EntitiesAsync()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "EntitiesAsync");
                ITextAnalyticsClient client = GetClient(HttpMockServer.CreateInstance());
                EntitiesResult result = await client.EntitiesAsync("Microsoft released Windows 10");

                Assert.Equal("Microsoft", result.Entities[0].Name);
                Assert.Equal("a093e9b9-90f5-a3d5-c4b8-5855e1b01f85", result.Entities[0].BingId);
                Assert.Equal("Microsoft", result.Entities[0].Matches[0].Text);
                Assert.Equal(0.12508682244047509, result.Entities[0].Matches[0].WikipediaScore);
                Assert.Equal(0.99999618530273438, result.Entities[0].Matches[0].EntityTypeScore);
                context.Stop();
            }
        }

        [Fact]
        public void EntitiesBatch()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "EntitiesBatch");
                ITextAnalyticsClient client = GetClient(HttpMockServer.CreateInstance());
                EntitiesBatchResult result = client.EntitiesBatch(
                    new MultiLanguageBatchInput(
                        new List<MultiLanguageInput>()
                        {
                            new MultiLanguageInput()
                            {
                                Id ="id",
                                Text ="Microsoft released Windows 10",
                                Language ="en"
                            }
                        }));

                Assert.Equal("Microsoft", result.Documents[0].Entities[0].Name);
                Assert.Equal("a093e9b9-90f5-a3d5-c4b8-5855e1b01f85", result.Documents[0].Entities[0].BingId);
                Assert.Equal("Microsoft", result.Documents[0].Entities[0].Matches[0].Text);
                Assert.Equal(0.12508682244047509, result.Documents[0].Entities[0].Matches[0].WikipediaScore);
                Assert.Equal(0.99999618530273438, result.Documents[0].Entities[0].Matches[0].EntityTypeScore);
                context.Stop();
            }
        }

        [Fact]
        public void Entities()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "Entities");
                ITextAnalyticsClient client = GetClient(HttpMockServer.CreateInstance());
                EntitiesResult result = client.Entities("Microsoft released Windows 10");

                Assert.Equal("Microsoft", result.Entities[0].Name);
                Assert.Equal("a093e9b9-90f5-a3d5-c4b8-5855e1b01f85", result.Entities[0].BingId);
                Assert.Equal("Microsoft", result.Entities[0].Matches[0].Text);
                Assert.Equal(0.12508682244047509, result.Entities[0].Matches[0].WikipediaScore);
                Assert.Equal(0.99999618530273438, result.Entities[0].Matches[0].EntityTypeScore);
                context.Stop();
            }
        }

    }
}
