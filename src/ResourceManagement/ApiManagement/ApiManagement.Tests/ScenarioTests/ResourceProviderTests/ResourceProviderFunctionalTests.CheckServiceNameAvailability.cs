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
    using global::ApiManagement.Tests;
    using Microsoft.Azure.Management.ApiManagement.Models;
    using Microsoft.Azure.Test;
    using Xunit;

    public partial class ResourceProviderFunctionalTests
    {
        [Fact]
        public void CheckServiceNameAvailability()
        {
            using (var context = UndoContext.Current)
            {
                context.Start("ResourceProviderFunctionalTests", "CheckServiceNameAvailability");

                var apiManagementClient = ApiManagementHelper.GetApiManagementClient();

                var validServiceName = TestUtilities.GenerateName("hydraapimservicevalid");
                var response =
                    apiManagementClient.ResourceProvider.CheckServiceNameAvailability(
                        new ApiServiceCheckNameAvailabilityParameters(validServiceName));
                Assert.NotNull(response);
                Assert.True(response.IsAvailable);
                Assert.Null(response.Reason);

                const string invalidName = "!!!invalidname";
                response =
                    apiManagementClient.ResourceProvider.CheckServiceNameAvailability(
                        new ApiServiceCheckNameAvailabilityParameters(invalidName));
                Assert.NotNull(response);
                Assert.False(response.IsAvailable);
                Assert.NotNull(response.Reason);

                // create api management service 
                var location = this.ManagmentClient.TryGetLocation("West US");
                var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName("Api-Default");
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }
                var createServiceParameters = new ApiServiceCreateOrUpdateParameters(
                    location,
                    new ApiServiceProperties
                    {
                        CreatedAtUtc = DateTime.UtcNow,
                        SkuProperties = new ApiServiceSkuProperties
                        {
                            Capacity = 1,
                            SkuType = SkuType.Developer
                        },
                        AddresserEmail = "addresser@live.com",
                        PublisherEmail = "publisher@live.com",
                        PublisherName = "publisher"
                    });

                var createResponse = apiManagementClient.ResourceProvider.CreateOrUpdate(resourceGroup, validServiceName,
                    createServiceParameters);
                Assert.NotNull(createResponse);

                response =
                    apiManagementClient.ResourceProvider.CheckServiceNameAvailability(
                        new ApiServiceCheckNameAvailabilityParameters(validServiceName));
                Assert.NotNull(response);
                Assert.False(response.IsAvailable);
                Assert.NotNull(response.Reason);
            }
        }
    }
}