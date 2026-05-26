// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.ResourceManager.Monitor.Slis.Tests
{
    public class SlisManagementTestEnvironment : TestEnvironment
    {
        public string ServiceGroupName => GetRecordedOptionalVariable("SERVICE_GROUP_NAME") ?? "arm-sdk-tests-sg";

        public string AmwResourceId => GetRecordedOptionalVariable("AMW_RESOURCE_ID");

        public string ManagedIdentityResourceId => GetRecordedOptionalVariable("MANAGED_IDENTITY_RESOURCE_ID");

        public string SourceAmwResourceId => GetRecordedOptionalVariable("SOURCE_AMW_RESOURCE_ID") ?? AmwResourceId;

        public string SourceManagedIdentityResourceId => GetRecordedOptionalVariable("SOURCE_MANAGED_IDENTITY_RESOURCE_ID") ?? ManagedIdentityResourceId;

        // SLI test subscriptions live in the Microsoft corp tenant rather than the Azure SDK test tenant,
        // so prefer AzureCliCredential when no service principal is configured. CI uses ClientSecretCredential
        // via CLIENT_SECRET/CLIENT_ID/TENANT_ID env vars (handled by the base class).
        protected override TokenCredential CreateDeveloperCredential() => new AzureCliCredential();
    }
}
