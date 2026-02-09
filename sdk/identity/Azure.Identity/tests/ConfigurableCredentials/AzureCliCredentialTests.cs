// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.Identity.Tests.ConfigurableCredentials.AzureCli
{
    internal class AzureCliCredentialTests : ConfigurableCredentialTestBase<AzureCliCredential, AzureCliCredentialOptions>
    {
        public AzureCliCredentialTests(bool isAsync) : base(isAsync)
        {
        }

        protected override string CredentialSource => "AzureCli";

        [Test]
        public async Task AuthenticateWithCliCredential(
            [Values(null, TenantIdHint)] string tenantId,
            [Values(null, "1a7eed92-726e-46c0-b21d-a3db74b3b58c", "My Subscription Name -_")] string subscription,
            [Values(true)] bool allowMultiTenantAuthentication,
            [Values(null, TenantId)] string explicitTenantId)
        {
            // Use TestEnvVar to temporarily clear AZURE_TENANT_ID so DefaultAzureCredentialOptions doesn't pick it up
            using (new TestEnvVar("AZURE_TENANT_ID", null))
            {
                var context = new TokenRequestContext([Scope], tenantId: tenantId);
                IConfiguration config = GetConfiguration();
                if (explicitTenantId != null)
                {
                    config["MyClient:Credential:TenantId"] = explicitTenantId;
                }
                config["MyClient:Credential:AdditionallyAllowedTenants:0"] = TenantIdHint;
                if (subscription != null)
                {
                    config["MyClient:Credential:Subscription"] = subscription;
                }
                string expectedTenantId = TenantIdResolverBase.Default.Resolve(explicitTenantId, context, TenantIdResolverBase.AllTenants);
                var (expectedToken, expectedExpiresOn, processOutput) = CredentialTestHelpers.CreateTokenForAzureCli();

                var testProcess = new TestProcess { Output = processOutput };
                ConfigurableCredential credential = InstrumentCredential(GetCredentialFromConfig(config), new TestProcessService(testProcess, true));
                AccessToken actualToken = await credential.GetTokenAsync(context);

                Assert.AreEqual(expectedToken, actualToken.Token);
                Assert.AreEqual(expectedExpiresOn, actualToken.ExpiresOn);

                var expectTenantId = expectedTenantId != null;
                if (expectTenantId)
                {
                    Assert.That(testProcess.StartInfo.Arguments, Does.Contain($"-tenant {expectedTenantId}"));
                }
                else
                {
                    Assert.That(testProcess.StartInfo.Arguments, Does.Not.Contain("-tenant"));
                }

                if (subscription != null)
                {
                    Assert.That(testProcess.StartInfo.Arguments, Does.Contain($"--subscription \"{subscription}\""));
                }
                else
                {
                    Assert.That(testProcess.StartInfo.Arguments, Does.Not.Contain("--subscription"));
                }
            }
        }

        [Test]
        public void AzureCliCredentialOptionsValidatesSubscriptionOption()
        {
            IConfiguration config = GetConfiguration();
            config["MyClient:Credential:Subscription"] = "My Subscription Name with a quote \"";
            Assert.Throws<ArgumentException>(() => { ConfigurableCredential credential = GetCredentialFromConfig(config); });

            config["MyClient:Credential:Subscription"] = "My Subscription Name -_";
            ConfigurableCredential credential = GetCredentialFromConfig(config);

            config["MyClient:Credential:Subscription"] = Guid.NewGuid().ToString();
            credential = GetCredentialFromConfig(config);
        }

        [Test]
        public async Task AuthenticateWithCliCredential_expires_on()
        {
            var now = DateTimeOffset.UtcNow;
            DateTimeOffset expectedExpiresOn = new DateTimeOffset(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, TimeSpan.Zero).AddHours(1);
            var (expectedToken1, processOutput1) = CredentialTestHelpers.CreateTokenForAzureCliExpiresOn(expectedExpiresOn, true);
            var (expectedToken2, processOutput2) = CredentialTestHelpers.CreateTokenForAzureCliExpiresOn(expectedExpiresOn, false);

            IConfiguration config = GetConfiguration();
            TestProcess testProcess = new() { Output = processOutput1 };

            ConfigurableCredential credential = InstrumentCredential(GetCredentialFromConfig(config), new TestProcessService(testProcess, true));
            AccessToken actualToken1 = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(expectedToken1, actualToken1.Token, "The tokens should match.");
            Assert.AreEqual(expectedExpiresOn, actualToken1.ExpiresOn, "The expires on value should be the same for token1.");

            testProcess = new TestProcess { Output = processOutput2 };
            credential = InstrumentCredential(GetCredentialFromConfig(config), new TestProcessService(testProcess, true));
            AccessToken actualToken2 = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(expectedToken2, actualToken2.Token);
            Assert.AreEqual(expectedExpiresOn, actualToken2.ExpiresOn, "The expires on value should be the same for token2.");

            Assert.AreEqual(actualToken1.ExpiresOn, actualToken2.ExpiresOn);
        }

        protected override IConfiguration GetConfigurationCore(IConfiguration config)
        {
            config["MyClient:Credential:CredentialSource"] = "AzureCli";
            return config;
        }

        [Test]
        public void AuthenticateWithCliCredential_InvalidJsonOutput(
            [Values("", "{}", "{\"Some\": false}", "{\"accessToken\": \"token\"}", "{\"expiresOn\" : \"1900-01-01 00:00:00.123456\"}")]
            string jsonContent)
        {
            IConfiguration config = GetConfiguration();
            var testProcess = new TestProcess { Output = jsonContent };
            ConfigurableCredential credential = InstrumentCredential(GetCredentialFromConfig(config), new TestProcessService(testProcess, true));
            // Note: Wrapped by DefaultAzureCredential into CredentialUnavailableException
            Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
        }

        // Note: When using ConfigurableCredential, exceptions from the underlying credential are wrapped by
        // DefaultAzureCredential into CredentialUnavailableException. This matches the _IsChained scenarios
        // from the original AzureCliCredentialTests.
        public static IEnumerable<object[]> AzureCliExceptionScenarios() => Tests.AzureCliCredentialTests.AzureCliExceptionScenarios_IsChained();

        [Test]
        [TestCaseSource(nameof(AzureCliExceptionScenarios))]
        public void AuthenticateWithCliCredential_ExceptionScenarios(Action<object> exceptionOnStartHandler, string errorMessage, string expectedMessage, Type exceptionType)
        {
            IConfiguration config = GetConfiguration();
            var testProcess = new TestProcess { Error = errorMessage, ExceptionOnStartHandler = exceptionOnStartHandler };
            ConfigurableCredential credential = InstrumentCredential(GetCredentialFromConfig(config), new TestProcessService(testProcess, true));
            var ex = Assert.ThrowsAsync(exceptionType, async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
            Assert.That(ex.Message, Does.Contain(expectedMessage));
        }

        [Test]
        public void AuthenticateWithCliCredential_CanceledByUser()
        {
            IConfiguration config = GetConfiguration();
            var cts = new CancellationTokenSource();
            var testProcess = new TestProcess { Timeout = 10000 };
            testProcess.Started += (o, e) => cts.Cancel();
            ConfigurableCredential credential = InstrumentCredential(GetCredentialFromConfig(config), new TestProcessService(testProcess, true));
            // Note: The OperationCanceledException may be wrapped, so we catch any exception and verify it's cancellation-related
            var ex = Assert.CatchAsync<Exception>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), cts.Token));
            Assert.That(ex.Message, Does.Contain("canceled").IgnoreCase);
        }

        // Skipped: AuthenticateWithCliCredential_ClaimsChallenge_NoTenant_ThrowsWithGuidance
        // Challenge: DefaultAzureCredentialOptions.TenantId defaults to AZURE_TENANT_ID environment variable,
        // so when no tenant is explicitly set, it still picks up the env tenant. This changes the expected
        // error message format.

        [Test]
        public void ConfigureCliProcessTimeout_ProcessTimeout()
        {
            IConfiguration config = GetConfiguration();
            config["MyClient:Credential:CredentialProcessTimeout"] = "00:00:00"; // Zero timeout
            var testProcess = new TestProcess { Timeout = 10000 };
            ConfigurableCredential credential = InstrumentCredential(GetCredentialFromConfig(config), new TestProcessService(testProcess, true));

            // Note: Wrapped by DefaultAzureCredential into CredentialUnavailableException
            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
            Assert.That(ex.Message, Does.Contain(AzureCliCredential.AzureCliTimeoutError));
        }

        [TestCaseSource(nameof(NegativeTestCharacters))]
        public void VerifyCtorTenantIdValidation(char testChar)
        {
            string tenantId = Guid.NewGuid().ToString();

            for (int i = 0; i < tenantId.Length; i++)
            {
                StringBuilder tenantIdBuilder = new StringBuilder(tenantId);
                tenantIdBuilder.Insert(i, testChar);

                IConfiguration config = GetConfiguration();
                config["MyClient:Credential:TenantId"] = tenantIdBuilder.ToString();

                Assert.Throws<ArgumentException>(() => GetCredentialFromConfig(config), Validations.InvalidTenantIdErrorMessage);
            }
        }

        [TestCaseSource(nameof(NegativeTestCharacters))]
        public void VerifyGetTokenTenantIdValidation(char testChar)
        {
            IConfiguration config = GetConfiguration();
            ConfigurableCredential credential = InstrumentCredential(GetCredentialFromConfig(config));

            string tenantId = Guid.NewGuid().ToString();

            for (int i = 0; i < tenantId.Length; i++)
            {
                StringBuilder tenantIdBuilder = new StringBuilder(tenantId);
                tenantIdBuilder.Insert(i, testChar);

                var tokenRequestContext = new TokenRequestContext(MockScopes.Default, tenantId: tenantIdBuilder.ToString());

                // Note: Wrapped by DefaultAzureCredential into CredentialUnavailableException
                Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(tokenRequestContext), Validations.InvalidTenantIdErrorMessage);
            }
        }

        [TestCaseSource(nameof(NegativeTestCharacters))]
        public void VerifyGetTokenScopeValidation(char testChar)
        {
            IConfiguration config = GetConfiguration();
            ConfigurableCredential credential = InstrumentCredential(GetCredentialFromConfig(config));

            string scope = MockScopes.Default.ToString();

            for (int i = 0; i < scope.Length; i++)
            {
                StringBuilder scopeBuilder = new StringBuilder(scope);
                scopeBuilder.Insert(i, testChar);

                var tokenRequestContext = new TokenRequestContext(new string[] { scopeBuilder.ToString() });

                // Note: Wrapped by DefaultAzureCredential into CredentialUnavailableException
                Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(tokenRequestContext), ScopeUtilities.InvalidScopeMessage);
            }
        }

        [Test]
        public void AuthenticateWithCliCredential_ClaimsChallenge_NoTenant_ThrowsWithGuidance()
        {
            // Arrange: claims challenge provided, no tenant specified
            // Use TestEnvVar to temporarily clear AZURE_TENANT_ID so DefaultAzureCredentialOptions doesn't pick it up
            using (new TestEnvVar("AZURE_TENANT_ID", null))
            {
                var claims = "test-claims-challenge";

                IConfiguration config = GetConfiguration();
                var (_, _, processOutput) = CredentialTestHelpers.CreateTokenForAzureCli();
                var testProcess = new TestProcess { Output = processOutput };
                ConfigurableCredential credential = InstrumentCredential(GetCredentialFromConfig(config), new TestProcessService(testProcess, true));

                var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () =>
                    await credential.GetTokenAsync(new TokenRequestContext(new[] { Scope }, claims: claims)));

                Assert.That(ex.Message, Does.Contain("Azure CLI authentication requires multi-factor authentication or additional claims."));
                Assert.That(ex.Message, Does.Contain($"az login --claims-challenge {claims}"));
                // Should not include a tenant switch when tenant is not resolved
                Assert.That(ex.Message, Does.Not.Contain("--tenant"));
            }
        }

        [Test]
        public void AuthenticateWithCliCredential_ClaimsChallenge_WithTenant_ThrowsWithGuidance()
        {
            // Arrange: claims challenge provided with tenant
            var claims = "test-claims-challenge";

            IConfiguration config = GetConfiguration();
            config["MyClient:Credential:TenantId"] = TenantId;
            var (_, _, processOutput) = CredentialTestHelpers.CreateTokenForAzureCli();
            var testProcess = new TestProcess { Output = processOutput };
            ConfigurableCredential credential = InstrumentCredential(GetCredentialFromConfig(config), new TestProcessService(testProcess, true));

            // Note: Wrapped by DefaultAzureCredential into CredentialUnavailableException
            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () =>
                await credential.GetTokenAsync(new TokenRequestContext(new[] { Scope }, claims: claims)));

            Assert.That(ex.Message, Does.Contain("Azure CLI authentication requires multi-factor authentication or additional claims."));
            Assert.That(ex.Message, Does.Contain($"az login --tenant {TenantId} --claims-challenge {claims}"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public async Task AuthenticateWithCliCredential_EmptyOrWhitespaceClaims_DoesNotTriggerGuidance(string claims)
        {
            IConfiguration config = GetConfiguration();
            var (expectedToken, expectedExpiresOn, processOutput) = CredentialTestHelpers.CreateTokenForAzureCli();
            var testProcess = new TestProcess { Output = processOutput };
            ConfigurableCredential credential = InstrumentCredential(GetCredentialFromConfig(config), new TestProcessService(testProcess, true));

            var token = await credential.GetTokenAsync(new TokenRequestContext(new[] { Scope }, claims: claims));
            Assert.AreEqual(expectedToken, token.Token);
            Assert.AreEqual(expectedExpiresOn, token.ExpiresOn);
        }
    }
}
