using System;
using DataBox.Tests.Helpers;
using Microsoft.Azure.Management.DataBox;
using Microsoft.Azure.Management.DataBox.Models;
using Xunit;
using Xunit.Abstractions;

namespace DataBox.Tests.Tests
{
    public class ServiceOperationTests : DataBoxTestBase
    {
        public ServiceOperationTests(ITestOutputHelper testOutputHelper) : base(testOutputHelper)
        {
        }

        [Fact]
        public void TestAvailableSkus()
        {
            try
            {
                var availableSkus = new AvailableSkuRequest
                {
                    Country = "US",
                    Location = "westus"
                };
                var skus = this.Client.Service.ListAvailableSkus(TestConstants.DefaultResourceLocation, availableSkus);
                Assert.True(skus != null, "List call for available skus was not successful.");

                foreach (var sku in skus)
                {
                    sku.Validate();
                }
            }
            catch (Exception e)
            {
                Assert.Null(e);
            }

        }

        [Fact]
        public void TestValidateAddress()
        {
            var shippingAddress = GetDefaultShippingAddress();

            var validateAddress = new ValidateAddress
            {
                ShippingAddress = shippingAddress,
                DeviceType = DeviceType.Pod
            };
            var addressValidation = this.Client.Service.ValidateAddressMethod(TestConstants.DefaultResourceLocation, validateAddress);

            Assert.NotNull(addressValidation);
            Assert.NotNull(addressValidation.AlternateAddresses);
            Assert.NotNull(addressValidation.ValidationStatus);
            var validatedAddress = addressValidation.AlternateAddresses[0];
            Assert.Equal(AddressValidationStatus.Valid, addressValidation.ValidationStatus);
            Assert.Equal(shippingAddress.City, validatedAddress.City, true);
            Assert.Equal(shippingAddress.Country, validatedAddress.Country, true);
            Assert.Equal(shippingAddress.PostalCode, validatedAddress.PostalCode, true);
            Assert.Equal(shippingAddress.StateOrProvince, validatedAddress.StateOrProvince, true);
            Assert.Equal(shippingAddress.StreetAddress1, validatedAddress.StreetAddress1, true);
            Assert.Equal(shippingAddress.StreetAddress2, validatedAddress.StreetAddress2, true);
        }
    }
}
