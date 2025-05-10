// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using Azure.Core;
using Azure.Communication;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// TeamsPhoneCallerDetails.
    /// </summary>
    public class TeamsPhoneCallerDetails
    {
        /// <summary> Initializes a new instance of <see cref="TeamsPhoneCallerDetails"/>. </summary>
        /// <param name="caller"> Caller's ID. </param>
        /// <param name="name"> Caller's name. </param>
        /// <param name="phoneNumber"> Caller's phone number. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="caller"/>, <paramref name="name"/> or <paramref name="phoneNumber"/> is null. </exception>
        public TeamsPhoneCallerDetails(CommunicationIdentifier caller, string name, string phoneNumber)
        {
            Argument.AssertNotNull(caller, nameof(caller));
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(phoneNumber, nameof(phoneNumber));
            Caller = caller;
            Name = name;
            PhoneNumber = phoneNumber;
            AdditionalCallerInformation = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of <see cref="TeamsPhoneCallerDetails"/>. </summary>
        /// <param name="caller"> Caller's ID. </param>
        /// <param name="name"> Caller's name. </param>
        /// <param name="phoneNumber"> Caller's phone number. </param>
        /// <param name="recordId"> Caller's record ID (ex in CRM). </param>
        /// <param name="screenPopUrl"> Caller's screen pop URL. </param>
        /// <param name="isAuthenticated"> Flag indicating whether the caller was authenticated. </param>
        /// <param name="additionalCallerInformation"> A set of key value pairs (max 10, any additional entries would be ignored) which a bot author wants to pass to the Teams Client for display to the agent. </param>
        internal TeamsPhoneCallerDetails(CommunicationIdentifier caller, string name, string phoneNumber, string recordId, string screenPopUrl, bool? isAuthenticated, IDictionary<string, string> additionalCallerInformation)
        {
            Caller = caller;
            Name = name;
            PhoneNumber = phoneNumber;
            RecordId = recordId;
            ScreenPopUrl = screenPopUrl;
            IsAuthenticated = isAuthenticated;
            AdditionalCallerInformation = additionalCallerInformation;
        }

        /// <summary> Caller's ID. </summary>
        internal CommunicationIdentifier Caller { get; set; }
        /// <summary> Caller's name. </summary>
        public string Name { get; set; }
        /// <summary> Caller's phone number. </summary>
        public string PhoneNumber { get; set; }
        /// <summary> Caller's record ID (ex in CRM). </summary>
        public string RecordId { get; set; }
        /// <summary> Caller's screen pop URL. </summary>
        public string ScreenPopUrl { get; set; }
        /// <summary> Flag indicating whether the caller was authenticated. </summary>
        public bool? IsAuthenticated { get; set; }
        /// <summary> A set of key value pairs (max 10, any additional entries would be ignored) which a bot author wants to pass to the Teams Client for display to the agent. </summary>
        public IDictionary<string, string> AdditionalCallerInformation { get; }

        /// <summary>
        /// Adds a key-value pair to the AdditionalCallerInformation dictionary.
        /// Will not add entries beyond the maximum limit of 10 items.
        /// </summary>
        /// <param name="key">The key for the caller information.</param>
        /// <param name="value">The value for the caller information.</param>
        /// <returns>True if the item was added, false if the dictionary already contains 10 items.</returns>
        public bool AddAdditionalCallerInformation(string key, string value)
        {
            if (AdditionalCallerInformation.Count >= 10)
            {
                return false;
            }

            AdditionalCallerInformation[key] = value;
            return true;
        }
    }
}
