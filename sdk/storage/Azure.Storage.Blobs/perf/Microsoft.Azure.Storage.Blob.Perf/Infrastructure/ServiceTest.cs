//Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;

namespace Microsoft.Azure.Storage.Blob.Perf
{
    public abstract class ServiceTest<TOptions> : PerfTest<TOptions> where TOptions : PerfOptions
    {
        protected CloudBlobClient CloudBlobClient { get; private set; }

        public ServiceTest(TOptions options) : base(options)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(PerfTestEnvironment.Instance.BlobStorageConnectionString);

            CloudBlobClient = storageAccount.CreateCloudBlobClient();
        }
    }
}
