// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace Azure.Storage
{
    /// <summary>
    /// A <see cref="StorageSharedKeyCredential"/> is a credential backed by
    /// a Storage Account's name and one of its access keys.
    /// </summary>
    public class StorageSharedKeyCredential
    {
        /// <summary>
        /// Gets the name of the Storage Account.
        /// </summary>
        public string AccountName { get; }

        /// <summary>
        /// The value of a Storage Account access key.
        /// </summary>
        private byte[] _accountKeyValue;

        /// <summary>
        /// Gets the value of a Storage Account access key.
        /// </summary>
        private byte[] AccountKeyValue
        {
            get => Volatile.Read(ref _accountKeyValue);
            set => Volatile.Write(ref _accountKeyValue, value);
        }

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
            AccountName = accountName;
            SetAccountKey(accountKey);
        }

        /// <summary>
        /// Update the Storage Account's access key.  This intended to be used
        /// when you've regenerated your Storage Account's access keys and want
        /// to update long lived clients.
        /// </summary>
        /// <param name="accountKey">A Storage Account access key.</param>
        public void SetAccountKey(string accountKey) =>
            AccountKeyValue = Convert.FromBase64String(accountKey);

        /// <summary>
        /// Generates a base-64 hash signature string for an HTTP request or
        /// for a SAS.
        /// </summary>
        /// <param name="message">The message to sign.</param>
        /// <returns>The signed message.</returns>
        internal string ComputeHMACSHA256(string message)
        {
#if NET6_0_OR_GREATER
            return Convert.ToBase64String(HMACSHA256.HashData(AccountKeyValue, Encoding.UTF8.GetBytes(message)));
#else
            return Convert.ToBase64String(new HMACSHA256(AccountKeyValue).ComputeHash(Encoding.UTF8.GetBytes(message)));
#endif
        }

        /// <summary>
        /// Generates a base-64 hash signature string for an HTTP request or
        /// for a SAS.
        /// </summary>
        /// <param name="credential">The credential.</param>
        /// <param name="message">The message to sign.</param>
        /// <returns>The signed message.</returns>
        protected static string ComputeSasSignature(StorageSharedKeyCredential credential, string message) =>
            credential.ComputeHMACSHA256(message);
    }
}
