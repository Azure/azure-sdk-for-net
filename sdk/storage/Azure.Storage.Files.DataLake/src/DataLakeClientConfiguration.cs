// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;
using Azure.Storage.Files.DataLake.Models;
using Azure.Storage.Shared;

namespace Azure.Storage.Files.DataLake
{
    internal class DataLakeClientConfiguration : StorageClientConfiguration
    {
        public DataLakeClientOptions.ServiceVersion Version { get; internal set; }

        public virtual DataLakeCustomerProvidedKey? CustomerProvidedKey { get; internal set; }

        public DataLakeClientConfiguration(
            HttpPipeline pipeline,
            StorageSharedKeyCredential sharedKeyCredential,
            ClientDiagnostics clientDiagnostics,
            DataLakeClientOptions.ServiceVersion version,
            DataLakeCustomerProvidedKey? customerProvidedKey)
            : this(pipeline, sharedKeyCredential, default, clientDiagnostics, version, customerProvidedKey)
        {
        }

        public DataLakeClientConfiguration(
            HttpPipeline pipeline,
            AzureSasCredential sasCredential,
            ClientDiagnostics clientDiagnostics,
            DataLakeClientOptions.ServiceVersion version,
            DataLakeCustomerProvidedKey? customerProvidedKey)
            : this(pipeline, default, sasCredential, clientDiagnostics, version, customerProvidedKey)
        {
        }

        internal DataLakeClientConfiguration(
            HttpPipeline pipeline,
            StorageSharedKeyCredential sharedKeyCredential,
            AzureSasCredential sasCredential,
            ClientDiagnostics clientDiagnostics,
            DataLakeClientOptions.ServiceVersion version,
            DataLakeCustomerProvidedKey? customerProvidedKey)
            : base(pipeline, sharedKeyCredential, sasCredential, clientDiagnostics)
        {
            Version = version;
            CustomerProvidedKey = customerProvidedKey;
        }

        internal static DataLakeClientConfiguration DeepCopy(DataLakeClientConfiguration originalClientConfiguration)
            => new DataLakeClientConfiguration(
                pipeline: originalClientConfiguration.Pipeline,
                sharedKeyCredential: originalClientConfiguration.SharedKeyCredential,
                sasCredential: originalClientConfiguration.SasCredential,
                clientDiagnostics: originalClientConfiguration.ClientDiagnostics,
                version: originalClientConfiguration.Version,
                customerProvidedKey: originalClientConfiguration.CustomerProvidedKey);
    }
}
