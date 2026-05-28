// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Template.Models;
using NUnit.Framework;

namespace Azure.Template.Tests.Samples
{
    public partial class TemplateSamples: SamplesBase<TemplateClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task GettingASecretAsync()
        {
            #region Snippet:Azure_Template_GetSecretAsync
#if SNIPPET
            string endpoint = "https://myvault.vault.azure.net";
            var credential = new DefaultAzureCredential();
#else
            string endpoint = TestEnvironment.KeyVaultUri;
            var credential = TestEnvironment.Credential;
#endif
            var client = new TemplateClient(endpoint, credential);

            SecretBundle secret = await client.GetSecretValueAsync("TestSecret");

            Console.WriteLine(secret.Value);
            #endregion

            Assert.NotNull(secret.Value);
        }
    }
}
