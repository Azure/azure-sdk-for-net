using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;
using System.Threading.Tasks;

namespace SmokeTest
{
    class KeyVaultTest
    {
        public static async Task performFunctionalities()
        {
            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("KEY VAULT");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Functionalities to test: 3:");
            Console.WriteLine("1.- Set a Secret");
            Console.WriteLine("2.- Get that Secret");
            Console.WriteLine("3.- Delete that Secret (Clean up)");
            Console.WriteLine("");

            /*
             * Create the KeyVault Client.
             * The credentials are stored in environment variables.
             */

            var tenantid = Environment.GetEnvironmentVariable("DIR_TENANT_ID");
            var clientid = Environment.GetEnvironmentVariable("APP_CLIENT_ID");
            var clientsecret = Environment.GetEnvironmentVariable("CLIENT_SECRET");
            var KeyVaultUri = Environment.GetEnvironmentVariable("KEY_VAULT_URI");
            
            var client = new SecretClient(new Uri(KeyVaultUri), new ClientSecretCredential(tenantid, clientid, clientsecret));

            const string SecretName = "SmokeTestSecret";

            //Create a new Secret
            Console.Write("Set a secret... ");
            Console.Write(await SetNewSecret(SecretName, client) + '\n');

            //Retrieve the Secret previously created
            Console.Write("Get that secret... ");
            Console.Write(await GetSecret(SecretName, client) + '\n');

            //Clean up the resource (Delte the secret that was created)
            Console.Write("Cleaning up the resource... ");
            Console.Write(await CleanUp(SecretName, client) + '\n');
        }

        private static async Task<string> SetNewSecret(string secretName, SecretClient client)
        {
            var newSecret = new Secret(secretName, "Secret Succesfully created");

            var result = await client.SetAsync(newSecret);
        
            return result.Value.Value;
        }

        private static async Task<string> GetSecret(string secretName, SecretClient client)
        {
            var secret = await client.GetAsync(secretName);

            return secret.Value.Value == "Secret Succesfully created"?  "Secret succesfully retreived" : "Secret retreived, but not the one previously created: " + secret.Value.Value;
      
        }

        private static async Task<string> CleanUp(string secretName, SecretClient client)
        {
            await client.DeleteAsync(secretName);
            return "done";
        }

    }
}
