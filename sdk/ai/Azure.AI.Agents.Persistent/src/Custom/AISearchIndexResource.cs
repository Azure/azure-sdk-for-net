// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Agents.Persistent
{
    public partial class AISearchIndexResource
    {
        /// <summary> An index connection id in an IndexResource attached to this agent. </summary>
        public string IndexConnectionId { get;}
        /// <summary> The name of an index in an IndexResource attached to this agent. </summary>
        public string IndexName { get; }
        public int? TopK { get; }
        /// <summary> filter string for search resource. </summary>
        public string Filter { get; }
        /// <summary> Index asset id for search resource. </summary>
        public string IndexAssetId { get; }
    }
}
