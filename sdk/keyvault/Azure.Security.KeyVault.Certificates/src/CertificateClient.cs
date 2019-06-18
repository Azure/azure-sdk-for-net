// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.Pipeline.Policies;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Security.KeyVault.Certificates
{
    public class CertificateClient
    {
        private readonly Uri _vaultUri;
        private const string ApiVersion = "7.0";
        private readonly HttpPipeline _pipeline;

        protected CertificateClient()
        {

        }
        public CertificateClient(Uri vaultUri, TokenCredential credential)
            : this(vaultUri, credential, null)
        {

        }

        public CertificateClient(Uri vaultUri, TokenCredential credential, CertificateClientOptions options)
        {
            _vaultUri = vaultUri ?? throw new ArgumentNullException(nameof(credential));
            options = options ?? new CertificateClientOptions();

            _pipeline = HttpPipelineBuilder.Build(options,
                    bufferResponse: true,
                    new BearerTokenAuthenticationPolicy(credential, "https://vault.azure.net/.default"));
        }

        // Certificates API

        // Uses default policy
        public virtual Response<CertificateOperation> CreateCertificate(string name, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        // Uses default policy
        public virtual async Task<Response<CertificateOperation>> CreateCertificateAsync(string name, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual Response<CertificateOperation> CreateCertificate(Certificate certificate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<CertificateOperation>> CreateCertificateAsync(Certificate certificate, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual Response<Certificate> GetCertificate(string name, string version = default, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<Certificate>> GetCertificateAsync(string name, string version = default, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual Response<Certificate> UpdateCertificate(bool enabled = default, Dictionary<string, string> tags = default, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<Certificate>> UpdateCertificateAsync(bool enabled = default, Dictionary<string, string> tags = default, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual Response<DeletedCertificate> DeleteCertificate(string name, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<DeletedCertificate>> DeleteCertificateAsync(string name, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual async Task<Response<DeletedCertificate>> GetDeletedCertificateAsync(string name, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual Response<DeletedCertificate> GetDeletedCertificate(string name, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual Response<Certificate> RecoverDeletedCertificate(string name, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<Certificate>> RecoverDeletedCertificateAsync(string name, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual Response PurgeDeletedCertificate(string name, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response> PurgeDeletedCertificateAsync(string name, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual Response<byte[]> BackupCertificate(string name, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<byte[]>> BackupCertificateAsync(string name, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual Response<Certificate> RestoreCertificate(byte [] backup, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<Certificate>> RestoreCertificateAsync(byte[] backup, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual Response<Certificate> ImportCertificate(string name, string value, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<Certificate>> ImportCertificateAsync(string name, string value, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual Response<Certificate> ImportCertificate(CertificateImport certificateImport, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<Certificate>> ImportCertificateAsync(CertificateImport certificateImport, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual Response<byte[]> GetPendingCertificateSigningRequest(string name, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<byte[]>> GetPendingCertificateSigningRequestAsync(string name, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual IAsyncEnumerable<Response<CertificateBase>> GetCertificatesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<Response<CertificateBase>> GetCertificates(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual IAsyncEnumerable<Response<CertificateBase>> GetCertificateVersionsAsync(string name, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<Response<CertificateBase>> GetCertificateVersions(string name, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual IAsyncEnumerable<Response<CertificateBase>> GetDeletedCertificatesAsync(string name, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<Response<CertificateBase>> GetDeletedCertificates(string name, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        // Policy
        public virtual Response<CertificateBase> GetCertificatePolicy(string certificateName, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<CertificateBase>> GetCertificatePolicyAsync(string certificateName, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual Response<CertificateBase> UpdateCertificatePolicy(string certificateName, CertificatePolicy policy, CertificateBase certificateBase, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<CertificateBase>> UpdateCertificatePolicyAsync(string certificateName, CertificatePolicy policy, CertificateBase certificateBase, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        // Issuer
        public virtual Response<Issuer> CreateIssuer(string name, string provider, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<Issuer>> CreateIssuerAsync(string name, string provider, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual Response<Issuer> CreateIssuer(Issuer issuer, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<Issuer>> CreateIssuerAsync(Issuer issuer, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual Response<Issuer> GetIssuer(string name, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<Issuer>> GetIssuerAsync(string name, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual Response<Issuer> DeleteIssuer(string name, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<Issuer>> DeleteIssuerAsync(string name, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual Response<Issuer> UpdateIssuer(Issuer issuer, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<Issuer>> UpdateIssuerAsync(Issuer issuer, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual IAsyncEnumerable<Response<IssuerBase>> GetIssuersAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<Response<IssuerBase>> GetIssuers(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        // Operations
        public virtual Response<CertificateOperation> GetCertificateOperation(string certificateName, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<CertificateOperation>> GetCertificateOperationAsync(string certificateName, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual Response<CertificateOperation> DeleteCertificateOperation(string certificateName, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<CertificateOperation>> DeleteCertificateOperationAsync(string certificateName, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public virtual Response<CertificateOperation> CancelCertificateOperation(string certificateName, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<Response<CertificateOperation>> CancelCertificateOperationAsync(string certificateName, CancellationToken cancellationToken = default)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        // Contacts
        public virtual IEnumerable<Response<Contact>> CreateContacts(IEnumerable<Contact> contacts, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual IAsyncEnumerable<Response<Contact>> CreateContactsAsync(IEnumerable<Contact> contacts, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<Response<Contact>> GetContacts(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual IAsyncEnumerable<Response<Contact>> GetContactsAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<Response<Contact>> DeleteContacts(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public virtual IAsyncEnumerable<Response<Contact>> DeleteContactsAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
