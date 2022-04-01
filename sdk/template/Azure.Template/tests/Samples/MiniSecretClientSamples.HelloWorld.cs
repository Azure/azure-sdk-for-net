// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
#region Snippet:Azure_Template_Namespaces
using Azure.Template.Models;
#endregion
using NUnit.Framework;

namespace Azure.Template.Tests.Samples
{
    public class MiniSecretClientSamples: SamplesBase<MiniSecretClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void GettingASecret()
        {
            var endpoint = TestEnvironment.KeyVaultUri;

            #region Snippet:Azure_Template_GetSecret
#if SNIPPET
            string endpoint = "https://myvault.vault.azure.net";
#endif
            var client = new MiniSecretClient(new Uri(endpoint), new DefaultAzureCredential());

            SecretBundle secret = client.GetSecret("TestSecret");

            Console.WriteLine(secret.Value);
            #endregion

            Assert.NotNull(secret.Value);
        }

        [Test]
        [AsyncOnly]
        public async Task GettingASecretAsync()
        {
            var endpoint = TestEnvironment.KeyVaultUri;

            #region Snippet:Azure_Template_GetSecretAsync
#if SNIPPET
            string endpoint = "https://myvault.vault.azure.net";
#endif
            var client = new MiniSecretClient(new Uri(endpoint), new DefaultAzureCredential());

            SecretBundle secret = await client.GetSecretAsync("TestSecret");

            Console.WriteLine(secret.Value);
            #endregion

            Assert.NotNull(secret.Value);
        }
    }
}
