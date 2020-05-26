// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Security.KeyVault.Certificates
{
    /// <summary>
    /// Model factory that enables mocking for the Key Vault Certificates library.
    /// </summary>
    public static class CertificateModelFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Certificates.IssuerProperties"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="Certificates.IssuerProperties.Id"/> property.</param>
        /// <param name="name">Sets the <see cref="Certificates.IssuerProperties.Name"/> property.</param>
        /// <returns>A new instance of the <see cref="Certificates.IssuerProperties"/> for mocking purposes.</returns>
        public static IssuerProperties IssuerProperties(
            Uri id = default,
            string name = default) => new IssuerProperties
            {
                Id = id,
                Name = name,
            };

        /// <summary>
        /// Initializes a new instance of the <see cref="Certificates.CertificateIssuer"/> for mocking purposes.
        /// </summary>
        /// <param name="properties">Sets the <see cref="Certificates.CertificateIssuer.Id"/>, <see cref="Certificates.CertificateIssuer.Name"/>, and <see cref="Certificates.CertificateIssuer.Provider"/> properties.</param>
        /// <param name="createdOn">Sets the <see cref="Certificates.CertificateIssuer.CreatedOn"/> property.</param>
        /// <param name="updatedOn">Sets the <see cref="Certificates.CertificateIssuer.UpdatedOn"/> property.</param>
        /// <returns>A new instance of the <see cref="Certificates.CertificateIssuer"/> for mocking purposes.</returns>
        public static CertificateIssuer CertificateIssuer(
            IssuerProperties properties,
            DateTimeOffset? createdOn = default,
            DateTimeOffset? updatedOn = default) => new CertificateIssuer(properties)
            {
                CreatedOn = createdOn,
                UpdatedOn = updatedOn,
            };

        // TODO: How should we support CertificateOperation?

        /// <summary>
        /// Initializes a new instance of the <see cref="Certificates.CertificateOperationError"/> for mocking purposes.
        /// </summary>
        /// <param name="code">Sets the <see cref="Certificates.CertificateOperationError.Code"/> property.</param>
        /// <param name="message">Sets the <see cref="Certificates.CertificateOperationError.Message"/> property.</param>
        /// <param name="innerError">Sets the <see cref="Certificates.CertificateOperationError.InnerError"/> property.</param>
        /// <returns>A new instance of the <see cref="Certificates.CertificateOperationError"/> for mocking purposes.</returns>
        public static CertificateOperationError CertificateOperationError(
            string code = default,
            string message = default,
            CertificateOperationError innerError = default) => new CertificateOperationError
            {
                Code = code,
                Message = message,
                InnerError = innerError,
            };

        /// <summary>
        /// Initializes a new instance of the <see cref="Certificates.CertificateOperationProperties"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="Certificates.CertificateOperationProperties.Id"/> property.</param>
        /// <param name="name">Sets the <see cref="Certificates.CertificateOperationProperties.Name"/> property.</param>
        /// <param name="vaultUri">Sets the <see cref="Certificates.CertificateOperationProperties.VaultUri"/> property.</param>
        /// <param name="issuerName">Sets the <see cref="Certificates.CertificateOperationProperties.IssuerName"/> property.</param>
        /// <param name="certificateType">Sets the <see cref="Certificates.CertificateOperationProperties.CertificateType"/> property.</param>
        /// <param name="certificateTransparency">Sets the <see cref="Certificates.CertificateOperationProperties.CertificateTransparency"/> property.</param>
        /// <param name="csr">Sets the <see cref="Certificates.CertificateOperationProperties.Csr"/> property.</param>
        /// <param name="cancellationRequested">Sets the <see cref="Certificates.CertificateOperationProperties.CancellationRequested"/> property.</param>
        /// <param name="requestId">Sets the <see cref="Certificates.CertificateOperationProperties.RequestId"/> property.</param>
        /// <param name="status">Sets the <see cref="Certificates.CertificateOperationProperties.Status"/> property.</param>
        /// <param name="statusDetails">Sets the <see cref="Certificates.CertificateOperationProperties.StatusDetails"/> property.</param>
        /// <param name="target">Sets the <see cref="Certificates.CertificateOperationProperties.Target"/> property.</param>
        /// <param name="error">Sets the <see cref="Certificates.CertificateOperationProperties.Error"/> property.</param>
        /// <returns>A new instance of the <see cref="Certificates.CertificateOperationProperties"/> for mocking purposes.</returns>
        public static CertificateOperationProperties CertificateOperationProperties(
            Uri id = default,
            string name = default,
            Uri vaultUri = default,
            string issuerName = default,
            string certificateType = default,
            bool? certificateTransparency = default,
            byte[] csr = default,
            bool cancellationRequested = default,
            string requestId = default,
            string status = default,
            string statusDetails = default,
            string target = default,
            CertificateOperationError error = default) => new CertificateOperationProperties
            {
                Id = id,
                Name = name,
                VaultUri = vaultUri,
                IssuerName = issuerName,
                CertificateType = certificateType,
                CertificateTransparency = certificateTransparency,
                Csr = csr,
                CancellationRequested = cancellationRequested,
                RequestId = requestId,
                Status = status,
                StatusDetails = statusDetails,
                Target = target,
                Error = error,
            };

        /// <summary>
        /// Initializes a new instance of the <see cref="Certificates.CertificatePolicy"/> for mocking purposes.
        /// </summary>
        /// <param name="subject">Sets the <see cref="Certificates.CertificatePolicy.Subject"/> property.</param>
        /// <param name="subjectAlternativeNames">Sets the <see cref="Certificates.CertificatePolicy.SubjectAlternativeNames"/> property.</param>
        /// <param name="issuerName">Sets the <see cref="Certificates.CertificatePolicy.IssuerName"/> property.</param>
        /// <param name="createdOn">Sets the <see cref="Certificates.CertificatePolicy.CreatedOn"/> property.</param>
        /// <param name="updatedOn">Sets the <see cref="Certificates.CertificatePolicy.UpdatedOn"/> property.</param>
        /// <returns>A new instance of the <see cref="Certificates.CertificatePolicy"/> for mocking purposes.</returns>
        public static CertificatePolicy CertificatePolicy(
            string subject = default,
            SubjectAlternativeNames subjectAlternativeNames = default,
            string issuerName = default,
            DateTimeOffset? createdOn = default,
            DateTimeOffset? updatedOn = default) => new CertificatePolicy
            {
                Subject = subject,
                SubjectAlternativeNames = subjectAlternativeNames,
                IssuerName = issuerName,
                CreatedOn = createdOn,
                UpdatedOn = updatedOn,
            };

        /// <summary>
        /// Initializes a new instance of the <see cref="Certificates.CertificateProperties"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="Certificates.CertificateProperties.Id"/> property.</param>
        /// <param name="name">Sets the <see cref="Certificates.CertificateProperties.Name"/> property.</param>
        /// <param name="vaultUri">Sets the <see cref="Certificates.CertificateProperties.VaultUri"/> property.</param>
        /// <param name="version">Sets the <see cref="Certificates.CertificateProperties.Version"/> property.</param>
        /// <param name="x509thumbprint">Sets the <see cref="Certificates.CertificateProperties.X509Thumbprint"/> property.</param>
        /// <param name="notBefore">Sets the <see cref="Certificates.CertificateProperties.NotBefore"/> property.</param>
        /// <param name="expiresOn">Sets the <see cref="Certificates.CertificateProperties.ExpiresOn"/> property.</param>
        /// <param name="createdOn">Sets the <see cref="Certificates.CertificateProperties.CreatedOn"/> property.</param>
        /// <param name="updatedOn">Sets the <see cref="Certificates.CertificateProperties.UpdatedOn"/> property.</param>
        /// <param name="recoveryLevel">Sets the <see cref="Certificates.CertificateProperties.RecoveryLevel"/> property.</param>
        /// <returns>A new instance of the <see cref="Certificates.CertificateProperties"/> for mocking purposes.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CertificateProperties CertificateProperties(
            Uri id,
            string name,
            Uri vaultUri,
            string version,
            byte[] x509thumbprint,
            DateTimeOffset? notBefore,
            DateTimeOffset? expiresOn,
            DateTimeOffset? createdOn,
            DateTimeOffset? updatedOn,
            string recoveryLevel) => CertificateProperties(
                id,
                name,
                vaultUri,
                version,
                x509thumbprint,
                notBefore,
                expiresOn,
                createdOn,
                updatedOn,
                recoveryLevel,
                default);

        /// <summary>
        /// Initializes a new instance of the <see cref="Certificates.CertificateProperties"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="Certificates.CertificateProperties.Id"/> property.</param>
        /// <param name="name">Sets the <see cref="Certificates.CertificateProperties.Name"/> property.</param>
        /// <param name="vaultUri">Sets the <see cref="Certificates.CertificateProperties.VaultUri"/> property.</param>
        /// <param name="version">Sets the <see cref="Certificates.CertificateProperties.Version"/> property.</param>
        /// <param name="x509thumbprint">Sets the <see cref="Certificates.CertificateProperties.X509Thumbprint"/> property.</param>
        /// <param name="notBefore">Sets the <see cref="Certificates.CertificateProperties.NotBefore"/> property.</param>
        /// <param name="expiresOn">Sets the <see cref="Certificates.CertificateProperties.ExpiresOn"/> property.</param>
        /// <param name="createdOn">Sets the <see cref="Certificates.CertificateProperties.CreatedOn"/> property.</param>
        /// <param name="updatedOn">Sets the <see cref="Certificates.CertificateProperties.UpdatedOn"/> property.</param>
        /// <param name="recoveryLevel">Sets the <see cref="Certificates.CertificateProperties.RecoveryLevel"/> property.</param>
        /// <param name="recoverableDays">Sets the <see cref="Certificates.CertificateProperties.RecoverableDays"/> property.</param>
        /// <returns>A new instance of the <see cref="Certificates.CertificateProperties"/> for mocking purposes.</returns>
        public static CertificateProperties CertificateProperties(
            Uri id = default,
            string name = default,
            Uri vaultUri = default,
            string version = default,
            byte[] x509thumbprint = default,
            DateTimeOffset? notBefore = default,
            DateTimeOffset? expiresOn = default,
            DateTimeOffset? createdOn = default,
            DateTimeOffset? updatedOn = default,
            string recoveryLevel = default,
            int? recoverableDays = default) => new CertificateProperties
            {
                Id = id,
                Name = name,
                VaultUri = vaultUri,
                Version = version,
                X509Thumbprint = x509thumbprint,
                NotBefore = notBefore,
                ExpiresOn = expiresOn,
                CreatedOn = createdOn,
                UpdatedOn = updatedOn,
                RecoveryLevel = recoveryLevel,
                RecoverableDays = recoverableDays,
            };

        /// <summary>
        /// Initializes a new instance of the <see cref="Certificates.DeletedCertificate"/> for mocking purposes.
        /// </summary>
        /// <param name="properties">Sets the <see cref="Certificates.KeyVaultCertificate.Properties"/> property.</param>
        /// <param name="keyId">Sets the <see cref="Certificates.KeyVaultCertificate.KeyId"/> property.</param>
        /// <param name="secretId">Sets the <see cref="Certificates.KeyVaultCertificate.SecretId"/> property.</param>
        /// <param name="cer">Sets the <see cref="Certificates.KeyVaultCertificate.Cer"/> property.</param>
        /// <param name="policy">Sets the <see cref="Certificates.KeyVaultCertificateWithPolicy.Policy"/> property.</param>
        /// <param name="recoveryId">Sets the <see cref="Certificates.DeletedCertificate.RecoveryId"/> property.</param>
        /// <param name="deletedOn">Sets the <see cref="Certificates.DeletedCertificate.DeletedOn"/> property.</param>
        /// <param name="scheduledPurgeDate">Sets the <see cref="Certificates.DeletedCertificate.ScheduledPurgeDate"/> property.</param>
        /// <returns>A new instance of the <see cref="Certificates.DeletedCertificate"/> for mocking purposes.</returns>
        public static DeletedCertificate DeletedCertificate(
            CertificateProperties properties,
            Uri keyId = default,
            Uri secretId = default,
            byte[] cer = default,
            CertificatePolicy policy = default,
            Uri recoveryId = default,
            DateTimeOffset? deletedOn = default,
            DateTimeOffset? scheduledPurgeDate = default) => new DeletedCertificate(properties)
            {
                KeyId = keyId,
                SecretId = secretId,
                Cer = cer,
                Policy = policy,
                RecoveryId = recoveryId,
                DeletedOn = deletedOn,
                ScheduledPurgeDate = scheduledPurgeDate,
            };

        /// <summary>
        /// Initializes a new instance of the <see cref="Certificates.KeyVaultCertificate"/> for mocking purposes.
        /// </summary>
        /// <param name="properties">Sets the <see cref="Certificates.KeyVaultCertificate.Properties"/> property.</param>
        /// <param name="keyId">Sets the <see cref="Certificates.KeyVaultCertificate.KeyId"/> property.</param>
        /// <param name="secretId">Sets the <see cref="Certificates.KeyVaultCertificate.SecretId"/> property.</param>
        /// <param name="cer">Sets the <see cref="Certificates.KeyVaultCertificate.Cer"/> property.</param>
        /// <returns>A new instance of the <see cref="Certificates.KeyVaultCertificate"/> for mocking purposes.</returns>
        public static KeyVaultCertificate KeyVaultCertificate(
            CertificateProperties properties,
            Uri keyId = default,
            Uri secretId = default,
            byte[] cer = default) => new KeyVaultCertificate(properties)
            {
                KeyId = keyId,
                SecretId = secretId,
                Cer = cer,
            };

        /// <summary>
        /// Initializes a new instance of the <see cref="Certificates.KeyVaultCertificateWithPolicy"/> for mocking purposes.
        /// </summary>
        /// <param name="properties">Sets the <see cref="Certificates.KeyVaultCertificate.Properties"/> property.</param>
        /// <param name="keyId">Sets the <see cref="Certificates.KeyVaultCertificate.KeyId"/> property.</param>
        /// <param name="secretId">Sets the <see cref="Certificates.KeyVaultCertificate.SecretId"/> property.</param>
        /// <param name="cer">Sets the <see cref="Certificates.KeyVaultCertificate.Cer"/> property.</param>
        /// <param name="policy">Sets the <see cref="Certificates.KeyVaultCertificateWithPolicy.Policy"/> property.</param>
        /// <returns>A new instance of the <see cref="Certificates.KeyVaultCertificateWithPolicy"/> for mocking purposes.</returns>
        public static KeyVaultCertificateWithPolicy KeyVaultCertificateWithPolicy(
            CertificateProperties properties,
            Uri keyId = default,
            Uri secretId = default,
            byte[] cer = default,
            CertificatePolicy policy = default) => new KeyVaultCertificateWithPolicy(properties)
            {
                KeyId = keyId,
                SecretId = secretId,
                Cer = cer,
                Policy = policy,
            };
    }
}
