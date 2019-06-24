using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using System;
using System.Threading.Tasks;

namespace SmokeTest
{
    class KeyVaultTest
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

        public async Task<bool> PerformFunctionalities()
        {
            Console.WriteLine("\n---------------------------------");
            Console.WriteLine("KEY VAULT");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Functionalities to test: 3:");
            Console.WriteLine("1.- Set a Secret");
            Console.WriteLine("2.- Get that Secret");
            Console.WriteLine("3.- Delete that Secret (Clean up)");
            Console.WriteLine("");
             
            var testPassed = true;

            //Create a new Secret
            Console.Write("Set a secret... ");
            var result1 = await SetNewSecret();
            if (result1 != null)
            {
                //If this test failes, the other ones are going to fail too.
                Console.Error.Write("FAILED.\n");
                Console.Error.WriteLine(result1);
                Console.Error.WriteLine("Cannot get a secret and delete it.");
                
                return false;
            }
            else
            {
                Console.Error.Write("Secret created succesfully.\n");
            }

            //Retrieve the Secret previously created
            Console.Write("Get that secret... ");
            var result2 = await GetSecret();
            if (result2 != null)
            {
                Console.Error.Write("FAILED.\n");
                Console.Error.WriteLine(result2);

                testPassed = false;
            }
            else
            {
                Console.WriteLine("Secret succesfully retreived.");
            }

            //Clean up the resource (Delete the secret that was created)
            Console.Write("Cleaning up the resource... ");
            var result3 = await CleanUp();
            if (result3 != null)
            {
                Console.Error.Write("FAILED.\n");
                Console.Error.WriteLine(result3);

                testPassed = false;
            }
            else
            {
                Console.WriteLine("done.");
            }

            return testPassed;
        }

        private async Task<Exception> SetNewSecret()
        {
            try
            {
                var newSecret = new Secret(secretName, secretValue);
                var result = await client.SetAsync(newSecret);
            }
            catch (Exception ex)
            {
                return ex;
            }
            
            return null;

            //return result.Value.Value;

        }

        private async Task<Exception> GetSecret()
        {
            Azure.Response<Secret> secret;

            try
            {
                secret = await client.GetAsync(secretName);                
            }
            catch (Exception ex)
            {
                return ex;
            }

            //Verify that the secret received is the one that was sent previously
            if (secret.Value.Value == secretValue)
            {
                return null;
            }
            else
            {
                return new Exception(String.Format("Secret retreived, but not the one previously created: '" + secret.Value.Value));
            }

        }

        private async Task<Exception> CleanUp()
        {
            try
            {
                await client.DeleteAsync(secretName);
            }
            catch (Exception ex)
            {
                return ex;
            }
           
            return null;
        }

    }
}
