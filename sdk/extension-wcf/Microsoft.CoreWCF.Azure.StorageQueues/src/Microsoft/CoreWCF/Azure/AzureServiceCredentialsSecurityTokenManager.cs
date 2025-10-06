// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using CoreWCF.IdentityModel.Selectors;
using CoreWCF.IdentityModel.Tokens;
using CoreWCF.Security;
using Microsoft.CoreWCF.Azure.StorageQueues.Channels;
using Microsoft.CoreWCF.Azure.Tokens;
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.CoreWCF.Azure
{
    /// <summary>
    /// Manages Azure credential security tokens for a CoreWCF service.
    /// </summary>
    public class AzureServiceCredentialsSecurityTokenManager : ServiceCredentialsSecurityTokenManager
    {
        private AzureServiceCredentials _azureServiceCredentials;

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureServiceCredentialsSecurityTokenManager"/> class.
        /// </summary>
        /// <param name="azureServiceCredentials"></param>
        public AzureServiceCredentialsSecurityTokenManager(AzureServiceCredentials azureServiceCredentials) : base(azureServiceCredentials)
        {
            _azureServiceCredentials = azureServiceCredentials;
        }

        /// <summary>
        /// Creates a security token authenticator.
        /// </summary>
        /// <param name="tokenRequirement">The <see cerf="SecurityTokenRequirement">SecurityTokenRequirement</see>.</param>
        /// <param name="outOfBandTokenResolver">When this method returns, contains a <see cref="SecurityTokenResolver">SecurityTokenResolver</see>. This parameter is passed uninitialized.</param>
        /// <returns>The <see cref="SecurityTokenAuthenticator">SecurityTokenAuthenticator</see> object.</returns>
        /// <exception cref="ArgumentNullException">`tokenRequirement` is `null`.</exception>
        public override SecurityTokenAuthenticator CreateSecurityTokenAuthenticator(SecurityTokenRequirement tokenRequirement, out SecurityTokenResolver outOfBandTokenResolver)
        {
            outOfBandTokenResolver = null;
            if (tokenRequirement is null) throw new ArgumentNullException(nameof(tokenRequirement));

            if (tokenRequirement is InitiatorServiceModelSecurityTokenRequirement initiatorRequirement)
            {
                if (initiatorRequirement.TokenType == SecurityTokenTypes.X509Certificate && initiatorRequirement.KeyUsage == SecurityKeyUsage.Exchange)
                {
                    X509CertificateValidator certValidator = GetX509CertificateValidator();
                    if (certValidator != null)
                    {
                        return new X509SecurityTokenAuthenticator(certValidator);
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            return base.CreateSecurityTokenAuthenticator(tokenRequirement, out outOfBandTokenResolver);
        }

        private X509CertificateValidator GetX509CertificateValidator()
        {
            var certAuthentication = _azureServiceCredentials.ClientCertificate.Authentication;
            switch (certAuthentication.CertificateValidationMode)
            {
                case X509CertificateValidationMode.None:
                    return X509CertificateValidator.None;
                case X509CertificateValidationMode.PeerTrust:
                    return X509CertificateValidator.PeerTrust;
                case X509CertificateValidationMode.Custom:
                    return _azureServiceCredentials.ClientCertificate.Authentication.CustomCertificateValidator;
            }

            bool useMachineContext = certAuthentication.TrustedStoreLocation == StoreLocation.LocalMachine;
            X509ChainPolicy chainPolicy = new X509ChainPolicy();
            chainPolicy.ApplicationPolicy.Add(new Oid("1.3.6.1.5.5.7.3.1", "1.3.6.1.5.5.7.3.1"));
            chainPolicy.RevocationMode = certAuthentication.RevocationMode;
            if (certAuthentication.CertificateValidationMode == X509CertificateValidationMode.ChainTrust)
            {
                // Returning null means use the QueueClient default implementation
                return null;
            }
            else
            {
                return X509CertificateValidator.CreatePeerOrChainTrustValidator(useMachineContext, chainPolicy);
            }
        }

        /// <summary>
        /// Creates a security token provider.
        /// </summary>
        /// <param name="tokenRequirement">The <see cref="SecurityTokenRequirement">SecurityTokenRequirement</see>.</param>
        /// <returns>The <see cref="SecurityTokenProvider">SecurityTokenProvider</see> object.</returns>
        /// <exception cref="ArgumentNullException">`tokenRequirement` is `null`.</exception>
        public override SecurityTokenProvider CreateSecurityTokenProvider(SecurityTokenRequirement tokenRequirement)
        {
            if (tokenRequirement is null) throw new ArgumentNullException(nameof(tokenRequirement));

            if (tokenRequirement.TokenType.StartsWith(AzureSecurityTokenTypes.Namespace))
                return new AzureSecurityTokenProvider(_azureServiceCredentials, tokenRequirement);
            return base.CreateSecurityTokenProvider(tokenRequirement);
        }

        /// <summary>
        /// Creates a security token serializer.
        /// </summary>
        /// <param name="version">The <see cref="SecurityTokenVersion">SecurityTokenVersion</see> of the security token.</param>
        /// <returns>The <see cref="SecurityTokenSerializer">SecurityTokenSerializer</see> object.</returns>
        public override SecurityTokenSerializer CreateSecurityTokenSerializer(SecurityTokenVersion version)
        {
            return base.CreateSecurityTokenSerializer(version);
        }
    }
}