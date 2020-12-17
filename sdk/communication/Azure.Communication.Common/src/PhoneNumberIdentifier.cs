// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using Azure.Core;

namespace Azure.Communication
{
    /// <summary>Represents a Phone Number.</summary>
    [DebuggerDisplay("{Value}")]
    public class PhoneNumberIdentifier : CommunicationIdentifier
    {
        /// <summary>The phone number in E.164 format.</summary>
        public string Value { get; }

        /// <summary> Initializes a new instance of <see cref="PhoneNumberIdentifier"/>.</summary>
        /// <param name="phoneNumber">The phone number in E.164 format.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when the <paramref name="phoneNumber"/> is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the <paramref name="phoneNumber"/> is empty.
        /// </exception>
        public PhoneNumberIdentifier(string phoneNumber)
        {
            Argument.AssertNotNullOrEmpty(phoneNumber, nameof(phoneNumber));
            Value = phoneNumber;
        }
    }
}
