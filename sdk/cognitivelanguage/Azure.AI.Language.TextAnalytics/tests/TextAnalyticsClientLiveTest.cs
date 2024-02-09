// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.AI.Language.Text;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.TextAnalytics.Tests
{
    public class TextAnalyticsClientLiveTest : AnalyzeTextTestBase
    {
        public TextAnalyticsClientLiveTest(bool isAsync, AnalyzeTextClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion, null /* RecordedTestMode.Record /* to record */)
        {
        }

        [RecordedTest]
        public async Task AnalyzeText_LanguageDetection()
        {
            string documentA =
                "Este documento está escrito en un lenguaje diferente al inglés. Su objectivo es demostrar cómo"
                + " invocar el método de detección de lenguaje del servicio de Text Analytics en Microsoft Azure."
                + " También muestra cómo acceder a la información retornada por el servicio. Esta funcionalidad es"
                + " útil para las aplicaciones que recopilan texto arbitrario donde el lenguaje no se conoce de"
                + " antemano. Puede usarse para detectar una amplia gama de lenguajes, variantes, dialectos y"
                + " algunos idiomas regionales o culturales.";

            AnalyzeTextTask body = new AnalyzeTextLanguageDetectionInput()
            {
                AnalysisInput = new LanguageDetectionAnalysisInput()
                {
                    Documents =
                        {
                            new LanguageInput("A", documentA),
                        }
                }
            };

            Response<AnalyzeTextTaskResult> response = await Client.AnalyzeTextAsync(body);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
            LanguageDetectionTaskResult languageDetectionTaskResult = (LanguageDetectionTaskResult)response.Value;

            Assert.IsNotNull(languageDetectionTaskResult);
            Assert.IsNotNull(languageDetectionTaskResult.Results);
            Assert.IsNotNull(languageDetectionTaskResult.Results.Documents);
            foreach (LanguageDetectionDocumentResult document in languageDetectionTaskResult.Results.Documents)
            {
                Assert.IsNotNull(document);
                Assert.IsNotNull(document.DetectedLanguage);
                Assert.IsNotNull(document.Id);
            }
        }

        [RecordedTest]
        public async Task AnalyzeText_Sentiment()
        {
            string documentA =
                "The food and service were unacceptable, but the concierge were nice. After talking to them about the"
                + " quality of the food and the process to get room service they refunded the money we spent at the"
                + " restaurant and gave us a voucher for nearby restaurants.";

            AnalyzeTextTask body = new AnalyzeTextSentimentAnalysisInput()
            {
                AnalysisInput = new MultiLanguageAnalysisInput()
                {
                    Documents =
                    {
                        new MultiLanguageInput("A", documentA, "en"),
                    }
                }
            };

            Response<AnalyzeTextTaskResult> response = await Client.AnalyzeTextAsync(body);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
            SentimentTaskResult sentimentTaskResult = (SentimentTaskResult)response.Value;

            Assert.IsNotNull(sentimentTaskResult);
            Assert.IsNotNull(sentimentTaskResult.Results);
            Assert.IsNotNull(sentimentTaskResult.Results.Documents);
            foreach (SentimentResponseWithDocumentDetectedLanguage sentimentResponseWithDocumentDetectedLanguage in sentimentTaskResult.Results.Documents)
            {
                Assert.IsNotNull(sentimentResponseWithDocumentDetectedLanguage);
                Assert.IsNotNull(sentimentResponseWithDocumentDetectedLanguage.Id);
                Assert.IsNotNull(sentimentResponseWithDocumentDetectedLanguage.Sentiment);
                Assert.IsNotNull(sentimentResponseWithDocumentDetectedLanguage.ConfidenceScores);
            }
        }

        [RecordedTest]
        public async Task AnalyzeText_ExtractKeyPhrases()
        {
            string documentA =
                "We love this trail and make the trip every year. The views are breathtaking and well worth the hike!"
                + " Yesterday was foggy though, so we missed the spectacular views. We tried again today and it was"
                + " amazing. Everyone in my family liked the trail although it was too challenging for the less"
                + " athletic among us. Not necessarily recommended for small children. A hotel close to the trail"
                + " offers services for childcare in case you want that.";

            AnalyzeTextTask body = new AnalyzeTextKeyPhraseExtractionInput()
            {
                AnalysisInput = new MultiLanguageAnalysisInput()
                {
                    Documents =
                    {
                        new MultiLanguageInput("A", documentA, "en"),
                    }
                },
                Parameters = new KeyPhraseTaskParameters()
                {
                    ModelVersion = "latest",
                }
            };

            Response<AnalyzeTextTaskResult> response = await Client.AnalyzeTextAsync(body);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
            KeyPhraseTaskResult keyPhraseTaskResult = (KeyPhraseTaskResult)response.Value;

            Assert.IsNotNull(keyPhraseTaskResult);
            Assert.IsNotNull(keyPhraseTaskResult.Results);
            Assert.IsNotNull(keyPhraseTaskResult.Results.Documents);
            foreach (KeyPhrasesDocumentResultWithDetectedLanguage kpeResult in keyPhraseTaskResult.Results.Documents)
            {
                Assert.IsNotNull(kpeResult);
                Assert.IsNotNull(kpeResult.Id);
                Assert.IsNotNull(kpeResult.KeyPhrases);
            }
        }

        [RecordedTest]
        public async Task AnalyzeText_RecognizeEntities()
        {
            string documentA =
                "We love this trail and make the trip every year. The views are breathtaking and well worth the hike!"
                + " Yesterday was foggy though, so we missed the spectacular views. We tried again today and it was"
                + " amazing. Everyone in my family liked the trail although it was too challenging for the less"
                + " athletic among us. Not necessarily recommended for small children. A hotel close to the trail"
                + " offers services for childcare in case you want that.";

            AnalyzeTextTask body = new AnalyzeTextEntityRecognitionInput()
            {
                AnalysisInput = new MultiLanguageAnalysisInput()
                {
                    Documents =
                    {
                        new MultiLanguageInput("A", documentA, "en"),
                    }
                },
                Parameters = new EntitiesTaskParameters()
                {
                    ModelVersion = "latest",
                }
            };

            Response<AnalyzeTextTaskResult> response = await Client.AnalyzeTextAsync(body);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
            EntitiesTaskResult entitiesTaskResult = (EntitiesTaskResult)response.Value;

            Assert.IsNotNull(entitiesTaskResult);
            Assert.IsNotNull(entitiesTaskResult.Results);
            Assert.IsNotNull(entitiesTaskResult.Results.Documents);
            foreach (EntitiesDocumentResultWithMetadataDetectedLanguage nerResult in entitiesTaskResult.Results.Documents)
            {
                Assert.IsNotNull(nerResult);
                Assert.IsNotNull(nerResult.Id);
                Assert.IsNotNull(nerResult.Entities);
            }
        }

        [Test]
        [SyncOnly]
        public void RecognizePii()
        {
            string documentA =
                "Parker Doe has repaid all of their loans as of 2020-04-25. Their SSN is 859-98-0987. To contact them,"
                + " use their phone number 800-102-1100. They are originally from Brazil and have document ID number"
                + " 998.214.865-68.";

            AnalyzeTextTask body = new AnalyzeTextPIIEntitiesRecognitionInput()
            {
                AnalysisInput = new MultiLanguageAnalysisInput()
                {
                    Documents =
                    {
                        new MultiLanguageInput("A", documentA, "en"),
                    }
                }
            };

            Response<AnalyzeTextTaskResult> response = Client.AnalyzeText(body);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
            PIITaskResult piiTaskResult = (PIITaskResult)response.Value;

            Assert.IsNotNull(piiTaskResult);
            Assert.IsNotNull(piiTaskResult.Results);
            Assert.IsNotNull(piiTaskResult.Results.Documents);
            foreach (PIIResultWithDetectedLanguage piiResult in piiTaskResult.Results.Documents)
            {
                foreach (Entity entity in piiResult.Entities)
                {
                    Assert.IsNotNull(entity.Text);
                    Assert.IsNotNull(entity.Category);
                }
            }
        }
    }
}
