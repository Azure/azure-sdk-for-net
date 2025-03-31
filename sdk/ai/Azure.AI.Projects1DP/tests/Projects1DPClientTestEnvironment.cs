// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.AI.Projects1DP.Tests
{
    public class Projects1DPClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("Projects1DP_ENDPOINT");

        // Add other client paramters here as above.
    }
}
