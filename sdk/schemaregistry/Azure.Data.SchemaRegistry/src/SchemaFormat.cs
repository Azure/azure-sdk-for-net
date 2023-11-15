// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Security.Cryptography;

namespace Azure.Data.SchemaRegistry
{
    /// <summary> The SerializationType. </summary>
    public readonly partial struct SchemaFormat : IEquatable<SchemaFormat>
    {
        private readonly string _value;

        private const string AvroValue = "Avro";
        private const string JsonValue = "JSON";
        private const string CustomValue = "Custom";
        private const string ProtobufValue = "Protobuf";

        private const string AvroContentType = "Avro";
        private const string JsonContentType = "Json";
        private const string ProtobufContentType = "vnd.ms.protobuf";

        /// <summary> Initializes a new instance of <see cref="SchemaFormat"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SchemaFormat(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary> Avro Serialization schema type. </summary>
        public static SchemaFormat Avro { get; } = new SchemaFormat(AvroValue);

        /// <summary> JSON Serialization schema type. </summary>
        public static SchemaFormat Json { get; } = new SchemaFormat(JsonValue);

        /// <summary> Custom Serialization schema type. </summary>
        public static SchemaFormat Custom { get; } = new SchemaFormat(CustomValue);

        /// <summary> Protobuf Serialization schema type. </summary>
        public static SchemaFormat Protobuf { get; } = new SchemaFormat(ProtobufValue);

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

        internal ContentType ToContentType()
        {
            switch (_value)
            {
                case AvroValue:
                    return ContentType.Avro;
                case JsonValue:
                    return ContentType.Json;
                case ProtobufValue:
                    return ContentType.Protobuf;
                default:
                    return ContentType.Custom;
            }
        }

        internal static SchemaFormat FromContentType(string contentTypeValue)
        {
            var contentTypeParameterValue = contentTypeValue.Split('=');
            var contentSubType = contentTypeValue.Split('/');
            if (contentTypeParameterValue.Length > 1)
            {
                switch (contentTypeParameterValue[1])
                {
                    case AvroContentType:
                        return SchemaFormat.Avro;
                    case JsonContentType:
                        return SchemaFormat.Json;
                    default:
                        break;
                }
            }
            return contentSubType[1] switch
            {
                ProtobufContentType => SchemaFormat.Protobuf,
                _ => SchemaFormat.Custom,
            };
        }
    }
}
