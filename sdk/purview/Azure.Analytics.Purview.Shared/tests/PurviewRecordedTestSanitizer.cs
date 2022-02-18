// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Analytics.Purview.Tests
{
    public class PurviewRecordedTestSanitizer : RecordedTestSanitizer
    {
        public PurviewRecordedTestSanitizer() : base()
        {
            JsonPathSanitizers.Add("$..atlasKafkaPrimaryEndpoint");
            JsonPathSanitizers.Add("$..atlasKafkaSecondaryEndpoint");
        }
    }
}
