﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.Test
{
    /// <summary>
    /// Base class for Common tests
    /// </summary>
    [ClientTestFixture(
    BlobClientOptions.ServiceVersion.V2020_06_12,
    BlobClientOptions.ServiceVersion.V2020_08_04,
    RecordingServiceVersion = BlobClientOptions.ServiceVersion.V2020_08_04,
    LiveServiceVersions = new object[] { BlobClientOptions.ServiceVersion.V2020_06_12 })]
    public abstract class CommonTestBase : StorageTestBase
    {
        protected readonly BlobClientOptions.ServiceVersion _serviceVersion;

        public CommonTestBase(bool async, BlobClientOptions.ServiceVersion serviceVersion, RecordedTestMode? mode = null)
            : base(async, mode /* RecordedTestMode.Record to re-record */)
        {
            _serviceVersion = serviceVersion;
        }

        public string GetNewContainerName() => $"test-container-{Recording.Random.NewGuid()}";

        /// <summary>
        /// Get BlobClientOptions instrumented for recording.
        /// </summary>
        protected BlobClientOptions GetBlobOptions()
        {
            var options = new BlobClientOptions(_serviceVersion)
            {
                Diagnostics = { IsLoggingEnabled = true },
                Retry =
                {
                    Mode = RetryMode.Exponential,
                    MaxRetries = Azure.Storage.Constants.MaxReliabilityRetries,
                    Delay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback? 0.01 : 1),
                    MaxDelay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.1 : 60)
                }
            };
            if (Mode != RecordedTestMode.Live)
            {
                options.AddPolicy(new RecordedClientRequestIdPolicy(Recording), HttpPipelinePosition.PerCall);
            }

            return InstrumentClientOptions(options);
        }

        public BlobServiceClient GetSecondaryStorageReadEnabledServiceClient(TenantConfiguration config, int numberOfReadFailuresToSimulate, bool simulate404 = false)
        {
            BlobClientOptions options = GetBlobOptions();
            options.GeoRedundantSecondaryUri = new Uri(config.BlobServiceSecondaryEndpoint);
            options.Retry.MaxRetries = 4;
            options.AddPolicy(new TestExceptionPolicy(numberOfReadFailuresToSimulate, options.GeoRedundantSecondaryUri, simulate404), HttpPipelinePosition.PerRetry);

            return InstrumentClient(
                 new BlobServiceClient(
                    new Uri(config.BlobServiceEndpoint),
                    new StorageSharedKeyCredential(config.AccountName, config.AccountKey),
                    options));
        }
    }
}
