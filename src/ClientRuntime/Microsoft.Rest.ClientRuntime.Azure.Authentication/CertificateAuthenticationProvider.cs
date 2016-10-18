// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Microsoft.Rest.Azure.Authentication
{
    public class CertificateAuthenticationProvider : IApplicationAuthenticationProvider
    {
        private Func<string, Task<ClientAssertionCertificate>> _assertionProvider;

        public CertificateAuthenticationProvider(byte[] certificate, string password)
        {
#if PORTABLE
            this._assertionProvider = (s) => Task.FromResult(new ClientAssertionCertificate(s, certificate, password));
#else
            this._assertionProvider = (s) => Task.FromResult(new ClientAssertionCertificate(s, 
                new System.Security.Cryptography.X509Certificates.X509Certificate2(certificate)));
#endif
        }

        /// <summary>
        /// Create an application authenticator using a certificate provider
        /// </summary>
        /// <param name="provider"></param>
        public CertificateAuthenticationProvider(Func<string, Task<ClientAssertionCertificate>> provider)
        {
            this._assertionProvider = provider;
        }

        public async Task<AuthenticationResult> AuthenticateAsync(string clientId, string audience, IdentityModel.Clients.ActiveDirectory.AuthenticationContext context)
        {
            var certificate = await this._assertionProvider(clientId).ConfigureAwait(false);
            return await context.AcquireTokenAsync(audience, certificate);
        }
    }
}
