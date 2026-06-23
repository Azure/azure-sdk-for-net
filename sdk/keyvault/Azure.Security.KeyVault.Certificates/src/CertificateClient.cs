// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// The CertificateClient provides synchronous and asynchronous methods to manage <see cref="KeyVaultCertificate"/>s in Azure Key Vault. The client
    /// supports creating, retrieving, updating, deleting, purging, backing up, restoring, and listing the <see cref="KeyVaultCertificate"/>, along with managing
    /// certificate <see cref="CertificateIssuer"/>s and <see cref="CertificateContact"/>s. The client also supports listing <see cref="DeletedCertificate"/> for a soft delete
    /// enabled key vault.
    /// </summary>
    /// <remarks>
    /// Internally, all transport - request building, response parsing, paging, model
    /// (de)serialization, and LRO polling - is delegated to the TypeSpec-generated
    /// <c>KeyVaultCertificatesClient</c> (internal). Public method signatures, return
    /// types, exception contracts and recorded HTTP traffic match every previously
    /// shipped 4.x version of this package, so adopting this build is a no-op for
    /// existing consumers. The legacy hand-written transport layer
    /// (KeyVaultPipeline.SendRequest&lt;T&gt;) is retained only for DownloadCertificate
    /// because that API hits the Secrets endpoint, not the Certificates endpoint.
    /// </remarks>
    public class CertificateClient
    {
        internal const string CertificatesPath = "/certificates/";
        private const string CallerShouldAuditReason = "https://aka.ms/azsdk/callershouldaudit/security-keyvault-certificates";
        private const string OTelCertificateNameKey = "az.keyvault.certificate.name";
        private const string OTelCertificateVersionKey = "az.keyvault.certificate.version";
        private const string OTelCertificateIssuerNameKey = "az.keyvault.certificate.issuer.name";

        // The generated client owns all transport for the Certificates endpoint.
        private readonly KeyVaultCertificatesClient _generated;
        private readonly ClientDiagnostics _diagnostics;
        private readonly Uri _vaultUri;

        // The hand-written pipeline is preserved purely for DownloadCertificate,
        // which fetches the managed secret behind the certificate from the Secrets
        // endpoint (not the Certificates endpoint). Keeping the existing transport
        // here preserves byte-identical wire behavior for that API while Phase 3
        // decides whether to route Download through a SecretClient instead.
        private readonly KeyVaultPipeline _pipeline;

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificateClient"/> class for mocking.
        /// </summary>
        protected CertificateClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificateClient"/> class for the specified vault.
        /// </summary>
        /// <param name="vaultUri">
        /// A <see cref="Uri"/> to the vault on which the client operates. Appears as "DNS Name" in the Azure portal.
        /// If you have a certificate <see cref="Uri"/>, use <see cref="KeyVaultCertificateIdentifier"/> to parse the <see cref="KeyVaultCertificateIdentifier.VaultUri"/> and other information.
        /// You should validate that this URI references a valid Key Vault resource. See <see href="https://aka.ms/azsdk/blog/vault-uri"/> for details.
        /// </param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to authenticate requests to the vault, such as DefaultAzureCredential.</param>
        /// <exception cref="ArgumentNullException"><paramref name="vaultUri"/> or <paramref name="credential"/> is null.</exception>
        public CertificateClient(Uri vaultUri, TokenCredential credential)
            : this(vaultUri, credential, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificateClient"/> class for the specified vault.
        /// </summary>
        /// <param name="vaultUri">
        /// A <see cref="Uri"/> to the vault on which the client operates. Appears as "DNS Name" in the Azure portal.
        /// If you have a certificate <see cref="Uri"/>, use <see cref="KeyVaultCertificateIdentifier"/> to parse the <see cref="KeyVaultCertificateIdentifier.VaultUri"/> and other information.
        /// You should validate that this URI references a valid Key Vault resource. See <see href="https://aka.ms/azsdk/blog/vault-uri"/> for details.
        /// </param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to authenticate requests to the vault, such as DefaultAzureCredential.</param>
        /// <param name="options"><see cref="CertificateClientOptions"/> that allow to configure the management of the request sent to Key Vault.</param>
        /// <exception cref="ArgumentNullException"><paramref name="vaultUri"/> or <paramref name="credential"/> is null.</exception>
        public CertificateClient(Uri vaultUri, TokenCredential credential, CertificateClientOptions options)
        {
            Argument.AssertNotNull(vaultUri, nameof(vaultUri));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new CertificateClientOptions();

            _vaultUri = vaultUri;
            _diagnostics = new ClientDiagnostics(options);

            // Build the HttpPipeline directly from the customer's CertificateClientOptions
            // (which extends ClientOptions). This is the same construction path the
            // legacy hand-written CertificateClient used, so all of AddPolicy entries
            // (per-call + per-retry), custom RetryPolicy / RetryOptions, Transport,
            // Diagnostics.LoggedHeaderNames + LoggedQueryParameters and ApplicationId
            // flow through automatically. No field-by-field copy is needed - future
            // additions to ClientOptions are picked up for free.
            var authPolicy = new ChallengeBasedAuthenticationPolicy(credential, options.DisableChallengeResourceVerification);
            HttpPipeline pipeline = HttpPipelineBuilder.Build(options, authPolicy);

            _generated = new KeyVaultCertificatesClient(vaultUri, MapApiVersion(options.Version), pipeline, _diagnostics);

            // Reuse the same HttpPipeline (and api-version) for the legacy KeyVaultPipeline
            // wrapper that DownloadCertificate still depends on - so DownloadCertificate's
            // wire shape is byte-identical to prior releases.
            _pipeline = new KeyVaultPipeline(vaultUri, options.GetVersionString(), pipeline, _diagnostics);
        }

        /// <summary>
        /// Gets the <see cref="Uri"/> of the vault used to create this instance of the <see cref="CertificateClient"/>.
        /// </summary>
        public virtual Uri VaultUri => _vaultUri;

        #region StartCreateCertificate

        /// <summary>
        /// Starts a long running operation to create a <see cref="KeyVaultCertificate"/> in the vault with the specified certificate policy.
        /// </summary>
        /// <remarks>
        /// If no certificate with the specified name exists it will be created; otherwise, a new version of the existing certificate will be created.
        /// This operation requires the certificates/create permission.
        /// </remarks>
        /// <param name="certificateName">The name of the certificate to create.</param>
        /// <param name="policy">The <see cref="CertificatePolicy"/> which governs the properties and lifecycle of the created certificate.</param>
        /// <param name="enabled">Specifies whether the certificate should be created in an enabled state. If null, the server default will be used.</param>
        /// <param name="tags">Tags to be applied to the created certificate.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="CertificateOperation"/> which contains details on the create operation, and can be used to retrieve updated status.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> or <paramref name="policy"/> is null.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual CertificateOperation StartCreateCertificate(string certificateName, CertificatePolicy policy, bool? enabled, IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            return StartCreateCertificate(certificateName, policy, enabled, tags, preserveCertificateOrder: null, cancellationToken);
        }

        /// <summary>
        /// Starts a long running operation to create a <see cref="KeyVaultCertificate"/> in the vault with the specified certificate policy.
        /// </summary>
        /// <remarks>
        /// If no certificate with the specified name exists it will be created; otherwise, a new version of the existing certificate will be created.
        /// This operation requires the certificates/create permission.
        /// </remarks>
        /// <param name="certificateName">The name of the certificate to create.</param>
        /// <param name="policy">The <see cref="CertificatePolicy"/> which governs the properties and lifecycle of the created certificate.</param>
        /// <param name="enabled">Specifies whether the certificate should be created in an enabled state. If null, the server default will be used.</param>
        /// <param name="tags">Tags to be applied to the created certificate.</param>
        /// <param name="preserveCertificateOrder">Specifies whether the certificate chain preserves its original order. The default value is false, which sets the leaf certificate at index 0.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="CertificateOperation"/> which contains details on the create operation, and can be used to retrieve updated status.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> or <paramref name="policy"/> is null.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        public virtual CertificateOperation StartCreateCertificate(string certificateName, CertificatePolicy policy, bool? enabled = default, IDictionary<string, string> tags = default, bool? preserveCertificateOrder = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));
            Argument.AssertNotNull(policy, nameof(policy));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(StartCreateCertificate)}");
            scope.AddAttribute(OTelCertificateNameKey, certificateName);
            scope.Start();

            try
            {
                using RequestContent content = CertificateMapper.ToRequestContent(new CertificateCreateParameters(policy, enabled, tags, preserveCertificateOrder));
                Response raw = _generated.CreateCertificate(certificateName, content, new RequestContext { CancellationToken = cancellationToken });
                var properties = CertificateMapper.Deserialize(raw, () => new CertificateOperationProperties());
                return new CertificateOperation(Response.FromValue(properties, raw), this);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Starts a long running operation to create a <see cref="KeyVaultCertificate"/> in the vault with the specified certificate policy.
        /// </summary>
        /// <remarks>
        /// If no certificate with the specified name exists it will be created; otherwise, a new version of the existing certificate will be created.
        /// This operation requires the certificates/create permission.
        /// </remarks>
        /// <param name="certificateName">The name of the certificate to create.</param>
        /// <param name="policy">The <see cref="CertificatePolicy"/> which governs the properties and lifecycle of the created certificate.</param>
        /// <param name="enabled">Specifies whether the certificate should be created in an enabled state. If null, the server default will be used.</param>
        /// <param name="tags">Tags to be applied to the created certificate.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="CertificateOperation"/> which contains details on the create operation, and can be used to retrieve updated status.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> or <paramref name="policy"/> is null.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<CertificateOperation> StartCreateCertificateAsync(string certificateName, CertificatePolicy policy, bool? enabled, IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            return await StartCreateCertificateAsync(certificateName, policy, enabled, tags, preserveCertificateOrder: null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Starts a long running operation to create a <see cref="KeyVaultCertificate"/> in the vault with the specified certificate policy.
        /// </summary>
        /// <remarks>
        /// If no certificate with the specified name exists it will be created; otherwise, a new version of the existing certificate will be created.
        /// This operation requires the certificates/create permission.
        /// </remarks>
        /// <param name="certificateName">The name of the certificate to create.</param>
        /// <param name="policy">The <see cref="CertificatePolicy"/> which governs the properties and lifecycle of the created certificate.</param>
        /// <param name="enabled">Specifies whether the certificate should be created in an enabled state. If null, the server default will be used.</param>
        /// <param name="tags">Tags to be applied to the created certificate.</param>
        /// <param name="preserveCertificateOrder">Specifies whether the certificate chain preserves its original order. The default value is false, which sets the leaf certificate at index 0.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="CertificateOperation"/> which contains details on the create operation, and can be used to retrieve updated status.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> or <paramref name="policy"/> is null.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        public virtual async Task<CertificateOperation> StartCreateCertificateAsync(string certificateName, CertificatePolicy policy, bool? enabled = default, IDictionary<string, string> tags = default, bool? preserveCertificateOrder = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));
            Argument.AssertNotNull(policy, nameof(policy));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(StartCreateCertificate)}");
            scope.AddAttribute(OTelCertificateNameKey, certificateName);
            scope.Start();

            try
            {
                using RequestContent content = CertificateMapper.ToRequestContent(new CertificateCreateParameters(policy, enabled, tags, preserveCertificateOrder));
                Response raw = await _generated.CreateCertificateAsync(certificateName, content, new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);
                var properties = CertificateMapper.Deserialize(raw, () => new CertificateOperationProperties());
                return new CertificateOperation(Response.FromValue(properties, raw), this);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion

        #region DownloadCertificate
        // DownloadCertificate intentionally retains the legacy KeyVaultPipeline-based
        // transport. The API pulls the PFX/PEM out of the backing managed secret via the
        // Secrets endpoint (not the Certificates endpoint that _generated targets), so
        // routing it through _generated would not actually exercise that endpoint.
        // Behavior, diagnostic scope name, OTel attributes, and the on-the-wire request
        // shape are preserved exactly as shipped in prior 4.x releases.

#pragma warning disable AZC0015 // Unexpected client method return type.
#pragma warning disable AZC0002 // Client method should have an optional CancellationToken.
        /// <summary>
        /// Creates an <see cref="X509Certificate2"/> from the specified certificate.
        /// </summary>
        /// <remarks>
        /// Because <see cref="KeyVaultCertificate.Cer"/> contains only the public key, this method attempts to download the managed secret
        /// that contains the full certificate. If you do not have permissions to get the secret,
        /// <see cref="RequestFailedException"/> will be thrown with an appropriate error response.
        /// If you want an <see cref="X509Certificate2"/> with only the public key, instantiate it passing only the
        /// <see cref="KeyVaultCertificate.Cer"/> property.
        /// This operation requires the certificates/get and secrets/get permissions.
        /// </remarks>
        /// <param name="certificateName">The name of the certificate to download.</param>
        /// <param name="version">Optional version of a certificate to download.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="X509Certificate2"/> from the specified certificate.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> is null.</exception>
        /// <exception cref="InvalidDataException">The managed secret did not contain a certificate.</exception>
        /// <exception cref="NotSupportedException">The <see cref="CertificateContentType"/> is not supported.</exception>
        /// <exception cref="PlatformNotSupportedException">Cannot create an <see cref="X509Certificate2"/> on this platform.</exception>
        /// <exception cref="RequestFailedException">The request failed. See <see cref="RequestFailedException.ErrorCode"/> and the exception message for details.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<X509Certificate2> DownloadCertificate(string certificateName, string version, CancellationToken cancellationToken) =>
            DownloadCertificate(new DownloadCertificateOptions(certificateName) { Version = version }, cancellationToken);
#pragma warning restore AZC0002

        /// <summary>
        /// Creates an <see cref="X509Certificate2"/> from the specified certificate.
        /// </summary>
        /// <remarks>
        /// Because <see cref="KeyVaultCertificate.Cer"/> contains only the public key, this method attempts to download the managed secret
        /// that contains the full certificate. If you do not have permissions to get the secret,
        /// <see cref="RequestFailedException"/> will be thrown with an appropriate error response.
        /// If you want an <see cref="X509Certificate2"/> with only the public key, instantiate it passing only the
        /// <see cref="KeyVaultCertificate.Cer"/> property.
        /// This operation requires the certificates/get and secrets/get permissions.
        /// </remarks>
        /// <param name="certificateName">The name of the certificate to download.</param>
        /// <param name="version">(Optional) The version of a certificate to download.</param>
        /// <param name="outContentType"> The certificate content type in which the certificate will be downloaded. If a supported format is specified,
        /// the certificate content is converted to the requested format. Currently, only PFX to PEM conversion is supported.
        /// If an unsupported format is specified, the request is rejected. If not specified, the certificate is returned in its original
        /// format without conversion.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="X509Certificate2"/> from the specified certificate.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> is null.</exception>
        /// <exception cref="InvalidDataException">The managed secret did not contain a certificate.</exception>
        /// <exception cref="NotSupportedException">The <see cref="CertificateContentType"/> is not supported.</exception>
        /// <exception cref="PlatformNotSupportedException">Cannot create an <see cref="X509Certificate2"/> on this platform.</exception>
        /// <exception cref="RequestFailedException">The request failed. See <see cref="RequestFailedException.ErrorCode"/> and the exception message for details.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        public virtual Response<X509Certificate2> DownloadCertificate(string certificateName, string version = null, CertificateContentType? outContentType = null, CancellationToken cancellationToken = default) =>
            DownloadCertificate(new DownloadCertificateOptions(certificateName) { Version = version, OutContentType = outContentType }, cancellationToken);

        /// <summary>
        /// Creates an <see cref="X509Certificate2"/> from the specified certificate.
        /// </summary>
        /// <remarks>
        /// Because <see cref="KeyVaultCertificate.Cer"/> contains only the public key, this method attempts to download the managed secret
        /// that contains the full certificate. If you do not have permissions to get the secret,
        /// <see cref="RequestFailedException"/> will be thrown with an appropriate error response.
        /// If you want an <see cref="X509Certificate2"/> with only the public key, instantiate it passing only the
        /// <see cref="KeyVaultCertificate.Cer"/> property.
        /// This operation requires the certificates/get and secrets/get permissions.
        /// </remarks>
        /// <param name="options">Options for downloading and creating an <see cref="X509Certificate2"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="X509Certificate2"/> from the specified certificate.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        /// <exception cref="InvalidDataException">The managed secret did not contain a certificate.</exception>
        /// <exception cref="NotSupportedException">The <see cref="CertificateContentType"/> is not supported.</exception>
        /// <exception cref="PlatformNotSupportedException">Cannot create an <see cref="X509Certificate2"/> on this platform.</exception>
        /// <exception cref="RequestFailedException">The request failed. See <see cref="RequestFailedException.ErrorCode"/> and the exception message for details.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        public virtual Response<X509Certificate2> DownloadCertificate(DownloadCertificateOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(DownloadCertificate)}");
            scope.AddAttribute(OTelCertificateNameKey, options.CertificateName);
            scope.AddAttribute(OTelCertificateVersionKey, options.Version);
            scope.Start();

            try
            {
                // First call uses _pipeline (legacy KeyVaultPipeline) by design,
                // not oversight: the GET /certificates/{name}/ shape recorded in
                // existing cassettes (always-trailing-slash) differs from the
                // shape _generated.GetCertificate emits (no trailing slash when
                // version is null). Switching the first call to _generated would
                // require re-recording every DownloadCertificate live test. The
                // second call (managed-secret fetch) legitimately belongs on
                // _pipeline because it hits the /secrets/ endpoint and uses an
                // outContentType query the generated client does not expose for
                // this path.
                KeyVaultCertificateWithPolicy certificate = _pipeline.SendRequest(RequestMethod.Get, () => new KeyVaultCertificateWithPolicy(), cancellationToken, CertificatesPath, options.CertificateName, "/", options.Version);
                Response<KeyVaultSecret> secretResponse;
                if (options.OutContentType != null)
                {
                    var requestUri = _pipeline.CreateUriWithQueryParams(certificate.SecretId, ("outContentType", options.OutContentType.ToString()));
                    secretResponse = _pipeline.SendRequest(RequestMethod.Get, () => new KeyVaultSecret(), requestUri, appendApiVersion: false, cancellationToken);
                }
                else
                {
                    secretResponse = _pipeline.SendRequest(RequestMethod.Get, () => new KeyVaultSecret(), certificate.SecretId, appendApiVersion: true, cancellationToken);
                }

                KeyVaultSecret secret = secretResponse.Value;
                string value = secret.Value;

                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidDataException($"Secret {certificate.SecretId} contains no value");
                }

                if (secret.ContentType is null || secret.ContentType == CertificateContentType.Pkcs12)
                {
                    byte[] rawData = Convert.FromBase64String(value);

                    X509Certificate2 x509;
#if NET9_0_OR_GREATER
                    x509 = X509CertificateLoader.LoadPkcs12(rawData, (string)null, options.KeyStorageFlags);
#else
                    x509 = new(rawData, (string)null, options.KeyStorageFlags);
#endif
                    return Response.FromValue(x509, secretResponse.GetRawResponse());
                }
                else if (secret.ContentType == CertificateContentType.Pem)
                {
                    X509Certificate2 x509 = PemReader.LoadCertificate(value.AsSpan(), certificate.Cer, allowCertificateOnly: true, keyStorageFlags: options.KeyStorageFlags);
                    return Response.FromValue(x509, secretResponse.GetRawResponse());
                }

                throw new NotSupportedException($"Content type {secret.ContentType} not supported");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

#pragma warning disable AZC0002 // Client method should have an optional CancellationToken.
        /// <summary>
        /// Creates an <see cref="X509Certificate2"/> from the specified certificate.
        /// </summary>
        /// <remarks>
        /// Because <see cref="KeyVaultCertificate.Cer"/> contains only the public key, this method attempts to download the managed secret
        /// that contains the full certificate. If you do not have permissions to get the secret,
        /// <see cref="RequestFailedException"/> will be thrown with an appropriate error response.
        /// If you want an <see cref="X509Certificate2"/> with only the public key, instantiate it passing only the
        /// <see cref="KeyVaultCertificate.Cer"/> property.
        /// This operation requires the certificates/get and secrets/get permissions.
        /// </remarks>
        /// <param name="certificateName">The name of the certificate to download.</param>
        /// <param name="version">Optional version of a certificate to download.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="X509Certificate2"/> from the specified certificate.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> is null.</exception>
        /// <exception cref="InvalidDataException">The managed secret did not contain a certificate.</exception>
        /// <exception cref="NotSupportedException">The <see cref="CertificateContentType"/> is not supported.</exception>
        /// <exception cref="PlatformNotSupportedException">Cannot create an <see cref="X509Certificate2"/> on this platform.</exception>
        /// <exception cref="RequestFailedException">The request failed. See <see cref="RequestFailedException.ErrorCode"/> and the exception message for details.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<X509Certificate2>> DownloadCertificateAsync(string certificateName, string version, CancellationToken cancellationToken) =>
            await DownloadCertificateAsync(new DownloadCertificateOptions(certificateName) { Version = version }, cancellationToken).ConfigureAwait(false);
#pragma warning restore AZC0002

        /// <summary>
        /// Creates an <see cref="X509Certificate2"/> from the specified certificate.
        /// </summary>
        /// <remarks>
        /// Because <see cref="KeyVaultCertificate.Cer"/> contains only the public key, this method attempts to download the managed secret
        /// that contains the full certificate. If you do not have permissions to get the secret,
        /// <see cref="RequestFailedException"/> will be thrown with an appropriate error response.
        /// If you want an <see cref="X509Certificate2"/> with only the public key, instantiate it passing only the
        /// <see cref="KeyVaultCertificate.Cer"/> property.
        /// This operation requires the certificates/get and secrets/get permissions.
        /// </remarks>
        /// <param name="certificateName">The name of the certificate to download.</param>
        /// <param name="version">Optional version of a certificate to download.</param>
        /// <param name="outContentType"> The certificate content type in which the certificate will be downloaded. If a supported format is specified,
        /// the certificate content is converted to the requested format. Currently, only PFX to PEM conversion is supported.
        /// If an unsupported format is specified, the request is rejected. If not specified, the certificate is returned in its original
        /// format without conversion.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="X509Certificate2"/> from the specified certificate.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> is null.</exception>
        /// <exception cref="InvalidDataException">The managed secret did not contain a certificate.</exception>
        /// <exception cref="NotSupportedException">The <see cref="CertificateContentType"/> is not supported.</exception>
        /// <exception cref="PlatformNotSupportedException">Cannot create an <see cref="X509Certificate2"/> on this platform.</exception>
        /// <exception cref="RequestFailedException">The request failed. See <see cref="RequestFailedException.ErrorCode"/> and the exception message for details.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        public virtual async Task<Response<X509Certificate2>> DownloadCertificateAsync(string certificateName, string version = null, CertificateContentType? outContentType = null, CancellationToken cancellationToken = default) =>
            await DownloadCertificateAsync(new DownloadCertificateOptions(certificateName) { Version = version, OutContentType = outContentType }, cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Creates an <see cref="X509Certificate2"/> from the specified certificate.
        /// </summary>
        /// <remarks>
        /// Because <see cref="KeyVaultCertificate.Cer"/> contains only the public key, this method attempts to download the managed secret
        /// that contains the full certificate. If you do not have permissions to get the secret,
        /// <see cref="RequestFailedException"/> will be thrown with an appropriate error response.
        /// If you want an <see cref="X509Certificate2"/> with only the public key, instantiate it passing only the
        /// <see cref="KeyVaultCertificate.Cer"/> property.
        /// This operation requires the certificates/get and secrets/get permissions.
        /// </remarks>
        /// <param name="options">Additional options for downloading and creating an <see cref="X509Certificate2"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="X509Certificate2"/> from the specified certificate.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="options"/> is null.</exception>
        /// <exception cref="InvalidDataException">The managed secret did not contain a certificate.</exception>
        /// <exception cref="NotSupportedException">The <see cref="CertificateContentType"/> is not supported.</exception>
        /// <exception cref="PlatformNotSupportedException">Cannot create an <see cref="X509Certificate2"/> on this platform.</exception>
        /// <exception cref="RequestFailedException">The request failed. See <see cref="RequestFailedException.ErrorCode"/> and the exception message for details.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        public virtual async Task<Response<X509Certificate2>> DownloadCertificateAsync(DownloadCertificateOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(DownloadCertificate)}");
            scope.AddAttribute(OTelCertificateNameKey, options.CertificateName);
            scope.AddAttribute(OTelCertificateVersionKey, options.Version);
            scope.Start();

            try
            {
                // First call uses _pipeline (legacy KeyVaultPipeline) by design,
                // not oversight: see DownloadCertificate (sync) for the full
                // explanation. Switching to _generated would require re-recording
                // every DownloadCertificate live test.
                KeyVaultCertificateWithPolicy certificate = await _pipeline.SendRequestAsync(RequestMethod.Get, () => new KeyVaultCertificateWithPolicy(), cancellationToken, CertificatesPath, options.CertificateName, "/", options.Version).ConfigureAwait(false);
                Response<KeyVaultSecret> secretResponse;
                if (options.OutContentType != null)
                {
                    var requestUri = _pipeline.CreateUriWithQueryParams(certificate.SecretId, ("outContentType", options.OutContentType.ToString()));
                    secretResponse = await _pipeline.SendRequestAsync(RequestMethod.Get, () => new KeyVaultSecret(), requestUri, appendApiVersion: false, cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    secretResponse = await _pipeline.SendRequestAsync(RequestMethod.Get, () => new KeyVaultSecret(), certificate.SecretId, appendApiVersion: true, cancellationToken).ConfigureAwait(false);
                }

                KeyVaultSecret secret = secretResponse.Value;
                string value = secret.Value;

                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidDataException($"Secret {certificate.SecretId} contains no value");
                }

                if (secret.ContentType is null || secret.ContentType == CertificateContentType.Pkcs12)
                {
                    byte[] rawData = Convert.FromBase64String(value);

                    X509Certificate2 x509;
#if NET9_0_OR_GREATER
                    x509 = X509CertificateLoader.LoadPkcs12(rawData, (string)null, options.KeyStorageFlags);
#else
                    x509 = new(rawData, (string)null, options.KeyStorageFlags);
#endif
                    return Response.FromValue(x509, secretResponse.GetRawResponse());
                }
                else if (secret.ContentType == CertificateContentType.Pem)
                {
                    X509Certificate2 x509 = PemReader.LoadCertificate(value.AsSpan(), certificate.Cer, allowCertificateOnly: true, keyStorageFlags: options.KeyStorageFlags);
                    return Response.FromValue(x509, secretResponse.GetRawResponse());
                }

                throw new NotSupportedException($"Content type {secret.ContentType} not supported");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
#pragma warning restore AZC0015 // Unexpected client method return type.

        #endregion

        #region GetCertificate / GetCertificateVersion / UpdateCertificateProperties

        /// <summary>
        /// Returns the latest version of the <see cref="KeyVaultCertificate"/> along with its <see cref="CertificatePolicy"/>. This operation requires the certificates/get permission.
        /// </summary>
        /// <param name="certificateName">The name of the <see cref="KeyVaultCertificate"/> to retrieve.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the certificate and policy as a <see cref="KeyVaultCertificateWithPolicy"/> instance.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> is null.</exception>
        public virtual Response<KeyVaultCertificateWithPolicy> GetCertificate(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(GetCertificate)}");
            scope.AddAttribute(OTelCertificateNameKey, certificateName);
            scope.Start();
            try
            {
                Response raw = _generated.GetCertificate(certificateName, certificateVersion: null, context: new RequestContext { CancellationToken = cancellationToken });
                return Response.FromValue(CertificateMapper.Deserialize(raw, () => new KeyVaultCertificateWithPolicy()), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Returns the latest version of the <see cref="KeyVaultCertificate"/> along with its <see cref="CertificatePolicy"/>. This operation requires the certificates/get permission.
        /// </summary>
        /// <param name="certificateName">The name of the <see cref="KeyVaultCertificate"/> to retrieve.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the certificate and policy as a <see cref="KeyVaultCertificateWithPolicy"/> instance.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> is null.</exception>
        public virtual async Task<Response<KeyVaultCertificateWithPolicy>> GetCertificateAsync(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(GetCertificate)}");
            scope.AddAttribute(OTelCertificateNameKey, certificateName);
            scope.Start();
            try
            {
                Response raw = await _generated.GetCertificateAsync(certificateName, certificateVersion: null, context: new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);
                return Response.FromValue(CertificateMapper.Deserialize(raw, () => new KeyVaultCertificateWithPolicy()), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Gets a specific version of the <see cref="KeyVaultCertificate"/>. This operation requires the certificates/get permission.
        /// </summary>
        /// <param name="certificateName">The name of the <see cref="KeyVaultCertificate"/> to retrieve.</param>
        /// <param name="version">The version of the <see cref="KeyVaultCertificate"/> to retrieve.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The requested <see cref="KeyVaultCertificate"/>.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> is null.</exception>
        public virtual Response<KeyVaultCertificate> GetCertificateVersion(string certificateName, string version, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));
            Argument.AssertNotNullOrEmpty(version, nameof(version));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(GetCertificateVersion)}");
            scope.AddAttribute(OTelCertificateNameKey, certificateName);
            scope.AddAttribute(OTelCertificateVersionKey, version);
            scope.Start();
            try
            {
                Response raw = _generated.GetCertificate(certificateName, version, new RequestContext { CancellationToken = cancellationToken });
                return Response.FromValue(CertificateMapper.Deserialize(raw, () => new KeyVaultCertificate()), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Gets a specific version of the <see cref="KeyVaultCertificate"/>. This operation requires the certificates/get permission.
        /// </summary>
        /// <param name="certificateName">The name of the <see cref="KeyVaultCertificate"/> to retrieve.</param>
        /// <param name="version">The version of the <see cref="KeyVaultCertificate"/> to retrieve.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The requested <see cref="KeyVaultCertificate"/>.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> is null.</exception>
        public virtual async Task<Response<KeyVaultCertificate>> GetCertificateVersionAsync(string certificateName, string version, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));
            Argument.AssertNotNullOrEmpty(version, nameof(version));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(GetCertificateVersion)}");
            scope.AddAttribute(OTelCertificateNameKey, certificateName);
            scope.AddAttribute(OTelCertificateVersionKey, version);
            scope.Start();
            try
            {
                Response raw = await _generated.GetCertificateAsync(certificateName, version, new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);
                return Response.FromValue(CertificateMapper.Deserialize(raw, () => new KeyVaultCertificate()), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Updates the specified <see cref="KeyVaultCertificate"/> with the specified values for its mutable properties. This operation requires the certificates/update permission.
        /// </summary>
        /// <param name="properties">The <see cref="CertificateProperties"/> object with updated properties.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The updated <see cref="KeyVaultCertificate"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="properties"/> is null.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        public virtual Response<KeyVaultCertificate> UpdateCertificateProperties(CertificateProperties properties, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(properties, nameof(properties));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(UpdateCertificateProperties)}");
            scope.AddAttribute(OTelCertificateNameKey, properties.Name);
            scope.AddAttribute(OTelCertificateVersionKey, properties.Version);
            scope.Start();
            try
            {
                using RequestContent content = CertificateMapper.WriteUpdateBody(properties);
                Response raw = _generated.UpdateCertificate(properties.Name, content, properties.Version, new RequestContext { CancellationToken = cancellationToken });
                return Response.FromValue(CertificateMapper.Deserialize(raw, () => new KeyVaultCertificate()), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Updates the specified <see cref="KeyVaultCertificate"/> with the specified values for its mutable properties. This operation requires the certificates/update permission.
        /// </summary>
        /// <param name="properties">The <see cref="CertificateProperties"/> object with updated properties.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The updated <see cref="KeyVaultCertificate"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="properties"/> is null.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        public virtual async Task<Response<KeyVaultCertificate>> UpdateCertificatePropertiesAsync(CertificateProperties properties, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(properties, nameof(properties));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(UpdateCertificateProperties)}");
            scope.AddAttribute(OTelCertificateNameKey, properties.Name);
            scope.AddAttribute(OTelCertificateVersionKey, properties.Version);
            scope.Start();
            try
            {
                using RequestContent content = CertificateMapper.WriteUpdateBody(properties);
                Response raw = await _generated.UpdateCertificateAsync(properties.Name, content, properties.Version, new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);
                return Response.FromValue(CertificateMapper.Deserialize(raw, () => new KeyVaultCertificate()), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        #endregion

        #region Delete / Recover / Purge / Backup / Restore / Import

        /// <summary>
        /// Deletes all versions of the specified <see cref="KeyVaultCertificate"/>. If the vault is soft delete-enabled, the <see cref="KeyVaultCertificate"/> will be marked for permanent deletion
        /// and can be recovered with <see cref="StartRecoverDeletedCertificate"/>, or purged with <see cref="PurgeDeletedCertificate"/>. This operation requires the certificates/delete permission.
        /// </summary>
        /// <param name="certificateName">The name of the <see cref="KeyVaultCertificate"/> to delete.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Certificates.DeleteCertificateOperation"/> to wait on this long-running operation.
        /// If the Key Vault is soft delete-enabled, you only need to wait for the operation to complete if you need to recover or purge the certificate;
        /// otherwise, the certificate is deleted automatically on the <see cref="DeletedCertificate.ScheduledPurgeDate"/>.
        /// </returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> is null.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        public virtual DeleteCertificateOperation StartDeleteCertificate(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(StartDeleteCertificate)}");
            scope.AddAttribute(OTelCertificateNameKey, certificateName);
            scope.Start();
            try
            {
                Response raw = _generated.DeleteCertificate(certificateName, new RequestContext { CancellationToken = cancellationToken });
                DeletedCertificate deleted = CertificateMapper.Deserialize(raw, () => new DeletedCertificate());
                return new DeleteCertificateOperation(_generated, _diagnostics, Response.FromValue(deleted, raw));
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Deletes all versions of the specified <see cref="KeyVaultCertificate"/>. If the vault is soft delete-enabled, the <see cref="KeyVaultCertificate"/> will be marked for permanent deletion
        /// and can be recovered with <see cref="StartRecoverDeletedCertificate"/>, or purged with <see cref="PurgeDeletedCertificate"/>. This operation requires the certificates/delete permission.
        /// </summary>
        /// <param name="certificateName">The name of the <see cref="KeyVaultCertificate"/> to delete.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>
        /// A <see cref="Certificates.DeleteCertificateOperation"/> to wait on this long-running operation.
        /// If the Key Vault is soft delete-enabled, you only need to wait for the operation to complete if you need to recover or purge the certificate;
        /// otherwise, the certificate is deleted automatically on the <see cref="DeletedCertificate.ScheduledPurgeDate"/>.
        /// </returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> is null.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        public virtual async Task<DeleteCertificateOperation> StartDeleteCertificateAsync(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(StartDeleteCertificate)}");
            scope.AddAttribute(OTelCertificateNameKey, certificateName);
            scope.Start();
            try
            {
                Response raw = await _generated.DeleteCertificateAsync(certificateName, new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);
                DeletedCertificate deleted = CertificateMapper.Deserialize(raw, () => new DeletedCertificate());
                return new DeleteCertificateOperation(_generated, _diagnostics, Response.FromValue(deleted, raw));
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Retrieves information about the specified deleted <see cref="KeyVaultCertificate"/>. This operation is only applicable in vaults enabled for soft delete, and
        /// requires the certificates/get permission.
        /// </summary>
        /// <param name="certificateName">The name of the <see cref="DeletedCertificate"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The details of the <see cref="DeletedCertificate"/>.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> is null.</exception>
        public virtual Response<DeletedCertificate> GetDeletedCertificate(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(GetDeletedCertificate)}");
            scope.AddAttribute(OTelCertificateNameKey, certificateName);
            scope.Start();
            try
            {
                Response raw = _generated.GetDeletedCertificate(certificateName, new RequestContext { CancellationToken = cancellationToken });
                return Response.FromValue(CertificateMapper.Deserialize(raw, () => new DeletedCertificate()), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Retrieves information about the specified deleted <see cref="KeyVaultCertificate"/>. This operation is only applicable in vaults enabled for soft delete, and
        /// requires the certificates/get permission.
        /// </summary>
        /// <param name="certificateName">The name of the <see cref="DeletedCertificate"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The details of the <see cref="DeletedCertificate"/>.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> is null.</exception>
        public virtual async Task<Response<DeletedCertificate>> GetDeletedCertificateAsync(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(GetDeletedCertificate)}");
            scope.AddAttribute(OTelCertificateNameKey, certificateName);
            scope.Start();
            try
            {
                Response raw = await _generated.GetDeletedCertificateAsync(certificateName, new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);
                return Response.FromValue(CertificateMapper.Deserialize(raw, () => new DeletedCertificate()), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Recovers the <see cref="DeletedCertificate"/> to its pre-deleted state. This operation is only applicable in vaults enabled for soft delete, and
        /// requires the certificates/recover permission.
        /// </summary>
        /// <param name="certificateName">The name of the <see cref="DeletedCertificate"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecoverDeletedCertificateOperation"/> to wait on this long-running operation.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> is null.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        public virtual RecoverDeletedCertificateOperation StartRecoverDeletedCertificate(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(StartRecoverDeletedCertificate)}");
            scope.AddAttribute(OTelCertificateNameKey, certificateName);
            scope.Start();
            try
            {
                Response raw = _generated.RecoverDeletedCertificate(certificateName, new RequestContext { CancellationToken = cancellationToken });
                KeyVaultCertificateWithPolicy recovered = CertificateMapper.Deserialize(raw, () => new KeyVaultCertificateWithPolicy());
                return new RecoverDeletedCertificateOperation(_generated, _diagnostics, Response.FromValue(recovered, raw));
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Recovers the <see cref="DeletedCertificate"/> to its pre-deleted state. This operation is only applicable in vaults enabled for soft delete, and
        /// requires the certificates/recover permission.
        /// </summary>
        /// <param name="certificateName">The name of the <see cref="DeletedCertificate"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="RecoverDeletedCertificateOperation"/> to wait on this long-running operation.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> is null.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        public virtual async Task<RecoverDeletedCertificateOperation> StartRecoverDeletedCertificateAsync(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(StartRecoverDeletedCertificate)}");
            scope.AddAttribute(OTelCertificateNameKey, certificateName);
            scope.Start();
            try
            {
                Response raw = await _generated.RecoverDeletedCertificateAsync(certificateName, new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);
                KeyVaultCertificateWithPolicy recovered = CertificateMapper.Deserialize(raw, () => new KeyVaultCertificateWithPolicy());
                return new RecoverDeletedCertificateOperation(_generated, _diagnostics, Response.FromValue(recovered, raw));
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Permanently and irreversibly deletes the specified deleted certificate, without the possibility of recovery. This operation is only applicable in vaults enabled for soft delete, and
        /// requires the certificates/purge permission. The operation is not available if the DeletedCertificate.RecoveryLevel of the DeletedCertificate does not specify 'Purgeable'.
        /// </summary>
        /// <param name="certificateName">The name of the <see cref="DeletedCertificate"/> to permanently delete.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The HTTP response from the service.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> is null.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        public virtual Response PurgeDeletedCertificate(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(PurgeDeletedCertificate)}");
            scope.AddAttribute(OTelCertificateNameKey, certificateName);
            scope.Start();
            try { return _generated.PurgeDeletedCertificate(certificateName, new RequestContext { CancellationToken = cancellationToken }); }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Permanently and irreversibly deletes the specified deleted certificate, without the possibility of recovery. This operation is only applicable in vaults enabled for soft delete, and
        /// requires the certificates/purge permission. The operation is not available if the DeletedCertificate.RecoveryLevel of the DeletedCertificate does not specify 'Purgeable'.
        /// </summary>
        /// <param name="certificateName">The name of the <see cref="DeletedCertificate"/> to permanently delete.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The HTTP response from the service.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> is null.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        public virtual async Task<Response> PurgeDeletedCertificateAsync(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(PurgeDeletedCertificate)}");
            scope.AddAttribute(OTelCertificateNameKey, certificateName);
            scope.Start();
            try { return await _generated.PurgeDeletedCertificateAsync(certificateName, new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false); }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Creates a backup of the certificate, including all versions, which can be used to restore the certificate to the state at the time of the backup in the case the certificate is deleted, or to
        /// restore the certificate to a different vault in the same region as the original value. This operation requires the certificate/backup permission.
        /// </summary>
        /// <param name="certificateName">The name of the <see cref="KeyVaultCertificate"/> to backup.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The certificate backup.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> is null.</exception>
        public virtual Response<byte[]> BackupCertificate(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(BackupCertificate)}");
            scope.AddAttribute(OTelCertificateNameKey, certificateName);
            scope.Start();
            try
            {
                Response raw = _generated.BackupCertificate(certificateName, new RequestContext { CancellationToken = cancellationToken });
                return CertificateMapper.ToBackupResponse(raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Creates a backup of the certificate, including all versions, which can be used to restore the certificate to the state at the time of the backup in the case the certificate is deleted, or to
        /// restore the certificate to a different vault in the same region as the original value. This operation requires the certificate/backup permission.
        /// </summary>
        /// <param name="certificateName">The name of the <see cref="KeyVaultCertificate"/> to backup.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The certificate backup.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> is null.</exception>
        public virtual async Task<Response<byte[]>> BackupCertificateAsync(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(BackupCertificate)}");
            scope.AddAttribute(OTelCertificateNameKey, certificateName);
            scope.Start();
            try
            {
                Response raw = await _generated.BackupCertificateAsync(certificateName, new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);
                return CertificateMapper.ToBackupResponse(raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Restores a <see cref="KeyVaultCertificate"/>, including all versions, from a backup created from the <see cref="BackupCertificate"/> or <see cref="BackupCertificateAsync"/>. The backup must be restored
        /// to a vault in the same region as its original vault. This operation requires the certificate/restore permission.
        /// </summary>
        /// <param name="backup">The backup of the <see cref="KeyVaultCertificate"/> to restore.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The restored certificate and policy.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="backup"/> is null.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        public virtual Response<KeyVaultCertificateWithPolicy> RestoreCertificateBackup(byte[] backup, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(backup, nameof(backup));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(RestoreCertificateBackup)}");
            scope.Start();
            try
            {
                using RequestContent content = CertificateMapper.ToRequestContent(new CertificateBackup { Value = backup });
                Response raw = _generated.RestoreCertificate(content, new RequestContext { CancellationToken = cancellationToken });
                return Response.FromValue(CertificateMapper.Deserialize(raw, () => new KeyVaultCertificateWithPolicy()), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Restores a <see cref="KeyVaultCertificate"/>, including all versions, from a backup created from the <see cref="BackupCertificate"/> or <see cref="BackupCertificateAsync"/>. The backup must be restored
        /// to a vault in the same region as its original vault. This operation requires the certificate/restore permission.
        /// </summary>
        /// <param name="backup">The backup of the <see cref="KeyVaultCertificate"/> to restore.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The restored certificate and policy.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="backup"/> is null.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        public virtual async Task<Response<KeyVaultCertificateWithPolicy>> RestoreCertificateBackupAsync(byte[] backup, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(backup, nameof(backup));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(RestoreCertificateBackup)}");
            scope.Start();
            try
            {
                using RequestContent content = CertificateMapper.ToRequestContent(new CertificateBackup { Value = backup });
                Response raw = await _generated.RestoreCertificateAsync(content, new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);
                return Response.FromValue(CertificateMapper.Deserialize(raw, () => new KeyVaultCertificateWithPolicy()), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Imports a pre-existing certificate to the key vault. The specified certificate must be in PFX or ASCII PEM-format, and must contain the private key as well as the X.509 certificates. This operation requires the
        /// certificates/import permission.
        /// </summary>
        /// <param name="importCertificateOptions">The details of the certificate to import to the key vault.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The imported certificate and policy.</returns>
        /// <exception cref="ArgumentException"><see cref="ImportCertificateOptions.Name"/> of <paramref name="importCertificateOptions"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="importCertificateOptions"/> or <see cref="ImportCertificateOptions.Name"/> of <paramref name="importCertificateOptions"/> is null.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        public virtual Response<KeyVaultCertificateWithPolicy> ImportCertificate(ImportCertificateOptions importCertificateOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(importCertificateOptions, nameof(importCertificateOptions));
            Argument.AssertNotNullOrEmpty(importCertificateOptions.Name, nameof(importCertificateOptions.Name));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(ImportCertificate)}");
            scope.AddAttribute(OTelCertificateNameKey, importCertificateOptions.Name);
            scope.Start();
            try
            {
                using RequestContent content = CertificateMapper.ToRequestContent(importCertificateOptions);
                Response raw = _generated.ImportCertificate(importCertificateOptions.Name, content, new RequestContext { CancellationToken = cancellationToken });
                return Response.FromValue(CertificateMapper.Deserialize(raw, () => new KeyVaultCertificateWithPolicy()), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Imports a pre-existing certificate to the key vault. The specified certificate must be in PFX or ASCII PEM-format, and must contain the private key as well as the X.509 certificates. This operation requires the
        /// certificates/import permission.
        /// </summary>
        /// <param name="importCertificateOptions">The details of the certificate to import to the key vault.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The imported certificate and policy.</returns>
        /// <exception cref="ArgumentException"><see cref="ImportCertificateOptions.Name"/> of <paramref name="importCertificateOptions"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="importCertificateOptions"/> or <see cref="ImportCertificateOptions.Name"/> of <paramref name="importCertificateOptions"/> is null.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        public virtual async Task<Response<KeyVaultCertificateWithPolicy>> ImportCertificateAsync(ImportCertificateOptions importCertificateOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(importCertificateOptions, nameof(importCertificateOptions));
            Argument.AssertNotNullOrEmpty(importCertificateOptions.Name, nameof(importCertificateOptions.Name));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(ImportCertificate)}");
            scope.AddAttribute(OTelCertificateNameKey, importCertificateOptions.Name);
            scope.Start();
            try
            {
                using RequestContent content = CertificateMapper.ToRequestContent(importCertificateOptions);
                Response raw = await _generated.ImportCertificateAsync(importCertificateOptions.Name, content, new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);
                return Response.FromValue(CertificateMapper.Deserialize(raw, () => new KeyVaultCertificateWithPolicy()), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        #endregion

        #region Paging

        /// <summary>
        /// Lists the properties of all enabled and disabled certificates in the specified vault. You can use the returned <see cref="CertificateProperties.Name"/> in subsequent calls to <see cref="GetCertificate(string, CancellationToken)"/>.
        /// This operation requires the certificates/list permission.
        /// </summary>
        /// <param name="includePending">Specifies whether to include certificates in a pending state as well.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An enumerable collection of certificate metadata.</returns>
        [ForwardsClientCalls]
        public virtual Pageable<CertificateProperties> GetPropertiesOfCertificates(bool includePending = default, CancellationToken cancellationToken = default)
        {
            // Use the protocol pageable (Pageable<BinaryData>) so we deserialize each
            // certificate item with the hand-written CertificateProperties JSON reader -
            // guaranteeing identical wire-shape parsing to prior releases.
            var ctx = new RequestContext { CancellationToken = cancellationToken };
            Pageable<BinaryData> source = _generated.GetCertificates(maxresults: null, includePending: includePending, context: ctx);
            return MapPageable(source, b => CertificateMapper.DeserializeItem(b, () => new CertificateProperties()));
        }

        /// <summary>
        /// Lists the properties of all enabled and disabled certificates in the specified vault. You can use the returned <see cref="CertificateProperties.Name"/> in subsequent calls to <see cref="GetCertificate(string, CancellationToken)"/>.
        /// This operation requires the certificates/list permission.
        /// </summary>
        /// <param name="includePending">Specifies whether to include certificates in a pending state as well.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An enumerable collection of certificate metadata.</returns>
        [ForwardsClientCalls]
        public virtual AsyncPageable<CertificateProperties> GetPropertiesOfCertificatesAsync(bool includePending = default, CancellationToken cancellationToken = default)
        {
            var ctx = new RequestContext { CancellationToken = cancellationToken };
            AsyncPageable<BinaryData> source = _generated.GetCertificatesAsync(maxresults: null, includePending: includePending, context: ctx);
            return MapAsyncPageable(source, b => CertificateMapper.DeserializeItem(b, () => new CertificateProperties()));
        }

        /// <summary>
        /// Lists the properties of all enabled and disabled versions of the specified certificate in the specified vault. You can use the returned <see cref="CertificateProperties.Name"/> in subsequent calls to <see cref="GetCertificateVersion(string, string, CancellationToken)"/>.
        /// This operation requires the certificates/list permission.
        /// </summary>
        /// <param name="certificateName">The name of the certificate whose versions should be retrieved.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An enumerable collection of the certificate's versions.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> is null.</exception>
        [ForwardsClientCalls]
        public virtual Pageable<CertificateProperties> GetPropertiesOfCertificateVersions(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            var ctx = new RequestContext { CancellationToken = cancellationToken };
            Pageable<BinaryData> source = _generated.GetCertificateVersions(certificateName, maxresults: null, context: ctx);
            return MapPageable(source, b => CertificateMapper.DeserializeItem(b, () => new CertificateProperties()));
        }

        /// <summary>
        /// Lists the properties of all enabled and disabled versions of the specified certificate in the specified vault. You can use the returned <see cref="CertificateProperties.Name"/> in subsequent calls to <see cref="GetCertificateVersion(string, string, CancellationToken)"/>.
        /// This operation requires the certificates/list permission.
        /// </summary>
        /// <param name="certificateName">The name of the certificate whose versions should be retrieved.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An enumerable collection of the certificate's versions.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> is null.</exception>
        [ForwardsClientCalls]
        public virtual AsyncPageable<CertificateProperties> GetPropertiesOfCertificateVersionsAsync(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            var ctx = new RequestContext { CancellationToken = cancellationToken };
            AsyncPageable<BinaryData> source = _generated.GetCertificateVersionsAsync(certificateName, maxresults: null, context: ctx);
            return MapAsyncPageable(source, b => CertificateMapper.DeserializeItem(b, () => new CertificateProperties()));
        }

        /// <summary>
        /// Enumerates the deleted certificates in the vault. This operation is only available on soft delete-enabled vaults, and requires the certificates/list/get permissions.
        /// </summary>
        /// <param name="includePending">Specifies whether to include certificates in a delete pending state as well.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An enumerable collection of deleted certificates.</returns>
        [ForwardsClientCalls]
        public virtual Pageable<DeletedCertificate> GetDeletedCertificates(bool includePending = default, CancellationToken cancellationToken = default)
        {
            var ctx = new RequestContext { CancellationToken = cancellationToken };
            Pageable<BinaryData> source = _generated.GetDeletedCertificates(maxresults: null, includePending: includePending, context: ctx);
            return MapPageable(source, b => CertificateMapper.DeserializeItem(b, () => new DeletedCertificate()));
        }

        /// <summary>
        /// Enumerates the deleted certificates in the vault. This operation is only available on soft delete-enabled vaults, and requires the certificates/list/get permissions.
        /// </summary>
        /// <param name="includePending">Specifies whether to include certificates in a delete pending state as well.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An enumerable collection of deleted certificates.</returns>
        [ForwardsClientCalls]
        public virtual AsyncPageable<DeletedCertificate> GetDeletedCertificatesAsync(bool includePending = default, CancellationToken cancellationToken = default)
        {
            var ctx = new RequestContext { CancellationToken = cancellationToken };
            AsyncPageable<BinaryData> source = _generated.GetDeletedCertificatesAsync(maxresults: null, includePending: includePending, context: ctx);
            return MapAsyncPageable(source, b => CertificateMapper.DeserializeItem(b, () => new DeletedCertificate()));
        }

        #endregion

        #region CertificatePolicy

        /// <summary>
        /// Retrieves the <see cref="CertificatePolicy"/> of the specified certificate. This operation requires the certificate/get permission.
        /// </summary>
        /// <param name="certificateName">The name of the certificate whose policy should be retrieved.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="CertificatePolicy"/> of the specified certificate.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> is null.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        public virtual Response<CertificatePolicy> GetCertificatePolicy(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(GetCertificatePolicy)}");
            scope.AddAttribute(OTelCertificateNameKey, certificateName);
            scope.Start();
            try
            {
                Response raw = _generated.GetCertificatePolicy(certificateName, new RequestContext { CancellationToken = cancellationToken });
                return Response.FromValue(CertificateMapper.Deserialize(raw, () => new CertificatePolicy()), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Retrieves the <see cref="CertificatePolicy"/> of the specified certificate. This operation requires the certificate/get permission.
        /// </summary>
        /// <param name="certificateName">The name of the certificate whose policy should be retrieved.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="CertificatePolicy"/> of the specified certificate.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> is null.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        public virtual async Task<Response<CertificatePolicy>> GetCertificatePolicyAsync(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(GetCertificatePolicy)}");
            scope.AddAttribute(OTelCertificateNameKey, certificateName);
            scope.Start();
            try
            {
                Response raw = await _generated.GetCertificatePolicyAsync(certificateName, new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);
                return Response.FromValue(CertificateMapper.Deserialize(raw, () => new CertificatePolicy()), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Updates the <see cref="CertificatePolicy"/> of the specified certificate. This operation requires the certificate/update permission.
        /// </summary>
        /// <param name="certificateName">The name of the certificate whose policy should be updated.</param>
        /// <param name="policy">The updated policy for the specified certificate.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The updated certificate policy.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> is null.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        public virtual Response<CertificatePolicy> UpdateCertificatePolicy(string certificateName, CertificatePolicy policy, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));
            Argument.AssertNotNull(policy, nameof(policy));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(UpdateCertificatePolicy)}");
            scope.AddAttribute(OTelCertificateNameKey, certificateName);
            scope.Start();
            try
            {
                using RequestContent content = CertificateMapper.ToRequestContent(policy);
                Response raw = _generated.UpdateCertificatePolicy(certificateName, content, new RequestContext { CancellationToken = cancellationToken });
                return Response.FromValue(CertificateMapper.Deserialize(raw, () => new CertificatePolicy()), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Updates the <see cref="CertificatePolicy"/> of the specified certificate. This operation requires the certificate/update permission.
        /// </summary>
        /// <param name="certificateName">The name of the certificate whose policy should be updated.</param>
        /// <param name="policy">The updated policy for the specified certificate.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The updated certificate policy.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> is null.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        public virtual async Task<Response<CertificatePolicy>> UpdateCertificatePolicyAsync(string certificateName, CertificatePolicy policy, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));
            Argument.AssertNotNull(policy, nameof(policy));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(UpdateCertificatePolicy)}");
            scope.AddAttribute(OTelCertificateNameKey, certificateName);
            scope.Start();
            try
            {
                using RequestContent content = CertificateMapper.ToRequestContent(policy);
                Response raw = await _generated.UpdateCertificatePolicyAsync(certificateName, content, new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);
                return Response.FromValue(CertificateMapper.Deserialize(raw, () => new CertificatePolicy()), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        #endregion

        #region Issuers

        /// <summary>
        /// Creates or replaces a certificate <see cref="CertificateIssuer"/> in the key vault. This operation requires the certificates/setissuers permission.
        /// </summary>
        /// <param name="issuer">The <see cref="CertificateIssuer"/> to add or replace in the vault.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The created certificate issuer.</returns>
        /// <exception cref="ArgumentException"><see cref="CertificateIssuer.Name"/> of <paramref name="issuer"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="issuer"/> or <see cref="CertificateIssuer.Name"/> of <paramref name="issuer"/> is null.</exception>
        public virtual Response<CertificateIssuer> CreateIssuer(CertificateIssuer issuer, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(issuer, nameof(issuer));

            if (string.IsNullOrEmpty(issuer.Name))
            {
                throw new ArgumentException($"{nameof(issuer)}.{nameof(issuer.Name)} cannot be null or an empty string.", nameof(issuer));
            }

            if (string.IsNullOrEmpty(issuer.Provider))
            {
                throw new ArgumentException($"{nameof(issuer)}.{nameof(issuer.Provider)} cannot be null or an empty string.", nameof(issuer));
            }

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(CreateIssuer)}");
            scope.AddAttribute(OTelCertificateIssuerNameKey, issuer.Name);
            scope.Start();
            try
            {
                using RequestContent content = CertificateMapper.ToRequestContent(issuer);
                Response raw = _generated.SetCertificateIssuer(issuer.Name, content, new RequestContext { CancellationToken = cancellationToken });
                return Response.FromValue(CertificateMapper.Deserialize(raw, () => new CertificateIssuer()), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Creates or replaces a certificate <see cref="CertificateIssuer"/> in the key vault. This operation requires the certificates/setissuers permission.
        /// </summary>
        /// <param name="issuer">The <see cref="CertificateIssuer"/> to add or replace in the vault.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The created certificate issuer.</returns>
        /// <exception cref="ArgumentException"><see cref="CertificateIssuer.Name"/> of <paramref name="issuer"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="issuer"/> or <see cref="CertificateIssuer.Name"/> of <paramref name="issuer"/> is null.</exception>
        public virtual async Task<Response<CertificateIssuer>> CreateIssuerAsync(CertificateIssuer issuer, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(issuer, nameof(issuer));

            if (string.IsNullOrEmpty(issuer.Name))
            {
                throw new ArgumentException($"{nameof(issuer)}.{nameof(issuer.Name)} cannot be null or an empty string.", nameof(issuer));
            }

            if (string.IsNullOrEmpty(issuer.Provider))
            {
                throw new ArgumentException($"{nameof(issuer)}.{nameof(issuer.Provider)} cannot be null or an empty string.", nameof(issuer));
            }

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(CreateIssuer)}");
            scope.AddAttribute(OTelCertificateIssuerNameKey, issuer.Name);
            scope.Start();
            try
            {
                using RequestContent content = CertificateMapper.ToRequestContent(issuer);
                Response raw = await _generated.SetCertificateIssuerAsync(issuer.Name, content, new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);
                return Response.FromValue(CertificateMapper.Deserialize(raw, () => new CertificateIssuer()), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Retrieves the specified certificate <see cref="CertificateIssuer"/> from the vault. This operation requires the certificates/getissuers permission.
        /// </summary>
        /// <param name="issuerName">The name of the <see cref="CertificateIssuer"/> to retrieve.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The retrieved certificate issuer.</returns>
        /// <exception cref="ArgumentException"><paramref name="issuerName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="issuerName"/> is null.</exception>
        public virtual Response<CertificateIssuer> GetIssuer(string issuerName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(issuerName, nameof(issuerName));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(GetIssuer)}");
            scope.AddAttribute(OTelCertificateIssuerNameKey, issuerName);
            scope.Start();
            try
            {
                Response raw = _generated.GetCertificateIssuer(issuerName, new RequestContext { CancellationToken = cancellationToken });
                return Response.FromValue(CertificateMapper.Deserialize(raw, () => new CertificateIssuer()), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Retrieves the specified certificate <see cref="CertificateIssuer"/> from the vault. This operation requires the certificates/getissuers permission.
        /// </summary>
        /// <param name="issuerName">The name of the <see cref="CertificateIssuer"/> to retrieve.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The retrieved certificate issuer.</returns>
        /// <exception cref="ArgumentException"><paramref name="issuerName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="issuerName"/> is null.</exception>
        public virtual async Task<Response<CertificateIssuer>> GetIssuerAsync(string issuerName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(issuerName, nameof(issuerName));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(GetIssuer)}");
            scope.AddAttribute(OTelCertificateIssuerNameKey, issuerName);
            scope.Start();
            try
            {
                Response raw = await _generated.GetCertificateIssuerAsync(issuerName, new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);
                return Response.FromValue(CertificateMapper.Deserialize(raw, () => new CertificateIssuer()), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Updates the specified certificate <see cref="CertificateIssuer"/> in the vault, only updating the specified fields, others will remain unchanged. This operation requires the certificates/setissuers permission.
        /// </summary>
        /// <param name="issuer">The <see cref="CertificateIssuer"/> to update in the vault.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The updated certificate issuer.</returns>
        /// <exception cref="ArgumentException"><see cref="CertificateIssuer.Name"/> of <paramref name="issuer"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="issuer"/> or <see cref="CertificateIssuer.Name"/> of <paramref name="issuer"/> is null.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        public virtual Response<CertificateIssuer> UpdateIssuer(CertificateIssuer issuer, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(issuer, nameof(issuer));

            if (string.IsNullOrEmpty(issuer.Name))
            {
                throw new ArgumentException($"{nameof(issuer)}.{nameof(issuer.Name)} cannot be null or an empty string.", nameof(issuer));
            }

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(UpdateIssuer)}");
            scope.AddAttribute(OTelCertificateIssuerNameKey, issuer.Name);
            scope.Start();
            try
            {
                // Reuse CertificateIssuer.WriteProperties via ToRequestContent for the
                // PATCH body. The legacy SendRequest(RequestMethod.Patch, issuer, ...)
                // serialized the same shape; the protocol overload of UpdateCertificateIssuer
                // is what the generated client exposes for this shape so we route through it.
                using RequestContent content = CertificateMapper.ToRequestContent(issuer);
                Response raw = _generated.UpdateCertificateIssuer(issuer.Name, content, new RequestContext { CancellationToken = cancellationToken });
                return Response.FromValue(CertificateMapper.Deserialize(raw, () => new CertificateIssuer()), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Updates the specified certificate <see cref="CertificateIssuer"/> in the vault, only updating the specified fields, others will remain unchanged. This operation requires the certificates/setissuers permission.
        /// </summary>
        /// <param name="issuer">The <see cref="CertificateIssuer"/> to update in the vault.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The updated certificate issuer.</returns>
        /// <exception cref="ArgumentException"><see cref="CertificateIssuer.Name"/> of <paramref name="issuer"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="issuer"/> or <see cref="CertificateIssuer.Name"/> of <paramref name="issuer"/> is null.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        public virtual async Task<Response<CertificateIssuer>> UpdateIssuerAsync(CertificateIssuer issuer, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(issuer, nameof(issuer));

            if (string.IsNullOrEmpty(issuer.Name))
            {
                throw new ArgumentException($"{nameof(issuer)}.{nameof(issuer.Name)} cannot be null or an empty string.", nameof(issuer));
            }

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(UpdateIssuer)}");
            scope.AddAttribute(OTelCertificateIssuerNameKey, issuer.Name);
            scope.Start();
            try
            {
                using RequestContent content = CertificateMapper.ToRequestContent(issuer);
                Response raw = await _generated.UpdateCertificateIssuerAsync(issuer.Name, content, new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);
                return Response.FromValue(CertificateMapper.Deserialize(raw, () => new CertificateIssuer()), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Deletes the specified certificate <see cref="CertificateIssuer"/> from the vault. This operation requires the certificates/deleteissuers permission.
        /// </summary>
        /// <param name="issuerName">The name of the <see cref="CertificateIssuer"/> to delete.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The deleted certificate issuer.</returns>
        /// <exception cref="ArgumentException"><paramref name="issuerName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="issuerName"/> is null.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        public virtual Response<CertificateIssuer> DeleteIssuer(string issuerName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(issuerName, nameof(issuerName));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(DeleteIssuer)}");
            scope.AddAttribute(OTelCertificateIssuerNameKey, issuerName);
            scope.Start();
            try
            {
                Response raw = _generated.DeleteCertificateIssuer(issuerName, new RequestContext { CancellationToken = cancellationToken });
                return Response.FromValue(CertificateMapper.Deserialize(raw, () => new CertificateIssuer()), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Deletes the specified certificate <see cref="CertificateIssuer"/> from the vault. This operation requires the certificates/deleteissuers permission.
        /// </summary>
        /// <param name="issuerName">The name of the <see cref="CertificateIssuer"/> to delete.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The deleted certificate issuer.</returns>
        /// <exception cref="ArgumentException"><paramref name="issuerName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="issuerName"/> is null.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        public virtual async Task<Response<CertificateIssuer>> DeleteIssuerAsync(string issuerName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(issuerName, nameof(issuerName));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(DeleteIssuer)}");
            scope.AddAttribute(OTelCertificateIssuerNameKey, issuerName);
            scope.Start();
            try
            {
                Response raw = await _generated.DeleteCertificateIssuerAsync(issuerName, new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);
                return Response.FromValue(CertificateMapper.Deserialize(raw, () => new CertificateIssuer()), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Lists the properties of all issuers in the specified vault. You can use the returned <see cref="CertificateProperties.Name"/> in subsequent calls to <see cref="GetIssuer(string, CancellationToken)"/>.
        /// This operation requires the certificates/getissuers permission.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An enumerable collection of certificate issuers' metadata.</returns>
        [ForwardsClientCalls]
        public virtual Pageable<IssuerProperties> GetPropertiesOfIssuers(CancellationToken cancellationToken = default)
        {
            var ctx = new RequestContext { CancellationToken = cancellationToken };
            Pageable<BinaryData> source = _generated.GetCertificateIssuers(maxresults: null, context: ctx);
            return MapPageable(source, b => CertificateMapper.DeserializeItem(b, () => new IssuerProperties()));
        }

        /// <summary>
        /// Lists the properties of all issuers in the specified vault. You can use the returned <see cref="CertificateProperties.Name"/> in subsequent calls to <see cref="GetIssuer(string, CancellationToken)"/>.
        /// This operation requires the certificates/getissuers permission.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An enumerable collection of certificate issuers' metadata.</returns>
        [ForwardsClientCalls]
        public virtual AsyncPageable<IssuerProperties> GetPropertiesOfIssuersAsync(CancellationToken cancellationToken = default)
        {
            var ctx = new RequestContext { CancellationToken = cancellationToken };
            AsyncPageable<BinaryData> source = _generated.GetCertificateIssuersAsync(maxresults: null, context: ctx);
            return MapAsyncPageable(source, b => CertificateMapper.DeserializeItem(b, () => new IssuerProperties()));
        }

        #endregion

        #region GetCertificateOperation / Contacts / Merge

        /// <summary>
        /// Gets a pending <see cref="CertificateOperation"/> from the key vault. This operation requires the certificates/get permission.
        /// </summary>
        /// <param name="certificateName">The name of the certificate for which an operation is pending.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The given certificate's current pending operation.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> is null.</exception>
        public virtual CertificateOperation GetCertificateOperation(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(GetCertificateOperation)}");
            scope.AddAttribute(OTelCertificateNameKey, certificateName);
            scope.Start();
            try
            {
                Response raw = _generated.GetCertificateOperation(certificateName, new RequestContext { CancellationToken = cancellationToken });
                var properties = CertificateMapper.Deserialize(raw, () => new CertificateOperationProperties());
                return new CertificateOperation(Response.FromValue(properties, raw), this);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Gets a pending <see cref="CertificateOperation"/> from the key vault. This operation requires the certificates/get permission.
        /// </summary>
        /// <param name="certificateName">The name of the certificate for which an operation is pending.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The given certificate's current pending operation.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> is null.</exception>
        public virtual async Task<CertificateOperation> GetCertificateOperationAsync(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(GetCertificateOperation)}");
            scope.AddAttribute(OTelCertificateNameKey, certificateName);
            scope.Start();
            try
            {
                Response raw = await _generated.GetCertificateOperationAsync(certificateName, new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);
                var properties = CertificateMapper.Deserialize(raw, () => new CertificateOperationProperties());
                return new CertificateOperation(Response.FromValue(properties, raw), this);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Sets the certificate <see cref="CertificateContact"/>s for the key vault, replacing any existing contacts. This operation requires the certificates/managecontacts permission.
        /// </summary>
        /// <param name="contacts">The certificate contacts for the vault.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The updated certificate contacts of the vault.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="contacts"/> is null.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        public virtual Response<IList<CertificateContact>> SetContacts(IEnumerable<CertificateContact> contacts, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(contacts, nameof(contacts));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(SetContacts)}");
            scope.Start();
            try
            {
                using RequestContent content = CertificateMapper.ToRequestContent(new ContactList(contacts));
                Response raw = _generated.SetCertificateContacts(content, new RequestContext { CancellationToken = cancellationToken });
                return CertificateMapper.ToContactsResponse(raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Sets the certificate <see cref="CertificateContact"/>s for the key vault, replacing any existing contacts. This operation requires the certificates/managecontacts permission.
        /// </summary>
        /// <param name="contacts">The certificate contacts for the vault.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The updated certificate contacts of the vault.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="contacts"/> is null.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        public virtual async Task<Response<IList<CertificateContact>>> SetContactsAsync(IEnumerable<CertificateContact> contacts, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(contacts, nameof(contacts));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(SetContacts)}");
            scope.Start();
            try
            {
                using RequestContent content = CertificateMapper.ToRequestContent(new ContactList(contacts));
                Response raw = await _generated.SetCertificateContactsAsync(content, new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);
                return CertificateMapper.ToContactsResponse(raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Gets the certificate <see cref="CertificateContact"/>s for the key vaults. This operation requires the certificates/managecontacts permission.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The certificate contacts of the vault.</returns>
        public virtual Response<IList<CertificateContact>> GetContacts(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(GetContacts)}");
            scope.Start();
            try
            {
                Response raw = _generated.GetCertificateContacts(new RequestContext { CancellationToken = cancellationToken });
                return CertificateMapper.ToContactsResponse(raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Gets the certificate <see cref="CertificateContact"/>s for the key vaults. This operation requires the certificates/managecontacts permission.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The certificate contacts of the vault.</returns>
        public virtual async Task<Response<IList<CertificateContact>>> GetContactsAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(GetContacts)}");
            scope.Start();
            try
            {
                Response raw = await _generated.GetCertificateContactsAsync(new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);
                return CertificateMapper.ToContactsResponse(raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Deletes all certificate <see cref="CertificateContact"/>s from the key vault, replacing any existing contacts. This operation requires the certificates/managecontacts permission.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The certificate contacts deleted from the vault.</returns>
        [CallerShouldAudit(CallerShouldAuditReason)]
        public virtual Response<IList<CertificateContact>> DeleteContacts(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(DeleteContacts)}");
            scope.Start();
            try
            {
                Response raw = _generated.DeleteCertificateContacts(new RequestContext { CancellationToken = cancellationToken });
                return CertificateMapper.ToContactsResponse(raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Deletes all certificate <see cref="CertificateContact"/>s from the key vault, replacing any existing contacts. This operation requires the certificates/managecontacts permission.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The certificate contacts deleted from the vault.</returns>
        [CallerShouldAudit(CallerShouldAuditReason)]
        public virtual async Task<Response<IList<CertificateContact>>> DeleteContactsAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(DeleteContacts)}");
            scope.Start();
            try
            {
                Response raw = await _generated.DeleteCertificateContactsAsync(new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);
                return CertificateMapper.ToContactsResponse(raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Merges a certificate or a certificate chain with a key pair currently available in the service. This operation requires the certificate/create permission.
        /// </summary>
        /// <param name="mergeCertificateOptions">The details of the certificate or certificate chain to merge into the key vault.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The merged certificate.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="mergeCertificateOptions"/> is null.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        public virtual Response<KeyVaultCertificateWithPolicy> MergeCertificate(MergeCertificateOptions mergeCertificateOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(mergeCertificateOptions, nameof(mergeCertificateOptions));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(MergeCertificate)}");
            scope.AddAttribute(OTelCertificateNameKey, mergeCertificateOptions.Name);
            scope.Start();
            try
            {
                using RequestContent content = CertificateMapper.ToRequestContent(mergeCertificateOptions);
                Response raw = _generated.MergeCertificate(mergeCertificateOptions.Name, content, new RequestContext { CancellationToken = cancellationToken });
                return Response.FromValue(CertificateMapper.Deserialize(raw, () => new KeyVaultCertificateWithPolicy()), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        /// <summary>
        /// Merges a certificate or a certificate chain with a key pair currently available in the service. This operation requires the certificate/create permission.
        /// </summary>
        /// <param name="mergeCertificateOptions">The details of the certificate or certificate chain to merge into the key vault.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The merged certificate.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="mergeCertificateOptions"/> is null.</exception>
        [CallerShouldAudit(CallerShouldAuditReason)]
        public virtual async Task<Response<KeyVaultCertificateWithPolicy>> MergeCertificateAsync(MergeCertificateOptions mergeCertificateOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(mergeCertificateOptions, nameof(mergeCertificateOptions));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(MergeCertificate)}");
            scope.AddAttribute(OTelCertificateNameKey, mergeCertificateOptions.Name);
            scope.Start();
            try
            {
                using RequestContent content = CertificateMapper.ToRequestContent(mergeCertificateOptions);
                Response raw = await _generated.MergeCertificateAsync(mergeCertificateOptions.Name, content, new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);
                return Response.FromValue(CertificateMapper.Deserialize(raw, () => new KeyVaultCertificateWithPolicy()), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        #endregion

        #region Internal helpers used by CertificateOperation

        // Polls the create-certificate LRO. Soft-delete semantics:
        //   200/403 -> still creating or already created (CertificateOperation interprets Status)
        //   404     -> operation has been deleted, surface as a null value response
        // Mirrors the legacy hand-written GetPendingCertificate, now routed through the
        // generated client's GetCertificateOperation protocol overload.
        internal virtual Response<CertificateOperationProperties> GetPendingCertificate(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(GetPendingCertificate)}");
            scope.AddAttribute(OTelCertificateNameKey, certificateName);
            scope.Start();
            try
            {
                var ctx = new RequestContext { CancellationToken = cancellationToken, ErrorOptions = ErrorOptions.NoThrow };
                Response response = _generated.GetCertificateOperation(certificateName, ctx);
                return response.Status switch
                {
                    200 or 403 => Response.FromValue(CertificateMapper.Deserialize(response, () => new CertificateOperationProperties()), response),
                    404        => Response.FromValue<CertificateOperationProperties>(null, response),
                    _          => throw new RequestFailedException(response),
                };
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        internal virtual async Task<Response<CertificateOperationProperties>> GetPendingCertificateAsync(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(GetPendingCertificate)}");
            scope.AddAttribute(OTelCertificateNameKey, certificateName);
            scope.Start();
            try
            {
                var ctx = new RequestContext { CancellationToken = cancellationToken, ErrorOptions = ErrorOptions.NoThrow };
                Response response = await _generated.GetCertificateOperationAsync(certificateName, ctx).ConfigureAwait(false);
                return response.Status switch
                {
                    200 or 403 => Response.FromValue(CertificateMapper.Deserialize(response, () => new CertificateOperationProperties()), response),
                    404        => Response.FromValue<CertificateOperationProperties>(null, response),
                    _          => throw new RequestFailedException(response),
                };
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        internal virtual Response<CertificateOperationProperties> CancelCertificateOperation(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(CancelCertificateOperation)}");
            scope.AddAttribute(OTelCertificateNameKey, certificateName);
            scope.Start();
            try
            {
                using RequestContent content = CertificateMapper.WriteCancelOperationBody();
                Response raw = _generated.UpdateCertificateOperation(certificateName, content, new RequestContext { CancellationToken = cancellationToken });
                return Response.FromValue(CertificateMapper.Deserialize(raw, () => new CertificateOperationProperties()), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        internal virtual async Task<Response<CertificateOperationProperties>> CancelCertificateOperationAsync(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(CancelCertificateOperation)}");
            scope.AddAttribute(OTelCertificateNameKey, certificateName);
            scope.Start();
            try
            {
                using RequestContent content = CertificateMapper.WriteCancelOperationBody();
                Response raw = await _generated.UpdateCertificateOperationAsync(certificateName, content, new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);
                return Response.FromValue(CertificateMapper.Deserialize(raw, () => new CertificateOperationProperties()), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        internal virtual Response<CertificateOperationProperties> DeleteCertificateOperation(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(DeleteCertificateOperation)}");
            scope.AddAttribute(OTelCertificateNameKey, certificateName);
            scope.Start();
            try
            {
                Response raw = _generated.DeleteCertificateOperation(certificateName, new RequestContext { CancellationToken = cancellationToken });
                return Response.FromValue(CertificateMapper.Deserialize(raw, () => new CertificateOperationProperties()), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        internal virtual async Task<Response<CertificateOperationProperties>> DeleteCertificateOperationAsync(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _diagnostics.CreateScope($"{nameof(CertificateClient)}.{nameof(DeleteCertificateOperation)}");
            scope.AddAttribute(OTelCertificateNameKey, certificateName);
            scope.Start();
            try
            {
                Response raw = await _generated.DeleteCertificateOperationAsync(certificateName, new RequestContext { CancellationToken = cancellationToken }).ConfigureAwait(false);
                return Response.FromValue(CertificateMapper.Deserialize(raw, () => new CertificateOperationProperties()), raw);
            }
            catch (Exception e) { scope.Failed(e); throw; }
        }

        #endregion

        #region Plumbing: MapApiVersion / pageable helpers

        // Maps the customer-facing CertificateClientOptions.ServiceVersion enum to the
        // api-version string the generated client should send. Every enum value listed
        // on the public type today must continue to construct a working client - no
        // silent fallback. Unknown enum values throw ArgumentOutOfRangeException.
        // For Phase 2 we keep this an identity mapping: the wire api-version still
        // matches GetVersionString() so existing recordings line up. If a future spec
        // drop removes wire support for an older version, fold it into the nearest
        // supported one here (mirroring SecretClient.MapApiVersion) rather than
        // throwing - that's the contract the customer relied on.
        private static string MapApiVersion(CertificateClientOptions.ServiceVersion version) => version switch
        {
            CertificateClientOptions.ServiceVersion.V7_0                => "7.0",
            CertificateClientOptions.ServiceVersion.V7_1                => "7.1",
            CertificateClientOptions.ServiceVersion.V7_2                => "7.2",
            CertificateClientOptions.ServiceVersion.V7_3                => "7.3",
            CertificateClientOptions.ServiceVersion.V7_4                => "7.4",
            CertificateClientOptions.ServiceVersion.V7_5                => "7.5",
            CertificateClientOptions.ServiceVersion.V7_6                => "7.6",
            CertificateClientOptions.ServiceVersion.V2025_07_01         => "2025-07-01",
            CertificateClientOptions.ServiceVersion.V2026_03_01_Preview => "2026-03-01-preview",
            CertificateClientOptions.ServiceVersion.V2026_05_01_Preview => "2026-05-01-preview",
            _ => throw new ArgumentOutOfRangeException(
                nameof(version),
                version,
                "Unknown CertificateClientOptions.ServiceVersion. Add a mapping in CertificateClient.MapApiVersion."),
        };

        private static Pageable<TOut> MapPageable<TIn, TOut>(Pageable<TIn> source, Func<TIn, TOut> map)
            => new MappedPageable<TIn, TOut>(source, map);

        private static AsyncPageable<TOut> MapAsyncPageable<TIn, TOut>(AsyncPageable<TIn> source, Func<TIn, TOut> map)
            => new MappedAsyncPageable<TIn, TOut>(source, map);

        private sealed class MappedPageable<TIn, TOut> : Pageable<TOut>
        {
            private readonly Pageable<TIn> _source;
            private readonly Func<TIn, TOut> _map;
            public MappedPageable(Pageable<TIn> source, Func<TIn, TOut> map) { _source = source; _map = map; }
            public override IEnumerable<Page<TOut>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                foreach (Page<TIn> page in _source.AsPages(continuationToken, pageSizeHint))
                {
                    var values = new List<TOut>(page.Values.Count);
                    foreach (TIn v in page.Values) values.Add(_map(v));
                    yield return Page<TOut>.FromValues(values, page.ContinuationToken, page.GetRawResponse());
                }
            }
        }

        private sealed class MappedAsyncPageable<TIn, TOut> : AsyncPageable<TOut>
        {
            private readonly AsyncPageable<TIn> _source;
            private readonly Func<TIn, TOut> _map;
            public MappedAsyncPageable(AsyncPageable<TIn> source, Func<TIn, TOut> map) { _source = source; _map = map; }
            public override async System.Collections.Generic.IAsyncEnumerable<Page<TOut>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                await foreach (Page<TIn> page in _source.AsPages(continuationToken, pageSizeHint).ConfigureAwait(false))
                {
                    var values = new List<TOut>(page.Values.Count);
                    foreach (TIn v in page.Values) values.Add(_map(v));
                    yield return Page<TOut>.FromValues(values, page.ContinuationToken, page.GetRawResponse());
                }
            }
        }

        #endregion
    }
}