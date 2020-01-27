// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Gets the entity type inferred by the text analytics service's named entity recognition model.
    /// The list of available types is described at <see href="https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/named-entity-types"/>.
    /// </summary>
    [JsonConverter(typeof(NamedEntityTypeJsonConverter))]
    public readonly struct NamedEntityType : IEquatable<NamedEntityType>
    {
        /// <summary>
        /// Specifies that named entity contains recognized name.
        /// </summary>
        public static readonly NamedEntityType Person = new NamedEntityType("Person");

        /// <summary>
        /// Specifies that named entity contains natural or human-made landmarks, structures, or geographical features.JsonConvert.SerializeObject(model)
        /// </summary>
        public static readonly NamedEntityType Location = new NamedEntityType("Location");

        /// <summary>
        /// Specifies that named entity contains recognized name of organization, corporation, agency, or other group of people.
        /// </summary>
        public static readonly NamedEntityType Organization = new NamedEntityType("Organization");

        /// <summary>
        /// Specifies that the named entity contains a date, time or duration.
        /// </summary>
        public static readonly NamedEntityType DateTime = new NamedEntityType("DateTime");

        /// <summary>
        /// Specifies that the named entity contains a phone number (US phone numbers only).
        /// </summary>
        public static readonly NamedEntityType PhoneNumber = new NamedEntityType("PhoneNumber");

        /// <summary>
        /// Specifies that the named entity contains an email address.
        /// </summary>
        public static readonly NamedEntityType Email = new NamedEntityType("Email");

        /// <summary>
        /// Specifies that the named entity contains an Internet URL.
        /// </summary>
        public static readonly NamedEntityType Url = new NamedEntityType("URL");

        /// <summary>
        /// Specifies that the named entity contains a number or numeric quantity.
        /// </summary>
        public static readonly NamedEntityType Quantity = new NamedEntityType("Quantity");

        private readonly string _value;

        private NamedEntityType(string type)
        {
            Argument.AssertNotNull(type, nameof(type));
            _value = type;
        }

        /// <summary>
        /// Defines implicit conversion from string to NamedEntityType.
        /// </summary>
        /// <param name="type">string to convert.</param>
        /// <returns>The string as a NamedEntityType.</returns>
        public static implicit operator NamedEntityType(string type) => new NamedEntityType(type);

        /// <summary>
        /// Defines explicit conversion from NamedEntityType to string.
        /// </summary>
        /// <param name="type">NamedEntityType to convert.</param>
        /// <returns>The NamedEntityType as a string.</returns>
        public static explicit operator string(NamedEntityType type) => type._value;

        /// <summary>
        /// Compares two NamedEntityType values for equality.
        /// </summary>
        /// <param name="lhs">The first NamedEntityType to compare.</param>
        /// <param name="rhs">The second NamedEntityType to compare.</param>
        /// <returns>true if the NamedEntityType objects are equal or are both null; false otherwise.</returns>
        public static bool operator ==(NamedEntityType lhs, NamedEntityType rhs) => Equals(lhs, rhs);

        /// <summary>
        /// Compares two NamedEntityType values for inequality.
        /// </summary>
        /// <param name="lhs">The first NamedEntityType to compare.</param>
        /// <param name="rhs">The second NamedEntityType to compare.</param>
        /// <returns>true if the NamedEntityType objects are not equal; false otherwise.</returns>
        public static bool operator !=(NamedEntityType lhs, NamedEntityType rhs) => !Equals(lhs, rhs);

        /// <summary>
        /// Compares the NamedEntityType for equality with another NamedEntityType.
        /// </summary>
        /// <param name="other">The NamedEntityType with which to compare.</param>
        /// <returns><c>true</c> if the NamedEntityType objects are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(NamedEntityType other) => _value == other._value;

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is NamedEntityType type && Equals(type);

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();

        /// <summary>
        /// Returns a string representation of the NamedEntityType.
        /// </summary>
        /// <returns>The NamedEntityType as a string.</returns>
        public override string ToString() => _value;
    }

    internal class NamedEntityTypeJsonConverter : JsonConverter<NamedEntityType>
    {
        public override NamedEntityType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetString();
        }

        public override void Write(Utf8JsonWriter writer, NamedEntityType value, JsonSerializerOptions options)
        {
            writer.WriteStringValue((string)value);
        }
    }
}
