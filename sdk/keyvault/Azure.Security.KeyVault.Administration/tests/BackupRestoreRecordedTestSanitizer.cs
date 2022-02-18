// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class BackupRestoreRecordedTestSanitizer : RecordedTestSanitizer
    {
        public BackupRestoreRecordedTestSanitizer()
            : base()
        {
            JsonPathSanitizers.Add("$..token");
            SanitizedQueryParameters.Add("sig");
        }
    }
}
