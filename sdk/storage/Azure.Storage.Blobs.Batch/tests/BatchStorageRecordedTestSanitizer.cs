// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using System.Text.RegularExpressions;
using Azure.Core.TestFramework.Models;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.Blobs.Batch.Tests
{
    public class BatchStorageRecordedTestSanitizer : StorageRecordedTestSanitizer
    {
        private static Regex pattern = new Regex(@"sig=\S+\s", RegexOptions.Compiled);

        public BatchStorageRecordedTestSanitizer()
        {
            BodyRegexSanitizers.Add(new BodyRegexSanitizer(@"sig=(?<group>.*?)(?=\s+)", SanitizeValue)
            {
                GroupForReplace = "group"
            });
        }
    }
}
