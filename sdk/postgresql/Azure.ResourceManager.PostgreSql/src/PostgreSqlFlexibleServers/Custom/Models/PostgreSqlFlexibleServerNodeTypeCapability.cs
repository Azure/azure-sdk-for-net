// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    /// <summary> node type capability. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class PostgreSqlFlexibleServerNodeTypeCapability
    {
        private readonly IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of PostgreSqlFlexibleServerNodeTypeCapability. </summary>
        internal PostgreSqlFlexibleServerNodeTypeCapability()
        {
        }

        /// <summary> Initializes a new instance of PostgreSqlFlexibleServerNodeTypeCapability. </summary>
        /// <param name="name"> note type name. </param>
        /// <param name="nodeType"> note type. </param>
        /// <param name="status"> The status. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal PostgreSqlFlexibleServerNodeTypeCapability(string name, string nodeType, string status, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            NodeType = nodeType;
            Status = status;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> note type name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("name")]
        public string Name { get; }
        /// <summary> note type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("nodeType")]
        public string NodeType { get; }
        /// <summary> The status. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("status")]
        public string Status { get; }
    }
}
