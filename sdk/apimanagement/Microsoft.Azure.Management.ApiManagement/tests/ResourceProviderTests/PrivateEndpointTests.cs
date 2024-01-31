// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.Management.ApiManagement;
using Microsoft.Azure.Management.ApiManagement.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using NRPPrivateEndpoint = Microsoft.Azure.Management.Network.Models.PrivateEndpoint;
using NRPPrivateLinkServiceConnection = Microsoft.Azure.Management.Network.Models.PrivateLinkServiceConnection;
using PrivateLinkServiceConnectionState = Microsoft.Azure.Management.ApiManagement.Models.PrivateLinkServiceConnectionState;

namespace ApiManagement.Tests.ResourceProviderTests
{
    public partial class ApiManagementServiceTests
    {
        const string apimPrivateEndpointTypeIdTemplate = "/subscriptions/{0}/resourceGroup/{1}/providers/Microsoft.Network/AvailablePrivateEndpointTypes/Microsoft.ApiManagement.service";
        const string apimPrivateLinkResourceIdTemplate = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.ApiManagement/service/{2}/privateLinkResources/Gateway";
        const string apimServiceIdTemplate = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.ApiManagement/service/{2}";
        const string privateEndpointIdTemplate = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/privateEndpoints/{2}";
        const string apimPrivateEndpointConnectionIdTemplate = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.ApiManagement/service/{2}/privateEndpointConnections/{3}";

        const string echoApiId = "echo-api";
        const string privateEndpointRequestDescription = "Please approve my connection.";
        const string privateEndpointRejectDescription = "Connection Rejected.";
        const string privateLinkResourceName = "Gateway";

        [Fact]
        [Trait("owner", "alanfeng")]

