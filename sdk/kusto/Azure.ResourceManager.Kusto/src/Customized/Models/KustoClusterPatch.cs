// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Kusto.Models
{
    public partial class KustoClusterPatch
    {
        // ClusterProperties.uri is shared by Cluster and ClusterUpdate; @@clientName renamed it to ClusterUri
        // (matching KustoClusterData), but the previous AutoRest SDK exposed it as `Uri` on the patch model.
        /// <summary> The cluster URI. </summary>
        public Uri Uri => ClusterUri;
    }
}
