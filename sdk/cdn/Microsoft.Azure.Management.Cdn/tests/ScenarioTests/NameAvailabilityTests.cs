// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
                var output = cdnMgmtClient.CheckNameAvailability(endpointName);
                Assert.True(output.NameAvailable);

                // Create endpoint with that name then CheckNameAvailability again

                // Create resource group
                var resourceGroupName = CdnTestUtilities.CreateResourceGroup(resourcesClient);

                // Create a standard cdn profile
                string profileName = TestUtilities.GenerateName("profile");
                Profile createParameters = new Profile
                {
                    Location = "WestUs",
                    Sku = new Sku { Name = SkuName.StandardVerizon },
                    Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                };
                var profile = cdnMgmtClient.Profiles.Create(resourceGroupName, profileName, createParameters);

                // Create endpoint with this name
                var endpointCreateParameters = new Endpoint
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
                var endpoint = cdnMgmtClient.Endpoints.Create(resourceGroupName, profileName, endpointName, endpointCreateParameters);

                // CheckNameAvailability after endpoint was created should return false
                output = cdnMgmtClient.CheckNameAvailability(endpointName);
                Assert.False(output.NameAvailable);

                // Delete resource group
                CdnTestUtilities.DeleteResourceGroup(resourcesClient, resourceGroupName);
            }
        }
    }
}
