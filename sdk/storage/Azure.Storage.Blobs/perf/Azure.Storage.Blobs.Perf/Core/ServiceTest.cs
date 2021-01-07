//Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Data.Common;
using Azure.Test.Perf;

namespace Azure.Storage.Blobs.Perf.Core
{
    public abstract class ServiceTest<TOptions> : PerfTest<TOptions> where TOptions : PerfOptions
    {
        protected BlobServiceClient BlobServiceClient { get; private set; }
        protected StorageSharedKeyCredential StorageSharedKeyCredential { get; private set; }

        public ServiceTest(TOptions options) : base(options)
        {
            var connectionString = GetEnvironmentVariable("STORAGE_CONNECTION_STRING");

            var builder = new DbConnectionStringBuilder() { ConnectionString = connectionString };

            var accountName = (string)builder["AccountName"];
            var accountKey = (string)builder["AccountKey"];
            var defaultEndpointsProtocol = (string)builder["DefaultEndpointsProtocol"];
            var endpointSuffix = (string)builder["EndpointSuffix"];

            var serviceUri = (new UriBuilder(defaultEndpointsProtocol, string.Join(".", accountName, endpointSuffix))).Uri;
            StorageSharedKeyCredential = new StorageSharedKeyCredential(accountName, accountKey);

            BlobServiceClient = new BlobServiceClient(connectionString);
        }
    }
}
