// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Identity.Broker.Tests
{
    public class DefaultAzureCredentialFactoryTests
    {
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
            yield return new object[] { Constants.BrokerCredential, typeof(InteractiveBrowserCredential) };
        }

        [Test]
        [TestCaseSource(nameof(CredSelection))]
        public void ValidateDefaultAzureCredentialAZURE_TOKEN_CREDENTIALS_Honored_WithBroker(string credSelection, Type expectedType)
        {
            // var initFactory = new DefaultAzureCredentialFactory(new());
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

                //check the factory created the correct credentials
                if (credSelection == Constants.DevCredentials)
                {
                    Assert.IsFalse(chain.Any(cred => cred is EnvironmentCredential));
                    Assert.IsFalse(chain.Any(cred => cred is WorkloadIdentityCredential));
                    Assert.IsFalse(chain.Any(cred => cred is ManagedIdentityCredential));
#pragma warning disable CS0618 // Type or member is obsolete
                    Assert.IsFalse(chain.Any(cred => cred is SharedTokenCacheCredential));
#pragma warning restore CS0618 // Type or member is obsolete
                    Assert.IsTrue(chain.Any(cred => cred is AzureCliCredential));
                    Assert.IsTrue(chain.Any(cred => cred is AzurePowerShellCredential));
                    Assert.IsTrue(chain.Any(cred => cred is VisualStudioCredential));
                    Assert.IsTrue(chain.Any(cred => cred is AzureDeveloperCliCredential));
                    Assert.IsTrue(chain.Any(cred => cred.GetType() == typeof(VisualStudioCodeCredential)));
                    Assert.IsTrue(chain.Any(cred => cred.GetType() == typeof(InteractiveBrowserCredential)));
                }
                else if (credSelection == Constants.ProdCredentials)
                {
                    //check the factory created the credentials
                    Assert.IsTrue(chain.Any(cred => cred is EnvironmentCredential));
                    Assert.IsTrue(chain.Any(cred => cred is WorkloadIdentityCredential));
                    Assert.IsTrue(chain.Any(cred => cred is ManagedIdentityCredential));
#pragma warning disable CS0618 // Type or member is obsolete
                    Assert.IsFalse(chain.Any(cred => cred is SharedTokenCacheCredential));
#pragma warning restore CS0618 // Type or member is obsolete
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
                    Assert.Multiple(() =>
                    {
                        Assert.IsTrue(chain.Any(cred => cred is EnvironmentCredential), "EnvironmentCredential should be in the chain");
                        Assert.IsTrue(chain.Any(cred => cred is WorkloadIdentityCredential), "WorkloadIdentityCredential should be in the chain");
                        Assert.IsTrue(chain.Any(cred => cred is ManagedIdentityCredential), "ManagedIdentityCredential should be in the chain");
#pragma warning disable CS0618 // Type or member is obsolete
                        Assert.IsFalse(chain.Any(cred => cred is SharedTokenCacheCredential), "SharedTokenCacheCredential should not be in the chain");
#pragma warning restore CS0618 // Type or member is obsolete
                        Assert.IsTrue(chain.Any(cred => cred is AzureCliCredential), "AzureCliCredential should be in the chain");
                        Assert.IsTrue(chain.Any(cred => cred is AzurePowerShellCredential), "AzurePowerShellCredential should be in the chain");
                        Assert.IsTrue(chain.Any(cred => cred is VisualStudioCredential), "VisualStudioCredential should be in the chain");
                        Assert.IsTrue(chain.Any(cred => cred is AzureDeveloperCliCredential), "AzureDeveloperCliCredential should be in the chain");
                        Assert.IsTrue(chain.Any(cred => cred is VisualStudioCodeCredential), "VisualStudioCodeCredential should be in the chain");
                    });
                }
                else
                {
                    ValidateSingleCredSelection(expectedType, chain);
                }
            }
        }

        [Test]
        [TestCaseSource(nameof(CredSelection))]
        public void ValidateDefaultAzureCredentialAZURE_TOKEN_CREDENTIALS_Honored_WithBroker_WithDacOptions(string credSelection, Type expectedType)
        {
            // var initFactory = new DefaultAzureCredentialFactory(new());
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

                //check the factory created the correct credentials
                if (credSelection == Constants.DevCredentials)
                {
                    Assert.IsFalse(chain.Any(cred => cred is EnvironmentCredential));
                    Assert.IsFalse(chain.Any(cred => cred is WorkloadIdentityCredential));
                    Assert.IsFalse(chain.Any(cred => cred is ManagedIdentityCredential));
#pragma warning disable CS0618 // Type or member is obsolete
                    Assert.IsFalse(chain.Any(cred => cred is SharedTokenCacheCredential));
#pragma warning restore CS0618 // Type or member is obsolete
                    Assert.IsTrue(chain.Any(cred => cred is AzureCliCredential));
                    Assert.IsTrue(chain.Any(cred => cred is AzurePowerShellCredential));
                    Assert.IsTrue(chain.Any(cred => cred is VisualStudioCredential));
                    Assert.IsTrue(chain.Any(cred => cred is AzureDeveloperCliCredential));
                    Assert.IsTrue(chain.Any(cred => cred.GetType() == typeof(VisualStudioCodeCredential)));
                    Assert.IsTrue(chain.Any(cred => cred.GetType() == typeof(InteractiveBrowserCredential)));
                }
                else if (credSelection == Constants.ProdCredentials)
                {
                    //check the factory created the credentials
                    Assert.IsTrue(chain.Any(cred => cred is EnvironmentCredential));
                    Assert.IsTrue(chain.Any(cred => cred is WorkloadIdentityCredential));
                    Assert.IsTrue(chain.Any(cred => cred is ManagedIdentityCredential));
#pragma warning disable CS0618 // Type or member is obsolete
                    Assert.IsFalse(chain.Any(cred => cred is SharedTokenCacheCredential));
#pragma warning restore CS0618 // Type or member is obsolete
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
                    Assert.Multiple(() =>
                    {
                        Assert.IsTrue(chain.Any(cred => cred is EnvironmentCredential), "EnvironmentCredential should be in the chain");
                        Assert.IsTrue(chain.Any(cred => cred is WorkloadIdentityCredential), "WorkloadIdentityCredential should be in the chain");
                        Assert.IsTrue(chain.Any(cred => cred is ManagedIdentityCredential), "ManagedIdentityCredential should be in the chain");
#pragma warning disable CS0618 // Type or member is obsolete
                        Assert.IsFalse(chain.Any(cred => cred is SharedTokenCacheCredential), "SharedTokenCacheCredential should not be in the chain");
#pragma warning restore CS0618 // Type or member is obsolete
                        Assert.IsTrue(chain.Any(cred => cred is AzureCliCredential), "AzureCliCredential should be in the chain");
                        Assert.IsTrue(chain.Any(cred => cred is AzurePowerShellCredential), "AzurePowerShellCredential should be in the chain");
                        Assert.IsTrue(chain.Any(cred => cred is VisualStudioCredential), "VisualStudioCredential should be in the chain");
                        Assert.IsTrue(chain.Any(cred => cred is AzureDeveloperCliCredential), "AzureDeveloperCliCredential should be in the chain");
                        Assert.IsTrue(chain.Any(cred => cred is VisualStudioCodeCredential), "VisualStudioCodeCredential should be in the chain");
                    });
                }
                else
                {
                    ValidateSingleCredSelection(expectedType, chain);
                }
            }
        }

        private void ValidateSingleCredSelection(Type expectedType, IReadOnlyList<TokenCredential> chain)
        {
            Assert.IsNotNull(chain);
            Assert.IsTrue(chain.Single(cred => cred.GetType() == expectedType).GetType() == expectedType, $"Chain does not contain expected credential type: {expectedType}");
            Assert.IsTrue(chain.Count == 1, $"Chain contains unexpected number of credentials: {chain.Count}");
        }
    }
}
