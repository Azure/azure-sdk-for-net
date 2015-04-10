// 
// Copyright © Microsoft Corporation, All Rights Reserved
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION
// ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A
// PARTICULAR PURPOSE, MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache License, Version 2.0 for the specific language
// governing permissions and limitations under the License.

using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Azure.KeyVault;
using Microsoft.WindowsAzure;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace SampleKeyVaultClientWebRole
{
    /// <summary>    
    /// This class uses Microsoft.KeyVault.Client library to call into Key Vault and retrieve a secret.
    /// 
    /// Authentication when calling Key Vault is done through the configured X509 ceritifcate.
    /// </summary>
    public class KeyVaultAccessor
    {
        private static KeyVaultClient keyVaultClient;
        private static X509Certificate2 clientAssertionCertPfx;
        static KeyVaultAccessor()
        {
            keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(GetAccessToken));
            clientAssertionCertPfx = CertificateHelper.FindCertificateByThumbprint(CloudConfigurationManager.GetSetting(Constants.KeyVaultAuthCertThumbprintSetting));
        }

        /// <summary>
        /// Get a secret from Key Vault
        /// </summary>
        /// <param name="secretId">ID of the secret</param>
        /// <returns>secret value</returns>
        public static async Task<string> GetSecret(string secretId)
        {
            var secret = await keyVaultClient.GetSecretAsync(secretId);
            return secret.Value;
        }

        /// <summary>
        /// Authentication callback that gets a token using the X509 certificate
        /// </summary>
        /// <param name="authority">Address of the authority</param>
        /// <param name="resource">Identifier of the target resource that is the recipient of the requested token</param>
        /// <param name="scope">Scope</param>
        /// <returns></returns>
        public static async Task<string> GetAccessToken(string authority, string resource, string scope)
        {
            var client_id = CloudConfigurationManager.GetSetting(Constants.KeyVaultAuthClientIdSetting);

            var context = new AuthenticationContext(authority, null);
            
            var assertionCert = new ClientAssertionCertificate(client_id, clientAssertionCertPfx);

            var result = await context.AcquireTokenAsync(resource, assertionCert);

            return result.AccessToken;
        }

    }
}