// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Management.KeyVault.Tests
{
    public class KeyVaultManagementTestEnvironment : TestEnvironment
    {
        public KeyVaultManagementTestEnvironment() : base("keyvalutmgmt")
        {
        }
    }
}
