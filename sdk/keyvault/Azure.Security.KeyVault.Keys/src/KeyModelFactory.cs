// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// Model factory that enables mocking for the Key Vault Keys library.
    /// </summary>
    public static class KeyModelFactory
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Keys.JsonWebKey"/> for mocking purposes.
        /// </summary>
        /// <param name="keyType">Sets the <see cref="Keys.JsonWebKey.KeyType"/> property.</param>
        /// <param name="id">Sets the <see cref="Keys.JsonWebKey.Id"/> property.</param>
        /// <param name="keyOps">Sets the <see cref="Keys.JsonWebKey.KeyOps"/> property.</param>
        /// <param name="curveName">Sets the <see cref="Keys.JsonWebKey.CurveName"/> property.</param>
        /// <param name="d">Sets the <see cref="Keys.JsonWebKey.D"/> property.</param>
        /// <param name="dp">Sets the <see cref="Keys.JsonWebKey.DP"/> property.</param>
        /// <param name="dq">Sets the <see cref="Keys.JsonWebKey.DQ"/> property.</param>
        /// <param name="e">Sets the <see cref="Keys.JsonWebKey.E"/> property.</param>
        /// <param name="k">Sets the <see cref="Keys.JsonWebKey.K"/> property.</param>
        /// <param name="n">Sets the <see cref="Keys.JsonWebKey.N"/> property.</param>
        /// <param name="p">Sets the <see cref="Keys.JsonWebKey.P"/> property.</param>
        /// <param name="q">Sets the <see cref="Keys.JsonWebKey.Q"/> property.</param>
        /// <param name="qi">Sets the <see cref="Keys.JsonWebKey.QI"/> property.</param>
        /// <param name="t">Sets the <see cref="Keys.JsonWebKey.T"/> property.</param>
        /// <param name="x">Sets the <see cref="Keys.JsonWebKey.X"/> property.</param>
        /// <param name="y">Sets the <see cref="Keys.JsonWebKey.Y"/> property.</param>
        /// <returns>A new instance of <see cref="Keys.JsonWebKey"/> for mocking purposes.</returns>
        public static JsonWebKey JsonWebKey(
            KeyType keyType,
            string id = default,
            IEnumerable<KeyOperation> keyOps = default,
            KeyCurveName? curveName = default,
            byte[] d = default,
            byte[] dp = default,
            byte[] dq = default,
            byte[] e = default,
            byte[] k = default,
            byte[] n = default,
            byte[] p = default,
            byte[] q = default,
            byte[] qi = default,
            byte[] t = default,
            byte[] x = default,
            byte[] y = default)
        {
            return new JsonWebKey(keyOps)
            {
                KeyType = keyType,
                Id = id,
                CurveName = curveName,
                D = d,
                DP = dp,
                DQ = dq,
                E = e,
                K = k,
                N = n,
                P = p,
                Q = q,
                QI = qi,
                T = t,
                X = x,
                Y = y,
            };
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Keys.KeyProperties"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="Keys.KeyProperties.Id"/> property.</param>
        /// <param name="vaultUri">Sets the <see cref="Keys.KeyProperties.VaultUri"/> property.</param>
        /// <param name="name">Sets the <see cref="Keys.KeyProperties.Name"/> property.</param>
        /// <param name="version">Sets the <see cref="Keys.KeyProperties.Version"/> property.</param>
        /// <param name="managed">Sets the <see cref="Keys.KeyProperties.Managed"/> property.</param>
        /// <param name="createdOn">Sets the <see cref="Keys.KeyProperties.CreatedOn"/> property.</param>
        /// <param name="updatedOn">Sets the <see cref="Keys.KeyProperties.UpdatedOn"/> property.</param>
        /// <param name="recoveryLevel">Sets the <see cref="Keys.KeyProperties.RecoveryLevel"/> property.</param>
        /// <returns>A new instance of <see cref="Keys.KeyProperties"/> for mocking purposes.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static KeyProperties KeyProperties(
            Uri id,
            Uri vaultUri,
            string name,
            string version,
            bool managed,
            DateTimeOffset? createdOn,
            DateTimeOffset? updatedOn,
            string recoveryLevel) => KeyProperties(
                id,
                vaultUri,
                name,
                version,
                managed,
                createdOn,
                updatedOn,
                recoveryLevel,
                default);

        /// <summary>
        /// Initializes a new instance of <see cref="Keys.KeyProperties"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="Keys.KeyProperties.Id"/> property.</param>
        /// <param name="vaultUri">Sets the <see cref="Keys.KeyProperties.VaultUri"/> property.</param>
        /// <param name="name">Sets the <see cref="Keys.KeyProperties.Name"/> property.</param>
        /// <param name="version">Sets the <see cref="Keys.KeyProperties.Version"/> property.</param>
        /// <param name="managed">Sets the <see cref="Keys.KeyProperties.Managed"/> property.</param>
        /// <param name="createdOn">Sets the <see cref="Keys.KeyProperties.CreatedOn"/> property.</param>
        /// <param name="updatedOn">Sets the <see cref="Keys.KeyProperties.UpdatedOn"/> property.</param>
        /// <param name="recoveryLevel">Sets the <see cref="Keys.KeyProperties.RecoveryLevel"/> property.</param>
        /// <param name="recoverableDays">Sets the <see cref="Keys.KeyProperties.RecoverableDays"/> property.</param>
        /// <returns>A new instance of <see cref="Keys.KeyProperties"/> for mocking purposes.</returns>
        public static KeyProperties KeyProperties(
            Uri id = default,
            Uri vaultUri = default,
            string name = default,
            string version = default,
            bool managed = default,
            DateTimeOffset? createdOn = default,
            DateTimeOffset? updatedOn = default,
            string recoveryLevel = default,
            int? recoverableDays = default)
        {
            return new KeyProperties
            {
                Id = id,
                VaultUri = vaultUri,
                Name = name,
                Version = version,
                Managed = managed,
                CreatedOn = createdOn,
                UpdatedOn = updatedOn,
                RecoveryLevel = recoveryLevel,
                RecoverableDays = recoverableDays,
            };
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Keys.KeyVaultKey"/> for mocking purposes.
        /// </summary>
        /// <param name="properties">Sets the <see cref="Keys.KeyVaultKey.Properties"/> property, which provides the <see cref="Keys.KeyVaultKey.Id"/> and <see cref="Keys.KeyVaultKey.Name"/> properties.</param>
        /// <param name="key">Sets the <see cref="Keys.KeyVaultKey.Key"/> property, which provides the <see cref="Keys.KeyVaultKey.KeyType"/> and <see cref="Keys.KeyVaultKey.KeyOperations"/> properties.</param>
        /// <returns>A new instance of <see cref="Keys.KeyVaultKey"/> for mocking purposes.</returns>
        public static KeyVaultKey KeyVaultKey(KeyProperties properties, JsonWebKey key) => new KeyVaultKey(properties)
        {
            Key = key,
        };

        /// <summary>
        /// Initializes a new instance of <see cref="Keys.DeletedKey"/> for mocking purposes.
        /// </summary>
        /// <param name="properties">Sets the <see cref="Keys.KeyVaultKey.Properties"/> property, which provides the <see cref="Keys.KeyVaultKey.Id"/> and <see cref="Keys.KeyVaultKey.Name"/> properties.</param>
        /// <param name="key">Sets the <see cref="Keys.KeyVaultKey.Key"/> property, which provides the <see cref="Keys.KeyVaultKey.KeyType"/> and <see cref="Keys.KeyVaultKey.KeyOperations"/> properties.</param>
        /// <param name="recoveryId">Sets the <see cref="Keys.DeletedKey.RecoveryId"/> property.</param>
        /// <param name="deletedOn">Sets the <see cref="Keys.DeletedKey.DeletedOn"/> property.</param>
        /// <param name="scheduledPurgeDate">Sets the <see cref="Keys.DeletedKey.ScheduledPurgeDate"/> property.</param>
        /// <returns>A new instance of <see cref="Keys.DeletedKey"/> for mocking purposes.</returns>
        public static DeletedKey DeletedKey(KeyProperties properties, JsonWebKey key, Uri recoveryId = default, DateTimeOffset? deletedOn = default, DateTimeOffset? scheduledPurgeDate = default) => new DeletedKey(properties)
        {
            Key = key,
            RecoveryId = recoveryId,
            DeletedOn = deletedOn,
            ScheduledPurgeDate = scheduledPurgeDate,
        };

        /// <summary>
        /// Initializes a new instance of <see cref="Keys.ReleaseKeyResult"/> for mocking purposes.
        /// </summary>
        /// <param name="value">Sets the <see cref="Keys.ReleaseKeyResult.Value"/> property.</param>
        /// <returns>A new instance of <see cref="Keys.ReleaseKeyResult"/> for mocking purposes.</returns>
        public static ReleaseKeyResult ReleaseKeyResult(string value) => new ReleaseKeyResult()
        {
            Value = value,
        };

        /// <summary>
        /// Initializes a new instance of <see cref="Keys.KeyRotationPolicy"/> for mocking purposes.
        /// </summary>
        /// <param name="id">Sets the <see cref="Keys.KeyRotationPolicy.Id"/> property.</param>
        /// <param name="createdOn">Sets the <see cref="Keys.KeyRotationPolicy.CreatedOn"/> property.</param>
        /// <param name="updatedOn">Sets the <see cref="Keys.KeyRotationPolicy.UpdatedOn"/> property.</param>
        /// <returns>A new instance of <see cref="Keys.KeyRotationPolicy"/> for mocking purposes.</returns>
        public static KeyRotationPolicy KeyRotationPolicy(Uri id = default, DateTimeOffset? createdOn = default, DateTimeOffset? updatedOn = default) => new KeyRotationPolicy
        {
            Id = id,
            CreatedOn = createdOn,
            UpdatedOn = updatedOn,
        };
    }
}
