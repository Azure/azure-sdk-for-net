// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    /// <summary> node type capability. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class PostgreSqlFlexibleServerNodeTypeCapability
    {
        /// <summary> Initializes a new instance of PostgreSqlFlexibleServerNodeTypeCapability. </summary>
        internal PostgreSqlFlexibleServerNodeTypeCapability()
        {
        }

        /// <summary> Initializes a new instance of PostgreSqlFlexibleServerNodeTypeCapability. </summary>
        /// <param name="name"> note type name. </param>
        /// <param name="nodeType"> note type. </param>
        /// <param name="status"> The status. </param>
        internal PostgreSqlFlexibleServerNodeTypeCapability(string name, string nodeType, string status)
        {
            Name = name;
            NodeType = nodeType;
            Status = status;
        }

        /// <summary> note type name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Name { get; }
        /// <summary> note type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string NodeType { get; }
        /// <summary> The status. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Status { get; }
    }
}
