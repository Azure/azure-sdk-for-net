// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core.TestFramework;

namespace Azure.AI.Personalizer.Tests
{
    public class PersonalizerRecordedTestSanitizer : RecordedTestSanitizer
    {
        public PersonalizerRecordedTestSanitizer() : base()
        {
            AddJsonPathSanitizer("$..accessToken");
            AddJsonPathSanitizer("$..source");
            SanitizedHeaders.Add("Ocp-Apim-Subscription-Key");
            // TODO: Remove when re-recording
            LegacyConvertJsonDateTokens = true;
        }
    }
}
