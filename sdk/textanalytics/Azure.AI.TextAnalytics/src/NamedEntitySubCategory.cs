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
    /// Gets the entity sub-type inferred by the text analytics service's named entity recognition model.
    /// The list of available types is described at <see href="https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/named-entity-types"/>.
    /// </summary>
    [JsonConverter(typeof(NamedEntitySubTypeJsonConverter))]
    public readonly struct NamedEntitySubCategory : IEquatable<NamedEntitySubCategory>
    {
        /// <summary>
        /// Specifies that named entity has no specific sub-type.
        /// </summary>
        public static readonly NamedEntitySubCategory None = default;

        /// <summary>
        /// Specifies that DateTime named entity represents date (e.g.: March 1, 1999).
        /// </summary>
        public static readonly NamedEntitySubCategory Date = new NamedEntitySubCategory("Date");

        /// <summary>
        /// Specifies that DateTime named entity represents time (e.g.: 12:34).
        /// </summary>
        public static readonly NamedEntitySubCategory Time = new NamedEntitySubCategory("Time");

        /// <summary>
        /// Specifies that DateTime named entity represents duration (e.g.: 2 minutes).
        /// </summary>
        public static readonly NamedEntitySubCategory Duration = new NamedEntitySubCategory("Duration");

        /// <summary>
        /// Specifies that numeric type named entity is number (e.g.: 5, six).
        /// </summary>
        public static readonly NamedEntitySubCategory Number = new NamedEntitySubCategory("Number");

        /// <summary>
        /// Specifies that numeric type named entity is Percentage (e.g.: 50%, fifty percent).
        /// </summary>
        public static readonly NamedEntitySubCategory Percentage = new NamedEntitySubCategory("Percentage");

        /// <summary>
        /// Specifies that numeric type named entity is Ordinal (e.g.: 2nd, second).
        /// </summary>
        public static readonly NamedEntitySubCategory Ordinal = new NamedEntitySubCategory("Ordinal");

        /// <summary>
        /// Specifies that numeric type named entity is Currency (e.g.: $10.99, €30.00).
        /// </summary>
        public static readonly NamedEntitySubCategory Currency = new NamedEntitySubCategory("Currency");

        /// <summary>
        /// Specifies that numeric type named entity is Dimension (e.g.: 10 miles, 40 cm).
        /// </summary>
        public static readonly NamedEntitySubCategory Dimension = new NamedEntitySubCategory("Dimension");

        /// <summary>
        /// Specifies that numeric type named entity is Percentage (e.g.: 32 degrees, 10°C).
        /// </summary>
        public static readonly NamedEntitySubCategory Temperature = new NamedEntitySubCategory("Temperature");

        private readonly string _value;

        private NamedEntitySubCategory(string type)
        {
            Argument.AssertNotNull(type, nameof(type));
            _value = type;
        }

        /// <summary>
        /// Defines implicit conversion from string to NamedEntitySubType.
        /// </summary>
        /// <param name="type">string to convert.</param>
        /// <returns>The string as a NamedEntitySubType.</returns>
        public static implicit operator NamedEntitySubCategory(string type) => type != null ? new NamedEntitySubCategory(type) : default;

        /// <summary>
        /// Defines explicit conversion from NamedEntitySubType to string.
        /// </summary>
        /// <param name="type">NamedEntitySubType to convert.</param>
        /// <returns>The NamedEntitySubType as a string.</returns>
        public static explicit operator string(NamedEntitySubCategory type) => type._value;

        /// <summary>
        /// Compares two NamedEntitySubType values for equality.
        /// </summary>
        /// <param name="lhs">The first NamedEntitySubType to compare.</param>
        /// <param name="rhs">The second NamedEntitySubType to compare.</param>
        /// <returns>true if the NamedEntitySubType objects are equal or are both null; false otherwise.</returns>
        public static bool operator ==(NamedEntitySubCategory lhs, NamedEntitySubCategory rhs) => Equals(lhs, rhs);

        /// <summary>
        /// Compares two NamedEntitySubType values for inequality.
        /// </summary>
        /// <param name="lhs">The first NamedEntitySubType to compare.</param>
        /// <param name="rhs">The second NamedEntitySubType to compare.</param>
        /// <returns>true if the NamedEntitySubType objects are not equal; false otherwise.</returns>
        public static bool operator !=(NamedEntitySubCategory lhs, NamedEntitySubCategory rhs) => !Equals(lhs, rhs);

        /// <summary>
        /// Compares the NamedEntitySubType for equality with another NamedEntitySubType.
        /// </summary>
        /// <param name="other">The NamedEntitySubType with which to compare.</param>
        /// <returns><c>true</c> if the NamedEntitySubType objects are equal; otherwise, <c>false</c>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Equals(NamedEntitySubCategory other) => _value == other._value;

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj) => obj is NamedEntitySubCategory type && Equals(type);

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();

        /// <summary>
        /// Returns a string representation of the NamedEntitySubType.
        /// </summary>
        /// <returns>The NamedEntitySubType as a string.</returns>
        public override string ToString() => _value ?? "None";
    }

    internal class NamedEntitySubTypeJsonConverter : JsonConverter<NamedEntitySubCategory>
    {
        public override NamedEntitySubCategory Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetString() ?? NamedEntitySubCategory.None;
        }

        public override void Write(Utf8JsonWriter writer, NamedEntitySubCategory value, JsonSerializerOptions options)
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
