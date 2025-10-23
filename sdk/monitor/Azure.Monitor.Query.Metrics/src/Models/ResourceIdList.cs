// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Monitor.Query.Metrics.Models
{
    /// <summary> The comma separated list of resource IDs to query metrics for. </summary>
    internal partial class ResourceIdList
    {
        /// <summary> Initializes a new instance of ResourceIdList. </summary>
        public ResourceIdList(List<string> resourceIds)
        {
            Resourceids = new ChangeTrackingList<ResourceIdentifier>();
            for (int i = 0; i < resourceIds.Count; i++)
            {
                Resourceids.Add(new ResourceIdentifier(resourceIds[i]));
            }
        }
    }
}
