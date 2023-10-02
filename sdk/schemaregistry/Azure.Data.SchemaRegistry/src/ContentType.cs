// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Data.SchemaRegistry
{
    /// <summary> The SerializationType. </summary>
    [CodeGenModel("ContentType")]
    internal readonly partial struct ContentType : IEquatable<ContentType>
    {
        private readonly string _value;

        /// <summary> application/json; serialization=Avro. </summary>
        [CodeGenMember("ApplicationJsonSerializationAvro")]
        public static ContentType Avro { get; } = new ContentType(AvroValue);

        /// <summary> application/json; serialization=json. </summary>
        [CodeGenMember("ApplicationJsonSerializationJson")]
        public static ContentType Json { get; } = new ContentType(JsonValue);

        /// <summary> text/plain; charset=utf-8. </summary>
        [CodeGenMember("TextPlainCharsetUtf8")]
        public static ContentType Custom { get; } = new ContentType(CustomValue);

        /// <summary> text/vnd.ms.protobuf. </summary>
        [CodeGenMember("TextVndMsProtobuf")]
        public static ContentType Protobuf { get; } = new ContentType(ProtobufValue);

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
