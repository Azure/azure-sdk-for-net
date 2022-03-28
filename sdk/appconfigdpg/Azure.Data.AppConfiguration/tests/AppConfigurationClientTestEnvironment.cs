// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Data.AppConfiguration.Tests
{
    public class AppConfigurationClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("AppConfiguration_ENDPOINT");

        // Add other client paramters here as above.
    }
}
