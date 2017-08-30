using Microsoft.CognitiveServices.Language.TextAnalytics;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.CognitiveServices.Language.TextAnalytics.Models;
using System.Net;
using Microsoft.Azure.Test.HttpRecorder;

namespace Microsoft.CognitiveServices.Language.Tests
{
    public class DetectLanguageTests : BaseTests
    {
        [Fact]
        public void DetectLanguage()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "DetectLanguage");
                ITextAnalyticsAPI client = GetClient(HttpMockServer.CreateInstance());
                LanguageBatchResultV2 result = client.DetectLanguage(
                    new BatchInputV2(
                        new List<InputV2>()
                        {
                        new InputV2("id","I love my team mates")
                        }));

                Assert.Equal("English", result.Documents[0].DetectedLanguages[0].Name);
                Assert.Equal("en", result.Documents[0].DetectedLanguages[0].Iso6391Name);

                context.Stop();
            }
        }
    }
}
