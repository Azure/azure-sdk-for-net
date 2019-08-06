// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Messaging.EventHubs.Compatibility;
using Moq;
using NUnit.Framework;
using TrackOne;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="TrackOneGenericToken" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class TrackOneGenericTokenTokenTests
    {
        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheCredential()
        {
            Assert.That(() => new TrackOneGenericToken(null, "fakeToken", "fakeResource", DateTime.Parse("2015-10-27T12:00:00Z").ToUniversalTime()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheJwtToken(string token)
        {
            Assert.That(() => new TrackOneGenericToken(Mock.Of<TokenCredential>(), token, "fakeResource", DateTime.Parse("2015-10-27T12:00:00Z").ToUniversalTime()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheResource(string resource)
        {
            Assert.That(() => new TrackOneGenericToken(Mock.Of<TokenCredential>(), "fakeToken", resource, DateTime.Parse("2015-10-27T12:00:00Z").ToUniversalTime()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesInitializesProperties()
        {
            var expiration = DateTime.Parse("2015-10-27T12:00:00Z").ToUniversalTime();
            var resource = "the-audience";
            var jwtToken = "TOkEn!";
            var credential = Mock.Of<TokenCredential>();
            var token = new TrackOneGenericToken(credential, jwtToken, resource, expiration);

            Assert.That(token.Audience, Is.EqualTo(resource), "The audience for the token should match.");
            Assert.That(token.TokenValue, Is.EqualTo(jwtToken), "The JWT token value should match.");
            Assert.That(token.Credential, Is.EqualTo(credential), "The credential should match.");
            Assert.That(token.ExpiresAtUtc, Is.EqualTo(expiration), "The expiration should match.");
            Assert.That(token.TokenType, Is.EqualTo(ClientConstants.JsonWebTokenType), "The token type should identify a generic JWT.");
        }
    }
}
