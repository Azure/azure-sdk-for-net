// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Analytics.LoadTestService.Tests
{
    public class LoadTestServiceClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("LoadTestService_ENDPOINT");

        // Add other client paramters here as above.
    }
}
