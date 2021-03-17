using FluentAssertions;
using Microsoft.Azure.Management.DeviceProvisioningServices;
using Microsoft.Azure.Management.DeviceProvisioningServices.Models;
using Microsoft.Azure.Management.IotHub;
using Microsoft.Azure.Management.IotHub.Models;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DeviceProvisioningServices.Tests.ScenarioTests
{
    public class DeviceProvisioningClientLinkedHubsTests : DeviceProvisioningTestBase
    {
        [Fact]
        public async Task CreateAndDelete()
        {
            using var context = MockContext.Start(GetType());
            var testName = "unitTestingDPSLinkedHubCreateUpdateDelete";
            Initialize(context);
            var iotHubClient = GetClient<IotHubClient>(context);
            ResourceGroup resourceGroup = await GetResourceGroupAsync(testName).ConfigureAwait(false);
            ProvisioningServiceDescription testedService = await GetServiceAsync(resourceGroup.Name, testName).ConfigureAwait(false);

            IotHubDescription iotHub = await GetIotHubAsync(iotHubClient, resourceGroup, testName).ConfigureAwait(false);
            IPage<SharedAccessSignatureAuthorizationRule> keys = await iotHubClient.IotHubResource
                .ListKeysAsync(
                    resourceGroup.Name,
                    iotHub.Name)
                .ConfigureAwait(false);
            SharedAccessSignatureAuthorizationRule key = keys.FirstOrDefault(x => x.Rights.HasFlag(AccessRights.ServiceConnect));
            var connectionString = $"HostName={iotHub.Name}.azure-devices.net;SharedAccessKeyName={key.KeyName};SharedAccessKey={key.PrimaryKey}";
            testedService.Properties.IotHubs = testedService.Properties.IotHubs ?? new List<IotHubDefinitionDescription>(1);

            testedService.Properties.IotHubs.Add(new IotHubDefinitionDescription(connectionString, resourceGroup.Location, name: testName));
            ProvisioningServiceDescription updatedInstance = await _provisioningClient.IotDpsResource
                .CreateOrUpdateAsync(
                    resourceGroup.Name,
                    testName,
                    testedService)
                .ConfigureAwait(false);

            IotHubDefinitionDescription returnedHub = updatedInstance.Properties.IotHubs
                .FirstOrDefault(x => x.ConnectionString.StartsWith($"HostName={iotHub.Name}.azure-devices.net;"));
            returnedHub.Should().NotBeNull();
            connectionString = returnedHub.ConnectionString;

            bool hasUpdatedApplyPolicy = !(returnedHub.ApplyAllocationPolicy ?? false);
            returnedHub.ApplyAllocationPolicy = hasUpdatedApplyPolicy;

            int updatedPolicyWeight = Helpers.Constants.RandomAllocationWeight;
            returnedHub.AllocationWeight = updatedPolicyWeight;

            updatedInstance = await _provisioningClient.IotDpsResource
                .CreateOrUpdateAsync(
                    resourceGroup.Name,
                    testName,
                    updatedInstance)
                .ConfigureAwait(false);
            IotHubDefinitionDescription updatedHub = updatedInstance.Properties.IotHubs
                .FirstOrDefault(x => x.ConnectionString == connectionString);
            updatedHub.Should().NotBeNull();

            updatedHub.ApplyAllocationPolicy.Should().Be(hasUpdatedApplyPolicy);
            updatedHub.AllocationWeight.Should().Be(updatedPolicyWeight);


            // Delete the linked hub
            testedService.Properties.IotHubs = testedService.Properties.IotHubs
                .Except(testedService.Properties.IotHubs.Where(x => x.Name == testName))
                .ToList();
            updatedInstance = await _provisioningClient.IotDpsResource
                .CreateOrUpdateAsync(
                    resourceGroup.Name,
                    testName,
                    testedService)
                .ConfigureAwait(false);
            updatedInstance.Properties.IotHubs.Should().NotContain(connectionString);
        }


        private Task<IotHubDescription> GetIotHubAsync(IotHubClient iotHubClient, ResourceGroup resourceGroup, string hubName)
        {
            return iotHubClient.IotHubResource.CreateOrUpdateAsync(
                resourceGroup.Name,
                hubName,
                new IotHubDescription
                {
                    Location = resourceGroup.Location,
                    Subscriptionid = _testEnv.SubscriptionId,
                    Resourcegroup = resourceGroup.Name,
                    Sku = new IotHubSkuInfo
                    {
                        Name = "S1",
                        Capacity = 1,
                    },
                    Properties = new IotHubProperties
                    {
                        Routing = new RoutingProperties(),
                    },
                });
        }
    }
}
