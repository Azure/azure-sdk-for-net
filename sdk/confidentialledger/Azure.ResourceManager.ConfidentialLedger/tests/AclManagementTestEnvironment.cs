// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.ResourceManager.ConfidentialLedger.Tests
{
    public class AclManagementTestEnvironment : TestEnvironment
    {
        public string TestResourceGroup => "sdk-test-rg";
        public string TestLedgerName => "dotnet-sdk-test-ledger";
    }
}
