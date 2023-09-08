// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Threading.Tasks;
using Azure.ResourceManager.NewRelicObservability.Models;
using System.Collections.Generic;

namespace Azure.ResourceManager.NewRelicObservability.Tests
{
    public class NewrelicManagementTestBase : ManagementRecordedTestBase<NewrelicManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        protected AzureLocation DefaultLocation => "centraluseuap";

        private ResourceGroupResource _resourceGroup;

        protected NewrelicManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected NewrelicManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroupAsync()
        {
            string rgName = Recording.GenerateAssetName("SDKTestNRRG-");
            ResourceGroupData input = new ResourceGroupData(DefaultLocation);
            var lro = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<NewRelicMonitorResourceCollection> GetMonitorResourceCollectionAsync()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            return _resourceGroup.GetNewRelicMonitorResources();
        }

        protected async Task<NewRelicMonitorResource> CreateMonitorResourceAsync(string monitorName)
        {
            var collection = await GetMonitorResourceCollectionAsync();
            var input = GetMonitorInput();

            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, monitorName, input);
            return lro.Value;
        }

        protected async Task<NewRelicMonitorResource> CreateMonitorResourceLinkWithOrgWithPlanAsync(string monitorName)
        {
            var collection = await GetMonitorResourceCollectionAsync();
            var input = GetMonitorLinkWithOrgWithPlanInput();

            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, monitorName, input);
            return lro.Value;
        }

        protected async Task<NewRelicMonitorResource> CreateMonitorResourceLinkWithOrgWithoutPlanAsync(string monitorName)
        {
            var collection = await GetMonitorResourceCollectionAsync();
            var input = GetMonitorLinkWithOrgWithPlanInput();

            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, monitorName, input);
            return lro.Value;
        }

        public NewRelicMonitorResourceData GetMonitorInput()
        {
            var aadDomains = new List<string>();
            aadDomains.Add("SDKTest");

            return new NewRelicMonitorResourceData(DefaultLocation)
            {
                UserInfo = new NewRelicObservabilityUserInfo
                {
                    FirstName = "vipray",
                    LastName = "jain",
                    PhoneNumber = "1234567890",
                    Country = "IN",
                    EmailAddress = "viprayjain@microsoft.com"
                },
                PlanData = new NewRelicPlanDetails
                {
                    UsageType = "PAYG",
                    BillingCycle = "MONTHLY",
                    PlanDetails = "newrelic-pay-as-you-go-free-live@TIDgmz7xq9ge3py@PUBIDnewrelicinc1635200720692.newrelic_liftr_payg",
                    EffectiveOn = new System.DateTimeOffset(2022, 9, 28, 8, 12, 30, new System.TimeSpan(1, 0, 0))
                }
            };
        }

        public NewRelicMonitorResourceData GetMonitorLinkWithOrgWithPlanInput()
        {
            var aadDomains = new List<string>();
            aadDomains.Add("SDKTest");

            return new NewRelicMonitorResourceData(DefaultLocation)
            {
                UserInfo = new NewRelicObservabilityUserInfo
                {
                    FirstName = "vipray",
                    LastName = "jain",
                    PhoneNumber = "1234567890",
                    Country = "IN",
                    EmailAddress = "viprayjain@microsoft.com"
                },
                PlanData = new NewRelicPlanDetails
                {
                    UsageType = "PAYG",
                    BillingCycle = "MONTHLY",
                    PlanDetails = "newrelic-pay-as-you-go-free-live@TIDgmz7xq9ge3py@PUBIDnewrelicinc1635200720692.newrelic_liftr_payg",
                    EffectiveOn = new System.DateTimeOffset(2022, 9, 28, 8, 12, 30, new System.TimeSpan(1, 0, 0))
                },
                NewRelicAccountProperties = new NewRelicAccountProperties
                {
                    OrganizationInfo = new NewRelicObservabilityOrganizationInfo
                    {
                        OrganizationId = "fe5759fb-092a-4353-906b-74df3b17f3d4"
                    }
                }
            };
        }

        public NewRelicMonitorResourceData GetMonitorLinkWithOrgWithoutPlanInput()
        {
            var aadDomains = new List<string>();
            aadDomains.Add("SDKTest");

            return new NewRelicMonitorResourceData(DefaultLocation)
            {
                UserInfo = new NewRelicObservabilityUserInfo
                {
                    FirstName = "vipray",
                    LastName = "jain",
                    PhoneNumber = "1234567890",
                    Country = "IN",
                    EmailAddress = "viprayjain@microsoft.com"
                },
                NewRelicAccountProperties = new NewRelicAccountProperties
                {
                    OrganizationInfo = new NewRelicObservabilityOrganizationInfo
                    {
                        OrganizationId = "fe5759fb-092a-4353-906b-74df3b17f3d4"
                    }
                }
            };
        }
    }
}
