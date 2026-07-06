// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.ResourceManager.TrafficManager.Tests
{
    public class TrafficManagerManagementTestEnvironment : TestEnvironment
    {
        protected override TokenCredential CreateDeveloperCredential() => new AzureCliCredential();
    }
}
