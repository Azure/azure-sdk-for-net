// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Microsoft.Azure.Services.AppAuthentication
{
    /// <summary>
    /// Used to acquire token using certificate associated with an Azure AD application.
    /// </summary>
    internal class ClientCertificateAzureServiceTokenProvider : NonInteractiveAzureServiceTokenProviderBase
    {
        // AppId of the application.
        private readonly string _clientId;

        // Certificate identifier: subject, thumbprint, or Key Vault secret identifier
        private readonly string _certificateIdentifier;

        // Enum which tells if subject, thumbprint, or Key Vault secret identifier is being used as identifier
        private readonly CertificateIdentifierType _certificateIdentifierType;

        private readonly string _azureAdInstance;

        private string _tenantId;

        private readonly IAuthenticationContext _authenticationContext;

        private readonly KeyVaultClient _keyVaultClient;

        // Store where certificate is deployed. 
        private readonly StoreLocation _storeLocation;

        internal enum CertificateIdentifierType
        {
            SubjectName,
            Thumbprint,
            KeyVaultCertificateSecretIdentifier
        };

        /// <summary>
        /// Creates instance of ClientCertificateAzureServiceTokenProvider class.
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="certificateIdentifier"></param>
        /// <param name="certificateIdentifierType"></param>
        /// <param name="storeLocation"></param>
        /// <param name="azureAdInstance"></param>
        /// <param name="authenticationContext"></param>
        /// <param name="tenantId"></param>
        internal ClientCertificateAzureServiceTokenProvider(string clientId,
            string certificateIdentifier, CertificateIdentifierType certificateIdentifierType, string storeLocation,
            string azureAdInstance, string tenantId = default, int msiRetryTimeoutInSeconds = 0,
            string keyVaultUserAssignedManagedIdentityId = null,
            IAuthenticationContext authenticationContext = null, KeyVaultClient keyVaultClient = null)
        {
            if (string.IsNullOrWhiteSpace(clientId))
            {
                throw new ArgumentNullException(nameof(clientId));
            }

            if (string.IsNullOrWhiteSpace(certificateIdentifier))
            {
                throw new ArgumentNullException(nameof(certificateIdentifier));
            }

            // require storeLocation if using subject name or thumbprint identifier
            if (certificateIdentifierType == CertificateIdentifierType.SubjectName
                || certificateIdentifierType == CertificateIdentifierType.Thumbprint)
            {
                if (string.IsNullOrWhiteSpace(storeLocation))
                {
                    throw new ArgumentNullException(nameof(storeLocation));
                }

                // Parse store location specified in connection string. 
                StoreLocation location;
                if (Enum.TryParse(storeLocation, true, out location))
                {
                    _storeLocation = location;
                }
                else
                {
                    throw new ArgumentException(
                        $"StoreLocation {storeLocation} is not valid. Valid values are CurrentUser and LocalMachine.");
                }
            }
            else
            {
                _keyVaultClient = keyVaultClient ?? new KeyVaultClient(msiRetryTimeoutInSeconds, keyVaultUserAssignedManagedIdentityId);
            }

            _clientId = clientId;

            _certificateIdentifierType = certificateIdentifierType;
            _azureAdInstance = azureAdInstance;
            _tenantId = tenantId;
            _authenticationContext = authenticationContext ?? new AdalAuthenticationContext();

            _certificateIdentifier = certificateIdentifier;

            PrincipalUsed = new Principal
            {
                Type = "App",
                AppId = _clientId
            };
        }


        /// <summary>
        /// Get access token using asymmetric key associated with an Azure AD application.
        /// </summary>
        /// <param name="resource">Resource to access.</param>
        /// <param name="authority">Authority where resource is.</param>
        /// <returns></returns>
        public override async Task<AppAuthenticationResult> GetAuthResultAsync(string resource, string authority,
            CancellationToken cancellationToken = default)
        {
            // If authority is not specified and tenantId was present in connection string, create it using azureAdInstance and tenantId. 
            if (string.IsNullOrWhiteSpace(authority) && !string.IsNullOrWhiteSpace(_tenantId))
            {
                authority = $"{_azureAdInstance}{_tenantId}";
            }

            List<X509Certificate2> certs = null;
            Dictionary<string, string> exceptionDictionary = new Dictionary<string, string>();

            try
            {
                switch (_certificateIdentifierType)
                {
                    case CertificateIdentifierType.KeyVaultCertificateSecretIdentifier:
                        // Get certificate for the given Key Vault secret identifier
                        try
                        {
                            var keyVaultCert = await _keyVaultClient
                                .GetCertificateAsync(_certificateIdentifier, cancellationToken).ConfigureAwait(false);
                            certs = new List<X509Certificate2>() { keyVaultCert };

                            // If authority is still not specified, create it using azureAdInstance and tenantId. Tenant ID comes from Key Vault access token.
                            if (string.IsNullOrWhiteSpace(authority))
                            {
                                _tenantId = _keyVaultClient.PrincipalUsed.TenantId;
                                authority = $"{_azureAdInstance}{_tenantId}";
                            }
                        }
                        catch (Exception exp)
                        {
                            throw new AzureServiceTokenProviderException(ConnectionString, resource, authority,
                                $"{AzureServiceTokenProviderException.KeyVaultCertificateRetrievalError} {exp.Message}");
                        }
                        break;
                    case CertificateIdentifierType.SubjectName:
                    case CertificateIdentifierType.Thumbprint:
                        // Get certificates for the given thumbprint or subject name. 
                        bool isThumbprint = _certificateIdentifierType == CertificateIdentifierType.Thumbprint;
                        certs = CertificateHelper.GetCertificates(_certificateIdentifier, isThumbprint,
                            _storeLocation);

                        if (certs == null || certs.Count == 0)
                        {
                            throw new AzureServiceTokenProviderException(ConnectionString, resource, authority,
                                AzureServiceTokenProviderException.LocalCertificateNotFound);
                        }
                        break;
                }

                Debug.Assert(certs != null, "Probably wrong certificateIdentifierType was used to instantiate this class!");

                // If multiple certs were found, use in order of most recently created.
                // This helps if old cert is rolled over, but not removed.
                // To hold reason why token could not be acquired per cert tried. 
                foreach (X509Certificate2 cert in certs.OrderByDescending(p => p.NotBefore))
                {
                    if (!string.IsNullOrEmpty(cert.Thumbprint))
                    {
                        try
                        {
                            ClientAssertionCertificate certCred = new ClientAssertionCertificate(_clientId, cert);

                            var authResult =
                                await _authenticationContext.AcquireTokenAsync(authority, resource, certCred)
                                    .ConfigureAwait(false);

                            var accessToken = authResult?.AccessToken;

                            if (accessToken != null)
                            {
                                PrincipalUsed.CertificateThumbprint = cert.Thumbprint;
                                PrincipalUsed.IsAuthenticated = true;
                                PrincipalUsed.TenantId = AccessToken.Parse(accessToken).TenantId;

                                return authResult;
                            }
                        }
                        catch (Exception exp)
                        {
                            // If token cannot be acquired using a cert, try the next one
                            exceptionDictionary[cert.Thumbprint] = exp.Message;
                        }
                    }
                }
            }
            finally
            {
                if (certs != null)
                {
                    foreach (var cert in certs)
                    {
#if net452
                        cert.Reset();
#else
                        cert.Dispose();
#endif
                    }
                }
            }

            // Could not acquire access token, throw exception
            string message = $"Tried {certs.Count} certificate(s). {AzureServiceTokenProviderException.GenericErrorMessage}";

            // Include exception details for each cert that was tried
            int count = 1;
            foreach (string thumbprint in exceptionDictionary.Keys)
            {
                message += Environment.NewLine +
                           $"Exception for cert #{count} with thumbprint {thumbprint}: {exceptionDictionary[thumbprint]}";
                count++;
            }

            throw new AzureServiceTokenProviderException(ConnectionString, resource, authority, message);
        }

    }
}
