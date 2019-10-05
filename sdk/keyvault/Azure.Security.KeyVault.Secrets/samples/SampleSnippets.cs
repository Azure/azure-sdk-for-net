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

            #region CreateClient
            // Create a new secret client using the default credential from Azure.Identity using environment variables previously set,
            // including AZURE_CLIENT_ID, AZURE_CLIENT_SECRET, and AZURE_TENANT_ID.
            var client = new SecretClient(vaultUri: new Uri(keyVaultUrl), credential: new DefaultAzureCredential());

            // Create a new secret using the secret client
            Secret secret = client.SetSecret("secret-name", "secret-value");
            #endregion

            this.client = client;
        }

        [Test]
        public void CreateSecret()
        {
            #region CreateSecret
            Secret secret = client.SetSecret("secret-name", "secret-value");

            Console.WriteLine(secret.Name);
            Console.WriteLine(secret.Value);
            Console.WriteLine(secret.Properties.Version);
            Console.WriteLine(secret.Properties.Enabled);
            #endregion
        }

        [Test]
        public async Task CreateSecretAsync()
        {
            #region CreateSecretAsync
            Secret secret = await client.SetSecretAsync("secret-name", "secret-value");

            Console.WriteLine(secret.Name);
            Console.WriteLine(secret.Value);
            #endregion
        }

        [Test]
        public void RetrieveSecret()
        {
            // Make sure a secret exists.
            client.SetSecret("secret-name", "secret-value");

            #region RetrieveSecret
            Secret secret = client.GetSecret("secret-name");

            Console.WriteLine(secret.Name);
            Console.WriteLine(secret.Value);
            #endregion
        }

        [Test]
        public void UpdateSecret()
        {
            // Make sure a secret exists.
            client.SetSecret("secret-name", "secret-value");

            #region UpdateSecret
            Secret secret = client.GetSecret("secret-name");

            // Clients may specify the content type of a secret to assist in interpreting the secret data when it's retrieved.
            secret.Properties.ContentType = "text/plain";

            // You can specify additional application-specific metadata in the form of tags.
            secret.Properties.Tags["foo"] = "updated tag";

            SecretProperties updatedSecretProperties = client.UpdateSecretProperties(secret.Properties);

            Console.WriteLine(updatedSecretProperties.Name);
            Console.WriteLine(updatedSecretProperties.Version);
            Console.WriteLine(updatedSecretProperties.ContentType);
            #endregion
        }

        [Test]
        public void ListSecrets()
        {
            #region ListSecrets
            Pageable<SecretProperties> allSecrets = client.GetSecrets();

            foreach (SecretProperties secret in allSecrets)
            {
                Console.WriteLine(secret.Name);
            }
            #endregion
        }

        [Test]
        public void NotFound()
        {
            #region NotFound
            try
            {
                Secret secret = client.GetSecret("some_secret");
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            #endregion
        }

        [OneTimeTearDown]
        public void DeleteSecret()
        {
            #region DeleteSecret
            DeletedSecret secret = client.DeleteSecret("secret-name");

            Console.WriteLine(secret.Name);
            Console.WriteLine(secret.Value);
            #endregion

            try
            {
                // Deleting a secret when soft delete is enabled may not happen immediately.
                WaitForDeletedSecret(secret.Name);

                client.PurgeDeletedSecret(secret.Name);
            }
            catch
            {
                // Merely attempt to purge a deleted secret since the Key Vault may not have soft delete enabled.
            }
        }
        private void WaitForDeletedSecret(string secretName)
        {
            int maxIterations = 20;
            for (int i = 0; i < maxIterations; i++)
            {
                try
                {
                    client.GetDeletedSecret(secretName);
                }
                catch
                {
                    Thread.Sleep(5000);
                }
            }
        }
    }
}
