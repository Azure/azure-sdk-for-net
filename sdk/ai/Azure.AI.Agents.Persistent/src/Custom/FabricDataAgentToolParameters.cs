// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.Agents.Persistent
{
    public partial class FabricDataAgentToolParameters
    {
        /// <summary> Initializes a new instance of the <see cref="FabricDataAgentToolParameters"/> class. </summary>
        /// <param name="connectionId"> The connection identifier for the Fabric data agent. </param>
        public FabricDataAgentToolParameters(string connectionId)
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
