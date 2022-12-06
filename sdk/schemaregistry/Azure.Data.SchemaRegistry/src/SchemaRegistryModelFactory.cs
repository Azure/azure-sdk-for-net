// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Data.SchemaRegistry
{
    /// <summary>
    /// This class contains methods to create Schema Registry models for mocking purposes.
    /// </summary>
    public static class SchemaRegistryModelFactory
    {
        /// <summary>
        /// Constructs a SchemaProperties instance for mocking.
        /// </summary>
        /// <param name="format">The format for the schema.</param>
        /// <param name="schemaId">The ID of the schema.</param>
        /// <returns>A schemaProperties instance for mocking.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SchemaProperties SchemaProperties(SchemaFormat format, string schemaId) => SchemaProperties(format, schemaId, null, null, 1);

        /// <summary>
        /// Constructs a SchemaProperties instance for mocking.
        /// </summary>
        /// <param name="format">The format for the schema.</param>
        /// <param name="schemaId">The ID of the schema.</param>
        /// <param name="groupName">The group name for the schema.</param>
        /// <param name="name">The name of the schema.</param>
        /// <returns>A schemaProperties instance for mocking.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SchemaProperties SchemaProperties(SchemaFormat format, string schemaId, string groupName, string name) => new(format, schemaId, groupName, name, 1);

        /// <summary>
        /// Constructs a SchemaProperties instance for mocking.
        /// </summary>
        /// <param name="format">The format for the schema.</param>
        /// <param name="schemaId">The ID of the schema.</param>
        /// <param name="groupName">The group name for the schema.</param>
        /// <param name="name">The name of the schema.</param>
        /// <param name="version">The version of the schema.</param>
        /// <returns>A schemaProperties instance for mocking.</returns>
        public static SchemaProperties SchemaProperties(SchemaFormat format, string schemaId, string groupName, string name, int version) => new(format, schemaId, groupName, name, version);

        /// <summary>
        /// Constructs a SchemaRegistrySchema instance for mocking.
        /// </summary>
        /// <param name="properties">The properties for the schema.</param>
        /// <param name="definition">The defintion of the schema.</param>
        /// <returns>A SchemaRegistrySchema instance for mocking.</returns>
        public static SchemaRegistrySchema SchemaRegistrySchema(SchemaProperties properties, string definition) => new(properties, definition);
    }
}
