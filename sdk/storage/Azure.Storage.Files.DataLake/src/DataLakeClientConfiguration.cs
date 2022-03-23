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
            : base(pipeline, sharedKeyCredential, clientDiagnostics)
        {
            Version = version;
            CustomerProvidedKey = customerProvidedKey;
        }

        internal static DataLakeClientConfiguration DeepCopy(DataLakeClientConfiguration originalClientConfiguration)
            => new DataLakeClientConfiguration(
                pipeline: originalClientConfiguration.Pipeline,
                sharedKeyCredential: originalClientConfiguration.SharedKeyCredential,
                clientDiagnostics: originalClientConfiguration.ClientDiagnostics,
                version: originalClientConfiguration.Version,
                customerProvidedKey: originalClientConfiguration.CustomerProvidedKey);
    }
}
