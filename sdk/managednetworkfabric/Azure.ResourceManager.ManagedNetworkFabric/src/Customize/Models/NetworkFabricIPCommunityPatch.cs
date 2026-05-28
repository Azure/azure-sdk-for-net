// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // 1. The TypeSpec patch model now keeps the Swagger-compatible TagsUpdate base and the generated
    //    C# patch shape is renamed to NetworkFabricIPCommunityPatchContent.
    // 2. We keep this obsolete compatibility type with the shipped NetworkFabricIPCommunityPatch name and original
    //    NetworkRackPatch inheritance, then adapt it to the generated content type at operation boundaries.
    // 3. Without this custom code, the public NetworkFabricIPCommunityPatch type and Update overloads that accept it would be
    //    removed or would have the wrong base type, breaking existing callers.
    /// <summary> The IP Community patch resource definition. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This compatibility type is obsolete and will be removed in a future version. Use NetworkFabricIPCommunityPatchContent instead.")]
    public partial class NetworkFabricIPCommunityPatch : NetworkRackPatch
    {
        /// <summary> Initializes a new instance of <see cref="NetworkFabricIPCommunityPatch"/>. </summary>
        public NetworkFabricIPCommunityPatch()
        {
        }

        /// <summary> Initializes a new instance of <see cref="NetworkFabricIPCommunityPatch"/>. </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <param name="properties"> IP Community patchable properties. </param>
        internal NetworkFabricIPCommunityPatch(IDictionary<string, string> tags, IDictionary<string, BinaryData> additionalBinaryDataProperties, IpCommunityPatchableProperties properties) : base(tags, additionalBinaryDataProperties)
        {
            Properties = properties;
        }

        /// <summary> IP Community patchable properties. </summary>
        internal IpCommunityPatchableProperties Properties { get; set; }

        /// <summary> List of IP Community Rules. </summary>
        public IList<IPCommunityRule> IPCommunityRules
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new IpCommunityPatchableProperties();
                }
                return Properties.IPCommunityRules;
            }
        }
    }
}
