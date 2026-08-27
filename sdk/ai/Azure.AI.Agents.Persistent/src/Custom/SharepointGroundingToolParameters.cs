// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.Agents.Persistent
{
    public partial class SharepointGroundingToolParameters
    {
        /// <summary> Initializes a new instance of the <see cref="SharepointGroundingToolParameters"/> class. </summary>
        /// <param name="connectionId"> The connection identifier for the SharePoint grounding resource. </param>
        public SharepointGroundingToolParameters(string connectionId)
        {
            // Additional initialization logic if needed
            var toolConnection = new ToolConnection
            {
                ConnectionId = connectionId,
            };

            this.ConnectionList = new List<ToolConnection> { toolConnection };
        }
    }
}
