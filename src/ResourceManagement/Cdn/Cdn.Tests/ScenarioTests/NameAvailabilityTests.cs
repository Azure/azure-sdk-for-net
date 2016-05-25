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

using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;
using Cdn.Tests.Helpers;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Cdn.Tests.ScenarioTests
{
    public class NameAvailabilityTests
    {
        [Fact]
        public void EndpointCheckNameAvailabilityTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                // Create clients
                var cdnMgmtClient = CdnTestUtilities.GetCdnManagementClient(context, handler1);
                var resourcesClient = CdnTestUtilities.GetResourceManagementClient(context, handler2);

                // Generate new endpoint name
                string endpointName = TestUtilities.GenerateName("endpoint-unique");
                
                // CheckNameAvailability should return true
                var output = cdnMgmtClient.NameAvailability.CheckNameAvailability(endpointName, ResourceType.MicrosoftCdnProfilesEndpoints);
                Assert.Equal(output.NameAvailable, true);

                // Create endpoint with that name then CheckNameAvailability again

                // Create resource group
                var resourceGroupName = CdnTestUtilities.CreateResourceGroup(resourcesClient);

                // Create a standard cdn profile
                string profileName = TestUtilities.GenerateName("profile");
                ProfileCreateParameters createParameters = new ProfileCreateParameters
                {
                    Location = "WestUs",
                    Sku = new Sku { Name = SkuName.StandardVerizon },
                    Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                };
                var profile = cdnMgmtClient.Profiles.Create(profileName, createParameters, resourceGroupName);

                // Create endpoint with this name
                var endpointCreateParameters = new EndpointCreateParameters
                {
                    Location = "WestUs",
                    IsHttpAllowed = true,
                    IsHttpsAllowed = true,
                    Origins = new List<DeepCreatedOrigin>
                    {
                        new DeepCreatedOrigin
                        {
                            Name = "origin1",
                            HostName = "host1.hello.com"
                        }
                    }
                };
                var endpoint = cdnMgmtClient.Endpoints.Create(endpointName, endpointCreateParameters, profileName, resourceGroupName);

                // CheckNameAvailability after endpoint was created should return false
                output = cdnMgmtClient.NameAvailability.CheckNameAvailability(endpointName, ResourceType.MicrosoftCdnProfilesEndpoints);
                Assert.Equal(output.NameAvailable, false);

                // Delete resource group
                CdnTestUtilities.DeleteResourceGroup(resourcesClient, resourceGroupName);
            }
        }
    }
}
