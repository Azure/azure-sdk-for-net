// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Certificates
{
    public class CertificateClient
    {
        private readonly KeyVaultPipeline _pipeline;
        private readonly CertificatePolicy _defaultPolicy;

        private const string CertificatesPath = "/certificates/";
        private const string DeletedCertificatesPath = "/deletedcertificates/";
        private const string IssuersPath = "/certificates/issuers/";
        private const string ContactsPath = "/contacts/";

        protected CertificateClient()
        {

        }
        public CertificateClient(Uri vaultUri, TokenCredential credential)
            : this(vaultUri, credential, null)
        {

        }

        public CertificateClient(Uri vaultUri, TokenCredential credential, CertificateClientOptions options)
        {
            vaultUri = vaultUri ?? throw new ArgumentNullException(nameof(credential));

            options ??= new CertificateClientOptions();

            var pipeline = HttpPipelineBuilder.Build(options, new ChallengeBasedAuthenticationPolicy(credential));

            _defaultPolicy = options.DefaultPolicy ?? CreateDefaultPolicy();

            _pipeline = new KeyVaultPipeline(vaultUri, options.GetVersionString(), pipeline);
        }

        // Certificates API

        // Uses default policy
        public virtual CertificateOperation StartCreateCertificate(string name, CancellationToken cancellationToken = default)
        {
            return this.StartCreateCertificate(name, _defaultPolicy, cancellationToken: cancellationToken);
        }

        // Uses default policy
        public virtual async Task<CertificateOperation> StartCreateCertificateAsync(string name, CancellationToken cancellationToken = default)
        {
            return await this.StartCreateCertificateAsync(name, _defaultPolicy, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public virtual CertificateOperation StartCreateCertificate(string name, CertificatePolicy policy, bool? enabled = default, IDictionary<string, string> tags = default, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");
            if (policy == null) throw new ArgumentNullException(nameof(policy));

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

        public virtual async Task<CertificateOperation> StartCreateCertificateAsync(string name, CertificatePolicy policy, bool? enabled = default, IDictionary<string, string> tags = default, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");
            if (policy == null) throw new ArgumentNullException(nameof(policy));

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

        public virtual Response<CertificateOperationProperties> GetPendingCertificate(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

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

        public virtual async Task<Response<CertificateOperationProperties>> GetPendingCertificateAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

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

        /// <summary>
        /// Returns the latest version of the <see cref="Certificate"/> along with it's <see cref="CertificatePolicy"/>. This operation requires the certificates/get permission.
        /// </summary>
        /// <param name="name">The name of the <see cref="Certificate"/> to retrieve</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A response containing the certificate and policy as a <see cref="CertificateWithPolicy"/> instance</returns>
        public virtual Response<CertificateWithPolicy> GetCertificateWithPolicy(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.GetCertificateWithPolicy");
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
        public virtual async Task<Response<CertificateWithPolicy>> GetCertificateWithPolicyAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.GetCertificateWithPolicy");
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
        public virtual Response<Certificate> GetCertificate(string name, string version, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.GetCertificate");
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
        public virtual async Task<Response<Certificate>> GetCertificateAsync(string name, string version, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");
            if (string.IsNullOrEmpty(version)) throw new ArgumentException($"{nameof(version)} can't be empty or null");

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.GetCertificate");
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
        /// <param name="name">The name of the <see cref="Certificate"/> to update</param>
        /// <param name="version">The version of the <see cref="Certificate"/> to update, if unspecified the latest version will be updated</param>
        /// <param name="enabled">Specifies whether the <see cref="Certificate"/> is enabled, if unspecified <see cref="CertificateBase.Enabled"/> remains unchanged</param>
        /// <param name="tags">Specifies the tags associated with the <see cref="Certificate"/>, if unspecified <see cref="CertificateBase.Tags"/> remains unchanged</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The updated <see cref="Certificate"/></returns>
        public virtual Response<Certificate> UpdateCertificate(string name, string version = default, bool enabled = default, IDictionary<string, string> tags = default, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            version = version ?? string.Empty;

            var parameters = new CertificateUpdateParameters(enabled, tags);

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.UpdateCertificate");
            scope.AddAttribute("certificate", name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Patch, parameters, () => new Certificate(), cancellationToken, CertificatesPath, name, "/", version);
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
        /// <param name="name">The name of the <see cref="Certificate"/> to update</param>
        /// <param name="version">The version of the <see cref="Certificate"/> to update, if unspecified the latest version will be updated</param>
        /// <param name="enabled">Specifies whether the <see cref="Certificate"/> is enabled, if unspecified <see cref="CertificateBase.Enabled"/> remains unchanged</param>
        /// <param name="tags">Specifies the tags associated with the <see cref="Certificate"/>, if unspecified <see cref="CertificateBase.Tags"/> remains unchanged</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>The updated <see cref="Certificate"/></returns>
        public virtual async Task<Response<Certificate>> UpdateCertificateAsync(string name, string version = default, bool enabled = default, IDictionary<string, string> tags = default, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            version = version ?? string.Empty;

            var parameters = new CertificateUpdateParameters(enabled, tags);

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.UpdateCertificate");
            scope.AddAttribute("certificate", name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Patch, parameters, () => new Certificate(), cancellationToken, CertificatesPath, name, "/", version).ConfigureAwait(false);
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
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

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
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

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

        public virtual Response<DeletedCertificate> GetDeletedCertificate(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

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

        public virtual async Task<Response<DeletedCertificate>> GetDeletedCertificateAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

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

        public virtual Response<CertificateWithPolicy> RecoverDeletedCertificate(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

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

        public virtual async Task<Response<CertificateWithPolicy>> RecoverDeletedCertificateAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

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

        public virtual Response PurgeDeletedCertificate(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

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

        public virtual async Task<Response> PurgeDeletedCertificateAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

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

        public virtual Response<byte[]> BackupCertificate(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.BackupCertificate");
            scope.AddAttribute("certificate", name);
            scope.Start();

            try
            {
                var backup = _pipeline.SendRequest(RequestMethod.Post, () => new CertificateBackup(), cancellationToken, CertificatesPath, name, "/backup");

                return new Response<byte[]>(backup.GetRawResponse(), backup.Value.Value);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<Response<byte[]>> BackupCertificateAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.BackupCertificate");
            scope.AddAttribute("certificate", name);
            scope.Start();

            try
            {
                var backup = await _pipeline.SendRequestAsync(RequestMethod.Post, () => new CertificateBackup(), cancellationToken, CertificatesPath, name, "/backup").ConfigureAwait(false);

                return new Response<byte[]>(backup.GetRawResponse(), backup.Value.Value);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Response<CertificateWithPolicy> RestoreCertificate(byte[] backup, CancellationToken cancellationToken = default)
        {
            if (backup == null) throw new ArgumentNullException(nameof(backup));

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

        public virtual async Task<Response<CertificateWithPolicy>> RestoreCertificateAsync(byte[] backup, CancellationToken cancellationToken = default)
        {
            if (backup == null) throw new ArgumentNullException(nameof(backup));

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

        public virtual Response<CertificateWithPolicy> ImportCertificate(CertificateImport import, CancellationToken cancellationToken = default)
        {
            if (import == null) throw new ArgumentNullException(nameof(import));
            if (string.IsNullOrEmpty(import.Name)) throw new ArgumentException($"{nameof(import.Name)} must not be null or empty");

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.ImportCertificate");
            scope.AddAttribute("certificate", import.Name);
            scope.Start();

            try
            {
                return _pipeline.SendRequest(RequestMethod.Post, import, () => new CertificateWithPolicy(), cancellationToken, CertificatesPath, "/", import.Name, "/import");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<Response<CertificateWithPolicy>> ImportCertificateAsync(CertificateImport import, CancellationToken cancellationToken = default)
        {
            if (import == null) throw new ArgumentNullException(nameof(import));
            if (string.IsNullOrEmpty(import.Name)) throw new ArgumentException($"{nameof(import.Name)} must not be null or empty");

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.ImportCertificate");
            scope.AddAttribute("certificate", import.Name);
            scope.Start();

            try
            {
                return await _pipeline.SendRequestAsync(RequestMethod.Post, import, () => new CertificateWithPolicy(), cancellationToken, CertificatesPath, "/", import.Name, "/import").ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual IEnumerable<Response<CertificateBase>> GetCertificates(bool? includePending = default, CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = includePending.HasValue ? _pipeline.CreateFirstPageUri(CertificatesPath, new ValueTuple<string, string>("includePending", includePending.Value.ToString(CultureInfo.InvariantCulture).ToLowerInvariant())) : _pipeline.CreateFirstPageUri(CertificatesPath);

            return PageResponseEnumerator.CreateEnumerable(nextLink => _pipeline.GetPage(firstPageUri, nextLink, () => new CertificateBase(), "Azure.Security.KeyVault.Keys.KeyClient.GetCertificates", cancellationToken));
        }

        public virtual IAsyncEnumerable<Response<CertificateBase>> GetCertificatesAsync(bool? includePending = default, CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = includePending.HasValue ? _pipeline.CreateFirstPageUri(CertificatesPath, new ValueTuple<string, string>("includePending", includePending.Value.ToString(CultureInfo.InvariantCulture).ToLowerInvariant())) : _pipeline.CreateFirstPageUri(CertificatesPath);

            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => _pipeline.GetPageAsync(firstPageUri, nextLink, () => new CertificateBase(), "Azure.Security.KeyVaultCertificates.CertificateClient.GetCertificates", cancellationToken));
        }

        public virtual IEnumerable<Response<CertificateBase>> GetCertificateVersions(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            Uri firstPageUri = _pipeline.CreateFirstPageUri($"{CertificatesPath}{name}/versions");

            return PageResponseEnumerator.CreateEnumerable(nextLink => _pipeline.GetPage(firstPageUri, nextLink, () => new CertificateBase(), "Azure.Security.KeyVaultCertificates.CertificateClient.GetCertificateVersions", cancellationToken));
        }

        public virtual IAsyncEnumerable<Response<CertificateBase>> GetCertificateVersionsAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

            Uri firstPageUri = _pipeline.CreateFirstPageUri($"{CertificatesPath}{name}/versions");

            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => _pipeline.GetPageAsync(firstPageUri, nextLink, () => new CertificateBase(), "Azure.Security.KeyVaultCertificates.CertificateClient.GetCertificateVersions", cancellationToken));
        }

        public virtual IEnumerable<Response<DeletedCertificate>> GetDeletedCertificates(string name, CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = _pipeline.CreateFirstPageUri(DeletedCertificatesPath);

            return PageResponseEnumerator.CreateEnumerable(nextLink => _pipeline.GetPage(firstPageUri, nextLink, () => new DeletedCertificate(), "Azure.Security.KeyVaultCertificates.CertificateClient.GetDeletedCertificates", cancellationToken));
        }

        public virtual IAsyncEnumerable<Response<DeletedCertificate>> GetDeletedCertificatesAsync(string name, CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = _pipeline.CreateFirstPageUri(DeletedCertificatesPath);

            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => _pipeline.GetPageAsync(firstPageUri, nextLink, () => new DeletedCertificate(), "Azure.Security.KeyVaultCertificates.CertificateClient.GetDeletedCertificates", cancellationToken));
        }

        // Policy
        public virtual Response<CertificatePolicy> GetCertificatePolicy(string certificateName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(certificateName)) throw new ArgumentException($"{nameof(certificateName)} can't be empty or null");

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

        public virtual async Task<Response<CertificatePolicy>> GetCertificatePolicyAsync(string certificateName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(certificateName)) throw new ArgumentException($"{nameof(certificateName)} can't be empty or null");

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

        public virtual Response<CertificatePolicy> UpdateCertificatePolicy(string certificateName, CertificatePolicy policy, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(certificateName)) throw new ArgumentException($"{nameof(certificateName)} can't be empty or null");

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

        public virtual async Task<Response<CertificatePolicy>> UpdateCertificatePolicyAsync(string certificateName, CertificatePolicy policy, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(certificateName)) throw new ArgumentException($"{nameof(certificateName)} can't be empty or null");

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

        // Issuer
        public virtual Response<Issuer> CreateIssuer(Issuer issuer, CancellationToken cancellationToken = default)
        {
            if (issuer == null) throw new ArgumentNullException(nameof(issuer));

            if (string.IsNullOrEmpty(issuer.Name)) throw new ArgumentException($"{nameof(issuer.Name)} can't be empty or null");

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

        public virtual async Task<Response<Issuer>> CreateIssuerAsync(Issuer issuer, CancellationToken cancellationToken = default)
        {
            if (issuer == null) throw new ArgumentNullException(nameof(issuer));

            if (string.IsNullOrEmpty(issuer.Name)) throw new ArgumentException($"{nameof(issuer.Name)} can't be empty or null");

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

        public virtual Response<Issuer> GetIssuer(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

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

        public virtual async Task<Response<Issuer>> GetIssuerAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

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

        public virtual Response<Issuer> UpdateIssuer(Issuer issuer, CancellationToken cancellationToken = default)
        {
            if (issuer == null) throw new ArgumentNullException(nameof(issuer));

            if (string.IsNullOrEmpty(issuer.Name)) throw new ArgumentException($"{nameof(issuer.Name)} can't be empty or null");

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

        public virtual async Task<Response<Issuer>> UpdateIssuerAsync(Issuer issuer, CancellationToken cancellationToken = default)
        {
            if (issuer == null) throw new ArgumentNullException(nameof(issuer));

            if (string.IsNullOrEmpty(issuer.Name)) throw new ArgumentException($"{nameof(issuer.Name)} can't be empty or null");

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

        public virtual Response<Issuer> DeleteIssuer(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

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

        public virtual async Task<Response<Issuer>> DeleteIssuerAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException($"{nameof(name)} can't be empty or null");

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

        public virtual IEnumerable<Response<IssuerBase>> GetIssuers(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = _pipeline.CreateFirstPageUri(IssuersPath);

            return PageResponseEnumerator.CreateEnumerable(nextLink => _pipeline.GetPage(firstPageUri, nextLink, () => new IssuerBase(), "Azure.Security.KeyVaultCertificates.CertificateClient.GetIssuers", cancellationToken));
        }

        public virtual IAsyncEnumerable<Response<IssuerBase>> GetIssuersAsync(CancellationToken cancellationToken = default)
        {
            Uri firstPageUri = _pipeline.CreateFirstPageUri(IssuersPath);

            return PageResponseEnumerator.CreateAsyncEnumerable(nextLink => _pipeline.GetPageAsync(firstPageUri, nextLink, () => new IssuerBase(), "Azure.Security.KeyVaultCertificates.CertificateClient.GetIssuers", cancellationToken));
        }

        // Operations
        public virtual CertificateOperation GetCertificateOperation(string certificateName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(certificateName)) throw new ArgumentException($"{nameof(certificateName)} can't be empty or null");

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

        public virtual async Task<CertificateOperation> GetCertificateOperationAsync(string certificateName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(certificateName)) throw new ArgumentException($"{nameof(certificateName)} can't be empty or null");

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

        public virtual CertificateOperation DeleteCertificateOperation(string certificateName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(certificateName)) throw new ArgumentException($"{nameof(certificateName)} can't be empty or null");

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

        public virtual async Task<CertificateOperation> DeleteCertificateOperationAsync(string certificateName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(certificateName)) throw new ArgumentException($"{nameof(certificateName)} can't be empty or null");

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

        public virtual CertificateOperation CancelCertificateOperation(string certificateName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(certificateName)) throw new ArgumentException($"{nameof(certificateName)} can't be empty or null");

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

        public virtual async Task<CertificateOperation> CancelCertificateOperationAsync(string certificateName, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(certificateName)) throw new ArgumentException($"{nameof(certificateName)} can't be empty or null");

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

        // Contacts
        public virtual Response<IList<Contact>> SetContacts(IEnumerable<Contact> contacts, CancellationToken cancellationToken = default)
        {
            if (contacts == null) throw new ArgumentNullException(nameof(contacts));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.SetContacts");
            scope.Start();

            try
            {
                Response<ContactList> contactList = _pipeline.SendRequest(RequestMethod.Put, new ContactList(contacts), () => new ContactList(), cancellationToken, ContactsPath);

                return new Response<IList<Contact>>(contactList.GetRawResponse(), contactList.Value.ToList());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<Response<IList<Contact>>> SetContactsAsync(IEnumerable<Contact> contacts, CancellationToken cancellationToken = default)
        {
            if (contacts == null) throw new ArgumentNullException(nameof(contacts));

            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.SetContacts");
            scope.Start();

            try
            {
                Response<ContactList> contactList = await _pipeline.SendRequestAsync(RequestMethod.Put, new ContactList(contacts), () => new ContactList(), cancellationToken, ContactsPath).ConfigureAwait(false);

                return new Response<IList<Contact>>(contactList.GetRawResponse(), contactList.Value.ToList());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Response<IList<Contact>> GetContacts(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.GetContacts");
            scope.Start();

            try
            {
                Response<ContactList> contactList = _pipeline.SendRequest(RequestMethod.Get, () => new ContactList(), cancellationToken, ContactsPath);

                return new Response<IList<Contact>>(contactList.GetRawResponse(), contactList.Value.ToList());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<Response<IList<Contact>>> GetContactsAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.GetContacts");
            scope.Start();

            try
            {
                Response<ContactList> contactList = await _pipeline.SendRequestAsync(RequestMethod.Get, () => new ContactList(), cancellationToken, ContactsPath).ConfigureAwait(false);

                return new Response<IList<Contact>>(contactList.GetRawResponse(), contactList.Value.ToList());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual Response<IList<Contact>> DeleteContacts(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.DeleteContacts");
            scope.Start();

            try
            {
                Response<ContactList> contactList = _pipeline.SendRequest(RequestMethod.Delete, () => new ContactList(), cancellationToken, ContactsPath);

                return new Response<IList<Contact>>(contactList.GetRawResponse(), contactList.Value.ToList());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        public virtual async Task<Response<IList<Contact>>> DeleteContactsAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _pipeline.CreateScope("Azure.Security.KeyVault.Certificates.CertificateClient.DeleteContacts");
            scope.Start();

            try
            {
                Response<ContactList> contactList = await _pipeline.SendRequestAsync(RequestMethod.Delete, () => new ContactList(), cancellationToken, ContactsPath).ConfigureAwait(false);

                return new Response<IList<Contact>>(contactList.GetRawResponse(), contactList.Value.ToList());
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
                KeyOptions = new RsaKeyOptions(false)
                {
                    Exportable = true,
                    ReuseKey = false
                },
                KeyUsage = new[]
                {
                    KeyUsage.CrlSign,
                    KeyUsage.DataEncipherment,
                    KeyUsage.DigitalSignature,
                    KeyUsage.KeyEncipherment,
                    KeyUsage.KeyAgreement,
                    KeyUsage.KeyCertSign
                },
                CertificateTransparency = false,
                ContentType = CertificateContentType.Pkcs12
            };

            return policy;
        }
    }
}
