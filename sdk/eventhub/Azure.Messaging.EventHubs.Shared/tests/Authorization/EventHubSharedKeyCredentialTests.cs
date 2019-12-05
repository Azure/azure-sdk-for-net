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
        public void AsSharedAccessSignatureCredentialProducesTheExpectedCredential()
        {
            var resource = "amqps://some.hub.com/path";
            var keyName = "sharedKey";
            var keyValue = "keyValue";
            var validSpan = TimeSpan.FromHours(4);
            var signature = new SharedAccessSignature(resource, keyName, keyValue, validSpan);
            var keyCredential = new EventHubSharedKeyCredential(keyName, keyValue);
            var sasCredential = keyCredential.AsSharedAccessSignatureCredential(resource, validSpan);

            Assert.That(sasCredential, Is.Not.Null, "A shared access signature credential should have been created.");

            var credentialSignature = GetSharedAccessSignature(sasCredential);
            Assert.That(credentialSignature, Is.Not.Null, "The SAS credential should contain a shared access signature.");
            Assert.That(credentialSignature.Resource, Is.EqualTo(signature.Resource), "The resource should match.");
            Assert.That(credentialSignature.SharedAccessKeyName, Is.EqualTo(signature.SharedAccessKeyName), "The shared access key name should match.");
            Assert.That(credentialSignature.SharedAccessKey, Is.EqualTo(signature.SharedAccessKey), "The shared access key should match.");
            Assert.That(credentialSignature.SignatureExpiration, Is.EqualTo(signature.SignatureExpiration).Within(TimeSpan.FromSeconds(5)), "The expiration should match.");
        }

        /// <summary>
        ///   The signature expiration will always be extended after calling AsSharedAccessSignatureCredential.
        /// </summary>
        ///
        [Test]
        public void AsSharedAccessSignatureCredentialShouldRefreshTokenValidity()
        {
            var beforeResource = "amqps://before/path";
            var afterResource = "amqps://after/path";
            var beforeSpan = TimeSpan.FromHours(4);
            var afterSpan = TimeSpan.FromHours(8);
            var keyName = "keyName";
            var keyValue = "keyValue";
            var expectedSignature = new SharedAccessSignature(beforeResource, keyName, keyValue, beforeSpan);
            var keyCredential = new EventHubSharedKeyCredential(keyName, keyValue);

            SharedAccessSignatureCredential sasCredential = keyCredential.AsSharedAccessSignatureCredential(beforeResource, beforeSpan);
            SharedAccessSignature beforeSignature = GetSharedAccessSignature(sasCredential);

            Assert.That(beforeSignature.SignatureExpiration, Is.EqualTo(expectedSignature.SignatureExpiration).Within(TimeSpan.FromSeconds(5)), "The expiration should match.");

            expectedSignature = new SharedAccessSignature(afterResource, keyName, keyValue, afterSpan);
            sasCredential = keyCredential.AsSharedAccessSignatureCredential(afterResource, afterSpan);
            SharedAccessSignature afterSignature = GetSharedAccessSignature(sasCredential);

            Assert.That(afterSignature.SignatureExpiration, Is.EqualTo(expectedSignature.SignatureExpiration).Within(TimeSpan.FromSeconds(5)), "The expiration should match.");
        }

        /// <summary>
        ///   EventHubSharedKeyCredential should wrap an instance of SharedAccessSignatureCredential.
        ///   Multiple calls to AsSharedAccessSignatureCredential will return a reference to the same object.
        /// </summary>
        ///
        [Test]
        public void EventHubSharedKeyCredentialShouldHoldAReferenceToASharedAccessKey()
        {
            var resource = "amqps://some.hub.com/path";
            var span = TimeSpan.FromHours(4);
            var keyName = "keyName";
            var keyValue = "keyValue";
            var keyCredential = new EventHubSharedKeyCredential(keyName, keyValue);

            SharedAccessSignatureCredential sasCredential = keyCredential.AsSharedAccessSignatureCredential(resource, span);
            SharedAccessSignatureCredential wrappedCredential = GetSharedAccessSignatureCredential(keyCredential);

            Assert.That(wrappedCredential, Is.EqualTo(sasCredential), "The credentials should be wrapped.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void UpdateSharedAccessKeyShouldAllowToRefreshASharedAccessSignature()
        {
            var resource = "amqps://before/path";
            var beforeKeyName = "beforeKeyName";
            var afterKeyName = "afterKeyName";
            var beforeKeyValue = "beforeKeyValue";
            var afterKeyValue = "afterKeyValue";
            var validSpan = TimeSpan.FromHours(4);
            var signature = new SharedAccessSignature(resource, beforeKeyName, beforeKeyValue, validSpan);
            var keyCredential = new EventHubSharedKeyCredential(beforeKeyName, beforeKeyValue);

            // Needed to instantiate a SharedAccessSignatureCredential
            var sasCredential = keyCredential.AsSharedAccessSignatureCredential(resource, validSpan);

            // Updates
            keyCredential.UpdateSharedAccessKey(afterKeyName, afterKeyValue);

            Assert.That(sasCredential, Is.Not.Null, "A shared access signature credential should have been created.");

            var credentialSignature = GetSharedAccessSignature(sasCredential);
            Assert.That(credentialSignature, Is.Not.Null, "The SAS credential should contain a shared access signature.");
            Assert.That(credentialSignature.Resource, Is.EqualTo(signature.Resource), "The resource should match.");
            Assert.That(credentialSignature.SharedAccessKeyName, Is.EqualTo(afterKeyName), "The shared access key name should match.");
            Assert.That(credentialSignature.SharedAccessKey, Is.EqualTo(afterKeyValue), "The shared access key should match.");
            Assert.That(credentialSignature.SignatureExpiration, Is.EqualTo(signature.SignatureExpiration).Within(TimeSpan.FromSeconds(5)), "The expiration should match.");
        }

        /// <summary>
        ///   A call to UpdateSharedAccessKey should change properties of the SharedAccessSignature
        ///   that it wraps like the SharedAccessKeyName or the SharedAccessKey.
        /// </summary>
        ///
        [Test]
        public void UpdateSharedAccessKeyShouldAlwaysRefreshEventHubSharedKeyCredentialNameAndKey()
        {
            var resource = "amqps://before/path";
            var validSpan = TimeSpan.FromHours(4);
            var beforeKeyName = "beforeKeyName";
            var afterKeyName = "afterKeyName";
            var beforeKeyValue = "beforeKeyValue";
            var afterKeyValue = "afterKeyValue";
            var keyCredential = new EventHubSharedKeyCredential(beforeKeyName, beforeKeyValue);

            keyCredential.UpdateSharedAccessKey(afterKeyName, afterKeyValue);

            string keyName = GetSharedAccessKeyName(keyCredential);
            string key = GetSharedAccessKey(keyCredential);

            // Needed to instantiate a SharedAccessSignatureCredential
            var sasCredential = keyCredential.AsSharedAccessSignatureCredential(resource, validSpan);
            var credentialSignature = GetSharedAccessSignature(sasCredential);

            Assert.That(credentialSignature.SharedAccessKeyName, Is.EqualTo(afterKeyName), "The shared access key name should change after being updated.");
            Assert.That(credentialSignature.SharedAccessKey, Is.EqualTo(afterKeyValue), "The shared access key value should change after being updated.");
            Assert.That(keyName, Is.EqualTo(afterKeyName), "The shared access key name should change after being updated.");
            Assert.That(key, Is.EqualTo(afterKeyValue), "The shared access key value should change after being updated.");
        }

        /// <summary>
        ///   A call to UpdateSharedAccessKey should not change the properties of the SharedAccessSignature
        ///   that it wraps like the signature expiration or the signature resource.
        /// </summary>
        ///
        [Test]
        public void UpdateSharedAccessKeyShouldNotChangeOtherPropertiesOfASharedAccessSignature()
        {
            var resource = "amqps://before/path";
            var validSpan = TimeSpan.FromHours(4);
            var beforeKeyName = "beforeKeyName";
            var afterKeyName = "afterKeyName";
            var beforeKeyValue = "beforeKeyValue";
            var afterKeyValue = "afterKeyValue";
            var keyCredential = new EventHubSharedKeyCredential(beforeKeyName, beforeKeyValue);

            // Needed to instantiate a SharedAccessTokenCredential
            var sasCredential = keyCredential.AsSharedAccessSignatureCredential(resource, validSpan);
            var credentialSignature = GetSharedAccessSignature(sasCredential);

            var signatureExpiration = credentialSignature.SignatureExpiration;

            keyCredential.UpdateSharedAccessKey(afterKeyName, afterKeyValue);

            Assert.That(credentialSignature.SignatureExpiration, Is.EqualTo(signatureExpiration), "The expiration of a signature should not change when the credentials are rolled.");
            Assert.That(credentialSignature.Resource, Is.EqualTo(resource), "The resource of a signature should not change when the credentials are rolled.");
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
        ///   Retrieves the shared access key from the credential using its private accessor.
        /// </summary>
        ///
        /// <param name="instance">The instance to retrieve the key from.</param>
        ///
        /// <returns>The shared access key.</returns>
        ///
        private static string GetSharedAccessKeyName(EventHubSharedKeyCredential instance) =>
            (string)
                typeof(EventHubSharedKeyCredential)
                .GetProperty("SharedAccessKeyName", BindingFlags.Instance | BindingFlags.NonPublic)
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

        /// <summary>
        ///   Retrieves the EventHubSharedKeyCredential from the credential using its private accessor.
        /// </summary>
        ///
        /// <param name="instance">The instance to retrieve the key from.</param>
        ///
        /// <returns>The shared access key.</returns>
        ///
        private static SharedAccessSignatureCredential GetSharedAccessSignatureCredential(EventHubSharedKeyCredential instance) =>
            (SharedAccessSignatureCredential)
                typeof(EventHubSharedKeyCredential)
                .GetProperty("SharedAccessSignatureCredential", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(instance, null);
    }
}
