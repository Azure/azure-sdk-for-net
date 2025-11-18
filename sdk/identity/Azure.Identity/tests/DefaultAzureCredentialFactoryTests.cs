// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.Core.TestFramework;
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
                    if (setResourceId)
                    {
                        Assert.AreEqual(expResourceId.ToString(), cred.Client.ManagedIdentityId._userAssignedId);
                    }
                    if (setClientId)
                    {
                        Assert.AreEqual(expClientId, cred.Client.ManagedIdentityId._userAssignedId);
                    }
                }
            }
        }

        [Test]
        public void ValidateSharedTokenCacheOptionsHonored([Values] bool setTenantId, [Values] bool setSharedTokenCacheTenantId, [Values] bool setSharedTokenCacheUsername)
        {
            // ignore when both setTenantId and setSharedTokenCacheTenantId are true since we cannot set both
            if (setTenantId && setSharedTokenCacheTenantId)
            {
                Assert.Ignore("Test variation ignored since TenantId and SharedTokenCacheTenantId cannot both be set");
            }

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
        public void ValidateVisualStudioOptionsHonored([Values] bool setTenantId, [Values] bool setVisualStudioTenantId, [Values] bool setAdditionallyAllowedTenants, [Values] bool setCredentialProcessTimeout)
        {
            // ignore when both setTenantId and setVisualStudioTenantId are true since we cannot set both
            if (setTenantId && setVisualStudioTenantId)
            {
                Assert.Ignore("Test variation ignored since TenantId and VisualStudioTenantId cannot both be set");
            }

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
                TimeSpan? expTimeout = setCredentialProcessTimeout ? TimeSpan.FromMinutes(777) : null;
                DefaultAzureCredentialOptions options = new DefaultAzureCredentialOptions
                {
                    CredentialProcessTimeout = expTimeout
                };

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

                Assert.AreEqual(expTimeout ?? TimeSpan.FromSeconds(30), cred.ProcessTimeout);
                Assert.AreEqual(expVisualStudioTenantId ?? expTenantId, cred.TenantId);
                CollectionAssert.AreEquivalent(expAdditionallyAllowedTenants, cred.AdditionallyAllowedTenantIds);
                Assert.True(cred._isChainedCredential);
            }
        }

        [Test]
        public void ValidateVisualStudioCodeOptionsHonored([Values] bool setTenantId, [Values] bool setVisualStudioCodeTenantId, [Values] bool setAdditionallyAllowedTenants)
        {
            // ignore when both setTenantId and setVisualStudioCodeTenantId are true since we cannot set both
            if (setTenantId && setVisualStudioCodeTenantId)
            {
                Assert.Ignore("Test variation ignored since TenantId and VisualStudioCodeTenantId cannot both be set");
            }

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
                CollectionAssert.AreEquivalent(expAdditionallyAllowedTenants, cred.AdditionallyAllowedTenantIds);
            }
        }

        [Test]
        public void ValidateCliOptionsHonored([Values] bool setTenantId, [Values] bool setAdditionallyAllowedTenants, [Values] bool setCredentialProcessTimeout)
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
                TimeSpan? expTimeout = setCredentialProcessTimeout ? TimeSpan.FromMinutes(777) : null;

                DefaultAzureCredentialOptions options = new DefaultAzureCredentialOptions()
                {
                    TenantId = expTenantId,
                    CredentialProcessTimeout = expTimeout
                };

                foreach (var tenantId in expAdditionallyAllowedTenants)
                {
                    options.AdditionallyAllowedTenants.Add(tenantId);
                }

                var factory = new DefaultAzureCredentialFactory(options);

                AzureCliCredential cred = (AzureCliCredential)factory.CreateAzureCliCredential();

                Assert.AreEqual(expTimeout ?? TimeSpan.FromSeconds(13), cred.ProcessTimeout);
                Assert.AreEqual(expTenantId, cred.TenantId);
                CollectionAssert.AreEquivalent(expAdditionallyAllowedTenants, cred.AdditionallyAllowedTenantIds);
                Assert.True(cred._isChainedCredential);

                AzureDeveloperCliCredential credAzd = (AzureDeveloperCliCredential)factory.CreateAzureDeveloperCliCredential();

                Assert.AreEqual(expTimeout ?? TimeSpan.FromSeconds(13), credAzd.ProcessTimeout);
                Assert.AreEqual(expTenantId, credAzd.TenantId);
                CollectionAssert.AreEquivalent(expAdditionallyAllowedTenants, credAzd.AdditionallyAllowedTenantIds);
                Assert.True(credAzd._isChainedCredential);
            }
        }

        [Test]
        public void ValidatePowerShellOptionsHonored([Values] bool setTenantId, [Values] bool setAdditionallyAllowedTenants, [Values] bool setCredentialProcessTimeout)
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
                TimeSpan? expTimeout = setCredentialProcessTimeout ? TimeSpan.FromMinutes(777) : null;

                DefaultAzureCredentialOptions options = new DefaultAzureCredentialOptions()
                {
                    TenantId = expTenantId,
                    CredentialProcessTimeout = expTimeout
                };

                foreach (var tenantId in expAdditionallyAllowedTenants)
                {
                    options.AdditionallyAllowedTenants.Add(tenantId);
                }

                var factory = new DefaultAzureCredentialFactory(options);

                AzurePowerShellCredential cred = (AzurePowerShellCredential)factory.CreateAzurePowerShellCredential();

                Assert.AreEqual(expTimeout ?? TimeSpan.FromSeconds(10), cred.ProcessTimeout);
                Assert.AreEqual(expTenantId, cred.TenantId);
                CollectionAssert.AreEquivalent(expAdditionallyAllowedTenants, cred.AdditionallyAllowedTenantIds);
                Assert.True(cred._isChainedCredential);
            }
        }

        [Test]
        public void ValidateInteractiveBrowserOptionsHonored([Values] bool setTenantId, [Values] bool setClientId, [Values] bool setInteractiveBrowserTenantId, [Values] bool setAdditionallyAllowedTenants)
        {
            // ignore when both setTenantId and setInteractiveBrowserTenantId are true since we cannot set both
            if (setTenantId && setInteractiveBrowserTenantId)
            {
                Assert.Ignore("Test variation ignored since TenantId and InteractiveBrowserTenantId cannot both be set");
            }

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
                CollectionAssert.AreEquivalent(expAdditionallyAllowedTenants, cred.AdditionallyAllowedTenantIds);
            }
        }

        public static IEnumerable<object[]> ExcludeCredOptions()
        {
            yield return new object[] { true, false, false, false, false, false, false, false, false, false, false };
            yield return new object[] { false, true, false, false, false, false, false, false, false, false, false };
            yield return new object[] { false, false, true, false, false, false, false, false, false, false, false };
            yield return new object[] { false, false, false, true, false, false, false, false, false, false, false };
            yield return new object[] { false, false, false, false, true, false, false, false, false, false, false };
            yield return new object[] { false, false, false, false, false, true, false, false, false, false, false };
            yield return new object[] { false, false, false, false, false, false, true, false, false, false, false };
            yield return new object[] { false, false, false, false, false, false, false, true, false, false, false };
            yield return new object[] { false, false, false, false, false, false, false, false, true, false, false };
            yield return new object[] { false, false, false, false, false, false, false, false, false, true, false };
            yield return new object[] { false, false, false, false, false, false, false, false, false, false, true };
        }

        [Test]
        [TestCaseSource(nameof(ExcludeCredOptions))]
        public void ValidateExcludeOptionsHonored(bool excludeEnvironmentCredential,
                                                  bool excludeWorkloadIdentityCredential,
                                                  bool excludeManagedIdentityCredential,
                                                  bool excludeDeveloperCliCredential,
                                                  bool excludeSharedTokenCacheCredential,
                                                  bool excludeVisualStudioCredential,
                                                  bool excludeVisualStudioCodeCredential,
                                                  bool excludeCliCredential,
                                                  bool excludeAzurePowerShellCredential,
                                                  bool excludeInteractiveBrowserCredential,
                                                  bool excludeBrokerCredential)
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
                expCredentialTypes.ConditionalAdd(!excludeWorkloadIdentityCredential, typeof(WorkloadIdentityCredential));
                expCredentialTypes.ConditionalAdd(!excludeManagedIdentityCredential, typeof(ManagedIdentityCredential));
                expCredentialTypes.ConditionalAdd(!excludeSharedTokenCacheCredential, typeof(SharedTokenCacheCredential));
                expCredentialTypes.ConditionalAdd(!excludeVisualStudioCredential, typeof(VisualStudioCredential));
                expCredentialTypes.ConditionalAdd(!excludeVisualStudioCodeCredential, typeof(VisualStudioCodeCredential));
                expCredentialTypes.ConditionalAdd(!excludeCliCredential, typeof(AzureCliCredential));
                expCredentialTypes.ConditionalAdd(!excludeAzurePowerShellCredential, typeof(AzurePowerShellCredential));
                expCredentialTypes.ConditionalAdd(!excludeDeveloperCliCredential, typeof(AzureDeveloperCliCredential));
                expCredentialTypes.ConditionalAdd(!excludeInteractiveBrowserCredential, typeof(InteractiveBrowserCredential));
                expCredentialTypes.ConditionalAdd(!excludeBrokerCredential, typeof(BrokerCredential));

                var options = new DefaultAzureCredentialOptions
                {
                    ExcludeEnvironmentCredential = excludeEnvironmentCredential,
                    ExcludeWorkloadIdentityCredential = excludeWorkloadIdentityCredential,
                    ExcludeManagedIdentityCredential = excludeManagedIdentityCredential,
                    ExcludeAzureDeveloperCliCredential = excludeDeveloperCliCredential,
                    ExcludeSharedTokenCacheCredential = excludeSharedTokenCacheCredential,
                    ExcludeAzureCliCredential = excludeCliCredential,
                    ExcludeInteractiveBrowserCredential = excludeInteractiveBrowserCredential,
                    ExcludeVisualStudioCredential = excludeVisualStudioCredential,
                    ExcludeVisualStudioCodeCredential = excludeVisualStudioCodeCredential,
                    ExcludeAzurePowerShellCredential = excludeAzurePowerShellCredential,
                    ExcludeBrokerCredential = excludeBrokerCredential
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

        public static IEnumerable<object[]> CredSelection()
        {
            yield return new object[] { null, null };
            yield return new object[] { Constants.DevCredentials, null };
            yield return new object[] { Constants.ProdCredentials, null };
            yield return new object[] { Constants.VisualStudioCredential, typeof(VisualStudioCredential) };
            yield return new object[] { Constants.VisualStudioCodeCredential, typeof(VisualStudioCodeCredential) };
            yield return new object[] { Constants.AzureCliCredential, typeof(AzureCliCredential) };
            yield return new object[] { Constants.AzurePowerShellCredential, typeof(AzurePowerShellCredential) };
            yield return new object[] { Constants.AzureDeveloperCliCredential, typeof(AzureDeveloperCliCredential) };
            yield return new object[] { Constants.EnvironmentCredential, typeof(EnvironmentCredential) };
            yield return new object[] { Constants.WorkloadIdentityCredential, typeof(WorkloadIdentityCredential) };
            yield return new object[] { Constants.ManagedIdentityCredential, typeof(ManagedIdentityCredential) };
            yield return new object[] { Constants.InteractiveBrowserCredential, typeof(InteractiveBrowserCredential) };
            yield return new object[] { Constants.BrokerCredential, typeof(BrokerCredential) };
        }

        [Test]
        [TestCaseSource(nameof(CredSelection))]
        public void ValidateDefaultAzureCredentialAZURE_TOKEN_CREDENTIALS_Honored(string credSelection, Type expectedType)
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_CLIENT_ID", null },
                { "AZURE_USERNAME", null },
                { "AZURE_TENANT_ID", null },
                { "AZURE_TOKEN_CREDENTIALS", credSelection }
            }))
            {
                var factory = new DefaultAzureCredentialFactory(null);
                var chain = factory.CreateCredentialChain();

                // check the factory created the correct credentials
                if (credSelection == Constants.DevCredentials)
                {
                    Assert.IsFalse(chain.Any(cred => cred is EnvironmentCredential));
                    Assert.IsFalse(chain.Any(cred => cred is WorkloadIdentityCredential));
                    Assert.IsFalse(chain.Any(cred => cred is ManagedIdentityCredential));
                    Assert.IsFalse(chain.Any(cred => cred is SharedTokenCacheCredential));
                    Assert.IsTrue(chain.Any(cred => cred is AzureCliCredential));
                    Assert.IsTrue(chain.Any(cred => cred is AzurePowerShellCredential));
                    Assert.IsTrue(chain.Any(cred => cred is VisualStudioCredential));
                    Assert.IsTrue(chain.Any(cred => cred is AzureDeveloperCliCredential));
                    Assert.IsTrue(chain.Any(cred => cred is VisualStudioCodeCredential));
                    Assert.IsTrue(chain.Any(cred => cred is BrokerCredential));
                    // InteractiveBrowser is always excluded by default.
                    Assert.IsFalse(chain.Any(cred => cred.GetType() == typeof(InteractiveBrowserCredential)));
                }
                else if (credSelection == Constants.ProdCredentials)
                {
                    //check the factory created the credentials
                    Assert.IsTrue(chain.Any(cred => cred is EnvironmentCredential));
                    Assert.IsTrue(chain.Any(cred => cred is WorkloadIdentityCredential));
                    Assert.IsTrue(chain.Any(cred => cred is ManagedIdentityCredential));
                    Assert.IsFalse(chain.Any(cred => cred is SharedTokenCacheCredential));
                    Assert.IsFalse(chain.Any(cred => cred is AzureCliCredential));
                    Assert.IsFalse(chain.Any(cred => cred is AzurePowerShellCredential));
                    Assert.IsFalse(chain.Any(cred => cred is VisualStudioCredential));
                    Assert.IsFalse(chain.Any(cred => cred is AzureDeveloperCliCredential));
                    Assert.IsFalse(chain.Any(cred => cred is VisualStudioCodeCredential));
                    Assert.IsFalse(chain.Any(cred => cred is InteractiveBrowserCredential));
                }
                else if (credSelection == null)
                {
                    //check the factory created the credentials
                    Assert.IsTrue(chain.Any(cred => cred is EnvironmentCredential));
                    Assert.IsTrue(chain.Any(cred => cred is WorkloadIdentityCredential));
                    Assert.IsTrue(chain.Any(cred => cred is ManagedIdentityCredential));
                    Assert.IsFalse(chain.Any(cred => cred is SharedTokenCacheCredential));
                    Assert.IsTrue(chain.Any(cred => cred is AzureCliCredential));
                    Assert.IsTrue(chain.Any(cred => cred is AzurePowerShellCredential));
                    Assert.IsTrue(chain.Any(cred => cred is VisualStudioCredential));
                    Assert.IsTrue(chain.Any(cred => cred is AzureDeveloperCliCredential));
                    Assert.IsTrue(chain.Any(cred => cred is VisualStudioCodeCredential));
                }
                else
                {
                    ValidateSingleCredSelection(expectedType, chain);
                }
            }
        }

        [Test]
        [TestCaseSource(nameof(CredSelection))]
        public void ValidateDefaultAzureCredentialAZURE_TOKEN_CREDENTIALS_Honored_WithDacOptions(string credSelection, Type expectedType)
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_CLIENT_ID", null },
                { "AZURE_USERNAME", null },
                { "AZURE_TENANT_ID", null },
                { "AZURE_TOKEN_CREDENTIALS", credSelection }
            }))
            {
                var factory = new DefaultAzureCredentialFactory(new());
                var chain = factory.CreateCredentialChain();

                // check the factory created the correct credentials
                if (credSelection == Constants.DevCredentials)
                {
                    Assert.IsFalse(chain.Any(cred => cred is EnvironmentCredential));
                    Assert.IsFalse(chain.Any(cred => cred is WorkloadIdentityCredential));
                    Assert.IsFalse(chain.Any(cred => cred is ManagedIdentityCredential));
                    Assert.IsFalse(chain.Any(cred => cred is SharedTokenCacheCredential));
                    Assert.IsTrue(chain.Any(cred => cred is AzureCliCredential));
                    Assert.IsTrue(chain.Any(cred => cred is AzurePowerShellCredential));
                    Assert.IsTrue(chain.Any(cred => cred is VisualStudioCredential));
                    Assert.IsTrue(chain.Any(cred => cred is AzureDeveloperCliCredential));
                    Assert.IsTrue(chain.Any(cred => cred is VisualStudioCodeCredential));
                    Assert.IsTrue(chain.Any(cred => cred is BrokerCredential));
                    // InteractiveBrowser is always excluded by default.
                    Assert.IsFalse(chain.Any(cred => cred.GetType() == typeof(InteractiveBrowserCredential)));
                }
                else if (credSelection == Constants.ProdCredentials)
                {
                    //check the factory created the credentials
                    Assert.IsTrue(chain.Any(cred => cred is EnvironmentCredential));
                    Assert.IsTrue(chain.Any(cred => cred is WorkloadIdentityCredential));
                    Assert.IsTrue(chain.Any(cred => cred is ManagedIdentityCredential));
                    Assert.IsFalse(chain.Any(cred => cred is SharedTokenCacheCredential));
                    Assert.IsFalse(chain.Any(cred => cred is AzureCliCredential));
                    Assert.IsFalse(chain.Any(cred => cred is AzurePowerShellCredential));
                    Assert.IsFalse(chain.Any(cred => cred is VisualStudioCredential));
                    Assert.IsFalse(chain.Any(cred => cred is AzureDeveloperCliCredential));
                    Assert.IsFalse(chain.Any(cred => cred is VisualStudioCodeCredential));
                    Assert.IsFalse(chain.Any(cred => cred is InteractiveBrowserCredential));
                }
                else if (credSelection == null)
                {
                    //check the factory created the credentials
                    Assert.IsTrue(chain.Any(cred => cred is EnvironmentCredential));
                    Assert.IsTrue(chain.Any(cred => cred is WorkloadIdentityCredential));
                    Assert.IsTrue(chain.Any(cred => cred is ManagedIdentityCredential));
                    Assert.IsFalse(chain.Any(cred => cred is SharedTokenCacheCredential));
                    Assert.IsTrue(chain.Any(cred => cred is AzureCliCredential));
                    Assert.IsTrue(chain.Any(cred => cred is AzurePowerShellCredential));
                    Assert.IsTrue(chain.Any(cred => cred is VisualStudioCredential));
                    Assert.IsTrue(chain.Any(cred => cred is AzureDeveloperCliCredential));
                    Assert.IsTrue(chain.Any(cred => cred is VisualStudioCodeCredential));
                    Assert.IsTrue(chain.Any(cred => cred is BrokerCredential));
                }
                else
                {
                    ValidateSingleCredSelection(expectedType, chain);
                }
            }
        }

        [Test]
        public void InvalidAZURE_TOKEN_CREDENTIALS_Throws()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_CLIENT_ID", null },
                { "AZURE_USERNAME", null },
                { "AZURE_TENANT_ID", null },
                { "AZURE_TOKEN_CREDENTIALS", "bogus" }
            }))
            {
                var factory = new DefaultAzureCredentialFactory(null);
                Assert.Throws<InvalidOperationException>(() => factory.CreateCredentialChain());
            }
        }

        [Test]
        [TestCaseSource(nameof(ExcludeCredOptions))]
        public void ValidateExcludeOptionsHonoredWithAZURE_TOKEN_CREDENTIALS_DevMode(
            bool excludeEnvironmentCredential,
            bool excludeWorkloadIdentityCredential,
            bool excludeManagedIdentityCredential,
            bool excludeDeveloperCliCredential,
            bool excludeSharedTokenCacheCredential,
            bool excludeVisualStudioCredential,
            bool excludeVisualStudioCodeCredential,
            bool excludeCliCredential,
            bool excludeAzurePowerShellCredential,
            bool excludeInteractiveBrowserCredential,
            bool excludeBrokerCredential)
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_CLIENT_ID", null },
                { "AZURE_USERNAME", null },
                { "AZURE_TENANT_ID", null },
                { "AZURE_TOKEN_CREDENTIALS", "dev" }
            }))
            {
                var expCredentialTypes = new List<Type>();
                expCredentialTypes.ConditionalAdd(!excludeVisualStudioCredential, typeof(VisualStudioCredential));
                expCredentialTypes.ConditionalAdd(!excludeVisualStudioCodeCredential, typeof(VisualStudioCodeCredential));
                expCredentialTypes.ConditionalAdd(!excludeCliCredential, typeof(AzureCliCredential));
                expCredentialTypes.ConditionalAdd(!excludeAzurePowerShellCredential, typeof(AzurePowerShellCredential));
                expCredentialTypes.ConditionalAdd(!excludeDeveloperCliCredential, typeof(AzureDeveloperCliCredential));
                expCredentialTypes.ConditionalAdd(!excludeBrokerCredential, typeof(BrokerCredential));

                var options = new DefaultAzureCredentialOptions
                {
                    ExcludeEnvironmentCredential = excludeEnvironmentCredential,
                    ExcludeWorkloadIdentityCredential = excludeWorkloadIdentityCredential,
                    ExcludeManagedIdentityCredential = excludeManagedIdentityCredential,
                    ExcludeAzureDeveloperCliCredential = excludeDeveloperCliCredential,
                    ExcludeSharedTokenCacheCredential = excludeSharedTokenCacheCredential,
                    ExcludeAzureCliCredential = excludeCliCredential,
                    ExcludeInteractiveBrowserCredential = excludeInteractiveBrowserCredential,
                    ExcludeVisualStudioCredential = excludeVisualStudioCredential,
                    ExcludeVisualStudioCodeCredential = excludeVisualStudioCodeCredential,
                    ExcludeAzurePowerShellCredential = excludeAzurePowerShellCredential,
                    ExcludeBrokerCredential = excludeBrokerCredential
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

        [Test]
        [TestCaseSource(nameof(ExcludeCredOptions))]
        public void ValidateExcludeOptionsHonoredWithAZURE_TOKEN_CREDENTIALS_ProdMode(
            bool excludeEnvironmentCredential,
            bool excludeWorkloadIdentityCredential,
            bool excludeManagedIdentityCredential,
            bool excludeDeveloperCliCredential,
            bool excludeSharedTokenCacheCredential,
            bool excludeVisualStudioCredential,
            bool excludeVisualStudioCodeCredential,
            bool excludeCliCredential,
            bool excludeAzurePowerShellCredential,
            bool excludeInteractiveBrowserCredential,
            bool excludeBrokerCredential)
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_CLIENT_ID", null },
                { "AZURE_USERNAME", null },
                { "AZURE_TENANT_ID", null },
                { "AZURE_TOKEN_CREDENTIALS", "prod" }
            }))
            {
                var expCredentialTypes = new List<Type>();
                expCredentialTypes.ConditionalAdd(!excludeEnvironmentCredential, typeof(EnvironmentCredential));
                expCredentialTypes.ConditionalAdd(!excludeWorkloadIdentityCredential, typeof(WorkloadIdentityCredential));
                expCredentialTypes.ConditionalAdd(!excludeManagedIdentityCredential, typeof(ManagedIdentityCredential));

                var options = new DefaultAzureCredentialOptions
                {
                    ExcludeEnvironmentCredential = excludeEnvironmentCredential,
                    ExcludeWorkloadIdentityCredential = excludeWorkloadIdentityCredential,
                    ExcludeManagedIdentityCredential = excludeManagedIdentityCredential,
                    ExcludeAzureDeveloperCliCredential = excludeDeveloperCliCredential,
                    ExcludeSharedTokenCacheCredential = excludeSharedTokenCacheCredential,
                    ExcludeAzureCliCredential = excludeCliCredential,
                    ExcludeInteractiveBrowserCredential = excludeInteractiveBrowserCredential,
                    ExcludeVisualStudioCredential = excludeVisualStudioCredential,
                    ExcludeVisualStudioCodeCredential = excludeVisualStudioCodeCredential,
                    ExcludeAzurePowerShellCredential = excludeAzurePowerShellCredential,
                    ExcludeBrokerCredential = excludeBrokerCredential
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

        private void ValidateSingleCredSelection(Type expectedType, IReadOnlyList<TokenCredential> chain)
        {
            Assert.IsNotNull(chain);
            Assert.IsTrue(chain.Single(cred => cred.GetType() == expectedType).GetType() == expectedType, $"Chain does not contain expected credential type: {expectedType}");
            Assert.IsTrue(chain.Count == 1, $"Chain contains unexpected number of credentials: {chain.Count}");
        }

        [Test]
        public void BrokerCredentialThrowsWithoutBrokerPackage()
        {
            var options = new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = true,
                ExcludeWorkloadIdentityCredential = true,
                ExcludeManagedIdentityCredential = true,
                ExcludeSharedTokenCacheCredential = true,
                ExcludeVisualStudioCredential = true,
                ExcludeVisualStudioCodeCredential = true,
                ExcludeAzureCliCredential = true,
                ExcludeAzurePowerShellCredential = true,
                ExcludeAzureDeveloperCliCredential = true,
                ExcludeInteractiveBrowserCredential = true,
                ExcludeBrokerCredential = false
            };

            var credential = new DefaultAzureCredential(options);
            var exception = Assert.Throws<CredentialUnavailableException>(() => credential.GetToken(new TokenRequestContext(new[] { "scope" })));
            Assert.AreEqual($"The {nameof(BrokerCredential)} requires the Azure.Identity.Broker package to be referenced. See the troubleshooting guide for more information. https://aka.ms/azsdk/net/identity/brokercredential/troubleshoot", exception.Message);
        }
    }
}