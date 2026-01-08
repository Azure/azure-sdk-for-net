// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Identity;
using Azure.Test.Perf;

namespace Azure.Storage.Blobs.Perf
{
    public abstract class ServiceTest<TOptions> : PerfTest<TOptions> where TOptions : PerfOptions
    {
        protected BlobServiceClient BlobServiceClient { get; private set; }
        protected StorageSharedKeyCredential StorageSharedKeyCredential { get; private set; }

        public ServiceTest(TOptions options) : base(options)
        {
            BlobClientOptions clientOptions = options is Options.IBlobClientOptionsProvider clientOptionsOptions
                ? clientOptionsOptions.ClientOptions
                : new BlobClientOptions();
            // The default credential does not support managed identity
            TokenCredential credential = PerfTestEnvironment.Instance.StorageUseManagedIdentity ?
                new ManagedIdentityCredential(new ManagedIdentityCredentialOptions(ManagedIdentityId.SystemAssigned)) :
                PerfTestEnvironment.Instance.Credential;
            BlobServiceClient = new BlobServiceClient(
                PerfTestEnvironment.Instance.StorageEndpoint,
                credential,
                ConfigureClientOptions(clientOptions));

            // Can't do shared key tests if shared key wasn't provided
            if (PerfTestEnvironment.Instance.StorageAccountKey != null)
            {
                StorageSharedKeyCredential = new StorageSharedKeyCredential(
                    PerfTestEnvironment.Instance.StorageAccountName, PerfTestEnvironment.Instance.StorageAccountKey);
            }
        }
    }
}
