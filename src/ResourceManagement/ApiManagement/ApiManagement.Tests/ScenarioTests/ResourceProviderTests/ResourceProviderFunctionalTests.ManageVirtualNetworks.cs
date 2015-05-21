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
        public void ManageVirtualNetworks()
        {
            using (var context = UndoContext.Current)
            {
                context.Start("ResourceProviderFunctionalTests", "ManageVirtualNetworks");

                var location = this.ManagmentClient.TryGetLocation("West US");
                var resourceGroup = this.ResourceManagementClient.TryGetResourceGroup(location);
                if (string.IsNullOrWhiteSpace(resourceGroup))
                {
                    resourceGroup = TestUtilities.GenerateName("Api-Default");
                    this.ResourceManagementClient.TryRegisterResourceGroup(location, resourceGroup);
                }

                this.ApiManagementClient.RefreshAccessToken();

                // create premium API Management sevice
                var serviceName = TestUtilities.GenerateName("hydraapimservice");
                var createServiceParameters = new ApiServiceCreateOrUpdateParameters(
                    location,
                    new ApiServiceProperties
                    {
                        CreatedAtUtc = DateTime.UtcNow,
                        SkuProperties = new ApiServiceSkuProperties
                        {
                            Capacity = 1,
                            SkuType = SkuType.Premium // vpn configuration is only available for premium sku
                        },
                        AddresserEmail = "addresser@live.com",
                        PublisherEmail = "publisher@live.com",
                        PublisherName = "publisher"
                    });
                var createResponse = this.ApiManagementClient.ResourceProvider.CreateOrUpdate(resourceGroup, serviceName, createServiceParameters);
                Assert.NotNull(createResponse);

                this.ApiManagementClient.RefreshAccessToken();

                // we cannot test this in any environment except prod, so just verify the data accepted
                const string vnetLocation = "East US";
                var vnetId = Guid.Parse("53F96AC5-9F46-46CE-BA0F-77DE89943258");
                const string subnetName = "Subnet-1";

                // TODO: add verification of ManageVirtualNetworks method. 
                // This functionality relies on environment. Currently there's no ability to create a vnet and get it's GUID id.
                // Let's just verify the contract at least

                try
                {
                    var result = this.ApiManagementClient.ResourceProvider.BeginManagingVirtualNetworksAsync(
                        resourceGroup,
                        serviceName,
                        new ApiServiceManageVirtualNetworksParameters
                        {
                            VirtualNetworkConfigurations = new[]
                            {
                                new VirtualNetworkConfiguration
                                {
                                    Location = vnetLocation,
                                    SubnetName = subnetName,
                                    VnetId = vnetId
                                }
                            }
                        }).Result;

                    Assert.NotNull(result);
                    Assert.NotNull(result.Error);
                }
                catch (AggregateException exc)
                {
                    Assert.NotNull(exc.InnerException);
                    Assert.True(exc.InnerException.Message.Contains("Virtual Network configuration not found for location"));
                }
            }
        }
    }
}