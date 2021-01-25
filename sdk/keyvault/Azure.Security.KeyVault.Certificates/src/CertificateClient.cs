// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class CertificateClient
    {
        internal const string CertificatesPath = "/certificates/";
        internal const string DeletedCertificatesPath = "/deletedcertificates/";
        private const string IssuersPath = "/certificates/issuers/";
        private const string ContactsPath = "/certificates/contacts/";

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
        /// </param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to authenticate requests to the vault, such as DefaultAzureCredential.</param>
        /// <param name="options"><see cref="CertificateClientOptions"/> that allow to configure the management of the request sent to Key Vault.</param>
        /// <exception cref="ArgumentNullException"><paramref name="vaultUri"/> or <paramref name="credential"/> is null.</exception>
        public CertificateClient(Uri vaultUri, TokenCredential credential, CertificateClientOptions options)
        {
            Argument.AssertNotNull(vaultUri, nameof(vaultUri));
            Argument.AssertNotNull(credential, nameof(credential));

            options ??= new CertificateClientOptions();

            HttpPipeline pipeline = HttpPipelineBuilder.Build(options, new ChallengeBasedAuthenticationPolicy(credential));

            _pipeline = new KeyVaultPipeline(vaultUri, options.GetVersionString(), pipeline, new ClientDiagnostics(options));
        }

        /// <summary>
        /// Gets the <see cref="Uri"/> of the vault used to create this instance of the <see cref="CertificateClient"/>.
        /// </summary>
        public virtual Uri VaultUri => _pipeline.VaultUri;

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
        public virtual CertificateOperation StartCreateCertificate(string certificateName, CertificatePolicy policy, bool? enabled = default, IDictionary<string, string> tags = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));
            Argument.AssertNotNull(policy, nameof(policy));

            var parameters = new CertificateCreateParameters(policy, enabled, tags);

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(StartCreateCertificate)}");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                Response<CertificateOperationProperties> response = _pipeline.SendRequest(RequestMethod.Post, parameters, () => new CertificateOperationProperties(), cancellationToken, CertificatesPath, certificateName, "/create");

                return new CertificateOperation(response, this);
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
        public virtual async Task<CertificateOperation> StartCreateCertificateAsync(string certificateName, CertificatePolicy policy, bool? enabled = default, IDictionary<string, string> tags = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));
            Argument.AssertNotNull(policy, nameof(policy));

            var parameters = new CertificateCreateParameters(policy, enabled, tags);

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(StartCreateCertificate)}");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                Response<CertificateOperationProperties> response = await _pipeline.SendRequestAsync(RequestMethod.Post, parameters, () => new CertificateOperationProperties(), cancellationToken, CertificatesPath, certificateName, "/create").ConfigureAwait(false);

                return new CertificateOperation(response, this);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

