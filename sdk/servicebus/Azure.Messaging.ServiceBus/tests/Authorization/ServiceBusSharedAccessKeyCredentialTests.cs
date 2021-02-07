// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using Azure.Messaging.ServiceBus.Authorization;
using NUnit.Framework;

namespace Azure.Messaging.ServiceBus.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="ServiceBusSharedAccessKeyCredential" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class ServiceBusSharedAccessKeyCredentialTests
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
            Assert.That(() => new ServiceBusSharedAccessKeyCredential(keyName, "someKey"), Throws.InstanceOf<ArgumentException>());
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
            Assert.That(() => new ServiceBusSharedAccessKeyCredential("someName", keyValue), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesInitializesSharedAccessSignatureProperties(string signature)
        {
            Assert.That(() => new ServiceBusSharedAccessKeyCredential(signature), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorInitializesSharedKeyProperties()
        {
            var name = "KeyName";
            var value = "KeyValue";
            var credential = new ServiceBusSharedAccessKeyCredential(name, value);

            Assert.That(credential.SharedAccessKeyName, Is.EqualTo(name), "The shared key name should have been set.");
            Assert.That(credential.SharedAccessKey, Is.EqualTo(value), "The shared key should have been set.");
            Assert.That(credential.SharedAccessSignature, Is.Null, "The shared access signature should not have been set.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorInitializesSharedSignatureProperties()
        {
            var signature = new SharedAccessSignature("RESOURCE", "keyname", "keyvalue").Value;
            var credential = new ServiceBusSharedAccessKeyCredential(signature);

            Assert.That(credential.SharedAccessSignature, Is.EqualTo(signature), "The shared access signature name should have been set.");
            Assert.That(credential.SharedAccessKeyName, Is.Null, "The shared key name should have been set.");
            Assert.That(credential.SharedAccessKey, Is.Null, "The shared access key should not have been set.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void AsSharedAccessSignatureCredentialProducesTheExpectedCredentialForSharedKeys()
        {
            var resource = "amqps://some.hub.com/path";
            var keyName = "sharedKey";
            var keyValue = "keyValue";
            var validSpan = TimeSpan.FromHours(4);
            var signature = new SharedAccessSignature(resource, keyName, keyValue, validSpan);
            var keyCredential = new ServiceBusSharedAccessKeyCredential(keyName, keyValue);
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
        public void AsSharedAccessSignatureCredentialShouldRefreshTokenValidityForSharedKeys()
        {
            var beforeResource = "amqps://before/path";
            var afterResource = "amqps://after/path";
            var beforeSpan = TimeSpan.FromHours(4);
            var afterSpan = TimeSpan.FromHours(8);
            var keyName = "keyName";
            var keyValue = "keyValue";
            var expectedSignature = new SharedAccessSignature(beforeResource, keyName, keyValue, beforeSpan);
            var keyCredential = new ServiceBusSharedAccessKeyCredential(keyName, keyValue);

            SharedAccessSignatureCredential sasCredential = keyCredential.AsSharedAccessSignatureCredential(beforeResource, beforeSpan);
            SharedAccessSignature beforeSignature = GetSharedAccessSignature(sasCredential);

            Assert.That(beforeSignature.SignatureExpiration, Is.EqualTo(expectedSignature.SignatureExpiration).Within(TimeSpan.FromSeconds(5)), "The expiration should match.");

            expectedSignature = new SharedAccessSignature(afterResource, keyName, keyValue, afterSpan);
            sasCredential = keyCredential.AsSharedAccessSignatureCredential(afterResource, afterSpan);
            SharedAccessSignature afterSignature = GetSharedAccessSignature(sasCredential);

            Assert.That(afterSignature.SignatureExpiration, Is.EqualTo(expectedSignature.SignatureExpiration).Within(TimeSpan.FromSeconds(5)), "The expiration should match.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void AsSharedAccessSignatureCredentialProducesTheExpectedCredentialForSharedAccessSignatures()
        {
            var resource = "amqps://some.hub.com/path";
            var keyName = "sharedKey";
            var keyValue = "keyValue";
            var validSpan = TimeSpan.FromHours(4);
            var signature = new SharedAccessSignature(resource, keyName, keyValue, validSpan);
            var keyCredential = new ServiceBusSharedAccessKeyCredential(signature.Value);
            var sasCredential = keyCredential.AsSharedAccessSignatureCredential(resource, validSpan);

            Assert.That(sasCredential, Is.Not.Null, "A shared access signature credential should have been created.");

            var credentialSignature = GetSharedAccessSignature(sasCredential);
            Assert.That(credentialSignature, Is.Not.Null, "The SAS credential should contain a shared access signature.");
            Assert.That(credentialSignature.Resource, Is.EqualTo(signature.Resource), "The resource should match.");
            Assert.That(credentialSignature.SharedAccessKeyName, Is.EqualTo(signature.SharedAccessKeyName), "The shared access key name should match.");
            Assert.That(credentialSignature.SharedAccessKey, Is.Null, "The shared access key should not be populated.");
            Assert.That(credentialSignature.SignatureExpiration, Is.EqualTo(signature.SignatureExpiration).Within(TimeSpan.FromSeconds(5)), "The expiration should match.");
        }

        /// <summary>
        ///   The signature expiration will always be extended after calling AsSharedAccessSignatureCredential.
        /// </summary>
        ///
        [Test]
        public void AsSharedAccessSignatureCredentialShouldNotRefreshTokenValidityForSharedAccessSignatures()
        {
            var beforeResource = "amqps://before/path";
            var afterResource = "amqps://after/path";
            var beforeSpan = TimeSpan.FromHours(4);
            var afterSpan = TimeSpan.FromHours(8);
            var keyName = "keyName";
            var keyValue = "keyValue";
            var expectedSignature = new SharedAccessSignature(beforeResource, keyName, keyValue, beforeSpan);
            var keyCredential = new ServiceBusSharedAccessKeyCredential(expectedSignature.Value);

            SharedAccessSignatureCredential sasCredential = keyCredential.AsSharedAccessSignatureCredential(beforeResource, beforeSpan);
            SharedAccessSignature beforeSignature = GetSharedAccessSignature(sasCredential);

            Assert.That(beforeSignature.SignatureExpiration, Is.EqualTo(expectedSignature.SignatureExpiration).Within(TimeSpan.FromSeconds(5)), "The expiration should match.");

            sasCredential = keyCredential.AsSharedAccessSignatureCredential(afterResource, afterSpan);
            SharedAccessSignature afterSignature = GetSharedAccessSignature(sasCredential);

            Assert.That(afterSignature.SignatureExpiration, Is.EqualTo(expectedSignature.SignatureExpiration).Within(TimeSpan.FromSeconds(5)), "The expiration should match.");
        }

        /// <summary>
        ///   ServiceBusSharedAccessKeyCredential should wrap an instance of SharedAccessSignatureCredential.
        ///   Multiple calls to AsSharedAccessSignatureCredential will return a reference to the same object.
        /// </summary>
        ///
        [Test]
        public void ServiceBusSharedAccessKeyCredentialShouldHoldAReferenceToASharedAccessKey()
        {
            var resource = "amqps://some.hub.com/path";
            var span = TimeSpan.FromHours(4);
            var keyName = "keyName";
            var keyValue = "keyValue";
            var keyCredential = new ServiceBusSharedAccessKeyCredential(keyName, keyValue);

            SharedAccessSignatureCredential sasCredential = keyCredential.AsSharedAccessSignatureCredential(resource, span);
            SharedAccessSignatureCredential wrappedCredential = GetSharedAccessSignatureCredential(keyCredential);

            Assert.That(wrappedCredential, Is.EqualTo(sasCredential), "The credentials should be wrapped.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void UpdateSharedAccessKeyShouldAllowRefreshOfTheSharedAccessSignature()
        {
            var resource = "amqps://before/path";
            var beforeKeyName = "beforeKeyName";
            var afterKeyName = "afterKeyName";
            var beforeKeyValue = "beforeKeyValue";
            var afterKeyValue = "afterKeyValue";
            var validSpan = TimeSpan.FromHours(4);
            var signature = new SharedAccessSignature(resource, beforeKeyName, beforeKeyValue, validSpan);
            var keyCredential = new ServiceBusSharedAccessKeyCredential(beforeKeyName, beforeKeyValue);

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
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void UpdateSharedAccessSignatureShouldUpdateTheSharedAccessSignature()
        {
            var resource = "amqps://before/path";
            var beforeKeyName = "beforeKeyName";
            var afterKeyName = "afterKeyName";
            var beforeKeyValue = "beforeKeyValue";
            var afterKeyValue = "afterKeyValue";
            var validSpan = TimeSpan.FromHours(4);
            var signature = new SharedAccessSignature(resource, beforeKeyName, beforeKeyValue, validSpan.Add(TimeSpan.FromHours(2)));
            var keyCredential = new ServiceBusSharedAccessKeyCredential(signature.Value);
            var sasCredential = keyCredential.AsSharedAccessSignatureCredential(resource, validSpan);

            // Updates
            var newSignature = new SharedAccessSignature(resource, afterKeyName, afterKeyValue, validSpan);
            keyCredential.UpdateSharedAccessSignature(newSignature.Value);

            Assert.That(sasCredential, Is.Not.Null, "A shared access signature credential should have been created.");

            var credentialSignature = GetSharedAccessSignature(sasCredential);
            Assert.That(credentialSignature, Is.Not.Null, "The SAS credential should contain a shared access signature.");
            Assert.That(credentialSignature.Resource, Is.EqualTo(signature.Resource), "The resource should match.");
            Assert.That(credentialSignature.SharedAccessKeyName, Is.EqualTo(afterKeyName), "The shared access key name should match.");
            Assert.That(credentialSignature.SharedAccessKey, Is.Null, "The shared access key should not have been set.");
            Assert.That(credentialSignature.SignatureExpiration, Is.EqualTo(newSignature.SignatureExpiration).Within(TimeSpan.FromSeconds(5)), "The expiration should match.");
        }

        /// <summary>
        ///   A call to UpdateSharedAccessKey should change properties of the SharedAccessSignature
        ///   that it wraps like the SharedAccessKeyName or the SharedAccessKey.
        /// </summary>
        ///
        [Test]
        public void UpdateSharedAccessKeyShoulRefreshServiceBusSharedAccessKeyCredentialNameAndKey()
        {
            var resource = "amqps://before/path";
            var validSpan = TimeSpan.FromHours(4);
            var beforeKeyName = "beforeKeyName";
            var afterKeyName = "afterKeyName";
            var beforeKeyValue = "beforeKeyValue";
            var afterKeyValue = "afterKeyValue";
            var keyCredential = new ServiceBusSharedAccessKeyCredential(beforeKeyName, beforeKeyValue);

            keyCredential.UpdateSharedAccessKey(afterKeyName, afterKeyValue);

            var keyName = keyCredential.SharedAccessKeyName;
            var key = keyCredential.SharedAccessKey;

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
        public void UpdateSharedAccessKeyShouldNotChangeOtherPropertiesForTheSharedAccessSignature()
        {
            var resource = "amqps://before/path";
            var validSpan = TimeSpan.FromHours(4);
            var beforeKeyName = "beforeKeyName";
            var afterKeyName = "afterKeyName";
            var beforeKeyValue = "beforeKeyValue";
            var afterKeyValue = "afterKeyValue";
            var keyCredential = new ServiceBusSharedAccessKeyCredential(beforeKeyName, beforeKeyValue);

            // Needed to instantiate a SharedAccessTokenCredential
            var sasCredential = keyCredential.AsSharedAccessSignatureCredential(resource, validSpan);
            var credentialSignature = GetSharedAccessSignature(sasCredential);

            var signatureExpiration = credentialSignature.SignatureExpiration;

            keyCredential.UpdateSharedAccessKey(afterKeyName, afterKeyValue);

            Assert.That(credentialSignature.SignatureExpiration, Is.EqualTo(signatureExpiration), "The expiration of a signature should not change when the credentials are rolled.");
            Assert.That(credentialSignature.Resource, Is.EqualTo(resource), "The resource of a signature should not change when the credentials are rolled.");
        }

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
        ///   Retrieves the ServiceBusSharedAccessKeyCredential from the credential using its private accessor.
        /// </summary>
        ///
        /// <param name="instance">The instance to retrieve the key from.</param>
        ///
        /// <returns>The shared access key.</returns>
        ///
        private static SharedAccessSignatureCredential GetSharedAccessSignatureCredential(ServiceBusSharedAccessKeyCredential instance) =>
            (SharedAccessSignatureCredential)
                typeof(ServiceBusSharedAccessKeyCredential)
                .GetProperty("SharedAccessSignatureCredential", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(instance, null);
    }
}
