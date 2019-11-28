// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using Azure.Core;
using Azure.Messaging.EventHubs.Authorization;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventHubSharedKeyCredential" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class EventHubSharedKeyCredentialTests
    {
        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheKeyName(string keyName)
        {
            Assert.That(() => new EventHubSharedKeyCredential(keyName, "someKey"), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheKeyValue(string keyValue)
        {
            Assert.That(() => new EventHubSharedKeyCredential("someName", keyValue), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesInitializesProperties()
        {
            var name = "KeyName";
            var value = "KeyValue";
            var credential = new EventHubSharedKeyCredential(name, value);
            var initializedValue = GetSharedAccessKey(credential);

            Assert.That(initializedValue, Is.EqualTo(value), "The shared key should have been set.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void GetTokenIsNotPermitted()
        {
            Assert.That(() => new EventHubSharedKeyCredential("key", "value").GetToken(new TokenRequestContext(new[] { "test" }), default), Throws.InvalidOperationException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void GetTokenAsyncIsNotPermitted()
        {
            Assert.That(async () => await (new EventHubSharedKeyCredential("key", "value").GetTokenAsync(new TokenRequestContext(new[] { "thing" }), default)), Throws.InvalidOperationException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void CovertToSharedAccessSignatureCredentialProducesTheExpectedCredential()
        {
            var resource = "amqps://some.hub.com/path";
            var keyName = "sharedKey";
            var keyValue = "keyValue";
            var validSpan = TimeSpan.FromHours(4);
            var signature = new SharedAccessSignature(resource, keyName, keyValue, validSpan);
            var keyCredential = new EventHubSharedKeyCredential(keyName, keyValue);
            var sasCredential = keyCredential.ConvertToSharedAccessSignatureCredential(resource, validSpan);

            Assert.That(sasCredential, Is.Not.Null, "A shared access signature credential should have been created.");

            var credentialSignature = GetSharedAccessSignature(sasCredential);
            Assert.That(credentialSignature, Is.Not.Null, "The SAS credential should contain a shared access signature.");
            Assert.That(credentialSignature.Resource, Is.EqualTo(signature.Resource), "The resource should match.");
            Assert.That(credentialSignature.SharedAccessKeyName, Is.EqualTo(signature.SharedAccessKeyName), "The shared access key name should match.");
            Assert.That(credentialSignature.SharedAccessKey, Is.EqualTo(signature.SharedAccessKey), "The shared access key should match.");
            Assert.That(credentialSignature.SignatureExpiration, Is.EqualTo(signature.SignatureExpiration).Within(TimeSpan.FromSeconds(5)), "The expiration should match.");
        }

        /// <summary>
        ///   Retrieves the shared access key from the credential using its private accessor.
        /// </summary>
        ///
        /// <param name="instance">The instance to retrieve the key from.</param>
        ///
        /// <returns>The shared access key.</returns>
        ///
        private static string GetSharedAccessKey(EventHubSharedKeyCredential instance) =>
            (string)
                typeof(EventHubSharedKeyCredential)
                .GetProperty("SharedAccessKey", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(instance, null);

        /// <summary>
        ///   Retrieves the shared access signature from the credential using its private accessor.
        /// </summary>
        ///
        /// <param name="instance">The instance to retrieve the key from.</param>
        ///
        /// <returns>The shared access key.</returns>
        ///
        private static SharedAccessSignature GetSharedAccessSignature(SharedAccessSignatureCredential instance) =>
            (SharedAccessSignature)
                typeof(SharedAccessSignatureCredential)
                .GetProperty("SharedAccessSignature", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(instance, null);
    }
}
