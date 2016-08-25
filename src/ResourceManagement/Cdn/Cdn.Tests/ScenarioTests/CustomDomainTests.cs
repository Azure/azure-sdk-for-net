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
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;
using Cdn.Tests.Helpers;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace Cdn.Tests.ScenarioTests
{
    public class CustomDomainTests
    {
        [Fact]
        public void CustomDomainCRUDTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                // Create clients
                var cdnMgmtClient = CdnTestUtilities.GetCdnManagementClient(context, handler1);
                var resourcesClient = CdnTestUtilities.GetResourceManagementClient(context, handler2);

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

                // Create a cdn endpoint with minimum requirements
                string endpointName = "endpoint-554d5e6b9f56";
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

                // List custom domains one this endpoint should return none
                var customDomains = cdnMgmtClient.CustomDomains.ListByEndpoint(endpointName, profileName, resourceGroupName);
                Assert.Equal(0, customDomains.Count());

                // NOTE: There is a CName mapping already created for this custom domain and endpoint hostname
                // "sdk-1-5b4d5e6b9f56.azureedge-test.net" maps to "endpoint-554d5e6b9f56.azureedge-test.net"
                // "sdk-2-5b4d5e6b9f56.azureedge-test.net" maps to "endpoint-554d5e6b9f56.azureedge-test.net"

                // Create custom domain on running endpoint should succeed
                string customDomainName1 = TestUtilities.GenerateName("customDomain");
                cdnMgmtClient.CustomDomains.Create(customDomainName1, endpointName, profileName, resourceGroupName, "sdk-1-5b4d5e6b9f56.azureedge-test.net");

                // List custom domains one this endpoint should return one
                customDomains = cdnMgmtClient.CustomDomains.ListByEndpoint(endpointName, profileName, resourceGroupName);
                Assert.Equal(1, customDomains.Count());

                // Update custom domain on running endpoint should fail
                Assert.ThrowsAny<ErrorResponseException>(() =>
                {
                    cdnMgmtClient.CustomDomains.Update(customDomainName1, endpointName, profileName, resourceGroupName, "customdomain11.hello.com");
                });

                // Stop endpoint
                cdnMgmtClient.Endpoints.Stop(endpointName, profileName, resourceGroupName);

                // Create another custom domain on stopped endpoint should succeed
                string customDomainName2 = TestUtilities.GenerateName("customDomain");
                cdnMgmtClient.CustomDomains.Create(customDomainName2, endpointName, profileName, resourceGroupName, "sdk-2-5b4d5e6b9f56.azureedge-test.net");

                // List custom domains one this endpoint should return two
                customDomains = cdnMgmtClient.CustomDomains.ListByEndpoint(endpointName, profileName, resourceGroupName);
                Assert.Equal(2, customDomains.Count());

                // Update custom domain on stopped endpoint should fail
                Assert.ThrowsAny<ErrorResponseException>(() =>
                {
                    cdnMgmtClient.CustomDomains.Update(customDomainName2, endpointName, profileName, resourceGroupName, "customdomain22.hello.com");
                });

                // Delete second custom domain on stopped endpoint should succeed
                cdnMgmtClient.CustomDomains.DeleteIfExists(customDomainName2, endpointName, profileName, resourceGroupName);

                // Get deleted custom domain should fail
                Assert.ThrowsAny<ErrorResponseException>(() => {
                    cdnMgmtClient.CustomDomains.Get(customDomainName2, endpointName, profileName, resourceGroupName); });

                // List custom domains on endpoint should return one
                customDomains = cdnMgmtClient.CustomDomains.ListByEndpoint(endpointName, profileName, resourceGroupName);
                Assert.Equal(1, customDomains.Count());

                // Start endpoint
                cdnMgmtClient.Endpoints.Start(endpointName, profileName, resourceGroupName);

                // Delete first custom domain on stopped endpoint should succeed
                cdnMgmtClient.CustomDomains.DeleteIfExists(customDomainName1, endpointName, profileName, resourceGroupName);

                // Get deleted custom domain should fail
                Assert.ThrowsAny<ErrorResponseException>(() => {
                    cdnMgmtClient.CustomDomains.Get(customDomainName1, endpointName, profileName, resourceGroupName);
                });

                // List custom domains on endpoint should return none
                customDomains = cdnMgmtClient.CustomDomains.ListByEndpoint(endpointName, profileName, resourceGroupName);
                Assert.Equal(0, customDomains.Count());

                // Delete resource group
                CdnTestUtilities.DeleteResourceGroup(resourcesClient, resourceGroupName);
            }
        }
    }
}