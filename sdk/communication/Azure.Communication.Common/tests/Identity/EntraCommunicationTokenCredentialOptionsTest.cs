// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Moq;
using NUnit.Framework;

namespace Azure.Communication.Identity
{
    [TestFixture]
    public class EntraCommunicationTokenCredentialOptionsTest
    {
        private Mock<TokenCredential> _mockTokenCredential = null!;
        private const string communicationClientsPrefix = "https://communication.azure.com/clients/";
        private const string communicationClientsScope = communicationClientsPrefix + "VoIP";
        private const string defaultScope = communicationClientsPrefix + ".default";
        private const string teamsExtensionScope = "https://auth.msft.communication.azure.com/TeamsExtension.ManageCalls";
        private string _resourceEndpoint = "https://myResource.communication.azure.com";

        private static readonly object[] validScopes =
        {
            new object[] { new string[] { communicationClientsScope }},
            new object[] { new string[] { teamsExtensionScope } }
        };

        [SetUp]
        public void Setup()
        {
            _mockTokenCredential = new Mock<TokenCredential>();
        }

        [Test, TestCaseSource(nameof(validScopes))]
        public void EntraCommunicationTokenCredentialOptionsTest_Init_ThrowsErrorWithNulls(string[] scopes)
        {
            Assert.Throws<ArgumentNullException>(() => new EntraCommunicationTokenCredentialOptions(
                null,
                _mockTokenCredential.Object,
                scopes));

            Assert.Throws<ArgumentException>(() => new EntraCommunicationTokenCredentialOptions(
                "",
                _mockTokenCredential.Object,
                scopes));

            Assert.Throws<ArgumentNullException>(() => new EntraCommunicationTokenCredentialOptions(
                _resourceEndpoint,
                null,
                scopes));
        }

        [Test]
        public void EntraCommunicationTokenCredentialOptionsTest_InitWithoutScopes_InitsWithDefaultScope()
        {
            var credential = new EntraCommunicationTokenCredentialOptions(
                _resourceEndpoint,
                _mockTokenCredential.Object);
            Assert.AreEqual(1, credential.Scopes.Length);
            Assert.AreEqual(defaultScope, credential.Scopes[0]);

            credential = new EntraCommunicationTokenCredentialOptions(
                _resourceEndpoint,
                _mockTokenCredential.Object,
                null);
            Assert.AreEqual(1, credential.Scopes.Length);
            Assert.AreEqual(defaultScope, credential.Scopes[0]);

            credential = new EntraCommunicationTokenCredentialOptions(
                _resourceEndpoint,
                _mockTokenCredential.Object,
                null, null);
            Assert.AreEqual(1, credential.Scopes.Length);
            Assert.AreEqual(defaultScope, credential.Scopes[0]);

            credential = new EntraCommunicationTokenCredentialOptions(
                _resourceEndpoint,
                _mockTokenCredential.Object,
                Array.Empty<string>());
            Assert.AreEqual(1, credential.Scopes.Length);
            Assert.AreEqual(defaultScope, credential.Scopes[0]);
        }

        [Test]
        public void EntraCommunicationTokenCredentialOptionsTest_InitByParameters()
        {
            var credential = new EntraCommunicationTokenCredentialOptions(
                _resourceEndpoint,
                _mockTokenCredential.Object,
                communicationClientsScope);
            Assert.AreEqual(1, credential.Scopes.Length);
            Assert.AreEqual(communicationClientsScope, credential.Scopes[0]);

            var scope = new string[] { communicationClientsScope, teamsExtensionScope };
            credential = new EntraCommunicationTokenCredentialOptions(
                _resourceEndpoint,
                _mockTokenCredential.Object,
                scope[0], scope[1]);
            Assert.AreEqual(scope.Length, credential.Scopes.Length);
            Assert.AreEqual(scope, credential.Scopes);

            scope = new string[] { communicationClientsScope, teamsExtensionScope, communicationClientsPrefix + "Chat" };
            credential = new EntraCommunicationTokenCredentialOptions(
                _resourceEndpoint,
                _mockTokenCredential.Object,
                scope[0], scope[1], scope[2]);
            Assert.AreEqual(scope.Length, credential.Scopes.Length);
            Assert.AreEqual(scope, credential.Scopes);
        }

