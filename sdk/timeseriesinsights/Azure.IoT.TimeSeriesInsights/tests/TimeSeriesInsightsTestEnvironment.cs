// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.IoT.TimeSeriesInsights.Tests
{
    public class TimeSeriesInsightsTestEnvironment : TestEnvironment
    {
        public string TimeSeriesInsightsHostname => GetRecordedVariable(
            $"{TestSettings.TsiEnvironmentVariablesPrefix}_URL",
            options => options.IsSecret(TestUrlSanitizer.FAKE_HOST));

        public string IoTHubConnectionString => GetRecordedVariable(
            $"{TestSettings.IoTHubConnectionStringEnvironmentVariable}",
            options => options.HasSecretConnectionStringParameter(nameof(TestSettings.IoTHubConnectionStringEnvironmentVariable)));
    }
}
