// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
using System;
using System.Net;
using IotCentral.Tests.Helpers;
using Microsoft.Azure.Management.IotCentral;
using Microsoft.Azure.Management.IotCentral.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace IotCentral.Tests.ScenarioTests
{
    public class IotCentralTestBase
    {
        protected ResourceManagementClient resourcesClient;
        protected IotCentralClient iotCentralClient;

        protected bool initialized = false;
        protected object locker = new object();
        protected string location;
        protected TestEnvironment testEnv;

        protected String resourceName = IotCentralTestUtilities.RandomizedResourceName;
        protected String updateResourceName = IotCentralTestUtilities.RandomizedUpdateResourceName;
        protected String subDomain = IotCentralTestUtilities.RandomizedSubdomain;
        protected String updateSubDomain = IotCentralTestUtilities.RandomizedUpdateSubdomain;
        protected String resourceGroupName = IotCentralTestUtilities.RandomizedResourceGroupName;
        protected String updateResourceGroupName = IotCentralTestUtilities.RandomizedUpdateResourceGroupName;
        protected SystemAssignedServiceIdentity DefaultMIType = new SystemAssignedServiceIdentity(type: "SystemAssigned");

        protected void Initialize(MockContext context)
        {
            if (!initialized)
            {
                lock (locker)
                {
                    if (!initialized)
                    {
                        testEnv = TestEnvironmentFactory.GetTestEnvironment();
                        resourcesClient = IotCentralTestUtilities.GetResourceManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                        iotCentralClient = IotCentralTestUtilities.GetIotCentralClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                        if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION")))
                        {
                            location = IotCentralTestUtilities.DefaultLocation;
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

        protected App CreateIotCentralApp(string location, string appResourceName, string appSubdomain, string sku = null)
        {
            return new App()
            {
                Location = location,
                Sku = new AppSkuInfo()
                {
                    Name = sku ?? "ST1",
                },
                Subdomain = appSubdomain,
                DisplayName = appResourceName,
            };
        }

        protected App CreateIotCentral(
            ResourceGroup resourceGroup,
            string location,
            string appResourceName,
            string appSubdomain,
            SystemAssignedServiceIdentity identity = null,
            string sku = null)
        {
            var app = CreateIotCentralApp(location, appResourceName, appSubdomain, sku);

            // Set system-assigned identity as default.
            if (identity != null)
            {
                app.Identity = identity;
            }

            return this.iotCentralClient.Apps.CreateOrUpdate(
                resourceGroup.Name,
                appResourceName,
                app);
        }


        protected App UpdateIotCentral(ResourceGroup resourceGroup, AppPatch app, string appResourceName)
        {
            return this.iotCentralClient.Apps.Update(
                resourceGroup.Name,
                appResourceName,
                app);
        }

        protected ResourceGroup CreateResourceGroup(string resourceGroupName)
        {
                return this.resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = IotCentralTestUtilities.DefaultLocation
                    });
        }

        protected void DeleteResourceGroup(string resourceGroupName)
        {
            this.resourcesClient.ResourceGroups.Delete(resourceGroupName);
        }
    }
}

