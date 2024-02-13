// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests
{
    public class DetectLanguageTests : TextAnalyticsClientLiveTestBase
    {
        /// <summary>
        /// The version of the REST API to test against.  This will be passed
        /// to the .ctor via ClientTestFixture's values.
        /// </summary>
        private readonly TextAnalyticsClientOptions.ServiceVersion _serviceVersion;

        public DetectLanguageTests(bool isAsync, TextAnalyticsClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
            _serviceVersion = serviceVersion;
        }

        private const string SingleEnglish = "This is written in English.";
        private const string SingleSpanish = "Este documento está en español";

        private static List<string> batchConvenienceDocuments = new List<string>
        {
            "Hello world",
            "Bonjour tout le monde",
            "Hola mundo"
        };

        private static List<DetectLanguageInput> batchDocuments = new List<DetectLanguageInput>
        {
            new DetectLanguageInput("1", "Hello world")
            {
                CountryHint = "us",
            },
            new DetectLanguageInput("2", "Bonjour tout le monde")
            {
               CountryHint = "fr",
            },
            new DetectLanguageInput("3", "Hola mundo")
            {
                CountryHint = "es",
            },
            new DetectLanguageInput("4", ":) :( :D")
            {
               CountryHint = "us",
            }
        };

        [RecordedTest]
        public async Task DetectLanguageWithAADTest()
        {
            TextAnalyticsClient client = GetClient(useTokenCredential: true);
            string document = SingleEnglish;

            DetectedLanguage language = await client.DetectLanguageAsync(document);

            ValidateInDocumenResult(language);
        }

        [RecordedTest]
        public async Task DetectLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = SingleEnglish;

            DetectedLanguage language = await client.DetectLanguageAsync(document);

            ValidateInDocumenResult(language);
        }

        [RecordedTest]
        public async Task DetectLanguageWithCountryHintTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = SingleSpanish;

            DetectedLanguage language = await client.DetectLanguageAsync(document, "CO");

            ValidateInDocumenResult(language);
        }

        [RecordedTest]
        public void DetectLanguageWithErrorCountryHintTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = SingleSpanish;

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(() => client.DetectLanguageAsync(document, "COLOMBIA"));
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidCountryHint, ex.ErrorCode);
        }

        [RecordedTest]
        public async Task DetectLanguageWithNoneCountryHintTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = SingleSpanish;

            DetectedLanguage language = await client.DetectLanguageAsync(document, DetectLanguageInput.None);

            ValidateInDocumenResult(language);
        }

        [RecordedTest]
        public async Task DetectLanguageWithNoneDefaultCountryHintTest()
        {
            var options = new TextAnalyticsClientOptions(_serviceVersion)
            {
                DefaultCountryHint = DetectLanguageInput.None
            };

            TextAnalyticsClient client = GetClient(options: options);
            string document = SingleSpanish;

            DetectedLanguage language = await client.DetectLanguageAsync(document, DetectLanguageInput.None);

            ValidateInDocumenResult(language);
        }

        [RecordedTest]
        public async Task DetectLanguageBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();
            List<string> documents = batchConvenienceDocuments;

            DetectLanguageResultCollection results = await client.DetectLanguageBatchAsync(documents, options: new TextAnalyticsRequestOptions() { ModelVersion = "2019-10-01" });

            ValidateBatchDocumentsResult(results);

            Assert.AreEqual("English", results[0].PrimaryLanguage.Name);
            Assert.AreEqual("French", results[1].PrimaryLanguage.Name);
            Assert.AreEqual("Spanish", results[2].PrimaryLanguage.Name);
        }

        [RecordedTest]
        public async Task DetectLanguageBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            List<string> documents = batchConvenienceDocuments;

            var options = new TextAnalyticsRequestOptions()
            {
                IncludeStatistics = true,
                ModelVersion = "2019-10-01"
            };

            DetectLanguageResultCollection results = await client.DetectLanguageBatchAsync(documents, "us", options);

            ValidateBatchDocumentsResult(results, includeStatistics: true);

            Assert.AreEqual("English", results[0].PrimaryLanguage.Name);
            Assert.AreEqual("French", results[1].PrimaryLanguage.Name);
            Assert.AreEqual("Spanish", results[2].PrimaryLanguage.Name);
        }

        [RecordedTest]
        public async Task DetectLanguageBatchTest()
        {
            TextAnalyticsClient client = GetClient();
            List<DetectLanguageInput> documents = batchDocuments;

            DetectLanguageResultCollection results = await client.DetectLanguageBatchAsync(documents, options: new TextAnalyticsRequestOptions() { ModelVersion = "2019-10-01" });

            ValidateBatchDocumentsResult(results);

            Assert.AreEqual("English", results[0].PrimaryLanguage.Name);
            Assert.AreEqual("French", results[1].PrimaryLanguage.Name);
            Assert.AreEqual("Spanish", results[2].PrimaryLanguage.Name);
            Assert.AreEqual("(Unknown)", results[3].PrimaryLanguage.Name);
        }

        [RecordedTest]
        public async Task DetectLanguageBatchWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            List<DetectLanguageInput> documents = batchDocuments;

            var options = new TextAnalyticsRequestOptions()
            {
                IncludeStatistics = true,
                ModelVersion = "2019-10-01"
            };

            DetectLanguageResultCollection results = await client.DetectLanguageBatchAsync(documents, options: options);

            ValidateBatchDocumentsResult(results, includeStatistics: true);

            Assert.AreEqual("English", results[0].PrimaryLanguage.Name);
            Assert.AreEqual("French", results[1].PrimaryLanguage.Name);
            Assert.AreEqual("Spanish", results[2].PrimaryLanguage.Name);
            Assert.AreEqual("(Unknown)", results[3].PrimaryLanguage.Name);
        }

        [RecordedTest]
        public async Task DetectLanguageBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<string>
            {
                "Hello world",
                "",
                "Hola mundo"
            };

            DetectLanguageResultCollection results = await client.DetectLanguageBatchAsync(documents);

            Assert.IsTrue(!results[0].HasError);
            Assert.IsTrue(!results[2].HasError);

            var exceptionMessage = "Cannot access result for document 1, due to error InvalidDocument: Document text is empty.";
            Assert.IsTrue(results[1].HasError);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => results[1].PrimaryLanguage.GetType());
            Assert.AreEqual(exceptionMessage, ex.Message);
        }

        [RecordedTest]
        public void DetectLanguageBatchWithNullIdTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<DetectLanguageInput> { new DetectLanguageInput(null, "Hello world") };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await client.DetectLanguageBatchAsync(documents, options: new TextAnalyticsRequestOptions() { ModelVersion = "2019-10-01" }));
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocument, ex.ErrorCode);
        }

        [RecordedTest]
        public async Task DetectLanguageBatchWithNullTextTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<DetectLanguageInput> { new DetectLanguageInput("1", null) };

            DetectLanguageResultCollection results = await client.DetectLanguageBatchAsync(documents, options: new TextAnalyticsRequestOptions() { ModelVersion = "2019-10-01" });

            var exceptionMessage = "Cannot access result for document 1, due to error InvalidDocument: Document text is empty.";
            Assert.IsTrue(results[0].HasError);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => results[0].PrimaryLanguage.GetType());
            Assert.AreEqual(exceptionMessage, ex.Message);
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V3_1)]
        public async Task DetectLanguageBatchDisableServiceLogs()
        {
            TextAnalyticsClient client = GetClient();
            DetectLanguageResultCollection results = await client.DetectLanguageBatchAsync(batchConvenienceDocuments, options: new TextAnalyticsRequestOptions { DisableServiceLogs = true });

            ValidateBatchDocumentsResult(results);
            Assert.AreEqual("English", results[0].PrimaryLanguage.Name);
        }

        [RecordedTest]
        [ServiceVersion(Max = TextAnalyticsClientOptions.ServiceVersion.V3_0)]
        public void DetectLanguageBatchDisableServiceLogsThrows()
        {
            TestDiagnostics = false;

            TextAnalyticsClient client = GetClient();
            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(async () => await client.DetectLanguageBatchAsync(batchConvenienceDocuments, options: new TextAnalyticsRequestOptions { DisableServiceLogs = true }));
            Assert.AreEqual("TextAnalyticsRequestOptions.DisableServiceLogs is not available in API version v3.0. Use service API version v3.1 or newer.", ex.Message);
        }

        private void ValidateInDocumenResult(DetectedLanguage language)
        {
            Assert.That(language.Name, Is.Not.Null.And.Not.Empty);
            Assert.That(language.Iso6391Name, Is.Not.Null.And.Not.Empty);
            Assert.GreaterOrEqual(language.ConfidenceScore, 0.0);
            Assert.LessOrEqual(language.ConfidenceScore, 1.0);
            Assert.IsNotNull(language.Warnings);
        }

        private void ValidateBatchDocumentsResult(DetectLanguageResultCollection results, bool includeStatistics = default)
        {
            Assert.That(results.ModelVersion, Is.Not.Null.And.Not.Empty);

            if (includeStatistics)
            {
                Assert.IsNotNull(results.Statistics);
                Assert.Greater(results.Statistics.DocumentCount, 0);
                Assert.Greater(results.Statistics.TransactionCount, 0);
                Assert.GreaterOrEqual(results.Statistics.InvalidDocumentCount, 0);
                Assert.GreaterOrEqual(results.Statistics.ValidDocumentCount, 0);
            }
            else
                Assert.IsNull(results.Statistics);

            Assert.Greater(results.Count, 0);
            foreach (DetectLanguageResult languageInDocument in results)
            {
                Assert.That(languageInDocument.Id, Is.Not.Null.And.Not.Empty);
                Assert.False(languageInDocument.HasError);

                //Even though statistics are not asked for, TA 5.0.0 shipped with Statistics default always present.
                Assert.IsNotNull(languageInDocument.Statistics);

                if (includeStatistics)
                {
                    Assert.GreaterOrEqual(languageInDocument.Statistics.CharacterCount, 0);
                    Assert.Greater(languageInDocument.Statistics.TransactionCount, 0);
                }
                else
                {
                    Assert.AreEqual(0, languageInDocument.Statistics.CharacterCount);
                    Assert.AreEqual(0, languageInDocument.Statistics.TransactionCount);
                }

                ValidateInDocumenResult(languageInDocument.PrimaryLanguage);
            }
        }
    }
}
