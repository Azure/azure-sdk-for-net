// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Security.SDKReleasePlannerTest.Tests
{
    public class SDKReleasePlannerTestClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("SDKReleasePlannerTest_ENDPOINT");

        // Add other client paramters here as above.
    }
}
