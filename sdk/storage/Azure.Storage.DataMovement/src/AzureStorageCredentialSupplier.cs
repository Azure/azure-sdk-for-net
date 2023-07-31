// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Collection of suppliers for Azure Storage resources.
    /// </summary>
    public class AzureStorageCredentialSupplier
    {
        /// <summary>
        /// Gets a shared key credential for the given Azure Storage URI.
        /// </summary>
        public delegate Task<StorageSharedKeyCredential> GetSharedKeyCredential(string uri);

        /// <summary>
        /// Gets a token credential for the given Azure Storage URI.
        /// </summary>
        public delegate Task<TokenCredential> GetTokenCredential(string uri);

        /// <summary>
        /// Gets a SAS credential for the given Azure Storage URI.
        /// </summary>
        public delegate Task<AzureSasCredential> GetSasCredential(string uri);

        /// <summary>
        /// Shared key credential supplier.
        /// </summary>
        public GetSharedKeyCredential SharedKeyCredential { get; set; }

        /// <summary>
        /// Token credential supplier.
        /// </summary>
        public GetTokenCredential TokenCredential { get; set; }

        /// <summary>
        /// SAS credential supplier.
        /// </summary>
        public GetSasCredential SasCredential { get; set; }
    }
}
