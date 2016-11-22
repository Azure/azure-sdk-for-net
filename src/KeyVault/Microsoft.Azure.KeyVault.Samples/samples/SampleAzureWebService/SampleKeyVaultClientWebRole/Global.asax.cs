//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//

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
