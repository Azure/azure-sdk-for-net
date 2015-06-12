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
        [Fact]
        public void ManageDeployments()
        {
            using (var context = UndoContext.Current)
            {
                context.Start("ResourceProviderFunctionalTests", "ManageDeployments");

                TryCreateApiService();

                var apiManagementClient = GetServiceClient<ApiManagementClient>(new CSMTestEnvironmentFactory());

                // update from Developer to Standard and Update Capacity from 1 to 2
                var response = apiManagementClient.ResourceProvider.ManageDeployments(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    new ApiServiceManageDeploymentsParameters
                    {
                        SkuType = SkuType.Standard,
                        Location = Location,
                        SkuUnitCount = 2
                    });

                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                var getResponse = apiManagementClient.ResourceProvider.Get(ResourceGroupName, ApiManagementServiceName);
                Assert.NotNull(getResponse);
                Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
                Assert.NotNull(getResponse.Value);
                Assert.Equal(SkuType.Standard, getResponse.Value.Properties.SkuProperties.SkuType);
                Assert.Equal(2, getResponse.Value.Properties.SkuProperties.Capacity);

                // update from Standard to Premium and add one more region
                var location = this.ManagmentClient.GetLocations().FirstOrDefault(l => !string.Equals(l, Location, StringComparison.OrdinalIgnoreCase));
                if (location == null)
                {
                    location = "dummy location"; // in case environment has only one location. 
                }

                // renew access token
                apiManagementClient.RefreshAccessToken();

                response = apiManagementClient.ResourceProvider.ManageDeployments(
                    ResourceGroupName,
                    ApiManagementServiceName,
                    new ApiServiceManageDeploymentsParameters
                    {
                        SkuType = SkuType.Premium,
                        Location = Location,
                        SkuUnitCount = 2,
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

                getResponse = apiManagementClient.ResourceProvider.Get(ResourceGroupName, ApiManagementServiceName);
                Assert.NotNull(getResponse);
                Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);
                Assert.NotNull(getResponse.Value);
                Assert.Equal(SkuType.Premium, getResponse.Value.Properties.SkuProperties.SkuType);
                Assert.Equal(2, getResponse.Value.Properties.SkuProperties.Capacity);
                Assert.NotNull(getResponse.Value.Properties.AdditionalRegions);
                Assert.Equal(1, getResponse.Value.Properties.AdditionalRegions.Count);
                Assert.Equal(SkuType.Premium, getResponse.Value.Properties.AdditionalRegions[0].SkuType);
                Assert.Equal(2, getResponse.Value.Properties.AdditionalRegions[0].SkuUnitCount);
            }
        }
    }
}