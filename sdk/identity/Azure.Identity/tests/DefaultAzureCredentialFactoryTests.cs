// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.TestFramework;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Options;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    internal class DefaultAzureCredentialFactoryTests
    {
        [Test]
        public void ValidateManagedIdentityCtorOptionsHonored([Values] bool setClientId, [Values] bool setResourceId)
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_CLIENT_ID", null },
                { "AZURE_USERNAME", null },
                { "AZURE_TENANT_ID", null }
            }))
            {
                ResourceIdentifier expResourceId = setResourceId ? new ResourceIdentifier($"/subscriptions/{Guid.NewGuid().ToString()}/locations/MyLocation") : null;
                string expClientId = setClientId ? Guid.NewGuid().ToString() : null;

                DefaultAzureCredentialOptions options = new DefaultAzureCredentialOptions()
                {
                    ManagedIdentityClientId = expClientId,
                    ManagedIdentityResourceId = expResourceId
                };

                var factory = new DefaultAzureCredentialFactory(options);

                if (setClientId && setResourceId)
                {
                    Assert.Throws<ArgumentException>(() => factory.CreateManagedIdentityCredential());
                }
                else
                {
                    ManagedIdentityCredential cred = (ManagedIdentityCredential)factory.CreateManagedIdentityCredential();

                    Assert.AreEqual(expResourceId?.ToString(), cred.Client.ResourceIdentifier?.ToString());
                    Assert.AreEqual(expClientId, cred.Client.ClientId);
                }
            }
        }

        [Test]
        public void ValidateSharedTokenCacheOptionsHonored([Values] bool setTenantId, [Values] bool setSharedTokenCacheTenantId, [Values] bool setSharedTokenCacheUsername)
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_CLIENT_ID", null },
                { "AZURE_USERNAME", null },
                { "AZURE_TENANT_ID", null }
            }))
            {
                string expTenantId = setTenantId ? Guid.NewGuid().ToString() : null;
                string expSharedTokenCacheTenantId = setSharedTokenCacheTenantId ? Guid.NewGuid().ToString() : null;
                string expSharedTokenCacheUsername = setSharedTokenCacheUsername ? Guid.NewGuid().ToString() : null;

                var options = new DefaultAzureCredentialOptions()
                {
                    SharedTokenCacheUsername = expSharedTokenCacheUsername
                };

                if (setTenantId)
                {
                    options.TenantId = expTenantId;
                }

                if (setSharedTokenCacheTenantId)
                {
                    options.SharedTokenCacheTenantId = expSharedTokenCacheTenantId;
                }

                var factory = new DefaultAzureCredentialFactory(options);

                SharedTokenCacheCredential cred = (SharedTokenCacheCredential)factory.CreateSharedTokenCacheCredential();

                Assert.AreEqual(expSharedTokenCacheTenantId ?? expTenantId, cred.TenantId);
                Assert.AreEqual(expSharedTokenCacheUsername, cred.Username);
            }
        }

        [Test]
        public void ValidateVisualStudioOptionsHonored([Values] bool setTenantId, [Values] bool setVisualStudioTenantId, [Values] bool setAdditionallyAllowedTenants)
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_CLIENT_ID", null },
                { "AZURE_USERNAME", null },
                { "AZURE_TENANT_ID", null },
                { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", null }
            }))
            {
                string expTenantId = setTenantId ? Guid.NewGuid().ToString() : null;
                string expVisualStudioTenantId = setVisualStudioTenantId ? Guid.NewGuid().ToString() : null;
                string[] expAdditionallyAllowedTenants = setAdditionallyAllowedTenants ? new string[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() } : Array.Empty<string>();

                DefaultAzureCredentialOptions options = new DefaultAzureCredentialOptions();

                if (setTenantId)
                {
                    options.TenantId = expTenantId;
                }

                if (setVisualStudioTenantId)
                {
                    options.VisualStudioTenantId = expVisualStudioTenantId;
                }

                foreach (var tenantId in expAdditionallyAllowedTenants)
                {
                    options.AdditionallyAllowedTenants.Add(tenantId);
                }

                var factory = new DefaultAzureCredentialFactory(options);

                VisualStudioCredential cred = (VisualStudioCredential)factory.CreateVisualStudioCredential();

                Assert.AreEqual(expVisualStudioTenantId ?? expTenantId, cred.TenantId);
                CollectionAssert.AreEqual(expAdditionallyAllowedTenants, cred.AdditionallyAllowedTenantIds);
            }
        }

        [Test]
        public void ValidateVisualStudioCodeOptionsHonored([Values] bool setTenantId, [Values] bool setVisualStudioCodeTenantId, [Values] bool setAdditionallyAllowedTenants)
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_CLIENT_ID", null },
                { "AZURE_USERNAME", null },
                { "AZURE_TENANT_ID", null },
                { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", null }
            }))
            {
                string expTenantId = setTenantId ? Guid.NewGuid().ToString() : null;
                string expVisualStudioCodeTenantId = setVisualStudioCodeTenantId ? Guid.NewGuid().ToString() : null;
                string[] expAdditionallyAllowedTenants = setAdditionallyAllowedTenants ? new string[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() } : Array.Empty<string>();

                DefaultAzureCredentialOptions options = new DefaultAzureCredentialOptions();

                if (setTenantId)
                {
                    options.TenantId = expTenantId;
                }

                if (setVisualStudioCodeTenantId)
                {
                    options.VisualStudioCodeTenantId = expVisualStudioCodeTenantId;
                }

                foreach (var tenantId in expAdditionallyAllowedTenants)
                {
                    options.AdditionallyAllowedTenants.Add(tenantId);
                }

                var factory = new DefaultAzureCredentialFactory(options);

                VisualStudioCodeCredential cred = (VisualStudioCodeCredential)factory.CreateVisualStudioCodeCredential();

                Assert.AreEqual(expVisualStudioCodeTenantId ?? expTenantId, cred.TenantId);
                CollectionAssert.AreEqual(expAdditionallyAllowedTenants, cred.AdditionallyAllowedTenantIds);
            }
        }

        [Test]
        public void ValidateCliOptionsHonored([Values] bool setTenantId, [Values] bool setAdditionallyAllowedTenants)
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_CLIENT_ID", null },
                { "AZURE_USERNAME", null },
                { "AZURE_TENANT_ID", null },
                { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", null }
            }))
            {
                string expTenantId = setTenantId ? Guid.NewGuid().ToString() : null;
                string[] expAdditionallyAllowedTenants = setAdditionallyAllowedTenants ? new string[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() } : Array.Empty<string>();

                DefaultAzureCredentialOptions options = new DefaultAzureCredentialOptions()
                {
                    TenantId = expTenantId,
                };

                foreach (var tenantId in expAdditionallyAllowedTenants)
                {
                    options.AdditionallyAllowedTenants.Add(tenantId);
                }

                var factory = new DefaultAzureCredentialFactory(options);

                AzureCliCredential cred = (AzureCliCredential)factory.CreateAzureCliCredential();

                Assert.AreEqual(expTenantId, cred.TenantId);
                CollectionAssert.AreEqual(expAdditionallyAllowedTenants, cred.AdditionallyAllowedTenantIds);
            }
        }

        [Test]
        public void ValidatePowerShellOptionsHonored([Values] bool setTenantId, [Values] bool setAdditionallyAllowedTenants)
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_CLIENT_ID", null },
                { "AZURE_USERNAME", null },
                { "AZURE_TENANT_ID", null },
                { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", null }
            }))
            {
                string expTenantId = setTenantId ? Guid.NewGuid().ToString() : null;
                string[] expAdditionallyAllowedTenants = setAdditionallyAllowedTenants ? new string[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() } : Array.Empty<string>();

                DefaultAzureCredentialOptions options = new DefaultAzureCredentialOptions()
                {
                    TenantId = expTenantId,
                };

                foreach (var tenantId in expAdditionallyAllowedTenants)
                {
                    options.AdditionallyAllowedTenants.Add(tenantId);
                }

                var factory = new DefaultAzureCredentialFactory(options);

                AzurePowerShellCredential cred = (AzurePowerShellCredential)factory.CreateAzurePowerShellCredential();

                Assert.AreEqual(expTenantId, cred.TenantId);
                CollectionAssert.AreEqual(expAdditionallyAllowedTenants, cred.AdditionallyAllowedTenantIds);
            }
        }

        [Test]
        public void ValidateInteractiveBrowserOptionsHonored([Values] bool setTenantId, [Values] bool setClientId, [Values] bool setInteractiveBrowserTenantId, [Values] bool setAdditionallyAllowedTenants)
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_CLIENT_ID", null },
                { "AZURE_USERNAME", null },
                { "AZURE_TENANT_ID", null },
                { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", null }
            }))
            {
                string expClientId = setClientId ? Guid.NewGuid().ToString() : Constants.DeveloperSignOnClientId;
                string expTenantId = setTenantId ? Guid.NewGuid().ToString() : null;
                string expInteractiveBrowserTenantId = setInteractiveBrowserTenantId ? Guid.NewGuid().ToString() : null;
                string[] expAdditionallyAllowedTenants = setAdditionallyAllowedTenants ? new string[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() } : Array.Empty<string>();

                DefaultAzureCredentialOptions options = new DefaultAzureCredentialOptions();

                if (setTenantId)
                {
                    options.TenantId = expTenantId;
                }

                if (setClientId)
                {
                    options.InteractiveBrowserCredentialClientId = expClientId;
                }

                if (setInteractiveBrowserTenantId)
                {
                    options.InteractiveBrowserTenantId = expInteractiveBrowserTenantId;
                }

                foreach (var tenantId in expAdditionallyAllowedTenants)
                {
                    options.AdditionallyAllowedTenants.Add(tenantId);
                }

                var factory = new DefaultAzureCredentialFactory(options);

                InteractiveBrowserCredential cred = (InteractiveBrowserCredential)factory.CreateInteractiveBrowserCredential();

                Assert.AreEqual(expInteractiveBrowserTenantId ?? expTenantId, cred.TenantId);
                Assert.AreEqual(expClientId, cred.ClientId);
                CollectionAssert.AreEqual(expAdditionallyAllowedTenants, cred.AdditionallyAllowedTenantIds);
            }
        }

        [Test]
        public void ValidateExcludeOptionsHonored([Values(true, false)] bool excludeEnvironmentCredential,
                                                   [Values(true, false)] bool excludeManagedIdentityCredential,
                                                   [Values(true, false)] bool excludeSharedTokenCacheCredential,
                                                   [Values(true, false)] bool excludeVisualStudioCredential,
                                                   [Values(true, false)] bool excludeVisualStudioCodeCredential,
                                                   [Values(true, false)] bool excludeCliCredential,
                                                   [Values(true, false)] bool excludeAzurePowerShellCredential,
                                                   [Values(true, false)] bool excludeInteractiveBrowserCredential)
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_CLIENT_ID", null },
                { "AZURE_USERNAME", null },
                { "AZURE_TENANT_ID", null },
                { "AZURE_ADDITIONALLY_ALLOWED_TENANTS", null }
            }))
            {
                var expCredentialTypes = new List<Type>();
                expCredentialTypes.ConditionalAdd(!excludeEnvironmentCredential, typeof(EnvironmentCredential));
                expCredentialTypes.ConditionalAdd(!excludeManagedIdentityCredential, typeof(ManagedIdentityCredential));
                expCredentialTypes.ConditionalAdd(!excludeSharedTokenCacheCredential, typeof(SharedTokenCacheCredential));
                expCredentialTypes.ConditionalAdd(!excludeVisualStudioCredential, typeof(VisualStudioCredential));
                expCredentialTypes.ConditionalAdd(!excludeVisualStudioCodeCredential, typeof(VisualStudioCodeCredential));
                expCredentialTypes.ConditionalAdd(!excludeCliCredential, typeof(AzureCliCredential));
                expCredentialTypes.ConditionalAdd(!excludeAzurePowerShellCredential, typeof(AzurePowerShellCredential));
                expCredentialTypes.ConditionalAdd(!excludeInteractiveBrowserCredential, typeof(InteractiveBrowserCredential));

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

                var factory = new DefaultAzureCredentialFactory(options);

                if (expCredentialTypes.Count == 0)
                {
                    Assert.Throws<ArgumentException>(() => factory.CreateCredentialChain());

                    Assert.Pass();
                }

                TokenCredential[] chain = factory.CreateCredentialChain();

                for (int i = 0; i < expCredentialTypes.Count; i++)
                {
                    Assert.IsInstanceOf(expCredentialTypes[i], chain[i]);
                }

                for (int i = expCredentialTypes.Count; i < chain.Length; i++)
                {
                    Assert.IsNull(chain[i]);
                }
            }
        }
    }
}
