// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Authorization;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="SharedAccessSignatureCredential" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class SharedAccessSignatureCredentialTests
    {
        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheSignature()
        {
            Assert.That(() => new SharedAccessSignatureCredential(null), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesInitializesProperties()
        {
            var expiration = DateTime.UtcNow;
            var audience = "the-audience";
            var value = "TOkEn!";
            var signature = new SettablePropertiesMock("keyName", "key", expiration, audience, value);
            var credential = new SharedAccessSignatureCredential(signature);

            Assert.That(credential.SharedAccessSignature, Is.SameAs(signature), "The credential should allow the signature to be accessed.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void GetTokenReturnsTheSignatureValue()
        {
            var value = "TOkEn!";
            var signature = new SettablePropertiesMock(value: value);
            var credential = new SharedAccessSignatureCredential(signature);

            Assert.That(credential.GetToken(null, default), Is.SameAs(signature.Value), "The credential should return the signature as the token.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void GetTokenIgnoresScopeAndCancellationToken()
        {
            var value = "TOkEn!";
            var signature = new SettablePropertiesMock(value: value);
            var credential = new SharedAccessSignatureCredential(signature);

            Assert.That(credential.GetToken(new[] { "test", "this" }, CancellationToken.None), Is.SameAs(signature.Value), "The credential should return the signature as the token.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public async Task GetTokenAsyncReturnsTheSignatureValue()
        {
            var value = "TOkEn!";
            var signature = new SettablePropertiesMock(value: value);
            var credential = new SharedAccessSignatureCredential(signature);
            var cancellation = new CancellationTokenSource();
            var token = await credential.GetTokenAsync(null, cancellation.Token);

            Assert.That(token, Is.SameAs(signature.Value), "The credential should return the signature as the token.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public async Task GetTokenAsyncIgnoresScopeAndCancellationToken()
        {
            var value = "TOkEn!";
            var signature = new SettablePropertiesMock(value: value);
            var credential = new SharedAccessSignatureCredential(signature);
            var cancellation = new CancellationTokenSource();
            var token = await credential.GetTokenAsync(new string[0], cancellation.Token);

            Assert.That(token, Is.SameAs(signature.Value), "The credential should return the signature as the token.");
        }

        /// <summary>
        ///   Allows for the properties of the shared access signature to be manually set for
        ///   testing purposes.
        /// </summary>
        ///
        private class SettablePropertiesMock : SharedAccessSignature
        {
            public SettablePropertiesMock(string sharedAccessKeyName = default,
                                          string sharedAccessKey = default,
                                          DateTime expirationUtc = default,
                                          string resource = default,
                                          string value = default) : base()
            {
                SharedAccessKeyName = sharedAccessKeyName;
                SharedAccessKey = sharedAccessKey;
                ExpirationUtc = expirationUtc;
                Resource = resource;
                Value = value;
            }
        }
    }
}
