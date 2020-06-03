// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.DigitalTwins.Core.Tests
{
    public class DigitalTwinsTestEnvironment : TestEnvironment
    {
        public DigitalTwinsTestEnvironment()
            : base(TestSettings.AdtEnvironmentVariablesPrefix)
        {
        }

        public string DigitalTwinHostname => GetRecordedVariable("DIGITALTWINS_URL");
    }
}
