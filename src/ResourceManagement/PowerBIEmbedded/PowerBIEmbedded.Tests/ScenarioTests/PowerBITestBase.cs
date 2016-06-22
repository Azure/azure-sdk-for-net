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
