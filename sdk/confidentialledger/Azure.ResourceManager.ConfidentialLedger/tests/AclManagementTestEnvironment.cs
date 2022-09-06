// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.ResourceManager.ConfidentialLedger.Tests
{
    public class AclManagementTestEnvironment : TestEnvironment
    {
        public const string TestSubscriptionId = "027da7f8-2fc6-46d4-9be9-560706b60fec";
        public const string TestResourceGroup = "sdk-test-rg";
        public const string TestLedgerName = "dotnet-sdk-test-ledger2";
    }
}
