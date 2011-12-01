//-----------------------------------------------------------------------
// <copyright file="Credentials.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the Credentials class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    using System;

    /// <summary>
    /// Represents the credentials used to sign a request against the storage services.
    /// </summary>
    public class Credentials
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Credentials"/> class.
        /// </summary>
        /// <param name="accountName">The storage account name.</param>
        /// <param name="key">The access key.</param>
        public Credentials(string accountName, byte[] key)
        {
            if (String.IsNullOrEmpty(accountName))
            {
                throw new ArgumentException("accountName");
            }

            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            this.AccountName = accountName;
            this.Key = new StorageKey(key);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Credentials"/> class.
        /// </summary>
        /// <param name="accountName">The storage account name.</param>
        /// <param name="base64EncodedKey">The access key, as a Base64-encoded string.</param>
        public Credentials(string accountName, string base64EncodedKey)
            : this(accountName, Convert.FromBase64String(base64EncodedKey))
        {
        }

        /// <summary>
        /// Gets the account name to be used in signing the request.
        /// </summary>
        /// <value>The name of the account.</value>
        public string AccountName { get; private set; }

        /// <summary>
        /// Gets the access key to be used in signing the request.
        /// </summary>
        internal StorageKey Key { get; private set; }

        /// <summary>
        /// Exports the value of the access key to an array of bytes.
        /// </summary>
        /// <returns>The account access key.</returns>
        public byte[] ExportKey()
        {
            return this.Key.GetKey();
        }

        /// <summary>
        /// Exports the value of the access key to a Base64-encoded string.
        /// </summary>
        /// <returns>The account access key.</returns>
        public string ExportBase64EncodedKey()
        {
            return this.Key.GetBase64EncodedKey();
        }
    }
}
