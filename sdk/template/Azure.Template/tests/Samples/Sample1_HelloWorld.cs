// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
#region Snippet:Azure_Template
using Azure.Template.Models;
#endregion
using NUnit.Framework;

namespace Azure.Template.Tests.Samples
{
    public partial class TemplateSamples: SamplesBase<TemplateClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void GettingASecret()
        {
            #region Snippet:Azure_Template_GetSecret
            string endpoint = "https://myvault.vault.azure.net";
#if !SNIPPET
            endpoint = TestEnvironment.KeyVaultUri;
#endif
            var client = new TemplateClient(endpoint, new DefaultAzureCredential());

            SecretBundle secret = client.GetSecretValue("TestSecret");

            Console.WriteLine(secret.Value);
            #endregion

            Assert.NotNull(secret.Value);
        }
    }
}
