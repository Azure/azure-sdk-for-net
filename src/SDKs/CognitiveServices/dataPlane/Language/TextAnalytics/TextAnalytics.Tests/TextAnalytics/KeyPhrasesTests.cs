using Language.Tests;

using Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

using System.Collections.Generic;
using System.Threading.Tasks;

using Xunit;

namespace Microsoft.Azure.CognitiveServices.Language.TextAnalytics.Tests
{
    public class KeyPhrasesTests : BaseTests
    {
        [Fact]
        public async Task KeyPhrases()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "KeyPhrases");
                ITextAnalyticsClient client = GetClient(HttpMockServer.CreateInstance());
                KeyPhraseBatchResult result = await client.KeyPhrasesAsync(
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

                Assert.Equal("team mates", result.Documents[0].KeyPhrases[0]);
            }
        }
    }
}
