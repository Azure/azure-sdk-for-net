// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Azure.Management.BotService.Customizations;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;

namespace Microsoft.Azure.Management.BotService
{
    /// <summary>
    /// Abstraction to provision Microsoft applications, which are key pieces
    /// of creating a bot service.
    /// </summary>
    internal class MsaAppProvider
    {
        private readonly AuthenticationResult authenticationInfo;

        /// <summary>
        /// Creates an instance of MsaAppProvider
        /// </summary>
        public MsaAppProvider(AuthenticationResult authenticationResult)
        {
            this.authenticationInfo = authenticationResult;
        }

        /// <summary>
        /// Provisions a Microsoft application with the provided name using the authentication
        /// information provided when constructed
        /// </summary>
        public async Task<MsaAppIdInfo> ProvisionApp(string appName)
        {
            const string Scheme = "Bearer";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Scheme, authenticationInfo.AccessToken);

                string provisionUri = $"{BotServiceConfiguration.DevPortalUrl}api/botApp/provisionConvergedApp?name={appName}";

                var provisionPostResult = await client.PostAsync(provisionUri, new StringContent(string.Empty));
                var provisionResponseContent = await provisionPostResult.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<MsaAppIdInfo>(provisionResponseContent);
                
            }
        }
    }
}