using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;
using System.Threading.Tasks;

namespace SmokeTest
{
    class KeyVaultTest : TestBase
    {
        private string secretName;
        private string secretValue;
        private SecretClient client;

        public KeyVaultTest(string secretName, string secretValue, string tenantid, string clientid, string clientsecret, string KeyVaultUri)
        {
            this.secretName = secretName;
            this.secretValue = secretValue;
            this.client = new SecretClient(new Uri(KeyVaultUri), new ClientSecretCredential(tenantid, clientid, clientsecret));
        }

        /// <summary>
        /// Validates the Key Vault SDK
        /// </summary>
        /// <returns>true if passes, false if fails</returns>
        public async Task<bool> RunTests()
        {
            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("KEY VAULT");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Functionalities to test: 3:");
            Console.WriteLine("1.- Set a Secret");
            Console.WriteLine("2.- Get that Secret");
            Console.WriteLine("3.- Delete that Secret (Clean up)\n");
             
            var testPassed = true;

            Console.Write("Set a secret... ");
            var result1 = await ExecuteTest(SetNewSecret);
            if (!result1)
            {
                //If this test failes, the other ones are going to fail too.
                Console.WriteLine("Cannot get a secret and delete it.");
                return false;
            }

            Console.Write("Get that secret... ");
            var result2 = await ExecuteTest(GetSecret);
            if (!result2)
            {
                testPassed = false;
            }

            Console.Write("Cleaning up the resource... ");
            var result3 = await ExecuteTest(CleanUp);
            if (!result3)
            {
                testPassed = false;
            }

            return testPassed;
        }

        private async Task SetNewSecret()
        {
            var newSecret = new Secret(secretName, secretValue);
            await client.SetAsync(newSecret);
        }

        private async Task GetSecret()
        {
            Azure.Response<Secret> secret;
            secret = await client.GetAsync(secretName);                
            //Verify that the secret received is the one that was set previously
            if (secret.Value.Value != secretValue)
            {
                throw new Exception(String.Format("Secret retreived, but not the one previously created: '" + secret.Value.Value));
            }
        }

        private async Task CleanUp()
        {
            await client.DeleteAsync(secretName);
        }
    }
}