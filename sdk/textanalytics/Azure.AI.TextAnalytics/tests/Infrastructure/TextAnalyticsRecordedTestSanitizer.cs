// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.Core.TestFramework
{
    public class TextAnalyticsRecordedTestSanitizer : RecordedTestSanitizer
    {
        public TextAnalyticsRecordedTestSanitizer()
        {
            SanitizedHeaders.Add("Ocp-Apim-Subscription-Key");
        }
    }
}
