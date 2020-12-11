// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.Administration.Models
{
    /// <summary>
    /// Model factory that enables mocking for the Administration library.
    /// </summary>
    public static class AdministrationModelFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AcquiredPhoneNumber"/> class.
        /// </summary>
        /// <param name="phoneNumber"> String of the E.164 format of the phone number. </param>
        /// <param name="acquiredCapabilities"> The set of all acquired capabilities of the phone number. </param>
        /// <param name="availableCapabilities"> The set of all available capabilities that can be acquired for this phone number. </param>
        /// <returns>A new <see cref="AcquiredPhoneNumber"/> instance for mocking.</returns>
        public static AcquiredPhoneNumber AcquiredPhoneNumber(string phoneNumber, IEnumerable<PhoneNumberCapability> acquiredCapabilities, IEnumerable<PhoneNumberCapability> availableCapabilities)
            => new AcquiredPhoneNumber(phoneNumber, acquiredCapabilities, availableCapabilities);

        /// <summary>
        /// Initializes a new instance of the <see cref="AreaCodes"/> class.
        /// </summary>
        /// <param name="primaryAreaCodes"> Represents the list of primary area codes. </param>
        /// <param name="secondaryAreaCodes"> Represents the list of secondary area codes. </param>
        /// <param name="nextLink"> Represents the URL link to the next page. </param>
        /// <returns>A new <see cref="AreaCodes"/> instance for mocking.</returns>
        public static AreaCodes AreaCodes(IReadOnlyList<string> primaryAreaCodes, IReadOnlyList<string> secondaryAreaCodes, string nextLink)
            => new AreaCodes(primaryAreaCodes, secondaryAreaCodes, nextLink);

        /// <summary>
        /// Initializes a new instance of the <see cref="CarrierDetails"/> class.
        /// </summary>
        /// <param name="name"> Name of carrier details. </param>
        /// <param name="localizedName"> Display name of carrier details. </param>
        /// <returns>A new <see cref="CarrierDetails"/> instance for mocking.</returns>
        public static CarrierDetails CarrierDetails(string name, string localizedName)
            => new CarrierDetails(name, localizedName);

        /// <summary>
        /// Initializes a new instance of the <see cref="CommunicationUserToken"/> class.
        /// </summary>
        /// <param name="id"> id of communication user token. </param>
        /// <param name="token"> taken value of communication user token. </param>
        /// <param name="expiresOn"> expiry date time of communication user token. </param>
        /// <returns>A new <see cref="CommunicationUserToken"/> instance for mocking.</returns>
        public static CommunicationUserToken CommunicationUserToken(string id, string token, DateTimeOffset expiresOn)
            => new CommunicationUserToken(id, token, expiresOn);

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumberReservationOperation"/> class.
        /// </summary>
        /// <param name="client"> PhoneNumberAdministrationClient <see cref="PhoneNumberAdministrationClient"/> </param>
        /// <param name="reservationId"> The reservation id that was created. </param>
        /// <returns>A new <see cref="PhoneNumberReservationOperation"/> instance for mocking.</returns>
        public static PhoneNumberReservationOperation PhoneNumberReservationOperation(PhoneNumberAdministrationClient client, string reservationId)
            => new PhoneNumberReservationOperation(client, reservationId);

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationOptions"/> class.
        /// </summary>
        /// <param name="labelId"> The label id of the location. </param>
        /// <param name="labelName"> The display name of the location. </param>
        /// <param name="options"> The underlying location option details. </param>
        /// <returns>A new <see cref="LocationOptions"/> instance for mocking.</returns>
        public static LocationOptions LocationOptions(string labelId, string labelName, IList<LocationOptionsDetails> options)
            => new LocationOptions(labelId, labelName, options);

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationOptionsDetails"/> class.
        /// </summary>
        /// <param name="name"> The name of the location options. </param>
        /// <param name="value"> The abbreviated name of the location options. </param>
        /// <param name="locationOptions"> The underlying location options. </param>
        /// <returns>A new <see cref="LocationOptionsDetails"/> instance for mocking.</returns>
        public static LocationOptionsDetails LocationOptionsDetails(string name, string value, IList<LocationOptions> locationOptions)
            => new LocationOptionsDetails(name, value, locationOptions);

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationOptionsResponse"/> class.
        /// </summary>
        /// <param name="locationOptions"> Represents a location options. </param>
        /// <returns>A new <see cref="LocationOptionsResponse"/> instance for mocking.</returns>
        public static LocationOptionsResponse LocationOptionsResponse(LocationOptions locationOptions)
            => new LocationOptionsResponse(locationOptions);

        /// <summary>
        /// Initializes a new instance of the <see cref="NumberConfigurationResponse"/> class.
        /// </summary>
        /// <param name="pstnConfiguration"> Definition for pstn number configuration. </param>
        /// <returns>A new <see cref="NumberConfigurationResponse"/> instance for mocking.</returns>
        public static NumberConfigurationResponse NumberConfigurationResponse(PstnConfiguration pstnConfiguration)
            => new NumberConfigurationResponse(pstnConfiguration);

        /// <summary>
        /// Initializes a new instance of the <see cref="NumberUpdateCapabilities"/> class.
        /// </summary>
        /// <param name="add"> Capabilities to be added to a phone number. </param>
        /// <param name="remove"> Capabilities to be removed from a phone number. </param>
        /// <returns>A new <see cref="NumberUpdateCapabilities"/> instance for mocking.</returns>
        public static NumberUpdateCapabilities NumberUpdateCapabilities(IList<PhoneNumberCapability> @add, IList<PhoneNumberCapability> @remove)
            => new NumberUpdateCapabilities(@add, @remove);

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumberCountry"/> class.
        /// </summary>
        /// <param name="localizedName"> Represents the name of the country. </param>
        /// <param name="countryCode"> Represents the abbreviated name of the country. </param>
        /// <returns>A new <see cref="PhoneNumberCountry"/> instance for mocking.</returns>
        public static PhoneNumberCountry PhoneNumberCountry(string localizedName, string countryCode)
            => new PhoneNumberCountry(localizedName, countryCode);

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumberEntity"/> class.
        /// </summary>
        /// <param name="id"> The id of the entity. It is the search id of a search. It is the release id of a release. </param>
        /// <param name="createdAt"> Date and time the entity is created. </param>
        /// <param name="displayName"> Name of the entity. </param>
        /// <param name="quantity"> Quantity of requested phone numbers in the entity. </param>
        /// <param name="quantityObtained"> Quantity of acquired phone numbers in the entity. </param>
        /// <param name="status"> Status of the entity. </param>
        /// <param name="focDate"> The Firm Order Confirmation date of the phone number entity. </param>
        /// <returns>A new <see cref="PhoneNumberEntity"/> instance for mocking.</returns>

        public static PhoneNumberEntity PhoneNumberEntity(string id, DateTimeOffset? createdAt, string displayName, int? quantity, int? quantityObtained, string status, DateTimeOffset? focDate)
            => new PhoneNumberEntity(id, createdAt, displayName, quantity, quantityObtained, status, focDate);

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumberRelease"/> class.
        /// </summary>
        /// <param name="releaseId"> The id of the release. </param>
        /// <param name="createdAt"> The creation time of the release. </param>
        /// <param name="status"> The release status. </param>
        /// <param name="errorMessage"> The underlying error message of a release. </param>
        /// <param name="phoneNumberReleaseStatusDetails"> The list of phone numbers in the release, mapped to its individual statuses. </param>
        /// <returns>A new <see cref="PhoneNumberRelease"/> instance for mocking.</returns>
        public static PhoneNumberRelease PhoneNumberRelease(string releaseId, DateTimeOffset? createdAt, ReleaseStatus? status, string errorMessage, IReadOnlyDictionary<string, PhoneNumberReleaseDetails> phoneNumberReleaseStatusDetails)
            => new PhoneNumberRelease(releaseId, createdAt, status, errorMessage, phoneNumberReleaseStatusDetails);

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumberReleaseDetails"/> class.
        /// </summary>
        /// <param name="status"> The release status of a phone number. </param>
        /// <param name="errorCode"> The error code in the case the status is error. </param>
        /// <returns>A new <see cref="PhoneNumberReleaseDetails"/> instance for mocking.</returns>
        public static PhoneNumberReleaseDetails PhoneNumberReleaseDetails(PhoneNumberReleaseStatus? status, int? errorCode)
            => new PhoneNumberReleaseDetails(status, errorCode);

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumberReservation"/> class.
        /// </summary>
        /// <param name="reservationId"> The id of the reservation. </param>
        /// <param name="displayName"> The name of the search. </param>
        /// <param name="createdAt"> The creation time of the search. </param>
        /// <param name="description"> The description of the search. </param>
        /// <param name="phonePlanIds"> The phone plan ids of the search. </param>
        /// <param name="areaCode"> The area code of the search. </param>
        /// <param name="quantity"> The quantity of phone numbers in the search. </param>
        /// <param name="locationOptions"> The location options of the search. </param>
        /// <param name="status"> The status of the search. </param>
        /// <param name="phoneNumbers"> The list of phone numbers in the search, in the case the status is reserved or success. </param>
        /// <param name="reservationExpiryDate"> The date that search expires and the numbers become available. </param>
        /// <param name="errorCode"> The error code of the search. </param>
        /// <returns>A new <see cref="PhoneNumberReservation"/> instance for mocking.</returns>
        public static PhoneNumberReservation PhoneNumberReservation(string reservationId, string displayName, DateTimeOffset? createdAt, string description, IReadOnlyList<string> phonePlanIds, string areaCode, int? quantity, IReadOnlyList<LocationOptionsDetails> locationOptions, ReservationStatus? status, IReadOnlyList<string> phoneNumbers, DateTimeOffset? reservationExpiryDate, int? errorCode)
            => new PhoneNumberReservation(reservationId, displayName, createdAt, description, phonePlanIds, areaCode, quantity, locationOptions, status, phoneNumbers, reservationExpiryDate, errorCode);

        /// <summary>
        /// Initializes a new instance of the <see cref="PhonePlan"/> class.
        /// </summary>
        /// <param name="phonePlanId"> The phone plan id. </param>
        /// <param name="localizedName"> The name of the phone plan. </param>
        /// <param name="locationType"> The location type of the phone plan. </param>
        /// <returns>A new <see cref="PhonePlan"/> instance for mocking.</returns>
        public static PhonePlan PhonePlan(string phonePlanId, string localizedName, LocationType locationType)
            => new PhonePlan(phonePlanId, localizedName, locationType);

        /// <summary>
        /// Initializes a new instance of the <see cref="PhonePlanGroup"/> class.
        /// </summary>
        /// <param name="phonePlanGroupId"> The id of the plan group. </param>
        /// <param name="localizedName"> The name of the plan group. </param>
        /// <param name="localizedDescription"> The description of the plan group. </param>
        /// <returns>A new <see cref="PhonePlanGroup"/> instance for mocking.</returns>
        public static PhonePlanGroup PhonePlanGroup(string phonePlanGroupId, string localizedName, string localizedDescription)
            => new PhonePlanGroup(phonePlanGroupId, localizedName, localizedDescription);

        /// <summary>
        /// Initializes a new instance of the <see cref="PhonePlansResponse"/> class.
        /// </summary>
        /// <param name="phonePlans"> Represents the underlying list of phone plans. </param>
        /// <param name="nextLink"> Represents the URL link to the next page. </param>
        /// <returns>A new <see cref="PhonePlansResponse"/> instance for mocking.</returns>

        public static PhonePlansResponse PhonePlansResponse(IReadOnlyList<PhonePlan> phonePlans, string nextLink)
            => new PhonePlansResponse(phonePlans, nextLink);

        /// <summary>
        /// Initializes a new instance of the <see cref="RateInformation"/> class.
        /// </summary>
        /// <param name="monthlyRate"> The monthly rate of a phone plan group. </param>
        /// <param name="currencyType"> The currency of a phone plan group. </param>
        /// <param name="rateErrorMessage"> The error code of a phone plan group. </param>
        /// <returns>A new <see cref="RateInformation"/> instance for mocking.</returns>
        public static RateInformation RateInformation(double? monthlyRate, CurrencyType? currencyType, string rateErrorMessage)
            => new RateInformation(monthlyRate, currencyType, rateErrorMessage);

        /// <summary>
        /// Initializes a new instance of the <see cref="ReleasePhoneNumberOperation"/> class.
        /// </summary>
        /// <param name="releaseId"> The release id of a created release. </param>
        /// <param name="client"> PhoneNumberAdministrationClient <see cref="PhoneNumberAdministrationClient"/> </param>
        /// <returns>A new <see cref="ReleasePhoneNumberOperation"/> instance for mocking.</returns>
        public static ReleasePhoneNumberOperation ReleasePhoneNumberOperation(PhoneNumberAdministrationClient client, string releaseId)
            => new ReleasePhoneNumberOperation(client, releaseId);

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumberReservationPurchaseOperation"/> class.
        /// </summary>
        /// <param name="reservationId"> The reservation id of a created reservation. </param>
        /// <param name="client"> PhoneNumberAdministrationClient <see cref="PhoneNumberAdministrationClient"/> </param>
        /// <returns>A new <see cref="PhoneNumberReservationPurchaseOperation"/> instance for mocking.</returns>
        public static PhoneNumberReservationPurchaseOperation PhoneNumberReservationPurchaseOperation(PhoneNumberAdministrationClient client, string reservationId)
            => new PhoneNumberReservationPurchaseOperation(client, reservationId);

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateNumberCapabilitiesResponse"/> class.
        /// </summary>
        /// <param name="capabilitiesUpdateId"> The capabilities id. </param>
        /// <returns>A new <see cref="UpdateNumberCapabilitiesResponse"/> instance for mocking.</returns>
        public static UpdateNumberCapabilitiesResponse UpdateNumberCapabilitiesResponse(string capabilitiesUpdateId)
            => new UpdateNumberCapabilitiesResponse(capabilitiesUpdateId);

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdatePhoneNumberCapabilitiesResponse"/> class.
        /// </summary>
        /// <param name="capabilitiesUpdateId"> The id of the phone number capabilities update. </param>
        /// <param name="createdAt"> The time the capabilities update was created. </param>
        /// <param name="capabilitiesUpdateStatus"> Status of the capabilities update. </param>
        /// <param name="phoneNumberCapabilitiesUpdates"> The capabilities update for each of a set of phone numbers. </param>
        /// <returns>A new <see cref="UpdatePhoneNumberCapabilitiesResponse"/> instance for mocking.</returns>
        public static UpdatePhoneNumberCapabilitiesResponse UpdatePhoneNumberCapabilitiesResponse(string capabilitiesUpdateId, DateTimeOffset? createdAt, CapabilitiesUpdateStatus? capabilitiesUpdateStatus, IReadOnlyDictionary<string, NumberUpdateCapabilities> phoneNumberCapabilitiesUpdates)
            => new UpdatePhoneNumberCapabilitiesResponse(capabilitiesUpdateId, createdAt, capabilitiesUpdateStatus, phoneNumberCapabilitiesUpdates);
    }
}
