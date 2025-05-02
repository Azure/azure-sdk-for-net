// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.ConfidentialLedger.Tests
{
    /// <summary>
    /// Get outputs from test-resource.json and assign them to variables.
    /// </summary>
    public class AclManagementTestEnvironment : TestEnvironment
    {
        public string TestUserObjectId => GetRecordedVariable("CONFIDENTIALLEDGER_CLIENT_OBJECTID");
    }
}
