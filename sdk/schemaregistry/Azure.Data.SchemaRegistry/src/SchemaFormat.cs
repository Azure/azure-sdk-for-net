// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Data.SchemaRegistry
{
    /// <summary> The SerializationType. </summary>
    public readonly partial struct SchemaFormat : IEquatable<SchemaFormat>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="SchemaFormat"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SchemaFormat(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
            ContentType = $"application/json; serialization={_value}";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaFormat"/> struct.
        /// </summary>
        /// <param name="contentType"></param>
        public SchemaFormat(ContentType contentType)
        {
            _value = contentType.ToString() ?? throw new ArgumentNullException(nameof(contentType));
            ContentType = contentType.ToString();
        }

        private const string AvroValue = "Avro";

        /// <summary> Avro Serialization schema type. </summary>
        public static SchemaFormat Avro { get; } = new SchemaFormat(AvroValue);
        /// <summary> Json Serialization schema type. </summary>
        public static SchemaFormat Json { get; } = new SchemaFormat(Core.ContentType.ApplicationJson);
        /// <summary> Custom Serialization schema type. </summary>
        public static SchemaFormat Custom { get; } = new SchemaFormat(Core.ContentType.ApplicationOctetStream);
        /// <summary> Determines if two <see cref="SchemaFormat"/> values are the same. </summary>
        public static bool operator ==(SchemaFormat left, SchemaFormat right) => left.Equals(right);
        /// <summary> Determines if two <see cref="SchemaFormat"/> values are not the same. </summary>
        public static bool operator !=(SchemaFormat left, SchemaFormat right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="SchemaFormat"/>. </summary>
        public static implicit operator SchemaFormat(string value) => new SchemaFormat(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SchemaFormat other && Equals(other);
        /// <inheritdoc />
        public bool Equals(SchemaFormat other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;

        internal string ContentType { get; }
    }
}
