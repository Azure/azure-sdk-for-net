// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Security.CodeTransparency
{
    [CodeGenSuppress("CreateEntry", typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("CreateEntryAsync", typeof(RequestContent), typeof(RequestContext))]
    public partial class CodeTransparencyClient
    {
        /// <summary>
        /// Initializes a new instance of CodeTransparencyClient. The client will download its own
        /// TLS CA cert to perform server cert authentication.
        /// If the CA changes then there is a TTL which will help healing the long lived clients.
        /// </summary>
        /// <param name="endpoint"> The <see cref="Uri"/> to use. </param>
        /// <param name="credential"> A JWT based credential used to authenticate to the Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public CodeTransparencyClient(Uri endpoint, AzureKeyCredential credential, CodeTransparencyClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new CodeTransparencyClientOptions();
            string name = endpoint.Host.Split('.')[0];
            CodeTransparencyCertificateClient certificateClient = options.CreateCertificateClient();
            HttpPipelineTransportOptions transportOptions = CreateTlsCertAndTrustVerifier(name, certificateClient);

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(
                options,
                Array.Empty<HttpPipelinePolicy>(),
                _keyCredential == null ?
                    Array.Empty<HttpPipelinePolicy>() :
                    new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader, AuthorizationApiKeyPrefix) },
                transportOptions,
                new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary>
        /// Creates the transport option which will pull a custom TLS CA for the verification purposes.
        /// The CA is hosted in the confidential ledger identity service which in turn gets populated
        /// with the cert when the CCF enclave application boots.
        /// The client is expected to cache the CA cert as the verification will try to get this cert
        /// on each invocation.
        /// </summary>
        /// <param name="serviceName">which service to use to pull the cert from</param>
        /// <param name="certificateClient">identity service client to use for getting the CA cert</param>
        private static HttpPipelineTransportOptions CreateTlsCertAndTrustVerifier(string serviceName, CodeTransparencyCertificateClient certificateClient)
        {
            Argument.AssertNotNullOrEmpty(serviceName, nameof(serviceName));
            Argument.AssertNotNull(certificateClient, nameof(certificateClient));

            X509Chain certificateChain = new();
            // Revocation is not required by CCF. Hence revocation checks must be skipped to avoid validation failing unnecessarily.
            certificateChain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;

            // AllowUnknownCertificateAuthority will NOT allow validation of all unknown self-signed certificates.
            // It extends trust to the ExtraStore, which in this case contains the trusted ledger identity TLS certificate.
            // This makes it possible for validation of certificate chains terminating in the ledger identity TLS certificate to pass.
            // Note: .NET 5 introduced `CustomTrustStore` but we cannot use that here as we must support older versions of .NET.
            certificateChain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllowUnknownCertificateAuthority;
            certificateChain.ChainPolicy.VerificationTime = DateTime.Now;

            // Define a validation function to ensure that certificates presented to the client only pass validation if
            // they are trusted by the ledger identity TLS certificate.
            // will yield AuthenticationException if cert is invalid
            bool CertValidationCheck(X509Certificate2 cert)
            {
                // Pull the TLS cert or get it from the cache
                ServiceIdentityResult identity = certificateClient.GetServiceIdentity(serviceName);
                X509Certificate2 identityServiceCert = identity.GetCertificate();

                // Add the ledger identity TLS certificate to the ExtraStore.
                X509Certificate2Collection existingCerts = certificateChain.ChainPolicy.ExtraStore;
                if (!existingCerts.Contains(identityServiceCert))
                {
                    certificateChain.ChainPolicy.ExtraStore.Clear();
                    certificateChain.ChainPolicy.ExtraStore.Add(identityServiceCert);
                }
                // Validate the presented certificate chain, using the ChainPolicy defined above.
                // Note: this check will allow certificates signed by standard CAs as well as those signed by the ledger identity TLS certificate.
                bool isChainValid = certificateChain.Build(cert);
                if (!isChainValid)
                    return false;

                // Ensure that the presented certificate chain passes validation only if it is rooted in the the ledger identity TLS certificate.
                X509Certificate2 rootCert = certificateChain.ChainElements[certificateChain.ChainElements.Count - 1].Certificate;
                bool isChainRootedInTheTlsCert = rootCert.Thumbprint.Equals(identityServiceCert.Thumbprint);
                return isChainRootedInTheTlsCert;
            }

            return new HttpPipelineTransportOptions { ServerCertificateCustomValidationCallback = args => CertValidationCheck(args.Certificate) };
        }

        /// <summary> Post an entry to be registered on the CodeTransparency instance. The returned operation will have the entry id when it is complete. </summary>
        /// <param name="body"> A raw CoseSign1 signature. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public virtual Operation<GetOperationResult> CreateEntry(BinaryData body, CancellationToken cancellationToken = default)
        {
            using RequestContent content = body ?? throw new ArgumentNullException(nameof(body));
            RequestContext context = FromCancellationToken(cancellationToken);
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("CodeTransparencyClient.CreateEntry");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateEntryRequest(content, context);
                Response response = _pipeline.ProcessMessage(message, context, cancellationToken);
                CreateEntryResult result = Response.FromValue(CreateEntryResult.FromResponse(response), response);
                return new CreateEntryOperation(this, result.OperationId);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Post an entry to be registered on the CodeTransparency instance. The returned operation will have the entry id when it is complete. </summary>
        /// <param name="body"> A raw CoseSign1 signature. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="body"/> is null. </exception>
        public virtual async Task<Operation<GetOperationResult>> CreateEntryAsync(BinaryData body, CancellationToken cancellationToken = default)
        {
            using RequestContent content = body ?? throw new ArgumentNullException(nameof(body));
            RequestContext context = FromCancellationToken(cancellationToken);
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("CodeTransparencyClient.CreateEntryAsync");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateEntryRequest(content, context);
                Response response = await _pipeline.ProcessMessageAsync(message, context, cancellationToken).ConfigureAwait(false);
                CreateEntryResult result = Response.FromValue(CreateEntryResult.FromResponse(response), response);
                return new CreateEntryOperation(this, result.OperationId);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateCreateEntryRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/entries", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("content-type", "application/cose");
            request.Content = content;
            return message;
        }
    }
}
