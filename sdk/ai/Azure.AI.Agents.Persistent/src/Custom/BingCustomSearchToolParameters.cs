// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.Agents.Persistent
{
    public partial class BingCustomSearchToolParameters
    {
        /// <summary> Initializes a new instance of the <see cref="BingCustomSearchToolParameters"/> class. </summary>
        /// <param name="connectionId"> The connection identifier for the Bing Custom Search instance. </param>
        /// <param name="instanceName"> The name of the Bing Custom Search instance. </param>
        public BingCustomSearchToolParameters(string connectionId, string instanceName)
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
