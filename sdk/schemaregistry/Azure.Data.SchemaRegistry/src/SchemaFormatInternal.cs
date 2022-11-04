// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Data.SchemaRegistry
{
    /// <summary>
    /// Properties for a SchemaRegistry schema.
    /// </summary>
    [CodeGenModel("SchemaFormat")]
    internal readonly partial struct SchemaFormatInternal
    {
        /// <summary> application/json; serialization=Avro. </summary>
        [CodeGenMember("ApplicationJsonSerializationAvro")]
        public static SchemaFormatInternal Avro { get; } = new SchemaFormatInternal(ApplicationJsonSerializationAvroValue);

        /// <summary> application/json; serialization=json. </summary>
        [CodeGenMember("ApplicationJsonSerializationJson")]
        public static SchemaFormatInternal Json { get; } = new SchemaFormatInternal(ApplicationJsonSerializationJsonValue);

        /// <summary> text/plain; charset=utf-8. </summary>
        [CodeGenMember("TextPlainCharsetUtf8")]
        public static SchemaFormatInternal Custom { get; } = new SchemaFormatInternal(TextPlainCharsetUtf8Value);

        internal SchemaFormat ToSchemaFormat()
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
    }
}
