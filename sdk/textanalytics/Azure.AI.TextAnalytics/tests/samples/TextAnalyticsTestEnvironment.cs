// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.TextAnalytics.Samples
{
    public class TextAnalyticsTestEnvironment: TestEnvironment
    {
        public TextAnalyticsTestEnvironment() : base("textanalytics")
        {
        }

        public string Endpoint => GetRecordedVariable("TEXT_ANALYTICS_ENDPOINT");
        public string ApiKey => GetRecordedVariable("TEXT_ANALYTICS_API_KEY");
    }
}