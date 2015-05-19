namespace Network.Tests.Gateways
{
    using Microsoft.WindowsAzure.Management.Network.Models;
    using System;
    using System.Linq;
    using System.Net;
    using Xunit;

    public class VirtualNetworkGatewayTests
    {
        [Fact]
        [Trait("Feature", "Gateways")]
        [Trait("Operation", "VirtualNetworkGateway")]
        public void VirtualNetworkGatewayAPIsTests()
        {
            using (NetworkTestClient networkTestClient = new NetworkTestClient())
            {
                string virtualNetworkSiteName = "coexistenceVirtualNetworkSiteName";
                string vnetGatewayName = "coexistenceVnetGateway";

                networkTestClient.EnsureNoNetworkConfigurationExists(virtualNetworkSiteName);

                // 1.CreateVirtualnetworkGateway API
                networkTestClient.SetNetworkConfiguration(NetworkTestConstants.CoexistenceFeatureNetworkConfigurationParameters);
                NetworkListResponse listResponse = networkTestClient.ListNetworkConfigurations();
                Assert.NotNull(listResponse);
                Assert.True(listResponse.VirtualNetworkSites.Any(vnet => vnet.Name.Equals(virtualNetworkSiteName)),
                    "Virtual network:" + virtualNetworkSiteName + " is not found!");
                string vnetId = listResponse.First(vnet => vnet.Name.Equals(virtualNetworkSiteName)).Id;

                GatewayGetOperationStatusResponse response =
                    networkTestClient.Gateways.CreateVirtualNetworkGateway(
                        virtualNetworkSiteName,
                        new VirtualNetworkGatewayCreateParameters()
                        {
                            GatewayName = vnetGatewayName,
                            GatewayType = GatewayType.DynamicRouting
                        });
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.HttpStatusCode);

                // 2.Listvirtualnetworkgateways API
                ListVirtualNetworkGatewaysResponse listVirtualNetworkGatewaysResponse = networkTestClient.Gateways.ListVirtualNetworkGateways();
                Assert.True(listVirtualNetworkGatewaysResponse.VirtualNetworkGateways.Count >= 1);
                string vnetGatewayId = listVirtualNetworkGatewaysResponse.VirtualNetworkGateways.First(vnetGateway => vnetGateway.GatewayName.Equals(vnetGatewayName)).GatewayId.ToString();

                // 3.Getvirtualnetworkgateway API
                VirtualNetworkGatewayGetResponse virtualNetworkGatewayGetResponse = networkTestClient.Gateways.GetVirtualNetworkGateway(vnetGatewayId);
                Assert.NotNull(virtualNetworkGatewayGetResponse);
                Assert.Equal(HttpStatusCode.OK, virtualNetworkGatewayGetResponse.StatusCode);
                Assert.Equal(vnetGatewayName, virtualNetworkGatewayGetResponse.GatewayName);
                Assert.Equal(GatewaySKU.Default, virtualNetworkGatewayGetResponse.GatewaySKU);
                Assert.Equal(GatewayType.DynamicRouting, virtualNetworkGatewayGetResponse.GatewayType);

                // 4.ResizeVirtualnetworkGateway API
                ResizeGatewayParameters parameters = new ResizeGatewayParameters()
                {
                    GatewaySKU = GatewaySKU.HighPerformance
                };
                response = networkTestClient.Gateways.ResizeVirtualNetworkGateway(vnetGatewayId, parameters);
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.HttpStatusCode);

                virtualNetworkGatewayGetResponse = networkTestClient.Gateways.GetVirtualNetworkGateway(vnetGatewayId);
                Assert.NotNull(virtualNetworkGatewayGetResponse);
                Assert.Equal(HttpStatusCode.OK, virtualNetworkGatewayGetResponse.StatusCode);
                Assert.Equal(vnetGatewayName, virtualNetworkGatewayGetResponse.GatewayName);
                Assert.Equal(GatewaySKU.HighPerformance, virtualNetworkGatewayGetResponse.GatewaySKU);

                // 5.ResetVirtualnetworkGateway API
                ResetGatewayParameters resetGatewayParameters = new ResetGatewayParameters();
                response = networkTestClient.Gateways.ResetVirtualNetworkGateway(vnetGatewayId, resetGatewayParameters);
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.HttpStatusCode);

                // 6.DeleteVirtualNetworkGateway API
                response = networkTestClient.Gateways.DeleteVirtualNetworkGateway(vnetGatewayId);
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.HttpStatusCode);

                listVirtualNetworkGatewaysResponse = networkTestClient.Gateways.ListVirtualNetworkGateways();
                Assert.False(listVirtualNetworkGatewaysResponse.VirtualNetworkGateways.Any(vnetGateway => vnetGateway.GatewayName.Equals(vnetGatewayName)),
                    "Virtual network: " + virtualNetworkSiteName + " gateway: " + vnetGatewayName + " is not deleted even after DeleteVirtualNetworkGateway API call!");
            }
        }
    }
}
