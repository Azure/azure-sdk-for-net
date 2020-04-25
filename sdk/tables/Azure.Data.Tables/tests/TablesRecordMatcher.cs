// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;

namespace Azure.Data.Tables.Tests
{
    public class TablesRecordMatcher : RecordMatcher
    {
        public TablesRecordMatcher(RecordedTestSanitizer sanitizer) : base(sanitizer)
        {
            ExcludeHeaders.Add("Content-Type");
        }
    }
}
