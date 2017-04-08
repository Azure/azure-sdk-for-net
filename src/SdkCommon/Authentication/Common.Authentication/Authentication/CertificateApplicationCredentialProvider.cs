// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest.Azure.Authentication;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Microsoft.Azure.Common.Authentication
{
    /// <summary>
    /// Interface to the certificate store for authentication
    /// </summary>
    internal sealed class CertificateApplicationCredentialProvider : IApplicationAuthenticationProvider
    {
        private string _certificateThumbprint;

        /// <summary>
        /// Create a certificate provider
        /// </summary>
        /// <param name="certificateThumbprint"></param>
        public CertificateApplicationCredentialProvider(string certificateThumbprint)
        {
            this._certificateThumbprint = certificateThumbprint;
        }
        
        /// <summary>
        /// Authenticate using certificate thumbprint from the datastore 
        /// </summary>
        /// <param name="clientId">The active directory client id for the application.</param>
        /// <param name="audience">The intended audience for authentication</param>
        /// <param name="context">The AD AuthenticationContext to use</param>
        /// <returns></returns>
        public async Task<AuthenticationResult> AuthenticateAsync(string clientId, string audience, AuthenticationContext context)
        {
            var task = new Task<X509Certificate2>(() =>
            {
                return  AzureSession.DataStore.GetCertificate(this._certificateThumbprint);
            });
            task.Start();
            var certificate = await task.ConfigureAwait(false);

            return await context.AcquireTokenAsync(
                audience,
                new ClientAssertionCertificate(clientId, certificate));
        }
    }
}
