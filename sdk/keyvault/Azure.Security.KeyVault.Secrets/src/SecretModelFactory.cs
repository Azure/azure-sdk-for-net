// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Security.KeyVault.Secrets
{
    /// <summary>
    /// Model factory that enables mocking for the Key Vault Secrets library.
    /// </summary>
    public static class SecretModelFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Secrets.SecretProperties"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="Secrets.SecretProperties.Id"/> property.</param>
        /// <param name="vaultUri">Sets the <see cref="Secrets.SecretProperties.VaultUri"/> property.</param>
        /// <param name="name">Sets the <see cref="Secrets.SecretProperties.Name"/> property.</param>
        /// <param name="version">Sets the <see cref="Secrets.SecretProperties.Version"/> property.</param>
        /// <param name="managed">Sets the <see cref="Secrets.SecretProperties.Managed"/> property.</param>
        /// <param name="keyId">Sets the <see cref="Secrets.SecretProperties.KeyId"/> property.</param>
        /// <param name="createdOn">Sets the <see cref="Secrets.SecretProperties.CreatedOn"/> property.</param>
        /// <param name="updatedOn">Sets the <see cref="Secrets.SecretProperties.UpdatedOn"/> property.</param>
        /// <param name="recoveryLevel">Sets the <see cref="Secrets.SecretProperties.RecoveryLevel"/> property.</param>
        /// <returns>A new instance of the <see cref="Secrets.SecretProperties"/> for mocking purposes.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SecretProperties SecretProperties(
            Uri id,
            Uri vaultUri,
            string name,
            string version,
            bool managed,
            Uri keyId,
            DateTimeOffset? createdOn,
            DateTimeOffset? updatedOn,
            string recoveryLevel) => SecretProperties(
                id,
                vaultUri,
                name,
                version,
                managed,
                keyId,
                createdOn,
                updatedOn,
                recoveryLevel,
                default);

        /// <summary>
        /// Initializes a new instance of the <see cref="Secrets.SecretProperties"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="Secrets.SecretProperties.Id"/> property.</param>
        /// <param name="vaultUri">Sets the <see cref="Secrets.SecretProperties.VaultUri"/> property.</param>
        /// <param name="name">Sets the <see cref="Secrets.SecretProperties.Name"/> property.</param>
        /// <param name="version">Sets the <see cref="Secrets.SecretProperties.Version"/> property.</param>
        /// <param name="managed">Sets the <see cref="Secrets.SecretProperties.Managed"/> property.</param>
        /// <param name="keyId">Sets the <see cref="Secrets.SecretProperties.KeyId"/> property.</param>
        /// <param name="createdOn">Sets the <see cref="Secrets.SecretProperties.CreatedOn"/> property.</param>
        /// <param name="updatedOn">Sets the <see cref="Secrets.SecretProperties.UpdatedOn"/> property.</param>
        /// <param name="recoveryLevel">Sets the <see cref="Secrets.SecretProperties.RecoveryLevel"/> property.</param>
        /// <param name="recoverableDays">Sets the <see cref="Secrets.SecretProperties.RecoverableDays"/> property.</param>
        /// <returns>A new instance of the <see cref="Secrets.SecretProperties"/> for mocking purposes.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SecretProperties SecretProperties(
            Uri id,
            Uri vaultUri,
            string name,
            string version,
            bool managed,
            Uri keyId,
            DateTimeOffset? createdOn,
            DateTimeOffset? updatedOn,
            string recoveryLevel,
            int? recoverableDays) => SecretProperties(
                id,
                vaultUri,
                name,
                version,
                managed,
                keyId,
                createdOn,
                updatedOn,
                recoveryLevel,
                recoverableDays,
                default);

        /// <summary>
        /// Initializes a new instance of the <see cref="Secrets.SecretProperties"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="Secrets.SecretProperties.Id"/> property.</param>
        /// <param name="vaultUri">Sets the <see cref="Secrets.SecretProperties.VaultUri"/> property.</param>
        /// <param name="name">Sets the <see cref="Secrets.SecretProperties.Name"/> property.</param>
        /// <param name="version">Sets the <see cref="Secrets.SecretProperties.Version"/> property.</param>
        /// <param name="managed">Sets the <see cref="Secrets.SecretProperties.Managed"/> property.</param>
        /// <param name="keyId">Sets the <see cref="Secrets.SecretProperties.KeyId"/> property.</param>
        /// <param name="createdOn">Sets the <see cref="Secrets.SecretProperties.CreatedOn"/> property.</param>
        /// <param name="updatedOn">Sets the <see cref="Secrets.SecretProperties.UpdatedOn"/> property.</param>
        /// <param name="recoveryLevel">Sets the <see cref="Secrets.SecretProperties.RecoveryLevel"/> property.</param>
        /// <param name="recoverableDays">Sets the <see cref="Secrets.SecretProperties.RecoverableDays"/> property.</param>
        /// <param name="previousVersion"> Sets the <see cref="Secrets.SecretProperties.PreviousVersion"/> property.</param>
        /// <returns>A new instance of the <see cref="Secrets.SecretProperties"/> for mocking purposes.</returns>
        public static SecretProperties SecretProperties(
            Uri id = default,
            Uri vaultUri = default,
            string name = default,
            string version = default,
            bool managed = default,
            Uri keyId = default,
            DateTimeOffset? createdOn = default,
            DateTimeOffset? updatedOn = default,
            string recoveryLevel = default,
            int? recoverableDays = default,
            string previousVersion = default)
        {
            return new SecretProperties
            {
                Id = id,
                VaultUri = vaultUri,
                Name = name,
                Version = version,
                Managed = managed,
                KeyId = keyId,
                CreatedOn = createdOn,
                UpdatedOn = updatedOn,
                RecoveryLevel = recoveryLevel,
                RecoverableDays = recoverableDays,
                PreviousVersion = previousVersion
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Secrets.KeyVaultSecret"/> for mocking purposes.
        /// </summary>
        /// <param name="properties">Sets the <see cref="Secrets.KeyVaultSecret.Properties"/> property, which provides the <see cref="Secrets.KeyVaultSecret.Id"/> and <see cref="Secrets.KeyVaultSecret.Name"/> properties.</param>
        /// <param name="value">Sets the <see cref="Secrets.KeyVaultSecret.Value"/> property.</param>
        /// <returns>A new instance of the <see cref="Secrets.KeyVaultSecret"/> for mocking purposes.</returns>
        public static KeyVaultSecret KeyVaultSecret(SecretProperties properties, string value = default) => new KeyVaultSecret(properties)
        {
            Value = value,
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="Secrets.DeletedSecret"/> for mocking purposes.
        /// </summary>
        /// <param name="properties">Sets the <see cref="Secrets.KeyVaultSecret.Properties"/> property, which provides the <see cref="Secrets.KeyVaultSecret.Id"/> and <see cref="Secrets.KeyVaultSecret.Name"/> properties.</param>
        /// <param name="value">Sets the <see cref="Secrets.KeyVaultSecret.Value"/> property.</param>
        /// <param name="recoveryId">Sets the <see cref="Secrets.DeletedSecret.RecoveryId"/> property.</param>
        /// <param name="deletedOn">Sets the <see cref="Secrets.DeletedSecret.DeletedOn"/> property.</param>
        /// <param name="scheduledPurgeDate">Sets the <see cref="Secrets.DeletedSecret.ScheduledPurgeDate"/> property.</param>
        /// <returns>A new instance of the <see cref="Secrets.DeletedSecret"/> for mocking purposes.</returns>
        public static DeletedSecret DeletedSecret(SecretProperties properties, string value = default, Uri recoveryId = default, DateTimeOffset? deletedOn = default, DateTimeOffset? scheduledPurgeDate = default) => new DeletedSecret(properties)
        {
            Value = value,
            RecoveryId = recoveryId,
            DeletedOn = deletedOn,
            ScheduledPurgeDate = scheduledPurgeDate,
        };
    }
}
