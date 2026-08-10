// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.ResourceManager.FileShares.Tests
{
    public class FileSharesManagementTestEnvironment : TestEnvironment
    {
        protected override TokenCredential CreateDeveloperCredential()
        {
            // Use AzureCliCredential directly to authenticate against the canary tenant
            // since the default broker credential targets the Azure SDK test tenant.
            return new AzureCliCredential();
        }
    }
}
