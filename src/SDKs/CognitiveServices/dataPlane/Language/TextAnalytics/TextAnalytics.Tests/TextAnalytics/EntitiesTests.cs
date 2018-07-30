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
                EntitiesBatchResult result = await client.EntitiesAsync(
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

                Assert.Equal("Windows 10", result.Documents[0].Entities[0].Name);
                Assert.Equal("5f9fbd03-49c4-39ef-cc95-de83ab897b94", result.Documents[0].Entities[0].BingId);
                context.Stop();
            }
        }
    }
}
