// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Data.SchemaRegistry
{
    /// <summary>
    /// Properties for a SchemaRegistry schema.
    /// </summary>
    public class SchemaProperties
    {
        internal SchemaProperties(string content, string location, SerializationType xSchemaType, string xSchemaId, int? xSchemaVersion)
        {
            Content = content;
            Id = xSchemaId;
            Location = location;
            Type = xSchemaType;
            Version = xSchemaVersion ?? 0;
        }

        /// <summary>
        /// The schema ID that uniquely identifies a schema in the registry namespace.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// The schema content of the SchemaRegistry schema.
        /// </summary>
        public string Content { get; }

        /// <summary>
        /// The location of the schema.
        /// </summary>
        internal string Location { get; }

        /// <summary>
        /// Serialization type for the schema being stored.
        /// </summary>
        internal SerializationType Type { get; }

        /// <summary>
        /// Version of the schema.
        /// </summary>
        internal int Version { get; }
    }
}
