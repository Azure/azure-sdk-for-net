//Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;

namespace Azure.Storage.Blobs.Perf
{
    public abstract class ServiceTest<TOptions> : PerfTest<TOptions> where TOptions : PerfOptions
    {
        protected BlobServiceClient BlobServiceClient { get; private set; }

        public ServiceTest(TOptions options) : base(options)
        {
            var blobClientOptions = new BlobClientOptions()
            {
                Transport = PerfTransport.Create(options)
            };

            BlobServiceClient = new BlobServiceClient(PerfTestEnvironment.Instance.BlobStorageConnectionString, blobClientOptions);
        }
    }
}
