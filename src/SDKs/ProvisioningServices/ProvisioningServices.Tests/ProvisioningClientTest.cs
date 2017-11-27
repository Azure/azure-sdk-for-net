using System;
using System.Linq;
using Microsoft.Azure.Management.ProvisioningServices;
using Microsoft.Azure.Management.ProvisioningServices.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ProvisioningServices.Tests
{
    public class ProvisioningClientTest : DeviceProvisioningTestBase
    {
        [Fact]
        public void DeviceProvisioningCreateAndDelete()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {

                this.Initialize(context);
                var testName = "unitTestingDPSCreateUpdate";
                this.GetResourceGroup(testName);


                var nameAvailabilityInputs = new OperationInputs(testName);
                var availabilityInfo =
                    this.provisioningClient.IotDpsResource.CheckNameAvailability(nameAvailabilityInputs);

                if (!availabilityInfo.NameAvailable ?? false)
                {
                    //it exists, so test the delete
                    this.provisioningClient.IotDpsResource.Delete(testName, testName);

                    //check the name is now available
                    availabilityInfo =
                        this.provisioningClient.IotDpsResource.CheckNameAvailability(nameAvailabilityInputs);
                    Assert.True(availabilityInfo.NameAvailable);
                }

                //try to create a DPS service
                var createServiceDescription = new ProvisioningServiceDescription(Constants.DefaultLocation,
                    new IotDpsSkuInfo(Constants.DefaultSku.Name,
                        Constants.DefaultSku.Tier,
                        Constants.DefaultSku.Capacity
                    ),
                    properties: new IotDpsPropertiesDescription());

                var dpsInstance = this.provisioningClient.IotDpsResource.CreateOrUpdate(
                    testName,
                    testName,
                    createServiceDescription);

                Assert.NotNull(dpsInstance);
                Assert.Equal(Constants.DefaultSku.Name, dpsInstance.Sku.Name);
                Assert.Equal(testName, dpsInstance.Name);

                //verify item exists in list by resource group
                var existingServices =
                    this.provisioningClient.IotDpsResource.ListByResourceGroup(testName);
                Assert.Contains(existingServices.Value, x => x.Name == testName);

                //verify can find
                var foundInstance = this.provisioningClient.IotDpsResource.Get(testName, testName);
                Assert.NotNull(foundInstance);
                Assert.Equal(testName, foundInstance.Name);

                this.provisioningClient.IotDpsResource.Delete(testName, testName);
                existingServices =
                    this.provisioningClient.IotDpsResource.ListByResourceGroup(testName);
                Assert.DoesNotContain(existingServices.Value, x => x.Name == testName);
            }
        }

        [Fact]
        public void DeviceProvisioningUpdateSku()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                this.Initialize(context);
                string testName = "unitTestingDPSUpdateSku";
                var resourceGroup = this.GetResourceGroup(testName);
                var service = this.GetService(testName, testName);
                //update capacity
                service.Sku.Capacity += 1;

                var updatedInstance =
                    this.provisioningClient.IotDpsResource.CreateOrUpdate(resourceGroup.Name, service.Name,
                        service);

                Assert.Equal(service.Sku.Capacity, updatedInstance.Sku.Capacity);
            }
        }
        [Fact]
        public void DeviceProvisioningCreateFailure()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {

                this.Initialize(context);
                var testName = "unitTestingDPSCreateUpdateInvalidName";
                this.GetResourceGroup(testName);


                //try to create a DPS service
                var createServiceDescription = new ProvisioningServiceDescription(Constants.DefaultLocation,
                    new IotDpsSkuInfo(Constants.DefaultSku.Name,
                        Constants.DefaultSku.Tier,
                        Constants.DefaultSku.Capacity
                    ),
                    properties: new IotDpsPropertiesDescription());

                var badCall = new Func<ProvisioningServiceDescription>(() => this.provisioningClient.IotDpsResource.CreateOrUpdate(
                    testName,
                    $"1ñ1{testName}!!!", //We dont't allow most punctuation, leading numbers, etc
                    createServiceDescription));

                Assert.Throws<ErrorDetailsException>(badCall);
            }
        }
    }
}