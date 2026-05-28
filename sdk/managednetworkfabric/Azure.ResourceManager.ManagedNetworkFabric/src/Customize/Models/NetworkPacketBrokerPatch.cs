// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    /// <summary> The NetworkPacketBroker patch resource definition. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This compatibility type is obsolete and will be removed in a future version. Use NetworkPacketBrokerPatchContent instead.")]
    public partial class NetworkPacketBrokerPatch : NetworkRackPatch
    {
        /// <summary> Initializes a new instance of <see cref="NetworkPacketBrokerPatch"/>. </summary>
        public NetworkPacketBrokerPatch()
        {
        }

        /// <summary> Initializes a new instance of <see cref="NetworkPacketBrokerPatch"/>. </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <param name="identity"> The managed service identities assigned to this resource. </param>
        internal NetworkPacketBrokerPatch(IDictionary<string, string> tags, IDictionary<string, BinaryData> additionalBinaryDataProperties, NetworkFabricManagedServiceIdentityPatch identity) : base(tags, additionalBinaryDataProperties)
        {
            Identity = identity;
        }

        /// <summary> The managed service identities assigned to this resource. </summary>
        public NetworkFabricManagedServiceIdentityPatch Identity { get; set; }
    }
}
