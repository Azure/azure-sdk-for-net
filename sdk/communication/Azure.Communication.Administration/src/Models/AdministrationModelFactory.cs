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
        /// <summary> Initializes a new instance of AcquiredPhoneNumber. </summary>
        /// <param name="id"> The id, this is the same as the phone number in E.164 format. </param>
        /// <param name="phoneNumber"> The phoneNumber in E.164 format. </param>
        /// <param name="countryCode"> The ISO 3166-2 country code of the country that the phone number belongs to. </param>
        /// <param name="phoneNumberType"> The type of the phone number. </param>
        /// <param name="assignmentType"> The assignment type of the phone number, people or application. </param>
        /// <param name="purchaseDate"> The purchase date of the phone number. </param>
        /// <param name="capabilities"> The phone number&apos;s capabilities. </param>
        /// <param name="callbackUri"> The webhook for receiving incoming events. </param>
        /// <param name="applicationId"> The application id the number has been assigned to. </param>
        /// <param name="cost"> The monthly cost of the phone number. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="phoneNumber"/>, <paramref name="countryCode"/>, <paramref name="capabilities"/>, <paramref name="callbackUri"/>, <paramref name="applicationId"/>, or <paramref name="cost"/> is null. </exception>
#pragma warning disable CA1054 // URI-like parameters should not be strings
        public static AcquiredPhoneNumber AcquiredPhoneNumber(string id, string phoneNumber, string countryCode, PhoneNumberType phoneNumberType, PhoneNumberAssignmentType assignmentType, DateTimeOffset purchaseDate, PhoneNumberCapabilities capabilities, string callbackUri, string applicationId, PhoneNumberCost cost)
#pragma warning restore CA1054 // URI-like parameters should not be strings
            => new AcquiredPhoneNumber(id, phoneNumber, countryCode, phoneNumberType, assignmentType, purchaseDate, capabilities, callbackUri, applicationId, cost);

        /// <summary> Initializes a new instance of PhoneNumberCost. </summary>
        /// <param name="amount"> The cost amount. </param>
        /// <param name="currencyCode"> The ISO 4217 currency code for the cost amount. </param>
        /// <param name="billingFrequency"> The frequency with which the cost gets billed. </param>
        public static PhoneNumberCost PhoneNumberCost(double amount, string currencyCode, string billingFrequency)
            => new PhoneNumberCost(amount, currencyCode, billingFrequency);
    }
}
