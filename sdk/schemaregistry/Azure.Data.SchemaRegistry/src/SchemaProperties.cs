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

        internal SchemaProperties(string content, string location, SerializationType xSchemaType, string xSchemaId, int? xSchemaVersion)
        {
            Content = content;
            Id = xSchemaId;
            var groupSplit = location.Split(s_groupSplitter, StringSplitOptions.None)[1];
            var slashSplit = groupSplit.Split(Slash);
            Name = slashSplit[2];
            GroupName = slashSplit[0];
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
        /// The name of the schema.
        /// </summary>
        internal string Name { get; }

        /// <summary>
        /// The group name of the schema.
        /// </summary>
        internal string GroupName { get; }

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
