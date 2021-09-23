// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.TextAnalytics.Tests
{
    public class TextAnalyticsTestEnvironment: TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("TEXT_ANALYTICS_ENDPOINT");
        public string ApiKey => GetRecordedVariable("TEXT_ANALYTICS_API_KEY", options => options.IsSecret());
        public string SingleClassificationProjectName = "659c1851-be0b-4142-b12a-087da9785926";
        public string SingleClassificationDeploymentName = "659c1851-be0b-4142-b12a-087da9785926";
    }
}
