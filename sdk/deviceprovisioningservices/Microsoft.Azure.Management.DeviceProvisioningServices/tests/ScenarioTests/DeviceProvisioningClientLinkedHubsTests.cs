using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.IotHub;
using Microsoft.Azure.Management.IotHub.Models;
using Microsoft.Azure.Management.DeviceProvisioningServices;
using Microsoft.Azure.Management.DeviceProvisioningServices.Models;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace DeviceProvisioningServices.Tests.ScenarioTests
{
    public class DeviceProvisioningClientLinkedHubsTests : DeviceProvisioningTestBase
    {
        [Fact]
        public void CreateAndDelete()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                var testName = "unitTestingDPSLinkedHubCreateUpdateDelete";
                this.Initialize(context);
                var iotHubClient = this.GetClient<IotHubClient>(context);
                var resourceGroup = this.GetResourceGroup(testName);
                var testedService = GetService(testName, resourceGroup.Name);

                var iotHub = GetIoTHub(iotHubClient, resourceGroup, testName);
                var keys = iotHubClient.IotHubResource.ListKeys(
                    resourceGroup.Name,
                    iotHub.Name);
                var key = keys.FirstOrDefault(x => x.Rights.HasFlag(AccessRights.ServiceConnect));
                var connectionString = $"HostName={iotHub.Name}.azure-devices.net;SharedAccessKeyName={key.KeyName};SharedAccessKey={key.PrimaryKey}";
                testedService.Properties.IotHubs =
                    testedService.Properties.IotHubs ?? new List<IotHubDefinitionDescription>(1);

                testedService.Properties.IotHubs.Add(new IotHubDefinitionDescription(connectionString, resourceGroup.Location, name: testName));
                var updatedInstance = 
                    this.provisioningClient.IotDpsResource.CreateOrUpdate(resourceGroup.Name, testName,
                    testedService);

                var returnedHub = updatedInstance.Properties.IotHubs.FirstOrDefault(x => x.ConnectionString.StartsWith($"HostName={iotHub.Name}.azure-devices.net;"));
                Assert.NotNull(returnedHub);
                connectionString = returnedHub.ConnectionString;

                var updatedApplyPolicy = !(returnedHub.ApplyAllocationPolicy ?? false);
                returnedHub.ApplyAllocationPolicy = updatedApplyPolicy;

                var updatedPolicyWeight = Helpers.Constants.RandomAllocationWeight;
                returnedHub.AllocationWeight = updatedPolicyWeight;

                updatedInstance =
                    this.provisioningClient.IotDpsResource.CreateOrUpdate(resourceGroup.Name, testName,
                        updatedInstance);
                var updatedHub = updatedInstance.Properties.IotHubs.FirstOrDefault(x => x.ConnectionString == connectionString);
                Assert.NotNull(updatedHub);

                Assert.Equal(updatedApplyPolicy, updatedHub.ApplyAllocationPolicy);
                Assert.Equal(updatedPolicyWeight, updatedHub.AllocationWeight);


                //Delete the linked hub
                testedService.Properties.IotHubs = testedService.Properties.IotHubs.Except(
                    testedService.Properties.IotHubs.Where(x => x.Name == testName)).ToList();
                updatedInstance = this.provisioningClient.IotDpsResource.CreateOrUpdate(resourceGroup.Name, testName,
                    testedService);
                Assert.DoesNotContain(updatedInstance.Properties.IotHubs, x=> x.ConnectionString == connectionString);

            }
        }


        private IotHubDescription GetIoTHub(IotHubClient iotHubClient, ResourceGroup resourceGroup, string hubName)
        {
            return iotHubClient.IotHubResource.CreateOrUpdate(
                resourceGroup.Name,
                hubName,
            new IotHubDescription
            {
                Location = resourceGroup.Location,
                Subscriptionid = testEnv.SubscriptionId,
                Resourcegroup = resourceGroup.Name,
                Sku = new IotHubSkuInfo
                {
                    Name = "S1",
                    Capacity = 1
                },
                Properties = new IotHubProperties
                {
                    Routing = new RoutingProperties()
                }
            });
        }
    }
}
