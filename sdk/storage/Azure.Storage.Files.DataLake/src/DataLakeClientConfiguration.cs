// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

        internal DataLakeClientConfiguration(
            HttpPipeline pipeline,
            StorageSharedKeyCredential sharedKeyCredential,
            AzureSasCredential sasCredential,
            ClientDiagnostics clientDiagnostics,
            DataLakeClientOptions clientOptions,
            DataLakeCustomerProvidedKey? customerProvidedKey)
            : base(pipeline, sharedKeyCredential, sasCredential, default, clientDiagnostics)
        {
            ClientOptions = clientOptions;
            CustomerProvidedKey = customerProvidedKey;
            TransferValidation = clientOptions.TransferValidation;
        }

        internal static DataLakeClientConfiguration DeepCopy(DataLakeClientConfiguration originalClientConfiguration)
            => new DataLakeClientConfiguration(
                pipeline: originalClientConfiguration.Pipeline,
                sharedKeyCredential: originalClientConfiguration.SharedKeyCredential,
                sasCredential: originalClientConfiguration.SasCredential,
                clientDiagnostics: originalClientConfiguration.ClientDiagnostics,
                clientOptions: originalClientConfiguration.ClientOptions,
                customerProvidedKey: originalClientConfiguration.CustomerProvidedKey);
    }
}
