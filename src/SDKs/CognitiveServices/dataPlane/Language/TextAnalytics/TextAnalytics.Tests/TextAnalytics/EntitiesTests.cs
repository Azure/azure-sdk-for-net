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
        public async Task Entities()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "Entities");
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
    }
}
