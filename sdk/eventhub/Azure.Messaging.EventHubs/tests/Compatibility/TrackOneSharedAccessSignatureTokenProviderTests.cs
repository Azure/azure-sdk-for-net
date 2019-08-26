// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Compatibility;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="TrackOneSharedAccessSignatureTokenProvider" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class TrackOneSharedAccessSignatureTokenProviderTests
    {
        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheSignature()
        {
            Assert.That(() => new TrackOneSharedAccessTokenProvider(null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheSignatureHasAKey()
        {
            var signature = new SharedAccessSignature("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&skn=keykeykey");
            Assert.That(() => new TrackOneSharedAccessTokenProvider(signature), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorClonesTheSignature()
        {
            var signature = new SharedAccessSignature("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&skn=keykeykey", "ABC123");
            var provider = new TrackOneSharedAccessTokenProvider(signature);

            Assert.That(provider.SharedAccessSignature, Is.Not.Null, "The provider should have a signature.");
            Assert.That(provider.SharedAccessSignature, Is.Not.SameAs(signature), "The provider should not be the same instance.");
            Assert.That(provider.SharedAccessSignature.Resource, Is.EqualTo(signature.Resource), "The resources should match.");
            Assert.That(provider.SharedAccessSignature.SharedAccessKeyName, Is.EqualTo(signature.SharedAccessKeyName), "The key name should match.");
            Assert.That(provider.SharedAccessSignature.SharedAccessKey, Is.EqualTo(signature.SharedAccessKey), "The key name should match.");
            Assert.That(provider.SharedAccessSignature.SignatureExpiration, Is.EqualTo(signature.SignatureExpiration), "The expiration should match.");
            Assert.That(provider.SharedAccessSignature.Value, Is.EqualTo(signature.Value), "The value should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneSharedAccessTokenProvider.GetTokenAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetTokenAsyncRequiresTheResource()
        {
            var signature = new SharedAccessSignature("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&skn=keykeykey", "ABC123");
            var provider = new TrackOneSharedAccessTokenProvider(signature);

            Assert.That(async () => await provider.GetTokenAsync(null, TimeSpan.FromHours(4)), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneSharedAccessTokenProvider.GetTokenAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetTokenAsyncValidatesTheDuration()
        {
            var signature = new SharedAccessSignature("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&skn=keykeykey", "ABC123");
            var provider = new TrackOneSharedAccessTokenProvider(signature);

            Assert.That(async () => await provider.GetTokenAsync(signature.Resource, TimeSpan.FromMilliseconds(-1)), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneSharedAccessTokenProvider.GetTokenAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase("amqps://my.eventhubs.com")]
        [TestCase("amqps://my.eventhubs.com/otherHub")]
        [TestCase("amqps://other.eventhubs.com/someHub")]
        [TestCase("https://my.eventhubs.com/someHub")]
        public void GetTokenAsyncDisallowsInvalideResources(string invalidResource)
        {
            var resource = WebUtility.UrlEncode("amqps://my.eventhubs.com/someHub");
            var signature = new SharedAccessSignature($"SharedAccessSignature sr={ resource }&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&skn=keykeykey", "ABC123");
            var provider = new TrackOneSharedAccessTokenProvider(signature);

            Assert.That(async () => await provider.GetTokenAsync(invalidResource, TimeSpan.FromHours(4)), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneSharedAccessTokenProvider.GetTokenAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase("amqps://my.eventhubs.com/someHub")]
        [TestCase("amqps://my.eventhubs.com/someHub/partition")]
        [TestCase("amqps://my.eventhubs.com/someHub/partition/0")]
        [TestCase("amqps://my.eventhubs.com/someHub/management")]
        public void GetTokenAsyncAllowsValidResources(string validResource)
        {
            var resource = WebUtility.UrlEncode("amqps://my.eventhubs.com/someHub");
            var signature = new SharedAccessSignature($"SharedAccessSignature sr={ resource }&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&skn=keykeykey", "ABC123");
            var provider = new TrackOneSharedAccessTokenProvider(signature);

            Assert.That(async () => await provider.GetTokenAsync(validResource, TimeSpan.FromHours(4)), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneSharedAccessTokenProvider.GetTokenAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetTokenAsyncProducesASharedAccessSignatureToken()
        {
            var signature = new SharedAccessSignature("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&skn=keykeykey", "ABC123");
            var provider = new TrackOneSharedAccessTokenProvider(signature);
            var token = await provider.GetTokenAsync(signature.Resource, TimeSpan.FromHours(1));

            Assert.That(token, Is.Not.Null, "A token should have been produced.");
            Assert.That(token, Is.InstanceOf<TrackOneSharedAccessSignatureToken>(), "The token should be a SAS token.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneSharedAccessTokenProvider.GetTokenAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetTokenAsyncProducesTokenForTheResource()
        {
            var signature = new SharedAccessSignature("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&skn=keykeykey", "ABC123");
            var provider = new TrackOneSharedAccessTokenProvider(signature);
            var token = await provider.GetTokenAsync(signature.Resource, TimeSpan.FromHours(1));

            Assert.That(token, Is.Not.Null, "A token should have been produced.");
            Assert.That(token.Audience, Is.EqualTo(signature.Resource), "The audience of the token should match the signature.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneSharedAccessTokenProvider.GetTokenAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetTokenAsyncProducesTokenWithCorrectExpiration()
        {
            var signature = new SharedAccessSignature("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&skn=keykeykey", "ABC123");
            var provider = new TrackOneSharedAccessTokenProvider(signature);
            var duration = TimeSpan.FromHours(1.5);
            var expiration = DateTime.UtcNow.Add(duration);
            var token = await provider.GetTokenAsync(signature.Resource, duration);

            Assert.That(token, Is.Not.Null, "A token should have been produced.");
            Assert.That(token.ExpiresAtUtc, Is.EqualTo(expiration).Within(TimeSpan.FromSeconds(5)), "The expiration of the token should match the requested duration.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneSharedAccessTokenProvider.GetTokenAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetTokenAsyncTokensChangeOnEachIssue()
        {
            var signature = new SharedAccessSignature("SharedAccessSignature sr=amqps%3A%2F%2Fmy.eh.com%2Fsomepath%2F&sig=%2BLsuqDlN8Us5lp%2FGdyEUMnU1XA4HdXx%2BJUdtkRNr7qI%3D&se=1562258488&skn=keykeykey", "ABC123");
            var provider = new TrackOneSharedAccessTokenProvider(signature);
            var first = await provider.GetTokenAsync(signature.Resource, TimeSpan.FromHours(1));
            var second = await provider.GetTokenAsync(signature.Resource, TimeSpan.FromMinutes(10));

            Assert.That(first.TokenValue, Is.Not.EqualTo(second.TokenValue));
        }
    }
}
