// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Batch.Tests.ScenarioTests
{
    public class BatchScenarioTestBase : TestBase
    {
        public ResourceManagementClient ResourceManagementClient { get; private set; }

        public BatchManagementClient BatchManagementClient { get; private set; }

        public string Location { get; private set; }

        protected MockContext StartMockContextAndInitializeClients(
            Type type,
            // Automatically populates the methodName parameter with the calling method, which
            // gets used to generate recorder file names.
            [System.Runtime.CompilerServices.CallerMemberName]
            string methodName = "")
        {
            MockContext context = MockContext.Start(type, methodName);
            Location = FindLocation(context);

            ResourceManagementClient = context.GetServiceClient<ResourceManagementClient>();
            BatchManagementClient = context.GetServiceClient<BatchManagementClient>();
            return context;
        }

        private static string FindLocation(MockContext context)
        {
            var resourceManagementClient = context.GetServiceClient<ResourceManagementClient>();
            Provider provider = resourceManagementClient.Providers.Get("Microsoft.Batch");
            IList <string> locations = provider.ResourceTypes.First(resType => resType.ResourceType == "batchAccounts").Locations;
            return locations.First(location => location == "East US");
        }

        // Can be used to find a region to test against, but probably shouldn't record tests that use this as it will leave your subscription account details in the 
        // logs
        private static string FindLocationWithQuotaCheck(MockContext context)
        {
            var resourceManagementClient = context.GetServiceClient<ResourceManagementClient>();
            var batchManagementClient = context.GetServiceClient<BatchManagementClient>();

            Provider provider = resourceManagementClient.Providers.Get("Microsoft.Batch");
            IEnumerable<string> locations = provider.ResourceTypes.First(resType => resType.ResourceType == "batchAccounts").Locations.DefaultIfEmpty("westus");

            var locationQuotaInUse = batchManagementClient.BatchAccount.List().GroupBy(acct => acct.Location).ToDictionary(a => a.Key, x => x.Count());
            
            foreach(var location in locations)
            {
                var transformedLocation = location.Replace(" ", "").ToLower();
                var quotas = batchManagementClient.Location.GetQuotas(location);
                int accountsInUse;
                locationQuotaInUse.TryGetValue(transformedLocation, out accountsInUse);
                if (quotas.AccountQuota - accountsInUse > 0)
                {
                    return location;
                }
            }

            throw new ArgumentException("No location found that satisfies quota requirements");
        }
    }
}
