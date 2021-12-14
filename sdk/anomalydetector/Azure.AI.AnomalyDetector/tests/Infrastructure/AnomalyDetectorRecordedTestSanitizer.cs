// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core.TestFramework;

namespace Azure.AI.AnomalyDetector.Tests
{
    public class AnomalyDetectorRecordedTestSanitizer : RecordedTestSanitizer
    {
        public AnomalyDetectorRecordedTestSanitizer()
            : base()
        {
            AddJsonPathSanitizer("$..accessToken");
            AddJsonPathSanitizer("$..source");
            SanitizedHeaders.Add(Constants.AuthorizationHeader);
        }
    }
}
