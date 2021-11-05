// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Authorization;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventHubTokenCredential" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class EventHubTokenCredentialTests
    {
        /// <summary>
        ///   The set of test cases for understanding whether a credential is considered to be
        ///   based on a shared access signature.
        /// </summary>
        ///
        public static IEnumerable<object[]> SharedAccessCredentialTestCases()
        {
            TokenCredential credentialMock = Mock.Of<TokenCredential>();
            var signature = new SharedAccessSignature("hub", "keyName", "key", "TOkEn!", DateTimeOffset.UtcNow.AddHours(4));

            yield return new object[] { new SharedAccessCredential(signature), true };
            yield return new object[] { new EventHubTokenCredential(credentialMock), false };
            yield return new object[] { credentialMock, false };
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheCredential()
        {
            Assert.That(() => new EventHubTokenCredential(null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesInitializesProperties()
        {
            TokenCredential sourceCredential = Mock.Of<TokenCredential>();
            var credential = new EventHubTokenCredential(sourceCredential);

            var credentialPropertyValue = typeof(EventHubTokenCredential)
                .GetField("_credential", BindingFlags.Instance | BindingFlags.NonPublic)
                .GetValue(credential);

            Assert.That(credentialPropertyValue, Is.SameAs(sourceCredential), "The source credential should have been retained.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void GetTokenDelegatesToTheSourceCredential()
        {
            var mockCredential = new Mock<TokenCredential>();
            var accessToken = new AccessToken("token", new DateTimeOffset(2015, 10, 27, 12, 0, 0, TimeSpan.Zero));
            var resource = "the resource value";
            var credential = new EventHubTokenCredential(mockCredential.Object);

            mockCredential
                .Setup(cred => cred.GetToken(It.Is<TokenRequestContext>(value => value.Scopes.FirstOrDefault() == resource), It.IsAny<CancellationToken>()))
                .Returns(accessToken)
                .Verifiable("The source credential GetToken method should have been called.");

            AccessToken tokenResult = credential.GetToken(new TokenRequestContext(new[] { resource }), CancellationToken.None);

            Assert.That(tokenResult, Is.EqualTo(accessToken), "The access token should match the return of the delegated call.");
            mockCredential.VerifyAll();
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public async Task GetTokenAsyncDelegatesToTheSourceCredential()
        {
            var mockCredential = new Mock<TokenCredential>();
            var accessToken = new AccessToken("token", new DateTimeOffset(2015, 10, 27, 12, 0, 0, TimeSpan.Zero));
            var resource = "the resource value";
            var credential = new EventHubTokenCredential(mockCredential.Object);

            mockCredential
                .Setup(cred => cred.GetTokenAsync(It.Is<TokenRequestContext>(value => value.Scopes.FirstOrDefault() == resource), It.IsAny<CancellationToken>()))
                .ReturnsAsync(accessToken)
                .Verifiable("The source credential GetToken method should have been called.");

            AccessToken tokenResult = await credential.GetTokenAsync(new TokenRequestContext(new[] { resource }), CancellationToken.None);

            Assert.That(tokenResult, Is.EqualTo(accessToken), "The access token should match the return of the delegated call.");
            mockCredential.VerifyAll();
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubTokenCredential.IsSharedAccessCredential" />
        ///   property.
        /// </summary>
        ///
        [Test]
        [TestCaseSource(nameof(SharedAccessCredentialTestCases))]
        public void IsSharedAccessCredentialRecognizesSasCredentials(TokenCredential credential,
                                                                     bool expectedResult)
        {
            var eventHubsCredential = new EventHubTokenCredential(credential);
            Assert.That(eventHubsCredential.IsSharedAccessCredential, Is.EqualTo(expectedResult));
        }
    }
}
