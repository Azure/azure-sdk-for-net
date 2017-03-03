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
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.StreamAnalytics;
using Microsoft.Azure.Management.StreamAnalytics.Models;
using Microsoft.WindowsAzure.Management;
using Microsoft.Azure.Test;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.StreamAnalytics.Testing;
using System.Threading;
using System.Threading.Tasks;

namespace StreamAnalytics.Tests.OperationTests
{
    class TestHelper
    {
        // Azure Storage secrets
        public const string AccountName = "exchangeevent";
        public const string AccountKey = @"$TestStringToBeReplaced";

        // Event Hub/Service Bus secrets
        public const string EventHubName = "sdkeventhub";
        public const string ServiceBusNamespace = "sdktest";
        public const string SharedAccessPolicyName = "RootManageSharedAccessKey";
        public const string SharedAccessPolicyKey = @"$TestStringToBeReplaced";

        // IoT Hub secrets
        public const string IoTHubNamespace = "ZivIoTHub";
        public const string IotHubSharedAccessPolicyKey = @"$TestStringToBeReplaced";
        
        // DocumentDB secrets
        public const string DocDbAccountId = "ibizaloctest001docdb";
        public const string DocDbAccountKey = @"$TestStringToBeReplaced";

        // SQL Azure secrets
        public const string Server = "z102fk12be";
        public const string Database = "HydraSdkTest";
        public const string User = "customersolution";
        public const string Password = "$TestStringToBeReplaced";

        // Function secrets
        public const string ExecuteEndpoint = "https://ussouthcentral.services.azureml.net/workspaces/f80d5d7a77fa4a46bf2a30c63c078dca/services/b7be5e40fd194258896fb602c1858eaf/execute?api-version=2.0&details=true";
        public const string ApiKey = "$TestStringToBeReplaced";

        /// <summary>
        /// Generate a Resource Management client from the test base to use for managing resource groups.
        /// </summary>
        /// <returns>Resource Management client</returns>
        public static ResourceManagementClient GetResourceClient(HyakMockContext context, DelegatingHandler handler)
        {
            return context.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment(), false, new DelegatingHandler[] { handler });
        }

        public static StreamAnalyticsManagementClient GetStreamAnalyticsManagementClient(HyakMockContext context, DelegatingHandler handler)
        {
            return context.GetServiceClient<StreamAnalyticsManagementClient>().WithHandler(handler);
        }

        public static string GetDefaultLocation(HyakMockContext context)
        {
            return "West US";
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