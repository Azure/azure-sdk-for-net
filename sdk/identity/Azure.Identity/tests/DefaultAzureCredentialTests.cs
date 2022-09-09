// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
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
            Assert.AreEqual(sources.Length, 8);
            Assert.IsInstanceOf(typeof(EnvironmentCredential), sources[0]);
            Assert.IsInstanceOf(typeof(ManagedIdentityCredential), sources[1]);
            Assert.IsInstanceOf(typeof(VisualStudioCredential), sources[2]);
            Assert.IsInstanceOf(typeof(VisualStudioCodeCredential), sources[3]);
            Assert.IsInstanceOf(typeof(AzureCliCredential), sources[4]);
            Assert.IsInstanceOf(typeof(AzurePowerShellCredential), sources[5]);
            Assert.IsNull(sources[7]);
        }

        [Test]
        public void ValidateCtorIncludedInteractiveParam([Values(true, false)] bool includeInteractive)
        {
            var cred = new DefaultAzureCredential(includeInteractive);

            TokenCredential[] sources = cred._sources();

            Assert.NotNull(sources);
            Assert.AreEqual(sources.Length, 8);
            Assert.IsInstanceOf(typeof(EnvironmentCredential), sources[0]);
            Assert.IsInstanceOf(typeof(ManagedIdentityCredential), sources[1]);
            Assert.IsInstanceOf(typeof(VisualStudioCredential), sources[2]);
            Assert.IsInstanceOf(typeof(VisualStudioCodeCredential), sources[3]);
            Assert.IsInstanceOf(typeof(AzureCliCredential), sources[4]);
            Assert.IsInstanceOf(typeof(AzurePowerShellCredential), sources[5]);

            if (includeInteractive)
            {
                Assert.IsInstanceOf(typeof(InteractiveBrowserCredential), sources[6]);
            }
            else
            {
                Assert.IsNull(sources[6]);
            }
        }

        public enum ManagedIdentityIdType
        {
            None,
            ClientId,
            ResourceId
        }

        [Test]
        public void ValidateCtorOptionsPassedToCredentials([Values(ManagedIdentityIdType.None, ManagedIdentityIdType.ClientId, ManagedIdentityIdType.ResourceId)] ManagedIdentityIdType managedIdentityIdType)
        {
            string expClientId = Guid.NewGuid().ToString();
            string expUsername = Guid.NewGuid().ToString();
            string expCacheTenantId = Guid.NewGuid().ToString();
            string expBrowserTenantId = Guid.NewGuid().ToString();
            string expVsTenantId = Guid.NewGuid().ToString();
            string expCodeTenantId = Guid.NewGuid().ToString();
            string expResourceId =  $"/subscriptions/{Guid.NewGuid().ToString()}/locations/MyLocation";
            TimeSpan developerCredentialTimeout = TimeSpan.FromSeconds(42);
            string actClientId_ManagedIdentity = null;
            string actResiurceId_ManagedIdentity = null;
            string actClientId_InteractiveBrowser = null;
            string actUsername = null;
            string actCacheTenantId = null;
            string actBrowserTenantId = null;
            string actVsTenantId = null;
            string actCodeTenantId = null;
            TimeSpan? actSubProcessTimeout = TimeSpan.Zero;

            var credFactory = new MockDefaultAzureCredentialFactory(CredentialPipeline.GetInstance(null));

            credFactory.OnCreateManagedIdentityCredential = (options, _) =>
            {
                actClientId_ManagedIdentity = options.ManagedIdentityClientId;
                actResiurceId_ManagedIdentity = options.ManagedIdentityResourceId?.ToString();
            };
            credFactory.OnCreateSharedTokenCacheCredential = (tenantId, username, _) => { actCacheTenantId = tenantId; actUsername = username; };
            credFactory.OnCreateInteractiveBrowserCredential = (tenantId, clientId,  _) => { actBrowserTenantId = tenantId; actClientId_InteractiveBrowser = clientId; };
            credFactory.OnCreateVisualStudioCredential = (tenantId, visualstudioProcessTimeout, _) => { actVsTenantId = tenantId; actSubProcessTimeout = visualstudioProcessTimeout;  };
            credFactory.OnCreateVisualStudioCodeCredential = (tenantId, _) => { actCodeTenantId = tenantId; };
            credFactory.OnCreateAzurePowerShellCredential = (powershellProcessTimeoutMs, _) => { actSubProcessTimeout = powershellProcessTimeoutMs; };

            var options = new DefaultAzureCredentialOptions
            {
                InteractiveBrowserCredentialClientId = expClientId,
                SharedTokenCacheUsername = expUsername,
                ExcludeSharedTokenCacheCredential = false,
                SharedTokenCacheTenantId = expCacheTenantId,
                VisualStudioTenantId = expVsTenantId,
                VisualStudioCodeTenantId = expCodeTenantId,
                InteractiveBrowserTenantId = expBrowserTenantId,
                ExcludeInteractiveBrowserCredential = false,
                DeveloperCredentialTimeout = developerCredentialTimeout
            };

            switch (managedIdentityIdType)
            {
                case ManagedIdentityIdType.ClientId:
                    options.ManagedIdentityClientId = expClientId;
                    break;
                case ManagedIdentityIdType.ResourceId:
                    options.ManagedIdentityResourceId = new ResourceIdentifier(expResourceId);
                    break;
            }

            new DefaultAzureCredential(credFactory, options);

            Assert.AreEqual(expClientId, actClientId_InteractiveBrowser);
            Assert.AreEqual(expUsername, actUsername);
            Assert.AreEqual(expCacheTenantId, actCacheTenantId);
            Assert.AreEqual(expBrowserTenantId, actBrowserTenantId);
            Assert.AreEqual(expVsTenantId, actVsTenantId);
            Assert.AreEqual(expCodeTenantId, actCodeTenantId);
            Assert.AreEqual(developerCredentialTimeout, actSubProcessTimeout);
            switch (managedIdentityIdType)
            {
                case ManagedIdentityIdType.ClientId:
                    Assert.AreEqual(expClientId, actClientId_ManagedIdentity);
                    break;
                case ManagedIdentityIdType.ResourceId:
                    Assert.AreEqual(expResourceId, actResiurceId_ManagedIdentity);
                    break;
                case ManagedIdentityIdType.None:
                    Assert.IsNull(actClientId_ManagedIdentity);
                    Assert.IsNull(actResiurceId_ManagedIdentity);
                    break;
            }
        }

        [Test]
        [NonParallelizable]
        public void ValidateEnvironmentBasedOptionsPassedToCredentials([Values] bool clientIdSpecified, [Values] bool usernameSpecified, [Values] bool tenantIdSpecified)
        {
            var expClientId = clientIdSpecified ? Guid.NewGuid().ToString() : null;
            var expUsername = usernameSpecified ? Guid.NewGuid().ToString() : null;
            var expTenantId = tenantIdSpecified ? Guid.NewGuid().ToString() : null;
            bool onCreateSharedCalled = false;
            bool onCreatedManagedCalled = false;
            bool onCreateInteractiveCalled = false;
            bool onCreateVsCalled = false;
            bool onCreateVsCodeCalled = false;

            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_CLIENT_ID", expClientId },
                { "AZURE_USERNAME", expUsername },
                { "AZURE_TENANT_ID", expTenantId }
            }))
            {
                var credFactory = new MockDefaultAzureCredentialFactory(CredentialPipeline.GetInstance(null));

                credFactory.OnCreateManagedIdentityCredential = (options, _) =>
                {
                    onCreatedManagedCalled = true;
                    Assert.AreEqual(expClientId, options.ManagedIdentityClientId);
                };

                credFactory.OnCreateSharedTokenCacheCredential = (tenantId, username, _) =>
                {
                    onCreateSharedCalled = true;
                    Assert.AreEqual(expTenantId, tenantId);
                    Assert.AreEqual(expUsername, username);
                };

                credFactory.OnCreateInteractiveBrowserCredential = (tenantId, clientId, _) =>
                {
                    onCreateInteractiveCalled = true;
                    Assert.AreEqual(expTenantId, tenantId);
                };

                credFactory.OnCreateVisualStudioCredential = (tenantId, visualStudioTimeout, _) =>
                {
                    onCreateVsCalled = true;
                    Assert.AreEqual(expTenantId, tenantId);
                };

                credFactory.OnCreateVisualStudioCodeCredential = (tenantId, _) =>
                {
                    onCreateVsCodeCalled = true;
                    Assert.AreEqual(expTenantId, tenantId);
                };
                var options = new DefaultAzureCredentialOptions
                {
                    ExcludeEnvironmentCredential = true,
                    ExcludeManagedIdentityCredential = false,
                    ExcludeSharedTokenCacheCredential = false,
                    ExcludeVisualStudioCredential = false,
                    ExcludeVisualStudioCodeCredential = false,
                    ExcludeAzureCliCredential = true,
                    ExcludeInteractiveBrowserCredential = false
                };

                new DefaultAzureCredential(credFactory, options);

                Assert.IsTrue(onCreateSharedCalled);
                Assert.IsTrue(onCreatedManagedCalled);
                Assert.IsTrue(onCreateInteractiveCalled);
                Assert.IsTrue(onCreateVsCalled);
                Assert.IsTrue(onCreateVsCodeCalled);
            }
        }

        [Test]
        [NonParallelizable]
        public void ValidateEmptyEnvironmentBasedOptionsNotPassedToCredentials([Values] bool clientIdSpecified, [Values] bool usernameSpecified, [Values] bool tenantIdSpecified)
        {
            var expClientId = clientIdSpecified ? string.Empty : null;
            var expUsername = usernameSpecified ? string.Empty : null;
            var expTenantId = tenantIdSpecified ? string.Empty : null;
            bool onCreateSharedCalled = false;
            bool onCreatedManagedCalled = false;
            bool onCreateInteractiveCalled = false;
            bool onCreateVsCalled = false;
            bool onCreateVsCodeCalled = false;

            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_CLIENT_ID", expClientId },
                { "AZURE_USERNAME", expUsername },
                { "AZURE_TENANT_ID", expTenantId }
            }))
            {
                var credFactory = new MockDefaultAzureCredentialFactory(CredentialPipeline.GetInstance(null));

                credFactory.OnCreateManagedIdentityCredential = (options, _) =>
                {
                    onCreatedManagedCalled = true;
                    Assert.IsNull(options.ManagedIdentityClientId);
                };

                credFactory.OnCreateSharedTokenCacheCredential = (tenantId, username, _) =>
                {
                    onCreateSharedCalled = true;
                    Assert.IsNull(tenantId);
                    Assert.IsNull(username);
                };

                credFactory.OnCreateInteractiveBrowserCredential = (tenantId, _, _) =>
                {
                    onCreateInteractiveCalled = true;
                    Assert.IsNull(tenantId);
                };

                credFactory.OnCreateVisualStudioCredential = (tenantId, visualStudioProcessTimeout, _) =>
                {
                    onCreateVsCalled = true;
                    Assert.IsNull(tenantId);
                };

                credFactory.OnCreateVisualStudioCodeCredential = (tenantId, _) =>
                {
                    onCreateVsCodeCalled = true;
                    Assert.IsNull(tenantId);
                };
                var options = new DefaultAzureCredentialOptions
                {
                    ExcludeEnvironmentCredential = true,
                    ExcludeManagedIdentityCredential = false,
                    ExcludeSharedTokenCacheCredential = false,
                    ExcludeVisualStudioCredential = false,
                    ExcludeVisualStudioCodeCredential = false,
                    ExcludeAzureCliCredential = true,
                    ExcludeInteractiveBrowserCredential = false
                };

                new DefaultAzureCredential(credFactory, options);

                Assert.IsTrue(onCreateSharedCalled);
                Assert.IsTrue(onCreatedManagedCalled);
                Assert.IsTrue(onCreateInteractiveCalled);
                Assert.IsTrue(onCreateVsCalled);
                Assert.IsTrue(onCreateVsCodeCalled);
            }
        }

        [Test]
        public void ValidateCtorWithExcludeOptions([Values(true, false)]bool excludeEnvironmentCredential,
                                                   [Values(true, false)]bool excludeManagedIdentityCredential,
                                                   [Values(true, false)]bool excludeSharedTokenCacheCredential,
                                                   [Values(true, false)]bool excludeVisualStudioCredential,
                                                   [Values(true, false)]bool excludeVisualStudioCodeCredential,
                                                   [Values(true, false)]bool excludeCliCredential,
                                                   [Values(true, false)]bool excludeAzurePowerShellCredential,
                                                   [Values(true, false)]bool excludeInteractiveBrowserCredential)
        {
            var credFactory = new MockDefaultAzureCredentialFactory(CredentialPipeline.GetInstance(null));

            bool environmentCredentialIncluded = false;
            bool managedIdentityCredentialIncluded = false;
            bool sharedTokenCacheCredentialIncluded = false;
            bool cliCredentialIncluded = false;
            bool interactiveBrowserCredentialIncluded = false;
            bool visualStudioCredentialIncluded = false;
            bool visualStudioCodeCredentialIncluded = false;
            bool powerShellCredentialsIncluded = false;

            credFactory.OnCreateEnvironmentCredential = _ => environmentCredentialIncluded = true;
            credFactory.OnCreateAzureCliCredential = (_, _) => cliCredentialIncluded = true;
            credFactory.OnCreateInteractiveBrowserCredential = (tenantId, _, _) => interactiveBrowserCredentialIncluded = true;
            credFactory.OnCreateVisualStudioCredential = (tenantId, visualStudioProcessTimeout, _) => visualStudioCredentialIncluded = true;
            credFactory.OnCreateVisualStudioCodeCredential = (tenantId, _) => visualStudioCodeCredentialIncluded = true;
            credFactory.OnCreateAzurePowerShellCredential = (_, _) => powerShellCredentialsIncluded = true;
            credFactory.OnCreateManagedIdentityCredential = (clientId, _) =>
            {
                managedIdentityCredentialIncluded = true;
            };
            credFactory.OnCreateSharedTokenCacheCredential = (tenantId, username, _) =>
            {
                sharedTokenCacheCredentialIncluded = true;
            };

            var options = new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = excludeEnvironmentCredential,
                ExcludeManagedIdentityCredential = excludeManagedIdentityCredential,
                ExcludeSharedTokenCacheCredential = excludeSharedTokenCacheCredential,
                ExcludeAzureCliCredential = excludeCliCredential,
                ExcludeInteractiveBrowserCredential = excludeInteractiveBrowserCredential,
                ExcludeVisualStudioCredential = excludeVisualStudioCredential,
                ExcludeVisualStudioCodeCredential = excludeVisualStudioCodeCredential,
                ExcludeAzurePowerShellCredential = excludeAzurePowerShellCredential
            };

            if (excludeEnvironmentCredential && excludeManagedIdentityCredential && excludeSharedTokenCacheCredential && excludeVisualStudioCredential && excludeVisualStudioCodeCredential && excludeCliCredential && excludeAzurePowerShellCredential && excludeInteractiveBrowserCredential)
            {
                Assert.Throws<ArgumentException>(() => new DefaultAzureCredential(options));
            }
            else
            {
                new DefaultAzureCredential(credFactory, options);

                Assert.AreEqual(!excludeEnvironmentCredential, environmentCredentialIncluded);
                Assert.AreEqual(!excludeManagedIdentityCredential, managedIdentityCredentialIncluded);
                Assert.AreEqual(!excludeSharedTokenCacheCredential, sharedTokenCacheCredentialIncluded);
                Assert.AreEqual(!excludeCliCredential, cliCredentialIncluded);
                Assert.AreEqual(!excludeAzurePowerShellCredential, powerShellCredentialsIncluded);
                Assert.AreEqual(!excludeInteractiveBrowserCredential, interactiveBrowserCredentialIncluded);
                Assert.AreEqual(!excludeVisualStudioCredential, visualStudioCredentialIncluded);
                Assert.AreEqual(!excludeVisualStudioCodeCredential, visualStudioCodeCredentialIncluded);
            }
        }

        [Test]
        public void ValidateAllUnavailable([Values(true, false)]bool excludeEnvironmentCredential,
                                           [Values(true, false)]bool excludeManagedIdentityCredential,
                                           [Values(true, false)]bool excludeSharedTokenCacheCredential,
                                           [Values(true, false)]bool excludeVisualStudioCredential,
                                           [Values(true, false)]bool excludeVisualStudioCodeCredential,
                                           [Values(true, false)]bool excludeCliCredential,
                                           [Values(true, false)]bool excludePowerShellCredential,
                                           [Values(true, false)]bool excludeInteractiveBrowserCredential)
        {
            if (excludeEnvironmentCredential && excludeManagedIdentityCredential && excludeSharedTokenCacheCredential && excludeVisualStudioCredential && excludeVisualStudioCodeCredential && excludeCliCredential && excludeInteractiveBrowserCredential)
            {
                Assert.Pass();
            }

            var credFactory = new MockDefaultAzureCredentialFactory(CredentialPipeline.GetInstance(null));

            void SetupMockForException<T>(Mock<T> mock) where T : TokenCredential =>
                mock.Setup(m => m.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                    .Throws(new CredentialUnavailableException($"{typeof(T).Name} Unavailable"));

            credFactory.OnCreateEnvironmentCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateInteractiveBrowserCredential = (_, _, c) =>
                SetupMockForException(c);
            credFactory.OnCreateManagedIdentityCredential = (_, c) =>
                SetupMockForException(c);
            credFactory.OnCreateSharedTokenCacheCredential = (_, _, c) =>
                SetupMockForException(c);
            credFactory.OnCreateAzureCliCredential = (_, c) =>
                SetupMockForException(c);
            credFactory.OnCreateAzurePowerShellCredential = (_, c) =>
                SetupMockForException(c);
            credFactory.OnCreateVisualStudioCredential = (_, visualStudioProcessTimeout, c) =>
                SetupMockForException(c);
            credFactory.OnCreateVisualStudioCodeCredential = (_, c) =>
                SetupMockForException(c);

            var options = new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = excludeEnvironmentCredential,
                ExcludeManagedIdentityCredential = excludeManagedIdentityCredential,
                ExcludeSharedTokenCacheCredential = excludeSharedTokenCacheCredential,
                ExcludeVisualStudioCredential = excludeVisualStudioCredential,
                ExcludeVisualStudioCodeCredential = excludeVisualStudioCodeCredential,
                ExcludeAzureCliCredential = excludeCliCredential,
                ExcludeAzurePowerShellCredential = excludePowerShellCredential,
                ExcludeInteractiveBrowserCredential = excludeInteractiveBrowserCredential
            };

            var cred = new DefaultAzureCredential(credFactory, options);

            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await cred.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            if (!excludeEnvironmentCredential)
            {
                Assert.True(ex.Message.Contains("EnvironmentCredential Unavailable"));
            }
            if (!excludeManagedIdentityCredential)
            {
                Assert.True(ex.Message.Contains("ManagedIdentityCredential Unavailable"));
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
            var credFactory = new MockDefaultAzureCredentialFactory(CredentialPipeline.GetInstance(null));

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
            credFactory.OnCreateManagedIdentityCredential = (_, c) =>
                SetupMockForException(c);
            credFactory.OnCreateSharedTokenCacheCredential = (_, _, c) =>
                SetupMockForException(c);
            credFactory.OnCreateVisualStudioCredential = (_, visualStudioProcessTimeout, c) =>
                SetupMockForException(c);
            credFactory.OnCreateVisualStudioCodeCredential = (_, c) =>
                SetupMockForException(c);
            credFactory.OnCreateAzureCliCredential = (_, c) =>
                SetupMockForException(c);
            credFactory.OnCreateAzurePowerShellCredential = (_, c) =>
                SetupMockForException(c);

            credFactory.OnCreateInteractiveBrowserCredential = (_, _, c) =>
            {
                c.Setup(m => m.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                    .Throws(new MockClientException("InteractiveBrowserCredential unhandled exception"));
            };

            var options = new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = false,
                ExcludeManagedIdentityCredential = false,
                ExcludeSharedTokenCacheCredential = false,
                ExcludeAzureCliCredential = false,
                ExcludeAzurePowerShellCredential = false,
                ExcludeInteractiveBrowserCredential = false
            };

            var cred = new DefaultAzureCredential(credFactory, options);

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
        }

        [Test]
        [TestCaseSource(nameof(AllCredentialTypes))]
        public async Task ValidateSelectedCredentialCaching(Type availableCredential)
        {
            var expToken = new AccessToken(Guid.NewGuid().ToString(), DateTimeOffset.MaxValue);
            List<Type> calledCredentials = new();
            var credFactory = GetMockDefaultAzureCredentialFactory(availableCredential, expToken, calledCredentials);

            var options = new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = false,
                ExcludeManagedIdentityCredential = false,
                ExcludeSharedTokenCacheCredential = false,
                ExcludeAzureCliCredential = false,
                ExcludeAzurePowerShellCredential = false,
                ExcludeInteractiveBrowserCredential = false
            };

            var cred = new DefaultAzureCredential(credFactory, options);

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
            var credFactory = GetMockDefaultAzureCredentialFactory(availableCredential, expToken, calledCredentials);

            var options = new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = false,
                ExcludeManagedIdentityCredential = false,
                ExcludeSharedTokenCacheCredential = false,
                ExcludeAzureCliCredential = false,
                ExcludeInteractiveBrowserCredential = false,
            };

            var cred = new DefaultAzureCredential(credFactory, options);

            await cred.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.That(messages, Has.Some.Match(availableCredential.Name).And.Some.Match("DefaultAzureCredential credential selected"));
        }

        internal MockDefaultAzureCredentialFactory GetMockDefaultAzureCredentialFactory(Type availableCredential, AccessToken expToken, List<Type> calledCredentials)
        {
            var credFactory = new MockDefaultAzureCredentialFactory(CredentialPipeline.GetInstance(null));

            void SetupMockForException<T>(Mock<T> mock) where T : TokenCredential =>
                mock.Setup(m => m.GetTokenAsync(It.IsAny<TokenRequestContext>(), It.IsAny<CancellationToken>()))
                    .Callback(() => calledCredentials.Add(typeof(T)))
                    .ReturnsAsync(() =>
                    {
                        return availableCredential == typeof(T) ? expToken : throw new CredentialUnavailableException("Unavailable");
                    });

            credFactory.OnCreateEnvironmentCredential = c =>
                SetupMockForException(c);
            credFactory.OnCreateManagedIdentityCredential = (clientId, c) =>
                SetupMockForException(c);
            credFactory.OnCreateSharedTokenCacheCredential = (tenantId, username, c) =>
                SetupMockForException(c);
            credFactory.OnCreateAzureCliCredential = (_, c) =>
                SetupMockForException(c);
            credFactory.OnCreateInteractiveBrowserCredential = (_, _, c) =>
                SetupMockForException(c);
            credFactory.OnCreateVisualStudioCredential = (_, visualStudioProcessTimeout, c) =>
                SetupMockForException(c);
            credFactory.OnCreateVisualStudioCodeCredential = (_, c) =>
                SetupMockForException(c);
            credFactory.OnCreateAzurePowerShellCredential = (_, c) =>
                SetupMockForException(c);

            return credFactory;
        }
    }
}
