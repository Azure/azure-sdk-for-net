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
        protected static string DefaultIotcSku = AppSku.ST2.ToString();

        protected ResourceManagementClient resourcesClient;
        protected IotCentralClient iotCentralClient;

        protected bool initialized = false;
        protected object locker = new object();
        protected string location;
        protected TestEnvironment testEnv;

        // Use randomized names for testing locally (to avoid 'resource group is in deprovisioning state' error)
        // and set isTestRecorderRun=true to update SessionRecords (to avoid pipeline failures on playback).
        protected bool isTestRecorderRun = false;

        protected string randomizedResourceName = IotCentralTestUtilities.RandomizedResourceName;
        protected string randomizedUpdateResourceName = IotCentralTestUtilities.RandomizedUpdateResourceName;
        protected string randomizedSubDomain = IotCentralTestUtilities.RandomizedSubdomain;
        protected string randomizedUpdateSubDomain = IotCentralTestUtilities.RandomizedUpdateSubdomain;
        protected string randomizedResourceGroupName = IotCentralTestUtilities.RandomizedResourceGroupName;
        protected string randomizedUpdateResourceGroupName = IotCentralTestUtilities.RandomizedUpdateResourceGroupName;

        protected string defaultResourceName = IotCentralTestUtilities.DefaultResourceName;
        protected string defaultUpdateResourceName = IotCentralTestUtilities.DefaultUpdateResourceName;
        protected string defaultSubDomain = IotCentralTestUtilities.DefaultSubdomain;
        protected string defaultUpdateSubDomain = IotCentralTestUtilities.DefaultUpdateSubdomain;
        protected string defaultResourceGroupName = IotCentralTestUtilities.DefaultResourceGroupName;
        protected string defaultUpdateResourceGroupName = IotCentralTestUtilities.DefaultUpdateResourceGroupName;

        protected string ResourceName => isTestRecorderRun ? defaultResourceName : randomizedResourceName;
        protected string UpdateResourceName => isTestRecorderRun ? defaultUpdateResourceName : randomizedUpdateResourceName;
        protected string SubDomain => isTestRecorderRun ? defaultSubDomain : randomizedSubDomain;
        protected string UpdateSubDomain => isTestRecorderRun ? defaultUpdateSubDomain : randomizedUpdateSubDomain;
        protected string ResourceGroupName => isTestRecorderRun ? defaultResourceGroupName : randomizedResourceGroupName;
        protected string UpdateResourceGroupName => isTestRecorderRun ? defaultUpdateResourceGroupName : randomizedUpdateResourceGroupName;

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
                        
                        // Set this to true before running the tests for updating SessionRecords and the Github PR.
                        isTestRecorderRun = true;

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
                    Name = sku ?? DefaultIotcSku,
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

