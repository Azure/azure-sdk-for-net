// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.Monitor.Slis.Tests
{
    public class SlisManagementTestEnvironment : TestEnvironment
    {
        public string ServiceGroupName => GetRecordedOptionalVariable("SERVICE_GROUP_NAME") ?? "arm-sdk-tests-sg";

        public string AmwResourceId => GetRecordedOptionalVariable("AMW_RESOURCE_ID")
            ?? "/subscriptions/6820e35f-0fe6-4af3-aad2-27414fa82621/resourceGroups/mfrei/providers/microsoft.monitor/accounts/streaming-3p-slo-am2cbn-eastus2euap-1";

        public string ManagedIdentityResourceId => GetRecordedOptionalVariable("MANAGED_IDENTITY_RESOURCE_ID")
            ?? "/subscriptions/6820e35f-0fe6-4af3-aad2-27414fa82621/resourceGroups/mfrei/providers/Microsoft.ManagedIdentity/userAssignedIdentities/mfrei-test-user-managed-identity";

        public string SourceAmwResourceId => GetRecordedOptionalVariable("SOURCE_AMW_RESOURCE_ID") ?? AmwResourceId;

        public string SourceManagedIdentityResourceId => GetRecordedOptionalVariable("SOURCE_MANAGED_IDENTITY_RESOURCE_ID") ?? ManagedIdentityResourceId;
    }
}
