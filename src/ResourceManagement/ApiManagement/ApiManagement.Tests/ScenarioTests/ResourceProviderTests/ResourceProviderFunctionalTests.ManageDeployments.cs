//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

namespace Microsoft.Azure.Management.ApiManagement.Tests.ScenarioTests.ResourceProviderTests
{
    using System;
    using System.Linq;
    using System.Net;
    using global::ApiManagement.Tests;
    using Microsoft.Azure.Management.ApiManagement.Models;
    using Microsoft.Azure.Test;
    using Xunit;

    public partial class ResourceProviderFunctionalTests
    {
        /// <summary>
        /// Common Test Subnet Resource
        /// </summary>
        const string SubnetResourceId =
                    "/subscriptions/20010222-2b48-4245-a95c-090db6312d5f/resourceGroups/onesdk2423/providers/Microsoft.Network/virtualNetworks/hydra-apim-vnet/subnets/default";

        [Fact]
        public void ManageDeployments()
        {
            using (var context = UndoContext.Current)
            {
                context.Start("ResourceProviderFunctionalTests", "ManageDeployments");

                TryCreateApiService();

                var apiManagementClient = GetServiceClient<ApiManagementClient>(new CSMTestEnvironmentFactory());

                // update from Standard to Premium and add one more region
                var location = this.ManagmentClient.GetLocations().FirstOrDefault(l => !string.Equals(l, Location, StringComparison.OrdinalIgnoreCase));
                if (location == null)
                {
                    location = "dummy location"; // in case environment has only one location. 
                }

                // renew access token
                apiManagementClient.RefreshAccessToken();

                var response = apiManagementClient.ResourceProvider.ManageDeployments(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    new ApiServiceManageDeploymentsParameters
                    {
                        SkuType = SkuType.Premium,
                        Location = Location,
                        SkuUnitCount = 2,
                        VpnType = VirtualNetworkType.None,
                        AdditionalRegions = new[]
                        {
                            new AdditionalRegion
                            {
                                Location = location,
                                SkuType = SkuType.Premium,
                                SkuUnitCount = 2
                            }
                        }
                    });

                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                var getResponse = apiManagementClient.ResourceProvider.Get(ResourceGroupName, ApiManagementServiceName);
                Assert.NotNull(getResponse);
                Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
                Assert.NotNull(getResponse.Value);
                Assert.Equal(SkuType.Premium, getResponse.Value.SkuProperties.SkuType);
                Assert.Equal(2, getResponse.Value.SkuProperties.Capacity);
                Assert.NotNull(getResponse.Value.Properties.AdditionalRegions);
                Assert.Equal(1, getResponse.Value.Properties.AdditionalRegions.Count);
                Assert.Equal(SkuType.Premium, getResponse.Value.Properties.AdditionalRegions[0].SkuType);
                Assert.Equal(2, getResponse.Value.Properties.AdditionalRegions[0].SkuUnitCount);
                Assert.Equal(VirtualNetworkType.None, getResponse.Value.Properties.VpnType);
            }
        }
        
        [Fact]
        public void ManageDeployments_SetupExternalVpnConfiguration()
        {
            using (var context = UndoContext.Current)
            {
                context.Start("ResourceProviderFunctionalTests", "ManageDeployments_SetupExternalVpnConfiguration");

                TryCreateApiService();

                var apiManagementClient = GetServiceClient<ApiManagementClient>(new CSMTestEnvironmentFactory());
                
                // Join the Developer Service to a Vnet having External VIP
                var response = apiManagementClient.ResourceProvider.ManageDeployments(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    new ApiServiceManageDeploymentsParameters
                    {
                        SkuType = SkuType.Developer,
                        Location = Location,
                        SkuUnitCount = 1,
                        VirtualNetworkConfiguration = new VirtualNetworkConfiguration()
                        {
                            Location = Location,
                            SubnetResourceId = SubnetResourceId
                        },
                        VpnType = VirtualNetworkType.External
                    });

                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                var getResponse = apiManagementClient.ResourceProvider.Get(ResourceGroupName, ApiManagementServiceName);
                Assert.NotNull(getResponse);
                Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
                Assert.NotNull(getResponse.Value);
                Assert.Equal(SkuType.Developer, getResponse.Value.SkuProperties.SkuType);
                Assert.Equal(1, getResponse.Value.SkuProperties.Capacity);
                Assert.NotNull(getResponse.Value.Properties.VirtualNetworkConfiguration.SubnetResourceId);
                Assert.Equal(SubnetResourceId, getResponse.Value.Properties.VirtualNetworkConfiguration.SubnetResourceId);
                Assert.Equal(VirtualNetworkType.External, getResponse.Value.Properties.VpnType);
                Assert.NotNull(getResponse.Value.Properties.VirtualNetworkConfiguration.VnetId);
                Assert.Null(getResponse.Value.Properties.VirtualNetworkConfiguration.SubnetName);
            }
        }

        [Fact]
        public void ManageDeployments_SetupInternalVpnConfiguration()
        {
            using (var context = UndoContext.Current)
            {
                context.Start("ResourceProviderFunctionalTests", "ManageDeployments_SetupInternalVpnConfiguration");

                TryCreateApiService();

                var apiManagementClient = GetServiceClient<ApiManagementClient>(new CSMTestEnvironmentFactory());
                
                // switch from External to Internal Vpn
                var response = apiManagementClient.ResourceProvider.ManageDeployments(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    new ApiServiceManageDeploymentsParameters
                    {
                        SkuType = SkuType.Developer,
                        Location = Location,
                        SkuUnitCount = 1,
                        VirtualNetworkConfiguration = new VirtualNetworkConfiguration()
                        {
                            Location = Location,
                            SubnetResourceId = SubnetResourceId
                        },
                        VpnType = VirtualNetworkType.Internal
                    });

                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                var getResponse = apiManagementClient.ResourceProvider.Get(ResourceGroupName, ApiManagementServiceName);
                Assert.NotNull(getResponse);
                Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
                Assert.NotNull(getResponse.Value);
                Assert.Equal(SkuType.Developer, getResponse.Value.SkuProperties.SkuType);
                Assert.Equal(1, getResponse.Value.SkuProperties.Capacity);
                Assert.NotNull(getResponse.Value.Properties.VirtualNetworkConfiguration.SubnetResourceId);
                Assert.Equal(SubnetResourceId, getResponse.Value.Properties.VirtualNetworkConfiguration.SubnetResourceId);
                Assert.Equal(VirtualNetworkType.Internal, getResponse.Value.Properties.VpnType);
                Assert.NotNull(getResponse.Value.Properties.VirtualNetworkConfiguration.VnetId);
                Assert.Null(getResponse.Value.Properties.VirtualNetworkConfiguration.SubnetName);
            }
        }
    }
}