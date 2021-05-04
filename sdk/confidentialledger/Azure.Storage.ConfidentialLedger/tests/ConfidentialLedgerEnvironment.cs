// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Storage.ConfidentialLedger.Tests
{
    public class ConfidentialLedgerEnvironment : TestEnvironment
    {
        public string ConfidentialLedgerUrl => GetRecordedVariable("CONFIDENTIALLEDGER_URL");
        public string ConfidentialLedgerIdentityUrl => GetRecordedVariable("CONFIDENTIALLEDGER_IDENTITY_URL");
    }
}
