// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.ConfidentialLedger.Tests
{
    public class AclManagementTestEnvironment : TestEnvironment
    {
        public string TestLedgerNamePrefix => GetRecordedVariable("TEST-LEDGER-NAME-PREFIX");
        public string TestUserObjectId => GetRecordedVariable("TEST-USER-OBJECT-ID");
    }
}
