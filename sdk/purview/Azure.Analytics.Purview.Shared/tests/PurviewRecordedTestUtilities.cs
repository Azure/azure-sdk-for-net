// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Analytics.Purview.Tests
{
    public static class PurviewRecordedTestUtilities
    {
        public static void AddPurviewSanitizers(this RecordedTestBase testBase)
        {
            testBase.JsonPathSanitizers.Add("$..atlasKafkaPrimaryEndpoint");
            testBase.JsonPathSanitizers.Add("$..atlasKafkaSecondaryEndpoint");
        }
    }
}
