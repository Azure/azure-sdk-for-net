// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.Tests;
using Moq;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class AzureApplicationCredentialTests : ClientTestBase
    {
        private const string clientId = "MyClientId";
        private const string envToken = "environmentToken";
        private const string msiToken = "managedIdentityToken";
        private DateTimeOffset expires = DateTimeOffset.Now;
        private Mock<EnvironmentCredential> mockEnvCred;
        private Mock<ManagedIdentityCredential> mockManagedIdCred;
        private AzureApplicationCredentialOptions options = new AzureApplicationCredentialOptions();

        public AzureApplicationCredentialTests(bool isAsync) : base(isAsync)
        {
            TestDiagnostics = false;
        }

        [SetUp]
        public void TestSetup()
        {
            options.ManagedIdentityId = ManagedIdentityId.FromUserAssignedClientId(clientId);
        }

        [Test]
        public void CtorValidatesArgs()
        {
            new AzureApplicationCredential(null);
            new AzureApplicationCredential(new AzureApplicationCredentialOptions());
            new AzureApplicationCredential(new AzureApplicationCredentialOptions { ManagedIdentityId = ManagedIdentityId.FromUserAssignedClientId("clientId") });
        }

        [Test]
        public async Task CredentialSequenceValid([Values(true, false)] bool envAvailable, [Values(true, false)] bool MsiAvailable)
        {
            ConfigureMocks(envAvailable, MsiAvailable);

            var target = InstrumentClient(new AzureApplicationCredential(options, mockEnvCred.Object, mockManagedIdCred.Object));

            if (!envAvailable && !MsiAvailable)
            {
                var ex = Assert.CatchAsync<AuthenticationFailedException>(async () => await target.GetTokenAsync(new TokenRequestContext(new string[] { "Scope" })));
            }
            else
            {
                var expectedToken = envAvailable switch
                {
                    true => envToken,
                    false => msiToken
                };
                Assert.AreEqual(expectedToken, (await target.GetTokenAsync(new TokenRequestContext(new string[] { "scope" }))).Token);
            }

            VerifyMocks(envAvailable, MsiAvailable);
        }

        private void ConfigureMocks(bool EnvAvailable, bool MsiAvailable)
        {
            mockEnvCred = new Mock<EnvironmentCredential>();
            mockManagedIdCred = new Mock<ManagedIdentityCredential>();

            if (EnvAvailable)
            {
                mockEnvCred
                    .Setup(m => m.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                    .Returns(new AccessToken(envToken, expires));

                mockEnvCred
                    .Setup(m => m.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(new AccessToken(envToken, expires));
            }
            else
            {
                mockEnvCred
                     .Setup(m => m.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                     .Throws(new CredentialUnavailableException("no cred"));

                mockEnvCred
                    .Setup(m => m.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                    .Throws(new CredentialUnavailableException("no cred"));
            }

            if (MsiAvailable)
            {
                mockManagedIdCred
                    .Setup(m => m.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                    .Returns(new AccessToken(msiToken, expires));

                mockManagedIdCred
                    .Setup(m => m.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                    .ReturnsAsync(new AccessToken(msiToken, expires));
            }
            else
            {
                mockManagedIdCred
                    .Setup(m => m.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                    .Throws(new CredentialUnavailableException("no cred"));

                mockManagedIdCred
                    .Setup(m => m.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                    .Throws(new CredentialUnavailableException("no cred"));
            }
        }

        private void VerifyMocks(bool EnvAvailable, bool MsiAvailable)
        {
            if (EnvAvailable)
            {
                if (IsAsync)
                {
                    mockEnvCred
                        .Verify(m => m.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()));
                }
                else
                {
                    mockEnvCred
                        .Verify(m => m.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()));
                }
            }
            else if (MsiAvailable)
            {
                if (IsAsync)
                {
                    mockManagedIdCred
                        .Verify(m => m.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()));
                }
                else
                {
                    mockManagedIdCred
                        .Verify(m => m.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()));
                }
            }
        }
    }
}
