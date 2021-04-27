// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Identity
{
    /// <summary>
    /// Enables authentication of a service principal in to Azure Active Directory using a X509 certificate that is assigned to it's App Registration. More information
    /// on how to configure certificate authentication can be found here:
    /// https://docs.microsoft.com/en-us/azure/active-directory/develop/active-directory-certificate-credentials#register-your-certificate-with-azure-ad
    /// </summary>
    public class ClientCertificateCredential : TokenCredential
    {
        /// <summary>
        /// Gets the Azure Active Directory tenant (directory) Id of the service principal
        /// </summary>
        internal string TenantId { get; }

        /// <summary>
        /// Gets the client (application) ID of the service principal
        /// </summary>
        internal string ClientId { get; }

        internal IX509Certificate2Provider ClientCertificateProvider { get; }

        private readonly MsalConfidentialClient _client;
        private readonly CredentialPipeline _pipeline;

        /// <summary>
        /// Protected constructor for mocking.
        /// </summary>
        protected ClientCertificateCredential()
        {
        }

        /// <summary>
        /// Creates an instance of the ClientCertificateCredential with the details needed to authenticate against Azure Active Directory with the specified certificate.
        /// </summary>
        /// <param name="tenantId">The Azure Active Directory tenant (directory) Id of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="clientCertificatePath">The path to a file which contains both the client certificate and private key.</param>
        public ClientCertificateCredential(string tenantId, string clientId, string clientCertificatePath)
            : this(tenantId, clientId, clientCertificatePath, null, null, null)
        {
        }

        /// <summary>
        /// Creates an instance of the ClientCertificateCredential with the details needed to authenticate against Azure Active Directory with the specified certificate.
        /// </summary>
        /// <param name="tenantId">The Azure Active Directory tenant (directory) Id of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="clientCertificatePath">The path to a file which contains both the client certificate and private key.</param>
        /// <param name="options">Options that allow to configure the management of the requests sent to the Azure Active Directory service.</param>
        public ClientCertificateCredential(string tenantId, string clientId, string clientCertificatePath, TokenCredentialOptions options)
            : this(tenantId, clientId, clientCertificatePath, options, null, null)
        {
        }

        /// <summary>
        /// Creates an instance of the ClientCertificateCredential with the details needed to authenticate against Azure Active Directory with the specified certificate.
        /// </summary>
        /// <param name="tenantId">The Azure Active Directory tenant (directory) Id of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="clientCertificatePath">The path to a file which contains both the client certificate and private key.</param>
        /// <param name="options">Options that allow to configure the management of the requests sent to the Azure Active Directory service.</param>
        public ClientCertificateCredential(string tenantId, string clientId, string clientCertificatePath, ClientCertificateCredentialOptions options)
            : this(tenantId, clientId, clientCertificatePath, options, null, null)
        { }

        /// <summary>
        /// Creates an instance of the ClientCertificateCredential with the details needed to authenticate against Azure Active Directory with the specified certificate.
        /// </summary>
        /// <param name="tenantId">The Azure Active Directory tenant (directory) Id of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="clientCertificate">The authentication X509 Certificate of the service principal</param>
        public ClientCertificateCredential(string tenantId, string clientId, X509Certificate2 clientCertificate)
            : this(tenantId, clientId, clientCertificate, null, null, null)
        {
        }

        /// <summary>
        /// Creates an instance of the ClientCertificateCredential with the details needed to authenticate against Azure Active Directory with the specified certificate.
        /// </summary>
        /// <param name="tenantId">The Azure Active Directory tenant (directory) Id of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="clientCertificate">The authentication X509 Certificate of the service principal</param>
        /// <param name="options">Options that allow to configure the management of the requests sent to the Azure Active Directory service.</param>
        public ClientCertificateCredential(string tenantId, string clientId, X509Certificate2 clientCertificate, TokenCredentialOptions options)
            : this(tenantId, clientId, clientCertificate, options, null, null) {}

        /// <summary>
        /// Creates an instance of the ClientCertificateCredential with the details needed to authenticate against Azure Active Directory with the specified certificate.
        /// </summary>
        /// <param name="tenantId">The Azure Active Directory tenant (directory) Id of the service principal.</param>
        /// <param name="clientId">The client (application) ID of the service principal</param>
        /// <param name="clientCertificate">The authentication X509 Certificate of the service principal</param>
        /// <param name="options">Options that allow to configure the management of the requests sent to the Azure Active Directory service.</param>
        public ClientCertificateCredential(string tenantId, string clientId, X509Certificate2 clientCertificate, ClientCertificateCredentialOptions options)
            : this(tenantId, clientId, clientCertificate, options, null, null)
        {
        }

        internal ClientCertificateCredential(string tenantId, string clientId, string certificatePath, TokenCredentialOptions options, CredentialPipeline pipeline, MsalConfidentialClient client)
            : this(tenantId, clientId, new X509Certificate2FromFileProvider(certificatePath ?? throw new ArgumentNullException(nameof(certificatePath))), options, pipeline, client)
        {
        }

        internal ClientCertificateCredential(string tenantId, string clientId, X509Certificate2 certificate, TokenCredentialOptions options, CredentialPipeline pipeline, MsalConfidentialClient client)
            : this(tenantId, clientId, new X509Certificate2FromObjectProvider(certificate ?? throw new ArgumentNullException(nameof(certificate))), options, pipeline, client)
        {
        }

        internal ClientCertificateCredential(string tenantId, string clientId, IX509Certificate2Provider certificateProvider, TokenCredentialOptions options, CredentialPipeline pipeline, MsalConfidentialClient client)
        {
            TenantId = Validations.ValidateTenantId(tenantId, nameof(tenantId));

            ClientId = clientId ?? throw new ArgumentNullException(nameof(clientId));

            ClientCertificateProvider = certificateProvider;

            _pipeline = pipeline ?? CredentialPipeline.GetInstance(options);

            _client = client ?? new MsalConfidentialClient(_pipeline, tenantId, clientId, certificateProvider, (options as ClientCertificateCredentialOptions)?.SendCertificateChain ?? false, options as ITokenCacheOptions);
        }

        /// <summary>
        /// Obtains a token from the Azure Active Directory service, using the specified X509 certificate to authenticate. This method is called automatically by Azure SDK client libraries. You may call this method directly, but you must also handle token caching and token refreshing.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("ClientCertificateCredential.GetToken", requestContext);

            try
            {
                AuthenticationResult result = _client.AcquireTokenForClientAsync(requestContext.Scopes, false, cancellationToken).EnsureCompleted();

                return scope.Succeeded(new AccessToken(result.AccessToken, result.ExpiresOn));
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }

        /// <summary>
        /// Obtains a token from the Azure Active Directory service, using the specified X509 certificate to authenticate. This method is called automatically by Azure SDK client libraries. You may call this method directly, but you must also handle token caching and token refreshing.
        /// </summary>
        /// <param name="requestContext">The details of the authentication request.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="AccessToken"/> which can be used to authenticate service client calls.</returns>
        public override async ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken = default)
        {
            using CredentialDiagnosticScope scope = _pipeline.StartGetTokenScope("ClientCertificateCredential.GetToken", requestContext);

            try
            {
                AuthenticationResult result = await _client.AcquireTokenForClientAsync(requestContext.Scopes, true, cancellationToken).ConfigureAwait(false);

                return scope.Succeeded(new AccessToken(result.AccessToken, result.ExpiresOn));
            }
            catch (Exception e)
            {
                throw scope.FailWrapAndThrow(e);
            }
        }

        /// <summary>
        /// IX509Certificate2Provider provides a way to control how the X509Certificate2 object is fetched.
        /// </summary>
        internal interface IX509Certificate2Provider
        {
            ValueTask<X509Certificate2> GetCertificateAsync(bool async, CancellationToken cancellationToken);
        }

        /// <summary>
        /// X509Certificate2FromObjectProvider provides an X509Certificate2 from an existing instance.
        /// </summary>
        private class X509Certificate2FromObjectProvider : IX509Certificate2Provider
        {
            private X509Certificate2 Certificate { get; }

            public X509Certificate2FromObjectProvider(X509Certificate2 clientCertificate)
            {
                Certificate = clientCertificate ?? throw new ArgumentNullException(nameof(clientCertificate));
            }

            public ValueTask<X509Certificate2> GetCertificateAsync(bool async, CancellationToken cancellationToken)
            {
                return new ValueTask<X509Certificate2>(Certificate);
            }
        }

        /// <summary>
        /// X509Certificate2FromFileProvider provides an X509Certificate2 from a file on disk.  It supports both
        /// "pfx" and "pem" encoded certificates.
        /// </summary>
        internal class X509Certificate2FromFileProvider : IX509Certificate2Provider
        {
            // Lazy initialized on the first call to GetCertificateAsync, based on CertificatePath.
            private X509Certificate2 Certificate { get; set; }
            internal string CertificatePath { get; }

            public X509Certificate2FromFileProvider(string clientCertificatePath)
            {
                CertificatePath = clientCertificatePath ?? throw new ArgumentNullException(nameof(clientCertificatePath));
            }

            public ValueTask<X509Certificate2> GetCertificateAsync(bool async, CancellationToken cancellationToken)
            {
                if (!(Certificate is null))
                {
                    return new ValueTask<X509Certificate2>(Certificate);
                }

                string fileType = Path.GetExtension(CertificatePath);

                switch (fileType.ToLowerInvariant())
                {
                    case ".pfx":
                        return LoadCertificateFromPfxFileAsync(async, CertificatePath, cancellationToken);
                    case ".pem":
                        return LoadCertificateFromPemFileAsync(async, CertificatePath, cancellationToken);
                    default:
                        throw new CredentialUnavailableException("Only .pfx and .pem files are supported.");
                }
            }

            private async ValueTask<X509Certificate2> LoadCertificateFromPfxFileAsync(bool async, string clientCertificatePath, CancellationToken cancellationToken)
            {
                const int BufferSize = 4 * 1024;

                if (!(Certificate is null))
                {
                    return Certificate;
                }

                try
                {
                    if (!async)
                    {
                        Certificate = new X509Certificate2(clientCertificatePath);
                    }
                    else
                    {
                        List<byte> certContents = new List<byte>();
                        byte[] buf = new byte[BufferSize];
                        int offset = 0;
                        using (Stream s = File.OpenRead(clientCertificatePath))
                        {
                            while (true)
                            {
                                int read = await s.ReadAsync(buf, offset, buf.Length, cancellationToken).ConfigureAwait(false);
                                for (int i = 0; i < read; i++)
                                {
                                    certContents.Add(buf[i]);
                                }

                                if (read == 0)
                                {
                                    break;
                                }
                            }
                        }

                        Certificate = new X509Certificate2(certContents.ToArray());
                    }

                    return Certificate;
                }
                catch (Exception e) when (!(e is OperationCanceledException))
                {
                    throw new CredentialUnavailableException("Could not load certificate file", e);
                }
            }

            private async ValueTask<X509Certificate2> LoadCertificateFromPemFileAsync(bool async, string clientCertificatePath, CancellationToken cancellationToken)
            {
                if (!(Certificate is null))
                {
                    return Certificate;
                }

                string certficateText;

                try
                {
                    if (!async)
                    {
                        certficateText = File.ReadAllText(clientCertificatePath);
                    }
                    else
                    {
                        cancellationToken.ThrowIfCancellationRequested();

                        using (StreamReader sr = new StreamReader(clientCertificatePath))
                        {
                            certficateText = await sr.ReadToEndAsync().ConfigureAwait(false);
                        }
                    }

                    Certificate = PemReader.LoadCertificate(certficateText.AsSpan(), keyType: PemReader.KeyType.RSA);

                    return Certificate;
                }
                catch (Exception e) when (!(e is OperationCanceledException))
                {
                    throw new CredentialUnavailableException("Could not load certificate file", e);
                }
            }

            private delegate void ImportPkcs8PrivateKeyDelegate(ReadOnlySpan<byte> blob, out int bytesRead);
        }
    }
}
