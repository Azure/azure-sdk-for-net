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
    public sealed class EnvironmentConnectionStringCredential : TokenCredential
    {
        private const string UnavailableErrorMessage = "EnvironmentConnectionStringCredential authentication unavailable. Environment variable 'AzureServicesAuthConnectionString' is null or empty.";
        private const string MissingPartErrorMessage = "Environment variable 'AzureServicesAuthConnectionString' doesn't contain part '{0}'.";
        private const string CertificateNotFoundErrorMessage = "Certificate specified om environment variable 'AzureServicesAuthConnectionString' was not found.";

        private readonly bool _validOnly;

        public EnvironmentConnectionStringCredential()
            : this(true)
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
            return GetTokenImplAsync(false, requestContext, cancellationToken).GetAwaiter().GetResult(); // TODO: use EnsureCompleted();
        }

        private async ValueTask<AccessToken> GetTokenImplAsync(bool async, TokenRequestContext requestContext, CancellationToken cancellationToken)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("EnvironmentConnectionStringCredential.GetToken", requestContext);

            try
            {
                // TODO: add to EnvironmentVariables
                var connectionString = Environment.GetEnvironmentVariable("AzureServicesAuthConnectionString");
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
