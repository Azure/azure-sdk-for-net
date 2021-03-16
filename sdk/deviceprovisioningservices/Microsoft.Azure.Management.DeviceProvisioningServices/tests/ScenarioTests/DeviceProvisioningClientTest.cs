using DeviceProvisioningServices.Tests.Helpers;
using FluentAssertions;
using Microsoft.Azure.Management.DeviceProvisioningServices;
using Microsoft.Azure.Management.DeviceProvisioningServices.Models;
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
            var testName = "unitTestingDPSCreateUpdate";
            await GetResourceGroupAsync(testName);


            var availabilityInfo = await _provisioningClient.IotDpsResource
                .CheckProvisioningServiceNameAvailabilityAsync(testName)
                .ConfigureAwait(false);

            if (availabilityInfo.NameAvailable.HasValue && !availabilityInfo.NameAvailable.Value)
            {
                //it exists, so test the delete
                await _provisioningClient.IotDpsResource
                    .DeleteAsync(testName, testName)
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
                    testName,
                    testName,
                    createServiceDescription)
                .ConfigureAwait(false);

            dpsInstance.Should().NotBeNull();
            dpsInstance.Sku.Name.Should().Be(Constants.DefaultSku.Name);
            dpsInstance.Name.Should().Be(testName);

            // verify item exists in list by resource group
            IPage<ProvisioningServiceDescription> existingServices = await _provisioningClient.IotDpsResource
                .ListByResourceGroupAsync(testName)
                .ConfigureAwait(false);
            existingServices.Should().Contain(testName);

            // verify can find
            ProvisioningServiceDescription foundInstance = await _provisioningClient.IotDpsResource
                .GetAsync(testName, testName)
                .ConfigureAwait(false);
            foundInstance.Should().NotBeNull();
            foundInstance.Name.Should().Be(testName);

            var attempts = Constants.ArmAttemptLimit;
            var hasSucceeded = false;
            while (attempts > 0 && !hasSucceeded)
            {
                try
                {
                    await _provisioningClient.IotDpsResource
                        .DeleteAsync(testName, testName)
                        .ConfigureAwait(false);
                    hasSucceeded = true;
                }
                catch
                {
                    attempts--;
                    await Task.Delay(Constants.ArmAttemptWaitMS).ConfigureAwait(false);
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
            string testName = "unitTestingDPSUpdateSku";
            Microsoft.Azure.Management.Resources.Models.ResourceGroup resourceGroup = await GetResourceGroupAsync(testName).ConfigureAwait(false);
            ProvisioningServiceDescription service = await GetServiceAsync(testName, testName).ConfigureAwait(false);
            
            //update capacity
            service.Sku.Capacity += 1;

            var attempts = Constants.ArmAttemptLimit;
            var success = false;
            while (attempts > 0 && !success)
            {
                try
                {
                    var updatedInstance = await _provisioningClient
                        .IotDpsResource.CreateOrUpdateAsync(
                            resourceGroup.Name,
                            service.Name,
                            service)
                        .ConfigureAwait(false);
                    Assert.Equal(service.Sku.Capacity, updatedInstance.Sku.Capacity);
                    success = true;
                }
                catch
                {
                    // Let ARM finish
                    await Task.Delay(Constants.ArmAttemptWaitMS).ConfigureAwait(false);
                    attempts--;
                }
            }
        }

        [Fact(Skip = "Needs re-recording")]
        //[Fact]
        public async Task CreateFailure()
        {
            using var context = MockContext.Start(GetType());

            Initialize(context);
            var testName = "unitTestingDPSCreateUpdateInvalidName";
            await GetResourceGroupAsync(testName).ConfigureAwait(false);


            // try to create a DPS service
            var createServiceDescription = new ProvisioningServiceDescription(
                Constants.DefaultLocation,
                new IotDpsPropertiesDescription(),
                new IotDpsSkuInfo(Constants.DefaultSku.Name,
                    Constants.DefaultSku.Tier,
                    Constants.DefaultSku.Capacity));

            var badCall = new Func<Task<ProvisioningServiceDescription>>(
                () =>
                    _provisioningClient.IotDpsResource.CreateOrUpdateAsync(
                    testName,
                    $"1ñ1{testName}!!!", // We dont't allow most punctuation, leading numbers, etc
                    createServiceDescription));

            await badCall.Should().ThrowAsync<ErrorDetailsException>();
        }
    }
}
