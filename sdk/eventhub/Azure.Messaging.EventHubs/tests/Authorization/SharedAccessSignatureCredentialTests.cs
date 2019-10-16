// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
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
            var value = "TOkEn!";
            var signature = new SharedAccessSignature(string.Empty, "keyName", "key", value, DateTimeOffset.UtcNow.AddHours(4));
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
            var signature = new SharedAccessSignature(string.Empty, "keyName", "key", value, DateTimeOffset.UtcNow.AddHours(4));
            var credential = new SharedAccessSignatureCredential(signature);

            Assert.That(credential.GetToken(new TokenRequestContext(), default).Token, Is.SameAs(signature.Value), "The credential should return the signature as the token.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void GetTokenIgnoresScopeAndCancellationToken()
        {
            var value = "TOkEn!";
            var signature = new SharedAccessSignature(string.Empty, "keyName", "key", value, DateTimeOffset.UtcNow.AddHours(4));
            var credential = new SharedAccessSignatureCredential(signature);

            Assert.That(credential.GetToken(new TokenRequestContext(new[] { "test", "this" }), CancellationToken.None).Token, Is.SameAs(signature.Value), "The credential should return the signature as the token.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public async Task GetTokenAsyncReturnsTheSignatureValue()
        {
            var value = "TOkEn!";
            var signature = new SharedAccessSignature(string.Empty, "keyName", "key", value, DateTimeOffset.UtcNow.AddHours(4));
            var credential = new SharedAccessSignatureCredential(signature);
            var cancellation = new CancellationTokenSource();
            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(), cancellation.Token);

            Assert.That(token.Token, Is.SameAs(signature.Value), "The credential should return the signature as the token.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public async Task GetTokenAsyncIgnoresScopeAndCancellationToken()
        {
            var value = "TOkEn!";
            var signature = new SharedAccessSignature(string.Empty, "keyName", "key", value, DateTimeOffset.UtcNow.AddHours(4));
            var credential = new SharedAccessSignatureCredential(signature);
            var cancellation = new CancellationTokenSource();
            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(new string[0]), cancellation.Token);

            Assert.That(token.Token, Is.SameAs(signature.Value), "The credential should return the signature as the token.");
        }
    }
}
