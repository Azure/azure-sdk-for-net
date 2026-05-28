// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // 1. The TypeSpec patch model now keeps the Swagger-compatible TagsUpdate base and the generated
    //    C# patch shape is renamed to NetworkFabricNeighborGroupPatchContent.
    // 2. We keep this obsolete compatibility type with the shipped NetworkFabricNeighborGroupPatch name and original
    //    NetworkRackPatch inheritance, then adapt it to the generated content type at operation boundaries.
    // 3. Without this custom code, the public NetworkFabricNeighborGroupPatch type and Update overloads that accept it would be
    //    removed or would have the wrong base type, breaking existing callers.
    /// <summary> The Neighbor Group Patch definition. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This compatibility type is obsolete and will be removed in a future version. Use NetworkFabricNeighborGroupPatchContent instead.")]
    public partial class NetworkFabricNeighborGroupPatch : NetworkRackPatch
    {
        /// <summary> Initializes a new instance of <see cref="NetworkFabricNeighborGroupPatch"/>. </summary>
        public NetworkFabricNeighborGroupPatch()
        {
        }

        /// <summary> Initializes a new instance of <see cref="NetworkFabricNeighborGroupPatch"/>. </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <param name="properties"> Neighbor Group Patch properties. </param>
        /// <param name="identity"> The managed service identities assigned to this resource. </param>
        internal NetworkFabricNeighborGroupPatch(IDictionary<string, string> tags, IDictionary<string, BinaryData> additionalBinaryDataProperties, NeighborGroupPatchProperties properties, NetworkFabricManagedServiceIdentityPatch identity) : base(tags, additionalBinaryDataProperties)
        {
            Properties = properties;
            Identity = identity;
        }

        /// <summary> Neighbor Group Patch properties. </summary>
        internal NeighborGroupPatchProperties Properties { get; set; }

        /// <summary> The managed service identities assigned to this resource. </summary>
        public NetworkFabricManagedServiceIdentityPatch Identity { get; set; }

        /// <summary> Switch configuration description. </summary>
        public string Annotation
        {
            get
            {
                return Properties is null ? default : Properties.Annotation;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NeighborGroupPatchProperties();
                }
                Properties.Annotation = value;
            }
        }

        /// <summary> An array of destination IPv4 Addresses or IPv6 Addresses. </summary>
        public NeighborGroupDestination Destination
        {
            get
            {
                return Properties is null ? default : Properties.Destination;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NeighborGroupPatchProperties();
                }
                Properties.Destination = value;
            }
        }
    }
}
