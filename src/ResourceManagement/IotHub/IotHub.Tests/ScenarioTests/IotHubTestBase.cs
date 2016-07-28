//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace IotHub.Tests.ScenarioTests
{
    using System;
    using System.Net;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Microsoft.Azure.Management.IotHub;
    using Microsoft.Azure.Management.IotHub.Models;
    using Microsoft.Azure.Management.Resources;
    using Microsoft.Azure.Management.Resources.Models;
    using IotHub.Tests.Helpers;

    public class IotHubTestBase
    {
        protected ResourceManagementClient resourcesClient;
        protected IotHubClient iotHubClient;

        protected bool initialized = false;
        protected object locker = new object();
        protected string location;
        protected TestEnvironment testEnv;

        protected void Initialize(MockContext context)
        {
            if (!initialized)
            {
                lock (locker)
                {
                    if (!initialized)
                    {
                        testEnv = TestEnvironmentFactory.GetTestEnvironment();
                        resourcesClient = IotHubTestUtilities.GetResourceManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                        iotHubClient = IotHubTestUtilities.GetIotHubClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                        if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION")))
                        {
                            location = IotHubTestUtilities.DefaultLocation;
                        }
                        else
                        {
                            location = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION").Replace(" ", "").ToLower();
                        }

                        this.initialized = true;
                    }
                }
            }
        }

        protected IotHubDescription CreateDefaultIotHub(ResourceGroup resourceGroup)
        {
            var createIotHubDescription = new IotHubDescription("-1", IotHubTestUtilities.DefaultIotHubName, null, IotHubTestUtilities.DefaultLocation)
            {
                Subscriptionid = testEnv.SubscriptionId,
                Resourcegroup = resourceGroup.Name,
                Sku = new IotHubSkuInfo()
                {
                    Name = "S1",
                    Capacity = 1
                },
                
            };

            return this.iotHubClient.IotHubResource.CreateOrUpdate(
                resourceGroup.Name,
                IotHubTestUtilities.DefaultIotHubName,
                createIotHubDescription);
        }

        protected IotHubDescription UpdateIotHub(ResourceGroup resourceGroup, IotHubDescription iotHubDescription)
        {
            return this.iotHubClient.IotHubResource.CreateOrUpdate(
                resourceGroup.Name,
                IotHubTestUtilities.DefaultIotHubName,
                iotHubDescription);
        }

        protected ResourceGroup CreateResourceGroup()
        {
            var resourceGroupName = IotHubTestUtilities.DefaultResourceGroupName;
            return this.resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                new ResourceGroup
                {
                    Location = IotHubTestUtilities.DefaultLocation
                });
        }
    }
}