        [Test]
        public void EntraCommunicationTokenCredentialOptionsTest_InitByArray()
        {
            var scope = new string[] { communicationClientsScope };
            var credential = new EntraCommunicationTokenCredentialOptions(
                _resourceEndpoint,
                _mockTokenCredential.Object,
                scope);
            Assert.AreEqual(1, credential.Scopes.Length);
            Assert.AreEqual(communicationClientsScope, credential.Scopes[0]);

            scope = new string[] { communicationClientsScope, teamsExtensionScope };
            credential = new EntraCommunicationTokenCredentialOptions(
                _resourceEndpoint,
                _mockTokenCredential.Object,
                scope);
            Assert.AreEqual(scope.Length, credential.Scopes.Length);
            Assert.AreEqual(scope, credential.Scopes);

            scope = new string[] { communicationClientsScope, teamsExtensionScope, communicationClientsPrefix + "Chat" };
            credential = new EntraCommunicationTokenCredentialOptions(
                _resourceEndpoint,
                _mockTokenCredential.Object,
                scope);
            Assert.AreEqual(scope.Length, credential.Scopes.Length);
            Assert.AreEqual(scope, credential.Scopes);
        }

        [Test]
        public void EntraCommunicationTokenCredentialOptionsTest_NullInScopes_Skipped()
        {
            var credential = new EntraCommunicationTokenCredentialOptions(
                _resourceEndpoint,
                _mockTokenCredential.Object,
                communicationClientsScope, null);
            Assert.AreEqual(1, credential.Scopes.Length);
            Assert.AreEqual(communicationClientsScope, credential.Scopes[0]);

            credential = new EntraCommunicationTokenCredentialOptions(
                _resourceEndpoint,
                _mockTokenCredential.Object,
                null, communicationClientsScope, null);
            Assert.AreEqual(1, credential.Scopes.Length);
            Assert.AreEqual(communicationClientsScope, credential.Scopes[0]);

            var scope = new string[] { communicationClientsScope, teamsExtensionScope };
            credential = new EntraCommunicationTokenCredentialOptions(
                _resourceEndpoint,
                _mockTokenCredential.Object,
                scope[0], null, scope[1]);
            Assert.AreEqual(scope.Length, credential.Scopes.Length);
            Assert.AreEqual(scope, credential.Scopes);
        }

        [Test]
        public void EntraCommunicationTokenCredentialOptionsTest_EmptyStringInScopes_Skipped()
        {
            var credential = new EntraCommunicationTokenCredentialOptions(
                _resourceEndpoint,
                _mockTokenCredential.Object,
                communicationClientsScope, String.Empty);
            Assert.AreEqual(1, credential.Scopes.Length);
            Assert.AreEqual(communicationClientsScope, credential.Scopes[0]);

            credential = new EntraCommunicationTokenCredentialOptions(
                _resourceEndpoint,
                _mockTokenCredential.Object,
                String.Empty, communicationClientsScope, null);
            Assert.AreEqual(1, credential.Scopes.Length);
            Assert.AreEqual(communicationClientsScope, credential.Scopes[0]);

            var scope = new string[] { communicationClientsScope, teamsExtensionScope };
            credential = new EntraCommunicationTokenCredentialOptions(
                _resourceEndpoint,
                _mockTokenCredential.Object,
                scope[0], String.Empty, null, String.Empty, scope[1]);
            Assert.AreEqual(scope.Length, credential.Scopes.Length);
            Assert.AreEqual(scope, credential.Scopes);

            var scopeWithEmpty = new string[] { String.Empty, communicationClientsScope, String.Empty, teamsExtensionScope, String.Empty, String.Empty, communicationClientsPrefix + "Chat" };
            var expectedScope = new string[] { communicationClientsScope, teamsExtensionScope, communicationClientsPrefix + "Chat" };
            credential = new EntraCommunicationTokenCredentialOptions(
                _resourceEndpoint,
                _mockTokenCredential.Object,
                scopeWithEmpty);
            Assert.AreEqual(expectedScope.Length, credential.Scopes.Length);
            Assert.AreEqual(expectedScope, credential.Scopes);
        }
    }
}
