using DeviceProvisioningServices.Tests.Helpers;
using FluentAssertions;
using Microsoft.Azure.Management.DeviceProvisioningServices;
using Microsoft.Azure.Management.DeviceProvisioningServices.Models;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Threading.Tasks;
using Xunit;

namespace DeviceProvisioningServices.Tests.ScenarioTests
{
    public class DeviceProvisioningClientTest : DeviceProvisioningTestBase
    {
        [Fact]
        public async Task CreateAndDelete()
        {
            using var context = MockContext.Start(GetType());

            Initialize(context);
            const string testName = "unitTestingDPSCreateUpdate";
            ResourceGroup rg = await GetResourceGroupAsync(testName);

            var availabilityInfo = await _provisioningClient.IotDpsResource
                .CheckProvisioningServiceNameAvailabilityAsync(testName)
                .ConfigureAwait(false);

            if (availabilityInfo.NameAvailable.HasValue && !availabilityInfo.NameAvailable.Value)
            {
                // it exists, so test the delete
                await _provisioningClient.IotDpsResource
                    .DeleteAsync(testName, rg.Name)
                    .ConfigureAwait(false);

                // check the name is now available
                availabilityInfo = await _provisioningClient.IotDpsResource
                    .CheckProvisioningServiceNameAvailabilityAsync(testName)
                    .ConfigureAwait(false);
                availabilityInfo.NameAvailable.Should().BeTrue();
            }

            // try to create a DPS service
            var createServiceDescription = new ProvisioningServiceDescription(
                Constants.DefaultLocation,
                new IotDpsPropertiesDescription(),
                new IotDpsSkuInfo(
                    Constants.DefaultSku.Name,
                    Constants.DefaultSku.Tier,
                    Constants.DefaultSku.Capacity));

            var dpsInstance = await _provisioningClient.IotDpsResource
                .CreateOrUpdateAsync(
                    rg.Name,
                    testName,
                    createServiceDescription)
                .ConfigureAwait(false);

            dpsInstance.Should().NotBeNull();
            dpsInstance.Sku.Name.Should().Be(Constants.DefaultSku.Name);
            dpsInstance.Name.Should().Be(testName);

            // verify item exists in list by resource group
            IPage<ProvisioningServiceDescription> existingServices = await _provisioningClient.IotDpsResource
                .ListByResourceGroupAsync(rg.Name)
                .ConfigureAwait(false);
            existingServices.Should().Contain(x => x.Name == testName);

            // verify can find
            ProvisioningServiceDescription foundInstance = await _provisioningClient.IotDpsResource
                .GetAsync(testName, testName)
                .ConfigureAwait(false);
            foundInstance.Should().NotBeNull();
            foundInstance.Name.Should().Be(testName);

            var attempts = Constants.ArmAttemptLimit;
            while (attempts > 0)
            {
                try
                {
                    await _provisioningClient.IotDpsResource
                        .DeleteAsync(testName, rg.Name)
                        .ConfigureAwait(false);
                    break;
                }
                catch
                {
                    attempts--;
                    await Task.Delay(Constants.ArmAttemptWaitMs).ConfigureAwait(false);
                }
            }
            existingServices = await _provisioningClient.IotDpsResource
                .ListByResourceGroupAsync(testName)
                .ConfigureAwait(false);

            // As long as it is gone or deleting, we're good
            existingServices.Should().NotContain(x => x.Name == testName && x.Properties.State != "Deleting");
        }

        [Fact]
        public async Task UpdateSku()
        {
            using var context = MockContext.Start(GetType());
            Initialize(context);
            const string testName = "unitTestingDPSUpdateSku";
            ResourceGroup rg = await GetResourceGroupAsync(testName).ConfigureAwait(false);
            ProvisioningServiceDescription service = await GetServiceAsync(testName, testName).ConfigureAwait(false);

            // update capacity
            service.Sku.Capacity += 1;

            var attempts = Constants.ArmAttemptLimit;
            while (attempts > 0)
            {
                try
                {
                    ProvisioningServiceDescription updatedInstance = await _provisioningClient
                        .IotDpsResource.CreateOrUpdateAsync(
                            rg.Name,
                            service.Name,
                            service)
                        .ConfigureAwait(false);
                    updatedInstance.Sku.Capacity.Should().Be(service.Sku.Capacity);
                    break;
                }
                catch
                {
                    // Let ARM finish
                    await Task.Delay(Constants.ArmAttemptWaitMs).ConfigureAwait(false);
                    attempts--;
                }
            }
        }

        [Fact]
        public async Task CreateFailure()
        {
            using var context = MockContext.Start(GetType());

            Initialize(context);
            const string testName = "unitTestingDPSCreateUpdateInvalidName";
            ResourceGroup rg = await GetResourceGroupAsync(testName).ConfigureAwait(false);

            // try to create a DPS service
            var createServiceDescription = new ProvisioningServiceDescription(
                Constants.DefaultLocation,
                new IotDpsPropertiesDescription(),
                new IotDpsSkuInfo(Constants.DefaultSku.Name,
                    Constants.DefaultSku.Tier,
                    Constants.DefaultSku.Capacity));

            var badCall = new Func<Task<ProvisioningServiceDescription>>(
                () =>
                    // force a failure by passing bad input
                    _provisioningClient.IotDpsResource.CreateOrUpdateAsync(
                    rg.Name,
                    // Must be between 3 and 64 characters, must not be a number, must be alphanumeric/dash characters, and must be unique
                    $"Invalid {testName}",
                    createServiceDescription));

            await badCall.Should().ThrowAsync<ErrorDetailsException>();
        }
    }
}
