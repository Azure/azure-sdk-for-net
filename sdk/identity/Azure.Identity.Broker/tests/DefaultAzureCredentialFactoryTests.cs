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
            yield return new object[] { Constants.BrokerCredential, typeof(BrokerCredential) };
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
                    Assert.That(chain.Any(cred => cred is EnvironmentCredential), Is.False);
                    Assert.That(chain.Any(cred => cred is WorkloadIdentityCredential), Is.False);
                    Assert.That(chain.Any(cred => cred is ManagedIdentityCredential), Is.False);
#pragma warning disable CS0618 // Type or member is obsolete
                    Assert.That(chain.Any(cred => cred is SharedTokenCacheCredential), Is.False);
#pragma warning restore CS0618 // Type or member is obsolete
                    Assert.That(chain.Any(cred => cred is AzureCliCredential), Is.True);
                    Assert.That(chain.Any(cred => cred is AzurePowerShellCredential), Is.True);
                    Assert.That(chain.Any(cred => cred is VisualStudioCredential), Is.True);
                    Assert.That(chain.Any(cred => cred is AzureDeveloperCliCredential), Is.True);
                    Assert.That(chain.Any(cred => cred is VisualStudioCodeCredential), Is.True);
                    Assert.That(chain.Any(cred => cred is BrokerCredential), Is.True);
                }
                else if (credSelection == Constants.ProdCredentials)
                {
                    //check the factory created the credentials
                    Assert.That(chain.Any(cred => cred is EnvironmentCredential), Is.True);
                    Assert.That(chain.Any(cred => cred is WorkloadIdentityCredential), Is.True);
                    Assert.That(chain.Any(cred => cred is ManagedIdentityCredential), Is.True);
#pragma warning disable CS0618 // Type or member is obsolete
                    Assert.That(chain.Any(cred => cred is SharedTokenCacheCredential), Is.False);
#pragma warning restore CS0618 // Type or member is obsolete
                    Assert.That(chain.Any(cred => cred is AzureCliCredential), Is.False);
                    Assert.That(chain.Any(cred => cred is AzurePowerShellCredential), Is.False);
                    Assert.That(chain.Any(cred => cred is VisualStudioCredential), Is.False);
                    Assert.That(chain.Any(cred => cred is AzureDeveloperCliCredential), Is.False);
                    Assert.That(chain.Any(cred => cred is VisualStudioCodeCredential), Is.False);
                    Assert.That(chain.Any(cred => cred is InteractiveBrowserCredential), Is.False);
                    Assert.That(chain.Any(cred => cred is BrokerCredential), Is.False);
                }
                else if (credSelection == null)
                {
                    //check the factory created the credentials
                    Assert.Multiple(() =>
                    {
                        Assert.That(chain.Any(cred => cred is EnvironmentCredential), Is.True, "EnvironmentCredential should be in the chain");
                        Assert.That(chain.Any(cred => cred is WorkloadIdentityCredential), Is.True, "WorkloadIdentityCredential should be in the chain");
                        Assert.That(chain.Any(cred => cred is ManagedIdentityCredential), Is.True, "ManagedIdentityCredential should be in the chain");
#pragma warning disable CS0618 // Type or member is obsolete
                        Assert.That(chain.Any(cred => cred is SharedTokenCacheCredential), Is.False, "SharedTokenCacheCredential should not be in the chain");
#pragma warning restore CS0618 // Type or member is obsolete
                        Assert.That(chain.Any(cred => cred is AzureCliCredential), Is.True, "AzureCliCredential should be in the chain");
                        Assert.That(chain.Any(cred => cred is AzurePowerShellCredential), Is.True, "AzurePowerShellCredential should be in the chain");
                        Assert.That(chain.Any(cred => cred is VisualStudioCredential), Is.True, "VisualStudioCredential should be in the chain");
                        Assert.That(chain.Any(cred => cred is AzureDeveloperCliCredential), Is.True, "AzureDeveloperCliCredential should be in the chain");
                        Assert.That(chain.Any(cred => cred is VisualStudioCodeCredential), Is.True, "VisualStudioCodeCredential should be in the chain");
                        Assert.That(chain.Any(cred => cred is BrokerCredential), Is.True, "BrokerCredential should be in the chain");
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
                    Assert.That(chain.Any(cred => cred is EnvironmentCredential), Is.False);
                    Assert.That(chain.Any(cred => cred is WorkloadIdentityCredential), Is.False);
                    Assert.That(chain.Any(cred => cred is ManagedIdentityCredential), Is.False);
#pragma warning disable CS0618 // Type or member is obsolete
                    Assert.That(chain.Any(cred => cred is SharedTokenCacheCredential), Is.False);
#pragma warning restore CS0618 // Type or member is obsolete
                    Assert.That(chain.Any(cred => cred is AzureCliCredential), Is.True);
                    Assert.That(chain.Any(cred => cred is AzurePowerShellCredential), Is.True);
                    Assert.That(chain.Any(cred => cred is VisualStudioCredential), Is.True);
                    Assert.That(chain.Any(cred => cred is AzureDeveloperCliCredential), Is.True);
                    Assert.That(chain.Any(cred => cred is VisualStudioCodeCredential), Is.True);
                    Assert.That(chain.Any(cred => cred is BrokerCredential), Is.True);
                }
                else if (credSelection == Constants.ProdCredentials)
                {
                    //check the factory created the credentials
                    Assert.That(chain.Any(cred => cred is EnvironmentCredential), Is.True);
                    Assert.That(chain.Any(cred => cred is WorkloadIdentityCredential), Is.True);
                    Assert.That(chain.Any(cred => cred is ManagedIdentityCredential), Is.True);
#pragma warning disable CS0618 // Type or member is obsolete
                    Assert.That(chain.Any(cred => cred is SharedTokenCacheCredential), Is.False);
#pragma warning restore CS0618 // Type or member is obsolete
                    Assert.That(chain.Any(cred => cred is AzureCliCredential), Is.False);
                    Assert.That(chain.Any(cred => cred is AzurePowerShellCredential), Is.False);
                    Assert.That(chain.Any(cred => cred is VisualStudioCredential), Is.False);
                    Assert.That(chain.Any(cred => cred is AzureDeveloperCliCredential), Is.False);
                    Assert.That(chain.Any(cred => cred is VisualStudioCodeCredential), Is.False);
                    Assert.That(chain.Any(cred => cred is InteractiveBrowserCredential), Is.False);
                    Assert.That(chain.Any(cred => cred is BrokerCredential), Is.False);
                }
                else if (credSelection == null)
                {
                    //check the factory created the credentials
                    Assert.Multiple(() =>
                    {
                        Assert.That(chain.Any(cred => cred is EnvironmentCredential), Is.True, "EnvironmentCredential should be in the chain");
                        Assert.That(chain.Any(cred => cred is WorkloadIdentityCredential), Is.True, "WorkloadIdentityCredential should be in the chain");
                        Assert.That(chain.Any(cred => cred is ManagedIdentityCredential), Is.True, "ManagedIdentityCredential should be in the chain");
#pragma warning disable CS0618 // Type or member is obsolete
                        Assert.That(chain.Any(cred => cred is SharedTokenCacheCredential), Is.False, "SharedTokenCacheCredential should not be in the chain");
#pragma warning restore CS0618 // Type or member is obsolete
                        Assert.That(chain.Any(cred => cred is AzureCliCredential), Is.True, "AzureCliCredential should be in the chain");
                        Assert.That(chain.Any(cred => cred is AzurePowerShellCredential), Is.True, "AzurePowerShellCredential should be in the chain");
                        Assert.That(chain.Any(cred => cred is VisualStudioCredential), Is.True, "VisualStudioCredential should be in the chain");
                        Assert.That(chain.Any(cred => cred is AzureDeveloperCliCredential), Is.True, "AzureDeveloperCliCredential should be in the chain");
                        Assert.That(chain.Any(cred => cred is VisualStudioCodeCredential), Is.True, "VisualStudioCodeCredential should be in the chain");
                        Assert.That(chain.Any(cred => cred is BrokerCredential), Is.True, "BrokerCredential should be in the chain");
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
            Assert.That(chain, Is.Not.Null);
            Assert.That(chain.Single(cred => cred.GetType() == expectedType).GetType(), Is.EqualTo(expectedType), $"Chain does not contain expected credential type: {expectedType}");
            Assert.That(chain.Count, Is.EqualTo(1), $"Chain contains unexpected number of credentials: {chain.Count}");
        }
    }
}
