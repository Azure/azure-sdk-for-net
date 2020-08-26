// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.DigitalTwins.Core.Tests
{
    public class DigitalTwinsTestEnvironment : TestEnvironment
    {
        public DigitalTwinsTestEnvironment()
            : base(TestSettings.AdtEnvironmentVariablesPrefix.ToLower())
        {
        }

        public string DigitalTwinHostname => GetRecordedVariable($"{TestSettings.AdtEnvironmentVariablesPrefix}_URL",
        options => options.IsSecret(TestUrlSanitizer.FAKE_HOST));
    }
}
