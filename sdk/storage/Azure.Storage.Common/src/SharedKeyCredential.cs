// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Security.Cryptography;
using System.Text;

namespace Azure.Storage
{
    // SharedKeyCredential contains an account's name and its primary or secondary key.
    // It is immutable making it shareable and goroutine-safe.
    public sealed class SharedKeyCredentials : IStorageCredentials
    {
        // NewSharedKeyCredential creates an immutable SharedKeyCredential containing the
        // storage account's name and either its primary or secondary key.
        public SharedKeyCredentials(string accountName, string accountKey, string accountKeyName = default)
        {
            this.AccountName = accountName;
            this.AccountKeyValue = Convert.FromBase64String(accountKey);
            this.AccountKeyName = accountKeyName;
        }

        // AccountName returns the Storage account's name.
        public string AccountName { get; }
        internal byte[] AccountKeyValue { get; }
        public string AccountKeyName { get; }

        /// <summary>
        /// Exports the value of the account access key to a Base64-encoded string.
        /// </summary>
        /// <returns>The account access key.</returns>
        internal string ExportBase64EncodedKey() => (this.AccountKeyValue == null) ? null : Convert.ToBase64String(this.AccountKeyValue);

        // ComputeHMACSHA256 generates a base-64 hash signature string for an HTTP request or for a SAS.

        internal string ComputeHMACSHA256(string message) =>
            Convert.ToBase64String(new HMACSHA256(this.AccountKeyValue).ComputeHash(Encoding.UTF8.GetBytes(message)));
    }
}
