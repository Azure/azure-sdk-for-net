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

    public class DedicatedCircuitTests : ExpressRouteTestBase
    {
        [Fact]
        public void CanCreateGetListUpdateAndDeleteDedicatedCircuit()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var expressRouteClient = GetCustomerExpressRouteManagementClient();

                var providers = expressRouteClient.DedicatedCircuitServiceProviders.List();
                var providerName = GetProviderName();
                var provider = providers.Single(p => p.Name.Equals(providerName, StringComparison.CurrentCultureIgnoreCase));
                var location = provider.DedicatedCircuitLocations.Split(',').First();
                var bandwidth = provider.DedicatedCircuitBandwidths.First().Bandwidth;
                var circuitName = TestUtilities.GenerateName("circuit");
                var newParams = new DedicatedCircuitNewParameters()
                    {
                        Bandwidth = bandwidth,
                        CircuitName = circuitName,
                        Location = location,
                        ServiceProviderName = provider.Name,
                        BillingType = BillingType.UnlimitedData
                    };
                var newResponse = expressRouteClient.DedicatedCircuits.New(newParams);
                TestUtilities.ValidateOperationResponse(newResponse);
                Guid serviceKey;
                Assert.True(Guid.TryParse(newResponse.Data, out serviceKey));
                DedicatedCircuitGetResponse createdCircuit = expressRouteClient.DedicatedCircuits.Get(serviceKey.ToString());
                Assert.Equal(createdCircuit.DedicatedCircuit.CircuitName, circuitName, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(createdCircuit.DedicatedCircuit.ServiceProviderName, provider.Name, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(createdCircuit.DedicatedCircuit.Bandwidth, bandwidth);
                Assert.Equal(createdCircuit.DedicatedCircuit.Location, location, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(createdCircuit.DedicatedCircuit.Status, DedicatedCircuitState.Enabled);
                Assert.Equal(createdCircuit.DedicatedCircuit.ServiceProviderProvisioningState, ProviderProvisioningState.NotProvisioned);
                Assert.Equal(createdCircuit.DedicatedCircuit.BillingType, BillingType.UnlimitedData.ToString());

                DedicatedCircuitListResponse circuits = expressRouteClient.DedicatedCircuits.List();
                TestUtilities.ValidateOperationResponse(circuits);
                Assert.NotEmpty(circuits.DedicatedCircuits);
                var circuit =
                    circuits.DedicatedCircuits.FirstOrDefault(c => c.CircuitName.Equals(circuitName, StringComparison.CurrentCultureIgnoreCase));
                Assert.NotNull(circuit);
                Assert.Equal(serviceKey.ToString(), circuit.ServiceKey);
                Assert.Equal(location, circuit.Location, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(provider.Name, circuit.ServiceProviderName, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(circuit.ServiceProviderProvisioningState, ProviderProvisioningState.NotProvisioned);
                Assert.Equal(bandwidth, circuit.Bandwidth);
                Assert.Equal(circuit.Status, DedicatedCircuitState.Enabled);

                var updateParams = new DedicatedCircuitUpdateParameters()
                    {
                        Bandwidth = provider.DedicatedCircuitBandwidths.Last().Bandwidth.ToString()
                    };
                var updateResponse = expressRouteClient.DedicatedCircuits.Update(serviceKey.ToString(), updateParams);
                TestUtilities.ValidateOperationResponse(updateResponse);

                var updatedCircuit = expressRouteClient.DedicatedCircuits.Get(serviceKey.ToString());
                TestUtilities.ValidateOperationResponse(updatedCircuit);
                Assert.Equal(updatedCircuit.DedicatedCircuit.Bandwidth.ToString(), updateParams.Bandwidth);

            }

        }

        [Fact]
        public void CreateFailsIfDuplicateName()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var expressRouteClient = GetCustomerExpressRouteManagementClient();
                var provider = expressRouteClient.DedicatedCircuitServiceProviders.List().Single(p => p.Name.Equals(GetProviderName(), StringComparison.CurrentCultureIgnoreCase)); 
                var location = provider.DedicatedCircuitLocations.Split(',').First();
                var bandwidth = provider.DedicatedCircuitBandwidths.First().Bandwidth;
                var circuitName = TestUtilities.GenerateName("circuit");
                var newParams = new DedicatedCircuitNewParameters()
                {
                    Bandwidth = bandwidth,
                    CircuitName = circuitName,
                    Location = location,
                    ServiceProviderName = provider.Name
                };
                var newResponse = expressRouteClient.DedicatedCircuits.New(newParams);
                TestUtilities.ValidateOperationResponse(newResponse);
                Guid serviceKey;
                Assert.True(Guid.TryParse(newResponse.Data, out serviceKey));
                DedicatedCircuitGetResponse createdCircuit = expressRouteClient.DedicatedCircuits.Get(serviceKey.ToString());
                Assert.Equal(createdCircuit.DedicatedCircuit.CircuitName, circuitName, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(createdCircuit.DedicatedCircuit.ServiceProviderName, provider.Name, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(createdCircuit.DedicatedCircuit.Bandwidth, bandwidth);
                Assert.Equal(createdCircuit.DedicatedCircuit.Location, location, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(createdCircuit.DedicatedCircuit.Status, DedicatedCircuitState.Enabled);
                Assert.Equal(createdCircuit.DedicatedCircuit.ServiceProviderProvisioningState, ProviderProvisioningState.NotProvisioned);
                var exception = Assert.Throws<CloudException>(() => newResponse = expressRouteClient.DedicatedCircuits.New(newParams));
                Assert.Equal(exception.Error.Code, "ConflictError");
                Assert.True(exception.Error.Message.Contains(circuitName) && exception.Error.Message.Contains("already exists"));
            }
        }

        [Fact]
        public void CreateFailsIfProviderDoesNotExist()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var expressRouteClient = GetCustomerExpressRouteManagementClient();
                var providerName = TestUtilities.GenerateName("provider");
                var location = TestUtilities.GenerateName("location");
                uint bandwidth = DefaultCircuitBandwidth;
                var circuitName = TestUtilities.GenerateName("circuit");
                var newParams = new DedicatedCircuitNewParameters()
                {
                    Bandwidth = bandwidth,
                    CircuitName = circuitName,
                    Location = location,
                    ServiceProviderName = providerName
                };
                var exception = Assert.Throws<CloudException>(() => expressRouteClient.DedicatedCircuits.New(newParams));
                Assert.Equal(exception.Error.Code, "ResourceNotFound");
                Assert.True(exception.Error.Message.Contains("The provider could not be found"));
            }
        }

        [Fact]
        public void CreateFailsIfLocationDoesNotExist()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var expressRouteClient = GetCustomerExpressRouteManagementClient();
                var provider = expressRouteClient.DedicatedCircuitServiceProviders.List().Single(p => p.Name.Equals(GetProviderName(), StringComparison.CurrentCultureIgnoreCase));
                var location = TestUtilities.GenerateName("location");
                var bandwidth = provider.DedicatedCircuitBandwidths.First().Bandwidth;
                var circuitName = TestUtilities.GenerateName("circuit");
                var newParams = new DedicatedCircuitNewParameters()
                {
                    Bandwidth = bandwidth,
                    CircuitName = circuitName,
                    Location = location,
                    ServiceProviderName = provider.Name
                };
                var newResponse = new ExpressRouteOperationStatusResponse(); 
                var exception = Assert.Throws<CloudException>(() => newResponse = expressRouteClient.DedicatedCircuits.New(newParams));
                Assert.Equal(exception.Error.Code, "ResourceNotFound");
                Assert.True(exception.Error.Message.Contains(location) && exception.Error.Message.Contains("does not exist"));
            }
        }

        [Fact]
        public void CreateFailsIfBandwidthDoesNotExist()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var expressRouteClient = GetCustomerExpressRouteManagementClient();
                var provider = expressRouteClient.DedicatedCircuitServiceProviders.List().Single(p => p.Name.Equals(GetProviderName(), StringComparison.CurrentCultureIgnoreCase));
                var location = provider.DedicatedCircuitLocations.Split(',').First();
                var circuitName = TestUtilities.GenerateName("circuit");
                var newParams = new DedicatedCircuitNewParameters()
                {
                    Bandwidth = DefaultCircuitBandwidth,
                    CircuitName = circuitName,
                    Location = location,
                    ServiceProviderName = provider.Name
                };
                var newResponse = new ExpressRouteOperationStatusResponse();
                var exception = Assert.Throws<CloudException>(() => newResponse = expressRouteClient.DedicatedCircuits.New(newParams));
                Assert.Equal(exception.Error.Code, "ResourceNotFound");
                Assert.True(exception.Error.Message.Contains(DefaultCircuitBandwidth.ToString()) && exception.Error.Message.Contains("does not exist"));
            }
        }

        [Fact]
        public void CanListDedicatedCircuit()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var expressRouteClient = GetCustomerExpressRouteManagementClient();
                var provider = expressRouteClient.DedicatedCircuitServiceProviders.List().Single(p => p.Name.Equals(GetProviderName(), StringComparison.CurrentCultureIgnoreCase));
                var location = provider.DedicatedCircuitLocations.Split(',').First();
                var bandwidth = provider.DedicatedCircuitBandwidths.First().Bandwidth;
                var circuitName = TestUtilities.GenerateName("circuit");
                var newParams = new DedicatedCircuitNewParameters()
                {
                    Bandwidth = bandwidth,
                    CircuitName = circuitName,
                    Location = location,
                    ServiceProviderName = provider.Name
                };
                var newResponse = expressRouteClient.DedicatedCircuits.New(newParams);
                TestUtilities.ValidateOperationResponse(newResponse);
                Guid serviceKey;
                Assert.True(Guid.TryParse(newResponse.Data, out serviceKey));
                DedicatedCircuitListResponse circuits = expressRouteClient.DedicatedCircuits.List();
                Assert.NotEmpty(circuits.DedicatedCircuits);
                var circuit =
                    circuits.DedicatedCircuits.FirstOrDefault(c => c.CircuitName.Equals(circuitName, StringComparison.CurrentCultureIgnoreCase));
                Assert.NotNull(circuit);
                Assert.Equal(serviceKey.ToString(), circuit.ServiceKey);
                Assert.Equal(location, circuit.Location, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(provider.Name, circuit.ServiceProviderName, StringComparer.CurrentCultureIgnoreCase);
                Assert.Equal(circuit.ServiceProviderProvisioningState, ProviderProvisioningState.NotProvisioned);
                Assert.Equal(bandwidth, circuit.Bandwidth);
                Assert.Equal(circuit.Status, DedicatedCircuitState.Enabled);
            }
        }

        [Fact]
        public void GetFailsIfCircuitDoesNotExist()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var expressRouteClient = GetCustomerExpressRouteManagementClient();
                
                var getResponse = new DedicatedCircuitGetResponse();
                var exception = Assert.Throws<CloudException>(() => getResponse = expressRouteClient.DedicatedCircuits.Get(FakeServiceKey));
                Assert.Equal(exception.Error.Code, "ResourceNotFound");
                Assert.True(exception.Error.Message.Contains(FakeServiceKey) && exception.Error.Message.Contains("was not found"));
            }
        }

        [Fact]
        public void CanRemoveDedicatedCircuit()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var expressRouteClient = GetCustomerExpressRouteManagementClient();
                var provider = expressRouteClient.DedicatedCircuitServiceProviders.List().Single(p => p.Name.Equals(GetProviderName(), StringComparison.CurrentCultureIgnoreCase));
                var location = provider.DedicatedCircuitLocations.Split(',').First();
                var bandwidth = provider.DedicatedCircuitBandwidths.First().Bandwidth;
                var circuitName = TestUtilities.GenerateName("circuit");
                var newParams = new DedicatedCircuitNewParameters()
                {
                    Bandwidth = bandwidth,
                    CircuitName = circuitName,
                    Location = location,
                    ServiceProviderName = provider.Name
                };
                var newResponse = expressRouteClient.DedicatedCircuits.New(newParams);
                TestUtilities.ValidateOperationResponse(newResponse);
                Guid serviceKey;
                Assert.True(Guid.TryParse(newResponse.Data, out serviceKey));
                ExpressRouteOperationStatusResponse removeResponse = expressRouteClient.DedicatedCircuits.Remove(serviceKey.ToString());
                TestUtilities.ValidateOperationResponse(removeResponse);
            }
        }

        [Fact]
        public void RemoveFailsIfCircuitDoesNotExist()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();
                var expressRouteClient = GetCustomerExpressRouteManagementClient();

                var removeResponse = new ExpressRouteOperationStatusResponse();
                var exception = Assert.Throws<CloudException>(() => removeResponse = expressRouteClient.DedicatedCircuits.Remove(FakeServiceKey));
                Assert.Equal(exception.Error.Code, "BadRequest");
                Assert.True(exception.Error.Message.Contains(FakeServiceKey) && exception.Error.Message.Contains("is not valid or could not be found"));
            }
        }
    }
}