// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;

namespace Azure.Identity
{
    /// <summary>
    /// Enables authentication to Azure Active Directory using a client certificate,
    /// details configured in the environment variable <c>AzureServicesAuthConnectionString</c>
    /// that is a semicolon-separated list of the following key-vault pairs:
    /// <list type="table">
    /// <listheader><term>Key</term><description>Description</description></listheader>
    /// <item><term>TenantId</term><description>Azure Active Directory tenant (directory) Id of the service principal.</description></item>
    /// <item><term>AppId</term><description>The client (application) ID of the service principal.</description></item>
    /// <item><term>CertificateThumbprint</term><description>The client certificate thumbprint.</description></item>
    /// <item><term>CertificateStoreLocation</term><description>The client certificate store location.</description></item>
    /// </list>
    /// This credential ultimately uses a <see cref="ClientCertificateCredential"/> to perform the authentication using these details.
    /// Please consult the documentation of that class for more details.
    /// </summary>
    public class EnvironmentConnectionStringCredential : TokenCredential
    {
        private const string UnavailableErrorMessage = "EnvironmentConnectionStringCredential authentication unavailable. Environment variable 'AzureServicesAuthConnectionString' is null or empty.";
        private const string MissingPartErrorMessage = "Environment variable 'AzureServicesAuthConnectionString' doesn't contain part '{0}'.";
        private const string CertificateNotFoundErrorMessage = "Certificate specified om environment variable 'AzureServicesAuthConnectionString' was not found.";

        private readonly bool _validOnly;

        public EnvironmentConnectionStringCredential()
            : this(validOnly: true)
        {
        }

        public EnvironmentConnectionStringCredential(bool validOnly)
        {
            _validOnly = validOnly;
        }

        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return await GetTokenImplAsync(true, requestContext, cancellationToken).ConfigureAwait(false);
        }

        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            return GetTokenImplAsync(false, requestContext, cancellationToken).EnsureCompleted();
        }

        private async ValueTask<AccessToken> GetTokenImplAsync(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("EnvironmentConnectionStringCredential.GetToken", requestContext);

            try
            {
                var connectionString = EnvironmentVariables.AzureServicesAuthConnectionString;
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new CredentialUnavailableException(UnavailableErrorMessage);
                }

                var connectionStringDict = connectionString.Split(';', StringSplitOptions.RemoveEmptyEntries)
                                                           .Select(part => part.Split('=', StringSplitOptions.RemoveEmptyEntries))
                                                           .ToDictionary(pair => pair[0], pair => pair[1], StringComparer.OrdinalIgnoreCase);

                string tenantId = GetConnectionStringPart(connectionStringDict, "TenantId");
                string clientId = GetConnectionStringPart(connectionStringDict, "AppId");
                string certThumbprint = GetConnectionStringPart(connectionStringDict, "CertificateThumbprint");
                StoreLocation certStoreLocation = Enum.Parse<StoreLocation>(GetConnectionStringPart(connectionStringDict, "CertificateStoreLocation"), ignoreCase: true);
                X509Certificate2 cert = LoadCertificate(certStoreLocation, certThumbprint) ?? throw new CredentialUnavailableException(CertificateNotFoundErrorMessage);

                ClientCertificateCredential credential = new ClientCertificateCredential(tenantId, clientId, cert);

                AccessToken token = async ?
                                        await credential.GetTokenAsync(requestContext, cancellationToken).ConfigureAwait(false) :
                                        credential.GetToken(requestContext, cancellationToken);

                return scope.Succeeded(token);
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }

        private static string GetConnectionStringPart(Dictionary<string, string> dict, string name)
        {
            if (!dict.TryGetValue(name, out string value))
            {
                throw new CredentialUnavailableException(string.Format(MissingPartErrorMessage, name));
            }
            return value;
        }

        private X509Certificate2 LoadCertificate(StoreLocation storeLocation, string thumbprint)
        {
            using var store = new X509Store(StoreName.My, storeLocation);
            store.Open(OpenFlags.ReadOnly);

            return store.Certificates
                        .Find(X509FindType.FindByThumbprint, thumbprint, _validOnly)
                        .OfType<X509Certificate2>()
                        .OrderByDescending(cert => cert.NotBefore)
                        .FirstOrDefault();
        }
    }
}
