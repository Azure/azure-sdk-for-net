// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.ResourceManager.HDInsight.Containers.Tests
{
    public class HDInsightContainersManagementTestEnvironment : TestEnvironment
    {
        public new string SubscriptionId => GetRecordedVariable("SUBSCRIPTION_ID", options => options.IsSecret("10e32bab-26da-4cc4-a441-52b318f824e6"));
        public new string ClientId => GetRecordedVariable("CLIENT_ID", options => options.IsSecret());
        public new string TenantId => GetRecordedVariable("TENANT_ID", options => options.IsSecret("72f988bf-86f1-41af-91ab-2d7cd011db47"));
    }
}
