// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Dynatrace.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Dynatrace.Tests
{
    public class MonitorTestBase : DynatraceManagementTestBase
    {
        protected ResourceGroupResource _resourceGroup;
        protected GenericResourceCollection _genericResourceCollection;

        public MonitorTestBase(bool isAsync) : base(isAsync)
        {
        }

        public MonitorTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        protected async Task<DynatraceMonitorCollection> GetMonitorResourceCollectionAsync()
        {
            _genericResourceCollection = Client.GetGenericResources();
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
                    FirstName = "Divyansh",
                    LastName = "Agarwal",
                    PhoneNumber = "1234567890",
                    Country = "US",
                    EmailAddress = "agarwald@microsoft.com"
                },
                PlanData = new DynatraceBillingPlanInfo
                {
                    UsageType = "COMMITTED",
                    BillingCycle = "Monthly",
                    PlanDetails = "dynatraceapitestplan",
                    EffectiveOn = new System.DateTimeOffset(2022, 5, 26, 8, 12, 30, new System.TimeSpan(1,0,0))
                },
                DynatraceEnvironmentProperties = new DynatraceEnvironmentProperties
                {
                    SingleSignOnProperties = new DynatraceSingleSignOnProperties(
                        DynatraceSingleSignOnState.Disable,
                        null,
                        new System.Uri("http://www.contoso.com/"),
                        aadDomains,
                        DynatraceProvisioningState.Accepted
                    )
                }
            };
        }
    }
}
