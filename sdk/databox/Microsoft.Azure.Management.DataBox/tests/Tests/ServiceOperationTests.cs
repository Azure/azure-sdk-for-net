using DataBox.Tests.Helpers;
using Microsoft.Azure.Management.DataBox;
using Microsoft.Azure.Management.DataBox.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
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
                var skus = this.Client.Service.ListAvailableSkusByResourceGroup(TestConstants.DefaultResourceGroupName, TestConstants.DefaultResourceLocation, availableSkus);
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
        [Obsolete]
        public void TestValidateAddress()
        {
            var shippingAddress = GetDefaultShippingAddress();

            var validateAddress = new ValidateAddress()
            {
                ShippingAddress = shippingAddress,
                DeviceType = SkuName.DataBox
            };
            var addressValidation = this.Client.Service.ValidateAddressMethod(TestConstants.DefaultResourceLocation,
                validateAddress);

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

        [Fact]
        public void TestValidateInputs()
        {
            var destinationAccountsList = GetDestinationAccountsList();
            var dataImportDetails = new List<DataImportDetails>();
            dataImportDetails.Add(new DataImportDetails(destinationAccountsList.FirstOrDefault()));
            var validateInput = new CreateJobValidations
            {
                IndividualRequestDetails = new List<ValidationInputRequest>() {
                        new DataTransferDetailsValidationRequest()
                        {
                            DataImportDetails = dataImportDetails
                        },
                        new ValidateAddress()
                        {
                            ShippingAddress = GetDefaultShippingAddress(),
                            DeviceType = SkuName.DataBox,
                            TransportPreferences = new TransportPreferences
                            {
                                PreferredShipmentType = TransportShipmentTypes.MicrosoftManaged
                            }
                        },
                        new SubscriptionIsAllowedToCreateJobValidationRequest()
                        {
                        },
                        new SkuAvailabilityValidationRequest()
                        {
                            DeviceType = SkuName.DataBox,
                            Country = "US",
                            Location = "westus"
                        },
                        new CreateOrderLimitForSubscriptionValidationRequest()
                        {
                            DeviceType = SkuName.DataBox
                        },
                        new PreferencesValidationRequest()
                        {
                            DeviceType = SkuName.DataBox,
                            Preference = new Preferences
                            {
                                TransportPreferences = new TransportPreferences
                                {
                                    PreferredShipmentType = TransportShipmentTypes.MicrosoftManaged
                                }
                            }
                        }
                }
            };
            var validateResponse = this.Client.Service.ValidateInputs(TestConstants.DefaultResourceLocation, validateInput);
            Assert.True(validateResponse != null, "Call for ValidateInputs is successful.");
            Assert.True(validateResponse.Status == OverallValidationStatus.AllValidToProceed);
            ValidateIndividualValidateResponse(validateResponse.IndividualResponseDetails);
        }

        [Fact]
        public void TestValidateInputsByResourceGroup()
        {
            var resourceGroupName = TestUtilities.GenerateName("SdkRg");
            var destinationAccountsList = GetDestinationAccountsList();
            var dataImportDetails = new List<DataImportDetails>();
            dataImportDetails.Add(new DataImportDetails(destinationAccountsList.FirstOrDefault()));
            var validateInput = new CreateJobValidations
            {
                IndividualRequestDetails = new List<ValidationInputRequest>() {
                        new DataTransferDetailsValidationRequest()
                        {
                            DataImportDetails = dataImportDetails
                        },
                        new ValidateAddress()
                        {
                            ShippingAddress = GetDefaultShippingAddress(),
                            DeviceType = SkuName.DataBox,
                            TransportPreferences = new TransportPreferences
                            {
                                PreferredShipmentType = TransportShipmentTypes.MicrosoftManaged
                            }
                        },
                        new SubscriptionIsAllowedToCreateJobValidationRequest()
                        {
                        },
                        new SkuAvailabilityValidationRequest()
                        {
                            DeviceType = SkuName.DataBox,
                            Country = "US",
                            Location = "westus"
                        },
                        new CreateOrderLimitForSubscriptionValidationRequest()
                        {
                            DeviceType = SkuName.DataBox
                        },
                        new PreferencesValidationRequest()
                        {
                            DeviceType = SkuName.DataBox,
                            Preference = new Preferences
                            {
                                TransportPreferences = new TransportPreferences
                                {
                                    PreferredShipmentType = TransportShipmentTypes.MicrosoftManaged
                                }
                            }
                        }
                }
            };
            var validateResponse = this.Client.Service.ValidateInputsByResourceGroup(resourceGroupName, TestConstants.DefaultResourceLocation, validateInput);
            Assert.True(validateResponse != null, "Call for ValidateInputs is successful.");
            Assert.True(validateResponse.Status == OverallValidationStatus.AllValidToProceed);
            ValidateIndividualValidateResponse(validateResponse.IndividualResponseDetails);
        }

        [Fact]
        public void TestValidateInputsSpecificToExport()
        {
            var sourceAccountsList = GetSourceAccountsList();
            var dataExportDetails = new List<DataExportDetails>();

            TransferConfiguration transferCofiguration = new TransferConfiguration
            {
                TransferConfigurationType = TransferConfigurationType.TransferAll,
                TransferAllDetails = new TransferConfigurationTransferAllDetails
                {
                    Include = new TransferAllDetails
                    {
                        DataAccountType = DataAccountType.StorageAccount,
                        TransferAllBlobs = true,
                        TransferAllFiles = true
                    }
                }
            };
            dataExportDetails.Add(new DataExportDetails(transferCofiguration, sourceAccountsList.FirstOrDefault()));
            var validateInput = new CreateJobValidations
            {
                IndividualRequestDetails = new List<ValidationInputRequest>() {
                        new DataTransferDetailsValidationRequest()
                        {
                            TransferType = TransferType.ExportFromAzure,
                            DataExportDetails = dataExportDetails
                        },

                        new SkuAvailabilityValidationRequest()
                        {
                            DeviceType = SkuName.DataBox,
                            TransferType = TransferType.ExportFromAzure,
                            Country = "US",
                            Location = "westus"
                        },

                }
            };
            var validateResponse = this.Client.Service.ValidateInputs(TestConstants.DefaultResourceLocation, validateInput);
            Assert.True(validateResponse != null, "Call for ValidateInputs is successful.");
            Assert.True(validateResponse.Status == OverallValidationStatus.AllValidToProceed);
            ValidateIndividualValidateResponse(validateResponse.IndividualResponseDetails);
        }

        [Fact]
        public void TestValidateInputsSpecificToExportByResourceGroup()
        {
            var resourceGroupName = TestUtilities.GenerateName("SdkRg");
            var sourceAccountsList = GetSourceAccountsList();
            var dataExportDetails = new List<DataExportDetails>();

            TransferConfiguration transferCofiguration = new TransferConfiguration
            {
                TransferConfigurationType = TransferConfigurationType.TransferAll,
                TransferAllDetails = new TransferConfigurationTransferAllDetails
                {
                    Include = new TransferAllDetails
                    {
                        DataAccountType = DataAccountType.StorageAccount,
                        TransferAllBlobs = true,
                        TransferAllFiles = true
                    }
                }
            };
            dataExportDetails.Add(new DataExportDetails(transferCofiguration, sourceAccountsList.FirstOrDefault()));
            var validateInput = new CreateJobValidations
            {
                IndividualRequestDetails = new List<ValidationInputRequest>() {
                        new DataTransferDetailsValidationRequest()
                        {
                            TransferType = TransferType.ExportFromAzure,
                            DataExportDetails = dataExportDetails
                        },

                        new SkuAvailabilityValidationRequest()
                        {
                            DeviceType = SkuName.DataBox,
                            TransferType = TransferType.ExportFromAzure,
                            Country = "US",
                            Location = "westus"
                        },

                }
            };
            var validateResponse = this.Client.Service.ValidateInputsByResourceGroup(resourceGroupName, TestConstants.DefaultResourceLocation, validateInput);
            Assert.True(validateResponse != null, "Call for ValidateInputs is successful.");
            Assert.True(validateResponse.Status == OverallValidationStatus.AllValidToProceed);
            ValidateIndividualValidateResponse(validateResponse.IndividualResponseDetails);
        }

        [Fact]
        public void TestRegionConfiguration()
        {
            var regionConfigurationRequest = new RegionConfigurationRequest
            {
                TransportAvailabilityRequest = new TransportAvailabilityRequest
                {
                    SkuName = SkuName.DataBox
                }
            };

            var regionconfigurationResponse = this.Client.Service.RegionConfiguration(TestConstants.DefaultResourceLocation, transportAvailabilityRequest: regionConfigurationRequest.TransportAvailabilityRequest);
            Assert.True(regionconfigurationResponse != null, "Call for RegionConfiguration request is successful");
            //Assert.True(regionconfigurationResponse.ScheduleAvailabilityResponse.AvailableDates != null);
            Assert.True(regionconfigurationResponse.TransportAvailabilityResponse.TransportAvailabilityDetails != null);
        }

        [Fact]
        public void TestRegionConfigurationByResourceGroup()
        {
            var resourceGroupName = TestUtilities.GenerateName("SdkRg");

            var regionConfigurationRequest = new RegionConfigurationRequest
            {
                TransportAvailabilityRequest = new TransportAvailabilityRequest
                {
                    SkuName = SkuName.DataBox
                }
            };

            var regionconfigurationResponse = this.Client.Service.RegionConfigurationByResourceGroup(resourceGroupName, TestConstants.DefaultResourceLocation, transportAvailabilityRequest: regionConfigurationRequest.TransportAvailabilityRequest);
            Assert.True(regionconfigurationResponse != null, "Call for RegionConfiguration at resource group request is successful");
            Assert.True(regionconfigurationResponse.TransportAvailabilityResponse.TransportAvailabilityDetails != null);
        }
    }
}

