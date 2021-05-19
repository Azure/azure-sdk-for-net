// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.AnomalyDetector.Tests
{
    /// <summary>
    /// A helper class used to retrieve information to be used for tests.
    /// </summary>
    public class AnomalyDetectorTestEnvironment: TestEnvironment
    {
        /// <summary>The name of the environment variable from which the Anomaly Detector resource's endpoint will be extracted for the live tests.</summary>
        internal const string EndpointEnvironmentVariableName = "ANOMALY_DETECTOR_ENDPOINT";

        /// <summary>The name of the environment variable from which the Anomaly Detector resource's API key will be extracted for the live tests.</summary>
        internal const string ApiKeyEnvironmentVariableName = "ANOMALY_DETECTOR_API_KEY";

        public string ApiKey => GetRecordedVariable(ApiKeyEnvironmentVariableName);
        public string Endpoint => GetRecordedVariable(EndpointEnvironmentVariableName);
    }
}
