// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Net.Http;
using Azure.Core.Pipeline;
using Azure.Test.Perf;

namespace Azure.Storage.Blobs.Perf
{
    public abstract class ServiceTest<TOptions> : PerfTest<TOptions> where TOptions : PerfOptions
    {
        protected HttpClient HttpClient { get; private set; }
        protected TestProxyTransport Transport { get; private set; }

        protected BlobServiceClient BlobServiceClient { get; private set; }
        protected StorageSharedKeyCredential StorageSharedKeyCredential { get; private set; }

        public ServiceTest(TOptions options) : base(options)
        {
            if (options.Insecure)
            {
                HttpClient = new HttpClient(new HttpClientHandler()
                {
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
                });
            }
            else
            {
                HttpClient = new HttpClient();
            }

            var httpClientTransport = new HttpClientTransport(HttpClient);

            Transport = new TestProxyTransport(httpClientTransport, options.Host, options.Port);

            var blobClientOptions = new BlobClientOptions()
            {
                Transport = Transport,
            };

            BlobServiceClient = new BlobServiceClient(PerfTestEnvironment.Instance.BlobStorageConnectionString, blobClientOptions);

            StorageSharedKeyCredential = new StorageSharedKeyCredential(
                PerfTestEnvironment.Instance.BlobStorageAccountName, PerfTestEnvironment.Instance.BlobStorageAccountKey);
        }
    }
}
