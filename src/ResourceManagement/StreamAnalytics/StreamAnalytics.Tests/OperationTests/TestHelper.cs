// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Linq;
using System.Net.Http;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.StreamAnalytics;
using Microsoft.Azure.Management.StreamAnalytics.Models;
using Microsoft.WindowsAzure.Management;
using Microsoft.Azure.Test;

namespace StreamAnalytics.Tests.OperationTests
{
    class TestHelper
    {
        // Azure Storage secrets
        public const string AccountName = "exchangeevent";
        public const string AccountKey = @"LVn3eQSK8GoBkPG4zpHEESzaoI3L2HnzuWIm2rkEA9ybnxlA1EJ3VeB6kld4OH+aR1COn0/aeZz+ynldcgMJSg==";

        // Event Hub/Service Bus secrets
        public const string EventHubName = "sdkeventhub";
        public const string ServiceBusNamespace = "sdktest";
        public const string SharedAccessPolicyName = "RootManageSharedAccessKey";
        public const string SharedAccessPolicyKey = @"CnZzqHjkAx2HKXVtnmMvCtbFGq+iFyvzhjO7rBAEaOE=";

        // IoT Hub secrets
        public const string IoTHubNamespace = "ZivIoTHub";
        public const string IotHubSharedAccessPolicyKey = @"caL8uCB0BxnPUnbmACgENpuqdyGLig5P5IoJLT4pIQ9=";
        
        // DocumentDB secrets
        public const string DocDbAccountId = "ibizaloctest001docdb";
        public const string DocDbAccountKey = @"0slkXPyx4q97Q+QxCtT1TnvP+XEfbfVG3qG+1B+uzD0TA+IQ5/VSi49y2gS4pRrqe+hXj704zvTR5x59R3H0Hg==";

        // SQL Azure secrets
        public const string Server = "z102fk12be";
        public const string Database = "HydraSdkTest";
        public const string User = "customersolution";
        public const string Password = "y3%rNk9*";

        /// <summary>
        /// Generate a Resource Management client from the test base to use for managing resource groups.
        /// </summary>
        /// <returns>Resource Management client</returns>
        public static ResourceManagementClient GetResourceClient(DelegatingHandler handler)
        {
            CSMTestEnvironmentFactory factory = new CSMTestEnvironmentFactory();
            return TestBase.GetServiceClient<ResourceManagementClient>(factory).WithHandler(handler);
        }

        public static StreamAnalyticsManagementClient GetStreamAnalyticsManagementClient(DelegatingHandler handler)
        {
            CSMTestEnvironmentFactory factory = new CSMTestEnvironmentFactory();
            return TestBase.GetServiceClient<StreamAnalyticsManagementClient>(factory).WithHandler(handler);
        }

        public static string GetDefaultLocation()
        {
            ManagementClient managementClient = TestBase.GetServiceClient<ManagementClient>();

            var serviceLocations = managementClient.Locations.ListAsync()
                    .Result.ToList();

            return serviceLocations.Any(l => l.Name.Equals("West US"))
                ? "West US"
                : serviceLocations.FirstOrDefault().Name;
        }

        // Construct the general Job object
        public static Job GetDefaultJob(string resourceName, string serviceLocation)
        {
            Job job = new Job
            {
                Name = resourceName,
                Location = serviceLocation,
                Properties = new JobProperties
                {
                    Sku = new Sku()
                    {
                        Name = "standard"
                    },
                    EventsOutOfOrderPolicy = EventsOutOfOrderPolicy.Drop,
                    EventsOutOfOrderMaxDelayInSeconds = 0
                } 
            };

            return job;
        }
    }
}