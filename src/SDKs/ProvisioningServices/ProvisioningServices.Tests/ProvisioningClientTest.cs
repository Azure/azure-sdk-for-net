using System.Linq;
using Microsoft.Azure.Management.IotHub;
using Microsoft.Azure.Management.IotHub.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace ProvisioningServices.Tests
{
    public class ProvisioningClientTest : DeviceProvisioningTestBase
    {
        [Fact]
        public void DeviceProvisioningCreateOrUpdate()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                this.Initialize(context);
                
                var nameAvailabilityInputs = new OperationInputs(Constants.DefaultProvisioningServiceName);
                var availabilityInfo =
                    this.provisioningClient.IotDpsResource.CheckNameAvailability(nameAvailabilityInputs);

                if (!availabilityInfo.NameAvailable ?? false)
                {
                    //it exists, so test the delete
                    this.provisioningClient.IotDpsResource.Delete(Constants.DefaultProvisioningServiceName, Constants.DefaultResourceGroupName);

                    //check the name is now available
                    availabilityInfo =
                        this.provisioningClient.IotDpsResource.CheckNameAvailability(nameAvailabilityInputs);
                    Assert.True(availabilityInfo.NameAvailable);
                }

                //try to create a DPS service
                var createServiceDescription = new ProvisioningServiceDescription(Constants.DefaultLocation, new IotDpsSkuInfo { Name = Constants.DefaultSku.Name, Capacity = Constants.DefaultSku.Capacity });
                var dpsInstance = this.provisioningClient.IotDpsResource.CreateOrUpdate(Constants.DefaultResourceGroupName,
                    Constants.DefaultProvisioningServiceName, createServiceDescription);

                Assert.NotNull(dpsInstance);
                Assert.Equal(Constants.DefaultSku.Name, dpsInstance.Sku.Name);
                Assert.Equal(Constants.DefaultProvisioningServiceName, dpsInstance.Name);

                var existingServices =
                    this.provisioningClient.IotDpsResource.ListByResourceGroup(Constants.DefaultResourceGroupName);
                Assert.Contains(existingServices, x => x.Name == Constants.DefaultProvisioningServiceName);

                //update capacity
                dpsInstance.Sku.Capacity += 1;

                var updatedInstance =
                    this.provisioningClient.IotDpsResource.CreateOrUpdate(resourceGroup.Name, dpsInstance.Name,
                        dpsInstance);

                Assert.Equal(dpsInstance.Sku.Capacity, updatedInstance.Sku.Capacity);

                DeviceProvisioningSharedAccessKeys();
                DeviceProvisioningCertificates();
            }
        }

        
        private void DeviceProvisioningSharedAccessKeys()
        {
            //verify owner has been created
            var ownerKey = this.provisioningClient.IotDpsResource.GetKeysForKeyName(Constants.DefaultResourceGroupName,
                Constants.AccessKeyName, Constants.DefaultResourceGroupName);
            Assert.Equal(Constants.AccessKeyName, ownerKey.KeyName);
        }

        private void DeviceProvisioningCertificates()
        {
            //get certificates list
            var certificateList = this.provisioningClient.DpsCertificates.List(Constants.DefaultResourceGroupName,
                Constants.DefaultProvisioningServiceName);

            if (certificateList.Value.Any(x => x.Name == Constants.Certificate.Name))
            {
                this.provisioningClient.DpsCertificate.Delete(Constants.DefaultResourceGroupName,
                    Constants.DefaultProvisioningServiceName, Constants.Certificate.Name);
                certificateList =
                    this.provisioningClient.DpsCertificates.List(Constants.DefaultResourceGroupName,
                        Constants.DefaultProvisioningServiceName);
                Assert.DoesNotContain(certificateList.Value, x => x.Name == Constants.Certificate.Name);
            }

            //add a cert
            this.provisioningClient.DpsCertificate.CreateOrUpdate(Constants.DefaultResourceGroupName,
                Constants.DefaultProvisioningServiceName, Constants.Certificate.Name,
                new CertificateBodyDescription(Constants.Certificate.Content));

            certificateList = this.provisioningClient.DpsCertificates.List(Constants.DefaultResourceGroupName,
                Constants.DefaultProvisioningServiceName);

            Assert.Contains(certificateList.Value, x => x.Name == Constants.Certificate.Name);

            //verify certificate details
            var certificateDetails = certificateList.Value.FirstOrDefault(x => x.Name == Constants.Certificate.Name);
            Assert.Equal(certificateDetails.Properties.Subject, Constants.Certificate.Subject);
            Assert.Equal(certificateDetails.Properties.Thumbprint, Constants.Certificate.Thumbprint);

            //delete certificate
            this.provisioningClient.DpsCertificate.Delete(Constants.DefaultResourceGroupName,
                Constants.DefaultProvisioningServiceName, Constants.Certificate.Name);
            Assert.DoesNotContain(certificateList.Value, x => x.Name == Constants.Certificate.Name);
        }
    }
}