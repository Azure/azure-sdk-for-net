// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resources.Models;
using PowerBIEmbedded.Tests.Helpers;
using ResourceGroups.Tests;

namespace PowerBIEmbedded.Tests.ScenarioTests
{
    using Microsoft.Azure.Management.Resources;
    using System;
    using System.Net;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Microsoft.Azure.Management.PowerBIEmbedded;
    using Microsoft.Azure.Management.PowerBIEmbedded.Models;

    namespace PowerBIEmbedded.Tests.ScenarioTests
    {
        public class PowerBITestBase
        {
            protected const string TestPrefix = "crptestar";

            protected ResourceManagementClient resourcesClient;
            protected PowerBIEmbeddedManagementClient powerBIClient;

            protected bool initialized = false;
            protected object locker = new object();
            protected string location;

            protected void Initialize(MockContext context)
            {
                if (!initialized)
                {
                    lock (locker)
                    {
                        if (!initialized)
                        {
                            resourcesClient = PowerBITestUtilities.GetResourceManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                            powerBIClient = PowerBITestUtilities.GetPowerBiEmbeddedManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION")))
                            {
                                location = PowerBITestUtilities.DefaultLocation;
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

            protected WorkspaceCollection CreateWorkspaceCollection(ResourceGroup resourceGroup)
            {
                var createWorkspaceRequest = new CreateWorkspaceCollectionRequest
                {
                    Location = this.location
                };

                var workspaceCollectionName = PowerBITestUtilities.GenerateName("wc");
                return this.powerBIClient.WorkspaceCollections.Create(
                    resourceGroup.Name,
                    workspaceCollectionName,
                    createWorkspaceRequest);

            }

            protected ResourceGroup CreateResourceGroup()
            {
                var resourceGroupName = PowerBITestUtilities.GenerateName("rg");
                return this.resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                    new ResourceGroup
                    {
                        Location = PowerBITestUtilities.DefaultLocation
                    });
            }
        }
    }

}
