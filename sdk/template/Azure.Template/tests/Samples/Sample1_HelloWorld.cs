// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;
#region Snippet:Azure_Template
using Azure.Identity;
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
#if SNIPPET
            string endpoint = "https://myvault.vault.azure.net";
            var credential = new DefaultAzureCredential();
#else
            string endpoint = TestEnvironment.KeyVaultUri;
            var credential = TestEnvironment.Credential;
#endif
            var client = new TemplateClient(endpoint, credential);

            SecretBundle secret = client.GetSecretValue("TestSecret");

            Console.WriteLine(secret.Value);
            #endregion

            Assert.NotNull(secret.Value);
        }
    }
}
