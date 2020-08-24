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
        public void AnalyzeSentimentArgumentValidation()
        {
            var documents = new List<string>();
            Assert.ThrowsAsync<ArgumentException>(() => Client.AnalyzeSentimentAsync(""));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.AnalyzeSentimentAsync((string)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.AnalyzeSentimentBatchAsync((List<string>)null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.AnalyzeSentimentBatchAsync(documents));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.AnalyzeSentimentBatchAsync(null, new TextAnalyticsRequestOptions()));
        }

        [Test]
        public void ExtractKeyPhrasesArgumentValidation()
        {
            var documents = new List<string>();
            Assert.ThrowsAsync<ArgumentException>(() => Client.ExtractKeyPhrasesAsync(""));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.ExtractKeyPhrasesAsync((string)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.ExtractKeyPhrasesBatchAsync((List<string>)null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.ExtractKeyPhrasesBatchAsync(documents));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.ExtractKeyPhrasesBatchAsync(null, new TextAnalyticsRequestOptions()));
        }

        [Test]
        public void RecognizeLinkedEntitiesArgumentValidation()
        {
            var documents = new List<string>();
            Assert.ThrowsAsync<ArgumentException>(() => Client.RecognizeLinkedEntitiesAsync(""));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeLinkedEntitiesAsync((string)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeLinkedEntitiesBatchAsync((List<string>)null));
            Assert.ThrowsAsync<ArgumentException>(() => Client.RecognizeLinkedEntitiesBatchAsync(documents));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeLinkedEntitiesBatchAsync(null, new TextAnalyticsRequestOptions()));
        }
    }
}
