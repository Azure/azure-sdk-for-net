// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.ServiceBus.Authorization;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="SharedAccessCredential" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class SharedAccessCredentialTests
    {
        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void SignatureConstructorValidatesTheSignature()
        {
            Assert.That(() => new SharedAccessCredential(default(SharedAccessSignature)), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void SasCredentialConstructorValidatesTheCredential()
        {
            Assert.That(() => new SharedAccessCredential(default(AzureSasCredential)), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void KeyCredentialConstructorValidatesTheCredential()
        {
            Assert.That(() => new SharedAccessCredential(default(AzureNamedKeyCredential), "fake"), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void KeyCredentialConstructorValidatesTheResource(string resource)
        {
            var credential = new AzureNamedKeyCredential("name", "key");
            Assert.That(() => new SharedAccessCredential(credential, resource), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void SignatureConstructorInitializesProperties()
        {
            var value = "TOkEn!";
            var signature = new SharedAccessSignature("hub-name", "keyName", "key", value, DateTimeOffset.UtcNow.AddHours(4));
            var credential = new SharedAccessCredential(signature);

            Assert.That(GetSharedAccessSignature(credential), Is.SameAs(signature), "The credential should match.");
            Assert.That(GetSourceSasCredential(credential), Is.Null, "The source SAS credential should not be populated.");
            Assert.That(GetSourceKeyCredential(credential), Is.Null, "The source named key credential should not be populated.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void SasConstructorInitializesProperties()
        {
            var signature = new SharedAccessSignature("hub-name", "keyName", "key");
            var sourceCredential = new AzureSasCredential(signature.Value);
            var credential = new SharedAccessCredential(sourceCredential);

            Assert.That(GetSharedAccessSignature(credential).Value, Is.EqualTo(sourceCredential.Signature), "The signature should match the source credential.");
            Assert.That(GetSourceSasCredential(credential), Is.SameAs(sourceCredential), "The source SAS credential should match.");
            Assert.That(GetSourceKeyCredential(credential), Is.Null, "The source named key credential should not be populated.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void KeyConstructorInitializesProperties()
        {
            var signature = new SharedAccessSignature("hub-name", "keyName", "key");
            var sourceCredential = new AzureNamedKeyCredential(signature.SharedAccessKeyName, signature.SharedAccessKey);
            var credential = new SharedAccessCredential(sourceCredential, signature.Resource);
            var credentialSignature = GetSharedAccessSignature(credential);
            var (signatureKeyName, signatureKeyValue) = sourceCredential;

            Assert.That(credentialSignature.SharedAccessKeyName, Is.EqualTo(signatureKeyName), "The shared key name should match the source credential.");
            Assert.That(credentialSignature.SharedAccessKey, Is.EqualTo(signatureKeyValue), "The shared key should match the source credential.");
            Assert.That(GetSourceSasCredential(credential), Is.Null, "The source SAS credential should not be populated.");
            Assert.That(GetSourceKeyCredential(credential), Is.SameAs(sourceCredential), "The source key credential should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="SharedAccessCredential.GetToken" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetTokenReturnsTheSignatureValue()
        {
            var value = "TOkEn!";
            var signature = new SharedAccessSignature("hub-name", "keyName", "key", value, DateTimeOffset.UtcNow.AddHours(4));
            var credential = new SharedAccessCredential(signature);

            Assert.That(credential.GetToken(new TokenRequestContext(), default).Token, Is.SameAs(signature.Value), "The credential should return the signature as the token.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="SharedAccessCredential.GetToken" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetTokenIgnoresScopeAndCancellationToken()
        {
            var value = "TOkEn!";
            var signature = new SharedAccessSignature("hub-name", "keyName", "key", value, DateTimeOffset.UtcNow.AddHours(4));
            var credential = new SharedAccessCredential(signature);

            Assert.That(credential.GetToken(new TokenRequestContext(new[] { "test", "this" }), CancellationToken.None).Token, Is.SameAs(signature.Value), "The credential should return the signature as the token.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="SharedAccessCredential.GetToken" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetTokenAsyncReturnsTheSignatureValue()
        {
            var value = "TOkEn!";
            var signature = new SharedAccessSignature("hub-name", "keyName", "key", value, DateTimeOffset.UtcNow.AddHours(4));
            var credential = new SharedAccessCredential(signature);
            var cancellation = new CancellationTokenSource();
            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(), cancellation.Token);

            Assert.That(token.Token, Is.SameAs(signature.Value), "The credential should return the signature as the token.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="SharedAccessCredential.GetToken" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task GetTokenAsyncIgnoresScopeAndCancellationToken()
        {
            var value = "TOkEn!";
            var signature = new SharedAccessSignature("hub-name", "keyName", "key", value, DateTimeOffset.UtcNow.AddHours(4));
            var credential = new SharedAccessCredential(signature);
            var cancellation = new CancellationTokenSource();
            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(new string[0]), cancellation.Token);

            Assert.That(token.Token, Is.SameAs(signature.Value), "The credential should return the signature as the token.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="SharedAccessCredential.GetToken" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetTokenExtendsAnExpiredTokenWhenCreatedWithTheSharedKey()
        {
            var value = "TOkEn!";
            var signature = new SharedAccessSignature("hub-name", "keyName", "key", value, DateTimeOffset.UtcNow.Subtract(TimeSpan.FromHours(2)));
            var credential = new SharedAccessCredential(signature);

            var expectedExpiration = DateTimeOffset.UtcNow.Add(GetSignatureExtensionDuration());
            Assert.That(credential.GetToken(new TokenRequestContext(), default).ExpiresOn, Is.EqualTo(expectedExpiration).Within(TimeSpan.FromMinutes(1)));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="SharedAccessCredential.GetToken" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void GetTokenExtendsATokenCloseToExpiringWhenCreatedWithTheSharedKey()
        {
            var value = "TOkEn!";
            var tokenExpiration = DateTimeOffset.UtcNow.Add(TimeSpan.FromSeconds(GetSignatureRefreshBuffer().TotalSeconds / 2));
            var signature = new SharedAccessSignature("hub-name", "keyName", "key", value, tokenExpiration);
            var credential = new SharedAccessCredential(signature);

            var expectedExpiration = DateTimeOffset.UtcNow.Add(GetSignatureExtensionDuration());
            Assert.That(credential.GetToken(new TokenRequestContext(), default).ExpiresOn, Is.EqualTo(expectedExpiration).Within(TimeSpan.FromMinutes(1)));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="SharedAccessCredential.GetToken" />
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
            var credential = new SharedAccessCredential(signature);

            Assert.That(credential.GetToken(new TokenRequestContext(), default).ExpiresOn, Is.EqualTo(expectedExpiration).Within(TimeSpan.FromMinutes(1)));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="SharedAccessCredential.GetToken" />
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
            var credential = new SharedAccessCredential(signature);

            Assert.That(credential.GetToken(new TokenRequestContext(), default).ExpiresOn, Is.EqualTo(tokenExpiration).Within(TimeSpan.FromMinutes(1)));
        }

        /// <summary>
        ///   Verifies that a signature can be rotated without refreshing its validity.
        /// </summary>
        ///
        [Test]
        public void NamedKeyCredentialUpdatesAreRespected()
        {
            var updatedKeyName = "updated-name";
            var updatedKey = "updated-Key";
            var signature = new SharedAccessSignature("hub-name", "keyName", "key");
            var sourceCredential = new AzureNamedKeyCredential(signature.SharedAccessKeyName, signature.SharedAccessKey);
            var credential = new SharedAccessCredential(sourceCredential, signature.Resource);
            var credentialSignature = GetSharedAccessSignature(credential);
            var (signatureKeyName, signatureKeyValue) = sourceCredential;

            Assert.That(credentialSignature.SharedAccessKeyName, Is.EqualTo(signatureKeyName), "The shared key name should match the source credential.");
            Assert.That(credentialSignature.SharedAccessKey, Is.EqualTo(signatureKeyValue), "The shared key should match the source credential.");

            sourceCredential.Update(updatedKeyName, updatedKey);
            _ = credential.GetToken(new TokenRequestContext(), CancellationToken.None);

            var newSignature = GetSharedAccessSignature(credential);
            Assert.That(newSignature.SharedAccessKeyName, Is.EqualTo(updatedKeyName));
            Assert.That(newSignature.SharedAccessKey, Is.EqualTo(updatedKey));
            Assert.That(newSignature.SignatureExpiration, Is.EqualTo(signature.SignatureExpiration).Within(TimeSpan.FromMinutes(5)));
        }

        /// <summary>
        ///   Verifies that a signature can be rotated without refreshing its validity.
        /// </summary>
        ///
        [Test]
        public void SasCredentialUpdatesAreRespected()
        {
            var tokenExpiration = TimeSpan.FromSeconds(GetSignatureRefreshBuffer().TotalSeconds / 2);
            var signature = new SharedAccessSignature("hub-name", "keyName", "key", tokenExpiration);
            var sourceCredential = new AzureSasCredential(signature.Value);
            var credential = new SharedAccessCredential(sourceCredential);

            Assert.That(GetSharedAccessSignature(credential).Value, Is.EqualTo(sourceCredential.Signature), "The signature should match the source credential.");

            var updatedSignature = new SharedAccessSignature("hub-name", "newKeyName", "newKey", tokenExpiration.Add(TimeSpan.FromMinutes(30)));
            sourceCredential.Update(updatedSignature.Value);

            var accessToken = credential.GetToken(new TokenRequestContext(), CancellationToken.None);
            Assert.That(accessToken.Token, Is.EqualTo(updatedSignature.Value));
            Assert.That(accessToken.ExpiresOn, Is.EqualTo(updatedSignature.SignatureExpiration).Within(TimeSpan.FromMinutes(5)));
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
        ///   Retrieves the shared access signature from the credential using its private field.
        /// </summary>
        ///
        /// <param name="instance">The instance to retrieve the key from.</param>
        ///
        /// <returns>The shared access key.</returns>
        ///
        private static SharedAccessSignature GetSharedAccessSignature(SharedAccessCredential instance) =>
            (SharedAccessSignature)
                typeof(SharedAccessCredential)
                .GetField("_sharedAccessSignature", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(instance);

        /// <summary>
        ///   Retrieves the source SAS credential instance from the credential using its private field.
        /// </summary>
        ///
        /// <param name="instance">The instance to retrieve the key from.</param>
        ///
        /// <returns>The source credential.</returns>
        ///
        private static AzureSasCredential GetSourceSasCredential(SharedAccessCredential instance) =>
            (AzureSasCredential)
                typeof(SharedAccessCredential)
                .GetField("_sourceSasCredential", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(instance);

        /// <summary>
        ///   Retrieves the source named key credential instance from the credential using its private field.
        /// </summary>
        ///
        /// <param name="instance">The instance to retrieve the key from.</param>
        ///
        /// <returns>The source credential.</returns>
        ///
        private static AzureNamedKeyCredential GetSourceKeyCredential(SharedAccessCredential instance) =>
            (AzureNamedKeyCredential)
                typeof(SharedAccessCredential)
                .GetField("_sourceKeyCredential", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(instance);

        /// <summary>
        ///   Gets the refresh buffer for the <see cref="SharedAccessCredential" /> using
        ///   its private field.
        /// </summary>
        ///
        private static TimeSpan GetSignatureRefreshBuffer() =>
            (TimeSpan)
                typeof(SharedAccessCredential)
                    .GetField("SignatureRefreshBuffer", BindingFlags.Static | BindingFlags.NonPublic)
                    .GetValue(null);

        /// <summary>
        ///   Gets the extension duration for the <see cref="SharedAccessCredential" /> using
        ///   its private field.
        /// </summary>
        ///
        private static TimeSpan GetSignatureExtensionDuration() =>
            (TimeSpan)
                typeof(SharedAccessCredential)
                    .GetField("SignatureExtensionDuration", BindingFlags.Static | BindingFlags.NonPublic)
                    .GetValue(null);
    }
}