        public async void SetupPrivateEndpointAutoApprovalTests()
        {
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Playback");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                //prepare test base
                var testBase = new ApiManagementTestBase(context);
                testBase.serviceProperties.Sku = new ApiManagementServiceSkuProperties(SkuType.Developer, capacity: 1);

                // prepare private endpoint names and ids
                var virtualNetworkName = TestUtilities.GenerateName("apimvnet");
                var subnetName = TestUtilities.GenerateName("apimsubnet");
                var subnetId = CreateDefaultVNetWithSubnet(virtualNetworkName, subnetName, testBase);
                var privateEndpointName = TestUtilities.GenerateName("apimprivateendpoint");
                var privateEndpointConnectionName = TestUtilities.GenerateName("apimprivateendpointconnection");

                var apimPrivateEndpointTypeId = String.Format(apimPrivateEndpointTypeIdTemplate, testBase.subscriptionId, testBase.rgName);
                var apimPrivateLinkResourceId = String.Format(apimPrivateLinkResourceIdTemplate, testBase.subscriptionId, testBase.rgName, testBase.serviceName);
                var apimServiceId = String.Format(apimServiceIdTemplate, testBase.subscriptionId, testBase.rgName, testBase.serviceName);
                var apimPrivateEndpointId = String.Format(privateEndpointIdTemplate, testBase.subscriptionId, testBase.rgName, privateEndpointName);
                var apimPrivateEndpointConnectionId = String.Format(apimPrivateEndpointConnectionIdTemplate, testBase.subscriptionId, testBase.rgName, testBase.serviceName, privateEndpointConnectionName);

                //create new service
                var createdService = testBase.client.ApiManagementService.CreateOrUpdate(
                    resourceGroupName: testBase.rgName,
                    serviceName: testBase.serviceName,
                    parameters: testBase.serviceProperties);
                // service must be non-consumption and non-vnet to enable private link
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
                Assert.Equal(VirtualNetworkType.None, createdService.VirtualNetworkType);

                // verify the response of get available private endpoint types in subscription
                bool privateEndpointTypeFound = false;
                var pagedAvailablePrivateEndpointTypes = await testBase.networkClient.AvailablePrivateEndpointTypes.ListByResourceGroupAsync(testBase.location, testBase.rgName);
                while (pagedAvailablePrivateEndpointTypes != null && pagedAvailablePrivateEndpointTypes.Count() > 0)
                {
                    Console.WriteLine(pagedAvailablePrivateEndpointTypes);
                    if (pagedAvailablePrivateEndpointTypes.Any(peType =>
                        peType.Name == "Microsoft.ApiManagement.service" &&
                        peType.Type == "Microsoft.Network/AvailablePrivateEndpointTypes" &&
                        peType.ResourceName == "Microsoft.ApiManagement/service" &&
                        peType.Id == apimPrivateEndpointTypeId))
                    {
                        privateEndpointTypeFound = true;
                        break;
                    }
                    if (pagedAvailablePrivateEndpointTypes.NextPageLink != null && pagedAvailablePrivateEndpointTypes.NextPageLink != String.Empty)
                    {
                        pagedAvailablePrivateEndpointTypes = await testBase.networkClient.AvailablePrivateEndpointTypes.ListByResourceGroupNextAsync(pagedAvailablePrivateEndpointTypes.NextPageLink);
                    }
                    else
                    {
                        break;
                    }
                }
                Assert.True(privateEndpointTypeFound);

                // verify the response of get available private Link resources in subscription
                var listAvailablePrivateLinkResourceResponse = await testBase.client.PrivateEndpointConnection.ListPrivateLinkResourcesAsync(testBase.rgName, testBase.serviceName);
                Assert.Contains(listAvailablePrivateLinkResourceResponse.Value,
                    plResource =>
                        plResource.Name == privateLinkResourceName &&
                        plResource.Type == "Microsoft.ApiManagement/service/privateLinkResources" &&
                        plResource.Id == apimPrivateLinkResourceId &&
                        plResource.GroupId == privateLinkResourceName &&
                        plResource.RequiredMembers.Count == 1 &&
                        plResource.RequiredMembers.Contains(privateLinkResourceName) &&
                        plResource.RequiredZoneNames.Count == 1 &&
                        plResource.RequiredZoneNames.Contains("privateLink.azure-api.net"));

                // prepare vnet for private endpoint creation
                var plServiceConnection = new NRPPrivateLinkServiceConnection(
                    null,
                    null,
                    apimServiceId,
                    new List<string> { privateLinkResourceName },
                    privateEndpointRequestDescription,
                    null,
                    privateEndpointConnectionName);
                var subnet = new Subnet(subnetId);
                var privateEndpoint = new NRPPrivateEndpoint(
                    null,
                    null,
                    null,
                    testBase.location,
                    null,
                    null,
                    subnet,
                    null,
                    null,
                    new List<NRPPrivateLinkServiceConnection> { plServiceConnection });

                // create private endpoint with auto-approval flow
                var createdPrivateEndpoint = await testBase.networkClient.PrivateEndpoints.CreateOrUpdateAsync(testBase.rgName, privateEndpointName, privateEndpoint);

                // verify that the private endpoint connection is created correctly
                Assert.Equal(1, createdPrivateEndpoint.PrivateLinkServiceConnections.Count);
                Assert.Contains(createdPrivateEndpoint.PrivateLinkServiceConnections,
                    connection =>
                        connection.PrivateLinkServiceId == plServiceConnection.PrivateLinkServiceId &&
                        connection.GroupIds.Count == 1 &&
                        connection.PrivateLinkServiceConnectionState.Status == "Approved" &&
                        connection.PrivateLinkServiceConnectionState.Description == privateEndpointRequestDescription &&
                        connection.Name == plServiceConnection.Name &&
                        connection.GroupIds.Contains(privateLinkResourceName));
                Assert.Equal(privateEndpointName, createdPrivateEndpoint.Name);
                Assert.Equal(subnetId, createdPrivateEndpoint.Subnet.Id);
                Assert.Equal("Succeeded", createdPrivateEndpoint.ProvisioningState);

                // verify that the private endpoint connection returned from NRP List is correct
                var nrpListPrivateEndpointsResponse = await testBase.networkClient.PrivateEndpoints.ListAsync(testBase.rgName);
                Assert.Contains(nrpListPrivateEndpointsResponse,
                    pe =>
                        pe.Name == privateEndpointName &&
                        pe.Subnet.Id == subnetId &&
                        pe.ProvisioningState == "Succeeded" &&
                        1 == pe.PrivateLinkServiceConnections.Count(
                            connection =>
                            connection.PrivateLinkServiceId == plServiceConnection.PrivateLinkServiceId &&
                            connection.GroupIds.Count == 1 &&
                            connection.PrivateLinkServiceConnectionState.Status == "Approved" &&
                            connection.PrivateLinkServiceConnectionState.Description == privateEndpointRequestDescription &&
                            connection.Name == plServiceConnection.Name &&
                            connection.GroupIds.Contains(privateLinkResourceName)));

                // verify that the private endpoint connection returned from GET is correct
                createdPrivateEndpoint = await testBase.networkClient.PrivateEndpoints.GetAsync(testBase.rgName, privateEndpointName);
                Assert.Single(createdPrivateEndpoint.PrivateLinkServiceConnections);
                Assert.Equal(privateEndpointName, createdPrivateEndpoint.Name);
                Assert.Equal(subnetId, createdPrivateEndpoint.Subnet.Id);
                Assert.Equal("Succeeded", createdPrivateEndpoint.ProvisioningState);
                Assert.Contains(createdPrivateEndpoint.PrivateLinkServiceConnections,
                    connection =>
                        connection.PrivateLinkServiceId == plServiceConnection.PrivateLinkServiceId &&
                        connection.GroupIds.Count == 1 &&
                        connection.PrivateLinkServiceConnectionState.Status == "Approved" &&
                        connection.PrivateLinkServiceConnectionState.Description == privateEndpointRequestDescription &&
                        connection.Name == plServiceConnection.Name &&
                        connection.GroupIds.Contains(privateLinkResourceName));

                // verify that the private endpoint connection returned from LIST is correct
                var privateEndpointList = await testBase.networkClient.PrivateEndpoints.ListBySubscriptionAsync();
                Assert.Contains(privateEndpointList,
                    endpoint =>
                        endpoint.Name == privateEndpointName &&
                        endpoint.Subnet.Id == subnetId &&
                        1 == endpoint.PrivateLinkServiceConnections.Count(
                            connection =>
                                connection.PrivateLinkServiceId == plServiceConnection.PrivateLinkServiceId &&
                                connection.GroupIds.Count == 1 &&
                                connection.PrivateLinkServiceConnectionState.Status == "Approved" &&
                                connection.PrivateLinkServiceConnectionState.Description == privateEndpointRequestDescription &&
                                connection.Name == plServiceConnection.Name &&
                                connection.GroupIds.Contains(privateLinkResourceName)));

                // verfity that the private endpoint connection returned from GET api service container is correct
                // NOTE: currently connection.Name is returning internal name, need to verify after it is fixed
                var apiService = await testBase.client.ApiManagementService.GetAsync(testBase.rgName, testBase.serviceName);
                Assert.Contains(apiService.PrivateEndpointConnections,
                    connection =>
                        //connection.Name == privateEndpointName &&
                        connection.ProvisioningState == "Succeeded" &&
                        connection.PrivateLinkServiceConnectionState.Status == "Approved" &&
                        connection.PrivateLinkServiceConnectionState.Description == privateEndpointRequestDescription &&
                        connection.Id == apimPrivateEndpointConnectionId &&
                        connection.GroupIds.Contains(privateLinkResourceName) &&
                        connection.PrivateEndpoint.Id == apimPrivateEndpointId);

                // run only on live testing because generic HttpClient is not supported in recording
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Live")
                {
                    // verify that the service is reachable
                    var httpStatusCode = await CallApiServiceEchoApi(testBase);
                    Assert.True(IsSuccessStatusCode((int)httpStatusCode));
                }

                // disable public network access for the api service and confirm the container is updated with GET
                apiService.PublicNetworkAccess = "Disabled";
                apiService = await testBase.client.ApiManagementService.CreateOrUpdateAsync(testBase.rgName, testBase.serviceName, apiService);
                apiService = await testBase.client.ApiManagementService.GetAsync(testBase.rgName, testBase.serviceName);
                Assert.Contains(apiService.PrivateEndpointConnections,
                    connection =>
                        //connection.Name == privateEndpointName &&
                        connection.ProvisioningState == "Succeeded" &&
                        connection.PrivateLinkServiceConnectionState.Status == "Approved" &&
                        connection.PrivateLinkServiceConnectionState.Description == privateEndpointRequestDescription &&
                        connection.Id == apimPrivateEndpointConnectionId &&
                        connection.GroupIds.Contains(privateLinkResourceName) &&
                        connection.PrivateEndpoint.Id == apimPrivateEndpointId);
                Assert.True(apiService.PublicNetworkAccess == "Disabled");

                // run only on live testing because generic HttpClient is not supported in recording
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Live")
                {
                    // verify that the service is not reachable
                    var httpStatusCode = await CallApiServiceEchoApi(testBase);
                    Assert.False(IsSuccessStatusCode((int)httpStatusCode));
                }

                // reject private endpoint and verify
                // NOTE:wait for the fix
                var requestProperty = new PrivateEndpointConnectionRequestProperties(new PrivateLinkServiceConnectionState("Rejected", privateEndpointRejectDescription));
                var request = new PrivateEndpointConnectionRequest(apimPrivateEndpointConnectionId, requestProperty);
                var updatedPrivateEndpointConnection = await testBase.client.PrivateEndpointConnection.CreateOrUpdateAsync(testBase.rgName, testBase.serviceName, privateEndpointConnectionName, request);
                Assert.Equal(privateEndpointConnectionName, updatedPrivateEndpointConnection.Name);
                Assert.Equal("Succeeded", updatedPrivateEndpointConnection.ProvisioningState);
                Assert.Equal("Rejected", updatedPrivateEndpointConnection.PrivateLinkServiceConnectionState.Status);
                //Assert.Equal(privateEndpointRejectDescription, updatedPrivateEndpointConnection.PrivateLinkServiceConnectionState.Description);
                Assert.Equal(apimPrivateEndpointConnectionId, updatedPrivateEndpointConnection.Id);
                Assert.Equal(apimPrivateEndpointId, updatedPrivateEndpointConnection.PrivateEndpoint.Id);
                Console.WriteLine(updatedPrivateEndpointConnection.Type);

                // delete private endpoint and verify
                testBase.networkClient.PrivateEndpoints.Delete(testBase.rgName, privateEndpointName);
                Assert.Throws<Microsoft.Azure.Management.Network.Models.ErrorException>(() =>
                {
                    testBase.networkClient.PrivateEndpoints.Get(testBase.rgName, privateEndpointName);
                });

                // delete created service and verify
                testBase.client.ApiManagementService.Delete(testBase.rgName, testBase.serviceName);
                Assert.Throws<Microsoft.Azure.Management.ApiManagement.Models.ErrorResponseException>(() =>
                {
                    testBase.client.ApiManagementService.Get(testBase.rgName, testBase.serviceName);
                });
            }
        }

