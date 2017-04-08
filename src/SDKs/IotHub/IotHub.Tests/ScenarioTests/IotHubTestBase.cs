// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
