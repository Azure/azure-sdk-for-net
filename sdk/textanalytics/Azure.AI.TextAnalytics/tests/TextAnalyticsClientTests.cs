// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Moq;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests
{
    public class TextAnalyticsClientTests : ClientTestBase
    {
        public TextAnalyticsClientTests(bool isAsync)
            : base(isAsync)
        {
            TextAnalyticsClientOptions options = new TextAnalyticsClientOptions()
            {
                Transport = new MockTransport(),
            };

             Client = InstrumentClient(new TextAnalyticsClient(new Uri("http://localhost"), new DefaultAzureCredential(), options));
        }

        public TextAnalyticsClient Client { get; set; }

        [Test]
        public void CreateClientArgumentValidation()
        {
            var uri = new Uri("http://localhost");

            Assert.Throws<ArgumentNullException>(() => new TextAnalyticsClient(null, new AzureKeyCredential("apiKey")));
            Assert.Throws<ArgumentNullException>(() => new TextAnalyticsClient(uri, (AzureKeyCredential)null));
            Assert.Throws<ArgumentNullException>(() => new TextAnalyticsClient(uri, (TokenCredential)null));
            Assert.Throws<ArgumentNullException>(() => new TextAnalyticsClient(null, new DefaultAzureCredential()));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CreateClientAllowsMissingDefaultLanguage(string defaultLanguage)
        {
            var uri = new Uri("http://localhost");
            var options = new TextAnalyticsClientOptions { DefaultLanguage = defaultLanguage };

            Assert.DoesNotThrow(() => new TextAnalyticsClient(uri, new AzureKeyCredential("apiKey"), options));
            Assert.DoesNotThrow(() => new TextAnalyticsClient(uri, Mock.Of<TokenCredential>(), options));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void CreateClientAllowsMissingDefaultCountryHint(string defaultCountryHint)
        {
            var uri = new Uri("http://localhost");
            var options = new TextAnalyticsClientOptions { DefaultCountryHint = defaultCountryHint };

            Assert.DoesNotThrow(() => new TextAnalyticsClient(uri, new AzureKeyCredential("apiKey"), options));
            Assert.DoesNotThrow(() => new TextAnalyticsClient(uri, Mock.Of<TokenCredential>(), options));
        }

        [Test]
        public void DetectLanguageArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentException>(() => Client.DetectLanguageAsync(""));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.DetectLanguageAsync(null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.DetectLanguageBatchAsync((string[])null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.DetectLanguageBatchAsync((DetectLanguageInput[])null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.DetectLanguageBatchAsync(Array.Empty<string>()));
            Assert.ThrowsAsync<ArgumentException>(() => Client.DetectLanguageBatchAsync(Array.Empty<DetectLanguageInput>()));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.DetectLanguageBatchAsync(null, new TextAnalyticsRequestOptions()));
        }

        [Test]
        public void RecognizeEntitiesArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentException>(() => Client.RecognizeEntitiesAsync(""));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeEntitiesAsync(null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeEntitiesBatchAsync((string[])null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeEntitiesBatchAsync((TextDocumentInput[])null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.RecognizeEntitiesBatchAsync(Array.Empty<string>()));
            Assert.ThrowsAsync<ArgumentException>(() => Client.RecognizeEntitiesBatchAsync(Array.Empty<TextDocumentInput>()));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeEntitiesBatchAsync(null, new TextAnalyticsRequestOptions()));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeEntitiesBatchAsync((string[])null, options: new TextAnalyticsRequestOptions()));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeEntitiesBatchAsync(null, null, new TextAnalyticsRequestOptions()));
        }

        [Test]
        public void RecognizePiiEntitiesArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentException>(() => Client.RecognizePiiEntitiesAsync(""));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizePiiEntitiesAsync(null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizePiiEntitiesBatchAsync((string[])null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizePiiEntitiesBatchAsync((TextDocumentInput[])null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.RecognizePiiEntitiesBatchAsync(Array.Empty<string>()));
            Assert.ThrowsAsync<ArgumentException>(() => Client.RecognizePiiEntitiesBatchAsync(Array.Empty<TextDocumentInput>()));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizePiiEntitiesBatchAsync(null, new RecognizePiiEntitiesOptions()));
        }

        [Test]
        public void AnalyzeSentimentArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentException>(() => Client.AnalyzeSentimentAsync(""));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.AnalyzeSentimentAsync(null));

            Assert.ThrowsAsync<ArgumentNullException>(() => Client.AnalyzeSentimentBatchAsync((string[])null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.AnalyzeSentimentBatchAsync((string[])null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.AnalyzeSentimentBatchAsync(Array.Empty<string>()));
            Assert.ThrowsAsync<ArgumentException>(() => Client.AnalyzeSentimentBatchAsync(Array.Empty<TextDocumentInput>()));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.AnalyzeSentimentBatchAsync(null, new TextAnalyticsRequestOptions()));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.AnalyzeSentimentBatchAsync(null, new AnalyzeSentimentOptions()));

            // Variations to ensure call-compatibility after adding method-specific options class to parameters.
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.AnalyzeSentimentBatchAsync(null, options: new TextAnalyticsRequestOptions()));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.AnalyzeSentimentBatchAsync(null, null, new TextAnalyticsRequestOptions()));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.AnalyzeSentimentBatchAsync(null, new AnalyzeSentimentOptions()));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.AnalyzeSentimentBatchAsync(null, null, new AnalyzeSentimentOptions()));
        }

        [Test]
        public void ExtractKeyPhrasesArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentException>(() => Client.ExtractKeyPhrasesAsync(""));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.ExtractKeyPhrasesAsync(null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.ExtractKeyPhrasesBatchAsync((string[])null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.ExtractKeyPhrasesBatchAsync((TextDocumentInput[])null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.ExtractKeyPhrasesBatchAsync(Array.Empty<string>()));
            Assert.ThrowsAsync<ArgumentException>(() => Client.ExtractKeyPhrasesBatchAsync(Array.Empty<TextDocumentInput>()));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.ExtractKeyPhrasesBatchAsync((string[])null, options: new TextAnalyticsRequestOptions()));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.ExtractKeyPhrasesBatchAsync((TextDocumentInput[])null, options: new TextAnalyticsRequestOptions()));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.ExtractKeyPhrasesBatchAsync(null, null, new TextAnalyticsRequestOptions()));
        }

        [Test]
        public void RecognizeLinkedEntitiesArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentException>(() => Client.RecognizeLinkedEntitiesAsync(""));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeLinkedEntitiesAsync(null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeLinkedEntitiesBatchAsync((string[])null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeLinkedEntitiesBatchAsync((string[])null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.RecognizeLinkedEntitiesBatchAsync(Array.Empty<string>()));
            Assert.ThrowsAsync<ArgumentException>(() => Client.RecognizeLinkedEntitiesBatchAsync(Array.Empty<TextDocumentInput>()));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeLinkedEntitiesBatchAsync(null, new TextAnalyticsRequestOptions()));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeLinkedEntitiesBatchAsync((string[])null, options: new TextAnalyticsRequestOptions()));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeLinkedEntitiesBatchAsync(null, null, new TextAnalyticsRequestOptions()));
        }

        [Test]
        public void DynamicClassifyArgumentValidation()
        {
            string document1 = "The WHO is issuing a warning about Monkey Pox.";
            string document2 = "Mo Salah plays in Liverpool FC in England.";
            List<string> batchConvenienceDocuments = new() { document1, document2 };
            List<TextDocumentInput> batchDocuments = new() {
                new TextDocumentInput("1", document1),
                new TextDocumentInput("2", document2)
            };
            List<string> categories = new() { "Health", "Politics", "Music", "Sports" };

            Assert.ThrowsAsync<ArgumentNullException>(() => Client.DynamicClassifyAsync(null, categories));
            Assert.ThrowsAsync<ArgumentException>(() => Client.DynamicClassifyAsync(string.Empty, categories));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.DynamicClassifyAsync(document1, null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.DynamicClassifyAsync(document1, Array.Empty<string>()));

            Assert.ThrowsAsync<ArgumentNullException>(() => Client.DynamicClassifyBatchAsync((string[])null, categories));
            Assert.ThrowsAsync<ArgumentException>(() => Client.DynamicClassifyBatchAsync(Array.Empty<string>(), categories));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.DynamicClassifyBatchAsync(batchConvenienceDocuments, null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.DynamicClassifyBatchAsync(batchConvenienceDocuments, Array.Empty<string>()));

            Assert.ThrowsAsync<ArgumentNullException>(() => Client.DynamicClassifyBatchAsync((TextDocumentInput[])null, categories));
            Assert.ThrowsAsync<ArgumentException>(() => Client.DynamicClassifyBatchAsync(Array.Empty<TextDocumentInput>(), categories));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.DynamicClassifyBatchAsync(batchDocuments, null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.DynamicClassifyBatchAsync(batchDocuments, Array.Empty<string>()));
        }

        [Test]
        public void ExtractSummaryArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.StartExtractSummaryAsync((string[])null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.StartExtractSummaryAsync(Array.Empty<string>()));

            Assert.ThrowsAsync<ArgumentNullException>(() => Client.StartExtractSummaryAsync((TextDocumentInput[])null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.StartExtractSummaryAsync(Array.Empty<TextDocumentInput>()));
        }

        [Test]
        public void AbstractiveSummarizeArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.StartAbstractiveSummarizeAsync((string[])null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.StartAbstractiveSummarizeAsync(Array.Empty<string>()));

            Assert.ThrowsAsync<ArgumentNullException>(() => Client.StartAbstractiveSummarizeAsync((TextDocumentInput[])null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.StartAbstractiveSummarizeAsync(Array.Empty<TextDocumentInput>()));
        }
    }
}
