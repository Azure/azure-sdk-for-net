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
    public class ExtractKeyPhrasesTests : TextAnalyticsClientLiveTestBase
    {
        public ExtractKeyPhrasesTests(bool isAsync, TextAnalyticsClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        private const string SingleEnglish = "My cat might need to see a veterinarian.";
        private const string SingleSpanish = "Mi perro está en el veterinario";

        private static List<string> batchConvenienceDocuments = new List<string>
        {
            "Microsoft was founded by Bill Gates and Paul Allen.",
            "My cat and my dog might need to see a veterinarian."
        };

        private static List<TextDocumentInput> batchDocuments = new List<TextDocumentInput>
        {
            new TextDocumentInput("1", "Microsoft was founded by Bill Gates and Paul Allen.")
            {
                 Language = "en",
            },
            new TextDocumentInput("2", "Mi perro y mi gato tienen que ir al veterinario.")
            {
                 Language = "es",
            }
        };

        [RecordedTest]
        public async Task ExtractKeyPhrasesWithAADTest()
        {
            TextAnalyticsClient client = GetClient(useTokenCredential: true);
            string document = SingleEnglish;

            KeyPhraseCollection keyPhrases = await client.ExtractKeyPhrasesAsync(document);

            ValidateInDocumenResult(keyPhrases, 2);

            Assert.That(keyPhrases, Does.Contain("cat"));
            Assert.That(keyPhrases, Does.Contain("veterinarian"));
        }

        [RecordedTest]
        public async Task ExtractKeyPhrasesTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = SingleEnglish;

            KeyPhraseCollection keyPhrases = await client.ExtractKeyPhrasesAsync(document);

            ValidateInDocumenResult(keyPhrases, 2);

            Assert.That(keyPhrases, Does.Contain("cat"));
            Assert.That(keyPhrases, Does.Contain("veterinarian"));
        }

        [RecordedTest]
        public async Task ExtractKeyPhrasesWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = SingleSpanish;

            KeyPhraseCollection keyPhrases = await client.ExtractKeyPhrasesAsync(document, "es");

            ValidateInDocumenResult(keyPhrases, 2);

            Assert.That(keyPhrases, Does.Contain("perro"));
            Assert.That(keyPhrases, Does.Contain("veterinario"));
        }

        [RecordedTest]
        public async Task ExtractKeyPhrasesBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<string>
            {
                "Microsoft was founded by Bill Gates and Paul Allen.",
                 "",
                "My cat might need to see a veterinarian."
            };

            ExtractKeyPhrasesResultCollection results = await client.ExtractKeyPhrasesBatchAsync(documents);

            Assert.Multiple(() =>
            {
                Assert.That(!results[0].HasError, Is.True);
                Assert.That(!results[2].HasError, Is.True);
            });

            var exceptionMessage = "Cannot access result for document 1, due to error InvalidDocument: Document text is empty.";
            Assert.That(results[1].HasError, Is.True);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => results[1].KeyPhrases.GetType());
            Assert.That(ex.Message, Is.EqualTo(exceptionMessage));
        }

        [RecordedTest]
        public async Task ExtractKeyPhrasesBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = batchConvenienceDocuments;

            ExtractKeyPhrasesResultCollection results = await client.ExtractKeyPhrasesBatchAsync(documents);

            ValidateBatchDocumentsResult(results, 3);
        }

        [RecordedTest]
        public async Task ExtractKeyPhrasesBatchConvenienceWithStatisticsTest()
        {
            var options = new TextAnalyticsRequestOptions { IncludeStatistics = true };
            TextAnalyticsClient client = GetClient();
            var documents = batchConvenienceDocuments;

            ExtractKeyPhrasesResultCollection results = await client.ExtractKeyPhrasesBatchAsync(documents, "en", options);

            ValidateBatchDocumentsResult(results, 3, includeStatistics: true);

            Assert.Multiple(() =>
            {
                Assert.That(results.Statistics.DocumentCount, Is.EqualTo(documents.Count));

                // Assert the options classes since overloads were added and the original now instantiates a RecognizeEntitiesOptions.
                Assert.That(options.IncludeStatistics, Is.True);
                Assert.That(options.ModelVersion, Is.Null);
            });
        }

        [RecordedTest]
        public async Task ExtractKeyPhrasesBatchTest()
        {
            TextAnalyticsClient client = GetClient();
            List<TextDocumentInput> documents = batchDocuments;

            ExtractKeyPhrasesResultCollection results = await client.ExtractKeyPhrasesBatchAsync(documents);

            ValidateBatchDocumentsResult(results, 3);
        }

        [RecordedTest]
        public async Task ExtractKeyPhrasesBatchWithSatisticsTest()
        {
            var options = new TextAnalyticsRequestOptions { IncludeStatistics = true };
            TextAnalyticsClient client = GetClient();
            List<TextDocumentInput> documents = batchDocuments;

            ExtractKeyPhrasesResultCollection results = await client.ExtractKeyPhrasesBatchAsync(documents, options);

            ValidateBatchDocumentsResult(results, 3, includeStatistics: true);

            Assert.Multiple(() =>
            {
                Assert.That(results.Statistics.DocumentCount, Is.EqualTo(documents.Count));

                // Assert the options classes since overloads were added and the original now instantiates a RecognizeEntitiesOptions.
                Assert.That(options.IncludeStatistics, Is.True);
                Assert.That(options.ModelVersion, Is.Null);
            });
        }

        [RecordedTest]
        public void ExtractKeyPhrasesBatchWithNullIdTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<TextDocumentInput> { new TextDocumentInput(null, "Hello world") };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.ExtractKeyPhrasesBatchAsync(documents));
            Assert.That(ex.ErrorCode, Is.EqualTo(TextAnalyticsErrorCode.InvalidDocument));
        }

        [RecordedTest]
        public async Task ExtractKeyPhrasesBatchWithNullTextTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<TextDocumentInput> { new TextDocumentInput("1", null) };

            ExtractKeyPhrasesResultCollection results = await client.ExtractKeyPhrasesBatchAsync(documents);
            var exceptionMessage = "Cannot access result for document 1, due to error InvalidDocument: Document text is empty.";
            Assert.That(results[0].HasError, Is.True);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => results[0].KeyPhrases.Count());
            Assert.That(ex.Message, Is.EqualTo(exceptionMessage));
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_05_01)]
        [Ignore("LRO not implemented")]
        public async Task ExtractKeyPhrasesWithMultipleActions()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ExtractKeyPhrasesActions = new List<ExtractKeyPhrasesAction>()
                {
                    new ExtractKeyPhrasesAction()
                    {
                        DisableServiceLogs = true,
                        ActionName = "ExtractKeyPhrasesWithDisabledServiceLogs"
                    },
                    new ExtractKeyPhrasesAction()
                    {
                        ActionName = "ExtractKeyPhrases"
                    }
                }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(batchConvenienceDocuments, batchActions);

            await operation.WaitForCompletionAsync();

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<ExtractKeyPhrasesActionResult> ExtractKeyPhrasesActionsResults = resultCollection.ExtractKeyPhrasesResults;

            Assert.That(ExtractKeyPhrasesActionsResults, Is.Not.Null);

            IList<string> expected = new List<string> { "ExtractKeyPhrases", "ExtractKeyPhrasesWithDisabledServiceLogs" };
            Assert.That(ExtractKeyPhrasesActionsResults.Select(result => result.ActionName), Is.EquivalentTo(expected));
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V3_1)]
        public async Task ExtractKeyPhrasesBatchDisableServiceLogs()
        {
            TextAnalyticsClient client = GetClient();
            ExtractKeyPhrasesResultCollection results = await client.ExtractKeyPhrasesBatchAsync(batchConvenienceDocuments, "en", options: new TextAnalyticsRequestOptions { DisableServiceLogs = true });

            ValidateBatchDocumentsResult(results, 3);
        }

        [RecordedTest]
        [ServiceVersion(Max = TextAnalyticsClientOptions.ServiceVersion.V3_0)]
        public void ExtractKeyPhrasesBatchDisableServiceLogsThrows()
        {
            TestDiagnostics = false;

            TextAnalyticsClient client = GetClient();
            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(async () => await client.ExtractKeyPhrasesBatchAsync(batchConvenienceDocuments, "en", options: new TextAnalyticsRequestOptions { DisableServiceLogs = true }));
            Assert.That(ex.Message, Is.EqualTo("TextAnalyticsRequestOptions.DisableServiceLogs is not available in API version v3.0. Use service API version v3.1 or newer."));
        }

        private void ValidateInDocumenResult(KeyPhraseCollection keyPhrases, int minKeyPhrasesCount = default)
        {
            Assert.Multiple(() =>
            {
                Assert.That(keyPhrases.Warnings, Is.Not.Null);
                Assert.That(keyPhrases, Has.Count.GreaterThanOrEqualTo(minKeyPhrasesCount));
            });
        }

        private void ValidateBatchDocumentsResult(
            ExtractKeyPhrasesResultCollection results,
            int minKeyPhrasesCount = default,
            bool includeStatistics = default)
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

            foreach (ExtractKeyPhrasesResult result in results)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(result.Id, Is.Not.Null.And.Not.Empty);
                    Assert.That(result.HasError, Is.False);

                    //Even though statistics are not asked for, TA 5.0.0 shipped with Statistics default always present.
                    Assert.That(result.Statistics, Is.Not.Null);
                });

                if (includeStatistics)
                {
                    Assert.Multiple(() =>
                    {
                        Assert.That(result.Statistics.CharacterCount, Is.GreaterThanOrEqualTo(0));
                        Assert.That(result.Statistics.TransactionCount, Is.GreaterThan(0));
                    });
                }
                else
                {
                    Assert.Multiple(() =>
                    {
                        Assert.That(result.Statistics.CharacterCount, Is.EqualTo(0));
                        Assert.That(result.Statistics.TransactionCount, Is.EqualTo(0));
                    });
                }

                ValidateInDocumenResult(result.KeyPhrases, minKeyPhrasesCount);
            }
        }
    }
}
