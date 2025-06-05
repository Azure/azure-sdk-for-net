﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;

namespace Azure.Storage.Files.DataLake.Perf
{
    public abstract class ServiceTest<TOptions> : PerfTest<TOptions> where TOptions : PerfOptions
    {
        protected DataLakeServiceClient DataLakeServiceClient { get; private set; }
        protected StorageSharedKeyCredential StorageSharedKeyCredential { get; private set; }

        public ServiceTest(TOptions options) : base(options)
        {
            DataLakeClientOptions clientOptions = options is Options.IDataLakeClientOptionsProvider clientOptionsProvider
                ? clientOptionsProvider.ClientOptions
                : new DataLakeClientOptions();
            DataLakeServiceClient = new DataLakeServiceClient(
                PerfTestEnvironment.Instance.DataLakeServiceUri,
                PerfTestEnvironment.Instance.DataLakeCredential,
                ConfigureClientOptions(clientOptions));

            StorageSharedKeyCredential = new StorageSharedKeyCredential(
                PerfTestEnvironment.Instance.DataLakeAccountName, PerfTestEnvironment.Instance.DataLakeAccountKey);
        }
    }
}
