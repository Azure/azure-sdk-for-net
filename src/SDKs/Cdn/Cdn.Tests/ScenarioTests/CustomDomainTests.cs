// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;
using Cdn.Tests.Helpers;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;

namespace Cdn.Tests.ScenarioTests
{
    public class CustomDomainTests
    {
        [Fact(Skip = "ReRecord due to CR change")]
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

                // Create a cdn endpoint with minimum requirements
                string endpointName = "endpoint-f3757d2a3e10";
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

                // List custom domains one this endpoint should return none
                var customDomains = cdnMgmtClient.CustomDomains.ListByEndpoint(resourceGroupName, profileName, endpointName);
                Assert.Empty(customDomains);

                // NOTE: There is a CName mapping already created for this custom domain and endpoint hostname
                // "sdk-1-f3757d2a3e10.azureedge-test.net" maps to "endpoint-f3757d2a3e10.azureedge.net"
                // "sdk-2-f3757d2a3e10.azureedge-test.net" maps to "endpoint-f3757d2a3e10.azureedge.net"

                // Create custom domain on running endpoint should succeed
                string customDomainName1 = TestUtilities.GenerateName("customDomain");

                cdnMgmtClient.CustomDomains.Create(resourceGroupName, profileName, endpointName, customDomainName1, "sdk-1-f3757d2a3e10.azureedge-test.net");

                // List custom domains one this endpoint should return one
                customDomains = cdnMgmtClient.CustomDomains.ListByEndpoint(resourceGroupName, profileName, endpointName);
                Assert.Single(customDomains);

                // Stop endpoint
                cdnMgmtClient.Endpoints.Stop(resourceGroupName, profileName, endpointName);

                // Create another custom domain on stopped endpoint should succeed
                string customDomainName2 = TestUtilities.GenerateName("customDomain");
                cdnMgmtClient.CustomDomains.Create(resourceGroupName, profileName, endpointName, customDomainName2, "sdk-2-f3757d2a3e10.azureedge-test.net");

                // List custom domains one this endpoint should return two
                customDomains = cdnMgmtClient.CustomDomains.ListByEndpoint(resourceGroupName, profileName, endpointName);
                Assert.Equal(2, customDomains.Count());

                // Enable custom https on custom domain that is already enabled should fail
                Assert.ThrowsAny<ErrorResponseException>(() => {
                    cdnMgmtClient.CustomDomains.DisableCustomHttps(resourceGroupName, profileName, endpointName, customDomainName2);
                });

                // Delete second custom domain on stopped endpoint should succeed
                cdnMgmtClient.CustomDomains.Delete(resourceGroupName, profileName, endpointName, customDomainName2);

                // Get deleted custom domain should fail
                Assert.ThrowsAny<ErrorResponseException>(() => {
                    cdnMgmtClient.CustomDomains.Get(resourceGroupName, profileName, endpointName, customDomainName2); });

                // List custom domains on endpoint should return one
                customDomains = cdnMgmtClient.CustomDomains.ListByEndpoint(resourceGroupName, profileName, endpointName);
                Assert.Single(customDomains);

                // Start endpoint
                cdnMgmtClient.Endpoints.Start(resourceGroupName, profileName, endpointName);

                // Enable custom https on custom domain that is already enabled should fail
                cdnMgmtClient.CustomDomains.EnableCustomHttps(resourceGroupName, profileName, endpointName, customDomainName1);

                // Delete first custom domain on stopped endpoint should succeed
                cdnMgmtClient.CustomDomains.Delete(resourceGroupName, profileName, endpointName, customDomainName1);

                // Get deleted custom domain should fail
                Assert.ThrowsAny<ErrorResponseException>(() => {
                    cdnMgmtClient.CustomDomains.Get(resourceGroupName, profileName, endpointName, customDomainName1);
                });

                // List custom domains on endpoint should return none
                customDomains = cdnMgmtClient.CustomDomains.ListByEndpoint(resourceGroupName, profileName, endpointName);
                Assert.Empty(customDomains);

                // Delete resource group
                CdnTestUtilities.DeleteResourceGroup(resourcesClient, resourceGroupName);
            }
        }
    }
}