// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Identity;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Security.KeyVault.Tests;

namespace Azure.Security.KeyVault.Secrets.Samples
{
    /// <summary>
    /// Samples that are used in the associated README.md file.
    /// </summary>
    public partial class Snippets
    {
#pragma warning disable IDE1006 // Naming Styles
        private SecretClient client;
#pragma warning restore IDE1006 // Naming Styles

        [OneTimeSetUp]
        public void CreateClient()
        {
            // Environment variable with the Key Vault endpoint.
            string keyVaultUrl = TestEnvironment.KeyVaultUrl;

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
        public void CreateSecret()
        {
            #region Snippet:CreateSecret
            KeyVaultSecret secret = client.SetSecret("secret-name", "secret-value");

            Console.WriteLine(secret.Name);
            Console.WriteLine(secret.Value);
            Console.WriteLine(secret.Properties.Version);
            Console.WriteLine(secret.Properties.Enabled);
            #endregion
        }

        [Test]
        public async Task CreateSecretAsync()
        {
            #region Snippet:CreateSecretAsync
            KeyVaultSecret secret = await client.SetSecretAsync("secret-name", "secret-value");

            Console.WriteLine(secret.Name);
            Console.WriteLine(secret.Value);
            #endregion
        }

        [Test]
        public void RetrieveSecret()
        {
            // Make sure a secret exists. This will create a new version if "secret-name" already exists.
            client.SetSecret("secret-name", "secret-value");

            #region Snippet:RetrieveSecret
            KeyVaultSecret secret = client.GetSecret("secret-name");

            Console.WriteLine(secret.Name);
            Console.WriteLine(secret.Value);
            #endregion
        }

        [Test]
        public void UpdateSecret()
        {
            // Make sure a secret exists. This will create a new version if "secret-name" already exists.
            client.SetSecret("secret-name", "secret-value");

            #region Snippet:UpdateSecret
            KeyVaultSecret secret = client.GetSecret("secret-name");

            // Clients may specify the content type of a secret to assist in interpreting the secret data when its retrieved.
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
            #region Snippet:ListSecrets
            Pageable<SecretProperties> allSecrets = client.GetPropertiesOfSecrets();

            foreach (SecretProperties secretProperties in allSecrets)
            {
                Console.WriteLine(secretProperties.Name);
            }
            #endregion
        }

        [Test]
        public async Task ListSecretsAsync()
        {
            #region Snippet:ListSecretsAsync
            AsyncPageable<SecretProperties> allSecrets = client.GetPropertiesOfSecretsAsync();

            await foreach (SecretProperties secretProperties in allSecrets)
            {
                Console.WriteLine(secretProperties.Name);
            }
            #endregion
        }

        [Test]
        public void NotFound()
        {
            #region Snippet:SecretNotFound
            try
            {
                KeyVaultSecret secret = client.GetSecret("some_secret");
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            #endregion
        }

        [Ignore("The secret is deleted and purged on tear down of this text fixture.")]
        public void DeleteSecret()
        {
            #region Snippet:DeleteSecret
            DeleteSecretOperation operation = client.StartDeleteSecret("secret-name");

            DeletedSecret secret = operation.Value;
            Console.WriteLine(secret.Name);
            Console.WriteLine(secret.Value);
            #endregion
        }

        [OneTimeTearDown]
        public async Task DeleteAndPurgeSecretAsync()
        {
            #region Snippet:DeleteAndPurgeSecretAsync
            DeleteSecretOperation operation = await client.StartDeleteSecretAsync("secret-name");

            // You only need to wait for completion if you want to purge or recover the secret.
            await operation.WaitForCompletionAsync();

            DeletedSecret secret = operation.Value;
            await client.PurgeDeletedSecretAsync(secret.Name);
            #endregion
        }

        [Ignore("The secret is deleted and purged on tear down of this text fixture.")]
        public void DeleteAndPurgeSecret()
        {
            #region Snippet:DeleteAndPurgeSecret
            DeleteSecretOperation operation = client.StartDeleteSecret("secret-name");

            // You only need to wait for completion if you want to purge or recover the secret.
            // You should call `UpdateStatus` in another thread or after doing additional work like pumping messages.
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
