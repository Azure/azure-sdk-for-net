// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Iot.TimeSeriesInsights.Tests
{
    public class TimeSeriesInsightsTestEnvironment : TestEnvironment
    {
        public TimeSeriesInsightsTestEnvironment()
            : base(TestSettings.TsiEnvironmentVariablesPrefix.ToLower())
        {
        }

        public string TimeSeriesInsightsHostname => GetRecordedVariable($"{TestSettings.TsiEnvironmentVariablesPrefix}_URL", options => options.IsSecret(TestUrlSanitizer.FAKE_HOST));
    }
}
