// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;

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

            return new MitigateJobContent(customerResolutionCode, serialNumberCustomerResolutionMap, serializedAdditionalRawData: null);
        }
    }
}
