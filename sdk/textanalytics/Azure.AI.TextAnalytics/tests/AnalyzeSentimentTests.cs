// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.TextAnalytics.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests
{
    public class AnalyzeSentimentTests : TextAnalyticsClientLiveTestBase
    {
        public AnalyzeSentimentTests(bool isAsync, TextAnalyticsClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        private const string singleEnglish = "That was the best day of my life!";
        private const string singleSpanish = "El mejor test del mundo!";

        private static List<string> batchConvenienceDocuments = new List<string>
        {
            "That was the best day of my life!. I had a lot of fun at the park.",
            "I'm not sure how I feel about this product. It is complicated."
        };

        private static List<TextDocumentInput> batchDocuments = new List<TextDocumentInput>
        {
            new TextDocumentInput("1", "Pike Place Market is my favorite Seattle attraction.  We had so much fun there.")
            {
                 Language = "en",
            },
            new TextDocumentInput("2", "Esta comida no me gusta. Siempre que la como me enfermo.")
            {
                 Language = "es",
            }
        };

        [RecordedTest]
        public async Task AnalyzeSentimentWithAADTest()
        {
            TextAnalyticsClient client = GetClient(useTokenCredential: true);
            string document = singleEnglish;

            DocumentSentiment docSentiment = await client.AnalyzeSentimentAsync(document);

            CheckAnalyzeSentimentProperties(docSentiment);
            Assert.AreEqual("Positive", docSentiment.Sentiment.ToString());
            Assert.AreEqual("Positive", docSentiment.Sentences.FirstOrDefault().Sentiment.ToString());
        }

        [RecordedTest]
        public async Task AnalyzeSentimentTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = singleEnglish;

            DocumentSentiment docSentiment = await client.AnalyzeSentimentAsync(document);

            CheckAnalyzeSentimentProperties(docSentiment);
            Assert.AreEqual("Positive", docSentiment.Sentiment.ToString());
            Assert.AreEqual("Positive", docSentiment.Sentences.FirstOrDefault().Sentiment.ToString());
        }

        [RecordedTest]
        public async Task AnalyzeSentimentWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = singleSpanish;

            DocumentSentiment docSentiment = await client.AnalyzeSentimentAsync(document, "es");

            CheckAnalyzeSentimentProperties(docSentiment);
            Assert.AreEqual("Positive", docSentiment.Sentiment.ToString());
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V3_1)]
        public async Task AnalyzeSentimentWithOpinionMining()
        {
            TextAnalyticsClient client = GetClient();
            string document = "The park was clean and pretty. The bathrooms and restaurant were not clean.";

            DocumentSentiment docSentiment = await client.AnalyzeSentimentAsync(document, options: new AnalyzeSentimentOptions() { IncludeOpinionMining = true });

            CheckAnalyzeSentimentProperties(docSentiment, opinionMining: true);
            Assert.AreEqual("Mixed", docSentiment.Sentiment.ToString());
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V3_1)]
        public async Task AnalyzeSentimentWithOpinionMiningEmpty()
        {
            TextAnalyticsClient client = GetClient();
            string document = singleEnglish;

            DocumentSentiment docSentiment = await client.AnalyzeSentimentAsync(document, "en", new AnalyzeSentimentOptions() { IncludeOpinionMining = true });

            CheckAnalyzeSentimentProperties(docSentiment);
            Assert.AreEqual("Positive", docSentiment.Sentiment.ToString());
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V3_1)]
        public async Task AnalyzeSentimentWithOpinionMiningNegated()
        {
            TextAnalyticsClient client = GetClient();
            string document = "The bathrooms are not clean.";

            DocumentSentiment docSentiment = await client.AnalyzeSentimentAsync(document, options: new AnalyzeSentimentOptions() { IncludeOpinionMining = true });

            CheckAnalyzeSentimentProperties(docSentiment, opinionMining: true);
            SentenceOpinion opinion = docSentiment.Sentences.FirstOrDefault().Opinions.FirstOrDefault();
            Assert.AreEqual("bathrooms", opinion.Target.Text);
            Assert.AreEqual(TextSentiment.Negative, opinion.Target.Sentiment);
            Assert.AreEqual("clean", opinion.Assessments.FirstOrDefault().Text);
            Assert.AreEqual(TextSentiment.Negative, opinion.Assessments.FirstOrDefault().Sentiment);
            Assert.IsTrue(opinion.Assessments.FirstOrDefault().IsNegated);
        }

        [RecordedTest]
        public async Task AnalyzeSentimentWithCancellationTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = singleSpanish;

            DocumentSentiment docSentiment = await client.AnalyzeSentimentAsync(document, cancellationToken: default);

            CheckAnalyzeSentimentProperties(docSentiment);
            Assert.AreEqual("Positive", docSentiment.Sentiment.ToString());
        }

        [RecordedTest]
        public async Task AnalyzeSentimentWithLanguageAndCancellationTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = singleSpanish;

            DocumentSentiment docSentiment = await client.AnalyzeSentimentAsync(document, "es", default);

            CheckAnalyzeSentimentProperties(docSentiment);
            Assert.AreEqual("Positive", docSentiment.Sentiment.ToString());
        }

        [RecordedTest]
        public async Task AnalyzeSentimentBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = batchConvenienceDocuments;

            AnalyzeSentimentResultCollection results = await client.AnalyzeSentimentBatchAsync(documents);

            foreach (AnalyzeSentimentResult docs in results)
            {
                CheckAnalyzeSentimentProperties(docs.DocumentSentiment);
            }

            Assert.AreEqual("Positive", results[0].DocumentSentiment.Sentiment.ToString());
            Assert.AreEqual("Negative", results[1].DocumentSentiment.Sentiment.ToString());
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V3_1)]
        public async Task AnalyzeSentimentBatchConvenienceWithOpinionMiningTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<string>
            {
                "The park was clean and pretty. The bathrooms and restaurant were not clean.",
                "The food and service is not good."
            };

            AnalyzeSentimentResultCollection results = await client.AnalyzeSentimentBatchAsync(documents, options: new AnalyzeSentimentOptions() { IncludeOpinionMining = true });

            foreach (AnalyzeSentimentResult docs in results)
            {
                CheckAnalyzeSentimentProperties(docs.DocumentSentiment, opinionMining: true);
            }

            Assert.AreEqual("Mixed", results[0].DocumentSentiment.Sentiment.ToString());
            Assert.AreEqual("Negative", results[1].DocumentSentiment.Sentiment.ToString());
        }

        [RecordedTest]
        public async Task AnalyzeSentimentBatchConvenienceWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = batchConvenienceDocuments;

            AnalyzeSentimentResultCollection results = await client.AnalyzeSentimentBatchAsync(documents, "en");

            foreach (AnalyzeSentimentResult docs in results)
            {
                CheckAnalyzeSentimentProperties(docs.DocumentSentiment);
            }

            Assert.AreEqual("Positive", results[0].DocumentSentiment.Sentiment.ToString());
            Assert.AreEqual("Negative", results[1].DocumentSentiment.Sentiment.ToString());
        }

        [RecordedTest]
        public async Task AnalyzeSentimentBatchConvenienceWithCancellationTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = batchConvenienceDocuments;

            AnalyzeSentimentResultCollection results = await client.AnalyzeSentimentBatchAsync(documents, cancellationToken: default);

            foreach (AnalyzeSentimentResult docs in results)
            {
                CheckAnalyzeSentimentProperties(docs.DocumentSentiment);
            }

            Assert.AreEqual("Positive", results[0].DocumentSentiment.Sentiment.ToString());
            Assert.AreEqual("Negative", results[1].DocumentSentiment.Sentiment.ToString());
        }

        [RecordedTest]
        public async Task AnalyzeSentimentBatchConvenienceWithLanguageAndCancellationTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = batchConvenienceDocuments;

            AnalyzeSentimentResultCollection results = await client.AnalyzeSentimentBatchAsync(documents, "en", cancellationToken: default);

            foreach (AnalyzeSentimentResult docs in results)
            {
                CheckAnalyzeSentimentProperties(docs.DocumentSentiment);
            }

            Assert.AreEqual("Positive", results[0].DocumentSentiment.Sentiment.ToString());
            Assert.AreEqual("Negative", results[1].DocumentSentiment.Sentiment.ToString());
        }

        [RecordedTest]
        public async Task AnalyzeSentimentBatchConvenienceWithLanguageAndStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = batchConvenienceDocuments;

            AnalyzeSentimentResultCollection results = await client.AnalyzeSentimentBatchAsync(documents, "en", new TextAnalyticsRequestOptions { IncludeStatistics = true });

            foreach (AnalyzeSentimentResult docs in results)
            {
                CheckAnalyzeSentimentProperties(docs.DocumentSentiment);
            }

            Assert.AreEqual("Positive", results[0].DocumentSentiment.Sentiment.ToString());
            Assert.AreEqual("Negative", results[1].DocumentSentiment.Sentiment.ToString());

            Assert.IsNotNull(results.Statistics.ValidDocumentCount);
            Assert.IsNotNull(results.Statistics.DocumentCount);
            Assert.IsNotNull(results.Statistics.TransactionCount);
            Assert.IsNotNull(results.Statistics.InvalidDocumentCount);
        }

        [RecordedTest]
        public async Task AnalyzeSentimentBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = batchConvenienceDocuments;

            AnalyzeSentimentResultCollection results = await client.AnalyzeSentimentBatchAsync(documents, options: new AnalyzeSentimentOptions() { IncludeStatistics = true });

            foreach (AnalyzeSentimentResult docs in results)
            {
                CheckAnalyzeSentimentProperties(docs.DocumentSentiment);
            }

            Assert.AreEqual("Positive", results[0].DocumentSentiment.Sentiment.ToString());
            Assert.AreEqual("Negative", results[1].DocumentSentiment.Sentiment.ToString());

            Assert.IsNotNull(results.Statistics.ValidDocumentCount);
            Assert.IsNotNull(results.Statistics.DocumentCount);
            Assert.IsNotNull(results.Statistics.TransactionCount);
            Assert.IsNotNull(results.Statistics.InvalidDocumentCount);
        }

        [RecordedTest]
        public async Task AnalyzeSentimentBatchConvenienceWithStatisticsAndCancellationTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = batchConvenienceDocuments;

            AnalyzeSentimentResultCollection results = await client.AnalyzeSentimentBatchAsync(documents, options: new AnalyzeSentimentOptions() { IncludeStatistics = true }, cancellationToken: default);

            foreach (AnalyzeSentimentResult docs in results)
            {
                CheckAnalyzeSentimentProperties(docs.DocumentSentiment);
            }

            Assert.AreEqual("Positive", results[0].DocumentSentiment.Sentiment.ToString());
            Assert.AreEqual("Negative", results[1].DocumentSentiment.Sentiment.ToString());

            Assert.IsNotNull(results.Statistics.ValidDocumentCount);
            Assert.IsNotNull(results.Statistics.DocumentCount);
            Assert.IsNotNull(results.Statistics.TransactionCount);
            Assert.IsNotNull(results.Statistics.InvalidDocumentCount);
        }

        [RecordedTest]
        public async Task AnalyzeSentimentBatchConvenienceFullTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = batchConvenienceDocuments;

            AnalyzeSentimentResultCollection results = await client.AnalyzeSentimentBatchAsync(documents, "en", new TextAnalyticsRequestOptions { IncludeStatistics = true }, default);

            foreach (AnalyzeSentimentResult result in results)
            {
                Assert.That(result.Id, Is.Not.Null.And.Not.Empty);
                Assert.False(result.HasError);
                Assert.IsNull(result.DetectedLanguage);
                CheckAnalyzeSentimentProperties(result.DocumentSentiment);
            }

            Assert.AreEqual("Positive", results[0].DocumentSentiment.Sentiment.ToString());
            Assert.AreEqual("Negative", results[1].DocumentSentiment.Sentiment.ToString());

            Assert.IsNotNull(results.Statistics.ValidDocumentCount);
            Assert.IsNotNull(results.Statistics.DocumentCount);
            Assert.IsNotNull(results.Statistics.TransactionCount);
            Assert.IsNotNull(results.Statistics.InvalidDocumentCount);
        }

        [RecordedTest]
        public async Task AnalyzeSentimentBatchTest()
        {
            TextAnalyticsClient client = GetClient();
            List<TextDocumentInput> documents = batchDocuments;

            AnalyzeSentimentResultCollection results = await client.AnalyzeSentimentBatchAsync(documents);

            foreach (AnalyzeSentimentResult docs in results)
            {
                CheckAnalyzeSentimentProperties(docs.DocumentSentiment);
            }

            Assert.AreEqual("Positive", results[0].DocumentSentiment.Sentiment.ToString());
            Assert.AreEqual("Negative", results[1].DocumentSentiment.Sentiment.ToString());
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V3_1)]
        public async Task AnalyzeSentimentBatchWithOpinionMiningTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<TextDocumentInput>
            {
                new TextDocumentInput("1", "The park was clean and pretty. The bathrooms and restaurant were not clean.")
                {
                     Language = "en",
                },
                new TextDocumentInput("2", "The food and service is not good.")
                {
                     Language = "en",
                }
            };

            AnalyzeSentimentResultCollection results = await client.AnalyzeSentimentBatchAsync(documents, options: new AnalyzeSentimentOptions() { IncludeOpinionMining = true });

            foreach (AnalyzeSentimentResult docs in results)
            {
                CheckAnalyzeSentimentProperties(docs.DocumentSentiment, opinionMining: true);
            }

            Assert.AreEqual("Mixed", results[0].DocumentSentiment.Sentiment.ToString());
            Assert.AreEqual("Negative", results[1].DocumentSentiment.Sentiment.ToString());
        }

        [RecordedTest]
        public async Task AnalyzeSentimentBatchWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            List<TextDocumentInput> documents = batchDocuments;

            AnalyzeSentimentResultCollection results = await client.AnalyzeSentimentBatchAsync(documents, new TextAnalyticsRequestOptions { IncludeStatistics = true });

            foreach (AnalyzeSentimentResult docs in results)
            {
                CheckAnalyzeSentimentProperties(docs.DocumentSentiment);
            }

            Assert.AreEqual("Positive", results[0].DocumentSentiment.Sentiment.ToString());
            Assert.AreEqual("Negative", results[1].DocumentSentiment.Sentiment.ToString());

            Assert.IsNotNull(results.Statistics.ValidDocumentCount);
            Assert.IsNotNull(results.Statistics.DocumentCount);
            Assert.IsNotNull(results.Statistics.TransactionCount);
            Assert.IsNotNull(results.Statistics.InvalidDocumentCount);
        }

        [RecordedTest]
        public async Task AnalyzeSentimentBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<string>
            {
                "That was the best day of my life!",
                "",
                "I'm not sure how I feel about this product."
            };

            AnalyzeSentimentResultCollection results = await client.AnalyzeSentimentBatchAsync(documents);

            Assert.IsTrue(!results[0].HasError);
            Assert.IsTrue(!results[2].HasError);

            var exceptionMessage = "Cannot access result for document 1, due to error InvalidDocument: Document text is empty.";
            Assert.IsTrue(results[1].HasError);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => results[1].DocumentSentiment.GetType());
            Assert.AreEqual(exceptionMessage, ex.Message);
        }

        [RecordedTest]
        public void AnalyzeSentimentBatchWithNullIdTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<TextDocumentInput> { new TextDocumentInput(null, "Hello world") };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.AnalyzeSentimentBatchAsync(documents));
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocument, ex.ErrorCode);
        }

        [RecordedTest]
        public async Task AnalyzeSentimentBatchWithNullTextTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<TextDocumentInput> { new TextDocumentInput("1", null) };

            AnalyzeSentimentResultCollection results = await client.AnalyzeSentimentBatchAsync(documents);
            var exceptionMessage = "Cannot access result for document 1, due to error InvalidDocument: Document text is empty.";
            Assert.IsTrue(results[0].HasError);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => results[0].DocumentSentiment.GetType());
            Assert.AreEqual(exceptionMessage, ex.Message);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_05_01)]
        [Ignore("LRO not implemented")]
        public async Task AnalyzeSentimentWithMultipleActions()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                AnalyzeSentimentActions = new List<AnalyzeSentimentAction>()
                {
                    new AnalyzeSentimentAction()
                    {
                        DisableServiceLogs = true,
                        ActionName = "AnalyzeSentimentWithDisabledServiceLogs"
                    },
                    new AnalyzeSentimentAction()
                    {
                        ActionName = "AnalyzeSentiment"
                    }
                }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(batchConvenienceDocuments, batchActions);

            await operation.WaitForCompletionAsync();

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<AnalyzeSentimentActionResult> AnalyzeSentimentActionsResults = resultCollection.AnalyzeSentimentResults;

            Assert.IsNotNull(AnalyzeSentimentActionsResults);

            IList<string> expected = new List<string> { "AnalyzeSentiment", "AnalyzeSentimentWithDisabledServiceLogs" };
            CollectionAssert.AreEquivalent(expected, AnalyzeSentimentActionsResults.Select(result => result.ActionName));
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V3_1)]
        public async Task AnalyzeSentimentBatchDisableServiceLogs()
        {
            TextAnalyticsClient client = GetClient();
            AnalyzeSentimentResultCollection results = await client.AnalyzeSentimentBatchAsync(batchConvenienceDocuments, "en", options: new TextAnalyticsRequestOptions { DisableServiceLogs = true });

            foreach (AnalyzeSentimentResult docs in results)
            {
                CheckAnalyzeSentimentProperties(docs.DocumentSentiment);
            }

            Assert.AreEqual("Positive", results[0].DocumentSentiment.Sentiment.ToString());
            Assert.AreEqual("Negative", results[1].DocumentSentiment.Sentiment.ToString());
        }

        [RecordedTest]
        [ServiceVersion(Max = TextAnalyticsClientOptions.ServiceVersion.V3_0)]
        public void AnalyzeSentimentBatchDisableServiceLogsThrows()
        {
            TestDiagnostics = false;

            TextAnalyticsClient client = GetClient();
            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(async () => await client.AnalyzeSentimentBatchAsync(batchConvenienceDocuments, "en", options: new TextAnalyticsRequestOptions { DisableServiceLogs = true }));
            Assert.AreEqual("AnalyzeSentimentOptions.DisableServiceLogs is not available in API version v3.0. Use service API version v3.1 or newer.", ex.Message);
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V3_1)]
        public async Task AnalyzeSentimentBatchIncludeOpinionMining()
        {
            TextAnalyticsClient client = GetClient();
            AnalyzeSentimentResultCollection results = await client.AnalyzeSentimentBatchAsync(batchConvenienceDocuments, "en", options: new AnalyzeSentimentOptions { IncludeOpinionMining = true });

            foreach (AnalyzeSentimentResult docs in results)
            {
                CheckAnalyzeSentimentProperties(docs.DocumentSentiment);
            }

            Assert.AreEqual("Positive", results[0].DocumentSentiment.Sentiment.ToString());
            Assert.AreEqual("Negative", results[1].DocumentSentiment.Sentiment.ToString());
        }

        [RecordedTest]
        [ServiceVersion(Max = TextAnalyticsClientOptions.ServiceVersion.V3_0)]
        public void AnalyzeSentimentBatchIncludeOpinionMiningThrows()
        {
            TestDiagnostics = false;

            TextAnalyticsClient client = GetClient();
            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(async () => await client.AnalyzeSentimentBatchAsync(batchConvenienceDocuments, "en", options: new AnalyzeSentimentOptions { IncludeOpinionMining = true }));
            Assert.AreEqual("AnalyzeSentimentOptions.IncludeOpinionMining is not available in API version v3.0. Use service API version v3.1 or newer.", ex.Message);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_10_01_Preview)]
        public async Task AnalyzeOperationAnalyzeSentimentWithAutoDetectedLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            List<string> documents = new()
            {
                "The park was clean and pretty. The bathrooms and restaurant were not clean.",
            };
            TextAnalyticsActions actions = new()
            {
                AnalyzeSentimentActions = new List<AnalyzeSentimentAction>() { new AnalyzeSentimentAction() }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(documents, actions, "auto");
            await operation.WaitForCompletionAsync();

            // Take the first page.
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            IReadOnlyCollection<AnalyzeSentimentActionResult> actionResults = resultCollection.AnalyzeSentimentResults;
            Assert.IsNotNull(actionResults);

            AnalyzeSentimentResultCollection results = actionResults.FirstOrDefault().DocumentsResults;
            Assert.AreEqual(1, actionResults.Count);

            AnalyzeSentimentResult result = results.FirstOrDefault();
            Assert.IsNotNull(result.DetectedLanguage);
            Assert.That(result.DetectedLanguage.Value.Name, Is.Not.Null.And.Not.Empty);
            Assert.That(result.DetectedLanguage.Value.Iso6391Name, Is.Not.Null.And.Not.Empty);
            Assert.GreaterOrEqual(result.DetectedLanguage.Value.ConfidenceScore, 0.0);
            Assert.LessOrEqual(result.DetectedLanguage.Value.ConfidenceScore, 1.0);
            Assert.IsNotNull(result.DetectedLanguage.Value.Warnings);
            Assert.IsEmpty(result.DetectedLanguage.Value.Warnings);
        }

        private void CheckAnalyzeSentimentProperties(DocumentSentiment doc, bool opinionMining = default)
        {
            Assert.IsNotNull(doc.ConfidenceScores.Positive);
            Assert.IsNotNull(doc.ConfidenceScores.Neutral);
            Assert.IsNotNull(doc.ConfidenceScores.Negative);
            // TODO enable again. Issue tracking work: https://github.com/Azure/azure-sdk-for-net/issues/28246
            // Assert.IsTrue(CheckTotalConfidenceScoreValue(doc.ConfidenceScores));

            foreach (var sentence in doc.Sentences)
            {
                Assert.IsNotNull(sentence.Text);
                Assert.IsNotNull(sentence.ConfidenceScores.Positive);
                Assert.IsNotNull(sentence.ConfidenceScores.Neutral);
                Assert.IsNotNull(sentence.ConfidenceScores.Negative);
                // TODO enable again. Issue tracking work: https://github.com/Azure/azure-sdk-for-net/issues/28246
                // Assert.IsTrue(CheckTotalConfidenceScoreValue(sentence.ConfidenceScores));

                Assert.IsNotNull(sentence.Opinions);
                if (opinionMining)
                {
                    Assert.Greater(sentence.Opinions.Count(), 0);
                    foreach (var opinions in sentence.Opinions)
                    {
                        // target
                        Assert.IsNotNull(opinions.Target);
                        Assert.IsNotNull(opinions.Target.Text);
                        Assert.IsNotNull(opinions.Target.ConfidenceScores.Positive);
                        Assert.IsNotNull(opinions.Target.ConfidenceScores.Negative);
                        // Neutral should always be 0
                        Assert.AreEqual(0, opinions.Target.ConfidenceScores.Neutral);
                        Assert.IsTrue(CheckTotalConfidenceScoreValue(opinions.Target.ConfidenceScores));
                        Assert.IsNotNull(opinions.Target.Offset);
                        Assert.IsNotNull(opinions.Target.Length);

                        // assessment
                        Assert.IsNotNull(opinions.Assessments);
                        Assert.Greater(opinions.Assessments.Count(), 0);
                        foreach (var opinion in opinions.Assessments)
                        {
                            Assert.IsNotNull(opinion.Text);
                            Assert.IsNotNull(opinion.ConfidenceScores.Positive);
                            Assert.IsNotNull(opinion.ConfidenceScores.Negative);
                            // Neutral should always be 0
                            Assert.AreEqual(0, opinion.ConfidenceScores.Neutral);
                            Assert.IsTrue(CheckTotalConfidenceScoreValue(opinion.ConfidenceScores));
                            Assert.IsNotNull(opinion.IsNegated);
                            Assert.IsNotNull(opinion.Offset);
                            Assert.IsNotNull(opinion.Length);
                        }
                    }
                }
            }
        }

        private bool CheckTotalConfidenceScoreValue(SentimentConfidenceScores scores)
        {
            return scores.Positive + scores.Neutral + scores.Negative == 1d;
        }
    }
}
