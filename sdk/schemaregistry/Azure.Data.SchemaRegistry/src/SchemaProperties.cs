// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Data.SchemaRegistry.Models;

namespace Azure.Data.SchemaRegistry
{
    /// <summary>
    /// Properties for a SchemaRegistry schema.
    /// </summary>
    public class SchemaProperties
    {
        private const char Slash = '/';
        private static readonly string[] s_groupSplitter = { "/$schemagroups/" };

        internal SchemaProperties(string location, SerializationType xSchemaType, string xSchemaId, int? xSchemaVersion)
        {
            Id = xSchemaId;
            var groupSplit = location.Split(s_groupSplitter, StringSplitOptions.None)[1];
            var slashSplit = groupSplit.Split(Slash);
            Name = slashSplit[2];
            GroupName = slashSplit[0];
            Type = xSchemaType;
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
        public SerializationType Type { get; }

        /// <summary>
        /// Version of the schema.
        /// </summary>
        public int? Version { get; }
    }
}
