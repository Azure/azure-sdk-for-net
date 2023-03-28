// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Secrets.Samples
{
    public partial class GetSecretIfExists
    {
        [Test]
        public void GetSecretIfExistsSync()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = TestEnvironment.KeyVaultUrl;

            #region Snippet:SecretsSample4SecretClient
            var client = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());
            #endregion

            #region Snippet:SecretsSample4GetSecretIfExists
            // Do not treat HTTP 404 responses as errors.
            RequestContext context = new RequestContext();
            context.AddClassifier(404, false);

            // Try getting the latest application connection string using the context above.
            NullableResponse<KeyVaultSecret> response = client.GetSecret("appConnectionString", null, context);
            if (response.HasValue)
            {
                KeyVaultSecret secret = response.Value;
                Debug.WriteLine($"Secret is returned with name {secret.Name} and value {secret.Value}");
            }
            #endregion
        }

        [Test]
        public async Task GetSecretIfExistsAsync()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = TestEnvironment.KeyVaultUrl;

            var client = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

            #region Snippet:SecretsSample4GetSecretIfExistsAsync
            // Do not treat HTTP 404 responses as errors.
            RequestContext context = new RequestContext();
            context.AddClassifier(404, false);

            // Try getting the latest application connection string using the context above.
            NullableResponse<KeyVaultSecret> response = await client.GetSecretAsync("appConnectionString", null, context);
            if (response.HasValue)
            {
                KeyVaultSecret secret = response.Value;
                Debug.WriteLine($"Secret is returned with name {secret.Name} and value {secret.Value}");
            }
            #endregion
        }
    }
}
