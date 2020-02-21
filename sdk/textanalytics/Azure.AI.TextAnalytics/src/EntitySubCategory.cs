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
    /// Gets the entity sub-category inferred by the text analytics service's named entity recognition model.
    /// The list of available cateogries is described at <see href="https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/named-entity-types"/>.
    /// </summary>
    [JsonConverter(typeof(EntitySubCategoryJsonConverter))]
    public readonly struct EntitySubCategory : IEquatable<EntitySubCategory>
    {
        /// <summary>
        /// Specifies that the entity has no specific sub-category.
        /// </summary>
        public static readonly EntitySubCategory None = default;

        /// <summary>
        /// Specifies that a DateTime entity represents a date (e.g.: March 1, 1999).
        /// </summary>
        public static readonly EntitySubCategory Date = new EntitySubCategory("Date");

        /// <summary>
        /// Specifies that a DateTime entity represents a time (e.g.: 12:34).
        /// </summary>
        public static readonly EntitySubCategory Time = new EntitySubCategory("Time");

        /// <summary>
        /// Specifies that a DateTime entity represents a duration (e.g.: 2 minutes).
        /// </summary>
        public static readonly EntitySubCategory Duration = new EntitySubCategory("Duration");

        /// <summary>
        /// Specifies that a numeric type entity is a number (e.g.: 5, six).
        /// </summary>
        public static readonly EntitySubCategory Number = new EntitySubCategory("Number");

        /// <summary>
        /// Specifies that an entity of a Numeric type is a Percentage (e.g.: 50%, fifty percent).
        /// </summary>
        public static readonly EntitySubCategory Percentage = new EntitySubCategory("Percentage");

        /// <summary>
        /// Specifies that numeric category entity is Ordinal (e.g.: 2nd, second).
        /// </summary>
        public static readonly EntitySubCategory Ordinal = new EntitySubCategory("Ordinal");

        /// <summary>
        /// Specifies that numeric category entity is Currency (e.g.: $10.99, €30.00).
        /// </summary>
        public static readonly EntitySubCategory Currency = new EntitySubCategory("Currency");

        /// <summary>
        /// Specifies that numeric category entity is Dimension (e.g.: 10 miles, 40 cm).
        /// </summary>
        public static readonly EntitySubCategory Dimension = new EntitySubCategory("Dimension");

        /// <summary>
        /// Specifies that numeric category entity is Temperature (e.g.: 32 degrees, 10°C).
        /// </summary>
        public static readonly EntitySubCategory Temperature = new EntitySubCategory("Temperature");

        /// <summary>
        /// Specifies that location category entity is Geographical/Social/Political.
        /// </summary>
        public static readonly EntitySubCategory GPE = new EntitySubCategory("GPE");

        private readonly string _value;

        private EntitySubCategory(string subCategory)
        {
            Argument.AssertNotNull(subCategory, nameof(subCategory));
            _value = subCategory;
        }

        /// <summary>
        /// Defines implicit conversion from string to EntitySubCategory.
        /// </summary>
        /// <param name="subCategory">string to convert.</param>
        /// <returns>The string as a EntitySubCategory.</returns>
        public static implicit operator EntitySubCategory(string subCategory) => subCategory != null ? new EntitySubCategory(subCategory) : default;

        /// <summary>
        /// Defines explicit conversion from EntitySubCategory to string.
        /// </summary>
        /// <param name="subCategory">EntitySubCategory to convert.</param>
        /// <returns>The EntitySubCategory as a string.</returns>
        public static explicit operator string(EntitySubCategory subCategory) => subCategory._value;

        /// <summary>
        /// Compares two EntitySubCategory values for equality.
        /// </summary>
        /// <param name="lhs">The first EntitySubCategory to compare.</param>
        /// <param name="rhs">The second EntitySubCategory to compare.</param>
        /// <returns>true if the EntitySubCategory objects are equal or are both null; false otherwise.</returns>
        public static bool operator ==(EntitySubCategory lhs, EntitySubCategory rhs) => Equals(lhs, rhs);

        /// <summary>
        /// Compares two EntitySubCategory values for inequality.
        /// </summary>
        /// <param name="lhs">The first EntitySubCategory to compare.</param>
        /// <param name="rhs">The second EntitySubCategory to compare.</param>
        /// <returns>true if the EntitySubCategory objects are not equal; false otherwise.</returns>
        public static bool operator !=(EntitySubCategory lhs, EntitySubCategory rhs) => !Equals(lhs, rhs);

        /// <summary>
        /// Compares the EntitySubCategory for equality with another EntitySubCategory.
        /// </summary>
        /// <param name="other">The EntitySubCategory with which to compare.</param>
        /// <returns><c>true</c> if the EntitySubCategory objects are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(EntitySubCategory other) => _value == other._value;

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is EntitySubCategory type && Equals(type);

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value.GetHashCode();

        /// <summary>
        /// Returns a string representation of the EntitySubCategory.
        /// </summary>
        /// <returns>The EntitySubCategory as a string.</returns>
        public override string ToString() => _value ?? "None";
    }

    internal class EntitySubCategoryJsonConverter : JsonConverter<EntitySubCategory>
    {
        public override EntitySubCategory Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetString() ?? EntitySubCategory.None;
        }

        public override void Write(Utf8JsonWriter writer, EntitySubCategory value, JsonSerializerOptions options)
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
