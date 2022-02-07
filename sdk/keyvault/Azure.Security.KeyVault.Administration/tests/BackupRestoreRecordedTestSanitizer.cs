// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.RegularExpressions;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.Security.KeyVault.Tests;

namespace Azure.Security.KeyVault.Administration.Tests
{
    public class BackupRestoreRecordedTestSanitizer : RecordedTestSanitizer
    {
        public BackupRestoreRecordedTestSanitizer()
            : base()
        {
            AddJsonPathSanitizer("$..token");
            UriRegexSanitizers.Add(UriRegexSanitizer.CreateWithQueryParameter("sig", SanitizeValue));
        }
    }
}
