// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using System;

namespace Azure.ResourceManager.ConfidentialLedger.Tests
{
    public class AclManagementTestEnvironment : TestEnvironment
    {
        public string TestLedgerNamePrefix
        {
            get
            {
                try
                {
                    return GetRecordedVariable("TEST_LEDGER_NAME_PREFIX");
                }
                catch (Exception)
                {
                    return "dotnet-sdk-test-ledger-";
                }
            }
        }
        public string TestUserObjectId => GetRecordedVariable("CONFIDENTIALLEDGER_CLIENT_OBJECTID");
    }
}
