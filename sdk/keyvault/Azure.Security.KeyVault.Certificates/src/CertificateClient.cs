// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// The CertificateClient provides synchronous and asynchronous methods to manage <see cref="Certificate"/>s in Azure Key Vault. The client
    /// supports creating, retrieving, updating, deleting, purging, backing up, restoring and listing the <see cref="Certificate"/>, along with managing
    /// certificate <see cref="Issuer"/>s and <see cref="Contact"/>s. The client also supports listing <see cref="DeletedCertificate"/> for a soft-delete
    /// enabled key vault.
    /// </summary>
    public class CertificateClient
    {
        private readonly KeyVaultPipeline _pipeline;
        private readonly CertificatePolicy _defaultPolicy;

        private const string CertificatesPath = "/certificates/";
        private const string DeletedCertificatesPath = "/deletedcertificates/";
        private const string IssuersPath = "/certificates/issuers/";
        private const string ContactsPath = "/contacts/";

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificateClient"/> class for mocking.
        /// </summary>
        protected CertificateClient()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificateClient"/> class for the specified vault.
        /// </summary>
        /// <param name="vaultUri">A <see cref="Uri"/> to the vault on which the client operates. Appears as "DNS Name" in the Azure portal.</param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to authenticate requests to the vault, such as DefaultAzureCredential.</param>
        public CertificateClient(Uri vaultUri, TokenCredential credential)
            : this(vaultUri, credential, null)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CertificateClient"/> class for the specified vault.
        /// </summary>
        /// <param name="vaultUri">A <see cref="Uri"/> to the vault on which the client operates. Appears as "DNS Name" in the Azure portal.</param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to authenticate requests to the vault, such as DefaultAzureCredential.</param>
        /// <param name="options"><see cref="CertificateClientOptions"/> that allow to configure the management of the request sent to Key Vault.</param>
        public CertificateClient(Uri vaultUri, TokenCredential credential, CertificateClientOptions options)
        {
            Argument.AssertNotNull(vaultUri, nameof(vaultUri));

            options ??= new CertificateClientOptions();

            HttpPipeline pipeline = HttpPipelineBuilder.Build(options, new ChallengeBasedAuthenticationPolicy(credential));

            _defaultPolicy = options.DefaultPolicy ?? CreateDefaultPolicy();

            _pipeline = new KeyVaultPipeline(vaultUri, options.GetVersionString(), pipeline, new ClientDiagnostics(options));
        }

        /// <summary>
        /// Gets the <see cref="Uri"/> of the vault used to create this instance of the <see cref="CertificateClient"/>.
        /// </summary>
        public virtual Uri VaultUri => _pipeline.VaultUri;

        /// <summary>
        /// Starts a long running operation to create a self-signed <see cref="Certificate"/> in the vault, using the default certificate policy.
        /// </summary>
        /// <remarks>
        /// If no certificate with the specified name exists it will be created, otherwise a new version of the existing certificate will be created. This operation requires the certificates/create permission.
        /// </remarks>
        /// <param name="name">The name of the certificate to create</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="CertificateOperation"/> which contians details on the create operation, and can be used to retrieve updated status</returns>
        public virtual CertificateOperation StartCreateCertificate(string name, CancellationToken cancellationToken = default)
        {
            return StartCreateCertificate(name, _defaultPolicy, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Starts a long running operation to create a <see cref="Certificate"/> in the vault, using the default certificate policy.
        /// </summary>
        /// <remarks>
        /// If no certificate with the specified name exists it will be created, otherwise a new version of the existing certificate will be created. This operation requires the certificates/create permission.
        /// </remarks>
        /// <param name="name">The name of the certificate to create</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="CertificateOperation"/> which contians details on the create operation, and can be used to retrieve updated status</returns>
        public virtual async Task<CertificateOperation> StartCreateCertificateAsync(string name, CancellationToken cancellationToken = default)
        {
            return await StartCreateCertificateAsync(name, _defaultPolicy, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Starts a long running operation to create a <see cref="Certificate"/> in the vault with the specified certificate policy.
        /// </summary>
        /// <remarks>
        /// If no certificate with the specified name exists it will be created, otherwise a new version of the existing certificate will be created. This operation requires the certificates/create permission.
        /// </remarks>
        /// <param name="name">The name of the certificate to create</param>
        /// <param name="policy">The <see cref="CertificatePolicy"/> which governs the proprerties and lifecycle of the created certificate</param>
        /// <param name="enabled">Specifies whether the certificate should be created in an enabled state</param>
        /// <param name="tags">Tags to be applied to the created certificate</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="CertificateOperation"/> which contians details on the create operation, and can be used to retrieve updated status</returns>
        public virtual CertificateOperation StartCreateCertificate(string name, CertificatePolicy policy, bool? enabled = default, IDictionary<string, string> tags = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(policy, nameof(policy));

            var parameters = new CertificateCreateParameters(policy, enabled, tags);

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.StartCreateCertificate");
            scope.AddAttribute("certificate", name);
            scope.Start();

            try
            {
                Response<CertificateOperationProperties> response = _pipeline.SendRequest(RequestMethod.Post, parameters, () => new CertificateOperationProperties(), cancellationToken, CertificatesPath, name, "/create");

                return new CertificateOperation(response, this);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Starts a long running operation to create a <see cref="Certificate"/> in the vault with the specified certificate policy.
        /// </summary>
        /// <remarks>
        /// If no certificate with the specified name exists it will be created, otherwise a new version of the existing certificate will be created. This operation requires the certificates/create permission.
        /// </remarks>
        /// <param name="name">The name of the certificate to create</param>
        /// <param name="policy">The <see cref="CertificatePolicy"/> which governs the proprerties and lifecycle of the created certificate</param>
        /// <param name="enabled">Specifies whether the certificate should be created in an enabled state</param>
        /// <param name="tags">Tags to be applied to the created certificate</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="CertificateOperation"/> which contians details on the create operation, and can be used to retrieve updated status</returns>
        public virtual async Task<CertificateOperation> StartCreateCertificateAsync(string name, CertificatePolicy policy, bool? enabled = default, IDictionary<string, string> tags = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(policy, nameof(policy));

            var parameters = new CertificateCreateParameters(policy, enabled, tags);

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.StartCreateCertificate");
            scope.AddAttribute("certificate", name);
            scope.Start();

            try
            {
                Response<CertificateOperationProperties> response = await _pipeline.SendRequestAsync(RequestMethod.Post, parameters, () => new CertificateOperationProperties(), cancellationToken, CertificatesPath, name, "/create").ConfigureAwait(false);

                return new CertificateOperation(response, this);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Returns the latest version of the <see cref="Certificate"/> along with it's <see cref="CertificatePolicy"/>. This operation requires the certificates/get permission.
        /// </summary>
        /// <param name="name">The name of the <see cref="Certificate"/> to retrieve</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the certificate and policy as a <see cref="CertificateWithPolicy"/> instance</returns>
        public virtual Response<CertificateWithPolicy> GetCertificate(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.GetCertificate");
            scope.AddAttribute("certificate", name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Get, () => new CertificateWithPolicy(), cancellationToken, CertificatesPath, name);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Returns the latest version of the <see cref="Certificate"/> along with it's <see cref="CertificatePolicy"/>. This operation requires the certificates/get permission.
        /// </summary>
        /// <param name="name">The name of the <see cref="Certificate"/> to retrieve</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the certificate and policy as a <see cref="CertificateWithPolicy"/> instance</returns>
        public virtual async Task<Response<CertificateWithPolicy>> GetCertificateAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.GetCertificate");
            scope.AddAttribute("certificate", name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Get, () => new CertificateWithPolicy(), cancellationToken, CertificatesPath, name).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a specific version of the <see cref="Certificate"/>. This operation requires the certificates/get permission.
        /// </summary>
        /// <param name="name">The name of the <see cref="Certificate"/> to retrieve</param>
        /// <param name="version">Ther version of the <see cref="Certificate"/> to retrieve</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The requested <see cref="Certificate"/></returns>
        public virtual Response<Certificate> GetCertificateVersion(string name, string version, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.GetCertificateVersion");
            scope.AddAttribute("certificate", name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Get, () => new Certificate(), cancellationToken, CertificatesPath, name, "/", version);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a specific version of the <see cref="Certificate"/>. This operation requires the certificates/get permission.
        /// </summary>
        /// <param name="name">The name of the <see cref="Certificate"/> to retrieve</param>
        /// <param name="version">Ther version of the <see cref="Certificate"/> to retrieve</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The requested <see cref="Certificate"/></returns>
        public virtual async Task<Response<Certificate>> GetCertificateVersionAsync(string name, string version, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNullOrEmpty(version, nameof(version));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.GetCertificateVersion");
            scope.AddAttribute("certificate", name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Get, () => new Certificate(), cancellationToken, CertificatesPath, name, "/", version).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates the specified <see cref="Certificate"/> with the specified values for its mutable properties. This operation requires the certificates/update permission.
        /// </summary>
        /// <param name="properties">The <see cref="CertificateProperties"/> object with updated properties.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The updated <see cref="Certificate"/></returns>
        public virtual Response<Certificate> UpdateCertificateProperties(CertificateProperties properties, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(properties, nameof(properties));

            var parameters = new CertificateUpdateParameters(properties);

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.UpdateCertificateProperties");
            scope.AddAttribute("certificate", properties.Name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Patch, parameters, () => new Certificate(), cancellationToken, CertificatesPath, properties.Name, "/", properties.Version);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates the specified <see cref="Certificate"/> with the specified values for its mutable properties. This operation requires the certificates/update permission.
        /// </summary>
        /// <param name="properties">The <see cref="CertificateProperties"/> object with updated properties.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The updated <see cref="Certificate"/></returns>
        public virtual async Task<Response<Certificate>> UpdateCertificatePropertiesAsync(CertificateProperties properties, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(properties, nameof(properties));

            var parameters = new CertificateUpdateParameters(properties);

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.UpdateCertificateProperties");
            scope.AddAttribute("certificate", properties.Name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Patch, parameters, () => new Certificate(), cancellationToken, CertificatesPath, properties.Name, "/", properties.Version).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes all versions of the specified <see cref="Certificate"/>. If the vault is soft delete enabled, the <see cref="Certificate"/> will be marked for perminent deletion
        /// and can be recovered with <see cref="RecoverDeletedCertificate"/>, or purged with <see cref="PurgeDeletedCertificate"/>. This operation requires the certificates/delete permission.
        /// </summary>
        /// <param name="name">The name of the <see cref="Certificate"/> to delete</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The details of the <see cref="DeletedCertificate"/></returns>
        public virtual Response<DeletedCertificate> DeleteCertificate(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.DeleteCertificate");
            scope.AddAttribute("certificate", name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Delete, () => new DeletedCertificate(), cancellationToken, CertificatesPath, name);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes all versions of the specified <see cref="Certificate"/>. If the vault is soft delete enabled, the <see cref="Certificate"/> will be marked for perminent deletion
        /// and can be recovered with <see cref="RecoverDeletedCertificate"/>, or purged with <see cref="PurgeDeletedCertificate"/>. This operation requires the certificates/delete permission.
        /// </summary>
        /// <param name="name">The name of the <see cref="Certificate"/> to delete</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The details of the <see cref="DeletedCertificate"/></returns>
        public virtual async Task<Response<DeletedCertificate>> DeleteCertificateAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.DeleteCertificate");
            scope.AddAttribute("certificate", name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Delete, () => new DeletedCertificate(), cancellationToken, CertificatesPath, name).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information about the specified deleted <see cref="Certificate"/>. This operation is only applicable in vaults enabled for soft-delete, and
        /// requires the certificates/get permission.
        /// </summary>
        /// <param name="name">The name of the <see cref="DeletedCertificate"/></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The details of the <see cref="DeletedCertificate"/></returns>
        public virtual Response<DeletedCertificate> GetDeletedCertificate(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.GetDeletedCertificate");
            scope.AddAttribute("certificate", name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Get, () => new DeletedCertificate(), cancellationToken, DeletedCertificatesPath, name);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information about the specified deleted <see cref="Certificate"/>. This operation is only applicable in vaults enabled for soft-delete, and
        /// requires the certificates/get permission.
        /// </summary>
        /// <param name="name">The name of the <see cref="DeletedCertificate"/></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The details of the <see cref="DeletedCertificate"/></returns>
        public virtual async Task<Response<DeletedCertificate>> GetDeletedCertificateAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.GetDeletedCertificate");
            scope.AddAttribute("certificate", name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Get, () => new DeletedCertificate(), cancellationToken, DeletedCertificatesPath, name).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Recovers the <see cref="DeletedCertificate"/> to its pre-deleted state. This operation is only applicable in vaults enabled for soft-delete, and
        /// requires the certificates/recover permission.
        /// </summary>
        /// <param name="name">The name of the <see cref="DeletedCertificate"/></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The recovered certificate and policy</returns>
        public virtual Response<CertificateWithPolicy> RecoverDeletedCertificate(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.RecoverDeletedCertificate");
            scope.AddAttribute("certificate", name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Post, () => new CertificateWithPolicy(), cancellationToken, DeletedCertificatesPath, name, "/recover");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Recovers the <see cref="DeletedCertificate"/> to its pre-deleted state. This operation is only applicable in vaults enabled for soft-delete, and
        /// requires the certificates/recover permission.
        /// </summary>
        /// <param name="name">The name of the <see cref="DeletedCertificate"/></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The recovered certificate and policy</returns>
        public virtual async Task<Response<CertificateWithPolicy>> RecoverDeletedCertificateAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.RecoverDeletedCertificate");
            scope.AddAttribute("certificate", name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Post, () => new CertificateWithPolicy(), cancellationToken, DeletedCertificatesPath, name, "/recover").ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Permanently and irreversibly deletes the specified deleted certificate, without the possibility of recovery. This operation is only applicable in vaults enabled for soft-delete, and
        /// requires the certificates/purge permission. The operation is not available if the DeletedCertificate.RecoveryLevel of the DeletedCertificate does not specify 'Purgeable'.
        /// </summary>
        /// <param name="name">The name of the <see cref="DeletedCertificate"/> to perminantly delete</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The http response from the service</returns>
        public virtual Response PurgeDeletedCertificate(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.PurgeDeletedCertificate");
            scope.AddAttribute("certificate", name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Delete, cancellationToken, DeletedCertificatesPath, name);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Permanently and irreversibly deletes the specified deleted certificate, without the possibility of recovery. This operation is only applicable in vaults enabled for soft-delete, and
        /// requires the certificates/purge permission. The operation is not available if the DeletedCertificate.RecoveryLevel of the DeletedCertificate does not specify 'Purgeable'.
        /// </summary>
        /// <param name="name">The name of the <see cref="DeletedCertificate"/> to perminantly delete</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response> PurgeDeletedCertificateAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.PurgeDeletedCertificate");
            scope.AddAttribute("certificate", name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Delete, cancellationToken, DeletedCertificatesPath, name).ConfigureAwait(false);
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
        /// <param name="name">The name of the <see cref="Certificate"/> to backup</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The certificate backup</returns>
        public virtual Response<byte[]> BackupCertificate(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.BackupCertificate");
            scope.AddAttribute("certificate", name);
            scope.Start();

            try
            {
                Response<CertificateBackup> backup = _pipeline.SendRequest(RequestMethod.Post, () => new CertificateBackup(), cancellationToken, CertificatesPath, name, "/backup");

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
        /// <param name="name">The name of the <see cref="Certificate"/> to backup</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The certificate backup</returns>
        public virtual async Task<Response<byte[]>> BackupCertificateAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.BackupCertificate");
            scope.AddAttribute("certificate", name);
            scope.Start();

            try
            {
                Response<CertificateBackup> backup = await _pipeline.SendRequestAsync(RequestMethod.Post, () => new CertificateBackup(), cancellationToken, CertificatesPath, name, "/backup").ConfigureAwait(false);

                return Response.FromValue(backup.Value.Value, backup.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Restores a <see cref="Certificate"/>, including all versions, from a backup created from the <see cref="BackupCertificate"/> or <see cref="BackupCertificateAsync"/>. The backup must be restored
        /// to a vault in the same region as its original vault.  This operation requires the certificate/restore permission.
        /// </summary>
        /// <param name="backup">The backup of the <see cref="Certificate"/> to restore</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The restored certificate and policy</returns>
        public virtual Response<CertificateWithPolicy> RestoreCertificate(byte[] backup, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(backup, nameof(backup));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.RestoreCertificate");
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Post, new CertificateBackup { Value = backup }, () => new CertificateWithPolicy(), cancellationToken, CertificatesPath, "/restore");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Restores a <see cref="Certificate"/>, including all versions, from a backup created from the <see cref="BackupCertificate"/> or <see cref="BackupCertificateAsync"/>. The backup must be restored
        /// to a vault in the same region as its original vault.  This operation requires the certificate/restore permission.
        /// </summary>
        /// <param name="backup">The backup of the <see cref="Certificate"/> to restore</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The restored certificate and policy</returns>
        public virtual async Task<Response<CertificateWithPolicy>> RestoreCertificateAsync(byte[] backup, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(backup, nameof(backup));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.RestoreCertificate");
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Post, new CertificateBackup { Value = backup }, () => new CertificateWithPolicy(), cancellationToken, CertificatesPath, "/restore").ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Imports a pre-existing certificate to the key vault. The specified certificate must be in PFX or PEM format, and must contain the private key as well as the x509 certificates. This operation requires the
        /// certifcates/import permission
        /// </summary>
        /// <param name="certificateImportOptions">The details of the certificate to import to the key vault</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The imported certificate and policy</returns>
        public virtual Response<CertificateWithPolicy> ImportCertificate(CertificateImportOptions certificateImportOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(certificateImportOptions, nameof(certificateImportOptions));
            Argument.AssertNotNullOrEmpty(certificateImportOptions.Name, nameof(certificateImportOptions.Name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.ImportCertificate");
            scope.AddAttribute("certificate", certificateImportOptions.Name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Post, certificateImportOptions, () => new CertificateWithPolicy(), cancellationToken, CertificatesPath, "/", certificateImportOptions.Name, "/import");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Imports a pre-existing certificate to the key vault. The specified certificate must be in PFX or PEM format, and must contain the private key as well as the x509 certificates. This operation requires the
        /// certifcates/import permission
        /// </summary>
        /// <param name="certificateImportOptions">The details of the certificate to import to the key vault</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The imported certificate and policy</returns>
        public virtual async Task<Response<CertificateWithPolicy>> ImportCertificateAsync(CertificateImportOptions certificateImportOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(certificateImportOptions, nameof(certificateImportOptions));
            Argument.AssertNotNullOrEmpty(certificateImportOptions.Name, nameof(certificateImportOptions.Name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.ImportCertificate");
            scope.AddAttribute("certificate", certificateImportOptions.Name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Post, certificateImportOptions, () => new CertificateWithPolicy(), cancellationToken, CertificatesPath, "/", certificateImportOptions.Name, "/import").ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Enumerates the certificates in the vault, returning select properties of the certificate, sensative feilds of the certificate will not be returned.  This operation requires the certificates/list permission.
        /// </summary>
        /// <param name="includePending">Specifies whether to include certificates in a pending state as well</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An enumerable collection of certificate metadata</returns>
        public virtual Pageable<CertificateProperties> GetCertificates(bool? includePending = default, CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = includePending.HasValue ? _pipeline.CreateFirstPageUri(CertificatesPath, new ValueTuple<string, string>("includePending", includePending.Value.ToString(CultureInfo.InvariantCulture).ToLowerInvariant())) : _pipeline.CreateFirstPageUri(CertificatesPath);

            return PageResponseEnumerator.CreateEnumerable(nextLink => _pipeline.GetPage(firstPageUri, nextLink, () => new CertificateProperties(), "Azure.Security.KeyVault.Keys.KeyClient.GetCertificates", cancellationToken));
        }

        /// <summary>
        /// Enumerates the certificates in the vault, returning select properties of the certificate, sensative feilds of the certificate will not be returned.  This operation requires the certificates/list permission.
        /// </summary>
        /// <param name="includePending">Specifies whether to include certificates in a pending state as well</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An enumerable collection of certificate metadata</returns>
        public virtual AsyncPageable<CertificateProperties> GetCertificatesAsync(bool? includePending = default, CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = includePending.HasValue ? _pipeline.CreateFirstPageUri(CertificatesPath, new ValueTuple<string, string>("includePending", includePending.Value.ToString(CultureInfo.InvariantCulture).ToLowerInvariant())) : _pipeline.CreateFirstPageUri(CertificatesPath);

            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => _pipeline.GetPageAsync(firstPageUri, nextLink, () => new CertificateProperties(), "Azure.Security.KeyVaultCertificates.CertificateClient.GetCertificates", cancellationToken));
        }

        /// <summary>
        /// Enumerates the versions of a specific certificate in the vault, returning select properties of the certificate versions, sensative feilds of the certificate will not be returned.  This operation requires
        /// the certificates/list permission.
        /// </summary>
        /// <param name="name">The name of the certificate to retrieve the versions of</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An enumerable collection of the certificate's versions</returns>
        public virtual IEnumerable<CertificateProperties> GetCertificateVersions(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            Uri firstPageUri = _pipeline.CreateFirstPageUri($"{CertificatesPath}{name}/versions");

            return PageResponseEnumerator.CreateEnumerable(nextLink => _pipeline.GetPage(firstPageUri, nextLink, () => new CertificateProperties(), "Azure.Security.KeyVaultCertificates.CertificateClient.GetCertificateVersions", cancellationToken));
        }

        /// <summary>
        /// Enumerates the versions of a specific certificate in the vault, returning select properties of the certificate versions, sensative feilds of the certificate will not be returned.  This operation requires
        /// the certificates/list permission.
        /// </summary>
        /// <param name="name">The name of the certificate to retrieve the versions of</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An enumerable collection of the certificate's versions</returns>
        public virtual AsyncPageable<CertificateProperties> GetCertificateVersionsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            Uri firstPageUri = _pipeline.CreateFirstPageUri($"{CertificatesPath}{name}/versions");

            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => _pipeline.GetPageAsync(firstPageUri, nextLink, () => new CertificateProperties(), "Azure.Security.KeyVaultCertificates.CertificateClient.GetCertificateVersions", cancellationToken));
        }

        /// <summary>
        /// Enumerates the deleted certificates in the vault.  This operation is only available on soft-delete enabled vaults, and requires the certificates/list/get permissions.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An enumerable collection of deleted certificates</returns>
        public virtual Pageable<DeletedCertificate> GetDeletedCertificates(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = _pipeline.CreateFirstPageUri(DeletedCertificatesPath);

            return PageResponseEnumerator.CreateEnumerable(nextLink => _pipeline.GetPage(firstPageUri, nextLink, () => new DeletedCertificate(), "Azure.Security.KeyVaultCertificates.CertificateClient.GetDeletedCertificates", cancellationToken));
        }

        /// <summary>
        /// Enumerates the deleted certificates in the vault.  This operation is only available on soft-delete enabled vaults, and requires the certificates/list/get permissions.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An enumerable collection of deleted certificates</returns>
        public virtual AsyncPageable<DeletedCertificate> GetDeletedCertificatesAsync(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = _pipeline.CreateFirstPageUri(DeletedCertificatesPath);

            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => _pipeline.GetPageAsync(firstPageUri, nextLink, () => new DeletedCertificate(), "Azure.Security.KeyVaultCertificates.CertificateClient.GetDeletedCertificates", cancellationToken));
        }

        //
        // Policy
        //

        /// <summary>
        /// Retrieves the <see cref="CertificatePolicy"/> of the specified certificate. This operation requires the certificate/get permission.
        /// </summary>
        /// <param name="certificateName">The name of the certificate to retrieve the policy of</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="CertificatePolicy"/> of the specified certificate</returns>
        public virtual Response<CertificatePolicy> GetCertificatePolicy(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.GetCertificatePolicy");
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
        /// <param name="certificateName">The name of the certificate to retrieve the policy of</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The <see cref="CertificatePolicy"/> of the specified certificate</returns>
        public virtual async Task<Response<CertificatePolicy>> GetCertificatePolicyAsync(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.GetCertificatePolicy");
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
        /// <param name="certificateName">The name of the certificate to update the policy of</param>
        /// <param name="policy">The updated policy for the specified certificate</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The updated certificate policy</returns>
        public virtual Response<CertificatePolicy> UpdateCertificatePolicy(string certificateName, CertificatePolicy policy, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.UpdateCertificatePolicy");
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
        /// <param name="certificateName">The name of the certificate to update the policy of</param>
        /// <param name="policy">The updated policy for the specified certificate</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The updated certificate policy</returns>
        public virtual async Task<Response<CertificatePolicy>> UpdateCertificatePolicyAsync(string certificateName, CertificatePolicy policy, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.UpdateCertificatePolicy");
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

        //
        // Issuer
        //

        /// <summary>
        /// Creates or replaces a certificate <see cref="Issuer"/> in the key vault. This operation requires the certificates/setissuers permission.
        /// </summary>
        /// <param name="issuer">The <see cref="Issuer"/> to add or replace in the vault</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The created certificate issuer</returns>
        public virtual Response<Issuer> CreateIssuer(Issuer issuer, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(issuer, nameof(issuer));
            Argument.AssertNotNullOrEmpty(issuer.Name, nameof(issuer.Name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.CreateIssuer");
            scope.AddAttribute("issuer", issuer.Name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Put, issuer, () => new Issuer(), cancellationToken, IssuersPath, issuer.Name);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates or replaces a certificate <see cref="Issuer"/> in the key vault. This operation requires the certificates/setissuers permission.
        /// </summary>
        /// <param name="issuer">The <see cref="Issuer"/> to add or replace in the vault</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The created certificate issuer</returns>
        public virtual async Task<Response<Issuer>> CreateIssuerAsync(Issuer issuer, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(issuer, nameof(issuer));
            Argument.AssertNotNullOrEmpty(issuer.Name, nameof(issuer.Name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.CreateIssuer");
            scope.AddAttribute("issuer", issuer.Name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Put, issuer, () => new Issuer(), cancellationToken, IssuersPath, issuer.Name).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves the specified certificate <see cref="Issuer"/> from the vault. This operation requires the certificates/getissuers permission.
        /// </summary>
        /// <param name="name">The name of the <see cref="Issuer"/> to retreive</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The retrieved certificate issuer</returns>
        public virtual Response<Issuer> GetIssuer(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.GetIssuer");
            scope.AddAttribute("issuer", name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Get, () => new Issuer(), cancellationToken, IssuersPath, name);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves the specified certificate <see cref="Issuer"/> from the vault. This operation requires the certificates/getissuers permission.
        /// </summary>
        /// <param name="name">The name of the <see cref="Issuer"/> to retreive</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The retrieved certificate issuer</returns>
        public virtual async Task<Response<Issuer>> GetIssuerAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.GetIssuer");
            scope.AddAttribute("issuer", name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Get, () => new Issuer(), cancellationToken, IssuersPath, name).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates the specified certificate <see cref="Issuer"/> in the vault, only updating the specified fields, others will remain unchanged. This operation requires the certificates/setissuers permission.
        /// </summary>
        /// <param name="issuer">The <see cref="Issuer"/> to update in the vault</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The updated certificate issuer</returns>
        public virtual Response<Issuer> UpdateIssuer(Issuer issuer, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(issuer, nameof(issuer));
            Argument.AssertNotNullOrEmpty(issuer.Name, nameof(issuer.Name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.UpdateIssuer");
            scope.AddAttribute("issuer", issuer.Name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Patch, issuer, () => new Issuer(), cancellationToken, IssuersPath, issuer.Name);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Updates the specified certificate <see cref="Issuer"/> in the vault, only updating the specified fields, others will remain unchanged. This operation requires the certificates/setissuers permission.
        /// </summary>
        /// <param name="issuer">The <see cref="Issuer"/> to update in the vault</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The updated certificate issuer</returns>
        public virtual async Task<Response<Issuer>> UpdateIssuerAsync(Issuer issuer, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(issuer, nameof(issuer));
            Argument.AssertNotNullOrEmpty(issuer.Name, nameof(issuer.Name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.UpdateIssuer");
            scope.AddAttribute("issuer", issuer.Name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Patch, issuer, () => new Issuer(), cancellationToken, IssuersPath, issuer.Name).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes the specified certificate <see cref="Issuer"/> from the vault. This operation requires the certificates/deleteissuers permission.
        /// </summary>
        /// <param name="name">The name of the <see cref="Issuer"/> to delete</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The deleted certificate issuer</returns>
        public virtual Response<Issuer> DeleteIssuer(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.DeleteIssuer");
            scope.AddAttribute("issuer", name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Delete, () => new Issuer(), cancellationToken, IssuersPath, name);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes the specified certificate <see cref="Issuer"/> from the vault. This operation requires the certificates/deleteissuers permission.
        /// </summary>
        /// <param name="name">The name of the <see cref="Issuer"/> to delete</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The deleted certificate issuer</returns>
        public virtual async Task<Response<Issuer>> DeleteIssuerAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.DeleteIssuer");
            scope.AddAttribute("issuer", name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Delete, () => new Issuer(), cancellationToken, IssuersPath, name).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Enumerates the certificate issuers in the vault, returning select properties of the <see cref="Issuer"/>, sensative feilds of the <see cref="Issuer"/> will not be returned.  This operation requires the certificates/getissuers permission.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An enumerable collection of certificate issuers metadata</returns>
        public virtual Pageable<IssuerProperties> GetIssuers(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = _pipeline.CreateFirstPageUri(IssuersPath);

            return PageResponseEnumerator.CreateEnumerable(nextLink => _pipeline.GetPage(firstPageUri, nextLink, () => new IssuerProperties(), "Azure.Security.KeyVaultCertificates.CertificateClient.GetIssuers", cancellationToken));
        }

        /// <summary>
        /// Enumerates the certificate issuers in the vault, returning select properties of the <see cref="Issuer"/>, sensative feilds of the <see cref="Issuer"/> will not be returned. This operation requires the certificates/getissuers permission.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>An enumerable collection of certificate issuers metadata</returns>
        public virtual AsyncPageable<IssuerProperties> GetIssuersAsync(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = _pipeline.CreateFirstPageUri(IssuersPath);

            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => _pipeline.GetPageAsync(firstPageUri, nextLink, () => new IssuerProperties(), "Azure.Security.KeyVaultCertificates.CertificateClient.GetIssuers", cancellationToken));
        }

        //
        // Operations
        //

        /// <summary>
        /// Gets a pending <see cref="CertificateOperation"/> from the key vault.  This operation requires the certificates/get permission.
        /// </summary>
        /// <param name="certificateName">The name of the <see cref="Certificate"/> to retrieve the current pending operation of</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The given certificates current pending operation</returns>
        public virtual CertificateOperation GetCertificateOperation(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.GetCertificateOperation");
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
        /// Gets a pending <see cref="CertificateOperation"/> from the key vault.  This operation requires the certificates/get permission.
        /// </summary>
        /// <param name="certificateName">The name of the <see cref="Certificate"/> to retrieve the current pending operation of</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The given certificates current pending operation</returns>
        public virtual async Task<CertificateOperation> GetCertificateOperationAsync(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.GetCertificateOperation");
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
        /// Cancels a pending <see cref="CertificateOperation"/> in the key vault.  This operation requires the certificates/update permission.
        /// </summary>
        /// <param name="certificateName">The name of the <see cref="Certificate"/> to cancel the current pending operation of</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The canceled certificate operation</returns>
        public virtual CertificateOperation CancelCertificateOperation(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            var parameters = new CertificateOperationUpdateParameters(true);

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.CancelCertificateOperation");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                Response<CertificateOperationProperties> response = _pipeline.SendRequest(RequestMethod.Patch, parameters, () => new CertificateOperationProperties(), cancellationToken, CertificatesPath, certificateName, "/pending");

                return new CertificateOperation(response, this);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Cancels a pending <see cref="CertificateOperation"/> in the key vault.  This operation requires the certificates/update permission.
        /// </summary>
        /// <param name="certificateName">The name of the <see cref="Certificate"/> to cancel the current pending operation of</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The canceled certificate operation</returns>
        public virtual async Task<CertificateOperation> CancelCertificateOperationAsync(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            var parameters = new CertificateOperationUpdateParameters(true);

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.CancelCertificateOperation");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                Response<CertificateOperationProperties> response = await _pipeline.SendRequestAsync(RequestMethod.Patch, parameters, () => new CertificateOperationProperties(), cancellationToken, CertificatesPath, certificateName, "/pending").ConfigureAwait(false);

                return new CertificateOperation(response, this);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes a pending <see cref="CertificateOperation"/> in the key vault.  This operation requires the certificates/delete permission.
        /// </summary>
        /// <param name="certificateName">The name of the <see cref="Certificate"/> to delete the current pending operation of</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The deleted certificate operation</returns>
        public virtual CertificateOperation DeleteCertificateOperation(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.DeleteCertificateOperation");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                Response<CertificateOperationProperties> response = _pipeline.SendRequest(RequestMethod.Delete, () => new CertificateOperationProperties(), cancellationToken, CertificatesPath, certificateName, "/pending");

                return new CertificateOperation(response, this);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Deletes a pending <see cref="CertificateOperation"/> in the key vault.  This operation requires the certificates/delete permission.
        /// </summary>
        /// <param name="certificateName">The name of the <see cref="Certificate"/> to delete the current pending operation of</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The deleted certificate operation</returns>
        public virtual async Task<CertificateOperation> DeleteCertificateOperationAsync(string certificateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(certificateName, nameof(certificateName));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.DeleteCertificateOperation");
            scope.AddAttribute("certificate", certificateName);
            scope.Start();

            try
            {
                Response<CertificateOperationProperties> response = await _pipeline.SendRequestAsync(RequestMethod.Delete, () => new CertificateOperationProperties(), cancellationToken, CertificatesPath, certificateName, "/pending").ConfigureAwait(false);

                return new CertificateOperation(response, this);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        //
        // Contacts
        //

        /// <summary>
        /// Sets the certificate <see cref="Contact"/>s for the key vault, replacing any existing contacts. This operation requires the certificates/managecontacts permission.
        /// </summary>
        /// <param name="contacts">The certificate contacts for the vault</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The updated certificate contacts of the vault</returns>
        public virtual Response<IList<Contact>> SetContacts(IEnumerable<Contact> contacts, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(contacts, nameof(contacts));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.SetContacts");
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
        /// Sets the certificate <see cref="Contact"/>s for the key vault, replacing any existing contacts. This operation requires the certificates/managecontacts permission.
        /// </summary>
        /// <param name="contacts">The certificate contacts for the vault</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The updated certificate contacts of the vault</returns>
        public virtual async Task<Response<IList<Contact>>> SetContactsAsync(IEnumerable<Contact> contacts, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(contacts, nameof(contacts));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.SetContacts");
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
        /// Gets the certificate <see cref="Contact"/>s for the key vaults. This operation requires the certificates/managecontacts permission.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The certificate contacts of the vault</returns>
        public virtual Response<IList<Contact>> GetContacts(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.GetContacts");
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
        /// Gets the certificate <see cref="Contact"/>s for the key vaults. This operation requires the certificates/managecontacts permission.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The certificate contacts of the vault</returns>
        public virtual async Task<Response<IList<Contact>>> GetContactsAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.GetContacts");
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
        /// Delets all certificate <see cref="Contact"/>s from the key vault, replacing any existing contacts. This operation requires the certificates/managecontacts permission.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The certificate contacts deleted from the vault</returns>
        public virtual Response<IList<Contact>> DeleteContacts(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.DeleteContacts");
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
        /// Delets all certificate <see cref="Contact"/>s from the key vault, replacing any existing contacts. This operation requires the certificates/managecontacts permission.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The certificate contacts deleted from the vault</returns>
        public virtual async Task<Response<IList<Contact>>> DeleteContactsAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.DeleteContacts");
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
        /// <param name="certificateMergeOptions">The details of the certificate or certificate chain to merge into the key vault.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The merged certificate.</returns>
        public virtual Response<CertificateWithPolicy> MergeCertificate(CertificateMergeOptions certificateMergeOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(certificateMergeOptions, nameof(certificateMergeOptions));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.MergeCertificate");
            scope.AddAttribute("certificate", certificateMergeOptions.Name);
            scope.Start();

            try
            {
                Response<CertificateWithPolicy> certificate = _pipeline.SendRequest(RequestMethod.Post, () => new CertificateWithPolicy(), cancellationToken, CertificatesPath, certificateMergeOptions.Name, "/pending/merge");

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
        /// <param name="certificateMergeOptions">The details of the certificate or certificate chain to merge into the key vault.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The merged certificate.</returns>
        public virtual async Task<Response<CertificateWithPolicy>> MergeCertificateAsync(CertificateMergeOptions certificateMergeOptions, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(certificateMergeOptions, nameof(certificateMergeOptions));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.MergeCertificate");
            scope.AddAttribute("certificate", certificateMergeOptions.Name);
            scope.Start();

            try
            {
                Response<CertificateWithPolicy> certificate = await _pipeline.SendRequestAsync(RequestMethod.Post, () => new CertificateWithPolicy(), cancellationToken, CertificatesPath, certificateMergeOptions.Name, "/pending/merge").ConfigureAwait(false);

                return Response.FromValue(certificate.Value, certificate.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal virtual Response<CertificateOperationProperties> GetPendingCertificate(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.GetPendingCertificate");
            scope.AddAttribute("certificate", name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Get, () => new CertificateOperationProperties(), cancellationToken, CertificatesPath, name, "/pending");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal virtual async Task<Response<CertificateOperationProperties>> GetPendingCertificateAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.GetPendingCertificate");
            scope.AddAttribute("certificate", name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Get, () => new CertificateOperationProperties(), cancellationToken, CertificatesPath, name, "/pending").ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal CertificatePolicy CreateDefaultPolicy()
        {
            var policy = new CertificatePolicy
            {
                IssuerName = "Self",
                Subject = "CN=default",
                KeyType = CertificateKeyType.Rsa,
                Exportable = true,
                ReuseKey = false,
                KeyUsage = new[]
                {
                    CertificateKeyUsage.CrlSign,
                    CertificateKeyUsage.DataEncipherment,
                    CertificateKeyUsage.DigitalSignature,
                    CertificateKeyUsage.KeyEncipherment,
                    CertificateKeyUsage.KeyAgreement,
                    CertificateKeyUsage.KeyCertSign,
                },
                CertificateTransparency = false,
                ContentType = CertificateContentType.Pkcs12
            };

            return policy;
        }
    }
}
