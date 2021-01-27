// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests
{
    public class ExtractKeyPhrasesTests : TextAnalyticsClientLiveTestBase
    {
        public ExtractKeyPhrasesTests(bool isAsync) : base(isAsync) { }

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

        [Test]
        public async Task ExtractKeyPhrasesWithAADTest()
        {
            TextAnalyticsClient client = GetClient(useTokenCredential: true);
            string document = SingleEnglish;

            KeyPhraseCollection keyPhrases = await client.ExtractKeyPhrasesAsync(document);

            ValidateInDocumenResult(keyPhrases, 2);

            Assert.IsTrue(keyPhrases.Contains("cat"));
            Assert.IsTrue(keyPhrases.Contains("veterinarian"));
        }

        [Test]
        public async Task ExtractKeyPhrasesTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = SingleEnglish;

            KeyPhraseCollection keyPhrases = await client.ExtractKeyPhrasesAsync(document);

            ValidateInDocumenResult(keyPhrases, 2);

            Assert.IsTrue(keyPhrases.Contains("cat"));
            Assert.IsTrue(keyPhrases.Contains("veterinarian"));
        }

        [Test]
        public async Task ExtractKeyPhrasesWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = SingleSpanish;

            KeyPhraseCollection keyPhrases = await client.ExtractKeyPhrasesAsync(document, "es");

            ValidateInDocumenResult(keyPhrases, 2);

            Assert.IsTrue(keyPhrases.Contains("perro"));
            Assert.IsTrue(keyPhrases.Contains("veterinario"));
        }

        [Test]
        public async Task ExtractKeyPhrasesWithWarningTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = "Anthony runs his own personal training business so thisisaverylongtokenwhichwillbetruncatedtoshowushowwarningsareemittedintheapi";

            KeyPhraseCollection keyPhrases = await client.ExtractKeyPhrasesAsync(document, "es");

            ValidateInDocumenResult(keyPhrases, 1);

            Assert.AreEqual(TextAnalyticsWarningCode.LongWordsInDocument, keyPhrases.Warnings.FirstOrDefault().WarningCode.ToString());
        }

        [Test]
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

            Assert.IsTrue(!results[0].HasError);
            Assert.IsTrue(!results[2].HasError);

            var exceptionMessage = "Cannot access result for document 1, due to error InvalidDocument: Document text is empty.";
            Assert.IsTrue(results[1].HasError);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => results[1].KeyPhrases.GetType());
            Assert.AreEqual(exceptionMessage, ex.Message);
        }

        [Test]
        public async Task ExtractKeyPhrasesBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = batchConvenienceDocuments;

            ExtractKeyPhrasesResultCollection results = await client.ExtractKeyPhrasesBatchAsync(documents);

            ValidateBatchDocumentsResult(results, 3);
        }

        [Test]
        public async Task ExtractKeyPhrasesBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = batchConvenienceDocuments;

            ExtractKeyPhrasesResultCollection results = await client.ExtractKeyPhrasesBatchAsync(documents, "en", new TextAnalyticsRequestOptions { IncludeStatistics = true });

            ValidateBatchDocumentsResult(results, 3, includeStatistics: true);

            Assert.AreEqual(documents.Count, results.Statistics.DocumentCount);
        }

        [Test]
        public async Task ExtractKeyPhrasesBatchTest()
        {
            TextAnalyticsClient client = GetClient();
            List<TextDocumentInput> documents = batchDocuments;

            ExtractKeyPhrasesResultCollection results = await client.ExtractKeyPhrasesBatchAsync(documents);

            ValidateBatchDocumentsResult(results, 3);
        }

        [Test]
        public async Task ExtractKeyPhrasesBatchWithSatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            List<TextDocumentInput> documents = batchDocuments;

            ExtractKeyPhrasesResultCollection results = await client.ExtractKeyPhrasesBatchAsync(documents, new TextAnalyticsRequestOptions { IncludeStatistics = true });

            ValidateBatchDocumentsResult(results, 3, includeStatistics: true);

            Assert.AreEqual(documents.Count, results.Statistics.DocumentCount);
        }

        [Test]
        public void ExtractKeyPhrasesBatchWithNullIdTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<TextDocumentInput> { new TextDocumentInput(null, "Hello world") };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.ExtractKeyPhrasesBatchAsync(documents));
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocument, ex.ErrorCode);
        }

        [Test]
        public async Task ExtractKeyPhrasesBatchWithNullTextTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<TextDocumentInput> { new TextDocumentInput("1", null) };

            ExtractKeyPhrasesResultCollection results = await client.ExtractKeyPhrasesBatchAsync(documents);
            var exceptionMessage = "Cannot access result for document 1, due to error InvalidDocument: Document text is empty.";
            Assert.IsTrue(results[0].HasError);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => results[0].KeyPhrases.Count());
            Assert.AreEqual(exceptionMessage, ex.Message);
        }

        private void ValidateInDocumenResult(KeyPhraseCollection keyPhrases, int minKeyPhrasesCount = default)
        {
            Assert.IsNotNull(keyPhrases.Warnings);
            Assert.GreaterOrEqual(keyPhrases.Count, minKeyPhrasesCount);
        }

        private void ValidateBatchDocumentsResult(ExtractKeyPhrasesResultCollection results, int minKeyPhrasesCount = default, bool includeStatistics = default)
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

            foreach (ExtractKeyPhrasesResult keyPhrasesInDocument in results)
            {
                Assert.That(keyPhrasesInDocument.Id, Is.Not.Null.And.Not.Empty);

                Assert.False(keyPhrasesInDocument.HasError);

                //Even though statistics are not asked for, TA 5.0.0 shipped with Statistics default always present.
                Assert.IsNotNull(keyPhrasesInDocument.Statistics);

                if (includeStatistics)
                {
                    Assert.GreaterOrEqual(keyPhrasesInDocument.Statistics.CharacterCount, 0);
                    Assert.Greater(keyPhrasesInDocument.Statistics.TransactionCount, 0);
                }
                else
                {
                    Assert.AreEqual(0, keyPhrasesInDocument.Statistics.CharacterCount);
                    Assert.AreEqual(0, keyPhrasesInDocument.Statistics.TransactionCount);
                }

                ValidateInDocumenResult(keyPhrasesInDocument.KeyPhrases, minKeyPhrasesCount);
            }
        }
    }
}
