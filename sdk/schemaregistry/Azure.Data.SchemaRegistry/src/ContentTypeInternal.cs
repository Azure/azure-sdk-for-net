// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Data.SchemaRegistry
{
    /// <summary>
    /// Properties for a SchemaRegistry schema.
    /// </summary>
    [CodeGenModel("SchemaFormat")]
    internal readonly partial struct ContentTypeInternal
    {
        /// <summary> application/json; serialization=Avro. </summary>
        [CodeGenMember("ApplicationJsonSerializationAvro")]
        public static ContentTypeInternal Avro { get; } = new ContentTypeInternal(AvroValue);

        /// <summary> application/json; serialization=json. </summary>
        [CodeGenMember("ApplicationJsonSerializationJson")]
        public static ContentTypeInternal Json { get; } = new ContentTypeInternal(JsonValue);

        /// <summary> text/plain; charset=utf-8. </summary>
        [CodeGenMember("TextPlainCharsetUtf8")]
        public static ContentTypeInternal Custom { get; } = new ContentTypeInternal(CustomValue);

        internal SchemaFormat ToSchemaFormat()
        {
            var isJsonTemp = _value.Contains("+json");
            if (isJsonTemp)
            {
                return SchemaFormat.Json;
            }
            switch (_value)
            {
                case AvroValue:
                    return SchemaFormat.Avro;
                case JsonValue:
                    return SchemaFormat.Json;
                default:
                    return SchemaFormat.Custom;
            }
        }
    }
}
