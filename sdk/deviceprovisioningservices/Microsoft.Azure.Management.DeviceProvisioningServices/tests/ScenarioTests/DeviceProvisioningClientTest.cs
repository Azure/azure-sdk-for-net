using System;
using System.Linq;
using Microsoft.Azure.Management.DeviceProvisioningServices;
using Microsoft.Azure.Management.DeviceProvisioningServices.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using DeviceProvisioningServices.Tests.Helpers;
using Xunit;

namespace DeviceProvisioningServices.Tests.ScenarioTests
{
    public class DeviceProvisioningClientTest : DeviceProvisioningTestBase
    {
        [Fact]
        public void CreateAndDelete()
        {
            using (var context = MockContext.Start(this.GetType()))
            {

                this.Initialize(context);
                var testName = "unitTestingDPSCreateUpdate";
                this.GetResourceGroup(testName);


                var availabilityInfo =
                    this.provisioningClient.IotDpsResource.CheckProvisioningServiceNameAvailability(new OperationInputs(testName));

                if (!availabilityInfo.NameAvailable ?? false)
                {
                    //it exists, so test the delete
                    this.provisioningClient.IotDpsResource.Delete(testName, testName);

                    //check the name is now available
                    availabilityInfo =
                        this.provisioningClient.IotDpsResource.CheckProvisioningServiceNameAvailability(new OperationInputs(testName));
                    Assert.True(availabilityInfo.NameAvailable);
                }

                //try to create a DPS service
                var createServiceDescription = new ProvisioningServiceDescription(Constants.DefaultLocation,
                    new IotDpsPropertiesDescription(),
                    new IotDpsSkuInfo(Constants.DefaultSku.Name,
                        Constants.DefaultSku.Tier,
                        Constants.DefaultSku.Capacity
                    ));

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
                Assert.Contains(existingServices, x => x.Name == testName);

                //verify can find
                var foundInstance = this.provisioningClient.IotDpsResource.Get(testName, testName);
                Assert.NotNull(foundInstance);
                Assert.Equal(testName, foundInstance.Name);

                var attempts = Constants.ArmAttemptLimit;
                var success = false;
                while (attempts > 0 && !success)
                {
                    try
                    {

                        this.provisioningClient.IotDpsResource.Delete(testName, testName);
                        success = true;
                    }
                    catch
                    {
                        attempts--;
                        System.Threading.Thread.Sleep(Constants.ArmAttemptWaitMS);
                    }
                }
                existingServices =
                    this.provisioningClient.IotDpsResource.ListByResourceGroup(testName);

                //As long as it is gone or deleting, we're good
                Assert.DoesNotContain(existingServices, x => x.Name == testName && x.Properties.State != "Deleting");
            }
        }

        [Fact]
        public void UpdateSku()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                this.Initialize(context);
                string testName = "unitTestingDPSUpdateSku";
                var resourceGroup = this.GetResourceGroup(testName);
                var service = this.GetService(testName, testName);
                //update capacity
                service.Sku.Capacity += 1;
                var attempts = Constants.ArmAttemptLimit;
                var success = false;
                while (attempts > 0 && !success)
                {
                    try
                    {
                        var updatedInstance =
                   this.provisioningClient.IotDpsResource.CreateOrUpdate(resourceGroup.Name, service.Name,
                       service);
                        Assert.Equal(service.Sku.Capacity, updatedInstance.Sku.Capacity);
                        success = true;
                    }
                    catch
                    {
                        //Let ARM finish
                        System.Threading.Thread.Sleep(Constants.ArmAttemptWaitMS);
                        attempts--;
                    }
                }



            }
        }
        [Fact(Skip = "Needs re-recording")]
        //[Fact]
        public void CreateFailure()
        {
            using (var context = MockContext.Start(this.GetType()))
            {

                this.Initialize(context);
                var testName = "unitTestingDPSCreateUpdateInvalidName";
                this.GetResourceGroup(testName);


                //try to create a DPS service
                var createServiceDescription = new ProvisioningServiceDescription(Constants.DefaultLocation,
                    new IotDpsPropertiesDescription(),
                    new IotDpsSkuInfo(Constants.DefaultSku.Name,
                        Constants.DefaultSku.Tier,
                        Constants.DefaultSku.Capacity
                    ));

                var badCall = new Func<ProvisioningServiceDescription>(() => this.provisioningClient.IotDpsResource.CreateOrUpdate(
                    testName,
                    $"1ñ1{testName}!!!", //We dont't allow most punctuation, leading numbers, etc
                    createServiceDescription));

                Assert.Throws<ErrorDetailsException>(badCall);
            }
        }
    }
}
