// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Testing;
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
            Assert.AreEqual(sources.Length, 5);
            Assert.IsInstanceOf(typeof(EnvironmentCredential), sources[0]);
            Assert.IsInstanceOf(typeof(ManagedIdentityCredential), sources[1]);
            Assert.IsInstanceOf(typeof(SharedTokenCacheCredential), sources[2]);
            Assert.IsInstanceOf(typeof(AzureCliCredential), sources[3]);
            Assert.IsNull(sources[4]);
        }

        [Test]
        public void ValidateCtorIncludedInteractiveParam([Values(true, false)]bool includeInteractive)
        {
            var cred = new DefaultAzureCredential(includeInteractive);

            TokenCredential[] sources = cred._sources();

            Assert.NotNull(sources);
            Assert.AreEqual(sources.Length, 5);
            Assert.IsInstanceOf(typeof(EnvironmentCredential), sources[0]);
            Assert.IsInstanceOf(typeof(ManagedIdentityCredential), sources[1]);
            Assert.IsInstanceOf(typeof(SharedTokenCacheCredential), sources[2]);
            Assert.IsInstanceOf(typeof(AzureCliCredential), sources[3]);

            if (includeInteractive)
            {
                Assert.IsInstanceOf(typeof(InteractiveBrowserCredential), sources[4]);
            }
            else
            {
                Assert.IsNull(sources[4]);
            }
        }

        [Test]
        public void ValidateCtorOptionsPassedToCredentials()
        {
            string expClientId = Guid.NewGuid().ToString();
            string expUsername = Guid.NewGuid().ToString();
            string expTenantId = Guid.NewGuid().ToString();
            string actClientId = null;
            string actUsername = null;
            string actTenantId = null;

            var credFactory = new MockDefaultAzureCredentialFactory(CredentialPipeline.GetInstance(null));

            credFactory.OnCreateManagedIdentityCredential = (clientId, _) => actClientId = clientId;
            credFactory.OnCreateSharedTokenCacheCredential = (tenantId, username, _) => { actTenantId = tenantId; actUsername = username; };

            var options = new DefaultAzureCredentialOptions
            {
                ManagedIdentityClientId = expClientId,
                SharedTokenCacheUsername = expUsername,
                SharedTokenCacheTenantId = expTenantId
            };

            var cred = new DefaultAzureCredential(credFactory, options);

            Assert.AreEqual(expClientId, actClientId);
            Assert.AreEqual(expUsername, actUsername);
            Assert.AreEqual(expTenantId, actTenantId);
        }

        [Test]
        [NonParallelizable]
        public void ValidateEnvironmentBasedOptionsPassedToCredentials([Values]bool clientIdSpecified, [Values]bool usernameSpecified, [Values]bool tenantIdSpecified)
        {
            var expClientId = clientIdSpecified ? Guid.NewGuid().ToString() : null;
            var expUsername = usernameSpecified ? Guid.NewGuid().ToString() : null;
            var expTenantId = tenantIdSpecified ? Guid.NewGuid().ToString() : null;
            bool onCreateSharedCalled = false;
            bool onCreatedManagedCalled = false;
            bool onCreateInteractiveCalled = false;

            using (new TestEnvVar("AZURE_CLIENT_ID", expClientId))
            using (new TestEnvVar("AZURE_USERNAME", expUsername))
            using (new TestEnvVar("AZURE_TENANT_ID", expTenantId))
            {
                var credFactory = new MockDefaultAzureCredentialFactory(CredentialPipeline.GetInstance(null));

                credFactory.OnCreateManagedIdentityCredential = (clientId, _) =>
                {
                    onCreatedManagedCalled = true;
                    Assert.AreEqual(expClientId, clientId);
                };

                credFactory.OnCreateSharedTokenCacheCredential = (tenantId, username, _) =>
                {
                    onCreateSharedCalled = true;
                    Assert.AreEqual(expTenantId, tenantId);
                    Assert.AreEqual(expUsername, username);
                };

                credFactory.OnCreateInteractiveBrowserCredential = (tenantId, _) =>
                {
                    onCreateInteractiveCalled = true;
                    Assert.AreEqual(expTenantId, tenantId);
                };

                var options = new DefaultAzureCredentialOptions
                {
                    ExcludeEnvironmentCredential = true,
                    ExcludeManagedIdentityCredential = false,
                    ExcludeSharedTokenCacheCredential = false,
                    ExcludeAzureCliCredential = true,
                    ExcludeInteractiveBrowserCredential = false
                };

                var cred = new DefaultAzureCredential(credFactory, options);

                Assert.IsTrue(onCreateSharedCalled);
                Assert.IsTrue(onCreatedManagedCalled);
                Assert.IsTrue(onCreateInteractiveCalled);
            }
        }

        [Test]
        public void ValidateCtorWithExcludeOptions([Values(true, false)]bool excludeEnvironmentCredential, [Values(true, false)]bool excludeManagedIdentityCredential, [Values(true, false)]bool excludeSharedTokenCacheCredential, [Values(true, false)]bool excludeCliCredential, [Values(true, false)]bool excludeInteractiveBrowserCredential)
        {
            var credFactory = new MockDefaultAzureCredentialFactory(CredentialPipeline.GetInstance(null));

            bool environmentCredentialIncluded = false;
            bool managedIdentityCredentialIncluded = false;
            bool sharedTokenCacheCredentialIncluded = false;
            bool cliCredentialIncluded = false;
            bool interactiveBrowserCredentialIncluded = false;

            credFactory.OnCreateEnvironmentCredential = (_) => environmentCredentialIncluded = true;
            credFactory.OnCreateAzureCliCredential = (_) => cliCredentialIncluded = true;
            credFactory.OnCreateInteractiveBrowserCredential = (tenantId, _) => interactiveBrowserCredentialIncluded = true;
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
                ExcludeInteractiveBrowserCredential = excludeInteractiveBrowserCredential
            };

            if (excludeEnvironmentCredential && excludeManagedIdentityCredential && excludeSharedTokenCacheCredential && excludeCliCredential && excludeInteractiveBrowserCredential)
            {
                Assert.Throws<ArgumentException>(() => new DefaultAzureCredential(options));
            }
            else
            {
                var cred = new DefaultAzureCredential(credFactory, options);

                Assert.AreEqual(!excludeEnvironmentCredential, environmentCredentialIncluded);
                Assert.AreEqual(!excludeManagedIdentityCredential, managedIdentityCredentialIncluded);
                Assert.AreEqual(!excludeSharedTokenCacheCredential, sharedTokenCacheCredentialIncluded);
                Assert.AreEqual(!excludeCliCredential, cliCredentialIncluded);
                Assert.AreEqual(!excludeInteractiveBrowserCredential, interactiveBrowserCredentialIncluded);
            }
        }

        [Test]
        public void ValidateAllUnavailable([Values(true, false)]bool excludeEnvironmentCredential, [Values(true, false)]bool excludeManagedIdentityCredential, [Values(true, false)]bool excludeSharedTokenCacheCredential, [Values(true, false)]bool excludeCliCredential, [Values(true, false)]bool excludeInteractiveBrowserCredential)
        {
            if (excludeEnvironmentCredential && excludeManagedIdentityCredential && excludeSharedTokenCacheCredential && excludeCliCredential && excludeInteractiveBrowserCredential)
            {
                Assert.Pass();
            }

            var credFactory = new MockDefaultAzureCredentialFactory(CredentialPipeline.GetInstance(null));

            credFactory.OnCreateEnvironmentCredential = (c) =>
            {
                ((MockTokenCredential)c).TokenFactory = (context, cancel) => { throw new CredentialUnavailableException("EnvironmentCredential Unavailable"); };
            };
            credFactory.OnCreateInteractiveBrowserCredential = (_, c) =>
            {
                ((MockTokenCredential)c).TokenFactory = (context, cancel) => { throw new CredentialUnavailableException("InteractiveBrowserCredential Unavailable"); };
            };
            credFactory.OnCreateManagedIdentityCredential = (clientId, c) =>
            {
                ((MockTokenCredential)c).TokenFactory = (context, cancel) => { throw new CredentialUnavailableException("ManagedIdentityCredential Unavailable"); };
            };
            credFactory.OnCreateSharedTokenCacheCredential = (tenantId, username, c) =>
            {
                ((MockTokenCredential)c).TokenFactory = (context, cancel) => { throw new CredentialUnavailableException("SharedTokenCacheCredential Unavailable"); };
            };
            credFactory.OnCreateAzureCliCredential = (c) =>
            {
                ((MockTokenCredential)c).TokenFactory = (context, cancel) => { throw new CredentialUnavailableException("CliCredential Unavailable"); };
            };

            var options = new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = excludeEnvironmentCredential,
                ExcludeManagedIdentityCredential = excludeManagedIdentityCredential,
                ExcludeSharedTokenCacheCredential = excludeSharedTokenCacheCredential,
                ExcludeAzureCliCredential = excludeCliCredential,
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
            if (!excludeInteractiveBrowserCredential)
            {
                Assert.True(ex.Message.Contains("InteractiveBrowserCredential Unavailable"));
            }
        }

        [Test]
        public void ValidateUnhandledException([Values(0, 1, 2, 3, 4)]int exPossition)
        {
            var credFactory = new MockDefaultAzureCredentialFactory(CredentialPipeline.GetInstance(null));

            credFactory.OnCreateEnvironmentCredential = (c) =>
            {
                ((MockTokenCredential)c).TokenFactory = (context, cancel) =>
                {
                    if (exPossition > 0)
                    {
                        throw new CredentialUnavailableException("EnvironmentCredential Unavailable");
                    }
                    else
                    {
                        throw new MockClientException("EnvironmentCredential unhandled exception");
                    }
                };
            };
            credFactory.OnCreateManagedIdentityCredential = (clientId, c) =>
            {
                ((MockTokenCredential)c).TokenFactory = (context, cancel) =>
                {
                    if (exPossition > 1)
                    {
                        throw new CredentialUnavailableException("ManagedIdentityCredential Unavailable");
                    }
                    else
                    {
                        throw new MockClientException("ManagedIdentityCredential unhandled exception");
                    }
                };
            };
            credFactory.OnCreateSharedTokenCacheCredential = (tenantId, username, c) =>
            {
                ((MockTokenCredential)c).TokenFactory = (context, cancel) =>
                {
                    if (exPossition > 2)
                    {
                        throw new CredentialUnavailableException("SharedTokenCacheCredential Unavailable");
                    }
                    else
                    {
                        throw new MockClientException("SharedTokenCacheCredential unhandled exception");
                    }
                };
            };
            credFactory.OnCreateAzureCliCredential = (c) =>
            {
                ((MockTokenCredential)c).TokenFactory = (context, cancel) =>
                {
                    if (exPossition > 3)
                    {
                        throw new CredentialUnavailableException("CliCredential Unavailable");
                    }
                    else
                    {
                        throw new MockClientException("CliCredential unhandled exception");
                    }
                };
            };
            credFactory.OnCreateInteractiveBrowserCredential = (_, c) =>
            {
                ((MockTokenCredential)c).TokenFactory = (context, cancel) =>
                {
                    throw new MockClientException("InteractiveBrowserCredential unhandled exception");
                };
            };

            var options = new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = false,
                ExcludeManagedIdentityCredential = false,
                ExcludeSharedTokenCacheCredential = false,
                ExcludeAzureCliCredential = false,
                ExcludeInteractiveBrowserCredential = false
            };

            var cred = new DefaultAzureCredential(credFactory, options);

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await cred.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            switch (exPossition)
            {
                case 0:
                    Assert.AreEqual(ex.InnerException.Message, "EnvironmentCredential unhandled exception");
                    break;
                case 1:
                    Assert.AreEqual(ex.InnerException.Message, "ManagedIdentityCredential unhandled exception");
                    break;
                case 2:
                    Assert.AreEqual(ex.InnerException.Message, "SharedTokenCacheCredential unhandled exception");
                    break;
                case 3:
                    Assert.AreEqual(ex.InnerException.Message, "CliCredential unhandled exception");
                    break;
                case 4:
                    Assert.AreEqual(ex.InnerException.Message, "InteractiveBrowserCredential unhandled exception");
                    break;
                default:
                    Assert.Fail();
                    break;
            }
        }

        [Test]
        public async Task ValidateSelectedCredentialCaching([Values(typeof(EnvironmentCredential), typeof(ManagedIdentityCredential), typeof(SharedTokenCacheCredential), typeof(AzureCliCredential), typeof(InteractiveBrowserCredential))]Type availableCredential)
        {
            var expToken = new AccessToken(Guid.NewGuid().ToString(), DateTimeOffset.MaxValue);

            var credFactory = new MockDefaultAzureCredentialFactory(CredentialPipeline.GetInstance(null));

            List<Type> calledCredentials = new List<Type>();

            credFactory.OnCreateEnvironmentCredential = (c) =>
            {
                ((MockTokenCredential)c).TokenFactory = (context, cancel) =>
                {
                    calledCredentials.Add(typeof(EnvironmentCredential));

                    return (availableCredential == typeof(EnvironmentCredential)) ? expToken : throw new CredentialUnavailableException("Unavailable");
                };
            };
            credFactory.OnCreateManagedIdentityCredential = (clientId, c) =>
            {
                ((MockTokenCredential)c).TokenFactory = (context, cancel) =>
                {
                    calledCredentials.Add(typeof(ManagedIdentityCredential));

                    return (availableCredential == typeof(ManagedIdentityCredential)) ? expToken : throw new CredentialUnavailableException("Unavailable");
                };
            };
            credFactory.OnCreateSharedTokenCacheCredential = (tenantId, username, c) =>
            {
                ((MockTokenCredential)c).TokenFactory = (context, cancel) =>
                {
                    calledCredentials.Add(typeof(SharedTokenCacheCredential));

                    return (availableCredential == typeof(SharedTokenCacheCredential)) ? expToken : throw new CredentialUnavailableException("Unavailable");
                };
            };
            credFactory.OnCreateAzureCliCredential = (c) =>
            {
                ((MockTokenCredential)c).TokenFactory = (context, cancel) =>
                {
                    calledCredentials.Add(typeof(AzureCliCredential));

                    return (availableCredential == typeof(AzureCliCredential)) ? expToken : throw new CredentialUnavailableException("Unavailable");
                };
            };
            credFactory.OnCreateInteractiveBrowserCredential = (_, c) =>
            {
                ((MockTokenCredential)c).TokenFactory = (context, cancel) =>
                {
                    calledCredentials.Add(typeof(InteractiveBrowserCredential));

                    return (availableCredential == typeof(InteractiveBrowserCredential)) ? expToken : throw new CredentialUnavailableException("Unavailable");
                };
            };

            var options = new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = false,
                ExcludeManagedIdentityCredential = false,
                ExcludeSharedTokenCacheCredential = false,
                ExcludeAzureCliCredential = false,
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

        internal class PartialMockDefaultAzureCredentialFactory : DefaultAzureCredentialFactory
        {
            private EnvironmentCredential _environmentCredential;
            private ManagedIdentityCredential _managedIdentityCredential;

            public PartialMockDefaultAzureCredentialFactory(CredentialPipeline pipeline=null, EnvironmentCredential environmentCredential = null, ManagedIdentityCredential managedIdentityCredential = null) : base(pipeline ?? CredentialPipeline.GetInstance(null))
            {
                _environmentCredential = environmentCredential;
                _managedIdentityCredential = managedIdentityCredential;
            }

            public override TokenCredential CreateEnvironmentCredential()
            {
                return _environmentCredential ?? base.CreateEnvironmentCredential();
            }

            public override TokenCredential CreateManagedIdentityCredential(string clientId)
            {
                return _managedIdentityCredential ?? base.CreateManagedIdentityCredential(clientId);
            }
        }
    }
}
