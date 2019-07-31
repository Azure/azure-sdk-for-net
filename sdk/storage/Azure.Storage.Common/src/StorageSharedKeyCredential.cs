﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Security.Cryptography;
using System.Text;

namespace Azure.Storage
{
    /// <summary>
    /// A <see cref="StorageSharedKeyCredential"/> is a credential backed by
    /// a Storage Account's name and one of its access keys.
    /// </summary>
    public sealed class StorageSharedKeyCredential
    {
        /// <summary>
        /// Gets the name of the Storage Account.
        /// </summary>
        public string AccountName { get; }

#pragma warning disable CA1044 // Properties should not be write only
        /// <summary>
        /// Updates the Storage Account's access key.  This is a write-only
        /// property only intended to be used when you've regenerated your
        /// Storage Account's access keys and want to update long lived clients.
        /// </summary>
        public string AccountKey
        {
            set => this.AccountKeyValue = Convert.FromBase64String(value);
        }
#pragma warning restore CA1044 // Properties should not be write only

        /// <summary>
        /// Gets the value of a Storage Account access key.
        /// </summary>
        internal byte[] AccountKeyValue { get; private set; }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="StorageSharedKeyCredential"/> class.
        /// </summary>
        /// <param name="accountName">The name of the Storage Account.</param>
        /// <param name="accountKey">A Storage Account access key.</param>
        public StorageSharedKeyCredential(
            string accountName,
            string accountKey)
        {
            this.AccountName = accountName;
            this.AccountKey = accountKey;
        }

        /// <summary>
        /// Exports the value of the account's key to a Base64-encoded string.
        /// </summary>
        /// <returns>The account's key.</returns>
        internal string ExportBase64EncodedKey() =>
            this.AccountKeyValue == null ?
                null :
                Convert.ToBase64String(this.AccountKeyValue);

        /// <summary>
        /// Generates a base-64 hash signature string for an HTTP request or
        /// for a SAS.
        /// </summary>
        /// <param name="message">The message to sign.</param>
        /// <returns>The signed message.</returns>
        internal string ComputeHMACSHA256(string message) =>
            Convert.ToBase64String(new HMACSHA256(this.AccountKeyValue).ComputeHash(Encoding.UTF8.GetBytes(message)));
    }
}
