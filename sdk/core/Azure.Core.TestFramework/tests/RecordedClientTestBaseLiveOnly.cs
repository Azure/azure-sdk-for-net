// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using NUnit.Framework;

namespace Azure.Core.TestFramework.Tests
{
    [ClientTestFixture(FakeClientVersion.V0, FakeClientVersion.V4)]
    public class RecordedClientTestBaseLiveOnly : RecordedTestBase
    {
        public RecordedClientTestBaseLiveOnly(bool isAsync, FakeClientVersion version)
            : base(isAsync)//, RecordedTestMode.Record)
        {
        }

        [RecordedTest]
        public void ValidateFilename()
        {
            string filename = Path.GetFileName(GetSessionFilePath());
            bool isAsyncFile = filename == "ValidateFilenameAsync.json";
            bool isSyncFile = filename == "ValidateFilename.json";
            Assert.IsTrue(isAsyncFile || isSyncFile);
        }
    }
}
