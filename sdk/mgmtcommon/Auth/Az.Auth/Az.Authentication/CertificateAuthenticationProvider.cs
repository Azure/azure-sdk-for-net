// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.Azure.Authentication
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;

    public class CertificateAuthenticationProvider : IApplicationAuthenticationProvider
    {
        #region fields
        private Func<string, Task<ClientAssertionCertificate>> _assertionProvider;

        private bool _isCertRollOverEnabled;
        #endregion

        #region Properties

        #endregion

        #region Constructor
        CertificateAuthenticationProvider()
        {
            _isCertRollOverEnabled = false;
        }
        /// <summary>
        /// Create an application authenticator using a certificate provider
        /// </summary>
        /// <param name="provider"></param>
        public CertificateAuthenticationProvider(Func<string, Task<ClientAssertionCertificate>> provider) : this()
        {
            this._assertionProvider = provider;
        }

        public CertificateAuthenticationProvider(byte[] certificate, string password) : this()
        {
#if !net452
            this._assertionProvider = (s) => Task.FromResult(new ClientAssertionCertificate(s, certificate, password));
#else
            this._assertionProvider = (s) => Task.FromResult(
                new ClientAssertionCertificate(s, new System.Security.Cryptography.X509Certificates.X509Certificate2(certificate)));
#endif
        }

#if !net452

        public CertificateAuthenticationProvider(byte[] rawCertificate) : this(rawCertificate, IsCertRollOverEnabled: false) { }
        
        public CertificateAuthenticationProvider(byte[] rawCertificate, string password, bool IsCertRollOverEnabled) : this()
        {
            _isCertRollOverEnabled = IsCertRollOverEnabled;
            _assertionProvider = (clientId) => Task.FromResult<ClientAssertionCertificate>(new ClientAssertionCertificate(clientId, rawCertificate, password));
        }

        public CertificateAuthenticationProvider(byte[] rawCertificate, bool IsCertRollOverEnabled) : this()
        {
            _isCertRollOverEnabled = IsCertRollOverEnabled;
            _assertionProvider = (clientId) => Task.FromResult<ClientAssertionCertificate>(new ClientAssertionCertificate(clientId, rawCertificate));
        }

        public CertificateAuthenticationProvider(string certificateFilePath, bool IsCertRollOverEnabled): this()
        {
            _isCertRollOverEnabled = IsCertRollOverEnabled;
            _assertionProvider = (clientId) => Task.FromResult<ClientAssertionCertificate>(new ClientAssertionCertificate(clientId, certificateFilePath));
        }

        public CertificateAuthenticationProvider(ClientAssertionCertificate certAssertion, bool IsCertRollOverEnabled) : this()
        {
            _isCertRollOverEnabled = IsCertRollOverEnabled;
            _assertionProvider = (clientId) => Task.FromResult<ClientAssertionCertificate>(certAssertion);
        }

#endif
        #endregion

        #region Public Functions

        public async Task<AuthenticationResult> AuthenticateAsync(string clientId, string audience, AuthenticationContext context)
        {
            var certificate = await this._assertionProvider(clientId).ConfigureAwait(false);
            AuthenticationResult authResult = null;
            //We are not #if def'd this part of the code, because the constructors are #if Defd and so in .NET 452 rollOver flag will be set as false
            if (_isCertRollOverEnabled == true)
            {
#if !net452
                authResult = await context.AcquireTokenAsync(audience, certificate, sendX5c: _isCertRollOverEnabled).ConfigureAwait(false);
#endif
            }
            else
            {
                authResult = await context.AcquireTokenAsync(audience, certificate).ConfigureAwait(false);
            }

            return authResult;
        }

        //async Task<AuthenticationResult> AuthenticateAsync(string clientId, string audience, AuthenticationContext context, bool IsCertRollOverEnabled = false)
        //{
        //    var certificate = await this._assertionProvider(clientId).ConfigureAwait(false);
        //    return await context.AcquireTokenAsync(audience, certificate, sendX5c: IsCertRollOverEnabled);
        //}
        #endregion
    }
}
