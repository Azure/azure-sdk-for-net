// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.PhoneNumbers
{
    /// <summary>
    /// The Azure Communication Services phone numbers client.
    /// </summary>
    public interface IPhoneNumbersClient
    {
        /// <summary> Releases an purchased phone number. </summary>
        /// <param name="phoneNumber"> Phone number to be released, e.g. +14255550123. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="phoneNumber"/> is null. </exception>
        Task<ReleasePhoneNumberOperation> StartReleasePhoneNumberAsync(string phoneNumber, CancellationToken cancellationToken = default);

        /// <summary> Releases an purchased phone number. </summary>
        /// <param name="phoneNumber"> Phone number to be released, e.g. +14255550123. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="phoneNumber"/> is null. </exception>
        ReleasePhoneNumberOperation StartReleasePhoneNumber(string phoneNumber, CancellationToken cancellationToken = default);

        /// <summary> Updates the capabilities of a phone number. </summary>
        /// <param name="phoneNumber"> The phone number id in E.164 format. The leading plus can be either + or encoded as %2B, e.g. +14255550123. </param>
        /// <param name="calling"> Capability value for calling. </param>
        /// <param name="sms"> Capability value for SMS. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="phoneNumber"/> is null. </exception>
        Task<UpdatePhoneNumberCapabilitiesOperation> StartUpdateCapabilitiesAsync(string phoneNumber, PhoneNumberCapabilityType? calling = null, PhoneNumberCapabilityType? sms = null, CancellationToken cancellationToken = default);

        /// <summary> Updates the capabilities of a phone number. </summary>
        /// <param name="phoneNumber"> The phone number id in E.164 format. The leading plus can be either + or encoded as %2B, e.g. +14255550123. </param>
        /// <param name="calling"> Capability value for calling. </param>
        /// <param name="sms"> Capability value for SMS. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="phoneNumber"/> is null. </exception>
        UpdatePhoneNumberCapabilitiesOperation StartUpdateCapabilities(string phoneNumber, PhoneNumberCapabilityType? calling = null, PhoneNumberCapabilityType? sms = null, CancellationToken cancellationToken = default);

        /// <summary> Gets the details of the given purchased phone number. </summary>
        /// <param name="phoneNumber"> The acquired phone number whose details are to be fetched in E.164 format, e.g. +14255550123. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        Task<Response<PurchasedPhoneNumber>> GetPurchasedPhoneNumberAsync(string phoneNumber, CancellationToken cancellationToken = default);

        /// <summary> Gets the details of the given purchased phone number. </summary>
        /// <param name="phoneNumber"> The acquired phone number whose details are to be fetched in E.164 format, e.g. +14255550123. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        Response<PurchasedPhoneNumber> GetPurchasedPhoneNumber(string phoneNumber, CancellationToken cancellationToken = default);

        /// <summary> Purchases phone numbers. </summary>
        /// <param name="searchId"> The search id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        Task<PurchasePhoneNumbersOperation> StartPurchasePhoneNumbersAsync(string searchId, CancellationToken cancellationToken = default);

        /// <summary> Purchases phone numbers. </summary>
        /// <param name="searchId"> The search id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        PurchasePhoneNumbersOperation StartPurchasePhoneNumbers(string searchId, CancellationToken cancellationToken = default);

        /// <summary> Search for available phone numbers to purchase. </summary>
        /// <param name="twoLetterIsoCountryName"> The ISO 3166-2 country code, e.g. US. </param>
        /// <param name="phoneNumberType"> The type of phone numbers to search for. </param>
        /// <param name="phoneNumberAssignmentType"> The assignment type of the phone numbers to search for. </param>
        /// <param name="capabilities"> Capabilities of a phone number. </param>
        /// <param name="options"> The phone number search options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="twoLetterIsoCountryName"/> is null. </exception>
        Task<SearchAvailablePhoneNumbersOperation> StartSearchAvailablePhoneNumbersAsync(string twoLetterIsoCountryName, PhoneNumberType phoneNumberType, PhoneNumberAssignmentType phoneNumberAssignmentType,
            PhoneNumberCapabilities capabilities, PhoneNumberSearchOptions options = null, CancellationToken cancellationToken = default);

        /// <summary> Search for available phone numbers to purchase. </summary>
        /// <param name="twoLetterIsoCountryName"> The ISO 3166-2 country code, e.g. US. </param>
        /// <param name="phoneNumberType"> The type of phone numbers to search for. </param>
        /// <param name="phoneNumberAssignmentType"> The assignment type of the phone numbers to search for. </param>
        /// <param name="capabilities"> Capabilities of a phone number. </param>
        /// <param name="options"> The phone number search options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="twoLetterIsoCountryName"/> is null. </exception>
        SearchAvailablePhoneNumbersOperation StartSearchAvailablePhoneNumbers(string twoLetterIsoCountryName, PhoneNumberType phoneNumberType, PhoneNumberAssignmentType phoneNumberAssignmentType,
            PhoneNumberCapabilities capabilities, PhoneNumberSearchOptions options = null, CancellationToken cancellationToken = default);

        /// <summary> Gets the result of a search </summary>
        /// <param name="searchId"> The cancellation token to use. </param>
        AsyncPageable<PhoneNumberSearchResult> GetPhoneNumberSearchResult(string searchId);

        /// <summary> Gets the list of all purchased phone numbers. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        AsyncPageable<PurchasedPhoneNumber> GetPurchasedPhoneNumbersAsync(CancellationToken cancellationToken = default);

        /// <summary> Gets the list of all purchased phone numbers. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        Pageable<PurchasedPhoneNumber> GetPurchasedPhoneNumbers(CancellationToken cancellationToken = default);

        /// <summary> Lists the available countries from which to purchase phone numbers. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        AsyncPageable<PhoneNumberCountry> GetAvailableCountriesAsync(CancellationToken cancellationToken = default);

        /// <summary> Lists the available countries from which to purchase phone numbers. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        Pageable<PhoneNumberCountry> GetAvailableCountries(CancellationToken cancellationToken = default);

        /// <summary> Lists the available localities (e.g. city or town) in the given country from which to purchase phone numbers. </summary>
        /// <param name="twoLetterIsoCountryName"> The ISO 3166-2 country code, e.g. US. </param>
        /// <param name="administrativeDivision"> The administrative division within the country within which to list localities. This is also known as the state or province. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        AsyncPageable<PhoneNumberLocality> GetAvailableLocalitiesAsync(string twoLetterIsoCountryName, string administrativeDivision = null, CancellationToken cancellationToken = default);

        /// <summary> Lists the available localities (e.g. city or town) in the given country from which to purchase phone numbers. </summary>
        /// <param name="twoLetterIsoCountryName"> The ISO 3166-2 country code, e.g. US. </param>
        /// <param name="administrativeDivision"> The administrative division within the country within which to list localities. This is also known as the state or province. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        Pageable<PhoneNumberLocality> GetAvailableLocalities(string twoLetterIsoCountryName, string administrativeDivision = null, CancellationToken cancellationToken = default);

        /// <summary> Lists the available area codes within a given country and locality. </summary>
        /// <param name="twoLetterIsoCountryName"> The ISO 3166-2 country code, e.g. US. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        AsyncPageable<PhoneNumberAreaCode> GetAvailableAreaCodesTollFreeAsync(string twoLetterIsoCountryName, CancellationToken cancellationToken = default);

        /// <summary> Lists the available area codes within a given country and locality. </summary>
        /// <param name="twoLetterIsoCountryName"> The ISO 3166-2 country code, e.g. US. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        Pageable<PhoneNumberAreaCode> GetAvailableAreaCodesTollFree(string twoLetterIsoCountryName, CancellationToken cancellationToken = default);

        /// <summary> Lists the available area codes within a given country and locality. </summary>
        /// <param name="twoLetterIsoCountryName"> The ISO 3166-2 country code, e.g. US. </param>
        /// <param name="phoneNumberAssignmentType"> The assignment type of the phone numbers to search for. </param>
        /// <param name="locality"> The locality in which to list area codes. This is also known as the state or province. </param>
        /// <param name="administrativeDivision"> Optionally, the administrative division of the locality. This is also known as the state or province. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        AsyncPageable<PhoneNumberAreaCode> GetAvailableAreaCodesGeographicAsync(string twoLetterIsoCountryName, PhoneNumberAssignmentType phoneNumberAssignmentType, string locality, string administrativeDivision = null, CancellationToken cancellationToken = default);

        /// <summary> Lists the available area codes within a given country and locality. </summary>
        /// <param name="twoLetterIsoCountryName"> The ISO 3166-2 country code, e.g. US. </param>
        /// <param name="phoneNumberAssignmentType"> The assignment type of the phone numbers to search for. </param>
        /// <param name="locality"> The locality in which to list area codes. This is also known as the state or province. </param>
        /// <param name="administrativeDivision"> Optionally, the administrative division of the locality. This is also known as the state or province. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        Pageable<PhoneNumberAreaCode> GetAvailableAreaCodesGeographic(string twoLetterIsoCountryName, PhoneNumberAssignmentType phoneNumberAssignmentType, string locality, string administrativeDivision = null, CancellationToken cancellationToken = default);

        /// <summary> Lists the available offerings in the given country. </summary>
        /// <param name="twoLetterIsoCountryName"> The ISO 3166-2 country code, e.g. US. </param>
        /// <param name="phoneNumberType"> The type of phone numbers to search for. </param>
        /// <param name="phoneNumberAssignmentType"> The assignment type of the phone numbers to search for. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        AsyncPageable<PhoneNumberOffering> GetAvailableOfferingsAsync(string twoLetterIsoCountryName, PhoneNumberType? phoneNumberType = null, PhoneNumberAssignmentType? phoneNumberAssignmentType = null, CancellationToken cancellationToken = default);

        /// <summary> Lists the available offerings in the given country. </summary>
        /// <param name="twoLetterIsoCountryName"> The ISO 3166-2 country code, e.g. US. </param>
        /// <param name="phoneNumberType"> The type of phone numbers to search for. </param>
        /// <param name="phoneNumberAssignmentType"> The assignment type of the phone numbers to search for. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        Pageable<PhoneNumberOffering> GetAvailableOfferings(string twoLetterIsoCountryName, PhoneNumberType? phoneNumberType = null, PhoneNumberAssignmentType? phoneNumberAssignmentType = null, CancellationToken cancellationToken = default);
    }
}
