// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.Agents.Persistent
{
    /// <summary> The input definition information for a file search tool as used to configure an agent. </summary>
    public partial class FileSearchToolDefinition : ToolDefinition
    {
        /// <summary> Initializes a new instance of <see cref="FileSearchToolDefinition"/>. </summary>
        public FileSearchToolDefinition()
        {
            Type = "file_search";
        }

        /// <summary> Initializes a new instance of <see cref="FileSearchToolDefinition"/>. </summary>
        /// <param name="type"> The object type. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="fileSearch"> Options overrides for the file search tool. </param>
        internal FileSearchToolDefinition(string type, IDictionary<string, BinaryData> serializedAdditionalRawData, FileSearchToolDefinitionDetails fileSearch) : base(type, serializedAdditionalRawData)
        {
            FileSearch = fileSearch;
        }

        /// <summary> Options overrides for the file search tool. </summary>
        public FileSearchToolDefinitionDetails FileSearch { get; set; }
    }
}
