// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Xml.Schema;
using Azure.Core;

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

        // Temporary until autorest bug is fixed
        private const string AvroContentType = "application/json; serialization=Avro";
        private const string JsonContentType = "application/json; serialization=Json";
        private const string CustomContentType = "text/plain; charset=utf-8";
        private const string ProtobufContentType = "text/vnd.ms.protobuf";

        private const string AvroContentTypeValue = "Avro";
        private const string JsonContentTypeValue = "Json";
        private const string CustomContentTypeValue = "utf-8";
        private const string ProtobufContentTypeValue = "vnd.ms.protobuf";

        /// <summary> Initializes a new instance of <see cref="SchemaFormat"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        /// <remarks>
        /// If using a schema format that is unsupported by this client, upgrade to a
        /// version that supports the schema format.
        /// </remarks>
        public SchemaFormat(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
            ContentType = _value == CustomValue ? CustomContentType : $"application/json; serialization={value}";
        }

        private SchemaFormat(string value, string contentType)
        {
            _value = value;
            ContentType = contentType;
        }

        /// <summary> Avro Serialization schema type. </summary>
        public static SchemaFormat Avro { get; } = new SchemaFormat(AvroValue, AvroContentType);

        /// <summary> JSON Serialization schema type. </summary>
        public static SchemaFormat Json { get; } = new SchemaFormat(JsonValue, JsonContentType);

        /// <summary> Custom Serialization schema type. </summary>
        public static SchemaFormat Custom { get; } = new SchemaFormat(CustomValue, CustomContentType);

        ///// <summary> Protobuf Serialization schema type. </summary>
        //public static SchemaFormat Protobuf { get; } = new SchemaFormat(ProtobufValue);

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

        internal static SchemaFormat FromContentType(string contentTypeValue)
        {
            var contentTypeParameterValue = contentTypeValue.Split('=');
            if (contentTypeParameterValue.Length > 1)
            {
                switch (contentTypeParameterValue[1])
                {
                    case AvroContentTypeValue:
                        return Avro;
                    case JsonContentTypeValue:
                        return Json;
                    case CustomContentTypeValue:
                        return Custom;
                    default:
                        break;
                }
            }
            return new SchemaFormat(contentTypeValue);
        }
    }
}
