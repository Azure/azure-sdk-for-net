// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Identity.Broker.Tests
{
    public class DefaultAzureCredentialFactoryTests
    {
        public static IEnumerable<object[]> CredSelection()
        {
            yield return new object[] { null };
            yield return new object[] { Constants.DevCredentials };
            yield return new object[] { Constants.ProdCredentials };
            yield return new object[] { Constants.VisualStudioCredential };
            yield return new object[] { Constants.VisualStudioCodeCredential };
            yield return new object[] { Constants.AzureCliCredential };
            yield return new object[] { Constants.AzurePowerShellCredential };
            yield return new object[] { Constants.AzureDeveloperCliCredential };
            yield return new object[] { Constants.EnvironmentCredential };
            yield return new object[] { Constants.WorkloadIdentityCredential };
            yield return new object[] { Constants.ManagedIdentityCredential };
            yield return new object[] { Constants.InteractiveBrowserCredential };
            yield return new object[] { Constants.BrokerAuthenticationCredential };
        }

#pragma warning disable CS0618 // Type or member is obsolete
        [Test]
        [TestCaseSource(nameof(CredSelection))]
        public void ValidateDefaultAzureCredentialAZURE_TOKEN_CREDENTIALS_Honored_WithBroker(string credSelection)
        {
            var initFactory = new DefaultAzureCredentialFactory(new());
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
                    Assert.IsFalse(chain.Any(cred => cred is SharedTokenCacheCredential));
                    Assert.IsTrue(chain.Any(cred => cred is AzureCliCredential));
                    Assert.IsTrue(chain.Any(cred => cred is AzurePowerShellCredential));
                    Assert.IsTrue(chain.Any(cred => cred is VisualStudioCredential));
                    Assert.IsTrue(chain.Any(cred => cred is AzureDeveloperCliCredential));
                    // VS Code and InteractiveBrowser are always excluded by default.
                    Assert.IsFalse(chain.Any(cred => cred is VisualStudioCodeCredential));
                    Assert.IsFalse(chain.Any(cred => cred is InteractiveBrowserCredential));
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
                else if (credSelection == Constants.VisualStudioCredential)
                {
                    Assert.IsTrue(chain.Single(cred => cred is VisualStudioCredential) is VisualStudioCredential);
                }
                else if (credSelection == Constants.VisualStudioCodeCredential)
                {
                    Assert.IsTrue(chain.Single(cred => cred is VisualStudioCodeCredential) is VisualStudioCodeCredential);
                }
                else if (credSelection == Constants.AzureCliCredential)
                {
                    Assert.IsTrue(chain.Single(cred => cred is AzureCliCredential) is AzureCliCredential);
                }
                else if (credSelection == Constants.AzurePowerShellCredential)
                {
                    Assert.IsTrue(chain.Single(cred => cred is AzurePowerShellCredential) is AzurePowerShellCredential);
                }
                else if (credSelection == Constants.AzureDeveloperCliCredential)
                {
                    Assert.IsTrue(chain.Single(cred => cred is AzureDeveloperCliCredential) is AzureDeveloperCliCredential);
                }
                else if (credSelection == Constants.InteractiveBrowserCredential)
                {
                    Assert.IsTrue(chain.Single(cred => cred is InteractiveBrowserCredential) is InteractiveBrowserCredential);
                }
                else if (credSelection == Constants.BrokerAuthenticationCredential)
                {
                    Assert.IsTrue(chain.Single(cred => cred is InteractiveBrowserCredential) is InteractiveBrowserCredential);
                }

                else if (credSelection == null)
                {
                    //check the factory created the credentials
                    Assert.Multiple(() =>
                    {
                        Assert.IsTrue(chain.Any(cred => cred is EnvironmentCredential), "EnvironmentCredential should be in the chain");
                        Assert.IsTrue(chain.Any(cred => cred is WorkloadIdentityCredential), "WorkloadIdentityCredential should be in the chain");
                        Assert.IsTrue(chain.Any(cred => cred is ManagedIdentityCredential), "ManagedIdentityCredential should be in the chain");
                        Assert.IsFalse(chain.Any(cred => cred is SharedTokenCacheCredential), "SharedTokenCacheCredential should not be in the chain");
                        Assert.IsTrue(chain.Any(cred => cred is AzureCliCredential), "AzureCliCredential should be in the chain");
                        Assert.IsTrue(chain.Any(cred => cred is AzurePowerShellCredential), "AzurePowerShellCredential should be in the chain");
                        Assert.IsTrue(chain.Any(cred => cred is VisualStudioCredential), "VisualStudioCredential should be in the chain");
                        Assert.IsTrue(chain.Any(cred => cred is AzureDeveloperCliCredential), "AzureDeveloperCliCredential should be in the chain");
                        // VS Code is always excluded.
                        Assert.IsFalse(chain.Any(cred => cred is VisualStudioCodeCredential), "VisualStudioCodeCredential should not be in the chain");
                    });
                }
            }
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}
