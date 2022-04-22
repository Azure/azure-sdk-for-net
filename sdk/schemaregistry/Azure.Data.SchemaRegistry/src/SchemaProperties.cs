// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Data.SchemaRegistry
{
    /// <summary>
    /// Properties for a SchemaRegistry schema.
    /// </summary>
    public class SchemaProperties
    {
        internal SchemaProperties(SchemaFormat format, string schemaId)
        {
            Id = schemaId;
            Format = format;
        }

        /// <summary>
        /// The schema ID that uniquely identifies a schema in the registry namespace.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Serialization type for the schema being stored.
        /// </summary>
        public SchemaFormat Format { get; }
    }
}
