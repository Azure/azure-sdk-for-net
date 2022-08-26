// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            ShareServiceClient = new ShareServiceClient(
                PerfTestEnvironment.Instance.FileSharesConnectionString, ConfigureClientOptions(clientOptions));

            StorageSharedKeyCredential = new StorageSharedKeyCredential(
                PerfTestEnvironment.Instance.FilesSharesAccountName, PerfTestEnvironment.Instance.FilesSharesAccountKey);
        }
    }
}
