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
        public async Task CreateInVirtualNetworkStv1Tests()
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
                    testBase.tags,
                    PlatformVersion.Stv1);

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
                Assert.NotNull(serviceNetworkStatus.First().NetworkStatus.ConnectivityStatus.First().ResourceType);

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

                updatedService = await testBase.client.ApiManagementService.GetAsync(testBase.rgName, testBase.serviceName);

                Assert.Equal(VirtualNetworkType.Internal, updatedService.VirtualNetworkType);
                Assert.NotNull(updatedService.VirtualNetworkConfiguration);
                Assert.Equal(getSubnetResponse.Id, updatedService.VirtualNetworkConfiguration.SubnetResourceId);

                // Delete
                testBase.client.ApiManagementService.Delete(
                    resourceGroupName: testBase.rgName,
                    serviceName: testBase.serviceName);

                Assert.Throws<Microsoft.Azure.Management.ApiManagement.Models.ErrorResponseException>(() =>
                {
                    testBase.client.ApiManagementService.Get(
                        resourceGroupName: testBase.rgName,
                        serviceName: testBase.serviceName);
                });
            }
        }

        [Fact]
        [Trait("owner", "sasolank")]
        public async Task CreateInVirtualNetworkStv2Tests()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var testBase = new ApiManagementTestBase(context);

                var virtualNetworkName = TestUtilities.GenerateName("apimvnet");
                var subnetName = TestUtilities.GenerateName("apimsubnet");

                // setup NSG
                string networkSecurityGroupName = TestUtilities.GenerateName();
                var networkSecurityGroup = new NetworkSecurityGroup()
                {
                    Location = testBase.location,
                };

                // Put Nsg
                var putNsgResponse = testBase.networkClient.NetworkSecurityGroups.CreateOrUpdate(testBase.rgName, networkSecurityGroupName, networkSecurityGroup);
                Assert.Equal("Succeeded", putNsgResponse.ProvisioningState);

                // setup VNET
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
                            NetworkSecurityGroup = new NetworkSecurityGroup()
                            {
                                Id = putNsgResponse.Id
                            }
                        }
                    }
                };

                // Put Vnet
                var putVnetResponse = testBase.networkClient.VirtualNetworks.CreateOrUpdate(testBase.rgName, virtualNetworkName, vnet);
                Assert.Equal("Succeeded", putVnetResponse.ProvisioningState);

                var getSubnetResponse = testBase.networkClient.Subnets.Get(testBase.rgName, virtualNetworkName, subnetName);
                Assert.NotNull(getSubnetResponse);
                Assert.NotNull(getSubnetResponse.Id);

                // create public IP
                var putPublicIPResponse = await SetupPublicIPAsync(testBase);

                testBase.serviceProperties.VirtualNetworkType = VirtualNetworkType.External;
                testBase.serviceProperties.VirtualNetworkConfiguration = new VirtualNetworkConfiguration()
                {
                    SubnetResourceId = getSubnetResponse.Id
                };
                testBase.serviceProperties.PublicIpAddressId = putPublicIPResponse.Id;

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
                    testBase.tags,
                    PlatformVersion.Stv2);

                Assert.Equal(VirtualNetworkType.External, createdService.VirtualNetworkType);
                Assert.NotNull(createdService.VirtualNetworkConfiguration);
                Assert.Equal(getSubnetResponse.Id, createdService.VirtualNetworkConfiguration.SubnetResourceId);
                Assert.Equal(putPublicIPResponse.Id, createdService.PublicIpAddressId);

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
                Assert.NotNull(serviceNetworkStatus.First().NetworkStatus.ConnectivityStatus.First().ResourceType);

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
                // setup new public ip
                var putPublicIPResponse2 = await SetupPublicIPAsync(testBase);

                testBase.serviceProperties.VirtualNetworkType = VirtualNetworkType.Internal;
                testBase.serviceProperties.PublicIpAddressId = putPublicIPResponse2.Id;

                var updatedService = testBase.client.ApiManagementService.CreateOrUpdate(
                    resourceGroupName: testBase.rgName,
                    serviceName: testBase.serviceName,
                    parameters: testBase.serviceProperties);

                updatedService = await testBase.client.ApiManagementService.GetAsync(testBase.rgName, testBase.serviceName);

                Assert.Equal(VirtualNetworkType.Internal, updatedService.VirtualNetworkType);
                Assert.NotNull(updatedService.VirtualNetworkConfiguration);
                Assert.Equal(getSubnetResponse.Id, updatedService.VirtualNetworkConfiguration.SubnetResourceId);
                Assert.Equal(putPublicIPResponse2.Id, updatedService.PublicIpAddressId);

                // Delete
                testBase.client.ApiManagementService.Delete(
                    resourceGroupName: testBase.rgName,
                    serviceName: testBase.serviceName);

                Assert.Throws<Microsoft.Azure.Management.ApiManagement.Models.ErrorResponseException>(() =>
                {
                    testBase.client.ApiManagementService.Get(
                        resourceGroupName: testBase.rgName,
                        serviceName: testBase.serviceName);
                });
            }
        }

        async Task<PublicIPAddress> SetupPublicIPAsync(ApiManagementTestBase testBase)
        {
            // put Public IP
            string publicIpName = TestUtilities.GenerateName();
            string domainNameLabel = TestUtilities.GenerateName(testBase.rgName);

            var publicIp = new PublicIPAddress()
            {
                Location = testBase.location,
                Tags = new Dictionary<string, string>()
                    {
                       {"key","value"}
                    },
                PublicIPAllocationMethod = IPAllocationMethod.Static,
                PublicIPAddressVersion = "IPv4",
                DnsSettings = new PublicIPAddressDnsSettings()
                {
                    DomainNameLabel = domainNameLabel
                },
                Sku = new PublicIPAddressSku()
                {
                    Name = "Standard"
                }
            };
            var putPublicIPResponse = await testBase.networkClient.PublicIPAddresses.CreateOrUpdateAsync(testBase.rgName, publicIpName, publicIp);
            Assert.Equal("Succeeded", putPublicIPResponse.ProvisioningState);

            return putPublicIPResponse;
        }
    }
}