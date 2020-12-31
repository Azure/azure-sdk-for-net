// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 

using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using System.Collections.Generic;
using Xunit;
using System;
using System.Linq;
using System.Threading.Tasks;
using ApiManagementManagement.Tests.Helpers;

namespace ApiManagement.Tests.ResourceProviderTests
{
    public partial class ApiManagementServiceTests
    {
        [Fact]
        [Trait("owner", "sasolank")]
        public async Task CreateInVirtualNetworkTests()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);

                var virtualNetworkName = TestUtilities.GenerateName("apimvnet");
                var subnetName = TestUtilities.GenerateName("apimsubnet");

                var vnet = new VirtualNetwork()
                {
                    Location = testBase.location,

                    AddressSpace = new AddressSpace()
                    {
                        AddressPrefixes = new List<string>()
                        {
                            "10.0.0.0/16",
                        }
                    },
                    Subnets = new List<Subnet>()
                    {
                        new Subnet()
                        {
                            Name = subnetName,
                            AddressPrefix = "10.0.1.0/24",
                        },
                    }
                };

                // Put Vnet
                var putVnetResponse = testBase.networkClient.VirtualNetworks.CreateOrUpdate(testBase.rgName, virtualNetworkName, vnet);
                Assert.Equal("Succeeded", putVnetResponse.ProvisioningState);

                var getSubnetResponse = testBase.networkClient.Subnets.Get(testBase.rgName, virtualNetworkName, subnetName);
                Assert.NotNull(getSubnetResponse);
                Assert.NotNull(getSubnetResponse.Id);

                testBase.serviceProperties.VirtualNetworkType = VirtualNetworkType.External;
                testBase.serviceProperties.VirtualNetworkConfiguration = new VirtualNetworkConfiguration()
                {
                    SubnetResourceId = getSubnetResponse.Id
                };

                var createdService = testBase.client.ApiManagementService.CreateOrUpdate(
                    resourceGroupName: testBase.rgName,
                    serviceName: testBase.serviceName,
                    parameters: testBase.serviceProperties);

                ValidateService(createdService,
                    testBase.serviceName,
                    testBase.rgName,
                    testBase.subscriptionId,
                    testBase.location,
                    testBase.serviceProperties.PublisherEmail,
                    testBase.serviceProperties.PublisherName,
                    testBase.serviceProperties.Sku.Name,
                    testBase.tags);

                Assert.Equal(VirtualNetworkType.External, createdService.VirtualNetworkType);
                Assert.NotNull(createdService.VirtualNetworkConfiguration);
                Assert.Equal(getSubnetResponse.Id, createdService.VirtualNetworkConfiguration.SubnetResourceId);

                // apply network configuration
                var applyNetworkConfigParameters = new ApiManagementServiceApplyNetworkConfigurationParameters()
                {
                    Location = createdService.Location
                };

                var applyNetworkServiceResponse = testBase.client.ApiManagementService.ApplyNetworkConfigurationUpdates(
                    resourceGroupName: testBase.rgName,
                    serviceName: testBase.serviceName,
                    parameters: applyNetworkConfigParameters);

                Assert.NotNull(applyNetworkServiceResponse);
                Assert.Equal(createdService.Name, applyNetworkServiceResponse.Name);
                Assert.NotNull(applyNetworkServiceResponse.VirtualNetworkConfiguration);
                Assert.Equal(VirtualNetworkType.External, applyNetworkServiceResponse.VirtualNetworkType);
                // get the network status by service
                var serviceNetworkStatus = await testBase.client.NetworkStatus.ListByServiceAsync(
                    testBase.rgName,
                    testBase.serviceName);
                Assert.NotNull(serviceNetworkStatus);
                Assert.Single(serviceNetworkStatus);
                Assert.Equal(testBase.location.ToLowerAndRemoveWhiteSpaces(), serviceNetworkStatus.First().Location.ToLowerAndRemoveWhiteSpaces());
                Assert.NotNull(serviceNetworkStatus.First().NetworkStatus.ConnectivityStatus);
                Assert.NotNull(serviceNetworkStatus.First().NetworkStatus.DnsServers);
                Assert.Equal("success", serviceNetworkStatus.First().NetworkStatus.ConnectivityStatus.First().Status, true);
                Assert.NotNull(serviceNetworkStatus.First().NetworkStatus.ConnectivityStatus.First().Name);

                // get the network status by location
                var serviceNetworkStatusByLocation = await testBase.client.NetworkStatus.ListByLocationAsync(
                    testBase.rgName,
                    testBase.serviceName,
                    createdService.Location);
                Assert.NotNull(serviceNetworkStatusByLocation);
                Assert.NotNull(serviceNetworkStatusByLocation.ConnectivityStatus);
                Assert.NotNull(serviceNetworkStatusByLocation.DnsServers);
                Assert.Equal("success", serviceNetworkStatusByLocation.ConnectivityStatus.First().Status, true);
                Assert.NotNull(serviceNetworkStatusByLocation.ConnectivityStatus.First().Name);

                // Move to Internal Virtual Network
                testBase.serviceProperties.VirtualNetworkType = VirtualNetworkType.Internal;
                var updatedService = testBase.client.ApiManagementService.CreateOrUpdate(
                    resourceGroupName: testBase.rgName,
                    serviceName: testBase.serviceName,
                    parameters: testBase.serviceProperties);
                Assert.Equal(VirtualNetworkType.Internal, updatedService.VirtualNetworkType);
                Assert.NotNull(updatedService.VirtualNetworkConfiguration);
                Assert.Equal(getSubnetResponse.Id, updatedService.VirtualNetworkConfiguration.SubnetResourceId);

                // Delete
                testBase.client.ApiManagementService.Delete(
                    resourceGroupName: testBase.rgName,
                    serviceName: testBase.serviceName);

                Assert.Throws<ErrorResponseException>(() =>
                {
                    testBase.client.ApiManagementService.Get(
                        resourceGroupName: testBase.rgName,
                        serviceName: testBase.serviceName);
                });
            }
        }
    }
}