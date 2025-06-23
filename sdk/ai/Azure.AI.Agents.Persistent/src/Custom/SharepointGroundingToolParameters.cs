// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.Agents.Persistent
{
    public partial class SharepointGroundingToolParameters
    {
        public SharepointGroundingToolParameters( string connectionId )
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
