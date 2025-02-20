// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Amqp;
using Azure.Messaging.ServiceBus.Authorization;
using Microsoft.Azure.Amqp;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="CbsTokenProvider" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class CbsTokenProviderTests
    {
        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesCredential()
        {
            Assert.That(() => new CbsTokenProvider(null, TimeSpan.Zero, CancellationToken.None), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesExpirationBuffer()
        {
            var mockCredential = new Mock<TokenCredential>();
            var credential = new ServiceBusTokenCredential(mockCredential.Object);
            Assert.That(() => new CbsTokenProvider(credential, TimeSpan.FromMilliseconds(-1), CancellationToken.None), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="CbsTokenProvider.GetTokenAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetTokenAsyncPopulatesUsingTheCredentialAccessToken()
        {
            var tokenValue = "ValuE_oF_tHE_tokEn";
            var expires = DateTimeOffset.Parse("2015-10-27T00:00:00Z");
            var mockCredential = new Mock<TokenCredential>();
            var credential = new ServiceBusTokenCredential(mockCredential.Object);

            using var provider = new CbsTokenProvider(credential, TimeSpan.Zero, default);

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                .Returns(new ValueTask<AccessToken>(new AccessToken(tokenValue, expires)));

            var cbsToken = await provider.GetTokenAsync(new Uri("http://www.here.com"), "nobody", new string[0]);

            Assert.That(cbsToken, Is.Not.Null, "The token should have been produced");
            Assert.That(cbsToken.TokenValue, Is.EqualTo(tokenValue), "The token value should match");
            Assert.That(cbsToken.ExpiresAtUtc, Is.EqualTo(expires.DateTime), "The token expiration should match");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="CbsTokenProvider.GetTokenAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetTokenAsyncSetsTheCorrectTypeForSharedAccessTokens()
        {
            var value = "TOkEn!";
            var signature = new SharedAccessSignature("hub", "keyName", "key", value, DateTimeOffset.Parse("2015-10-27T00:00:00Z"));
            var sasCredential = new SharedAccessCredential(signature);
            var credential = new ServiceBusTokenCredential(sasCredential);

            using var provider = new CbsTokenProvider(credential, TimeSpan.Zero, default);

            var cbsToken = await provider.GetTokenAsync(new Uri("http://www.here.com"), "nobody", new string[0]);

            Assert.That(cbsToken, Is.Not.Null, "The token should have been produced");
            Assert.That(cbsToken.TokenType, Is.EqualTo(GetSharedAccessTokenType()), "The token type should match");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="CbsTokenProvider.GetTokenAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetTokenAsyncSetsTheCorrectTypeForOtherTokens()
        {
            var tokenValue = "ValuE_oF_tHE_tokEn";
            var expires = DateTimeOffset.Parse("2015-10-27T00:00:00Z");
            var mockCredential = new Mock<TokenCredential>();
            var credential = new ServiceBusTokenCredential(mockCredential.Object);

            using var provider = new CbsTokenProvider(credential, TimeSpan.Zero, default);

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                .Returns(new ValueTask<AccessToken>(new AccessToken(tokenValue, expires)));

            var cbsToken = await provider.GetTokenAsync(new Uri("http://www.here.com"), "nobody", new string[0]);

            Assert.That(cbsToken, Is.Not.Null, "The token should have been produced");
            Assert.That(cbsToken.TokenType, Is.EqualTo(GetGenericTokenType()), "The token type should match");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="CbsTokenProvider.GetTokenAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetTokenAsyncRespectsCacheForJwtTokens()
        {
            var tokenValue = "ValuE_oF_tHE_tokEn";
            var expires = DateTimeOffset.UtcNow.AddDays(1);
            var mockCredential = new Mock<TokenCredential>();
            var credential = new ServiceBusTokenCredential(mockCredential.Object);

            using var provider = new CbsTokenProvider(credential, TimeSpan.Zero, default);

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                .Returns(new ValueTask<AccessToken>(new AccessToken(tokenValue, expires)));

            var firstCallToken = await provider.GetTokenAsync(new Uri("http://www.here.com"), "nobody", new string[0]);
            var nextCallToken = await provider.GetTokenAsync(new Uri("http://www.here.com"), "nobody", new string[0]);

            Assert.That(firstCallToken, Is.Not.Null, "The first call token should have been produced.");
            Assert.That(nextCallToken, Is.Not.Null, "The next call token should have been produced.");
            Assert.That(firstCallToken, Is.SameAs(nextCallToken), "The same token instance should have been returned for both calls.");

            mockCredential
                .Verify(credential => credential.GetTokenAsync(
                    It.IsAny<TokenRequestContext>(),
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="CbsTokenProvider.GetTokenAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetTokenAsyncRespectsExpirationBufferForJwtTokens()
        {
            var tokenValue = "ValuE_oF_tHE_tokEn";
            var buffer = TimeSpan.FromMinutes(5);
            var expires = DateTimeOffset.UtcNow.Subtract(buffer).AddSeconds(-10);
            var mockCredential = new Mock<TokenCredential>();
            var credential = new ServiceBusTokenCredential(mockCredential.Object);

            using var provider = new CbsTokenProvider(credential, TimeSpan.Zero, default);

            mockCredential
                .Setup(credential => credential.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                .Returns(new ValueTask<AccessToken>(new AccessToken(tokenValue, expires)));

            var firstCallToken = await provider.GetTokenAsync(new Uri("http://www.here.com"), "nobody", new string[0]);
            var nextCallToken = await provider.GetTokenAsync(new Uri("http://www.here.com"), "nobody", new string[0]);

            Assert.That(firstCallToken, Is.Not.Null, "The first call token should have been produced.");
            Assert.That(nextCallToken, Is.Not.Null, "The next call token should have been produced.");
            Assert.That(firstCallToken, Is.Not.SameAs(nextCallToken), "The token should have been expired and returned two unique instances.");

            mockCredential
                .Verify(credential => credential.GetTokenAsync(
                    It.IsAny<TokenRequestContext>(),
                    It.IsAny<CancellationToken>()),
                Times.Exactly(2));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="CbsTokenProvider.GetTokenAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetTokenAsyncDoesNotCacheSharedAccessCredential()
        {
            var value = "TOkEn!";
            var signature = new SharedAccessSignature("hub-name", "keyName", "key", value, DateTimeOffset.UtcNow.AddHours(4));
            var mockCredential = new Mock<SharedAccessCredential>(signature) { CallBase = true };
            var credential = new ServiceBusTokenCredential(mockCredential.Object);

            using var provider = new CbsTokenProvider(credential, TimeSpan.Zero, default);

            var firstCallToken = await provider.GetTokenAsync(new Uri("http://www.here.com"), "nobody", new string[0]);
            var nextCallToken = await provider.GetTokenAsync(new Uri("http://www.here.com"), "nobody", new string[0]);

            Assert.That(firstCallToken, Is.Not.Null, "The first call token should have been produced.");
            Assert.That(nextCallToken, Is.Not.Null, "The next call token should have been produced.");
            Assert.That(firstCallToken, Is.Not.SameAs(nextCallToken), "The token should have been expired and returned two unique instances.");

            mockCredential
                .Verify(credential => credential.GetTokenAsync(
                    It.IsAny<TokenRequestContext>(),
                    It.IsAny<CancellationToken>()),
                Times.Exactly(2));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="CbsTokenProvider.GetTokenAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetTokenAsyncSynchronizesMultipleRefreshAttemptsForJwtTokens()
        {
            var tokenValue = "ValuE_oF_tHE_tokEn";
            var buffer = TimeSpan.FromMinutes(5);
            var expires = DateTimeOffset.UtcNow.Subtract(buffer).AddSeconds(-10);
            var mockCredential = new Mock<TokenCredential>();
            var credential = new ServiceBusTokenCredential(mockCredential.Object);

            using var provider = new CbsTokenProvider(credential, TimeSpan.Zero, default);

            mockCredential
                .SetupSequence(credential => credential.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                .Returns(new ValueTask<AccessToken>(new AccessToken(tokenValue, expires)))
                .Returns(new ValueTask<AccessToken>(new AccessToken(tokenValue, DateTimeOffset.UtcNow.AddDays(1))));

            var firstCallToken = await provider.GetTokenAsync(new Uri("http://www.here.com"), "nobody", new string[0]);
            Assert.That(firstCallToken, Is.Not.Null, "The first call token should have been produced.");

            var otherTokens = await Task.WhenAll(
                Enumerable.Range(0, 25)
                    .Select(index => provider.GetTokenAsync(new Uri("http://www.here.com"), "nobody", new string[0])));

            for (var index = 0; index < otherTokens.Length; ++index)
            {
                Assert.That(otherTokens[index], Is.Not.Null, $"The token at index `{ index }` should have been produced.");
                Assert.That(firstCallToken, Is.Not.SameAs(otherTokens[index]), $"The token at index `{ index } ` should not have matched the first call instance.");

                if (index > 0)
                {
                    Assert.That(otherTokens[0], Is.SameAs(otherTokens[index]), $"The other tokens should all be the same instance.  The token at index `{ index } ` did not match index `0`.");
                }
            }

            mockCredential
                .Verify(credential => credential.GetTokenAsync(
                    It.IsAny<TokenRequestContext>(),
                    It.IsAny<CancellationToken>()),
                Times.Exactly(2));
        }

        /// <summary>
        ///   Gets the token type used for SAS-based credentials, using the
        ///   private field of the provider.
        /// </summary>
        ///
        private static string GetSharedAccessTokenType() =>
                    (string)typeof(CbsTokenProvider)
                        .GetField("SharedAccessTokenType", BindingFlags.Static | BindingFlags.NonPublic)
                        .GetValue(null);

        /// <summary>
        ///   Gets the token type used for generic token-based credentials, using the
        ///   private field of the provider.
        /// </summary>
        ///
        private static string GetGenericTokenType() =>
                    (string)typeof(CbsTokenProvider)
                        .GetField("JsonWebTokenType", BindingFlags.Static | BindingFlags.NonPublic)
                        .GetValue(null);
    }
}
