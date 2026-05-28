// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // 1. The TypeSpec patch model now keeps the Swagger-compatible TagsUpdate base and the generated
    //    C# patch shape is renamed to NetworkPacketBrokerPatchContent.
    // 2. We keep this obsolete compatibility type with the shipped NetworkPacketBrokerPatch name and original
    //    NetworkRackPatch inheritance, then adapt it to the generated content type at operation boundaries.
    // 3. Without this custom code, the public NetworkPacketBrokerPatch type and Update overloads that accept it would be
    //    removed or would have the wrong base type, breaking existing callers.
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
