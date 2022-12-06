// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Data.SchemaRegistry
{
    /// <summary>
    /// Properties for a SchemaRegistry schema.
    /// </summary>
    public class SchemaProperties
    {
        internal SchemaProperties(SchemaFormat format, string schemaId, string groupName, string name, int version)
        {
            Id = schemaId;
            Format = format;
            GroupName = groupName;
            Name = name;
            Version = version;
        }

        /// <summary>
        /// The schema ID that uniquely identifies a schema in the registry namespace.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Serialization type for the schema being stored.
        /// </summary>
        public SchemaFormat Format { get; }

        /// <summary>
        /// The group name for the schema.
        /// </summary>
        public string GroupName { get; }

        /// <summary>
        /// The name of the schema.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The version of the schema.
        /// </summary>
        public int Version { get; }
    }
}
