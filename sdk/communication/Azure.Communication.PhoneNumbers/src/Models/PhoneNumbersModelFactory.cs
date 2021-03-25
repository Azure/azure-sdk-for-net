// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.PhoneNumbers.Models
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

        /// <summary> Initializes a new instance of <see cref="ReleasePhoneNumberResult"/>. </summary>
        public static ReleasePhoneNumberResult ReleasePhoneNumberResult()
            => new ReleasePhoneNumberResult();

        /// <summary> Initializes a new instance of <see cref="PurchasePhoneNumbersResult"/>. </summary>
        public static PurchasePhoneNumbersResult PurchasePhoneNumbersResult()
            => new PurchasePhoneNumbersResult();
    }
}
