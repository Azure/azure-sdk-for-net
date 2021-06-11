// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.Tests
{
    [ClientTestFixture(
    BlobClientOptions.ServiceVersion.V2020_06_12,
    BlobClientOptions.ServiceVersion.V2020_08_04,
    RecordingServiceVersion = BlobClientOptions.ServiceVersion.V2020_08_04,
    LiveServiceVersions = new object[] { BlobClientOptions.ServiceVersion.V2020_06_12 })]
    public abstract class DataMovementTestBase : StorageTestBase<StorageTestEnvironment>
    {
        public DataMovementTestBase(bool async, BlobClientOptions.ServiceVersion serviceVersion, RecordedTestMode? mode = null)
            : base(async, mode /* RecordedTestMode.Record to re-record */)
        {
        }

        [SetUp]
        public void Setup()
        {
        }
    }
}
