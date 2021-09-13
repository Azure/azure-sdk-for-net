// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Data.SchemaRegistry
{
    /// <summary>
    /// Represents a Schema Registry schema.
    /// </summary>
    public class SchemaRegistrySchema
    {
        internal SchemaRegistrySchema(SchemaProperties properties, string content)
        {
            Properties = properties;
            Content = content;
        }

        /// <summary>
        /// The properties of the SchemaRegistry schema.
        /// </summary>
        public SchemaProperties Properties { get; }

        /// <summary>
        /// The schema content of the SchemaRegistry schema.
        /// </summary>
        public string Content { get; }
    }
}