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
            Assert.Multiple(() =>
            {
                Assert.That(docSentiment.Sentiment.ToString(), Is.EqualTo("Positive"));
                Assert.That(docSentiment.Sentences.FirstOrDefault().Sentiment.ToString(), Is.EqualTo("Positive"));
            });
        }

        [RecordedTest]
        public async Task AnalyzeSentimentTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = singleEnglish;

            DocumentSentiment docSentiment = await client.AnalyzeSentimentAsync(document);

            CheckAnalyzeSentimentProperties(docSentiment);
            Assert.Multiple(() =>
            {
                Assert.That(docSentiment.Sentiment.ToString(), Is.EqualTo("Positive"));
                Assert.That(docSentiment.Sentences.FirstOrDefault().Sentiment.ToString(), Is.EqualTo("Positive"));
            });
        }

        [RecordedTest]
        public async Task AnalyzeSentimentWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = singleSpanish;

            DocumentSentiment docSentiment = await client.AnalyzeSentimentAsync(document, "es");

            CheckAnalyzeSentimentProperties(docSentiment);
            Assert.That(docSentiment.Sentiment.ToString(), Is.EqualTo("Positive"));
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V3_1)]
        public async Task AnalyzeSentimentWithOpinionMining()
        {
            TextAnalyticsClient client = GetClient();
            string document = "The park was clean and pretty. The bathrooms and restaurant were not clean.";

            DocumentSentiment docSentiment = await client.AnalyzeSentimentAsync(document, options: new AnalyzeSentimentOptions() { IncludeOpinionMining = true });

            CheckAnalyzeSentimentProperties(docSentiment, opinionMining: true);
            Assert.That(docSentiment.Sentiment.ToString(), Is.EqualTo("Mixed"));
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V3_1)]
        public async Task AnalyzeSentimentWithOpinionMiningEmpty()
        {
            TextAnalyticsClient client = GetClient();
            string document = singleEnglish;

            DocumentSentiment docSentiment = await client.AnalyzeSentimentAsync(document, "en", new AnalyzeSentimentOptions() { IncludeOpinionMining = true });

            CheckAnalyzeSentimentProperties(docSentiment);
            Assert.That(docSentiment.Sentiment.ToString(), Is.EqualTo("Positive"));
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
            Assert.Multiple(() =>
            {
                Assert.That(opinion.Target.Text, Is.EqualTo("bathrooms"));
                Assert.That(opinion.Target.Sentiment, Is.EqualTo(TextSentiment.Negative));
                Assert.That(opinion.Assessments.FirstOrDefault().Text, Is.EqualTo("clean"));
                Assert.That(opinion.Assessments.FirstOrDefault().Sentiment, Is.EqualTo(TextSentiment.Negative));
                Assert.That(opinion.Assessments.FirstOrDefault().IsNegated, Is.True);
            });
        }

        [RecordedTest]
        public async Task AnalyzeSentimentWithCancellationTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = singleSpanish;

            DocumentSentiment docSentiment = await client.AnalyzeSentimentAsync(document, cancellationToken: default);

            CheckAnalyzeSentimentProperties(docSentiment);
            Assert.That(docSentiment.Sentiment.ToString(), Is.EqualTo("Positive"));
        }

        [RecordedTest]
        public async Task AnalyzeSentimentWithLanguageAndCancellationTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = singleSpanish;

            DocumentSentiment docSentiment = await client.AnalyzeSentimentAsync(document, "es", default);

            CheckAnalyzeSentimentProperties(docSentiment);
            Assert.That(docSentiment.Sentiment.ToString(), Is.EqualTo("Positive"));
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

            Assert.Multiple(() =>
            {
                Assert.That(results[0].DocumentSentiment.Sentiment.ToString(), Is.EqualTo("Positive"));
                Assert.That(results[1].DocumentSentiment.Sentiment.ToString(), Is.EqualTo("Negative"));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(results[0].DocumentSentiment.Sentiment.ToString(), Is.EqualTo("Mixed"));
                Assert.That(results[1].DocumentSentiment.Sentiment.ToString(), Is.EqualTo("Negative"));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(results[0].DocumentSentiment.Sentiment.ToString(), Is.EqualTo("Positive"));
                Assert.That(results[1].DocumentSentiment.Sentiment.ToString(), Is.EqualTo("Negative"));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(results[0].DocumentSentiment.Sentiment.ToString(), Is.EqualTo("Positive"));
                Assert.That(results[1].DocumentSentiment.Sentiment.ToString(), Is.EqualTo("Negative"));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(results[0].DocumentSentiment.Sentiment.ToString(), Is.EqualTo("Positive"));
                Assert.That(results[1].DocumentSentiment.Sentiment.ToString(), Is.EqualTo("Negative"));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(results[0].DocumentSentiment.Sentiment.ToString(), Is.EqualTo("Positive"));
                Assert.That(results[1].DocumentSentiment.Sentiment.ToString(), Is.EqualTo("Negative"));

                Assert.That(results.Statistics.ValidDocumentCount, Is.Not.Null);
                Assert.That(results.Statistics.DocumentCount, Is.Not.Null);
                Assert.That(results.Statistics.TransactionCount, Is.Not.Null);
                Assert.That(results.Statistics.InvalidDocumentCount, Is.Not.Null);
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(results[0].DocumentSentiment.Sentiment.ToString(), Is.EqualTo("Positive"));
                Assert.That(results[1].DocumentSentiment.Sentiment.ToString(), Is.EqualTo("Negative"));

                Assert.That(results.Statistics.ValidDocumentCount, Is.Not.Null);
                Assert.That(results.Statistics.DocumentCount, Is.Not.Null);
                Assert.That(results.Statistics.TransactionCount, Is.Not.Null);
                Assert.That(results.Statistics.InvalidDocumentCount, Is.Not.Null);
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(results[0].DocumentSentiment.Sentiment.ToString(), Is.EqualTo("Positive"));
                Assert.That(results[1].DocumentSentiment.Sentiment.ToString(), Is.EqualTo("Negative"));

                Assert.That(results.Statistics.ValidDocumentCount, Is.Not.Null);
                Assert.That(results.Statistics.DocumentCount, Is.Not.Null);
                Assert.That(results.Statistics.TransactionCount, Is.Not.Null);
                Assert.That(results.Statistics.InvalidDocumentCount, Is.Not.Null);
            });
        }

        [RecordedTest]
        public async Task AnalyzeSentimentBatchConvenienceFullTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = batchConvenienceDocuments;

            AnalyzeSentimentResultCollection results = await client.AnalyzeSentimentBatchAsync(documents, "en", new TextAnalyticsRequestOptions { IncludeStatistics = true }, default);

            foreach (AnalyzeSentimentResult result in results)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(result.Id, Is.Not.Null.And.Not.Empty);
                    Assert.That(result.HasError, Is.False);
                });
                CheckAnalyzeSentimentProperties(result.DocumentSentiment);
            }

            Assert.Multiple(() =>
            {
                Assert.That(results[0].DocumentSentiment.Sentiment.ToString(), Is.EqualTo("Positive"));
                Assert.That(results[1].DocumentSentiment.Sentiment.ToString(), Is.EqualTo("Negative"));

                Assert.That(results.Statistics.ValidDocumentCount, Is.Not.Null);
                Assert.That(results.Statistics.DocumentCount, Is.Not.Null);
                Assert.That(results.Statistics.TransactionCount, Is.Not.Null);
                Assert.That(results.Statistics.InvalidDocumentCount, Is.Not.Null);
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(results[0].DocumentSentiment.Sentiment.ToString(), Is.EqualTo("Positive"));
                Assert.That(results[1].DocumentSentiment.Sentiment.ToString(), Is.EqualTo("Negative"));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(results[0].DocumentSentiment.Sentiment.ToString(), Is.EqualTo("Mixed"));
                Assert.That(results[1].DocumentSentiment.Sentiment.ToString(), Is.EqualTo("Negative"));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(results[0].DocumentSentiment.Sentiment.ToString(), Is.EqualTo("Positive"));
                Assert.That(results[1].DocumentSentiment.Sentiment.ToString(), Is.EqualTo("Negative"));

                Assert.That(results.Statistics.ValidDocumentCount, Is.Not.Null);
                Assert.That(results.Statistics.DocumentCount, Is.Not.Null);
                Assert.That(results.Statistics.TransactionCount, Is.Not.Null);
                Assert.That(results.Statistics.InvalidDocumentCount, Is.Not.Null);
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(!results[0].HasError, Is.True);
                Assert.That(!results[2].HasError, Is.True);
            });

            var exceptionMessage = "Cannot access result for document 1, due to error InvalidDocument: Document text is empty.";
            Assert.That(results[1].HasError, Is.True);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => results[1].DocumentSentiment.GetType());
            Assert.That(ex.Message, Is.EqualTo(exceptionMessage));
        }

        [RecordedTest]
        public void AnalyzeSentimentBatchWithNullIdTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<TextDocumentInput> { new TextDocumentInput(null, "Hello world") };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.AnalyzeSentimentBatchAsync(documents));
            Assert.That(ex.ErrorCode, Is.EqualTo(TextAnalyticsErrorCode.InvalidDocument));
        }

        [RecordedTest]
        public async Task AnalyzeSentimentBatchWithNullTextTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<TextDocumentInput> { new TextDocumentInput("1", null) };

            AnalyzeSentimentResultCollection results = await client.AnalyzeSentimentBatchAsync(documents);
            var exceptionMessage = "Cannot access result for document 1, due to error InvalidDocument: Document text is empty.";
            Assert.That(results[0].HasError, Is.True);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => results[0].DocumentSentiment.GetType());
            Assert.That(ex.Message, Is.EqualTo(exceptionMessage));
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

            Assert.That(AnalyzeSentimentActionsResults, Is.Not.Null);

            IList<string> expected = new List<string> { "AnalyzeSentiment", "AnalyzeSentimentWithDisabledServiceLogs" };
            Assert.That(AnalyzeSentimentActionsResults.Select(result => result.ActionName), Is.EquivalentTo(expected));
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

            Assert.Multiple(() =>
            {
                Assert.That(results[0].DocumentSentiment.Sentiment.ToString(), Is.EqualTo("Positive"));
                Assert.That(results[1].DocumentSentiment.Sentiment.ToString(), Is.EqualTo("Negative"));
            });
        }

        [RecordedTest]
        [ServiceVersion(Max = TextAnalyticsClientOptions.ServiceVersion.V3_0)]
        public void AnalyzeSentimentBatchDisableServiceLogsThrows()
        {
            TestDiagnostics = false;

            TextAnalyticsClient client = GetClient();
            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(async () => await client.AnalyzeSentimentBatchAsync(batchConvenienceDocuments, "en", options: new TextAnalyticsRequestOptions { DisableServiceLogs = true }));
            Assert.That(ex.Message, Is.EqualTo("AnalyzeSentimentOptions.DisableServiceLogs is not available in API version v3.0. Use service API version v3.1 or newer."));
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

            Assert.Multiple(() =>
            {
                Assert.That(results[0].DocumentSentiment.Sentiment.ToString(), Is.EqualTo("Positive"));
                Assert.That(results[1].DocumentSentiment.Sentiment.ToString(), Is.EqualTo("Negative"));
            });
        }

        [RecordedTest]
        [ServiceVersion(Max = TextAnalyticsClientOptions.ServiceVersion.V3_0)]
        public void AnalyzeSentimentBatchIncludeOpinionMiningThrows()
        {
            TestDiagnostics = false;

            TextAnalyticsClient client = GetClient();
            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(async () => await client.AnalyzeSentimentBatchAsync(batchConvenienceDocuments, "en", options: new AnalyzeSentimentOptions { IncludeOpinionMining = true }));
            Assert.That(ex.Message, Is.EqualTo("AnalyzeSentimentOptions.IncludeOpinionMining is not available in API version v3.0. Use service API version v3.1 or newer."));
        }

        private void CheckAnalyzeSentimentProperties(DocumentSentiment doc, bool opinionMining = default)
        {
            Assert.Multiple(() =>
            {
                Assert.That(doc.ConfidenceScores.Positive, Is.Not.Null);
                Assert.That(doc.ConfidenceScores.Neutral, Is.Not.Null);
                Assert.That(doc.ConfidenceScores.Negative, Is.Not.Null);
            });
            // TODO enable again. Issue tracking work: https://github.com/Azure/azure-sdk-for-net/issues/28246
            // Assert.IsTrue(CheckTotalConfidenceScoreValue(doc.ConfidenceScores));

            foreach (var sentence in doc.Sentences)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(sentence.Text, Is.Not.Null);
                    Assert.That(sentence.ConfidenceScores.Positive, Is.Not.Null);
                    Assert.That(sentence.ConfidenceScores.Neutral, Is.Not.Null);
                    Assert.That(sentence.ConfidenceScores.Negative, Is.Not.Null);
                    // TODO enable again. Issue tracking work: https://github.com/Azure/azure-sdk-for-net/issues/28246
                    // Assert.IsTrue(CheckTotalConfidenceScoreValue(sentence.ConfidenceScores));

                    Assert.That(sentence.Opinions, Is.Not.Null);
                });
                if (opinionMining)
                {
                    Assert.That(sentence.Opinions.Count(), Is.GreaterThan(0));
                    foreach (var opinions in sentence.Opinions)
                    {
                        // target
                        Assert.That(opinions.Target, Is.Not.Null);
                        Assert.Multiple(() =>
                        {
                            Assert.That(opinions.Target.Text, Is.Not.Null);
                            Assert.That(opinions.Target.ConfidenceScores.Positive, Is.Not.Null);
                            Assert.That(opinions.Target.ConfidenceScores.Negative, Is.Not.Null);
                            // Neutral should always be 0
                            Assert.That(opinions.Target.ConfidenceScores.Neutral, Is.EqualTo(0));
                            Assert.That(CheckTotalConfidenceScoreValue(opinions.Target.ConfidenceScores), Is.True);
                            Assert.That(opinions.Target.Offset, Is.Not.Null);
                            Assert.That(opinions.Target.Length, Is.Not.Null);

                            // assessment
                            Assert.That(opinions.Assessments, Is.Not.Null);
                        });
                        Assert.That(opinions.Assessments.Count(), Is.GreaterThan(0));
                        foreach (var opinion in opinions.Assessments)
                        {
                            Assert.Multiple(() =>
                            {
                                Assert.That(opinion.Text, Is.Not.Null);
                                Assert.That(opinion.ConfidenceScores.Positive, Is.Not.Null);
                                Assert.That(opinion.ConfidenceScores.Negative, Is.Not.Null);
                                // Neutral should always be 0
                                Assert.That(opinion.ConfidenceScores.Neutral, Is.EqualTo(0));
                                Assert.That(CheckTotalConfidenceScoreValue(opinion.ConfidenceScores), Is.True);
                                Assert.That(opinion.IsNegated, Is.Not.Null);
                                Assert.That(opinion.Offset, Is.Not.Null);
                                Assert.That(opinion.Length, Is.Not.Null);
                            });
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
