// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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

            IExtendedTokenCredential[] sources = cred._sources();

            Assert.NotNull(sources);
            Assert.AreEqual(sources.Length, 4);
            Assert.IsInstanceOf(typeof(EnvironmentCredential), sources[0]);
            Assert.IsInstanceOf(typeof(ManagedIdentityCredential), sources[1]);
            Assert.IsInstanceOf(typeof(SharedTokenCacheCredential), sources[2]);
            Assert.IsNull(sources[3]);
        }

        [Test]
        public void ValidateCtorIncludedInteractiveParam([Values(true, false)]bool includeInteractive)
        {
            var cred = new DefaultAzureCredential(includeInteractive);

            IExtendedTokenCredential[] sources = cred._sources();

            Assert.NotNull(sources);
            Assert.AreEqual(sources.Length, 4);
            Assert.IsInstanceOf(typeof(EnvironmentCredential), sources[0]);
            Assert.IsInstanceOf(typeof(ManagedIdentityCredential), sources[1]);
            Assert.IsInstanceOf(typeof(SharedTokenCacheCredential), sources[2]);

            if (includeInteractive)
            {
                Assert.IsInstanceOf(typeof(InteractiveBrowserCredential), sources[3]);
            }
            else
            {
                Assert.IsNull(sources[3]);
            }
        }

        [Test]
        public void ValidateCtorOptionsPassedToCredentials()
        {
            string expClientId = Guid.NewGuid().ToString();
            string expUsername = Guid.NewGuid().ToString();
            string actClientId = null;
            string actUsername = null;

            var credFactory = new MockDefaultAzureCredentialFactory(CredentialPipeline.GetInstance(null));

            credFactory.OnCreateManagedIdentityCredential = (clientId, _) => actClientId = clientId;
            credFactory.OnCreateSharedTokenCacheCredential = (username, _) => actUsername = username;

            var options = new DefaultAzureCredentialOptions
            {
                ManagedIdentityClientId = expClientId,
                SharedTokenCacheUsername = expUsername
            };

            var cred = new DefaultAzureCredential(credFactory, options);

            Assert.AreEqual(expClientId, actClientId);
            Assert.AreEqual(expUsername, actUsername);
        }


        [Test]
        public void ValidateCtorWithExcludeOptions([Values(true, false)]bool excludeEnvironmentCredential, [Values(true, false)]bool excludeManagedIdentityCredential, [Values(true, false)]bool excludeSharedTokenCacheCredential, [Values(true, false)]bool excludeInteractiveBrowserCredential)
        {
            var credFactory = new MockDefaultAzureCredentialFactory(CredentialPipeline.GetInstance(null));

            bool environmentCredentialIncluded = false;
            bool managedIdentityCredentialIncluded = false;
            bool sharedTokenCacheCredentialIncluded = false;
            bool interactiveBrowserCredentialIncluded = false;

            credFactory.OnCreateEnvironmentCredential = (_) => environmentCredentialIncluded = true;
            credFactory.OnCreateInteractiveBrowserCredential = (_) => interactiveBrowserCredentialIncluded = true;
            credFactory.OnCreateManagedIdentityCredential = (clientId, _) =>
            {
                Assert.IsNull(clientId);
                managedIdentityCredentialIncluded = true;
            };
            credFactory.OnCreateSharedTokenCacheCredential = (username, _) =>
            {
                Assert.IsNull(username);
                sharedTokenCacheCredentialIncluded = true;
            };

            var options = new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = excludeEnvironmentCredential,
                ExcludeManagedIdentityCredential = excludeManagedIdentityCredential,
                ExcludeSharedTokenCacheCredential = excludeSharedTokenCacheCredential,
                ExcludeInteractiveBrowserCredential = excludeInteractiveBrowserCredential
            };

            if (excludeEnvironmentCredential && excludeManagedIdentityCredential && excludeSharedTokenCacheCredential && excludeInteractiveBrowserCredential)
            {
                Assert.Throws<ArgumentException>(() => new DefaultAzureCredential(options));
            }
            else
            {
                var cred = new DefaultAzureCredential(credFactory, options);

                Assert.AreEqual(!excludeEnvironmentCredential, environmentCredentialIncluded);
                Assert.AreEqual(!excludeManagedIdentityCredential, managedIdentityCredentialIncluded);
                Assert.AreEqual(!excludeSharedTokenCacheCredential, sharedTokenCacheCredentialIncluded);
                Assert.AreEqual(!excludeInteractiveBrowserCredential, interactiveBrowserCredentialIncluded);
            }
        }

        [Test]
        public void ValidateAllUnavailable([Values(true, false)]bool excludeEnvironmentCredential, [Values(true, false)]bool excludeManagedIdentityCredential, [Values(true, false)]bool excludeSharedTokenCacheCredential, [Values(true, false)]bool excludeInteractiveBrowserCredential)
        {
            if (excludeEnvironmentCredential && excludeManagedIdentityCredential && excludeSharedTokenCacheCredential && excludeInteractiveBrowserCredential)
            {
                Assert.Pass();
            }

            var credFactory = new MockDefaultAzureCredentialFactory(CredentialPipeline.GetInstance(null));

            credFactory.OnCreateEnvironmentCredential = (c) =>
            {
                ((MockExtendedTokenCredential)c).TokenFactory = (context, cancel) => { return new ExtendedAccessToken(new CredentialUnavailableException("EnvironmentCredential Unavailable")); };
            };
            credFactory.OnCreateInteractiveBrowserCredential = (c) =>
            {
                ((MockExtendedTokenCredential)c).TokenFactory = (context, cancel) => { return new ExtendedAccessToken(new CredentialUnavailableException("InteractiveBrowserCredential Unavailable")); };
            };
            credFactory.OnCreateManagedIdentityCredential = (clientId, c) =>
            {
                ((MockExtendedTokenCredential)c).TokenFactory = (context, cancel) => { return new ExtendedAccessToken(new CredentialUnavailableException("ManagedIdentityCredential Unavailable")); };
            };
            credFactory.OnCreateSharedTokenCacheCredential = (username, c) =>
            {
                ((MockExtendedTokenCredential)c).TokenFactory = (context, cancel) => { return new ExtendedAccessToken(new CredentialUnavailableException("SharedTokenCacheCredential Unavailable")); };
            };

            var options = new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = excludeEnvironmentCredential,
                ExcludeManagedIdentityCredential = excludeManagedIdentityCredential,
                ExcludeSharedTokenCacheCredential = excludeSharedTokenCacheCredential,
                ExcludeInteractiveBrowserCredential = excludeInteractiveBrowserCredential
            };

            var cred = new DefaultAzureCredential(credFactory, options);

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await cred.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

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
            if (!excludeInteractiveBrowserCredential)
            {
                Assert.True(ex.Message.Contains("InteractiveBrowserCredential Unavailable"));
            }
        }

        [Test]
        public void ValidateUnhandledException([Values(0, 1, 2, 3)]int exPossition)
        {
            var credFactory = new MockDefaultAzureCredentialFactory(CredentialPipeline.GetInstance(null));

            credFactory.OnCreateEnvironmentCredential = (c) =>
            {
                ((MockExtendedTokenCredential)c).TokenFactory = (context, cancel) =>
                {
                    if (exPossition > 0)
                    {
                        return new ExtendedAccessToken(new CredentialUnavailableException("EnvironmentCredential Unavailable"));
                    }
                    else
                    {
                        return new ExtendedAccessToken(new MockClientException("EnvironmentCredential unhandled exception"));
                    }
                };
            };
            credFactory.OnCreateManagedIdentityCredential = (clientId, c) =>
            {
                ((MockExtendedTokenCredential)c).TokenFactory = (context, cancel) =>
                {
                    if (exPossition > 1)
                    {
                        return new ExtendedAccessToken(new CredentialUnavailableException("ManagedIdentityCredential Unavailable"));
                    }
                    else
                    {
                        return new ExtendedAccessToken(new MockClientException("ManagedIdentityCredential unhandled exception"));
                    }
                };
            };
            credFactory.OnCreateSharedTokenCacheCredential = (username, c) =>
            {
                ((MockExtendedTokenCredential)c).TokenFactory = (context, cancel) =>
                {
                    if (exPossition > 2)
                    {
                        return new ExtendedAccessToken(new CredentialUnavailableException("SharedTokenCacheCredential Unavailable"));
                    }
                    else
                    {
                        return new ExtendedAccessToken(new MockClientException("SharedTokenCacheCredential unhandled exception"));
                    }
                };
            };
            credFactory.OnCreateInteractiveBrowserCredential = (c) =>
            {
                ((MockExtendedTokenCredential)c).TokenFactory = (context, cancel) =>
                {
                    return new ExtendedAccessToken(new MockClientException("InteractiveBrowserCredential unhandled exception"));
                };
            };

            var options = new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = false,
                ExcludeManagedIdentityCredential = false,
                ExcludeSharedTokenCacheCredential = false,
                ExcludeInteractiveBrowserCredential = false
            };

            var cred = new DefaultAzureCredential(credFactory, options);

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await cred.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));

            if (exPossition > 0)
            {
                Assert.True(ex.Message.Contains("EnvironmentCredential Unavailable"));
            }

            if (exPossition > 1)
            {
                Assert.True(ex.Message.Contains("ManagedIdentityCredential Unavailable"));
            }

            if (exPossition > 2)
            {
                Assert.True(ex.Message.Contains("SharedTokenCacheCredential Unavailable"));
            }

            switch (exPossition)
            {
                case 0:
                    Assert.True(ex.Message.Contains("EnvironmentCredential unhandled exception"));
                    break;
                case 1:
                    Assert.True(ex.Message.Contains("ManagedIdentityCredential unhandled exception"));
                    break;
                case 2:
                    Assert.True(ex.Message.Contains("SharedTokenCacheCredential unhandled exception"));
                    break;
                case 3:
                    Assert.True(ex.Message.Contains("InteractiveBrowserCredential unhandled exception"));
                    break;
                default:
                    Assert.Fail();
                    break;
            }
        }
    }
}
