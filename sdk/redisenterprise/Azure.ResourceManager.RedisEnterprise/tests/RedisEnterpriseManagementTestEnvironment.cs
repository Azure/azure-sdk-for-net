// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.ResourceManager.RedisEnterprise.Tests
{
    public class RedisEnterpriseManagementTestEnvironment : TestEnvironment
    {
        protected override TokenCredential CreateDeveloperCredential()
            => new ChainedTokenCredential(
                new AzureCliCredential(),
                base.CreateDeveloperCredential());
    }
}
