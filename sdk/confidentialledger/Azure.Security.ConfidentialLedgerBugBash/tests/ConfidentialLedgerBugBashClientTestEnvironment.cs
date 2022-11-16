// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Security.ConfidentialLedgerBugBash.Tests
{
    public class ConfidentialLedgerBugBashClientTestEnvironment : TestEnvironment
    {
        public string Endpoint => GetRecordedVariable("ConfidentialLedgerBugBash_ENDPOINT");

        // Add other client paramters here as above.
    }
}
