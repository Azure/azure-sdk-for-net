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
            Assert.That(ex.ErrorCode, Is.EqualTo(TextAnalyticsErrorCode.InvalidCountryHint));
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

            Assert.Multiple(() =>
            {
                Assert.That(results[0].PrimaryLanguage.Name, Is.EqualTo("English"));
                Assert.That(results[1].PrimaryLanguage.Name, Is.EqualTo("French"));
                Assert.That(results[2].PrimaryLanguage.Name, Is.EqualTo("Spanish"));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(results[0].PrimaryLanguage.Name, Is.EqualTo("English"));
                Assert.That(results[1].PrimaryLanguage.Name, Is.EqualTo("French"));
                Assert.That(results[2].PrimaryLanguage.Name, Is.EqualTo("Spanish"));
            });
        }

        [RecordedTest]
        public async Task DetectLanguageBatchTest()
        {
            TextAnalyticsClient client = GetClient();
            List<DetectLanguageInput> documents = batchDocuments;

            DetectLanguageResultCollection results = await client.DetectLanguageBatchAsync(documents, options: new TextAnalyticsRequestOptions() { ModelVersion = "2019-10-01" });

            ValidateBatchDocumentsResult(results);

            Assert.Multiple(() =>
            {
                Assert.That(results[0].PrimaryLanguage.Name, Is.EqualTo("English"));
                Assert.That(results[1].PrimaryLanguage.Name, Is.EqualTo("French"));
                Assert.That(results[2].PrimaryLanguage.Name, Is.EqualTo("Spanish"));
                Assert.That(results[3].PrimaryLanguage.Name, Is.EqualTo("(Unknown)"));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(results[0].PrimaryLanguage.Name, Is.EqualTo("English"));
                Assert.That(results[1].PrimaryLanguage.Name, Is.EqualTo("French"));
                Assert.That(results[2].PrimaryLanguage.Name, Is.EqualTo("Spanish"));
                Assert.That(results[3].PrimaryLanguage.Name, Is.EqualTo("(Unknown)"));
            });
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

            Assert.Multiple(() =>
            {
                Assert.That(!results[0].HasError, Is.True);
                Assert.That(!results[2].HasError, Is.True);
            });

            var exceptionMessage = "Cannot access result for document 1, due to error InvalidDocument: Document text is empty.";
            Assert.That(results[1].HasError, Is.True);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => results[1].PrimaryLanguage.GetType());
            Assert.That(ex.Message, Is.EqualTo(exceptionMessage));
        }

        [RecordedTest]
        public void DetectLanguageBatchWithNullIdTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<DetectLanguageInput> { new DetectLanguageInput(null, "Hello world") };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                async () => await client.DetectLanguageBatchAsync(documents, options: new TextAnalyticsRequestOptions() { ModelVersion = "2019-10-01" }));
            Assert.That(ex.ErrorCode, Is.EqualTo(TextAnalyticsErrorCode.InvalidDocument));
        }

        [RecordedTest]
        public async Task DetectLanguageBatchWithNullTextTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<DetectLanguageInput> { new DetectLanguageInput("1", null) };

            DetectLanguageResultCollection results = await client.DetectLanguageBatchAsync(documents, options: new TextAnalyticsRequestOptions() { ModelVersion = "2019-10-01" });

            var exceptionMessage = "Cannot access result for document 1, due to error InvalidDocument: Document text is empty.";
            Assert.That(results[0].HasError, Is.True);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => results[0].PrimaryLanguage.GetType());
            Assert.That(ex.Message, Is.EqualTo(exceptionMessage));
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V3_1)]
        public async Task DetectLanguageBatchDisableServiceLogs()
        {
            TextAnalyticsClient client = GetClient();
            DetectLanguageResultCollection results = await client.DetectLanguageBatchAsync(batchConvenienceDocuments, options: new TextAnalyticsRequestOptions { DisableServiceLogs = true });

            ValidateBatchDocumentsResult(results);
            Assert.That(results[0].PrimaryLanguage.Name, Is.EqualTo("English"));
        }

        [RecordedTest]
        [ServiceVersion(Max = TextAnalyticsClientOptions.ServiceVersion.V3_0)]
        public void DetectLanguageBatchDisableServiceLogsThrows()
        {
            TestDiagnostics = false;

            TextAnalyticsClient client = GetClient();
            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(async () => await client.DetectLanguageBatchAsync(batchConvenienceDocuments, options: new TextAnalyticsRequestOptions { DisableServiceLogs = true }));
            Assert.That(ex.Message, Is.EqualTo("TextAnalyticsRequestOptions.DisableServiceLogs is not available in API version v3.0. Use service API version v3.1 or newer."));
        }

        private void ValidateInDocumenResult(DetectedLanguage language)
        {
            Assert.Multiple(() =>
            {
                Assert.That(language.Name, Is.Not.Null.And.Not.Empty);
                Assert.That(language.Iso6391Name, Is.Not.Null.And.Not.Empty);
                Assert.That(language.ConfidenceScore, Is.GreaterThanOrEqualTo(0.0));
            });
            Assert.Multiple(() =>
            {
                Assert.That(language.ConfidenceScore, Is.LessThanOrEqualTo(1.0));
                Assert.That(language.Warnings, Is.Not.Null);
            });
        }

        private void ValidateBatchDocumentsResult(DetectLanguageResultCollection results, bool includeStatistics = default)
        {
            Assert.That(results.ModelVersion, Is.Not.Null.And.Not.Empty);

            if (includeStatistics)
            {
                Assert.That(results.Statistics, Is.Not.Null);
                Assert.Multiple(() =>
                {
                    Assert.That(results.Statistics.DocumentCount, Is.GreaterThan(0));
                    Assert.That(results.Statistics.TransactionCount, Is.GreaterThan(0));
                    Assert.That(results.Statistics.InvalidDocumentCount, Is.GreaterThanOrEqualTo(0));
                    Assert.That(results.Statistics.ValidDocumentCount, Is.GreaterThanOrEqualTo(0));
                });
            }
            else
                Assert.That(results.Statistics, Is.Null);

            Assert.That(results.Count, Is.GreaterThan(0));
            foreach (DetectLanguageResult languageInDocument in results)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(languageInDocument.Id, Is.Not.Null.And.Not.Empty);
                    Assert.That(languageInDocument.HasError, Is.False);

                    //Even though statistics are not asked for, TA 5.0.0 shipped with Statistics default always present.
                    Assert.That(languageInDocument.Statistics, Is.Not.Null);
                });

                if (includeStatistics)
                {
                    Assert.Multiple(() =>
                    {
                        Assert.That(languageInDocument.Statistics.CharacterCount, Is.GreaterThanOrEqualTo(0));
                        Assert.That(languageInDocument.Statistics.TransactionCount, Is.GreaterThan(0));
                    });
                }
                else
                {
                    Assert.Multiple(() =>
                    {
                        Assert.That(languageInDocument.Statistics.CharacterCount, Is.EqualTo(0));
                        Assert.That(languageInDocument.Statistics.TransactionCount, Is.EqualTo(0));
                    });
                }

                ValidateInDocumenResult(languageInDocument.PrimaryLanguage);
            }
        }
    }
}
