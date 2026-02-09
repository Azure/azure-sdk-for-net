// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Agents.Persistent
{
    public partial class MCPToolResource
    {
        /// <summary> Initializes a new instance of <see cref="MCPToolResource"/>. </summary>
        /// <param name="serverLabel"> The label for the MCP server. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="serverLabel"/> is null. </exception>
        public MCPToolResource(string serverLabel)
        {
            Argument.AssertNotNull(serverLabel, nameof(serverLabel));

            ServerLabel = serverLabel;
            Headers = new Dictionary<string, string>();
        }

        /// <summary>
        /// Adds or updates a header in the Headers dictionary.
        /// </summary>
        /// <param name="key">The header key.</param>
        /// <param name="value">The header value.</param>
        public void UpdateHeader(string key, string value)
        {
            Headers[key] = value;
        }

        /// <summary>
        /// Creates a new ToolResources instance with this MCPToolResource added to the Mcp collection.
        /// </summary>
        /// <returns>A new ToolResources instance containing this MCPToolResource.</returns>
        public ToolResources ToToolResources()
        {
            var toolResources = new ToolResources();
            toolResources.Mcp.Add(this);
            return toolResources;
        }

        /// <summary>
        /// Get or set the MCP approval.
        /// </summary>
        public MCPApproval RequireApproval {  get => MCPApproval.FromBinaryData(RequireApprovalInternal); set => RequireApprovalInternal = value?.ToBinaryData(); }

        [CodeGenMember("RequireApproval")]
        internal BinaryData RequireApprovalInternal { get; set; }
    }
}
