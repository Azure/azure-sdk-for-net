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

namespace Azure.Identity.Tests.samples
{
    public class CertificateCredentialSnippets
    {
        public void CreateWithPath()
        {
            string tenantId = "00000000-0000-0000-0000-00000000";
            string clientId = "00000000-0000-0000-0000-00000000";

            #region Snippet:Identity_CertificateCredenetial_CreateWithPath
            var credential = new ClientCertificateCredential(tenantId, clientId, "./certs/cert.pfx");
            #endregion
        }

        public void CreateWithX509Certificate2()
        {
            string tenantId = "00000000-0000-0000-0000-00000000";
            string clientId = "00000000-0000-0000-0000-00000000";

            #region Snippet:Identity_CertificateCredenetial_CreateWithX509Cert
#if NET9_0_OR_GREATER
            var certificate = X509CertificateLoader.LoadPkcs12FromFile("./certs/cert-password-protected.pfx", "password");
#else
            var certificate = new X509Certificate2("./certs/cert-password-protected.pfx", "password");
#endif

            var credential = new ClientCertificateCredential(tenantId, clientId, certificate);
            #endregion
        }

        public void CreateFromStore()
        {
            string tenantId = "00000000-0000-0000-0000-00000000";
            string clientId = "00000000-0000-0000-0000-00000000";
            string thumbprint = "";
            #region Snippet:Identity_CertificateCredenetial_CreateFromStore
            using var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);

            store.Open(OpenFlags.ReadOnly);

            var certificate = store.Certificates.Cast<X509Certificate2>().FirstOrDefault(cert => cert.Thumbprint == thumbprint);

            var credential = new ClientCertificateCredential(tenantId, clientId, certificate);
            #endregion
        }

        #region Snippet:Identity_CertificateCredenetial_RotatableCredential
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

        #region Snippet:Identity_CertificateCredenetial_RotatingCredential
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
