using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.IotHub;
using Microsoft.Azure.Management.IotHub.Models;
using Microsoft.Azure.Management.ProvisioningServices;
using Microsoft.Azure.Management.ProvisioningServices.Models;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ProvisioningServices.Tests
{
    public class ProvisioningClientLinkedHubsTests : DeviceProvisioningTestBase
    {
        [Fact]
        public void Create()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                var testName = "unitTestingDPSLinkedHubCreate";
                this.Initialize(context);
                var iotHubClient = this.GetClient<IotHubClient>(context);
                var resourceGroup = this.GetResourceGroup(testName);
                var testedService = GetService(testName, resourceGroup.Name);

                var iotHub = GetIoTHub(iotHubClient, resourceGroup, testName);
                var keys = iotHubClient.IotHubResource.ListKeys(
                    resourceGroup.Name,
                    iotHub.Name);
                var key = keys.FirstOrDefault(x => x.Rights.HasFlag(AccessRights.ServiceConnect));
                var connectionString = $"HostName={iotHub.Name};SharedAccessKeyName={key.KeyName};SharedAccessKey={key.PrimaryKey}";
                testedService.Properties.IotHubs =
                    testedService.Properties.IotHubs ?? new List<IotHubDefinitionDescription>(1);

                testedService.Properties.IotHubs.Add(new IotHubDefinitionDescription(connectionString, resourceGroup.Location));
                var updatedInstance = 
                    this.provisioningClient.IotDpsResource.CreateOrUpdate(resourceGroup.Name, testName,
                    testedService);

                Assert.Contains(updatedInstance.Properties.IotHubs, x => x.Name == iotHub.Name);
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