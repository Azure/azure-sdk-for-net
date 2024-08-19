// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using NUnit.Framework;

namespace Azure.Core.TestFramework.Tests
{
    [ClientTestFixture(true, FakeClientVersion.V0, FakeClientVersion.V4)]
    public class RecordedClientTestBaseRecordAll : RecordedTestBase
    {
        public RecordedClientTestBaseRecordAll(bool isAsync, FakeClientVersion version)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [RecordedTest]
        public void ValidateFilename()
        {
            string filename = Path.GetFileName(GetSessionFilePath());
            bool isAsyncFileV0 = filename == "ValidateFilename[V0]Async.json";
            bool isAsyncFileV4 = filename == "ValidateFilename[V4]Async.json";
            bool isSyncFileV0 = filename == "ValidateFilename[V0].json";
            bool isSyncFileV4 = filename == "ValidateFilename[V4].json";
            Assert.IsTrue(isAsyncFileV4 || isAsyncFileV0 || isSyncFileV0 || isSyncFileV4);
        }
    }
}
