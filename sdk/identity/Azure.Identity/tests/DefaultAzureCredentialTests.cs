// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using Moq;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class DefaultAzureCredentialTests : ClientTestBase
    {
        public DefaultAzureCredentialTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]

        public void ValidateCtorNoOptions()
        {
            var cred = new DefaultAzureCredential();

            TokenCredential[] sources = cred._sources();

            Assert.NotNull(sources);
            Assert.AreEqual(sources.Length, 7);
            Assert.IsInstanceOf(typeof(EnvironmentCredential), sources[0]);
            Assert.IsInstanceOf(typeof(WorkloadIdentityCredential), sources[1]);
            Assert.IsInstanceOf(typeof(ManagedIdentityCredential), sources[2]);
            Assert.IsInstanceOf(typeof(VisualStudioCredential), sources[3]);
            Assert.IsInstanceOf(typeof(AzureCliCredential), sources[4]);
            Assert.IsInstanceOf(typeof(AzurePowerShellCredential), sources[5]);
            Assert.IsInstanceOf(typeof(AzureDeveloperCliCredential), sources[6]);
        }

        [Test]
        public void ValidateCtorIncludedInteractiveParam([Values(true, false)] bool includeInteractive)
        {
            var cred = new DefaultAzureCredential(includeInteractive);

            TokenCredential[] sources = cred._sources();

            Assert.NotNull(sources);
            Assert.AreEqual(sources.Length, includeInteractive ? 8 : 7);

            Assert.IsInstanceOf(typeof(EnvironmentCredential), sources[0]);
            Assert.IsInstanceOf(typeof(WorkloadIdentityCredential), sources[1]);
            Assert.IsInstanceOf(typeof(ManagedIdentityCredential), sources[2]);
            Assert.IsInstanceOf(typeof(VisualStudioCredential), sources[3]);
            Assert.IsInstanceOf(typeof(AzureCliCredential), sources[4]);
            Assert.IsInstanceOf(typeof(AzurePowerShellCredential), sources[5]);
            Assert.IsInstanceOf(typeof(AzureDeveloperCliCredential), sources[6]);

            if (includeInteractive)
            {
                Assert.IsInstanceOf(typeof(InteractiveBrowserCredential), sources[7]);
            }
        }

        public static IEnumerable<object[]> ExcludeCredOptions()
        {
            yield return new object[] { false, true, false, false, false, false, false, false, false, false };
            yield return new object[] { false, false, true, false, false, false, false, false, false, false };
            yield return new object[] { true, false, false, false, false, false, false, false, false, false };
            yield return new object[] { false, false, false, true, false, false, false, false, false, false };
            yield return new object[] { false, false, false, false, true, false, false, false, false, false };
            yield return new object[] { false, false, false, false, false, true, false, false, false, false };
            yield return new object[] { false, false, false, false, false, false, true, false, false, false };
            yield return new object[] { false, false, false, false, false, false, false, true, false, false };
            yield return new object[] { false, false, false, false, false, false, false, false, true, false };
            yield return new object[] { false, false, false, false, false, false, false, false, false, true };
        }

        [Test]
        [TestCaseSource(nameof(ExcludeCredOptions))]
        public void ValidateAllUnavailable(bool excludeEnvironmentCredential,
                                           bool excludeWorkloadIdentityCredential,
                                           bool excludeManagedIdentityCredential,
                                           bool excludeDeveloperCliCredential,
                                           bool excludeSharedTokenCacheCredential,
                                           bool excludeVisualStudioCredential,
                                           bool excludeVisualStudioCodeCredential,
                                           bool excludeCliCredential,
                                           bool excludePowerShellCredential,
                                           bool excludeInteractiveBrowserCredential)
        {
            if (excludeEnvironmentCredential && excludeWorkloadIdentityCredential && excludeManagedIdentityCredential && excludeDeveloperCliCredential && excludeSharedTokenCacheCredential && excludeVisualStudioCredential && excludeVisualStudioCodeCredential && excludeCliCredential && excludeInteractiveBrowserCredential)
            {
                Assert.Pass();
            }

            var options = new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = excludeEnvironmentCredential,
                ExcludeWorkloadIdentityCredential = excludeWorkloadIdentityCredential,
                ExcludeManagedIdentityCredential = excludeManagedIdentityCredential,
                ExcludeAzureDeveloperCliCredential = excludeDeveloperCliCredential,
                ExcludeSharedTokenCacheCredential = excludeSharedTokenCacheCredential,
                ExcludeVisualStudioCredential = excludeVisualStudioCredential,
                ExcludeVisualStudioCodeCredential = excludeVisualStudioCodeCredential,
                ExcludeAzureCliCredential = excludeCliCredential,
                ExcludeAzurePowerShellCredential = excludePowerShellCredential,
                ExcludeInteractiveBrowserCredential = excludeInteractiveBrowserCredential,
            };

            var credFactory = new MockDefaultAzureCredentialFactory(options);

            void SetupMockForException<T>(Mock<T> mock) where T : TokenCredential =>
                mock.Setup(m => m.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                    .Throws(new CredentialUnavailableException($"{typeof(T).Name} Unavailable"));

            credFactory.OnCreateEnvironmentCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateInteractiveBrowserCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateWorkloadIdentityCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateManagedIdentityCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateAzureDeveloperCliCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateSharedTokenCacheCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateAzureCliCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateAzurePowerShellCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateVisualStudioCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateVisualStudioCodeCredential = c =>
                SetupMockForException(c);

            var cred = new DefaultAzureCredential(credFactory);

            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await cred.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            if (!excludeEnvironmentCredential)
            {
                Assert.True(ex.Message.Contains("EnvironmentCredential Unavailable"));
            }
            if (!excludeWorkloadIdentityCredential)
            {
                Assert.True(ex.Message.Contains("WorkloadIdentityCredential Unavailable"));
            }
            if (!excludeManagedIdentityCredential)
            {
                Assert.True(ex.Message.Contains("ManagedIdentityCredential Unavailable"));
            }
            if (!excludeDeveloperCliCredential)
            {
                Assert.True(ex.Message.Contains("DeveloperCliCredential Unavailable"));
            }
            if (!excludeSharedTokenCacheCredential)
            {
                Assert.True(ex.Message.Contains("SharedTokenCacheCredential Unavailable"));
            }
            if (!excludeCliCredential)
            {
                Assert.True(ex.Message.Contains("CliCredential Unavailable"));
            }
            if (!excludePowerShellCredential)
            {
                Assert.True(ex.Message.Contains("PowerShellCredential Unavailable"));
            }
            if (!excludeInteractiveBrowserCredential)
            {
                Assert.True(ex.Message.Contains("InteractiveBrowserCredential Unavailable"));
            }
            if (!excludeVisualStudioCredential)
            {
                Assert.True(ex.Message.Contains("VisualStudioCredential Unavailable"));
            }
            if (!excludeVisualStudioCodeCredential)
            {
                Assert.True(ex.Message.Contains("VisualStudioCodeCredential Unavailable"));
            }
        }

        [Test]
        [TestCaseSource(nameof(AllCredentialTypes))]
        public void ValidateUnhandledException(Type credentialType)
        {
            var options = new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = false,
                ExcludeWorkloadIdentityCredential = false,
                ExcludeManagedIdentityCredential = false,
                ExcludeAzureDeveloperCliCredential = false,
                ExcludeSharedTokenCacheCredential = false,
                ExcludeVisualStudioCredential = false,
                ExcludeVisualStudioCodeCredential = false,
                ExcludeAzureCliCredential = false,
                ExcludeAzurePowerShellCredential = false,
                ExcludeInteractiveBrowserCredential = false
            };

            var credFactory = new MockDefaultAzureCredentialFactory(options);

            void SetupMockForException<T>(Mock<T> mock) where T : TokenCredential
            {
                Exception e;
                if (typeof(T) != credentialType)
                {
                    e = new CredentialUnavailableException($"{typeof(T).Name} Unavailable");
                }
                else
                {
                    e = new MockClientException($"{typeof(T).Name} unhandled exception");
                }
                mock.Setup(m => m.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                    .Throws(e);
            }

            credFactory.OnCreateEnvironmentCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateWorkloadIdentityCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateManagedIdentityCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateAzureDeveloperCliCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateSharedTokenCacheCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateVisualStudioCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateVisualStudioCodeCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateAzureCliCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateAzurePowerShellCredential = c =>
                SetupMockForException(c);

            credFactory.OnCreateInteractiveBrowserCredential = c =>
            {
                c.Setup(m => m.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                    .Throws(new MockClientException("InteractiveBrowserCredential unhandled exception"));
            };

            var cred = new DefaultAzureCredential(credFactory);

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await cred.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
            var unhandledException = ex.InnerException is AggregateException ae ? ae.InnerExceptions.Last() : ex.InnerException;

            Assert.AreEqual($"{credentialType.Name} unhandled exception", unhandledException.Message);
        }

        public static IEnumerable<object[]> AllCredentialTypes()
        {
            yield return new object[] { typeof(EnvironmentCredential) };
            yield return new object[] { typeof(SharedTokenCacheCredential) };
            yield return new object[] { typeof(VisualStudioCredential) };
            yield return new object[] { typeof(VisualStudioCodeCredential) };
            yield return new object[] { typeof(AzureCliCredential) };
            yield return new object[] { typeof(InteractiveBrowserCredential) };
            yield return new object[] { typeof(ManagedIdentityCredential) };
            yield return new object[] { typeof(AzurePowerShellCredential) };
            yield return new object[] { typeof(AzureDeveloperCliCredential) };
            yield return new object[] { typeof(WorkloadIdentityCredential) };
        }

        [Test]
        [TestCaseSource(nameof(AllCredentialTypes))]
        public async Task ValidateSelectedCredentialCaching(Type availableCredential)
        {
            var expToken = new AccessToken(Guid.NewGuid().ToString(), DateTimeOffset.MaxValue);
            List<Type> calledCredentials = new();

            var options = new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = false,
                ExcludeManagedIdentityCredential = false,
                ExcludeAzureDeveloperCliCredential = false,
                ExcludeSharedTokenCacheCredential = false,
                ExcludeVisualStudioCredential = false,
                ExcludeVisualStudioCodeCredential = false,
                ExcludeAzureCliCredential = false,
                ExcludeAzurePowerShellCredential = false,
                ExcludeInteractiveBrowserCredential = false
            };

            var credFactory = GetMockDefaultAzureCredentialFactory(options, availableCredential, expToken, calledCredentials);

            var cred = InstrumentClient(new DefaultAzureCredential(credFactory));

            AccessToken actToken = await cred.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(expToken.Token, actToken.Token);

            // assert that the available credential was the last credential called
            Assert.AreEqual(calledCredentials[calledCredentials.Count - 1], availableCredential);

            calledCredentials.Clear();

            actToken = await cred.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(expToken.Token, actToken.Token);

            // assert that the available credential was the only credential called
            Assert.AreEqual(calledCredentials.Count, 1);

            Assert.AreEqual(calledCredentials[0], availableCredential);
        }

        [Test]
        [TestCaseSource(nameof(AllCredentialTypes))]
        public async Task CredentialTypeLogged(Type availableCredential)
        {
            List<string> messages = new();
            using AzureEventSourceListener listener = new AzureEventSourceListener(
                (_, message) => messages.Add(message),
                EventLevel.Informational);

            var expToken = new AccessToken(Guid.NewGuid().ToString(), DateTimeOffset.MaxValue);
            List<Type> calledCredentials = new();

            var options = new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = false,
                ExcludeWorkloadIdentityCredential = false,
                ExcludeManagedIdentityCredential = false,
                ExcludeAzureDeveloperCliCredential = false,
                ExcludeSharedTokenCacheCredential = false,
                ExcludeVisualStudioCredential = false,
                ExcludeVisualStudioCodeCredential = false,
                ExcludeAzureCliCredential = false,
                ExcludeAzurePowerShellCredential = false,
                ExcludeInteractiveBrowserCredential = false
            };

            var credFactory = GetMockDefaultAzureCredentialFactory(options, availableCredential, expToken, calledCredentials);

            var cred = InstrumentClient(new DefaultAzureCredential(credFactory));

            await cred.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.That(messages, Has.Some.Match(availableCredential.Name).And.Some.Match("DefaultAzureCredential credential selected"));
        }

        [Test]
        [TestCaseSource(nameof(AllCredentialTypes))]
        public void DisableMetadataDiscoveryOptionIsHonoredWhenTrue(Type availableCredential)
        {
            Type targetCredOptionsType = GetTargetCredentialOptionType(availableCredential);

            if (!typeof(ISupportsDisableInstanceDiscovery).IsAssignableFrom(targetCredOptionsType))
            {
                Assert.Ignore($"Credential {availableCredential.Name} does not support disabling instance discovery");
            }

            using (new TestEnvVar(new Dictionary<string, string> {
                    { "AZURE_CLIENT_ID", "mockclientid" },
                    { "AZURE_CLIENT_SECRET", null},
                    { "AZURE_TENANT_ID", "mocktenantid" },
                    {"AZURE_USERNAME", "mockusername" },
                    { "AZURE_PASSWORD", "mockpassword" },
                    { "AZURE_CLIENT_CERTIFICATE_PATH", null },
                    { "AZURE_FEDERATED_TOKEN_FILE", "/temp/token" } }))
            {
                DefaultAzureCredentialOptions options = GetDacOptions(availableCredential, true);

                var credential = new DefaultAzureCredential(options);
                Assert.AreEqual(1, credential._sources.Length);
                var targetCred = credential._sources[0];
                bool DisableInstanceDiscovery = CredentialTestHelpers.ExtractMsalDisableInstanceDiscoveryProperty(targetCred);

                Assert.IsTrue(DisableInstanceDiscovery);
            }
        }

        [Test]
        [TestCaseSource(nameof(AllCredentialTypes))]
        public void DisableMetadataDiscoveryOptionIsHonoredWhenFalse(Type availableCredential)
        {
            Type targetCredOptionsType = GetTargetCredentialOptionType(availableCredential);

            if (!typeof(ISupportsDisableInstanceDiscovery).IsAssignableFrom(targetCredOptionsType))
            {
                Assert.Ignore($"Credential {availableCredential.Name} does not support disabling instance discovery");
            }

            using (new TestEnvVar(new Dictionary<string, string> {
                    { "AZURE_CLIENT_ID", "mockclientid" },
                    { "AZURE_CLIENT_SECRET", null},
                    { "AZURE_TENANT_ID", "mocktenantid" },
                    {"AZURE_USERNAME", "mockusername" },
                    { "AZURE_PASSWORD", "mockpassword" },
                    { "AZURE_CLIENT_CERTIFICATE_PATH", null },
                    { "AZURE_FEDERATED_TOKEN_FILE", "c:/temp/token" } }))
            {
                DefaultAzureCredentialOptions options = GetDacOptions(availableCredential, false);
                var credential = new DefaultAzureCredential(options);
                Assert.AreEqual(1, credential._sources.Length);
                var targetCred = credential._sources[0];
                bool DisableInstanceDiscovery = CredentialTestHelpers.ExtractMsalDisableInstanceDiscoveryProperty(targetCred);

                Assert.IsFalse(DisableInstanceDiscovery);
            }
        }

        [Test]
        [TestCaseSource(nameof(AllCredentialTypes))]
        public void AdditionallyAllowedTenantsOptionIsHonored(Type availableCredential)
        {
            using (new TestEnvVar(new Dictionary<string, string> {
                    { "AZURE_CLIENT_ID", "mockclientid" },
                    { "AZURE_CLIENT_SECRET", null},
                    { "AZURE_TENANT_ID", "mocktenantid" },
                    {"AZURE_USERNAME", "mockusername" },
                    { "AZURE_PASSWORD", "mockpassword" },
                    { "AZURE_CLIENT_CERTIFICATE_PATH", null },
                    { "AZURE_FEDERATED_TOKEN_FILE", "c:/temp/token" }
            }))
            {
                DefaultAzureCredentialOptions options = GetDacOptions(availableCredential, false);
                var additionalTenant = Guid.NewGuid().ToString();
                options.AdditionallyAllowedTenants.Add(additionalTenant);

                var credential = new DefaultAzureCredential(options);
                Assert.AreEqual(1, credential._sources.Length);
                var targetCred = credential._sources[0];
                if (targetCred is SharedTokenCacheCredential || targetCred is ManagedIdentityCredential)
                {
                    Assert.Ignore($"Credential {availableCredential.Name} does not support additional tenants");
                }
                string[] additionallyAllowedTenantIds = CredentialTestHelpers.ExtractAdditionalTenantProperty(targetCred);

                CollectionAssert.Contains(additionallyAllowedTenantIds, additionalTenant);
            }
        }

        [Test]
        [TestCaseSource(nameof(AllCredentialTypes))]
        public void TenantIdOptionOverridesEnvironment(Type availableCredential)
        {
            using (new TestEnvVar(new Dictionary<string, string> {
                    { "AZURE_CLIENT_ID", "mockclientid" },
                    { "AZURE_CLIENT_SECRET", null},
                    { "AZURE_TENANT_ID", "mocktenantid" },
                    {"AZURE_USERNAME", "mockusername" },
                    { "AZURE_PASSWORD", "mockpassword" },
                    { "AZURE_CLIENT_CERTIFICATE_PATH", null },
                    { "AZURE_FEDERATED_TOKEN_FILE", "c:/temp/token" }
            }))
            {
                DefaultAzureCredentialOptions options = GetDacOptions(availableCredential, false, "overridetenantid");
                var additionalTenant = Guid.NewGuid().ToString();
                options.AdditionallyAllowedTenants.Add(additionalTenant);

                var credential = new DefaultAzureCredential(options);
                Assert.AreEqual(1, credential._sources.Length);
                var targetCred = credential._sources[0];
                if (CredentialTestHelpers.TryGetConfiguredTenantIdForMsalCredential(targetCred, out string tenantId))
                {
                    if (availableCredential == typeof(ManagedIdentityCredential))
                    {
                        Assert.Ignore("ManagedIdentityCredential does not include a TenantId option.");
                    }
                    else
                    {
                        Assert.AreEqual("overridetenantid", tenantId);
                    }
                }
            }
        }

        [Test]
        public void ExcludeWorkloadIdentityCredential_Disables_TokenExchangeManagedIdentitySource()
        {
            var availableCredential = typeof(ManagedIdentityCredential);

            // Set environment variables to use token exchange managed identity source
            using (new TestEnvVar(new Dictionary<string, string> {
                    { "AZURE_CLIENT_ID", "mockclientid" },
                    { "AZURE_TENANT_ID", "mocktenantid" },
                    { "AZURE_FEDERATED_TOKEN_FILE", "c:/temp/token" }
            }))
            {
                DefaultAzureCredentialOptions options = GetDacOptions(availableCredential, false);
                // exclude workload identity credential to exclude use of token exchange managed identity source
                options.ExcludeWorkloadIdentityCredential = true;

                var credential = new DefaultAzureCredential(options);
                Assert.AreEqual(1, credential._sources.Length);
                var targetCred = credential._sources[0];

                Assert.IsInstanceOf<ManagedIdentityCredential>(targetCred);
                ManagedIdentityCredential miCred = targetCred as ManagedIdentityCredential;
                var source = miCred.Client._identitySource.Value;
                Assert.IsNotInstanceOf<TokenExchangeManagedIdentitySource>(source);
            }
        }

        private static DefaultAzureCredentialOptions GetDacOptions(Type availableCredential, bool disableInstanceDiscovery, string tenantId = null)
        {
            var options = new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = availableCredential != typeof(EnvironmentCredential),
                ExcludeWorkloadIdentityCredential = availableCredential != typeof(WorkloadIdentityCredential),
                ExcludeManagedIdentityCredential = availableCredential != typeof(ManagedIdentityCredential),
                ExcludeAzureDeveloperCliCredential = availableCredential != typeof(AzureDeveloperCliCredential),
                ExcludeSharedTokenCacheCredential = availableCredential != typeof(SharedTokenCacheCredential),
                ExcludeVisualStudioCredential = availableCredential != typeof(VisualStudioCredential),
                ExcludeVisualStudioCodeCredential = availableCredential != typeof(VisualStudioCodeCredential),
                ExcludeAzureCliCredential = availableCredential != typeof(AzureCliCredential),
                ExcludeAzurePowerShellCredential = availableCredential != typeof(AzurePowerShellCredential),
                ExcludeInteractiveBrowserCredential = availableCredential != typeof(InteractiveBrowserCredential),
                DisableInstanceDiscovery = disableInstanceDiscovery,
            };
            if (tenantId != null)
            {
                options.TenantId = tenantId;
            }
            return options;
        }

        private static Type GetTargetCredentialOptionType(Type availableCredential)
        {
            return availableCredential.Name switch
            {
                "SharedTokenCacheCredential" => typeof(SharedTokenCacheCredentialOptions),
                "VisualStudioCredential" => typeof(VisualStudioCredentialOptions),
                "VisualStudioCodeCredential" => typeof(VisualStudioCodeCredentialOptions),
                "AzureCliCredential" => typeof(AzureCliCredentialOptions),
                "AzurePowerShellCredential" => typeof(AzurePowerShellCredentialOptions),
                "InteractiveBrowserCredential" => typeof(InteractiveBrowserCredentialOptions),
                "WorkloadIdentityCredential" => typeof(WorkloadIdentityCredentialOptions),
                "ManagedIdentityCredential" => typeof(TokenCredentialOptions),
                "AzureDeveloperCliCredential" => typeof(AzureDeveloperCliCredentialOptions),
                "EnvironmentCredential" => typeof(EnvironmentCredentialOptions),
                _ => throw new InvalidOperationException($"Unexpected credential type {availableCredential.Name}")
            };
        }

        internal MockDefaultAzureCredentialFactory GetMockDefaultAzureCredentialFactory(DefaultAzureCredentialOptions options, Type availableCredential, AccessToken expToken, List<Type> calledCredentials)
        {
            var credFactory = new MockDefaultAzureCredentialFactory(options);

            void SetupMockForException<T>(Mock<T> mock) where T : TokenCredential
            {
                if (IsAsync)
                    mock.Setup(m => m.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                        .Callback(() => calledCredentials.Add(typeof(T)))
                        .ReturnsAsync(() =>
                        {
                            return availableCredential == typeof(T) ? expToken : throw new CredentialUnavailableException("Unavailable");
                        });
                else
                    mock.Setup(m => m.GetToken(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                        .Callback(() => calledCredentials.Add(typeof(T)))
                        .Returns(() =>
                        {
                            return availableCredential == typeof(T) ? expToken : throw new CredentialUnavailableException("Unavailable");
                        });
            }

            credFactory.OnCreateEnvironmentCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateWorkloadIdentityCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateManagedIdentityCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateAzureDeveloperCliCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateSharedTokenCacheCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateAzureCliCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateInteractiveBrowserCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateVisualStudioCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateVisualStudioCodeCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateAzurePowerShellCredential = c =>
                SetupMockForException(c);

            return credFactory;
        }
    }
}
