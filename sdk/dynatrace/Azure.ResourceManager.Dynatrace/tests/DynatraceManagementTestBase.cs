// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Dynatrace.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Dynatrace.Tests
{
    public class DynatraceManagementTestBase : ManagementRecordedTestBase<DynatraceManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected AzureLocation DefaultLocation => AzureLocation.EastUS;
        protected SubscriptionResource DefaultSubscription { get; private set; }

        private ResourceGroupResource _resourceGroup;

        protected DynatraceManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected DynatraceManagementTestBase(bool isAsync)
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
            string rgName = Recording.GenerateAssetName("SDKTestRG-");
            ResourceGroupData input = new ResourceGroupData(DefaultLocation);
            var lro = await DefaultSubscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        protected async Task<DynatraceMonitorCollection> GetMonitorResourceCollectionAsync()
        {
            _resourceGroup = await CreateResourceGroupAsync();
            return _resourceGroup.GetDynatraceMonitors();
        }

        protected async Task<DynatraceMonitorResource> CreateMonitorResourceAsync(string monitorName)
        {
            var collection = await GetMonitorResourceCollectionAsync();
            var input = GetMonitorInput();

            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, monitorName, input);
            return lro.Value;
        }

        public DynatraceMonitorData GetMonitorInput()
        {
            var aadDomains = new List<string>();
            aadDomains.Add("SDKTest");

            return new DynatraceMonitorData(DefaultLocation)
            {
                UserInfo = new DynatraceMonitorUserInfo
                {
                    FirstName = "Yao",
                    LastName = "Kou",
                    PhoneNumber = "1234567890",
                    Country = "US",
                    EmailAddress = "yaokou@microsoft.com"
                },
                PlanData = new DynatraceBillingPlanInfo
                {
                    UsageType = "COMMITTED",
                    BillingCycle = "Monthly",
                    PlanDetails = "azureportalintegration_privatepreview@TIDhjdtn7tfnxcy",
                    EffectiveOn = new System.DateTimeOffset(2022, 9, 28, 8, 12, 30, new System.TimeSpan(1, 0, 0))
                },
                DynatraceEnvironmentProperties = new DynatraceEnvironmentProperties
                {
                    SingleSignOnProperties = new DynatraceSingleSignOnProperties(
                        DynatraceSingleSignOnState.Disable,
                        null,
                        new System.Uri("http://www.contoso.com/"),
                        aadDomains,
                        DynatraceProvisioningState.Accepted, null)
                }
            };
        }
    }
}
