// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.KeyVault.Tests
{
    public class KeyVaultManagementTestEnvironment : TestEnvironment
    {
        // Key Vault tests require one more environment variable AZURE_OBJECT_ID
        // See https://learn.microsoft.com/en-us/azure/cost-management-billing/manage/assign-roles-azure-service-principals#find-your-spn-and-tenant-id to get the object Id of the credential
        public string ObjectId => GetRecordedVariable("OBJECT_ID");
    }
}
