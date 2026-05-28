// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;

namespace Azure.ResourceManager.ServiceFabricManagedClusters.Models
{
    /// <summary> Parameters for Node type action. </summary>
    public partial class NodeTypeActionContent
    {
        /// <summary> Initializes a new instance of NodeTypeActionContent. </summary>
        /// <param name="nodes"> List of node names from the node type. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="nodes"/> is null. </exception>
        [Obsolete("This constructor is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NodeTypeActionContent(IEnumerable<string> nodes)
        {
        }
    }
}
