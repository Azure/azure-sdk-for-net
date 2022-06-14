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

        protected async Task<MonitorResourceCollection> GetMonitorResourceCollectionAsync()
        {
            _genericResourceCollection = Client.GetGenericResources();
            _resourceGroup = await CreateResourceGroupAsync();
            return _resourceGroup.GetMonitorResources();
        }

        protected async Task<MonitorResource> CreateMonitorResourceAsync(string monitorName)
        {
            var collection = await GetMonitorResourceCollectionAsync();
            var input = GetMonitorInput();

            var lro = await collection.CreateOrUpdateAsync(WaitUntil.Completed, monitorName, input);
            return lro.Value;
        }

        public MonitorResourceData GetMonitorInput()
        {
            var aadDomains = new List<string>();
            aadDomains.Add("SDKTest");

            return new MonitorResourceData(DefaultLocation)
            {
                UserInfo = new UserInfo
                {
                    FirstName = "Divyansh",
                    LastName = "Agarwal",
                    PhoneNumber = "1234567890",
                    Country = "US",
                    EmailAddress = "agarwald@microsoft.com"
                },
                PlanData = new PlanData
                {
                    UsageType = "COMMITTED",
                    BillingCycle = "Monthly",
                    PlanDetails = "azureportalintegration_privatepreview",
                    EffectiveOn = new System.DateTimeOffset(2022, 5, 26, 8, 12, 30, new System.TimeSpan(1,0,0))
                },
                DynatraceEnvironmentProperties = new DynatraceEnvironmentProperties
                {
                    SingleSignOnProperties = new DynatraceSingleSignOnProperties(
                        SingleSignOnStates.Disable,
                        null,
                        new System.Uri("http://www.contoso.com/"),
                        aadDomains,
                        ProvisioningState.Accepted
                    )
                }
            };
        }
    }
}
