// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.TextAnalytics.Tests
{
    public class TextAnalyticsTestEnvironment: TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("TEXT_ANALYTICS_ENDPOINT");
        public string ApiKey => GetRecordedVariable("TEXT_ANALYTICS_API_KEY", options => options.IsSecret());

        // The following variables refer to the static test resource, which is
        // used to test the custom text analysis features.
        public string StaticEndpoint => GetRecordedVariable("TEXT_ANALYTICS_STATIC_ENDPOINT");
        public string StaticApiKey => GetRecordedVariable("TEXT_ANALYTICS_STATIC_API_KEY", options => options.IsSecret());
        public string SingleClassificationProjectName => GetRecordedVariable("TEXTANALYTICS_SINGLE_CATEGORY_CLASSIFY_PROJECT_NAME");
        public string SingleClassificationDeploymentName => GetRecordedVariable("TEXTANALYTICS_SINGLE_CATEGORY_CLASSIFY_DEPLOYMENT_NAME");
        public string MultiClassificationProjectName => GetRecordedVariable("TEXTANALYTICS_MULTI_CATEGORY_CLASSIFY_PROJECT_NAME");
        public string MultiClassificationDeploymentName => GetRecordedVariable("TEXTANALYTICS_MULTI_CATEGORY_CLASSIFY_DEPLOYMENT_NAME");
        public string RecognizeCustomEntitiesProjectName => GetRecordedVariable("TEXTANALYTICS_CUSTOM_ENTITIES_PROJECT_NAME");
        public string RecognizeCustomEntitiesDeploymentName => GetRecordedVariable("TEXTANALYTICS_CUSTOM_ENTITIES_DEPLOYMENT_NAME");
    }
}
