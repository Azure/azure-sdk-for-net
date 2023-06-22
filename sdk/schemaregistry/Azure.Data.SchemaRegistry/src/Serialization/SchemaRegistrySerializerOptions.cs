// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Serialization;

namespace Azure.Data.SchemaRegistry.Serialization
{
    /// <summary>
    /// The options to use when configuring the <see cref="SchemaRegistrySerializer"/>.
    /// </summary>
    public class SchemaRegistrySerializerOptions
    {
        private static ObjectSerializer s_jsonObjectSerializer = new JsonObjectSerializer();

        /// <summary>
        /// Allows the user to pass in an <see cref="ObjectSerializer"/> with configured options.
        /// The default is a <see cref="JsonObjectSerializer"/>.
        /// </summary>
        public ObjectSerializer Serializer { get; set; } = s_jsonObjectSerializer;

        /// <summary>
        /// The format of the schema to use for serialization. The default is JSON. If this is changed, then
        /// a custom <see cref="ObjectSerializer"/> must be supplied.
        /// </summary>
        public SchemaFormat Format { get; set; } = SchemaFormat.Json;

        internal SchemaRegistrySerializerOptions Clone()
        {
            return new()
            {
                Serializer = Serializer,
                Format = Format
            };
        }
    }
}
