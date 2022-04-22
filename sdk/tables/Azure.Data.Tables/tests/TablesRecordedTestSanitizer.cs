// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.RegularExpressions;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;

namespace Azure.Data.Tables.Tests
{
    public class TablesRecordedTestSanitizer : RecordedTestSanitizer
    {
        public TablesRecordedTestSanitizer()
        {
            SanitizedHeaders.Add("My-Custom-Auth-Header");
            UriRegexSanitizers.Add(new UriRegexSanitizer(@"([\x0026|&|?]sig=)(?<group>[\w\d%]+)", SanitizeValue)
            {
                GroupForReplace = "group"
            });
        }
    }
}
