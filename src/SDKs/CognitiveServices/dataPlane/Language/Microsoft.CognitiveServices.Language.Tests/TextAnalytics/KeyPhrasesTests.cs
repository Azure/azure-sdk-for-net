﻿using Language.Tests;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.CognitiveServices.Language.TextAnalytics;
using Microsoft.CognitiveServices.Language.TextAnalytics.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using Xunit;

namespace Language.TextAnalytics.Tests
{
    public class KeyPhrasesTests : BaseTests
    {
        [Fact]
        public void KeyPhrases()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "KeyPhrases");
                ITextAnalyticsAPI client = GetClient(HttpMockServer.CreateInstance());
                KeyPhraseBatchResultV2 result = client.KeyPhrases(
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

                Assert.Equal("team mates", result.Documents[0].KeyPhrases[0]);
            }
        }
    }
}
