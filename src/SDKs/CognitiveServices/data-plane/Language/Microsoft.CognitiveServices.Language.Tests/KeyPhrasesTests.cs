using Microsoft.CognitiveServices.Language.TextAnalytics;
using Microsoft.CognitiveServices.Language.TextAnalytics.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Microsoft.CognitiveServices.Language.Tests
{
    public class KeyPhrasesTests : BaseTests
    {
        [Fact]
        public void KeyPhrases()
        {
            ITextAnalyticsAPI client = GetClient();
            KeyPhraseBatchResultV2 result = client.KeyPhrases(
                new MultiLanguageBatchInputV2(
                    new List<MultiLanguageInputV2>()
                    {
                        new MultiLanguageInputV2("id", "I love my team mates", "en")
                    }));

            Assert.Equal("team mates", result.Documents[0].KeyPhrases[0]);
        }
    }
}
