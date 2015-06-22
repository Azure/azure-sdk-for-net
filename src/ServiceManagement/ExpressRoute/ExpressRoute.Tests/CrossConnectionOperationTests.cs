namespace Microsoft.WindowsAzure.Management.ExpressRoute.Testing
{
    using System;
    using System.Linq;
    using System.Net;
    using Azure.Management.ExpressRoute.Testing;
    using Azure.Test;
    using ExpressRoute;
    using ExpressRoute.Models;
    using Hyak.Common;
    using Management;
    using Xunit;

    public class CrossConnectionTests : ExpressRouteTestBase
    {
        [Fact]
        public void CanCreateGetListAndUpdateCrossConnnections()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var customerExpressRouteClient = GetCustomerExpressRouteManagementClient();
                var provider =
                    customerExpressRouteClient.DedicatedCircuitServiceProviders.List()
                                              .Single(
                                                  p =>
                                                  p.Name.Equals(GetProviderName(),
                                                                StringComparison.CurrentCultureIgnoreCase));
                var location = provider.DedicatedCircuitLocations.Split(',').First();
                var bandwidth = provider.DedicatedCircuitBandwidths.First().Bandwidth;
                var circuitName = TestUtilities.GenerateName("circuit");
                var newCircuitParams = new DedicatedCircuitNewParameters()
                    {
                        Bandwidth = bandwidth,
                        CircuitName = circuitName,
                        Location = location,
                        ServiceProviderName = provider.Name
                    };
                var newResponse = customerExpressRouteClient.DedicatedCircuits.New(newCircuitParams);
                TestUtilities.ValidateOperationResponse(newResponse);
                Guid serviceKey;
                Assert.True(Guid.TryParse(newResponse.Data, out serviceKey));
                var providerExpressRouteClient = GetProviderExpressRouteManagementClient();
                newResponse = providerExpressRouteClient.CrossConnections.New(serviceKey.ToString());
                TestUtilities.ValidateOperationResponse(newResponse);

                CrossConnectionGetResponse getResponse =
                    providerExpressRouteClient.CrossConnections.Get(serviceKey.ToString());
                TestUtilities.ValidateOperationResponse(getResponse);
                Assert.Equal((uint) getResponse.CrossConnection.Bandwidth, bandwidth);
                Assert.Equal(getResponse.CrossConnection.Status, DedicatedCircuitState.Enabled.ToString());
                Assert.Equal(getResponse.CrossConnection.ProvisioningState,
                             ProviderProvisioningState.Provisioning.ToString());

                var updateParams = new CrossConnectionUpdateParameters()
                    {
                        Operation = UpdateCrossConnectionOperation.NotifyCrossConnectionProvisioned,
                        ProvisioningError = ""
                    };
                var updateResponse = providerExpressRouteClient.CrossConnections.Update(serviceKey.ToString(),
                                                                                        updateParams);
                TestUtilities.ValidateOperationResponse(updateResponse);

            }
        }
    }
}