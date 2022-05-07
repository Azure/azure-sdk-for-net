// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
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
            string endpoint = "https://myvault.vault.azure.net";
#if !SNIPPET
            endpoint = TestEnvironment.KeyVaultUri;
#endif
            var client = new TemplateClient(endpoint, new DefaultAzureCredential());

            SecretBundle secret = await client.GetSecretValueAsync("TestSecret");

            Console.WriteLine(secret.Value);
            #endregion

            Assert.NotNull(secret.Value);
        }
    }
}
