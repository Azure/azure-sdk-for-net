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
        internal string ComputeHMACSHA256(string message) =>
            Convert.ToBase64String(new HMACSHA256(AccountKeyValue).ComputeHash(Encoding.UTF8.GetBytes(message)));

        /// <summary>
        /// Generates a base-64 hash signature string for an HTTP request or
        /// for a SAS.
        /// </summary>
        /// <param name="credential">The credential.</param>
        /// <param name="message">The message to sign.</param>
        /// <returns>The signed message.</returns>
        protected static string ComputeSasSignature(StorageSharedKeyCredential credential, string message) =>
            credential.ComputeHMACSHA256(message);

        /// <summary>
        /// Parses a connection string for the storage account name and key
        /// returns a <see cref="StorageSharedKeyCredential"/> created
        /// from the connection string.
        /// </summary>
        /// <param name="connectionString">A valid connection string.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="connectionString"/> is null or empty.</exception>
        /// <exception cref="FormatException">Thrown if <paramref name="connectionString"/> is not a valid connection string.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="connectionString"/> cannot be parsed.</exception>
        /// <returns>A <see cref="StorageConnectionString"/> object constructed from the values provided in the connection string.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static StorageSharedKeyCredential ParseConnectionString(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw Errors.ArgumentNull(nameof(connectionString));
            }

            IDictionary<string, string> settings = new Dictionary<string, string>();
            var splitted = connectionString.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var nameValue in splitted)
            {
                var splittedNameValue = nameValue.Split(new char[] { '=' }, 2);

                if (splittedNameValue.Length != 2)
                {
                    throw new ArgumentException("Settings must be of the form \"name=value\".");
                }

                if (settings.ContainsKey(splittedNameValue[0]))
                {
                    throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Duplicate setting '{0}' found.", splittedNameValue[0]));
                }

                settings.Add(splittedNameValue[0], splittedNameValue[1]);
            }

            settings.TryGetValue(Constants.ConnectionStrings.AccountNameSetting, out var accountName);
            settings.TryGetValue(Constants.ConnectionStrings.AccountKeySetting, out var accountKey);

            return accountName != null && accountKey != null
                ? new StorageSharedKeyCredential(accountName, accountKey)
                : null;
        }
    }
}
