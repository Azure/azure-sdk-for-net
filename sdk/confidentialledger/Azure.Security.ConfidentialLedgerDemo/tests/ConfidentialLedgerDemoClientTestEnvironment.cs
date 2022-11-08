// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Security.ConfidentialLedgerDemo.Tests
{
    public class ConfidentialLedgerDemoClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("ConfidentialLedgerDemo_ENDPOINT");

        // Add other client paramters here as above.
    }
}
