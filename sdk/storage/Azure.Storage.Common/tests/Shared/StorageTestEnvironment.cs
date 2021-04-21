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
        protected TokenCredential OAuthCredential { get; } = new ClientSecretCredential(
                    TestConfigurations.DefaultTargetOAuthTenant.ActiveDirectoryTenantId,
                    TestConfigurations.DefaultTargetOAuthTenant.ActiveDirectoryApplicationId,
                    TestConfigurations.DefaultTargetOAuthTenant.ActiveDirectoryApplicationSecret,
                    new TokenCredentialOptions() { AuthorityHost = new Uri(TestConfigurations.DefaultTargetOAuthTenant.ActiveDirectoryAuthEndpoint) });
    }
}
