// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.Nginx.Tests
{
    public class NginxManagementTestEnvironment : TestEnvironment
    {
        public string NginxSubscriptionId => GetRecordedVariable("SUBSCRIPTION_ID");

        public string KeyVaultSecretId => GetRecordedVariable("KeyVaultSecretId");

        public string ManagedIdentityResourceID => GetRecordedVariable("ManagedIdentityResourceID");
    }
}
