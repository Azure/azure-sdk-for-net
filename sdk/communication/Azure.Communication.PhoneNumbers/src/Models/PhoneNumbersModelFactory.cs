// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.PhoneNumbers
{
    /// <summary>
    /// Model factory that enables mocking for the Azure.Communication.PhoneNumbers library.
    /// </summary>
    public static class PhoneNumbersModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="PurchasedPhoneNumber"/>. </summary>
        /// <param name="id"> The id of the phone number, e.g. 14255550123. </param>
        /// <param name="phoneNumber"> String of the E.164 format of the phone number, e.g. +14255550123. </param>
        /// <param name="countryCode"> The ISO 3166-2 code of the phone number&apos;s country, e.g. US. </param>
        /// <param name="phoneNumberType"> The phone number&apos;s type, e.g. Geographic, TollFree. </param>
        /// <param name="capabilities"> Capabilities of a phone number. </param>
        /// <param name="assignmentType"> The assignment type of the phone number. A phone number can be assigned to a person, or to an application. </param>
        /// <param name="purchaseDate"> The date and time that the phone number was purchased. </param>
        /// <param name="cost"> The incurred cost for a single phone number. </param>
#pragma warning disable CA1054 // URI-like parameters should not be strings
        public static PurchasedPhoneNumber PurchasedPhoneNumber(string id, string phoneNumber, string countryCode, PhoneNumberType phoneNumberType, PhoneNumberCapabilities capabilities, PhoneNumberAssignmentType assignmentType, DateTimeOffset purchaseDate, PhoneNumberCost cost)
#pragma warning restore CA1054 // URI-like parameters should not be strings
            => new PurchasedPhoneNumber(id, phoneNumber, countryCode, phoneNumberType, capabilities, assignmentType, purchaseDate, cost);

        /// <summary> Initializes a new instance of <see cref="PhoneNumberCost"/>. </summary>
        /// <param name="amount"> The cost amount. </param>
        /// <param name="currencyCode"> The ISO 4217 currency code for the cost amount. </param>
        /// <param name="billingFrequency"> The frequency with which the cost gets billed. </param>
        public static PhoneNumberCost PhoneNumberCost(double amount, string currencyCode, string billingFrequency)
            => new PhoneNumberCost(amount, currencyCode, billingFrequency);

        /// <summary> Initializes a new instance of PhoneNumberSearchResult. </summary>
        /// <param name="searchId"> The search id. </param>
        /// <param name="phoneNumbers"> The phone numbers that are available. Can be fewer than the desired search quantity. </param>
        /// <param name="phoneNumberType"> The phone number&apos;s type, e.g. geographic, or tollFree. </param>
        /// <param name="assignmentType"> Phone number&apos;s assignment type. </param>
        /// <param name="capabilities"> Capabilities of a phone number. </param>
        /// <param name="cost"> The incurred cost for a single phone number. </param>
        /// <param name="searchExpiresOn"> The date that this search result expires and phone numbers are no longer on hold. A search result expires in less than 15min, e.g. 2020-11-19T16:31:49.048Z. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="searchId"/>, <paramref name="phoneNumbers"/>, <paramref name="capabilities"/>, or <paramref name="cost"/> is null. </exception>
        public static PhoneNumberSearchResult PhoneNumberSearchResult(string searchId, IEnumerable<string> phoneNumbers, PhoneNumberType phoneNumberType, PhoneNumberAssignmentType assignmentType, PhoneNumberCapabilities capabilities, PhoneNumberCost cost, DateTimeOffset searchExpiresOn)
            => new PhoneNumberSearchResult(searchId, phoneNumbers, phoneNumberType, assignmentType, capabilities, cost, searchExpiresOn);
    }
}
