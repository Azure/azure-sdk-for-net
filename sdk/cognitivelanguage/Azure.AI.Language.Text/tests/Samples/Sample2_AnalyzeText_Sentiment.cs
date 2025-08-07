// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.AI.Language.Text;
using Azure.AI.Language.Text.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.TextAnalytics.Tests.Samples
{
    public partial class Sample2_AnalyzeText_Sentiment : SamplesBase<TextAnalysisClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void Sentiment()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisClient client = new TextAnalysisClient(endpoint, credential);

            #region Snippet:Sample2_AnalyzeText_Sentiment
            string textA =
                "The food and service were unacceptable, but the concierge were nice. After talking to them about the"
                + " quality of the food and the process to get room service they refunded the money we spent at the"
                + " restaurant and gave us a voucher for nearby restaurants.";

            string textB =
                "Nos hospedamos en el Hotel Foo la semana pasada por nuestro aniversario. La gerencia sabía de nuestra"
                + " celebración y me ayudaron a tenerle una sorpresa a mi pareja. La habitación estaba limpia y"
                + " decorada como yo había pedido. Una gran experiencia. El próximo año volveremos.";

            string textC =
                "The rooms were beautiful. The AC was good and quiet, which was key for us as outside it was 100F and"
                + " our baby was getting uncomfortable because of the heat. The breakfast was good too with good"
                + " options and good servicing times. The thing we didn't like was that the toilet in our bathroom was"
                + " smelly. It could have been that the toilet was not cleaned before we arrived.";

            try
            {
                AnalyzeTextInput body = new TextSentimentAnalysisInput()
                {
                    TextInput = new MultiLanguageTextInput()
                    {
                        MultiLanguageInputs =
                        {
                            new MultiLanguageInput("A", textA) { Language = "en" },
                            new MultiLanguageInput("B", textB) { Language = "es" },
                            new MultiLanguageInput("C", textC) { Language = "en" },
                        }
                    }
                };

                Response<AnalyzeTextResult> response = client.AnalyzeText(body);
                AnalyzeTextSentimentResult AnalyzeTextSentimentResult = (AnalyzeTextSentimentResult)response.Value;

                foreach (SentimentActionResult sentimentResponseWithDocumentDetectedLanguage in AnalyzeTextSentimentResult.Results.Documents)
                {
                        Console.WriteLine($"Document {sentimentResponseWithDocumentDetectedLanguage.Id} sentiment is {sentimentResponseWithDocumentDetectedLanguage.Sentiment} with: ");
                        Console.WriteLine($"  Positive confidence score: {sentimentResponseWithDocumentDetectedLanguage.ConfidenceScores.Positive}");
                        Console.WriteLine($"  Neutral confidence score: {sentimentResponseWithDocumentDetectedLanguage.ConfidenceScores.Neutral}");
                        Console.WriteLine($"  Negative confidence score: {sentimentResponseWithDocumentDetectedLanguage.ConfidenceScores.Negative}");
                }

                foreach (DocumentError analyzeTextDocumentError in AnalyzeTextSentimentResult.Results.Errors)
                {
                    Console.WriteLine($"  Error on document {analyzeTextDocumentError.Id}!");
                    Console.WriteLine($"  Document error code: {analyzeTextDocumentError.Error.Code}");
                    Console.WriteLine($"  Message: {analyzeTextDocumentError.Error.Message}");
                    Console.WriteLine();
                    continue;
                }
            }
            catch (RequestFailedException exception)
            {
                Console.WriteLine($"Error DocumentWarningCode: {exception.ErrorCode}");
                Console.WriteLine($"Message: {exception.Message}");
            }
            #endregion
        }

        [Test]
        [SyncOnly]
        public void Sentiment_OpinionMining()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalysisClient client = new TextAnalysisClient(endpoint, credential);

            #region Snippet:Sample2_AnalyzeText_Sentiment_OpinionMining
            string reviewA =
                "The food and service were unacceptable, but the concierge were nice. After talking to them about the"
                + " quality of the food and the process to get room service they refunded the money we spent at the"
                + " restaurant and gave us a voucher for nearby restaurants.";

            string reviewB =
                "The rooms were beautiful. The AC was good and quiet, which was key for us as outside it was 100F and"
                + "our baby was getting uncomfortable because of the heat. The breakfast was good too with good"
                + " options and good servicing times. The thing we didn't like was that the toilet in our bathroom was"
                + "smelly. It could have been that the toilet was not cleaned before we arrived. Either way it was"
                + "very uncomfortable. Once we notified the staff, they came and cleaned it and left candles.";

            string reviewC =
                "Nice rooms! I had a great unobstructed view of the Microsoft campus but bathrooms were old and the"
                + "toilet was dirty when we arrived. It was close to bus stops and groceries stores. If you want to"
                + "be close to campus I will recommend it, otherwise, might be better to stay in a cleaner one.";

            // Prepare the input of the text analysis operation. You can add multiple documents to this list and
            // perform the same operation on all of them simultaneously.
            List<string> batchedDocuments = new()
            {
                reviewA,
                reviewB,
                reviewC
            };

            AnalyzeTextInput body = new TextSentimentAnalysisInput()
            {
                TextInput = new MultiLanguageTextInput()
                {
                    MultiLanguageInputs =
                    {
                        new MultiLanguageInput("A", reviewA) { Language = "en" },
                        new MultiLanguageInput("B", reviewB) { Language = "en" },
                        new MultiLanguageInput("C", reviewC) { Language = "en" },
                    }
                },
                ActionContent = new SentimentAnalysisActionContent()
                {
                    OpinionMining = true,
                }
            };

            Response<AnalyzeTextResult> response = client.AnalyzeText(body);
            AnalyzeTextSentimentResult reviews = (AnalyzeTextSentimentResult)response.Value;

            Dictionary<string, int> complaints = GetComplaints(reviews);

            string negativeAspect = complaints.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            Console.WriteLine($"Alert! major complaint is *{negativeAspect}*");
            Console.WriteLine();
            Console.WriteLine("---All complaints:");
            foreach (KeyValuePair<string, int> complaint in complaints)
            {
                Console.WriteLine($"   {complaint.Key}, {complaint.Value}");
            }
            #endregion
        }

        #region Snippet:Sample2_AnalyzeText_Sentiment_GetComplaints
        private Dictionary<string, int> GetComplaints(AnalyzeTextSentimentResult reviews)
        {
            Dictionary<string, int> complaints = new();
            foreach (SentimentActionResult sentimentResponseWithDocumentDetectedLanguage in reviews.Results.Documents)
            {
                foreach (SentenceSentiment sentence in sentimentResponseWithDocumentDetectedLanguage.Sentences)
                {
                    foreach (SentenceTarget target in sentence.Targets)
                    {
                        if (target.Sentiment == TokenSentiment.Negative)
                        {
                            complaints.TryGetValue(target.Text, out int value);
                            complaints[target.Text] = value + 1;
                        }
                    }
                }
            }
            return complaints;
        }
        #endregion
    }
}
