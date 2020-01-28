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

            Assert.Throws<ArgumentNullException>(() => new TextAnalyticsClient(null, new TextAnalyticsSubscriptionKeyCredential("subscriptionKey")));
            Assert.Throws<ArgumentNullException>(() => new TextAnalyticsClient(uri, (TextAnalyticsSubscriptionKeyCredential)null));
            Assert.Throws<ArgumentNullException>(() => new TextAnalyticsClient(uri, (TokenCredential)null));
            Assert.Throws<ArgumentNullException>(() => new TextAnalyticsClient(null, new DefaultAzureCredential()));
        }

        [Test]
        public void DetectLanguageArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.DetectLanguageAsync(null));
        }

        [Test]
        public void DetectLanguagesArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.DetectLanguagesAsync((List<string>)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.DetectLanguagesAsync(null, new TextAnalyticsRequestOptions()));
        }

        [Test]
        public void RecognizeEntitiesArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeEntitiesAsync((string)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeEntitiesAsync((List<string>)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeEntitiesAsync(null, new TextAnalyticsRequestOptions()));
        }

        [Test]
        public void AnalyzeSentimentArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.AnalyzeSentimentAsync((string)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.AnalyzeSentimentAsync((List<string>)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.AnalyzeSentimentAsync(null, new TextAnalyticsRequestOptions()));
        }

        [Test]
        public void ExtractKeyPhrasesArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.ExtractKeyPhrasesAsync((string)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.ExtractKeyPhrasesAsync((List<string>)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.ExtractKeyPhrasesAsync(null, new TextAnalyticsRequestOptions()));
        }

        [Test]
        public void RecognizePiiEntitiesArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizePiiEntitiesAsync((string)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizePiiEntitiesAsync((List<string>)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizePiiEntitiesAsync(null, new TextAnalyticsRequestOptions()));
        }

        [Test]
        public void RecognizeLinkedEntitiesArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeLinkedEntitiesAsync((string)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeLinkedEntitiesAsync((List<string>)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeLinkedEntitiesAsync(null, new TextAnalyticsRequestOptions()));
        }
    }
}
