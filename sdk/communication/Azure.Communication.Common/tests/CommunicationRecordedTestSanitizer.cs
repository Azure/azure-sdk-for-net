// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Communication.Pipeline
{
    public class CommunicationRecordedTestSanitizer : RecordedTestSanitizer
    {
        public CommunicationRecordedTestSanitizer()
        {
            SanitizedHeaders.Add("x-ms-content-sha256");
        }
    }
}
