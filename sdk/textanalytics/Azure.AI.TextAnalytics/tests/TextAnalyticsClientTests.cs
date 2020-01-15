// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;
using Azure.Core.Testing;
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

            Assert.Throws<ArgumentNullException>(() => new TextAnalyticsClient(null, "subscriptionKey"));
            Assert.Throws<ArgumentException>(() => new TextAnalyticsClient(uri, ""));
            Assert.Throws<ArgumentNullException>(() => new TextAnalyticsClient(uri, (string)null));
            Assert.Throws<ArgumentNullException>(() => new TextAnalyticsClient(uri, (TokenCredential)null));
            Assert.Throws<ArgumentNullException>(() => new TextAnalyticsClient(null, new DefaultAzureCredential()));
        }

        [Test]
        public void DetectLanguageArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentException>(() => Client.DetectLanguageAsync(""));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.DetectLanguageAsync(null));
        }

        [Test]
        public void DetectLanguagesArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.DetectLanguagesAsync(null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.DetectLanguagesAsync(null, new TextAnalyticsRequestOptions()));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.DetectLanguagesAsync(new List<DetectLanguageInput>(), null));
        }

        [Test]
        public void RecognizeEntitiesArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentException>(() => Client.RecognizeEntitiesAsync(""));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeEntitiesAsync((string)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeEntitiesAsync((List<string>)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeEntitiesAsync(null, new TextAnalyticsRequestOptions()));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeEntitiesAsync(new List<TextDocumentInput>(), null));
        }

        [Test]
        public void AnalyzeSentimentArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentException>(() => Client.AnalyzeSentimentAsync(""));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.AnalyzeSentimentAsync((string)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.AnalyzeSentimentAsync((List<string>)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.AnalyzeSentimentAsync(null, new TextAnalyticsRequestOptions()));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.AnalyzeSentimentAsync(new List<TextDocumentInput>(), null));
        }

        [Test]
        public void ExtractKeyPhrasesArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentException>(() => Client.ExtractKeyPhrasesAsync(""));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.ExtractKeyPhrasesAsync((string)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.ExtractKeyPhrasesAsync((List<string>)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.ExtractKeyPhrasesAsync(null, new TextAnalyticsRequestOptions()));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.ExtractKeyPhrasesAsync(new List<TextDocumentInput>(), null));
        }

        [Test]
        public void RecognizePiiEntitiesArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentException>(() => Client.RecognizePiiEntitiesAsync(""));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizePiiEntitiesAsync((string)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizePiiEntitiesAsync((List<string>)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizePiiEntitiesAsync(null, new TextAnalyticsRequestOptions()));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizePiiEntitiesAsync(new List<TextDocumentInput>(), null));
        }

        [Test]
        public void RecognizeLinkedEntitiesArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentException>(() => Client.RecognizeLinkedEntitiesAsync(""));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeLinkedEntitiesAsync((string)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeLinkedEntitiesAsync((List<string>)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeLinkedEntitiesAsync(null, new TextAnalyticsRequestOptions()));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeLinkedEntitiesAsync(new List<TextDocumentInput>(), null));
        }
    }
}
