// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Compatibility;
using NUnit.Framework;
using TrackOne;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="TrackOneSharedAccessSignatureToken" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class TrackOneSharedAccessSignatureTokenTests
    {
        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheSignature()
        {
            Assert.That(() => new TrackOneSharedAccessSignatureToken(null), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheSignatureValue()
        {
            var signature = new SharedAccessSignature("audience", "keyName", "key", null, DateTimeOffset.UtcNow);
            Assert.That(() => new TrackOneSharedAccessSignatureToken(signature), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheSignatureResource()
        {
            var signature = new SharedAccessSignature(string.Empty, "keyName", "key", string.Empty, DateTimeOffset.UtcNow);
            Assert.That(() => new TrackOneSharedAccessSignatureToken(signature), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesInitializesProperties()
        {
            DateTimeOffset expiration = DateTimeOffset.UtcNow;
            var audience = "the-audience";
            var value = "TOkEn!";
            var signature = new SharedAccessSignature(audience, "keyName", "key", value, expiration);
            var token = new TrackOneSharedAccessSignatureToken(signature);

            Assert.That(token.Audience, Is.EqualTo(audience), "The audience for the token should match the signature resource.");
            Assert.That(token.TokenValue, Is.EqualTo(value), "The value for the token should match the signature value.");
            Assert.That(token.ExpiresAtUtc, Is.EqualTo(expiration.UtcDateTime), "The expiration for the token should match the signature expiration.");
            Assert.That(token.TokenType, Is.EqualTo(ClientConstants.SasTokenType), "The type for the token should match the expected constant.");
        }
    }
}
