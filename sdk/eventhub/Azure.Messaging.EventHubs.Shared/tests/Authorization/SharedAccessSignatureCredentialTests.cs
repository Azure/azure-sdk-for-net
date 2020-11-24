// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
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
        public void ConstructorInitializesProperties()
        {
            var value = "TOkEn!";
            var signature = new SharedAccessSignature("hub-name", "keyName", "key", value, DateTimeOffset.UtcNow.AddHours(4));
            var credential = new SharedAccessSignatureCredential(signature);

            Assert.That(GetSharedAccessSignature(credential), Is.SameAs(signature), "The credential should allow the signature to be accessed.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="SharedAccessSignatureCredential.GetToken" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetTokenReturnsTheSignatureValue()
        {
            var value = "TOkEn!";
            var signature = new SharedAccessSignature("hub-name", "keyName", "key", value, DateTimeOffset.UtcNow.AddHours(4));
            var credential = new SharedAccessSignatureCredential(signature);

            Assert.That(credential.GetToken(new TokenRequestContext(), default).Token, Is.SameAs(signature.Value), "The credential should return the signature as the token.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="SharedAccessSignatureCredential.GetToken" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetTokenIgnoresScopeAndCancellationToken()
        {
            var value = "TOkEn!";
            var signature = new SharedAccessSignature("hub-name", "keyName", "key", value, DateTimeOffset.UtcNow.AddHours(4));
            var credential = new SharedAccessSignatureCredential(signature);

            Assert.That(credential.GetToken(new TokenRequestContext(new[] { "test", "this" }), CancellationToken.None).Token, Is.SameAs(signature.Value), "The credential should return the signature as the token.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="SharedAccessSignatureCredential.GetToken" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetTokenAsyncReturnsTheSignatureValue()
        {
            var value = "TOkEn!";
            var signature = new SharedAccessSignature("hub-name", "keyName", "key", value, DateTimeOffset.UtcNow.AddHours(4));
            var credential = new SharedAccessSignatureCredential(signature);
            var cancellation = new CancellationTokenSource();
            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(), cancellation.Token);

            Assert.That(token.Token, Is.SameAs(signature.Value), "The credential should return the signature as the token.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="SharedAccessSignatureCredential.GetToken" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetTokenAsyncIgnoresScopeAndCancellationToken()
        {
            var value = "TOkEn!";
            var signature = new SharedAccessSignature("hub-name", "keyName", "key", value, DateTimeOffset.UtcNow.AddHours(4));
            var credential = new SharedAccessSignatureCredential(signature);
            var cancellation = new CancellationTokenSource();
            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(new string[0]), cancellation.Token);

            Assert.That(token.Token, Is.SameAs(signature.Value), "The credential should return the signature as the token.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="SharedAccessSignatureCredential.GetToken" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetTokenExtendsAnExpiredTokenWhenCreatedWithTheSharedKey()
        {
            var value = "TOkEn!";
            var signature = new SharedAccessSignature("hub-name", "keyName", "key", value, DateTimeOffset.UtcNow.Subtract(TimeSpan.FromHours(2)));
            var credential = new SharedAccessSignatureCredential(signature);

            var expectedExpiration = DateTimeOffset.Now.Add(GetSignatureExtensionDuration());
            Assert.That(credential.GetToken(new TokenRequestContext(), default).ExpiresOn, Is.EqualTo(expectedExpiration).Within(TimeSpan.FromMinutes(1)));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="SharedAccessSignatureCredential.GetToken" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetTokenExtendsATokenCloseToExpiringWhenCreatedWithTheSharedKey()
        {
            var value = "TOkEn!";
            var tokenExpiration = DateTimeOffset.UtcNow.Add(TimeSpan.FromSeconds(GetSignatureRefreshBuffer().TotalSeconds / 2));
            var signature = new SharedAccessSignature("hub-name", "keyName", "key", value, tokenExpiration);
            var credential = new SharedAccessSignatureCredential(signature);

            var expectedExpiration = DateTimeOffset.Now.Add(GetSignatureExtensionDuration());
            Assert.That(credential.GetToken(new TokenRequestContext(), default).ExpiresOn, Is.EqualTo(expectedExpiration).Within(TimeSpan.FromMinutes(1)));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="SharedAccessSignatureCredential.GetToken" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetTokenDoesNotExtendAnExpiredTokenWhenCreatedWithoutTheKey()
        {
            var expectedExpiration = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromHours(2));
            var value = $"SharedAccessSignature sr=https%3A%2F%2Ffake-test.servicebus.windows.net%2F&sig=nNBNavJfBiHuXUzWOLhSvI3bVgqbQUzA7Po8%2F4wQQng%3D&se={ ToUnixTime(expectedExpiration) }&skn=fakeKey";
            var sourceSignature = new SharedAccessSignature("fake-test", "fakeKey", "ABC123", value, expectedExpiration).Value;
            var signature = new SharedAccessSignature(sourceSignature);
            var credential = new SharedAccessSignatureCredential(signature);

            Assert.That(credential.GetToken(new TokenRequestContext(), default).ExpiresOn, Is.EqualTo(expectedExpiration).Within(TimeSpan.FromMinutes(1)));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="SharedAccessSignatureCredential.GetToken" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetTokenDoesNotExtendATokenCloseToExpiringWhenCreatedWithoutTheKey()
        {
            var tokenExpiration = DateTimeOffset.UtcNow.Add(TimeSpan.FromSeconds(GetSignatureRefreshBuffer().TotalSeconds / 2));
            var value = $"SharedAccessSignature sr=https%3A%2F%2Ffake-test.servicebus.windows.net%2F&sig=nNBNavJfBiHuXUzWOLhSvI3bVgqbQUzA7Po8%2F4wQQng%3D&se={ ToUnixTime(tokenExpiration) }&skn=fakeKey";
            var sourceSignature = new SharedAccessSignature("fake-test", "fakeKey", "ABC123", value, tokenExpiration).Value;
            var signature = new SharedAccessSignature(sourceSignature);
            var credential = new SharedAccessSignatureCredential(signature);

            Assert.That(credential.GetToken(new TokenRequestContext(), default).ExpiresOn, Is.EqualTo(tokenExpiration).Within(TimeSpan.FromMinutes(1)));
        }

        /// <summary>
        ///   Verifies that a signature can be rotated without refreshing its validity.
        /// </summary>
        ///
        [Test]
        public void SharedAccessKeyCanBeUpdated()
        {
            var value = "TOkEn!";
            var tokenExpiration = DateTimeOffset.UtcNow.Add(TimeSpan.FromSeconds(GetSignatureRefreshBuffer().TotalSeconds / 2));
            var signature = new SharedAccessSignature("hub-name", "keyName", "key", value, tokenExpiration);
            var credential = new SharedAccessSignatureCredential(signature);

            credential.UpdateSharedAccessKey("new-key-name", "new-key");

            var newSignature = GetSharedAccessSignature(credential);

            Assert.That(newSignature.SharedAccessKeyName, Is.EqualTo("new-key-name"));
            Assert.That(newSignature.SharedAccessKey, Is.EqualTo("new-key"));
            Assert.That(newSignature.SignatureExpiration, Is.EqualTo(signature.SignatureExpiration));
        }

        /// <summary>
        ///   Verifies that a signature can be rotated without refreshing its validity.
        /// </summary>
        ///
        [Test]
        public void SharedAccesSignatureCanBeUpdated()
        {
            var tokenExpiration = TimeSpan.FromSeconds(GetSignatureRefreshBuffer().TotalSeconds / 2);
            var signature = new SharedAccessSignature("hub-name", "keyName", "key", tokenExpiration);
            var updatedSignature = new SharedAccessSignature("hub-name", "newKeyName", "newKey", tokenExpiration.Add(TimeSpan.FromMinutes(30)));
            var credential = new SharedAccessSignatureCredential(signature);

            credential.UpdateSharedAccessSignature(updatedSignature.Value);

            var newSignature = GetSharedAccessSignature(credential);

            Assert.That(newSignature.Value, Is.EqualTo(updatedSignature.Value));
            Assert.That(newSignature.SharedAccessKeyName, Is.EqualTo(updatedSignature.SharedAccessKeyName));
            Assert.That(newSignature.SharedAccessKey, Is.Null);
            Assert.That(newSignature.SignatureExpiration, Is.EqualTo(updatedSignature.SignatureExpiration).Within(TimeSpan.FromSeconds(5)));
        }

        /// <summary>
        ///   Converts a <see cref="DateTimeOffset" /> value to the corresponding Unix-style time stamp.
        /// </summary>
        ///
        /// <param name="timestamp">The date/time to convert.</param>
        ///
        /// <returns>The Unix-style times tamp which corresponds to the specified date/time.</returns>
        ///
        private static long ToUnixTime(DateTimeOffset timestamp) =>
            Convert.ToInt64((timestamp - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        /// <summary>
        ///   Retrieves the shared access signature from the credential using its private accessor.
        /// </summary>
        ///
        /// <param name="instance">The instance to retrieve the key from.</param>
        ///
        /// <returns>The shared access key</returns>
        ///
        private static SharedAccessSignature GetSharedAccessSignature(SharedAccessSignatureCredential instance) =>
            (SharedAccessSignature)
                typeof(SharedAccessSignatureCredential)
                .GetProperty("SharedAccessSignature", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(instance, null);

        /// <summary>
        ///   Gets the refresh buffer for the <see cref="SharedAccessSignatureCredential" /> using
        ///   its private field.
        /// </summary>
        ///
        private static TimeSpan GetSignatureRefreshBuffer() =>
            (TimeSpan)
                typeof(SharedAccessSignatureCredential)
                    .GetField("SignatureRefreshBuffer", BindingFlags.Static | BindingFlags.NonPublic)
                    .GetValue(null);

        /// <summary>
        ///   Gets the extension duration for the <see cref="SharedAccessSignatureCredential" /> using
        ///   its private field.
        /// </summary>
        ///
        private static TimeSpan GetSignatureExtensionDuration() =>
            (TimeSpan)
                typeof(SharedAccessSignatureCredential)
                    .GetField("SignatureExtensionDuration", BindingFlags.Static | BindingFlags.NonPublic)
                    .GetValue(null);
    }
}
