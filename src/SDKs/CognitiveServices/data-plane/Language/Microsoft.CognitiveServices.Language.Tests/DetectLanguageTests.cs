using Microsoft.CognitiveServices.Language.TextAnalytics;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using Microsoft.CognitiveServices.Language.TextAnalytics.Models;

namespace Microsoft.CognitiveServices.Language.Tests
{
    public class DetectLanguageTests : BaseTests
    {
        [Fact]
        public void DetectLanguage()
        {
            ITextAnalyticsAPI client = GetClient();
            LanguageBatchResultV2 result = client.DetectLanguage(
                new BatchInputV2(
                    new List<InputV2>()
                    {
                        new InputV2("id","I love my team mates")
                    }));

            Assert.Equal("English", result.Documents[0].DetectedLanguages[0].Name);
            Assert.Equal("en", result.Documents[0].DetectedLanguages[0].Iso6391Name);
        }
    }
}
