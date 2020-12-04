// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests
{
    public class AnalyzeSentimentTests : TextAnalyticsClientLiveTestBase
    {
        public AnalyzeSentimentTests(bool isAsync) : base(isAsync) { }

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

        [Test]
        public async Task AnalyzeSentimentWithAADTest()
        {
            TextAnalyticsClient client = GetClient(useTokenCredential: true);
            string document = singleEnglish;

            DocumentSentiment docSentiment = await client.AnalyzeSentimentAsync(document);

            CheckAnalyzeSentimentProperties(docSentiment);
            Assert.AreEqual("Positive", docSentiment.Sentiment.ToString());
            Assert.AreEqual("Positive", docSentiment.Sentences.FirstOrDefault().Sentiment.ToString());
        }

        [Test]
        public async Task AnalyzeSentimentTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = singleEnglish;

            DocumentSentiment docSentiment = await client.AnalyzeSentimentAsync(document);

            CheckAnalyzeSentimentProperties(docSentiment);
            Assert.AreEqual("Positive", docSentiment.Sentiment.ToString());
            Assert.AreEqual("Positive", docSentiment.Sentences.FirstOrDefault().Sentiment.ToString());
        }

        [Test]
        public async Task AnalyzeSentimentWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = singleSpanish;

            DocumentSentiment docSentiment = await client.AnalyzeSentimentAsync(document, "es");

            CheckAnalyzeSentimentProperties(docSentiment);
            Assert.AreEqual("Positive", docSentiment.Sentiment.ToString());
        }

        [Test]
        public async Task AnalyzeSentimentWithOpinionMining()
        {
            TextAnalyticsClient client = GetClient();
            string document = "The park was clean and pretty. The bathrooms and restaurant were not clean.";

            DocumentSentiment docSentiment = await client.AnalyzeSentimentAsync(document, options: new AnalyzeSentimentOptions() { IncludeOpinionMining = true });

            CheckAnalyzeSentimentProperties(docSentiment, opinionMining: true);
            Assert.AreEqual("Mixed", docSentiment.Sentiment.ToString());
        }

        [Test]
        public async Task AnalyzeSentimentWithOpinionMiningEmpty()
        {
            TextAnalyticsClient client = GetClient();
            string document = singleEnglish;

            DocumentSentiment docSentiment = await client.AnalyzeSentimentAsync(document, "en", new AnalyzeSentimentOptions() { IncludeOpinionMining = true });

            CheckAnalyzeSentimentProperties(docSentiment);
            Assert.AreEqual("Positive", docSentiment.Sentiment.ToString());
        }

        [Test]
        public async Task AnalyzeSentimentWithOpinionMiningNegated()
        {
            TextAnalyticsClient client = GetClient();
            string document = "The bathrooms are not clean.";

            DocumentSentiment docSentiment = await client.AnalyzeSentimentAsync(document, options: new AnalyzeSentimentOptions() { IncludeOpinionMining = true });

            CheckAnalyzeSentimentProperties(docSentiment, opinionMining: true);
            MinedOpinion minedOpinion = docSentiment.Sentences.FirstOrDefault().MinedOpinions.FirstOrDefault();
            Assert.AreEqual("bathrooms", minedOpinion.Aspect.Text);
            Assert.AreEqual(TextSentiment.Negative, minedOpinion.Aspect.Sentiment);
            Assert.AreEqual("clean", minedOpinion.Opinions.FirstOrDefault().Text);
            Assert.AreEqual(TextSentiment.Negative, minedOpinion.Opinions.FirstOrDefault().Sentiment);
            Assert.IsTrue(minedOpinion.Opinions.FirstOrDefault().IsNegated);
        }

        [Test]
        public async Task AnalyzeSentimentWithCancellationTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = singleSpanish;

            DocumentSentiment docSentiment = await client.AnalyzeSentimentAsync(document, cancellationToken: default);

            CheckAnalyzeSentimentProperties(docSentiment);
            Assert.AreEqual("Positive", docSentiment.Sentiment.ToString());
        }

        [Test]
        public async Task AnalyzeSentimentWithLanguageAndCancellationTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = singleSpanish;

            DocumentSentiment docSentiment = await client.AnalyzeSentimentAsync(document, "es", default);

            CheckAnalyzeSentimentProperties(docSentiment);
            Assert.AreEqual("Positive", docSentiment.Sentiment.ToString());
        }

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
        public async Task AnalyzeSentimentBatchConvenienceFullTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = batchConvenienceDocuments;

            AnalyzeSentimentResultCollection results = await client.AnalyzeSentimentBatchAsync(documents, "en", new TextAnalyticsRequestOptions { IncludeStatistics = true }, default);

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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
        public void AnalyzeSentimentBatchWithNullIdTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<TextDocumentInput> { new TextDocumentInput(null, "Hello world") };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.AnalyzeSentimentBatchAsync(documents));
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocument, ex.ErrorCode);
        }

        [Test]
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

        private void CheckAnalyzeSentimentProperties(DocumentSentiment doc, bool opinionMining = false)
        {
            Assert.IsNotNull(doc.ConfidenceScores.Positive);
            Assert.IsNotNull(doc.ConfidenceScores.Neutral);
            Assert.IsNotNull(doc.ConfidenceScores.Negative);
            Assert.IsTrue(CheckTotalConfidenceScoreValue(doc.ConfidenceScores));

            foreach (var sentence in doc.Sentences)
            {
                Assert.IsNotNull(sentence.Text);
                Assert.IsNotNull(sentence.ConfidenceScores.Positive);
                Assert.IsNotNull(sentence.ConfidenceScores.Neutral);
                Assert.IsNotNull(sentence.ConfidenceScores.Negative);
                Assert.IsTrue(CheckTotalConfidenceScoreValue(sentence.ConfidenceScores));

                Assert.IsNotNull(sentence.MinedOpinions);
                if (opinionMining)
                {
                    Assert.Greater(sentence.MinedOpinions.Count(), 0);
                    foreach (var minedOpinions in sentence.MinedOpinions)
                    {
                        // Aspect
                        Assert.IsNotNull(minedOpinions.Aspect);
                        Assert.IsNotNull(minedOpinions.Aspect.Text);
                        Assert.IsNotNull(minedOpinions.Aspect.ConfidenceScores.Positive);
                        Assert.IsNotNull(minedOpinions.Aspect.ConfidenceScores.Negative);
                        // Neutral should always be 0
                        Assert.AreEqual(0, minedOpinions.Aspect.ConfidenceScores.Neutral);
                        Assert.IsTrue(CheckTotalConfidenceScoreValue(minedOpinions.Aspect.ConfidenceScores));
                        Assert.IsNotNull(minedOpinions.Aspect.Offset);

                        // Opinions
                        Assert.IsNotNull(minedOpinions.Opinions);
                        Assert.Greater(minedOpinions.Opinions.Count(), 0);
                        foreach (var opinion in minedOpinions.Opinions)
                        {
                            Assert.IsNotNull(opinion.Text);
                            Assert.IsNotNull(opinion.ConfidenceScores.Positive);
                            Assert.IsNotNull(opinion.ConfidenceScores.Negative);
                            // Neutral should always be 0
                            Assert.AreEqual(0, opinion.ConfidenceScores.Neutral);
                            Assert.IsTrue(CheckTotalConfidenceScoreValue(opinion.ConfidenceScores));
                            Assert.IsNotNull(opinion.IsNegated);
                            Assert.IsNotNull(opinion.Offset);
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
