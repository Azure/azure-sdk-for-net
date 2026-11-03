// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.DataBox.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmDataBoxModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.DataboxJobSecrets"/>. </summary>
        /// <param name="dataCenterAccessSecurityCode"> Dc Access Security Code for Customer Managed Shipping. </param>
        /// <param name="error"> Error while fetching the secrets. </param>
        /// <param name="podSecrets"> Contains the list of secret objects for a job. </param>
        /// <returns> A new <see cref="Models.DataboxJobSecrets"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This class is method and will be removed in a future release.Please use DataBoxJobSecrets instead.", false)]
        public static DataboxJobSecrets DataboxJobSecrets(DataCenterAccessSecurityCode dataCenterAccessSecurityCode, ResponseError error, IEnumerable<DataBoxSecret> podSecrets)
        {
            podSecrets ??= new List<DataBoxSecret>();

            return new DataboxJobSecrets(DataBoxOrderType.DataBox, dataCenterAccessSecurityCode, error, serializedAdditionalRawData: null, podSecrets?.ToList());
        }

        /// <summary> Initializes a new instance of <see cref="Models.ScheduleAvailabilityContent"/>. </summary>
        /// <param name="storageLocation"> Location for data transfer. For locations check: https://management.azure.com/subscriptions/SUBSCRIPTIONID/locations?api-version=2018-01-01. </param>
        /// <param name="country"> Country in which storage location should be supported. </param>
        /// <returns> A new <see cref="Models.ScheduleAvailabilityContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ScheduleAvailabilityContent ScheduleAvailabilityContent(AzureLocation storageLocation, string country)
            => ScheduleAvailabilityContent(storageLocation, country, null);
        /// <summary> Initializes a new instance of <see cref="Models.MitigateJobContent"/>. </summary>
        /// <param name="customerResolutionCode"> Resolution code for the job. </param>
        /// <param name="serialNumberCustomerResolutionMap"> Serial number and the customer resolution code corresponding to each serial number. </param>
        /// <returns> A new <see cref="Models.MitigateJobContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static MitigateJobContent MitigateJobContent(CustomerResolutionCode customerResolutionCode, IDictionary<string, CustomerResolutionCode> serialNumberCustomerResolutionMap)
        {
            serialNumberCustomerResolutionMap ??= new Dictionary<string, CustomerResolutionCode>();

            return new MitigateJobContent(customerResolutionCode, serialNumberCustomerResolutionMap, additionalBinaryDataProperties: null);
        }
        /// <summary> Initializes a new instance of <see cref="Models.DataBoxBasicJobDetails"/>. </summary>
        /// <param name="jobStages"> List of stages that run in the job. </param>
        /// <param name="contactDetails"> Contact details for notification and shipping. </param>
        /// <param name="shippingAddress"> Shipping address of the customer. </param>
        /// <param name="deliveryPackage"> Delivery package shipping details. </param>
        /// <param name="returnPackage"> Return package shipping details. </param>
        /// <param name="dataImportDetails"> Details of the data to be imported into azure. </param>
        /// <param name="dataExportDetails"> Details of the data to be exported from azure. </param>
        /// <param name="preferences"> Preferences for the order. </param>
        /// <param name="reverseShippingDetails"> Optional Reverse Shipping details for order. </param>
        /// <param name="copyLogDetails"> List of copy log details. </param>
        /// <param name="reverseShipmentLabelSasKey"> Shared access key to download the return shipment label. </param>
        /// <param name="chainOfCustodySasKey"> Shared access key to download the chain of custody logs. </param>
        /// <param name="deviceErasureDetails"> Holds device data erasure details. </param>
        /// <param name="keyEncryptionKey"> Details about which key encryption type is being used. </param>
        /// <param name="expectedDataSizeInTerabytes"> The expected size of the data, which needs to be transferred in this job, in terabytes. </param>
        /// <param name="actions"> Available actions on the job. </param>
        /// <param name="lastMitigationActionOnJob"> Last mitigation action performed on the job. </param>
        /// <param name="dataCenterAddress"> Datacenter address to ship to, for the given sku and storage location. </param>
        /// <param name="dataCenterCode"> DataCenter code. </param>
        /// <returns> A new <see cref="Models.DataBoxBasicJobDetails"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DataBoxBasicJobDetails DataBoxBasicJobDetails(
            IEnumerable<DataBoxJobStage> jobStages,
            DataBoxContactDetails contactDetails,
            DataBoxShippingAddress shippingAddress,
            PackageShippingDetails deliveryPackage,
            PackageShippingDetails returnPackage,
            IEnumerable<DataImportDetails> dataImportDetails,
            IEnumerable<DataExportDetails> dataExportDetails,
            DataBoxOrderPreferences preferences,
            ReverseShippingDetails reverseShippingDetails,
            IEnumerable<CopyLogDetails> copyLogDetails,
            string reverseShipmentLabelSasKey,
            string chainOfCustodySasKey,
            DeviceErasureDetails deviceErasureDetails,
            DataBoxKeyEncryptionKey keyEncryptionKey,
            int? expectedDataSizeInTerabytes,
            IEnumerable<CustomerResolutionCode> actions,
            LastMitigationActionOnJob lastMitigationActionOnJob,
            DataCenterAddressResult dataCenterAddress,
            DataCenterCode? dataCenterCode)
            => DataBoxBasicJobDetails(
                jobStages,
                contactDetails,
                shippingAddress,
                deliveryPackage,
                returnPackage,
                dataImportDetails,
                dataExportDetails,
                jobDetailsType: null,
                preferences,
                reverseShippingDetails,
                copyLogDetails,
                reverseShipmentLabelSasKey,
                chainOfCustodySasKey,
                deviceErasureDetails,
                keyEncryptionKey,
                expectedDataSizeInTerabytes,
                actions,
                lastMitigationActionOnJob,
                dataCenterAddress,
                dataCenterCode);
        /// <summary> Initializes a new instance of <see cref="Models.DataBoxValidationInputResult"/>. </summary>
        /// <param name="error"> Error code and message of validation response. </param>
        /// <returns> A new <see cref="Models.DataBoxValidationInputResult"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DataBoxValidationInputResult DataBoxValidationInputResult(ResponseError error)
            => DataBoxValidationInputResult(validationType: null, error);
        /// <summary> Initializes a new instance of <see cref="Models.DataCenterAddressResult"/>. </summary>
        /// <param name="supportedCarriersForReturnShipment"> List of supported carriers for return shipment. </param>
        /// <param name="dataCenterAzureLocation"> Azure Location where the Data Center serves primarily. </param>
        /// <returns> A new <see cref="Models.DataCenterAddressResult"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DataCenterAddressResult DataCenterAddressResult(IEnumerable<string> supportedCarriersForReturnShipment, AzureLocation? dataCenterAzureLocation)
            => DataCenterAddressResult(datacenterAddressType: null, supportedCarriersForReturnShipment, dataCenterAzureLocation);
        /// <summary> Initializes a new instance of <see cref="Models.JobSecrets"/>. </summary>
        /// <param name="dataCenterAccessSecurityCode"> Dc Access Security Code for Customer Managed Shipping. </param>
        /// <param name="error"> Error while fetching the secrets. </param>
        /// <returns> A new <see cref="Models.JobSecrets"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static JobSecrets JobSecrets(DataCenterAccessSecurityCode dataCenterAccessSecurityCode, ResponseError error)
            => JobSecrets(jobSecretsType: null, dataCenterAccessSecurityCode, error);
        /// <summary> Initializes a new instance of <see cref="Models.ScheduleAvailabilityContent"/>. </summary>
        /// <param name="storageLocation"> Location for data transfer. For locations check: https://management.azure.com/subscriptions/SUBSCRIPTIONID/locations?api-version=2018-01-01. </param>
        /// <param name="country"> Country in which storage location should be supported. </param>
        /// <param name="model"> Device model. </param>
        /// <returns> A new <see cref="Models.ScheduleAvailabilityContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ScheduleAvailabilityContent ScheduleAvailabilityContent(AzureLocation storageLocation, string country, DeviceModelName? model)
            => ScheduleAvailabilityContent(storageLocation, skuName: null, country, model);
    }
}
