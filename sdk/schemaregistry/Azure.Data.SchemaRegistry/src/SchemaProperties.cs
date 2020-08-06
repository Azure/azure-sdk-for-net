// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Data.SchemaRegistry
{
    /// <summary>
    /// Properties for a SchemaRegistry schema.
    /// </summary>
    public class SchemaProperties
    {
        internal SchemaProperties(string location, string xSerialization, string xSchemaId, int? xSchemaVersion)
        {
            Id = xSchemaId;
            Name = location;  //TODO: Parse name from location
            GroupName = null; //TODO: Parse group name from location
            Type = xSerialization;
            Version = xSchemaVersion;
        }

        /// <summary>
        /// The schema ID that uniquely identifies a schema in the registry namespace.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// The name of the schema.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The group name of the schema.
        /// </summary>
        public string GroupName { get; }

        /// <summary>
        /// Serialization type for the schema being stored.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Version of the schema.
        /// </summary>
        public int? Version { get; }
    }
}