        private string CreateDefaultVNetWithSubnet(string virtualNetworkName, string subnetName, ApiManagementTestBase testBase)
        {
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
                            PrivateEndpointNetworkPolicies = "Disabled"
                        },
                    }
            };

            // Put Vnet
            var putVnetResponse = testBase.networkClient.VirtualNetworks.CreateOrUpdate(testBase.rgName, virtualNetworkName, vnet);
            Assert.Equal("Succeeded", putVnetResponse.ProvisioningState);

            var getSubnetResponse = testBase.networkClient.Subnets.Get(testBase.rgName, virtualNetworkName, subnetName);
            Assert.NotNull(getSubnetResponse);
            Assert.NotNull(getSubnetResponse.Id);

            return getSubnetResponse.Id;
        }

        protected async Task<HttpStatusCode> CallApiServiceEchoApi(ApiManagementTestBase testBase)
        {
            var subscriptionList = await testBase.client.Subscription.ListAsync(testBase.rgName, testBase.serviceName);
            var subscription = subscriptionList.First();
            var subscriptionId = subscription.Id.Split("/").Last();
            var subscriptionKey = await testBase.client.Subscription.ListSecretsAsync(testBase.rgName, testBase.serviceName, subscriptionId);
            var echoApi = await testBase.client.Api.GetAsync(testBase.rgName, testBase.serviceName, echoApiId);
            var apiService = await testBase.client.ApiManagementService.GetAsync(testBase.rgName, testBase.serviceName);
            var url = string.Format(CultureInfo.InvariantCulture, $"/{echoApi.Path}/resource");

            using (var handler = new HttpClientHandler())
            {
                using (var httpClient = new HttpClient(handler)
                {
                    BaseAddress = new Uri(apiService.GatewayUrl)
                })
                {
                    var message = new HttpRequestMessage(HttpMethod.Head, url);
                    message.Headers.Add("Ocp-Apim-Subscription-Key", subscriptionKey.PrimaryKey);
                    var response = await httpClient.SendAsync(message);
                    return response.StatusCode;
                }
            }
        }

        static bool IsSuccessStatusCode(int code)
        {
            if (code <= 301 || code == 304 || code == 307)
            {
                return true;
            }

            return false;
        }
    }
}