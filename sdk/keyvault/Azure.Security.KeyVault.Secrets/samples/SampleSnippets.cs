// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using Azure.Identity;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Secrets.Samples
{
    /// <summary>
    /// Samples that are used in the associated README.md file.
    /// </summary>
    [LiveOnly]
    public partial class Snippets
    {
#pragma warning disable IDE1006 // Naming Styles
        private SecretClient client;
#pragma warning restore IDE1006 // Naming Styles

        [OneTimeSetUp]
        public void CreateClient()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = Environment.GetEnvironmentVariable("AZURE_KEYVAULT_URL");

            #region Snippet:CreateSecretClient
            // Create a new secret client using the default credential from Azure.Identity using environment variables previously set,
            // including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
            var client = new SecretClient(vaultUri: new Uri(keyVaultUrl), credential: new DefaultAzureCredential());

            // Create a new secret using the secret client.
            KeyVaultSecret secret = client.SetSecret("secret-name", "secret-value");

            // Retrieve a secret using the secret client.
            secret = client.GetSecret("secret-name");
            #endregion

            this.client = client;
        }

        [Test]
        public async Task CreateSecret()
        {
            #region Snippet:CreateSecret
            KeyVaultSecret secret = await client.SetSecretAsync("secret-name", "secret-value");

            Console.WriteLine(secret.Name);
            Console.WriteLine(secret.Value);
            Console.WriteLine(secret.Properties.Version);
            Console.WriteLine(secret.Properties.Enabled);
            #endregion
        }

        [Test]
        public void CreateSecretSync()
        {
            #region Snippet:CreateSecretSync
            KeyVaultSecret secret = client.SetSecret("secret-name", "secret-value");

            Console.WriteLine(secret.Name);
            Console.WriteLine(secret.Value);
            #endregion
        }

        [Test]
        public async Task RetrieveSecret()
        {
            // Make sure a secret exists. This will create a new version if "secret-name" already exists.
            await client.SetSecretAsync("secret-name", "secret-value");

            #region Snippet:RetrieveSecret
            KeyVaultSecret secret = await client.GetSecretAsync("secret-name");

            Console.WriteLine(secret.Name);
            Console.WriteLine(secret.Value);
            #endregion
        }

        [Test]
        public async Task UpdateSecret()
        {
            // Make sure a secret exists. This will create a new version if "secret-name" already exists.
            await client.SetSecretAsync("secret-name", "secret-value");

            #region Snippet:UpdateSecret
            KeyVaultSecret secret = await client.GetSecretAsync("secret-name");

            // Clients may specify the content type of a secret to assist in interpreting the secret data when it's retrieved.
            secret.Properties.ContentType = "text/plain";

            // You can specify additional application-specific metadata in the form of tags.
            secret.Properties.Tags["foo"] = "updated tag";

            SecretProperties updatedSecretProperties = await client.UpdateSecretPropertiesAsync(secret.Properties);

            Console.WriteLine(updatedSecretProperties.Name);
            Console.WriteLine(updatedSecretProperties.Version);
            Console.WriteLine(updatedSecretProperties.ContentType);
            #endregion
        }

        [Test]
        public async Task ListSecrets()
        {
            #region Snippet:ListSecrets
            AsyncPageable<SecretProperties> allSecrets = client.GetPropertiesOfSecretsAsync();

            await foreach (SecretProperties secretProperties in allSecrets)
            {
                Console.WriteLine(secretProperties.Name);
            }
            #endregion
        }

        [Test]
        public async Task NotFound()
        {
            #region Snippet:SecretNotFound
            try
            {
                KeyVaultSecret secret = await client.GetSecretAsync("some_secret");
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            #endregion
        }

        [Ignore("The secret is deleted and purged on tear down of this text fixture.")]
        public async Task DeleteSecret()
        {
            #region Snippet:DeleteSecret
            DeleteSecretOperation operation = await client.StartDeleteSecretAsync("secret-name");

            DeletedSecret secret = operation.Value;
            Console.WriteLine(secret.Name);
            Console.WriteLine(secret.Value);
            #endregion
        }

        [OneTimeTearDown]
        public async Task DeleteAndPurgeSecret()
        {
            #region Snippet:DeleteAndPurgeSecret
            DeleteSecretOperation operation = await client.StartDeleteSecretAsync("secret-name");

            // You only need to wait for completion if you want to purge or recover the secret.
            await operation.WaitForCompletionAsync();

            DeletedSecret secret = operation.Value;
            await client.PurgeDeletedSecretAsync(secret.Name);
            #endregion
        }

        [Ignore("The secret is deleted and purged on tear down of this text fixture.")]
        public void DeleteSecretSync()
        {
            #region Snippet:DeleteSecretSync
            DeleteSecretOperation operation = client.StartDeleteSecret("secret-name");

            // You only need to wait for completion if you want to purge or recover the secret.
            while (!operation.HasCompleted)
            {
                Thread.Sleep(2000);

                operation.UpdateStatus();
            }

            DeletedSecret secret = operation.Value;
            client.PurgeDeletedSecret(secret.Name);
            #endregion
        }
    }
}
