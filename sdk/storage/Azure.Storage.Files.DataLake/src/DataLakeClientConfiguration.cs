// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Shared;

namespace Azure.Storage.Files.DataLake
{
    internal class DataLakeClientConfiguration : StorageClientConfiguration
    {
        public DataLakeClientOptions ClientOptions { get; internal set; }

        public virtual DataLakeCustomerProvidedKey? CustomerProvidedKey { get; internal set; }

        public virtual TransferValidationOptions TransferValidation { get; } = new();

        private HttpPipeline _blobPipeline;

        /// <summary>
        /// Pipeline used by inner blob clients (e.g. <see cref="Blobs.BlobServiceClient"/>,
        /// <see cref="Blobs.BlobContainerClient"/>, <see cref="Blobs.Specialized.BlockBlobClient"/>)
        /// constructed inside DataLake clients. For token-credential scenarios this pipeline is
        /// wrapped with <c>SessionAuthenticationPolicy</c>, while the DFS-side
        /// <see cref="StorageClientConfiguration.Pipeline"/> uses the supplied authentication
        /// policy as-is so DFS endpoint requests can never route through session auth.
        /// Falls back to <see cref="StorageClientConfiguration.Pipeline"/> when no separate
        /// blob pipeline has been configured (e.g. SharedKey / SAS scenarios).
        /// </summary>
        public virtual HttpPipeline BlobPipeline
        {
            get => _blobPipeline ?? Pipeline;
            internal set => _blobPipeline = value;
        }

        /// <summary>
        /// Create a <see cref="DataLakeClientConfiguration"/> without authentication,
        /// or with SAS that was provided as part of the URL.
        /// </summary>
        public DataLakeClientConfiguration(
            HttpPipeline pipeline,
            ClientDiagnostics clientDiagnostics,
            DataLakeClientOptions clientOptions,
            DataLakeCustomerProvidedKey? customerProvidedKey)
            : base(pipeline, clientDiagnostics)
        {
            ClientOptions = clientOptions;
            CustomerProvidedKey = customerProvidedKey;
            TransferValidation = clientOptions.TransferValidation;
        }

        /// <summary>
        /// Create a <see cref="DataLakeClientConfiguration"/> with shared key authentication.
        /// </summary>
        public DataLakeClientConfiguration(
            HttpPipeline pipeline,
            StorageSharedKeyCredential sharedKeyCredential,
            ClientDiagnostics clientDiagnostics,
            DataLakeClientOptions clientOptions,
            DataLakeCustomerProvidedKey? customerProvidedKey)
            : base(pipeline, sharedKeyCredential, clientDiagnostics)
        {
            ClientOptions = clientOptions;
            CustomerProvidedKey = customerProvidedKey;
            TransferValidation = clientOptions.TransferValidation;
        }

        /// <summary>
        /// Create a <see cref="DataLakeClientConfiguration"/> with SAS authentication.
        /// </summary>
        public DataLakeClientConfiguration(
            HttpPipeline pipeline,
            AzureSasCredential sasCredential,
            ClientDiagnostics clientDiagnostics,
            DataLakeClientOptions clientOptions,
            DataLakeCustomerProvidedKey? customerProvidedKey)
            : base(pipeline, sasCredential, clientDiagnostics)
        {
            ClientOptions = clientOptions;
            CustomerProvidedKey = customerProvidedKey;
            TransferValidation = clientOptions.TransferValidation;
        }

        /// <summary>
        /// Create a <see cref="DataLakeClientConfiguration"/> with token authentication.
        /// </summary>
        public DataLakeClientConfiguration(
            HttpPipeline pipeline,
            TokenCredential tokenCredential,
            ClientDiagnostics clientDiagnostics,
            DataLakeClientOptions clientOptions,
            DataLakeCustomerProvidedKey? customerProvidedKey)
            : base(pipeline, tokenCredential, clientDiagnostics)
        {
            ClientOptions = clientOptions;
            CustomerProvidedKey = customerProvidedKey;
            TransferValidation = clientOptions.TransferValidation;
        }

        /// <summary>
        /// For internal Client Constructors that accept multiple types of authentication.
        /// </summary>
        internal DataLakeClientConfiguration(
            HttpPipeline pipeline,
            StorageSharedKeyCredential sharedKeyCredential,
            AzureSasCredential sasCredential,
            TokenCredential tokenCredential,
            ClientDiagnostics clientDiagnostics,
            DataLakeClientOptions clientOptions,
            DataLakeCustomerProvidedKey? customerProvidedKey)
            : base(pipeline, sharedKeyCredential, sasCredential, tokenCredential, clientDiagnostics)
        {
            ClientOptions = clientOptions;
            CustomerProvidedKey = customerProvidedKey;
            TransferValidation = clientOptions.TransferValidation;
        }

        internal static DataLakeClientConfiguration DeepCopy(DataLakeClientConfiguration originalClientConfiguration)
        {
            var copy = new DataLakeClientConfiguration(
                pipeline: originalClientConfiguration.Pipeline,
                sharedKeyCredential: originalClientConfiguration.SharedKeyCredential,
                sasCredential: originalClientConfiguration.SasCredential,
                tokenCredential: originalClientConfiguration.TokenCredential,
                clientDiagnostics: originalClientConfiguration.ClientDiagnostics,
                clientOptions: originalClientConfiguration.ClientOptions,
                customerProvidedKey: originalClientConfiguration.CustomerProvidedKey);
            copy._blobPipeline = originalClientConfiguration._blobPipeline;
            return copy;
        }
    }
}
