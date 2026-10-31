// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
            // Teardown requests tokens in parallel, which can exceed the default az CLI process timeout.
            return new AzureCliCredential(new AzureCliCredentialOptions { ProcessTimeout = TimeSpan.FromMinutes(2) });
        }
    }
}
