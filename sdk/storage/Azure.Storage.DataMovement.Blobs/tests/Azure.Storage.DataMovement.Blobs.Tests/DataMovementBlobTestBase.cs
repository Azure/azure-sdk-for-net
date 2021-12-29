// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Test.Shared;
using Azure.Core.TestFramework;

namespace Azure.Storage.Test.Shared
{
    /// <summary>
    /// Base class for Common tests
    /// </summary>
    [ClientTestFixture(
    BlobClientOptions.ServiceVersion.V2020_06_12,
    BlobClientOptions.ServiceVersion.V2020_08_04,
    RecordingServiceVersion = BlobClientOptions.ServiceVersion.V2020_08_04,
    LiveServiceVersions = new object[] { BlobClientOptions.ServiceVersion.V2020_06_12 })]
    public abstract class DataMovementBlobTestBase : DataMovementTestBase
    {
        public DataMovementBlobTestBase(bool async, BlobClientOptions.ServiceVersion serviceVersion, RecordedTestMode? mode = null)
            : base(async, serviceVersion, mode /* RecordedTestMode.Record /* to re-record */)
        {
        }
    }
}
