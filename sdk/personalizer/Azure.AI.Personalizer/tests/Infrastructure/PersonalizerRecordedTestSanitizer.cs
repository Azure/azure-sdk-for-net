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
            JsonPathSanitizers.Add("$..accessToken");
            JsonPathSanitizers.Add("$..source");
            SanitizedHeaders.Add("Ocp-Apim-Subscription-Key");
        }
    }
}
