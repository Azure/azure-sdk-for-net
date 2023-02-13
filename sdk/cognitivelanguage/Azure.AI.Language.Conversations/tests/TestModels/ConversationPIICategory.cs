// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The ConversationPIICategory. </summary>
    public readonly partial struct ConversationPIICategory : IEquatable<ConversationPIICategory>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="ConversationPIICategory"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ConversationPIICategory(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AddressValue = "Address";
        private const string CreditCardNumberValue = "CreditCardNumber";
        private const string EmailValue = "Email";
        private const string NameValue = "Name";
        private const string NumericIdentifierValue = "NumericIdentifier";
        private const string PhoneNumberValue = "PhoneNumber";
        private const string USSocialSecurityNumberValue = "USSocialSecurityNumber";
        private const string MiscellaneousValue = "Miscellaneous";
        private const string AllValue = "All";
        private const string DefaultValue = "Default";

        /// <summary> Address. </summary>
        public static ConversationPIICategory Address { get; } = new ConversationPIICategory(AddressValue);
        /// <summary> CreditCardNumber. </summary>
        public static ConversationPIICategory CreditCardNumber { get; } = new ConversationPIICategory(CreditCardNumberValue);
        /// <summary> Email. </summary>
        public static ConversationPIICategory Email { get; } = new ConversationPIICategory(EmailValue);
        /// <summary> Name. </summary>
        public static ConversationPIICategory Name { get; } = new ConversationPIICategory(NameValue);
        /// <summary> NumericIdentifier. </summary>
        public static ConversationPIICategory NumericIdentifier { get; } = new ConversationPIICategory(NumericIdentifierValue);
        /// <summary> PhoneNumber. </summary>
        public static ConversationPIICategory PhoneNumber { get; } = new ConversationPIICategory(PhoneNumberValue);
        /// <summary> USSocialSecurityNumber. </summary>
        public static ConversationPIICategory USSocialSecurityNumber { get; } = new ConversationPIICategory(USSocialSecurityNumberValue);
        /// <summary> Miscellaneous. </summary>
        public static ConversationPIICategory Miscellaneous { get; } = new ConversationPIICategory(MiscellaneousValue);
        /// <summary> All. </summary>
        public static ConversationPIICategory All { get; } = new ConversationPIICategory(AllValue);
        /// <summary> Default. </summary>
        public static ConversationPIICategory Default { get; } = new ConversationPIICategory(DefaultValue);
        /// <summary> Determines if two <see cref="ConversationPIICategory"/> values are the same. </summary>
        public static bool operator ==(ConversationPIICategory left, ConversationPIICategory right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ConversationPIICategory"/> values are not the same. </summary>
        public static bool operator !=(ConversationPIICategory left, ConversationPIICategory right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ConversationPIICategory"/>. </summary>
        public static implicit operator ConversationPIICategory(string value) => new ConversationPIICategory(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ConversationPIICategory other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ConversationPIICategory other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
