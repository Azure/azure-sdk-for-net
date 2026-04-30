// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;

using Azure.Identity;
namespace Azure.Core.Tests.Identity.samples
{
    public class CertificateCredentialSnippets
    {
        public void CreateWithPath_File()
        {
            string tenantId = "00000000-0000-0000-0000-00000000";
            string clientId = "00000000-0000-0000-0000-00000000";

            #region Snippet:Identity_CertificateCredential_CreateWithPath_File
            var credential = new ClientCertificateCredential(tenantId, clientId, "./certs/cert.pfx");
            #endregion
        }

        public void CreateWithPath_Store()
        {
            string tenantId = "00000000-0000-0000-0000-00000000";
            string clientId = "00000000-0000-0000-0000-00000000";

            #region Snippet:Identity_CertificateCredential_CreateWithPath_Store
            var credential = new ClientCertificateCredential(tenantId, clientId, "cert:/CurrentUser/My/E661583E8FABEF4C0BEF694CBC41C28FB81CD870");
            #endregion
        }

        public void CreateWithStorePath()
        {
            string tenantId = "00000000-0000-0000-0000-00000000";
            string clientId = "00000000-0000-0000-0000-00000000";

            #region Snippet:Identity_CertificateCredential_CreateWithStorePath
            // Load a certificate from the platform certificate store (Windows Certificate Store or macOS Keychain)
            // by specifying the path in the format: cert:/StoreLocation/StoreName/Thumbprint
            // Windows-style backslash separators `\` are also accepted
            var credential = new ClientCertificateCredential(
                tenantId,
                clientId,
                "cert:/CurrentUser/My/E661583E8FABEF4C0BEF694CBC41C28FB81CD870");
            #endregion
        }

        public void CreateWithX509Certificate2()
        {
            string tenantId = "00000000-0000-0000-0000-00000000";
            string clientId = "00000000-0000-0000-0000-00000000";

            #region Snippet:Identity_CertificateCredential_CreateWithX509Cert
#if NET9_0_OR_GREATER
            var certificate = X509CertificateLoader.LoadPkcs12FromFile("./certs/cert-password-protected.pfx", "password");
#else
            var certificate = new X509Certificate2("./certs/cert-password-protected.pfx", "password");
#endif

            var credential = new ClientCertificateCredential(tenantId, clientId, certificate);
            #endregion
        }

        public sealed class CertificateNotFoundException(string message) : Exception(message) { }

        public void CreateFromStore()
        {
            string tenantId = "00000000-0000-0000-0000-00000000";
            string clientId = "00000000-0000-0000-0000-00000000";
            string friendlyName = "";

            #region Snippet:Identity_CertificateCredential_CreateFromStore
            using var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);

            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

            var certificate = store.Certificates
                .OfType<X509Certificate2>()
                .Where(static cert => DateTime.UtcNow > cert.NotBefore && DateTime.UtcNow < cert.NotAfter)
                .OrderByDescending(static cert => cert.NotAfter)
                .FirstOrDefault(cert => cert.FriendlyName == friendlyName)
                ?? throw new CertificateNotFoundException($"Valid certificate with friendly name '{friendlyName}' could not be found in the local machine personal certificate store");

            var credential = new ClientCertificateCredential(tenantId, clientId, certificate);
            #endregion
        }

        #region Snippet:Identity_CertificateCredential_RotatableCredential
        public class RotatableCertificateCredential : TokenCredential
        {
            private readonly string _tenantId;
            private readonly string _clientId;
            private ClientCertificateCredential _credential;

            public RotatableCertificateCredential(string tenantId, string clientId, X509Certificate2 certificate)
            {
                _tenantId = tenantId;
                _clientId = clientId;
                _credential = new ClientCertificateCredential(_tenantId, _clientId, certificate);
            }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return _credential.GetToken(requestContext, cancellationToken);
            }

            public async override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                return await _credential.GetTokenAsync(requestContext, cancellationToken);
            }

            public void RotateCertificate(X509Certificate2 certificate)
            {
                _credential = new ClientCertificateCredential(_tenantId, _clientId, certificate);
            }
        }
        #endregion

        #region Snippet:Identity_CertificateCredential_RotatingCredential
        public class RotatingCertificateCredential : TokenCredential
        {
            private readonly string _tenantId;
            private readonly string _clientId;
            private readonly string _path;
            private readonly object _refreshLock = new object();
            private DateTimeOffset _credentialLastModified;
            private ClientCertificateCredential _credential;

            public RotatingCertificateCredential(string tenantId, string clientId, string path)
            {
                _tenantId = tenantId;
                _clientId = clientId;
                _path = path;

                RefreshCertificate();
            }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                RefreshCertificate();

                return _credential.GetToken(requestContext, cancellationToken);
            }

            public async override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                RefreshCertificate();

                return await _credential.GetTokenAsync(requestContext, cancellationToken);
            }

            public void RefreshCertificate()
            {
                lock (_refreshLock)
                {
                    var certificateLastModified = File.GetLastWriteTimeUtc(_path);

                    if (_credentialLastModified < certificateLastModified)
                    {
#if NET9_0_OR_GREATER
                        var certificate = X509CertificateLoader.LoadCertificateFromFile(_path);
#else
                        var certificate = new X509Certificate2(_path);
#endif
                        _credential = new ClientCertificateCredential(_tenantId, _clientId, certificate);

                        _credentialLastModified = certificateLastModified;
                    }
                }
            }
        }
        #endregion
    }
}
