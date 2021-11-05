// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Storage.Test.Shared
{
    public class StorageTestEnvironment : TestEnvironment
    {
        protected TokenCredential GetOAuthCredential(TenantConfiguration tenantConfiguration)
        {
            return new ClientSecretCredential(
                tenantConfiguration.ActiveDirectoryTenantId,
                tenantConfiguration.ActiveDirectoryApplicationId,
                tenantConfiguration.ActiveDirectoryApplicationSecret,
                new TokenCredentialOptions() { AuthorityHost = new Uri(tenantConfiguration.ActiveDirectoryAuthEndpoint) });
        }
    }
}
