// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // 1. The TypeSpec patch model now keeps the Swagger-compatible TagsUpdate base and the generated
    //    C# patch shape is renamed to NetworkTapPatchContent.
    // 2. We keep this obsolete compatibility type with the shipped NetworkTapPatch name and original
    //    NetworkRackPatch inheritance, then adapt it to the generated content type at operation boundaries.
    // 3. Without this custom code, the public NetworkTapPatch type and Update overloads that accept it would be
    //    removed or would have the wrong base type, breaking existing callers.
    /// <summary> The NetworkFabric resource definition. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This compatibility type is obsolete and will be removed in a future version. Use NetworkTapPatchContent instead.")]
    public partial class NetworkTapPatch : NetworkRackPatch
    {
        /// <summary> Initializes a new instance of <see cref="NetworkTapPatch"/>. </summary>
        public NetworkTapPatch()
        {
        }

        /// <summary> Initializes a new instance of <see cref="NetworkTapPatch"/>. </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <param name="properties"> NetworkTap resource patch properties. </param>
        /// <param name="identity"> The managed service identities assigned to this resource. </param>
        internal NetworkTapPatch(IDictionary<string, string> tags, IDictionary<string, BinaryData> additionalBinaryDataProperties, NetworkTapPatchProperties properties, NetworkFabricManagedServiceIdentityPatch identity) : base(tags, additionalBinaryDataProperties)
        {
            Properties = properties;
            Identity = identity;
        }

        /// <summary> NetworkTap resource patch properties. </summary>
        internal NetworkTapPatchProperties Properties { get; set; }

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
                    Properties = new NetworkTapPatchProperties();
                }
                Properties.Annotation = value;
            }
        }

        /// <summary> Polling type. </summary>
        public NetworkTapPollingType? PollingType
        {
            get
            {
                return Properties is null ? default : Properties.PollingType;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new NetworkTapPatchProperties();
                }
                Properties.PollingType = value;
            }
        }

        /// <summary> List of destination properties to send the filter traffic. </summary>
        public IList<NetworkTapPatchableParametersDestinationsItem> Destinations
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new NetworkTapPatchProperties();
                }
                return Properties.Destinations;
            }
        }
    }
}
