// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Gets the entity sub-type inferred by the text analytics service's named entity recognition model. The list of available types is described at <see href="https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/named-entity-types"/>.
    /// </summary>
    [JsonConverter(typeof(NamedEntitySubTypeJsonConverter))]
    public readonly struct NamedEntitySubType
    {
        /// <summary>
        /// Specifies that named entity has no specific sub-type.
        /// </summary>
        public static readonly NamedEntitySubType None = default;

        /// <summary>
        /// Specifies that DateTime named entity represents date (e.g.: March 1, 1999).
        /// </summary>
        public static readonly NamedEntitySubType Date = new NamedEntitySubType("Date");

        /// <summary>
        /// Specifies that DateTime named entity represents time (e.g.: 12:34).
        /// </summary>
        public static readonly NamedEntitySubType Time = new NamedEntitySubType("Time");

        /// <summary>
        /// Specifies that DateTime named entity represents duration (e.g.: 2 minutes).
        /// </summary>
        public static readonly NamedEntitySubType Duration = new NamedEntitySubType("Duration");

        /// <summary>
        /// Specifies that numeric type named entity is number (e.g.: 5, six).
        /// </summary>
        public static readonly NamedEntitySubType Number = new NamedEntitySubType("Number");

        /// <summary>
        /// Specifies that numeric type named entity is Percentage (e.g.: 50%, fifty percent).
        /// </summary>
        public static readonly NamedEntitySubType Percentage = new NamedEntitySubType("Percentage");

        /// <summary>
        /// Specifies that numeric type named entity is Ordinal (e.g.: 2nd, second).
        /// </summary>
        public static readonly NamedEntitySubType Ordinal = new NamedEntitySubType("Ordinal");

        /// <summary>
        /// Specifies that numeric type named entity is Currency (e.g.: $10.99, €30.00).
        /// </summary>
        public static readonly NamedEntitySubType Currency = new NamedEntitySubType("Currency");

        /// <summary>
        /// Specifies that numeric type named entity is Dimension (e.g.: 10 miles, 40 cm).
        /// </summary>
        public static readonly NamedEntitySubType Dimension = new NamedEntitySubType("Dimension");

        /// <summary>
        /// Specifies that numeric type named entity is Percentage (e.g.: 32 degrees, 10°C).
        /// </summary>
        public static readonly NamedEntitySubType Temperature = new NamedEntitySubType("Temperature");

        private readonly string _value;

        private NamedEntitySubType(string type)
        {
            Argument.AssertNotNull(type, nameof(type));
            _value = type;
        }

        /// <summary>
        /// Defines implicit conversion from string to NamedEntitySubType.
        /// </summary>
        /// <param name="type">string to convert.</param>
        /// <returns>The string as a NamedEntitySubType.</returns>
        public static implicit operator NamedEntitySubType(string type) => type != null ? new NamedEntitySubType(type) : default;

        /// <summary>
        /// Defines explicit conversion from NamedEntitySubType to string.
        /// </summary>
        /// <param name="type">NamedEntitySubType to convert.</param>
        /// <returns>The NamedEntitySubType as a string.</returns>
        public static explicit operator string(NamedEntitySubType type) => type._value;

        /// <summary>
        /// Compares two NamedEntitySubType values for equality.
        /// </summary>
        /// <param name="lhs">The first NamedEntitySubType to compare.</param>
        /// <param name="rhs">The second NamedEntitySubType to compare.</param>
        /// <returns>true if the NamedEntitySubType objects are equal or are both null; false otherwise.</returns>
        public static bool operator ==(NamedEntitySubType lhs, NamedEntitySubType rhs) => Equals(lhs, rhs);

        /// <summary>
        /// Compares two NamedEntitySubType values for inequality.
        /// </summary>
        /// <param name="lhs">The first NamedEntitySubType to compare.</param>
        /// <param name="rhs">The second NamedEntitySubType to compare.</param>
        /// <returns>true if the NamedEntitySubType objects are not equal; false otherwise.</returns>
        public static bool operator !=(NamedEntitySubType lhs, NamedEntitySubType rhs) => !Equals(lhs, rhs);

        /// <summary>
        /// Compares the NamedEntitySubType for equality with another NamedEntitySubType.
        /// </summary>
        /// <param name="other">The NamedEntitySubType with which to compare.</param>
        /// <returns><c>true</c> if the NamedEntitySubType objects are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(NamedEntitySubType other) => _value == other._value;

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj) => obj is NamedEntitySubType type && Equals(type);

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode() => _value.GetHashCode();

        /// <summary>
        /// Returns a string representation of the NamedEntitySubType.
        /// </summary>
        /// <returns>The NamedEntitySubType as a string.</returns>
        public override string ToString() => _value ?? "N/A";
    }

    internal class NamedEntitySubTypeJsonConverter : JsonConverter<NamedEntitySubType>
    {
        public override NamedEntitySubType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetString() ?? NamedEntitySubType.None;
        }

        public override void Write(Utf8JsonWriter writer, NamedEntitySubType value, JsonSerializerOptions options)
        {
            var stringValue = (string)value;
            if (stringValue != null)
            {
                writer.WriteStringValue(stringValue);
            }
            else
            {
                writer.WriteNullValue();
            }
        }
    }
}
