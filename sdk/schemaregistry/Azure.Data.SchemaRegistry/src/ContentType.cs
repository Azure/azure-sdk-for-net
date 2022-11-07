// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Data.SchemaRegistry
{
    /// <summary> The SerializationType. </summary>
    [CodeGenModel("ContentType")]
    public readonly partial struct ContentType : IEquatable<ContentType>
    {
        private readonly string _value;

        /// <summary> application/json; serialization=Avro. </summary>
        [CodeGenMember("ApplicationJsonSerializationAvroValue")]
        public static ContentType Avro { get; }

        /// <summary> application/json; serialization=json. </summary>
        [CodeGenMember("ApplicationJsonSerializationJsonValue")]
        public static ContentType Json { get; }

        /// <summary> text/plain; charset=utf-8. </summary>
        [CodeGenMember("TextPlainCharsetUtf8Value")]
        public static ContentType Custom { get; }

        /// <summary>
        /// Returns the format of this content type.
        /// </summary>
        /// <returns></returns>
        public SchemaFormat ToSchemaFormat()
        {
            switch (_value)
            {
                case ApplicationJsonSerializationAvroValue:
                    return SchemaFormat.Avro;
                case ApplicationJsonSerializationJsonValue:
                    return SchemaFormat.Json;
                default:
                    return SchemaFormat.Custom;
            }
        }

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ContentType other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ContentType other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
