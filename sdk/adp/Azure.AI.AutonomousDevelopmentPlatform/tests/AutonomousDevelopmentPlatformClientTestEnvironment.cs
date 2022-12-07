// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.AutonomousDevelopmentPlatform.Tests
{
    public class AutonomousDevelopmentPlatformClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("AutonomousDevelopmentPlatform_ENDPOINT");

        // Add other client paramters here as above.
    }
}
