// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using Common;
    using Newtonsoft.Json;
    using Serialization;

    /// <summary>
    /// Defines the data type of a field in a search index.
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<DataType>))]
    public struct DataType : IEquatable<DataType>
    {
        private readonly string _value;

        /// <summary>
        /// Indicates that a field contains a string.
        /// </summary>
        public static readonly DataType String = new DataType(AsString.String);

        /// <summary>
        /// Indicates that a field contains a 32-bit signed integer.
        /// </summary>
        public static readonly DataType Int32 = new DataType(AsString.Int32);

        /// <summary>
        /// Indicates that a field contains a 64-bit signed integer.
        /// </summary>
        public static readonly DataType Int64 = new DataType(AsString.Int64);

        /// <summary>
        /// Indicates that a field contains an IEEE double-precision floating point number.
        /// </summary>
        public static readonly DataType Double = new DataType(AsString.Double);

        /// <summary>
        /// Indicates that a field contains a Boolean value (true or false).
        /// </summary>
        public static readonly DataType Boolean = new DataType(AsString.Boolean);

        /// <summary>
        /// Indicates that a field contains a date/time value, including timezone information.
        /// </summary>
        public static readonly DataType DateTimeOffset = new DataType(AsString.DateTimeOffset);

        /// <summary>
        /// Indicates that a field contains a geo-location in terms of longitude and latitude.
        /// </summary>
        public static readonly DataType GeographyPoint = new DataType(AsString.GeographyPoint);

        /// <summary>
        /// Indicates that a field contains one or more complex objects that in turn have sub-fields of other types.
        /// </summary>
        public static readonly DataType Complex = new DataType(AsString.Complex);

        private DataType(string typeName)
        {
            Throw.IfArgumentNull(typeName, nameof(typeName));
            _value = typeName;
        }

        /// <summary>
        /// Creates a DataType for a collection of the given type.
        /// </summary>
        /// <param name="elementType">The DataType of the elements of the collection.</param>
        /// <returns>A new DataType for a collection.</returns>
        public static DataType Collection(DataType elementType) => new DataType($"Collection({elementType})");

        /// <summary>
        /// Defines implicit conversion from string to DataType.
        /// </summary>
        /// <param name="value">string to convert.</param>
        /// <returns>The string as a DataType.</returns>
        public static implicit operator DataType(string value) => new DataType(value);

        /// <summary>
        /// Defines explicit conversion from DataType to string.
        /// </summary>
        /// <param name="dataType">DataType to convert.</param>
        /// <returns>The DataType as a string.</returns>
        public static explicit operator string(DataType dataType) => dataType.ToString();

        /// <summary>
        /// Compares two DataType values for equality.
        /// </summary>
        /// <param name="lhs">The first DataType to compare.</param>
        /// <param name="rhs">The second DataType to compare.</param>
        /// <returns>true if the DataType objects are equal or are both null; false otherwise.</returns>
        public static bool operator ==(DataType lhs, DataType rhs) => Equals(lhs, rhs);

        /// <summary>
        /// Compares two DataType values for inequality.
        /// </summary>
        /// <param name="lhs">The first DataType to compare.</param>
        /// <param name="rhs">The second DataType to compare.</param>
        /// <returns>true if the DataType objects are not equal; false otherwise.</returns>
        public static bool operator !=(DataType lhs, DataType rhs) => !Equals(lhs, rhs);

        /// <summary>
        /// Compares the DataType for equality with another DataType.
        /// </summary>
        /// <param name="other">The DataType with which to compare.</param>
        /// <returns><c>true</c> if the DataType objects are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(DataType other) => _value == other._value;

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj) => obj is DataType ? Equals((DataType)obj) : false;

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode() => _value.GetHashCode();

        /// <summary>
        /// Returns a string representation of the DataType.
        /// </summary>
        /// <returns>The DataType as a string.</returns>
        public override string ToString() => _value;

        /// <summary>
        /// The names of all of the data types as plain strings.
        /// </summary>
        public static class AsString
        {
            /// <summary>
            /// Indicates that a field contains a string.
            /// </summary>
            public const string String = "Edm.String";

            /// <summary>
            /// Indicates that a field contains a 32-bit signed integer.
            /// </summary>
            public const string Int32 = "Edm.Int32";

            /// <summary>
            /// Indicates that a field contains a 64-bit signed integer.
            /// </summary>
            public const string Int64 = "Edm.Int64";

            /// <summary>
            /// Indicates that a field contains an IEEE double-precision floating point number.
            /// </summary>
            public const string Double = "Edm.Double";

            /// <summary>
            /// Indicates that a field contains a Boolean value (true or false).
            /// </summary>
            public const string Boolean = "Edm.Boolean";

            /// <summary>
            /// Indicates that a field contains a date/time value, including timezone information.
            /// </summary>
            public const string DateTimeOffset = "Edm.DateTimeOffset";

            /// <summary>
            /// Indicates that a field contains a geo-location in terms of longitude and latitude.
            /// </summary>
            public const string GeographyPoint = "Edm.GeographyPoint";

            /// <summary>
            /// Indicates that a field contains one or more complex objects that in turn have sub-fields of other types.
            /// </summary>
            public const string Complex = "Edm.ComplexType";
        }
    }
}
