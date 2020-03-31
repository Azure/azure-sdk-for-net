// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Search.Documents.Models
{
    [CodeGenModel("DataType")]
    public readonly partial struct DataType
    {
        private const string CollectionPrefix = "Collection(";

#pragma warning disable CA1720 // Identifier contains type name
        /// <summary>A <see cref="string"/> type.</summary>
        [CodeGenMember("EdmString")]
        public static DataType String { get; } = new DataType(StringValue);

        /// <summary>An <see cref="int"/> type, or something that can convert to an <see cref="int"/>.</summary>
        [CodeGenMember("EdmInt32")]
        public static DataType Int32 { get; } = new DataType(Int32Value);

        /// <summary>An <see cref="long"/> type, or something that can convert to an <see cref="long"/>.</summary>
        [CodeGenMember("EdmInt64")]
        public static DataType Int64 { get; } = new DataType(Int64Value);

        /// <summary>A <see cref="double"/> type, or something that can convert to a <see cref="double"/>.</summary>
        [CodeGenMember("EdmDouble")]
        public static DataType Double { get; } = new DataType(DoubleValue);
#pragma warning restore CA1720 // Identifier contains type name

        /// <summary>A <see cref="bool"/> type.</summary>
        [CodeGenMember("EdmBoolean")]
        public static DataType Boolean { get; } = new DataType(BooleanValue);

        /// <summary>A <see cref="System.DateTimeOffset"/> type, or <see cref="System.DateTime"/> converted to a <see cref="System.DateTimeOffset"/>.</summary>
        [CodeGenMember("EdmDateTimeOffset")]
        public static DataType DateTimeOffset { get; } = new DataType(DateTimeOffsetValue);

        /// <summary>A geographic point type.</summary>
        [CodeGenMember("EdmGeographyPoint")]
        public static DataType GeographyPoint { get; } = new DataType(GeographyPointValue);

        /// <summary>A complex type with child fields.</summary>
        [CodeGenMember("EdmComplexType")]
        public static DataType Complex { get; } = new DataType(ComplexValue);

        /// <summary>
        /// Gets a <see cref="DataType"/> representing a collection of <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type of collection.</param>
        /// <returns>A <see cref="DataType"/> representing a collection of <paramref name="type"/>.</returns>
        public static DataType Collection(DataType type) => type.IsCollection ? type : new DataType(string.Concat(CollectionPrefix, type._value, ")"));

        /// <summary>
        /// Gets a value indicating whether the <see cref="DataType"/> represents a collection.
        /// </summary>
        public bool IsCollection => _value.StartsWith(CollectionPrefix, StringComparison.InvariantCultureIgnoreCase);
    }
}
