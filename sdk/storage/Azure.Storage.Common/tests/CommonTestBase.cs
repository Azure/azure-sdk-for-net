// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using Azure.Core.Pipeline;
using Azure.Core.Testing;
using Azure.Storage.Blobs;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.Common.Test
{
    /// <summary>
    /// Base class for Common tests
    /// </summary>
    public class CommonTestBase : StorageTestBase
    {
        public CommonTestBase(bool async, RecordedTestMode? mode = null)
            : base(async, mode /* RecordedTestMode.Record to re-record */)
        {
        }

        public string GetNewContainerName() => $"test-container-{this.Recording.Random.NewGuid()}";

        /// <summary>
        /// Get BlobClientOptions instrumented for recording.
        /// </summary>
        protected BlobClientOptions GetBlobOptions() =>
            this.Recording.InstrumentClientOptions(
                new BlobClientOptions
                {
                    ResponseClassifier = new TestResponseClassifier(),
                    Diagnostics = { IsLoggingEnabled = true },
                    Retry =
                    {
                        Mode = RetryMode.Exponential,
                        MaxRetries = Constants.MaxReliabilityRetries,
                        Delay = TimeSpan.FromSeconds(this.Mode == RecordedTestMode.Playback ? 0.01 : 0.5),
                        MaxDelay = TimeSpan.FromSeconds(this.Mode == RecordedTestMode.Playback ? 0.1 : 10)
                    }
                });
    }
}
