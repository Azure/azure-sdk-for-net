// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement.Tests
{
    public class StartTransferDownloadDirectoryTests : DataMovementBlobTestBase
    {
        public StartTransferDownloadDirectoryTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        { }

        internal class VerifyDownloadBlobContentInfo
        {
            public readonly string SourceLocalPath;
            public readonly string DestinationLocalPath;
            public SingleTransferOptions DownloadOptions;
            public AutoResetEvent CompletedStatusWait;

            public VerifyDownloadBlobContentInfo(
                string sourceFile,
                string destinationFile,
                SingleTransferOptions downloadOptions,
                AutoResetEvent completedStatusWait)
            {
                SourceLocalPath = sourceFile;
                DestinationLocalPath = destinationFile;
                DownloadOptions = downloadOptions;
                CompletedStatusWait = completedStatusWait;
            }
        };
    }
}
