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

        protected App CreateIotCentral(ResourceGroup resourceGroup, string location, string appName)
        {
            var app = new App()
            {
                Location = location,
                Sku = new AppSkuInfo()
                {
                    Name = "S1"
                },
                Subdomain = appName,
                DisplayName = appName
            };

            return this.iotCentralClient.Apps.CreateOrUpdate(
                resourceGroup.Name,
                appName,
                app);
        }

        protected App UpdateIotCentral(ResourceGroup resourceGroup, App app, string appName)
        {
            return this.iotCentralClient.Apps.CreateOrUpdate(
                resourceGroup.Name,
                appName,
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
