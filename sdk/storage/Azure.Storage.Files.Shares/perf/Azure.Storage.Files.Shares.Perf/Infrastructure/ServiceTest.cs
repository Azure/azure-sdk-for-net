// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Storage.Files.Shares.Models;
using Azure.Test.Perf;

namespace Azure.Storage.Files.Shares.Perf
{
    public abstract class ServiceTest<TOptions> : PerfTest<TOptions> where TOptions : PerfOptions
    {
        protected ShareServiceClient ShareServiceClient { get; private set; }
        protected StorageSharedKeyCredential StorageSharedKeyCredential { get; private set; }

        public ServiceTest(TOptions options) : base(options)
        {
            ShareClientOptions clientOptions = options is Options.IShareClientOptionsProvider clientOptionsProvider
                ? clientOptionsProvider.ClientOptions
                : new ShareClientOptions();
            clientOptions.ShareTokenIntent = ShareTokenIntent.Backup;
            ShareServiceClient = new ShareServiceClient(
                PerfTestEnvironment.Instance.StorageEndpoint,
                PerfTestEnvironment.Instance.Credential,
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
