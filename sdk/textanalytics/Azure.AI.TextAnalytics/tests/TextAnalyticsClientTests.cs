// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests
{
    public class TextAnalyticsClientTests : ClientTestBase
    {
        public TextAnalyticsClientTests(bool isAsync) : base(isAsync)
        {
            TextAnalyticsClientOptions options = new TextAnalyticsClientOptions
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
        public void DetectLanguageArgumentValidation()
        {
            var documents = new List<string>();
            Assert.ThrowsAsync<ArgumentException>(() => Client.DetectLanguageAsync(""));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.DetectLanguageAsync((string)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.DetectLanguageBatchAsync((List<string>)null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.DetectLanguageBatchAsync(documents));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.DetectLanguageBatchAsync(null, new TextAnalyticsRequestOptions()));
        }

        [Test]
        public void RecognizeEntitiesArgumentValidation()
        {
            var documents = new List<string>();
            Assert.ThrowsAsync<ArgumentException>(() => Client.RecognizeEntitiesAsync(""));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeEntitiesAsync((string)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeEntitiesBatchAsync((List<string>)null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.RecognizeEntitiesBatchAsync(documents));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeEntitiesBatchAsync(null, new TextAnalyticsRequestOptions()));
        }

        [Test]
        public void RecognizePiiEntitiesArgumentValidation()
        {
            var documents = new List<string>();
            Assert.ThrowsAsync<ArgumentException>(() => Client.RecognizePiiEntitiesAsync(""));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizePiiEntitiesAsync((string)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizePiiEntitiesBatchAsync((List<string>)null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.RecognizePiiEntitiesBatchAsync(documents));
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
            var documents = new List<string>();
            Assert.ThrowsAsync<ArgumentException>(() => Client.ExtractKeyPhrasesAsync(""));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.ExtractKeyPhrasesAsync(null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.ExtractKeyPhrasesBatchAsync((List<string>)null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.ExtractKeyPhrasesBatchAsync(documents));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.ExtractKeyPhrasesBatchAsync(null, new TextAnalyticsRequestOptions()));
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
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeLinkedEntitiesBatchAsync((string[])null, new TextAnalyticsRequestOptions()));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeLinkedEntitiesBatchAsync((TextDocumentInput[])null, new TextAnalyticsRequestOptions()));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeLinkedEntitiesBatchAsync((string[])null, new RecognizeLinkedEntitiesOptions()));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeLinkedEntitiesBatchAsync(null, new RecognizeLinkedEntitiesOptions()));

            // Variations to ensure call-compatibility after adding method-specific options class to parameters.
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeLinkedEntitiesBatchAsync((string[])null, options: new TextAnalyticsRequestOptions()));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeLinkedEntitiesBatchAsync((TextDocumentInput[])null, options: new TextAnalyticsRequestOptions()));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeLinkedEntitiesBatchAsync(null, null, new TextAnalyticsRequestOptions()));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeLinkedEntitiesBatchAsync(null, new RecognizeLinkedEntitiesOptions()));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeLinkedEntitiesBatchAsync(null, null, new RecognizeLinkedEntitiesOptions()));
        }
    }
}
