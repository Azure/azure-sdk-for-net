// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication
{
    /// <summary>Represents a Phone Number.</summary>
    public class PhoneNumberIdentifier : CommunicationIdentifier
    {
        /// <summary>The full id of the phone number.</summary>
        public string Id { get; }

        /// <summary>The phone number in E.164 format.</summary>
        public string PhoneNumber { get; }

        /// <summary> Initializes a new instance of <see cref="PhoneNumberIdentifier"/>.</summary>
        /// <param name="phoneNumber">The phone number in E.164 format.</param>
        /// <param name="id">Full id of the phone number.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when the <paramref name="phoneNumber"/> is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the <paramref name="phoneNumber"/> is empty.
        /// </exception>
        public PhoneNumberIdentifier(string phoneNumber, string id = null)
        {
            Argument.AssertNotNullOrEmpty(phoneNumber, nameof(phoneNumber));
            PhoneNumber = phoneNumber;
            Id = id;
        }

        /// <inheritdoc />
        public override string ToString() => PhoneNumber;

        /// <inheritdoc />
        public override int GetHashCode() => PhoneNumber.GetHashCode();

        /// <inheritdoc />
        public override bool Equals(CommunicationIdentifier other)
            => other is PhoneNumberIdentifier otherId && otherId.PhoneNumber == PhoneNumber && (Id is null || otherId.Id is null || Id == otherId.Id);
    }
}
