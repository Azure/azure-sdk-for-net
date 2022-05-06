// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication
{
    /// <summary>Represents a Phone Number.</summary>
    public class PhoneNumberIdentifier : CommunicationIdentifier
    {
        private readonly string _rawId;

        /// <summary>The optional raw id of the phone number.</summary>
        public override string RawId
        {
            get
            {
                return _rawId ?? $"4:{PhoneNumber.TrimStart('+')}";
            }
        }

        /// <summary>The phone number in E.164 format.</summary>
        public string PhoneNumber { get; }

        /// <summary> Initializes a new instance of <see cref="PhoneNumberIdentifier"/>.</summary>
        /// <param name="phoneNumber">The phone number in E.164 format.</param>
        /// <param name="rawId">Raw id of the phone number, optional.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when the <paramref name="phoneNumber"/> is null.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the <paramref name="phoneNumber"/> is empty.
        /// </exception>
        public PhoneNumberIdentifier(string phoneNumber, string rawId = null)
        {
            Argument.AssertNotNullOrEmpty(phoneNumber, nameof(phoneNumber));
            PhoneNumber = phoneNumber;
            _rawId = rawId;
        }

        /// <inheritdoc />
        public override string ToString() => PhoneNumber;

        /// <inheritdoc />
        public override int GetHashCode() => RawId.GetHashCode();

        /// <inheritdoc />
        public override bool Equals(CommunicationIdentifier other)
            => other is PhoneNumberIdentifier otherId && otherId.RawId == RawId;
    }
}
