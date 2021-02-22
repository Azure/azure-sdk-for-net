// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using System.Text.RegularExpressions;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.Blobs.Batch.Tests
{
    public class BatchStorageRecordedTestSanitizer : StorageRecordedTestSanitizer
    {
        private static Regex pattern = new Regex(@"sig=\S+\s", RegexOptions.Compiled);

        public override byte[] SanitizeBody(string contentType, byte[] body)
        {
            if (contentType != null && contentType.Contains("multipart/mixed"))
            {
                string bodyAsString = Encoding.UTF8.GetString(body);
                bodyAsString = pattern.Replace(bodyAsString, "sig=Sanitized ");
                return Encoding.UTF8.GetBytes(bodyAsString);
            }
            else
            {
                return base.SanitizeBody(contentType, body);
            }
        }
    }
}
