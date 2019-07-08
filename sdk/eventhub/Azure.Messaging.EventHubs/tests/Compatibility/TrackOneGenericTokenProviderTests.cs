// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Compatibility;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="TrackOneGenericTokenProvider" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    [Parallelizable(ParallelScope.Children)]
    public class TrackOneGenericTokenProviderTests
    {
        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheCredential()
        {
            Assert.That(() => new TrackOneGenericTokenProvider(null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneGenericTokenProvider.GetTokenAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetTokenAsyncRequiresTheResource()
        {
            var token = new EventHubTokenCredential(Mock.Of<TokenCredential>(), "someResource");
            var provider = new TrackOneGenericTokenProvider(token);

            Assert.That(async () => await provider.GetTokenAsync(null, TimeSpan.FromHours(4)), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneGenericTokenProvider.GetTokenAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetTokenAsyncValidatesTheDuration()
        {
            var eventHubCredential = new EventHubTokenCredential(Mock.Of<TokenCredential>(), "someResource");
            var provider = new TrackOneGenericTokenProvider(eventHubCredential);

            Assert.That(async () => await provider.GetTokenAsync(eventHubCredential.Resource, TimeSpan.FromMilliseconds(-1)), Throws.InstanceOf<ArgumentException>());
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
            var mockCredential = new Mock<TokenCredential>();
            var resource = "amqps://my.eventhubs.com/someHub";
            var jwtToken = "somevalue";
            var expiration = DateTimeOffset.Parse("2017-10-27T12:00:00Z");
            var accessToken = new AccessToken(jwtToken, expiration);
            var eventHubCredential = new EventHubTokenCredential(mockCredential.Object, resource);
            var provider = new TrackOneGenericTokenProvider(eventHubCredential);

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.IsAny<string[]>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(accessToken);

            Assert.That(async () => await provider.GetTokenAsync(invalidResource, TimeSpan.FromHours(4)), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneGenericTokenProvider.GetTokenAsync" />
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
            var mockCredential = new Mock<TokenCredential>();
            var resource = "amqps://my.eventhubs.com/someHub";
            var jwtToken = "somevalue";
            var expiration = DateTimeOffset.Parse("2017-10-27T12:00:00Z");
            var accessToken = new AccessToken(jwtToken, expiration);
            var eventHubCredential = new EventHubTokenCredential(mockCredential.Object, resource);
            var provider = new TrackOneGenericTokenProvider(eventHubCredential);

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.Is<string[]>(value => value.FirstOrDefault() == GetTokenScope()), It.IsAny<CancellationToken>()))
                .ReturnsAsync(accessToken);

            Assert.That(async () => await provider.GetTokenAsync(validResource, TimeSpan.FromHours(4)), Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneGenericTokenProvider.GetTokenAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetTokenAsyncProducesAGenericToken()
        {
            var mockCredential = new Mock<TokenCredential>();
            var resource = "amqps://my.eventhubs.com/someHub";
            var jwtToken = "somevalue";
            var expiration = DateTimeOffset.Parse("2017-10-27T12:00:00Z");
            var accessToken = new AccessToken(jwtToken, expiration);
            var eventHubCredential = new EventHubTokenCredential(mockCredential.Object, resource);
            var provider = new TrackOneGenericTokenProvider(eventHubCredential);

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.Is<string[]>(value => value.FirstOrDefault() == GetTokenScope()), It.IsAny<CancellationToken>()))
                .ReturnsAsync(accessToken);

            var token = await provider.GetTokenAsync(resource, TimeSpan.FromHours(1));

            Assert.That(token, Is.Not.Null, "A token should have been produced.");
            Assert.That(token, Is.InstanceOf<TrackOneGenericToken>(), "The token should be a generic JWT token.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneGenericTokenProvider.GetTokenAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetTokenAsyncProducesATokenwithTheCorrectProperties()
        {
            var mockCredential = new Mock<TokenCredential>();
            var resource = "amqps://my.eventhubs.com/someHub";
            var jwtToken = "somevalue";
            var expiration = DateTimeOffset.Parse("2017-10-27T12:00:00Z");
            var accessToken = new AccessToken(jwtToken, expiration);
            var eventHubCredential = new EventHubTokenCredential(mockCredential.Object, resource);
            var provider = new TrackOneGenericTokenProvider(eventHubCredential);

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.Is<string[]>(value => value.FirstOrDefault() == GetTokenScope()), It.IsAny<CancellationToken>()))
                .ReturnsAsync(accessToken);

            var token = await provider.GetTokenAsync(resource, TimeSpan.FromHours(1));

            Assert.That(token, Is.Not.Null, "A token should have been produced.");
            Assert.That(token.TokenValue, Is.EqualTo(jwtToken), "The JWT token should match.");
            Assert.That(token.Audience, Is.EqualTo(resource), "The audience should match the resource.");
            Assert.That(token.ExpiresAtUtc, Is.EqualTo(expiration.UtcDateTime), "The token expiration should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="TrackOneGenericTokenProvider.GetTokenAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetTokenAsyncTokensChangeOnEachIssue()
        {
            var mockCredential = new Mock<TokenCredential>();
            var resource = "amqps://my.eventhubs.com/someHub";
            var jwtToken = "somevalue";
            var expiration = DateTimeOffset.Parse("2017-10-27T12:00:00Z");
            var accessToken = new AccessToken(jwtToken, expiration);
            var eventHubCredential = new EventHubTokenCredential(mockCredential.Object, resource);
            var provider = new TrackOneGenericTokenProvider(eventHubCredential);

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.Is<string[]>(value => value.FirstOrDefault() == GetTokenScope()), It.IsAny<CancellationToken>()))
                .ReturnsAsync(accessToken);

            var first = await provider.GetTokenAsync(resource, TimeSpan.FromHours(1));
            var second = await provider.GetTokenAsync(resource, TimeSpan.FromHours(4));

            Assert.That(first, Is.Not.SameAs(second), "A new token should be created for each request.");
            Assert.That(((TrackOneGenericToken)first).Credential, Is.SameAs(((TrackOneGenericToken)second).Credential), "The token should be based on the same source credential.");
        }

        /// <summary>
        ///   Gets the first scope used for requesting tokens.
        /// </summary>
        ///
        /// <returns>The scope used for requesting tokens.</returns>
        ///
        private static string GetTokenScope() =>
            ((string[])typeof(TrackOneGenericTokenProvider)
                .GetField("EventHubsDefaultScopes", BindingFlags.Static | BindingFlags.NonPublic)
                .GetValue(null))
                .First();

    }
}
