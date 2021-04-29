// ------------------------------------
// Copyright(c) Microsoft Corporation.
// Licensed under the MIT License.
// ------------------------------------
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmokeTest
{
    class KeyVaultTest
    {
        private static Dictionary<string, Uri> authorityHostMap = new Dictionary<string, Uri>
        {
            { "AzureCloud", AzureAuthorityHosts.AzurePublicCloud },
            { "AzureChinaCloud", AzureAuthorityHosts.AzureChina },
            { "AzureGermanCloud", AzureAuthorityHosts.AzureGermany },
            { "AzureUSGovernment", AzureAuthorityHosts.AzureGovernment },
        };

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

            string keyVaultUri = Environment.GetEnvironmentVariable("KEY_VAULT_URI");
            var authorityHost = GetAuthorityHost(Environment.GetEnvironmentVariable("AZURE_CLOUD"), AzureAuthorityHosts.AzurePublicCloud);

            var defaultAzureCredentialOptions = new DefaultAzureCredentialOptions 
            {
                AuthorityHost = authorityHost
            };


            client = new SecretClient(
                new Uri(keyVaultUri), 
                new DefaultAzureCredential(defaultAzureCredentialOptions)
            );

            await SetNewSecret();
            await GetSecret();
            await CleanUp();
        }

        private static async Task SetNewSecret()
        {
            Console.Write("Setting a secret...");
            var newSecret = new KeyVaultSecret(SecretName, SecretValue);
            await client.SetSecretAsync(newSecret);
            Console.WriteLine("\tdone");
        }

        private static async Task GetSecret()
        {
            Console.Write("Getting that secret...");
            Azure.Response<KeyVaultSecret> secret;
            secret = await client.GetSecretAsync(SecretName);
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
            var secretDeletePoller = await client.StartDeleteSecretAsync(SecretName);
            await secretDeletePoller.WaitForCompletionAsync();
            Console.WriteLine("\tdone");
        }

        private static Uri GetAuthorityHost(string cloudName, Uri defaultAuthorityHost)
        {
            Uri output;
            if (authorityHostMap.TryGetValue(cloudName, out output))
            {
                return output;
            }
            return defaultAuthorityHost;
        }
    }
}
