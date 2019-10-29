// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Storage.Blobs;
using Azure.Storage.Files.DataLake.Models;

namespace Azure.Storage.Files.DataLake
{
#pragma warning disable AZC0008 // ClientOptions should have a nested enum called ServiceVersion
    /// <summary>
    /// Provides the client configuration options for connecting to Azure Data Lake service.
    /// </summary>
    public class DataLakeClientOptions : BlobClientOptions
#pragma warning restore AZC0008 // ClientOptions should have a nested enum called ServiceVersion
    {

    }
}
