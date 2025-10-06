// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.Agents.Persistent
{
    public partial class BingCustomSearchToolParameters
    {
        public BingCustomSearchToolParameters( string connectionId, string instanceName )
        {
            // Additional initialization logic if needed
            var bingCustomSearchConfiguration = new BingCustomSearchConfiguration
            {
                ConnectionId = connectionId,
                InstanceName = instanceName
            };

            this.SearchConfigurations = new List<BingCustomSearchConfiguration> { bingCustomSearchConfiguration };
        }
    }
}
