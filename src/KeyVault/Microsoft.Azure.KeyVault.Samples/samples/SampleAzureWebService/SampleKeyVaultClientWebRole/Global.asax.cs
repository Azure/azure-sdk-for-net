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

using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Azure;
using Microsoft.Azure.KeyVault;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.WindowsAzure.ServiceRuntime;
using SampleKeyVaultConfigurationManager;

namespace SampleKeyVaultClientWebRole
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var cerificateThumbprint = CloudConfigurationManager.GetSetting(Constants.KeyVaultAuthCertThumbprintSetting);
            var authenticationClientId = CloudConfigurationManager.GetSetting(Constants.KeyVaultAuthClientIdSetting);

            var certificate = CertificateHelper.FindCertificateByThumbprint(cerificateThumbprint);
            var assertionCert = new ClientAssertionCertificate(authenticationClientId, certificate);

            // initializes configuration manager with key vault authentication and the secret cache default timespan
            ConfigurationManager.Initialize(
                new KeyVaultClient.AuthenticationCallback(
                    (authority, resource, scope) => GetAccessToken(authority, resource, scope, assertionCert)), 
                Constants.KeyVaultSecretCacheDefaultTimeSpan);

            RoleEnvironment.Changed += RoleEnvironment_Changed;
        }

        /// <summary>
        /// The callback which is called to refresh in-memory service configuration settings only if the role environment is changed
        /// </summary>
        private void RoleEnvironment_Changed(object sender, RoleEnvironmentChangedEventArgs e)
        {
            ConfigurationManager.Reset();
        }
        /// <summary>
        /// Authentication callback that gets a token using the X509 certificate
        /// </summary>
        /// <param name="authority">Address of the authority</param>
        /// <param name="resource">Identifier of the target resource that is the recipient of the requested token</param>
        /// <param name="scope">Scope</param>
        /// <param name="assertionCert">The assertion certificate</param>
        /// <returns> The access token </returns>
        public static async Task<string> GetAccessToken(string authority, string resource, string scope, ClientAssertionCertificate assertionCert)
        {
            var context = new AuthenticationContext(authority, TokenCache.DefaultShared);

            var result = await context.AcquireTokenAsync(resource, assertionCert);

            return result.AccessToken;
        }
    }
}
