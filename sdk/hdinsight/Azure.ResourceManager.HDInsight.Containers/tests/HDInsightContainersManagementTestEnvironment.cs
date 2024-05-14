// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.HDInsight.Containers.Tests
{
    public class HDInsightContainersManagementTestEnvironment : TestEnvironment
    {
        public new string SubscriptionId => GetRecordedVariable("SUBSCRIPTION_ID", options => options.IsSecret("00000000-0000-0000-0000-000000000000"));
        public new string ClientId => GetRecordedVariable("CLIENT_ID", options => options.IsSecret());
        public new string TenantId => GetRecordedVariable("TENANT_ID", options => options.IsSecret("00000000-0000-0000-0000-000000000000"));
    }
}
