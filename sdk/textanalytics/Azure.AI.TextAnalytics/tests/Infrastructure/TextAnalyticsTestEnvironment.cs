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
        public string MultiClassificationProjectName = "7cdace98-537b-494a-b69a-c19754718025";
        public string MultiClassificationDeploymentName = "7cdace98-537b-494a-b69a-c19754718025";
        public string RecognizeCustomEntitesProjectName = "88ee0f78-fbca-444d-98e2-7c4c8631e494";
        public string RecognizeCustomEntitesDeploymentName = "88ee0f78-fbca-444d-98e2-7c4c8631e494";
    }
}
