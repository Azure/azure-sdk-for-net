// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> List of virtual router peer routes. </summary>
    [Obsolete("This class is obsolete and will be removed in a future release", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class PeerRouteList
    {
        /// <summary> Initializes a new instance of PeerRouteList. </summary>
        internal PeerRouteList()
        {
            Value = new ChangeTrackingList<PeerRoute>();
        }

        /// <summary> Initializes a new instance of PeerRouteList. </summary>
        /// <param name="value"> List of peer routes. </param>
        internal PeerRouteList(IReadOnlyList<PeerRoute> value)
        {
            Value = value;
        }

        /// <summary> List of peer routes. </summary>
        public IReadOnlyList<PeerRoute> Value { get; }
    }
}
