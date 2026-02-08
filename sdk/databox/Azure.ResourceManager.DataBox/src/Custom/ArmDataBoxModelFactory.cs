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

        /// <summary> Initializes a new instance of <see cref="Models.CreateOrderLimitForSubscriptionValidationContent"/>. </summary>
        /// <param name="deviceType"> Device type to be used for the job. </param>
        /// <returns> A new <see cref="Models.CreateOrderLimitForSubscriptionValidationContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CreateOrderLimitForSubscriptionValidationContent CreateOrderLimitForSubscriptionValidationContent(DataBoxSkuName deviceType)
            => CreateOrderLimitForSubscriptionValidationContent(deviceType, null);

        /// <summary> Initializes a new instance of <see cref="Models.DataBoxScheduleAvailabilityContent"/>. </summary>
        /// <param name="storageLocation"> Location for data transfer. For locations check: https://management.azure.com/subscriptions/SUBSCRIPTIONID/locations?api-version=2018-01-01. </param>
        /// <param name="country"> Country in which storage location should be supported. </param>
        /// <returns> A new <see cref="Models.DataBoxScheduleAvailabilityContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DataBoxScheduleAvailabilityContent DataBoxScheduleAvailabilityContent(AzureLocation storageLocation, string country)
            => DataBoxScheduleAvailabilityContent(storageLocation, country, null);

        /// <summary> Initializes a new instance of <see cref="Models.DataTransferDetailsValidationContent"/>. </summary>
        /// <param name="dataExportDetails"> List of DataTransfer details to be used to export data from azure. </param>
        /// <param name="dataImportDetails"> List of DataTransfer details to be used to import data to azure. </param>
        /// <param name="deviceType"> Device type. </param>
        /// <param name="transferType"> Type of the transfer. </param>
        /// <returns> A new <see cref="Models.DataTransferDetailsValidationContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DataTransferDetailsValidationContent DataTransferDetailsValidationContent(IEnumerable<DataExportDetails> dataExportDetails, IEnumerable<DataImportDetails> dataImportDetails, DataBoxSkuName deviceType, DataBoxJobTransferType transferType)
            => DataTransferDetailsValidationContent(dataExportDetails, dataImportDetails, deviceType, transferType, null);

        /// <summary> Initializes a new instance of <see cref="Models.DiskScheduleAvailabilityContent"/>. </summary>
        /// <param name="storageLocation"> Location for data transfer. For locations check: https://management.azure.com/subscriptions/SUBSCRIPTIONID/locations?api-version=2018-01-01. </param>
        /// <param name="country"> Country in which storage location should be supported. </param>
        /// <param name="expectedDataSizeInTerabytes"> The expected size of the data, which needs to be transferred in this job, in terabytes. </param>
        /// <returns> A new <see cref="Models.DiskScheduleAvailabilityContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DiskScheduleAvailabilityContent DiskScheduleAvailabilityContent(AzureLocation storageLocation, string country, int expectedDataSizeInTerabytes)
            => DiskScheduleAvailabilityContent(storageLocation, country, null, expectedDataSizeInTerabytes);

        /// <summary> Initializes a new instance of <see cref="Models.HeavyScheduleAvailabilityContent"/>. </summary>
        /// <param name="storageLocation"> Location for data transfer. For locations check: https://management.azure.com/subscriptions/SUBSCRIPTIONID/locations?api-version=2018-01-01. </param>
        /// <param name="country"> Country in which storage location should be supported. </param>
        /// <returns> A new <see cref="Models.HeavyScheduleAvailabilityContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static HeavyScheduleAvailabilityContent HeavyScheduleAvailabilityContent(AzureLocation storageLocation, string country)
            => HeavyScheduleAvailabilityContent(storageLocation, country, null);

        /// <summary> Initializes a new instance of <see cref="Models.PreferencesValidationContent"/>. </summary>
        /// <param name="preference"> Preference of transport and data center. </param>
        /// <param name="deviceType"> Device type to be used for the job. </param>
        /// <returns> A new <see cref="Models.PreferencesValidationContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PreferencesValidationContent PreferencesValidationContent(DataBoxOrderPreferences preference, DataBoxSkuName deviceType)
            => PreferencesValidationContent(preference, deviceType, null);

        /// <summary> Initializes a new instance of <see cref="Models.ScheduleAvailabilityContent"/>. </summary>
        /// <param name="storageLocation"> Location for data transfer. For locations check: https://management.azure.com/subscriptions/SUBSCRIPTIONID/locations?api-version=2018-01-01. </param>
        /// <param name="country"> Country in which storage location should be supported. </param>
        /// <returns> A new <see cref="Models.ScheduleAvailabilityContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ScheduleAvailabilityContent ScheduleAvailabilityContent(AzureLocation storageLocation, string country)
            => ScheduleAvailabilityContent(storageLocation, country, null);

        /// <summary> Initializes a new instance of <see cref="Models.DataBoxValidateAddressContent"/>. </summary>
        /// <param name="shippingAddress"> Shipping address of the customer. </param>
        /// <param name="deviceType"> Device type to be used for the job. </param>
        /// <param name="transportPreferences"> Preferences related to the shipment logistics of the sku. </param>
        /// <returns> A new <see cref="Models.DataBoxValidateAddressContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DataBoxValidateAddressContent DataBoxValidateAddressContent(DataBoxShippingAddress shippingAddress, DataBoxSkuName deviceType, TransportPreferences transportPreferences)
            => DataBoxValidateAddressContent(shippingAddress, deviceType, transportPreferences, null);

        /// <summary> Initializes a new instance of <see cref="Models.SkuAvailabilityValidationContent"/>. </summary>
        /// <param name="deviceType"> Device type to be used for the job. </param>
        /// <param name="transferType"> Type of the transfer. </param>
        /// <param name="country"> ISO country code. Country for hardware shipment. For codes check: https://en.wikipedia.org/wiki/ISO_3166-1_alpha-2#Officially_assigned_code_elements. </param>
        /// <param name="location"> Location for data transfer. For locations check: https://management.azure.com/subscriptions/SUBSCRIPTIONID/locations?api-version=2018-01-01. </param>
        /// <returns> A new <see cref="Models.SkuAvailabilityValidationContent"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SkuAvailabilityValidationContent SkuAvailabilityValidationContent(DataBoxSkuName deviceType, DataBoxJobTransferType transferType, string country, AzureLocation location)
            => SkuAvailabilityValidationContent(deviceType, transferType, country, location, null);

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

        /// <summary> Initializes a new instance of <see cref="DataBox.DataBoxJobData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="transferType"> Type of the data transfer. </param>
        /// <param name="isCancellable"> Describes whether the job is cancellable or not. </param>
        /// <param name="isDeletable"> Describes whether the job is deletable or not. </param>
        /// <param name="isShippingAddressEditable"> Describes whether the shipping address is editable or not. </param>
        /// <param name="reverseShippingDetailsUpdate"> The Editable status for Reverse Shipping Address and Contact Info. </param>
        /// <param name="reverseTransportPreferenceUpdate"> The Editable status for Reverse Transport preferences. </param>
        /// <param name="isPrepareToShipEnabled"> Is Prepare To Ship Enabled on this job. </param>
        /// <param name="status"> Name of the stage which is in progress. </param>
        /// <param name="startOn"> Time at which the job was started in UTC ISO 8601 format. </param>
        /// <param name="error"> Top level error for the job. </param>
        /// <param name="details">
        /// Details of a job run. This field will only be sent for expand details filter.
        ///             Please note  is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        ///             The available derived classes include , ,  and .
        /// </param>
        /// <param name="cancellationReason"> Reason for cancellation. </param>
        /// <param name="deliveryType"> Delivery type of Job. </param>
        /// <param name="deliveryInfoScheduledOn"> Delivery Info of Job. </param>
        /// <param name="isCancellableWithoutFee"> Flag to indicate cancellation of scheduled job. </param>
        /// <param name="sku"> The sku type. </param>
        /// <param name="identity"> Msi identity of the resource. </param>
        /// <returns> A new <see cref="DataBox.DataBoxJobData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static DataBoxJobData DataBoxJobData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, DataBoxJobTransferType transferType, bool? isCancellable, bool? isDeletable, bool? isShippingAddressEditable, ReverseShippingDetailsEditStatus? reverseShippingDetailsUpdate, ReverseTransportPreferenceEditStatus? reverseTransportPreferenceUpdate, bool? isPrepareToShipEnabled, DataBoxStageName? status, DateTimeOffset? startOn, ResponseError error, DataBoxBasicJobDetails details, string cancellationReason, JobDeliveryType? deliveryType, DateTimeOffset? deliveryInfoScheduledOn, bool? isCancellableWithoutFee, DataBoxSku sku, ManagedServiceIdentity identity)
        {
            return DataBoxJobData(id, name, resourceType, systemData, tags, location, transferType, isCancellable, isDeletable, isShippingAddressEditable, reverseShippingDetailsUpdate, reverseTransportPreferenceUpdate, isPrepareToShipEnabled, status, delayedStage:null, startOn, error, details, cancellationReason, deliveryType, deliveryInfoScheduledOn, isCancellableWithoutFee, areAllDevicesLost:null, sku, identity);
        }
    }
}
