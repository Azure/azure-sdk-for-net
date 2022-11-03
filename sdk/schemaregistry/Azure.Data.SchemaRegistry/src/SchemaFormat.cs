// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Data.SchemaRegistry
{
    /// <summary>
    /// Properties for a SchemaRegistry schema.
    /// </summary>
    [CodeGenModel("SchemaFormat")]
    public readonly partial struct SchemaFormat
    {
        private const string AvroValue = "Avro";
        private const string JsonValue = "JSON";
        private const string CustomValue = "Custom";

        /// <summary> application/json; serialization=Avro. </summary>
        [CodeGenMember("ApplicationJsonSerializationAvro")]
        public static SchemaFormat Avro { get; } = new SchemaFormat(AvroValue);

        /// <summary> application/json; serialization=Json. </summary>
        [CodeGenMember("ApplicationJsonSerializationJson")]
        public static SchemaFormat Json { get; } = new SchemaFormat(JsonValue);

        /// <summary> text/plain; charset=utf-8. </summary>
        [CodeGenMember("TextPlainCharsetUtf8")]
        public static SchemaFormat Custom { get; } = new SchemaFormat(CustomValue);
    }
}
