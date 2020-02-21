// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Microsoft.Azure.Batch
{
    using System;

    public sealed class AzureStorageAuthenticationKey
    {
        /// <summary>
        /// Gets the Azure Storage Account key.
        /// </summary>
        public string AccountKey { get; }

        /// <summary>
        /// Gets the Azure Storage SAS key.
        /// </summary>
        public string SasKey { get; }

        private AzureStorageAuthenticationKey(string accountKey = null, string sasKey = null)
        {
            AccountKey = accountKey;
            SasKey = sasKey;
        }

        /// <summary>
        /// Creates a new <see cref="AzureStorageAuthenticationKey"/> referencing an Azure Storage Account key.
        /// </summary>
        /// <param name="key">The Storage Account key.</param>
        /// <returns>A new <see cref="AzureStorageAuthenticationKey"/> referencing the Azure Storage Account key.</returns>
        public static AzureStorageAuthenticationKey FromAccountKey(string key) => new AzureStorageAuthenticationKey(accountKey: key);

        /// <summary>
        /// Creates a new <see cref="AzureStorageAuthenticationKey"/> referencing an Azure Storage SAS key.
        /// </summary>
        /// <param name="key">The Storage SAS key.</param>
        /// <returns>A new <see cref="AzureStorageAuthenticationKey"/> referencing the Azure Storage SAS key.</returns>
        public static AzureStorageAuthenticationKey FromSasKey(string key) => new AzureStorageAuthenticationKey(sasKey: key);
    }
}
