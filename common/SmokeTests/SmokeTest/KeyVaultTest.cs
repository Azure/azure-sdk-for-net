// ------------------------------------
// Copyright(c) Microsoft Corporation.
// Licensed under the MIT License.
// ------------------------------------
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;
using System.Threading.Tasks;

namespace SmokeTest
{
    class KeyVaultTest
    {
        private static string SecretName = $"SmokeTestSecret-{Guid.NewGuid()}";
        private const string SecretValue = "smokeTestValue";
        private static SecretClient client;

        /// <summary>
        /// Validates the Key Vault SDK
        /// </summary>
        public static async Task RunTests()
        {
            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("KEY VAULT");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Functionalities to test: 3:");
            Console.WriteLine("1.- Set a Secret");
            Console.WriteLine("2.- Get that Secret");
            Console.WriteLine("3.- Delete that Secret (Clean up)\n");

            string tenantID = Environment.GetEnvironmentVariable("DIR_TENANT_ID");
            string clientID = Environment.GetEnvironmentVariable("APP_CLIENT_ID");
            string clientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET");
            string keyVaultUri = Environment.GetEnvironmentVariable("KEY_VAULT_URI");
            client = new SecretClient(new Uri(keyVaultUri), new ClientSecretCredential(tenantID, clientID, clientSecret));

            await SetNewSecret();
            await GetSecret();
            await CleanUp();
        }

        private static async Task SetNewSecret()
        {
            Console.Write("Setting a secret...");
            var newSecret = new Secret(SecretName, SecretValue);
            await client.SetAsync(newSecret);
            Console.WriteLine("\tdone");
        }

        private static async Task GetSecret()
        {
            Console.Write("Getting that secret...");
            Azure.Response<Secret> secret;
            secret = await client.GetAsync(SecretName);                
            //Verify that the secret received is the one that was set previously
            if (secret.Value.Value != SecretValue)
            {
                throw new Exception(String.Format("Secret retreived, but not the one previously created: '" + secret.Value.Value));
            }
            Console.WriteLine("\tdone");
        }

        private static async Task CleanUp()
        {
            Console.Write("Cleaning up the resource...");
            await client.DeleteAsync(SecretName);
            Console.WriteLine("\tdone");
        }
    }
}