#pragma warning disable AZC0015 // Unexpected client method return type.
        /// <summary>
        /// Creates an <see cref="X509Certificate2"/> from the specified certificate.
        /// </summary>
        /// <remarks>
        /// Because <see cref="KeyVaultCertificate.Cer"/> contains only the public key, this method attempts to download the managed secret
        /// that contains the full certificate. If you do not have permissions to get the secret,
        /// <see cref="RequestFailedException"/> will be thrown with an appropriate error response.
        /// If you want an <see cref="X509Certificate2"/> with only the public key, instantiate it passing only the
        /// <see cref="KeyVaultCertificate.Cer"/> property.
        /// </remarks>
        /// <param name="certificateName">The name of the certificate to download.</param>
        /// <param name="version">Optional version of a certificate to download.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="X509Certificate2"/> from the specified certificate.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> is null.</exception>
        /// <exception cref="InvalidOperationException">The managed secret did not contain a certificate.</exception>
        /// <exception cref="NotSupportedException">Downloading PEM-formatted certificates is not supported.</exception>
        /// <exception cref="RequestFailedException">The request failed. See <see cref="RequestFailedException.ErrorCode"/> and the exception message for details.</exception>
        public virtual Response<X509Certificate2> DownloadCertificate(string certificateName, string version = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(DownloadCertificate)}");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                KeyVaultCertificateWithPolicy certificate = _pipeline.SendRequest(RequestMethod.Get, () => new KeyVaultCertificateWithPolicy(), cancellationToken, CertificatesPath, certificateName, "/", version);
                Response<KeyVaultSecret> secretResponse = _pipeline.SendRequest(RequestMethod.Get, () => new KeyVaultSecret(), certificate.SecretId, cancellationToken);

                KeyVaultSecret secret = secretResponse.Value;
                string value = secret.Value;

                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidOperationException($"Secret {certificate.SecretId} contains no value");
                }

                if (secret.ContentType == CertificateContentType.Pem)
                {
                    throw new NotSupportedException($"PEM-formatted certificates are not supported");
                }

                byte[] rawData = Convert.FromBase64String(value);

                return Response.FromValue(new X509Certificate2(rawData), secretResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates an <see cref="X509Certificate2"/> from the specified certificate.
        /// </summary>
        /// <remarks>
        /// Because <see cref="KeyVaultCertificate.Cer"/> contains only the public key, this method attempts to download the managed secret
        /// that contains the full certificate. If you do not have permissions to get the secret,
        /// <see cref="RequestFailedException"/> will be thrown with an appropriate error response.
        /// If you want an <see cref="X509Certificate2"/> with only the public key, instantiate it passing only the
        /// <see cref="KeyVaultCertificate.Cer"/> property.
        /// </remarks>
        /// <param name="certificateName">The name of the certificate to download.</param>
        /// <param name="version">Optional version of a certificate to download.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An <see cref="X509Certificate2"/> from the specified certificate.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> is null.</exception>
        /// <exception cref="InvalidOperationException">The managed secret did not contain a certificate.</exception>
        /// <exception cref="NotSupportedException">Downloading PEM-formatted certificates is not supported.</exception>
        /// <exception cref="RequestFailedException">The request failed. See <see cref="RequestFailedException.ErrorCode"/> and the exception message for details.</exception>
        public virtual async Task<Response<X509Certificate2>> DownloadCertificateAsync(string certificateName, string version = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(DownloadCertificate)}");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                KeyVaultCertificateWithPolicy certificate = await _pipeline.SendRequestAsync(RequestMethod.Get, () => new KeyVaultCertificateWithPolicy(), cancellationToken, CertificatesPath, certificateName, "/", version).ConfigureAwait(false);
                Response<KeyVaultSecret> secretResponse = await _pipeline.SendRequestAsync(RequestMethod.Get, () => new KeyVaultSecret(), certificate.SecretId, cancellationToken).ConfigureAwait(false);

                KeyVaultSecret secret = secretResponse.Value;
                string value = secret.Value;

                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidOperationException($"Secret {certificate.SecretId} contains no value");
                }

                if (secret.ContentType == CertificateContentType.Pem)
                {
                    throw new NotSupportedException($"PEM-formatted certificates are not supported");
                }

                byte[] rawData = Convert.FromBase64String(value);

                return Response.FromValue(new X509Certificate2(rawData), secretResponse.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
#pragma warning restore AZC0015 // Unexpected client method return type.

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

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(GetCertificate)}");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Get, () => new KeyVaultCertificateWithPolicy(), cancellationToken, CertificatesPath, certificateName);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(GetCertificate)}");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Get, () => new KeyVaultCertificateWithPolicy(), cancellationToken, CertificatesPath, certificateName).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(GetCertificateVersion)}");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Get, () => new KeyVaultCertificate(), cancellationToken, CertificatesPath, certificateName, "/", version);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(GetCertificateVersion)}");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Get, () => new KeyVaultCertificate(), cancellationToken, CertificatesPath, certificateName, "/", version).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates the specified <see cref="KeyVaultCertificate"/> with the specified values for its mutable properties. This operation requires the certificates/update permission.
        /// </summary>
        /// <param name="properties">The <see cref="CertificateProperties"/> object with updated properties.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The updated <see cref="KeyVaultCertificate"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="properties"/> is null.</exception>
        public virtual Response<KeyVaultCertificate> UpdateCertificateProperties(CertificateProperties properties, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(properties, nameof(properties));

            var parameters = new CertificateUpdateParameters(properties);

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(UpdateCertificateProperties)}");
            scope.AddAttribute("certificate", properties.Name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Patch, parameters, () => new KeyVaultCertificate(), cancellationToken, CertificatesPath, properties.Name, "/", properties.Version);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates the specified <see cref="KeyVaultCertificate"/> with the specified values for its mutable properties. This operation requires the certificates/update permission.
        /// </summary>
        /// <param name="properties">The <see cref="CertificateProperties"/> object with updated properties.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The updated <see cref="KeyVaultCertificate"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="properties"/> is null.</exception>
        public virtual async Task<Response<KeyVaultCertificate>> UpdateCertificatePropertiesAsync(CertificateProperties properties, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(properties, nameof(properties));

            var parameters = new CertificateUpdateParameters(properties);

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(UpdateCertificateProperties)}");
            scope.AddAttribute("certificate", properties.Name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Patch, parameters, () => new KeyVaultCertificate(), cancellationToken, CertificatesPath, properties.Name, "/", properties.Version).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
        public virtual DeleteCertificateOperation StartDeleteCertificate(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(StartDeleteCertificate)}");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                Response<DeletedCertificate> response = _pipeline.SendRequest(RequestMethod.Delete, () => new DeletedCertificate(), cancellationToken, CertificatesPath, certificateName);
                return new DeleteCertificateOperation(_pipeline, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
        public virtual async Task<DeleteCertificateOperation> StartDeleteCertificateAsync(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(StartDeleteCertificate)}");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                Response<DeletedCertificate> response = await _pipeline.SendRequestAsync(RequestMethod.Delete, () => new DeletedCertificate(), cancellationToken, CertificatesPath, certificateName).ConfigureAwait(false);
                return new DeleteCertificateOperation(_pipeline, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(GetDeletedCertificate)}");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Get, () => new DeletedCertificate(), cancellationToken, DeletedCertificatesPath, certificateName);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(GetDeletedCertificate)}");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Get, () => new DeletedCertificate(), cancellationToken, DeletedCertificatesPath, certificateName).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
        public virtual RecoverDeletedCertificateOperation StartRecoverDeletedCertificate(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(StartRecoverDeletedCertificate)}");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                Response<KeyVaultCertificateWithPolicy> response = _pipeline.SendRequest(RequestMethod.Post, () => new KeyVaultCertificateWithPolicy(), cancellationToken, DeletedCertificatesPath, certificateName, "/recover");
                return new RecoverDeletedCertificateOperation(_pipeline, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
        public virtual async Task<RecoverDeletedCertificateOperation> StartRecoverDeletedCertificateAsync(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(StartRecoverDeletedCertificate)}");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                Response<KeyVaultCertificateWithPolicy> response = await _pipeline.SendRequestAsync(RequestMethod.Post, () => new KeyVaultCertificateWithPolicy(), cancellationToken, DeletedCertificatesPath, certificateName, "/recover").ConfigureAwait(false);
                return new RecoverDeletedCertificateOperation(_pipeline, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
        public virtual Response PurgeDeletedCertificate(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(PurgeDeletedCertificate)}");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Delete, cancellationToken, DeletedCertificatesPath, certificateName);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
        public virtual async Task<Response> PurgeDeletedCertificateAsync(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(PurgeDeletedCertificate)}");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Delete, cancellationToken, DeletedCertificatesPath, certificateName).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(BackupCertificate)}");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                Response<CertificateBackup> backup = _pipeline.SendRequest(RequestMethod.Post, () => new CertificateBackup(), cancellationToken, CertificatesPath, certificateName, "/backup");

                return Response.FromValue(backup.Value.Value, backup.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(BackupCertificate)}");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                Response<CertificateBackup> backup = await _pipeline.SendRequestAsync(RequestMethod.Post, () => new CertificateBackup(), cancellationToken, CertificatesPath, certificateName, "/backup").ConfigureAwait(false);

                return Response.FromValue(backup.Value.Value, backup.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Restores a <see cref="KeyVaultCertificate"/>, including all versions, from a backup created from the <see cref="BackupCertificate"/> or <see cref="BackupCertificateAsync"/>. The backup must be restored
        /// to a vault in the same region as its original vault. This operation requires the certificate/restore permission.
        /// </summary>
        /// <param name="backup">The backup of the <see cref="KeyVaultCertificate"/> to restore.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The restored certificate and policy.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="backup"/> is null.</exception>
        public virtual Response<KeyVaultCertificateWithPolicy> RestoreCertificateBackup(byte[] backup, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(backup, nameof(backup));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(RestoreCertificateBackup)}");
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Post, new CertificateBackup { Value = backup }, () => new KeyVaultCertificateWithPolicy(), cancellationToken, CertificatesPath, "/restore");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Restores a <see cref="KeyVaultCertificate"/>, including all versions, from a backup created from the <see cref="BackupCertificate"/> or <see cref="BackupCertificateAsync"/>. The backup must be restored
        /// to a vault in the same region as its original vault. This operation requires the certificate/restore permission.
        /// </summary>
        /// <param name="backup">The backup of the <see cref="KeyVaultCertificate"/> to restore.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The restored certificate and policy.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="backup"/> is null.</exception>
        public virtual async Task<Response<KeyVaultCertificateWithPolicy>> RestoreCertificateBackupAsync(byte[] backup, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(backup, nameof(backup));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(RestoreCertificateBackup)}");
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Post, new CertificateBackup { Value = backup }, () => new KeyVaultCertificateWithPolicy(), cancellationToken, CertificatesPath, "/restore").ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
        public virtual Response<KeyVaultCertificateWithPolicy> ImportCertificate(ImportCertificateOptions importCertificateOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(importCertificateOptions, nameof(importCertificateOptions));
            Argument.AssertNotNullOrEmpty(importCertificateOptions.Name, nameof(importCertificateOptions.Name));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(ImportCertificate)}");
            scope.AddAttribute("certificate", importCertificateOptions.Name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Post, importCertificateOptions, () => new KeyVaultCertificateWithPolicy(), cancellationToken, CertificatesPath, "/", importCertificateOptions.Name, "/import");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
        public virtual async Task<Response<KeyVaultCertificateWithPolicy>> ImportCertificateAsync(ImportCertificateOptions importCertificateOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(importCertificateOptions, nameof(importCertificateOptions));
            Argument.AssertNotNullOrEmpty(importCertificateOptions.Name, nameof(importCertificateOptions.Name));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(ImportCertificate)}");
            scope.AddAttribute("certificate", importCertificateOptions.Name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Post, importCertificateOptions, () => new KeyVaultCertificateWithPolicy(), cancellationToken, CertificatesPath, "/", importCertificateOptions.Name, "/import").ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists the properties of all certificates in the specified vault. You can use the returned <see cref="CertificateProperties.Name"/> in subsequent calls to <see cref="GetCertificate(string, CancellationToken)"/>.
        /// This operation requires the certificates/list permission.
        /// </summary>
        /// <param name="includePending">Specifies whether to include certificates in a pending state as well.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An enumerable collection of certificate metadata.</returns>
        public virtual Pageable<CertificateProperties> GetPropertiesOfCertificates(bool includePending = default, CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = _pipeline.CreateFirstPageUri(CertificatesPath, ("includePending", includePending.ToString(CultureInfo.InvariantCulture).ToLowerInvariant()));

            return PageResponseEnumerator.CreateEnumerable(nextLink => _pipeline.GetPage(firstPageUri, nextLink, () => new CertificateProperties(), "Azure.Security.KeyVault.Keys.KeyClient.GetPropertiesOfCertificates", cancellationToken));
        }

        /// <summary>
        /// Lists the properties of all certificates in the specified vault. You can use the returned <see cref="CertificateProperties.Name"/> in subsequent calls to <see cref="GetCertificate(string, CancellationToken)"/>.
        /// This operation requires the certificates/list permission.
        /// </summary>
        /// <param name="includePending">Specifies whether to include certificates in a pending state as well.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An enumerable collection of certificate metadata.</returns>
        public virtual AsyncPageable<CertificateProperties> GetPropertiesOfCertificatesAsync(bool includePending = default, CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = _pipeline.CreateFirstPageUri(CertificatesPath, ("includePending", includePending.ToString(CultureInfo.InvariantCulture).ToLowerInvariant()));

            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => _pipeline.GetPageAsync(firstPageUri, nextLink, () => new CertificateProperties(), "Azure.Security.KeyVaultCertificates.CertificateClient.GetPropertiesOfCertificates", cancellationToken));
        }

        /// <summary>
        /// Lists the properties of all versions of the specified certificate in the specified vault. You can use the returned <see cref="CertificateProperties.Name"/> in subsequent calls to <see cref="GetCertificateVersion(string, string, CancellationToken)"/>.
        /// This operation requires the certificates/list permission.
        /// </summary>
        /// <param name="certificateName">The name of the certificate whose versions should be retrieved.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An enumerable collection of the certificate's versions.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> is null.</exception>
        public virtual Pageable<CertificateProperties> GetPropertiesOfCertificateVersions(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            Uri firstPageUri = _pipeline.CreateFirstPageUri($"{CertificatesPath}{certificateName}/versions");

            return PageResponseEnumerator.CreateEnumerable(nextLink => _pipeline.GetPage(firstPageUri, nextLink, () => new CertificateProperties(), "Azure.Security.KeyVaultCertificates.CertificateClient.GetPropertiesOfCertificateVersions", cancellationToken));
        }

        /// <summary>
        /// Lists the properties of all versions of the specified certificate in the specified vault. You can use the returned <see cref="CertificateProperties.Name"/> in subsequent calls to <see cref="GetCertificateVersion(string, string, CancellationToken)"/>.
        /// This operation requires the certificates/list permission.
        /// </summary>
        /// <param name="certificateName">The name of the certificate whose versions should be retrieved.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An enumerable collection of the certificate's versions.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> is null.</exception>
        public virtual AsyncPageable<CertificateProperties> GetPropertiesOfCertificateVersionsAsync(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            Uri firstPageUri = _pipeline.CreateFirstPageUri($"{CertificatesPath}{certificateName}/versions");

            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => _pipeline.GetPageAsync(firstPageUri, nextLink, () => new CertificateProperties(), "Azure.Security.KeyVaultCertificates.CertificateClient.GetPropertiesOfCertificateVersions", cancellationToken));
        }

        /// <summary>
        /// Enumerates the deleted certificates in the vault. This operation is only available on soft delete-enabled vaults, and requires the certificates/list/get permissions.
        /// </summary>
        /// <param name="includePending">Specifies whether to include certificates in a delete pending state as well.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An enumerable collection of deleted certificates.</returns>
        public virtual Pageable<DeletedCertificate> GetDeletedCertificates(bool includePending = default, CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = _pipeline.CreateFirstPageUri(DeletedCertificatesPath, ("includePending", includePending.ToString(CultureInfo.InvariantCulture).ToLowerInvariant()));

            return PageResponseEnumerator.CreateEnumerable(nextLink => _pipeline.GetPage(firstPageUri, nextLink, () => new DeletedCertificate(), "Azure.Security.KeyVaultCertificates.CertificateClient.GetDeletedCertificates", cancellationToken));
        }

        /// <summary>
        /// Enumerates the deleted certificates in the vault. This operation is only available on soft delete-enabled vaults, and requires the certificates/list/get permissions.
        /// </summary>
        /// <param name="includePending">Specifies whether to include certificates in a delete pending state as well.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An enumerable collection of deleted certificates.</returns>
        public virtual AsyncPageable<DeletedCertificate> GetDeletedCertificatesAsync(bool includePending = default, CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = _pipeline.CreateFirstPageUri(DeletedCertificatesPath, ("includePending", includePending.ToString(CultureInfo.InvariantCulture).ToLowerInvariant()));

            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => _pipeline.GetPageAsync(firstPageUri, nextLink, () => new DeletedCertificate(), "Azure.Security.KeyVaultCertificates.CertificateClient.GetDeletedCertificates", cancellationToken));
        }

        /// <summary>
        /// Retrieves the <see cref="CertificatePolicy"/> of the specified certificate. This operation requires the certificate/get permission.
        /// </summary>
        /// <param name="certificateName">The name of the certificate whose policy should be retrieved.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="CertificatePolicy"/> of the specified certificate.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> is null.</exception>
        public virtual Response<CertificatePolicy> GetCertificatePolicy(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(GetCertificatePolicy)}");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Get, () => new CertificatePolicy(), cancellationToken, CertificatesPath, certificateName, "/policy");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves the <see cref="CertificatePolicy"/> of the specified certificate. This operation requires the certificate/get permission.
        /// </summary>
        /// <param name="certificateName">The name of the certificate whose policy should be retrieved.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="CertificatePolicy"/> of the specified certificate.</returns>
        /// <exception cref="ArgumentException"><paramref name="certificateName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="certificateName"/> is null.</exception>
        public virtual async Task<Response<CertificatePolicy>> GetCertificatePolicyAsync(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(GetCertificatePolicy)}");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Get, () => new CertificatePolicy(), cancellationToken, CertificatesPath, certificateName, "/policy").ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
        public virtual Response<CertificatePolicy> UpdateCertificatePolicy(string certificateName, CertificatePolicy policy, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(UpdateCertificatePolicy)}");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Patch, policy, () => new CertificatePolicy(), cancellationToken, CertificatesPath, certificateName, "/policy");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
        public virtual async Task<Response<CertificatePolicy>> UpdateCertificatePolicyAsync(string certificateName, CertificatePolicy policy, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(UpdateCertificatePolicy)}");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Patch, policy, () => new CertificatePolicy(), cancellationToken, CertificatesPath, certificateName, "/policy").ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

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

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(CreateIssuer)}");
            scope.AddAttribute("issuer", issuer.Name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Put, issuer, () => new CertificateIssuer(), cancellationToken, IssuersPath, issuer.Name);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(CreateIssuer)}");
            scope.AddAttribute("issuer", issuer.Name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Put, issuer, () => new CertificateIssuer(), cancellationToken, IssuersPath, issuer.Name).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(GetIssuer)}");
            scope.AddAttribute("issuer", issuerName);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Get, () => new CertificateIssuer(), cancellationToken, IssuersPath, issuerName);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(GetIssuer)}");
            scope.AddAttribute("issuer", issuerName);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Get, () => new CertificateIssuer(), cancellationToken, IssuersPath, issuerName).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates the specified certificate <see cref="CertificateIssuer"/> in the vault, only updating the specified fields, others will remain unchanged. This operation requires the certificates/setissuers permission.
        /// </summary>
        /// <param name="issuer">The <see cref="CertificateIssuer"/> to update in the vault.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The updated certificate issuer.</returns>
        /// <exception cref="ArgumentException"><see cref="CertificateIssuer.Name"/> of <paramref name="issuer"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="issuer"/> or <see cref="CertificateIssuer.Name"/> of <paramref name="issuer"/> is null.</exception>
        public virtual Response<CertificateIssuer> UpdateIssuer(CertificateIssuer issuer, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(issuer, nameof(issuer));

            if (string.IsNullOrEmpty(issuer.Name))
            {
                throw new ArgumentException($"{nameof(issuer)}.{nameof(issuer.Name)} cannot be null or an empty string.", nameof(issuer));
            }

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(UpdateIssuer)}");
            scope.AddAttribute("issuer", issuer.Name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Patch, issuer, () => new CertificateIssuer(), cancellationToken, IssuersPath, issuer.Name);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates the specified certificate <see cref="CertificateIssuer"/> in the vault, only updating the specified fields, others will remain unchanged. This operation requires the certificates/setissuers permission.
        /// </summary>
        /// <param name="issuer">The <see cref="CertificateIssuer"/> to update in the vault.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The updated certificate issuer.</returns>
        /// <exception cref="ArgumentException"><see cref="CertificateIssuer.Name"/> of <paramref name="issuer"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="issuer"/> or <see cref="CertificateIssuer.Name"/> of <paramref name="issuer"/> is null.</exception>
        public virtual async Task<Response<CertificateIssuer>> UpdateIssuerAsync(CertificateIssuer issuer, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(issuer, nameof(issuer));

            if (string.IsNullOrEmpty(issuer.Name))
            {
                throw new ArgumentException($"{nameof(issuer)}.{nameof(issuer.Name)} cannot be null or an empty string.", nameof(issuer));
            }

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(UpdateIssuer)}");
            scope.AddAttribute("issuer", issuer.Name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Patch, issuer, () => new CertificateIssuer(), cancellationToken, IssuersPath, issuer.Name).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes the specified certificate <see cref="CertificateIssuer"/> from the vault. This operation requires the certificates/deleteissuers permission.
        /// </summary>
        /// <param name="issuerName">The name of the <see cref="CertificateIssuer"/> to delete.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The deleted certificate issuer.</returns>
        /// <exception cref="ArgumentException"><paramref name="issuerName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="issuerName"/> is null.</exception>
        public virtual Response<CertificateIssuer> DeleteIssuer(string issuerName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(issuerName, nameof(issuerName));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(DeleteIssuer)}");
            scope.AddAttribute("issuer", issuerName);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Delete, () => new CertificateIssuer(), cancellationToken, IssuersPath, issuerName);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes the specified certificate <see cref="CertificateIssuer"/> from the vault. This operation requires the certificates/deleteissuers permission.
        /// </summary>
        /// <param name="issuerName">The name of the <see cref="CertificateIssuer"/> to delete.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The deleted certificate issuer.</returns>
        /// <exception cref="ArgumentException"><paramref name="issuerName"/> is empty.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="issuerName"/> is null.</exception>
        public virtual async Task<Response<CertificateIssuer>> DeleteIssuerAsync(string issuerName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(issuerName, nameof(issuerName));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(DeleteIssuer)}");
            scope.AddAttribute("issuer", issuerName);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Delete, () => new CertificateIssuer(), cancellationToken, IssuersPath, issuerName).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Lists the properties of all issuers in the specified vault. You can use the returned <see cref="CertificateProperties.Name"/> in subsequent calls to <see cref="GetIssuer(string, CancellationToken)"/>.
        /// This operation requires the certificates/getissuers permission.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An enumerable collection of certificate issuers' metadata.</returns>
        public virtual Pageable<IssuerProperties> GetPropertiesOfIssuers(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = _pipeline.CreateFirstPageUri(IssuersPath);

            return PageResponseEnumerator.CreateEnumerable(nextLink => _pipeline.GetPage(firstPageUri, nextLink, () => new IssuerProperties(), $"{nameof(CertificateClient)}.{nameof(GetPropertiesOfIssuers)}", cancellationToken));
        }

        /// <summary>
        /// Lists the properties of all issuers in the specified vault. You can use the returned <see cref="CertificateProperties.Name"/> in subsequent calls to <see cref="GetIssuer(string, CancellationToken)"/>.
        /// This operation requires the certificates/getissuers permission.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An enumerable collection of certificate issuers' metadata.</returns>
        public virtual AsyncPageable<IssuerProperties> GetPropertiesOfIssuersAsync(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = _pipeline.CreateFirstPageUri(IssuersPath);

            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => _pipeline.GetPageAsync(firstPageUri, nextLink, () => new IssuerProperties(), $"{nameof(CertificateClient)}.{nameof(GetPropertiesOfIssuers)}", cancellationToken));
        }

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

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(GetCertificateOperation)}");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                Response<CertificateOperationProperties> response = _pipeline.SendRequest(RequestMethod.Get, () => new CertificateOperationProperties(), cancellationToken, CertificatesPath, certificateName, "/pending");

                return new CertificateOperation(response, this);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(GetCertificateOperation)}");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                Response<CertificateOperationProperties> response = await _pipeline.SendRequestAsync(RequestMethod.Get, () => new CertificateOperationProperties(), cancellationToken, CertificatesPath, certificateName, "/pending").ConfigureAwait(false);

                return new CertificateOperation(response, this);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Sets the certificate <see cref="CertificateContact"/>s for the key vault, replacing any existing contacts. This operation requires the certificates/managecontacts permission.
        /// </summary>
        /// <param name="contacts">The certificate contacts for the vault.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The updated certificate contacts of the vault.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="contacts"/> is null.</exception>
        public virtual Response<IList<CertificateContact>> SetContacts(IEnumerable<CertificateContact> contacts, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(contacts, nameof(contacts));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(SetContacts)}");
            scope.Start();

            try
            {
                Response<ContactList> contactList = _pipeline.SendRequest(RequestMethod.Put, new ContactList(contacts), () => new ContactList(), cancellationToken, ContactsPath);

                return Response.FromValue(contactList.Value.ToList(), contactList.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Sets the certificate <see cref="CertificateContact"/>s for the key vault, replacing any existing contacts. This operation requires the certificates/managecontacts permission.
        /// </summary>
        /// <param name="contacts">The certificate contacts for the vault.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The updated certificate contacts of the vault.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="contacts"/> is null.</exception>
        public virtual async Task<Response<IList<CertificateContact>>> SetContactsAsync(IEnumerable<CertificateContact> contacts, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(contacts, nameof(contacts));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(SetContacts)}");
            scope.Start();

            try
            {
                Response<ContactList> contactList = await _pipeline.SendRequestAsync(RequestMethod.Put, new ContactList(contacts), () => new ContactList(), cancellationToken, ContactsPath).ConfigureAwait(false);

                return Response.FromValue(contactList.Value.ToList(), contactList.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the certificate <see cref="CertificateContact"/>s for the key vaults. This operation requires the certificates/managecontacts permission.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The certificate contacts of the vault.</returns>
        public virtual Response<IList<CertificateContact>> GetContacts(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(GetContacts)}");
            scope.Start();

            try
            {
                Response<ContactList> contactList = _pipeline.SendRequest(RequestMethod.Get, () => new ContactList(), cancellationToken, ContactsPath);

                return Response.FromValue(contactList.Value.ToList(), contactList.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the certificate <see cref="CertificateContact"/>s for the key vaults. This operation requires the certificates/managecontacts permission.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The certificate contacts of the vault.</returns>
        public virtual async Task<Response<IList<CertificateContact>>> GetContactsAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(GetContacts)}");
            scope.Start();

            try
            {
                Response<ContactList> contactList = await _pipeline.SendRequestAsync(RequestMethod.Get, () => new ContactList(), cancellationToken, ContactsPath).ConfigureAwait(false);

                return Response.FromValue(contactList.Value.ToList(), contactList.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes all certificate <see cref="CertificateContact"/>s from the key vault, replacing any existing contacts. This operation requires the certificates/managecontacts permission.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The certificate contacts deleted from the vault.</returns>
        public virtual Response<IList<CertificateContact>> DeleteContacts(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(DeleteContacts)}");
            scope.Start();

            try
            {
                Response<ContactList> contactList = _pipeline.SendRequest(RequestMethod.Delete, () => new ContactList(), cancellationToken, ContactsPath);

                return Response.FromValue(contactList.Value.ToList(), contactList.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes all certificate <see cref="CertificateContact"/>s from the key vault, replacing any existing contacts. This operation requires the certificates/managecontacts permission.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The certificate contacts deleted from the vault.</returns>
        public virtual async Task<Response<IList<CertificateContact>>> DeleteContactsAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(DeleteContacts)}");
            scope.Start();

            try
            {
                Response<ContactList> contactList = await _pipeline.SendRequestAsync(RequestMethod.Delete, () => new ContactList(), cancellationToken, ContactsPath).ConfigureAwait(false);

                return Response.FromValue(contactList.Value.ToList(), contactList.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Merges a certificate or a certificate chain with a key pair currently available in the service. This operation requires the certificate/create permission.
        /// </summary>
        /// <param name="mergeCertificateOptions">The details of the certificate or certificate chain to merge into the key vault.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The merged certificate.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="mergeCertificateOptions"/> is null.</exception>
        public virtual Response<KeyVaultCertificateWithPolicy> MergeCertificate(MergeCertificateOptions mergeCertificateOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(mergeCertificateOptions, nameof(mergeCertificateOptions));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(MergeCertificate)}");
            scope.AddAttribute("certificate", mergeCertificateOptions.Name);
            scope.Start();

            try
            {
                Response<KeyVaultCertificateWithPolicy> certificate = _pipeline.SendRequest(RequestMethod.Post, mergeCertificateOptions, () => new KeyVaultCertificateWithPolicy(), cancellationToken, CertificatesPath, mergeCertificateOptions.Name, "/pending/merge");

                return Response.FromValue(certificate.Value, certificate.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Merges a certificate or a certificate chain with a key pair currently available in the service. This operation requires the certificate/create permission.
        /// </summary>
        /// <param name="mergeCertificateOptions">The details of the certificate or certificate chain to merge into the key vault.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The merged certificate.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="mergeCertificateOptions"/> is null.</exception>
        public virtual async Task<Response<KeyVaultCertificateWithPolicy>> MergeCertificateAsync(MergeCertificateOptions mergeCertificateOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(mergeCertificateOptions, nameof(mergeCertificateOptions));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(MergeCertificate)}");
            scope.AddAttribute("certificate", mergeCertificateOptions.Name);
            scope.Start();

            try
            {
                Response<KeyVaultCertificateWithPolicy> certificate = await _pipeline.SendRequestAsync(RequestMethod.Post, mergeCertificateOptions, () => new KeyVaultCertificateWithPolicy(), cancellationToken, CertificatesPath, mergeCertificateOptions.Name, "/pending/merge").ConfigureAwait(false);

                return Response.FromValue(certificate.Value, certificate.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal virtual Response<CertificateOperationProperties> GetPendingCertificate(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(GetPendingCertificate)}");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                Response response = _pipeline.GetResponse(RequestMethod.Get, cancellationToken, CertificatesPath, certificateName, "/pending");
                switch (response.Status)
                {
                    case 200:
                    case 403:
                        return _pipeline.CreateResponse(response, new CertificateOperationProperties());

                    case 404:
                        return Response.FromValue<CertificateOperationProperties>(null, response);

                    default:
                        throw _pipeline.Diagnostics.CreateRequestFailedException(response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal virtual async Task<Response<CertificateOperationProperties>> GetPendingCertificateAsync(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(GetPendingCertificate)}");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                Response response = await _pipeline.GetResponseAsync(RequestMethod.Get, cancellationToken, CertificatesPath, certificateName, "/pending").ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                    case 403:
                        return _pipeline.CreateResponse(response, new CertificateOperationProperties());

                    case 404:
                        return Response.FromValue<CertificateOperationProperties>(null, response);

                    default:
                        throw await _pipeline.Diagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal virtual Response<CertificateOperationProperties> CancelCertificateOperation(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            var parameters = new CertificateOperationUpdateParameters(true);

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(CancelCertificateOperation)}");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Patch, parameters, () => new CertificateOperationProperties(), cancellationToken, CertificatesPath, certificateName, "/pending");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal virtual async Task<Response<CertificateOperationProperties>> CancelCertificateOperationAsync(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            var parameters = new CertificateOperationUpdateParameters(true);

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(CancelCertificateOperation)}");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Patch, parameters, () => new CertificateOperationProperties(), cancellationToken, CertificatesPath, certificateName, "/pending").ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal virtual Response<CertificateOperationProperties> DeleteCertificateOperation(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(DeleteCertificateOperation)}");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Delete, () => new CertificateOperationProperties(), cancellationToken, CertificatesPath, certificateName, "/pending");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal virtual async Task<Response<CertificateOperationProperties>> DeleteCertificateOperationAsync(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _pipeline.CreateScope($"{nameof(CertificateClient)}.{nameof(DeleteCertificateOperation)}");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Delete, () => new CertificateOperationProperties(), cancellationToken, CertificatesPath, certificateName, "/pending").ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
