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
        /// <summary>
        /// Allows the user to pass in an <see cref="ObjectSerializer"/> with configured options.
        /// The default is a <see cref="JsonObjectSerializer"/>.
        /// </summary>
        public ObjectSerializer Serializer { get; set; } = new JsonObjectSerializer();

        /// <summary>
        /// The format of the schema to use for serialization. The default is JSON.
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
