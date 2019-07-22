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
        public async Task KeyPhrasesBatchAsync()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "KeyPhrasesBatchAsync");
                ITextAnalyticsClient client = GetClient(HttpMockServer.CreateInstance());
                KeyPhraseBatchResult result = await client.KeyPhrasesBatchAsync(
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

        [Fact]
        public async Task KeyPhrasesAsync()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "KeyPhrasesAsync");
                ITextAnalyticsClient client = GetClient(HttpMockServer.CreateInstance());
                KeyPhraseResult result = await client.KeyPhrasesAsync("I love my team mates");

                Assert.Equal("team mates", result.KeyPhrases[0]);
            }
        }

        [Fact]
        public void KeyPhrasesBatch()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "KeyPhrasesBatch");
                ITextAnalyticsClient client = GetClient(HttpMockServer.CreateInstance());
                KeyPhraseBatchResult result = client.KeyPhrasesBatch(
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

        [Fact]
        public void KeyPhrases()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "KeyPhrases");
                ITextAnalyticsClient client = GetClient(HttpMockServer.CreateInstance());
                KeyPhraseResult result = client.KeyPhrases("I love my team mates");

                Assert.Equal("team mates", result.KeyPhrases[0]);
            }
        }

    }
}
