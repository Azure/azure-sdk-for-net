// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    public class SampleMoq
    {
        [Test]
        public async Task DetectLanguageAsync()
        {
            #region Snippet:CreateMocks
            Mock<Response> mockResponse = new();
            Mock<TextAnalyticsClient> mockClient = new();
            #endregion

            #region Snippet:SetupMocks
            Response<DetectedLanguage> response = Response.FromValue(TextAnalyticsModelFactory.DetectedLanguage("Spanish", "es", 1.00), mockResponse.Object);

            mockClient.Setup(c => c.DetectLanguageAsync("Este documento está en español.", It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(response));
            #endregion

            #region Snippet:UseMocks
            TextAnalyticsClient client = mockClient.Object;
            bool result = await IsSpanishAsync("Este documento está en español.", client, default);
            Assert.IsTrue(result);
            #endregion
        }

        #region Snippet:MethodToTest
        private static async Task<bool> IsSpanishAsync(string document, TextAnalyticsClient client, CancellationToken cancellationToken)
        {
            DetectedLanguage language = await client.DetectLanguageAsync(document, default, cancellationToken);
            return language.Iso6391Name == "es";
        }
        #endregion Snippet:MethodToTest

        [Test]
        public async Task DetectLanguageBatchAsync()
        {
            Mock<Response> mockResponse = new();
            Mock<TextAnalyticsClient> mockClient = new();
            List<string> documents = new()
            {
                "Hello world",
                "Bonjour tout le monde",
            };

            List<DetectLanguageResult> languages = new()
            {
                TextAnalyticsModelFactory.DetectLanguageResult("0", default, TextAnalyticsModelFactory.DetectedLanguage("English", "en", 1.00)),
                TextAnalyticsModelFactory.DetectLanguageResult("1", default, TextAnalyticsModelFactory.DetectedLanguage("French", "fr", 1.00)),
            };

            Response<DetectLanguageResultCollection> response = Response.FromValue(TextAnalyticsModelFactory.DetectLanguageResultCollection(languages, default, default), mockResponse.Object);

            mockClient.Setup(c => c.DetectLanguageBatchAsync(documents, It.IsAny<string>(), It.IsAny<TextAnalyticsRequestOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(response));

            TextAnalyticsClient client = mockClient.Object;
            DetectLanguageResultCollection results = await client.DetectLanguageBatchAsync(documents);

            int i = 0;
            foreach (DetectLanguageResult result in results)
            {
                Assert.AreEqual(languages[i].Id, results[i].Id);
                Assert.AreEqual(languages[i].PrimaryLanguage.Name, results[i].PrimaryLanguage.Name);
                Assert.AreEqual(languages[i].PrimaryLanguage.Iso6391Name, results[i].PrimaryLanguage.Iso6391Name);
                Assert.AreEqual(languages[i].PrimaryLanguage.ConfidenceScore, results[i].PrimaryLanguage.ConfidenceScore);
                i++;
            }
        }

        [Test]
        public async Task DetectLanguageBatchWithStatisticsAsync()
        {
            Mock<Response> mockResponse = new();
            Mock<TextAnalyticsClient> mockClient = new();
            List<string> documents = new()
            {
                "Hello world",
                "Bonjour tout le monde",
            };

            TextDocumentStatistics language1Stats = TextAnalyticsModelFactory.TextDocumentStatistics(11, 1);
            TextDocumentStatistics language2Stats = TextAnalyticsModelFactory.TextDocumentStatistics(21, 1);

            List<DetectLanguageResult> languages = new()
            {
                TextAnalyticsModelFactory.DetectLanguageResult("0", language1Stats, default),
                TextAnalyticsModelFactory.DetectLanguageResult("1", language2Stats, default),
            };

            TextDocumentBatchStatistics docStats = TextAnalyticsModelFactory.TextDocumentBatchStatistics(2, 2, 0, 2);

            Response<DetectLanguageResultCollection> response = Response.FromValue(TextAnalyticsModelFactory.DetectLanguageResultCollection(languages, docStats, default), mockResponse.Object);

            mockClient.Setup(c => c.DetectLanguageBatchAsync(documents, It.IsAny<string>(), It.IsAny<TextAnalyticsRequestOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(response));

            TextAnalyticsClient client = mockClient.Object;
            DetectLanguageResultCollection results = await client.DetectLanguageBatchAsync(documents);

            //language1
            Assert.AreEqual(languages[0].Id, results[0].Id);
            Assert.AreEqual(languages[0].Statistics.CharacterCount, results[0].Statistics.CharacterCount);
            Assert.AreEqual(languages[0].Statistics.TransactionCount, results[0].Statistics.TransactionCount);

            //language2
            Assert.AreEqual(languages[1].Id, results[1].Id);
            Assert.AreEqual(languages[1].Statistics.CharacterCount, results[1].Statistics.CharacterCount);
            Assert.AreEqual(languages[1].Statistics.TransactionCount, results[1].Statistics.TransactionCount);

            //Transaction Stats
            Assert.AreEqual(docStats.DocumentCount, results.Statistics.DocumentCount);
            Assert.AreEqual(docStats.ValidDocumentCount, results.Statistics.ValidDocumentCount);
            Assert.AreEqual(docStats.InvalidDocumentCount, results.Statistics.InvalidDocumentCount);
            Assert.AreEqual(docStats.TransactionCount, results.Statistics.TransactionCount);
        }

        [Test]
        public async Task DetectLanguageBatchWithErrorAsync()
        {
            Mock<Response> mockResponse = new();
            Mock<TextAnalyticsClient> mockClient = new();
            List<string> documents = new()
            {
                "Hello world",
                "",
            };

            TextAnalyticsError error = TextAnalyticsModelFactory.TextAnalyticsError("InvalidDocument", "Document text is empty.");

            List<DetectLanguageResult> languages = new()
            {
                TextAnalyticsModelFactory.DetectLanguageResult("0", default, TextAnalyticsModelFactory.DetectedLanguage("English", "en", 1.00)),
                TextAnalyticsModelFactory.DetectLanguageResult("1", error),
            };

            Response<DetectLanguageResultCollection> response = Response.FromValue(TextAnalyticsModelFactory.DetectLanguageResultCollection(languages, default, default), mockResponse.Object);

            mockClient.Setup(c => c.DetectLanguageBatchAsync(documents, It.IsAny<string>(), It.IsAny<TextAnalyticsRequestOptions>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(response));

            TextAnalyticsClient client = mockClient.Object;
            DetectLanguageResultCollection results = await client.DetectLanguageBatchAsync(documents);

            Assert.AreEqual(languages[1].Id, results[1].Id);
            Assert.IsTrue(results[1].HasError);
        }
    }
}
