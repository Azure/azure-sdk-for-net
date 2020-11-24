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

        private const string singleEnglish = "My cat might need to see a veterinarian.";
        private const string singleSpanish = "Mi perro está en el veterinario";

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
        public async Task ExtractKeyPhrasesTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = singleEnglish;

            KeyPhraseCollection keyPhrases = await client.ExtractKeyPhrasesAsync(document);

            Assert.AreEqual(2, keyPhrases.Count);
            Assert.IsTrue(keyPhrases.Contains("cat"));
            Assert.IsTrue(keyPhrases.Contains("veterinarian"));
        }

        [Test]
        public async Task ExtractKeyPhrasesWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = singleSpanish;

            KeyPhraseCollection keyPhrases = await client.ExtractKeyPhrasesAsync(document, "es");

            Assert.AreEqual(2, keyPhrases.Count);
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
        public async Task ExtractKeyPhrasesWithWarningTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = "Anthony runs his own personal training business so thisisaverylongtokenwhichwillbetruncatedtoshowushowwarningsareemittedintheapi";

            KeyPhraseCollection keyPhrases = await client.ExtractKeyPhrasesAsync(document, "es");

            Assert.IsNotNull(keyPhrases.Warnings);
            Assert.GreaterOrEqual(keyPhrases.Warnings.Count, 0);
            Assert.AreEqual(TextAnalyticsWarningCode.LongWordsInDocument, keyPhrases.Warnings.FirstOrDefault().WarningCode.ToString());

            Assert.GreaterOrEqual(keyPhrases.Count, 1);
        }

        [Test]
        public async Task ExtractKeyPhrasesBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = batchConvenienceDocuments;

            ExtractKeyPhrasesResultCollection results = await client.ExtractKeyPhrasesBatchAsync(documents);

            foreach (ExtractKeyPhrasesResult result in results)
            {
                Assert.AreEqual(3, result.KeyPhrases.Count());
            }
        }

        [Test]
        public async Task ExtractKeyPhrasesBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = batchConvenienceDocuments;

            ExtractKeyPhrasesResultCollection results = await client.ExtractKeyPhrasesBatchAsync(documents, "en", new TextAnalyticsRequestOptions { IncludeStatistics = true });

            foreach (ExtractKeyPhrasesResult result in results)
            {
                Assert.AreEqual(3, result.KeyPhrases.Count());
            }

            Assert.IsNotNull(results.Statistics.DocumentCount);
            Assert.IsNotNull(results.Statistics.InvalidDocumentCount);
            Assert.IsNotNull(results.Statistics.TransactionCount);
            Assert.IsNotNull(results.Statistics.ValidDocumentCount);
        }

        [Test]
        public async Task ExtractKeyPhrasesBatchTest()
        {
            TextAnalyticsClient client = GetClient();
            List<TextDocumentInput> documents = batchDocuments;

            ExtractKeyPhrasesResultCollection results = await client.ExtractKeyPhrasesBatchAsync(documents);

            foreach (ExtractKeyPhrasesResult result in results)
            {
                Assert.AreEqual(3, result.KeyPhrases.Count());
            }
        }

        [Test]
        public async Task ExtractKeyPhrasesBatchWithSatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            List<TextDocumentInput> documents = batchDocuments;

            ExtractKeyPhrasesResultCollection results = await client.ExtractKeyPhrasesBatchAsync(documents, new TextAnalyticsRequestOptions { IncludeStatistics = true });

            foreach (ExtractKeyPhrasesResult result in results)
            {
                Assert.AreEqual(3, result.KeyPhrases.Count());
            }

            Assert.IsNotNull(results.Statistics.DocumentCount);
            Assert.IsNotNull(results.Statistics.InvalidDocumentCount);
            Assert.IsNotNull(results.Statistics.TransactionCount);
            Assert.IsNotNull(results.Statistics.ValidDocumentCount);
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
    }
}
