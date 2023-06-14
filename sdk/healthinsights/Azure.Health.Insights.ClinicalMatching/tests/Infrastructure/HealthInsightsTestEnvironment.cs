// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Health.Insights.ClinicalMatching.Tests.Infrastructure
{
    public class HealthInsightsTestEnvironment : TestEnvironment
    {
        /// <summary>The name of the environment variable from which the Health Insights resource's endpoint will be extracted for the live tests.</summary>
        internal const string EndpointEnvironmentVariableName = "AZURE_HEALTH_INSIGHTS_ENDPOINT";

        /// <summary>The name of the environment variable from which the Health Insights resource's API key will be extracted for the live tests.</summary>
        internal const string ApiKeyEnvironmentVariableName = "AZURE_HEALTH_INSIGHTS_API_KEY";

        public string ApiKey => GetRecordedVariable(ApiKeyEnvironmentVariableName, options => options.IsSecret());
        public string Endpoint => GetRecordedVariable(EndpointEnvironmentVariableName);
    }
}
