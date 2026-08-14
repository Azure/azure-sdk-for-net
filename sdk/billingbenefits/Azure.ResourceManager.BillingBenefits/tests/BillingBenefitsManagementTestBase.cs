// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;

namespace Azure.ResourceManager.BillingBenefits.Tests
{
    public class BillingBenefitsManagementTestBase : ManagementRecordedTestBase<BillingBenefitsManagementTestEnvironment>
    {
        public string SubscriptionId { get; set; }
        public ArmClient Client { get; private set; }
        public ResourceGroupCollection ResourceGroupsOperations { get; set; }
        public SubscriptionResource Subscription { get; set; }

        protected BillingBenefitsManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected BillingBenefitsManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            Subscription = await Client.GetDefaultSubscriptionAsync();
            ResourceGroupsOperations = Subscription.GetResourceGroups();
        }
    }
}
