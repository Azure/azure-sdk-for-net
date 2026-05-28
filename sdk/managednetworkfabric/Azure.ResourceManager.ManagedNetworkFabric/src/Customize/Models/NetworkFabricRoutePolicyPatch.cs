// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    // 1. The TypeSpec patch model now keeps the Swagger-compatible TagsUpdate base and the generated
    //    C# patch shape is renamed to NetworkFabricRoutePolicyPatchContent.
    // 2. We keep this obsolete compatibility type with the shipped NetworkFabricRoutePolicyPatch name and original
    //    NetworkRackPatch inheritance, then adapt it to the generated content type at operation boundaries.
    // 3. Without this custom code, the public NetworkFabricRoutePolicyPatch type and Update overloads that accept it would be
    //    removed or would have the wrong base type, breaking existing callers.
    /// <summary> The Route Policy patch resource definition. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This compatibility type is obsolete and will be removed in a future version. Use NetworkFabricRoutePolicyPatchContent instead.")]
    public partial class NetworkFabricRoutePolicyPatch : NetworkRackPatch
    {
        /// <summary> Initializes a new instance of <see cref="NetworkFabricRoutePolicyPatch"/>. </summary>
        public NetworkFabricRoutePolicyPatch()
        {
        }

        /// <summary> Initializes a new instance of <see cref="NetworkFabricRoutePolicyPatch"/>. </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <param name="properties"> The RoutePolicy patchable properties. </param>
        internal NetworkFabricRoutePolicyPatch(IDictionary<string, string> tags, IDictionary<string, BinaryData> additionalBinaryDataProperties, RoutePolicyPatchableProperties properties) : base(tags, additionalBinaryDataProperties)
        {
            Properties = properties;
        }

        /// <summary> The RoutePolicy patchable properties. </summary>
        internal RoutePolicyPatchableProperties Properties { get; set; }

        /// <summary> Default action that needs to be applied when no condition is matched. Example: Permit | Deny. </summary>
        public CommunityActionType? DefaultAction
        {
            get
            {
                return Properties is null ? default : Properties.DefaultAction;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new RoutePolicyPatchableProperties();
                }
                Properties.DefaultAction = value;
            }
        }

        /// <summary> Route Policy statements. </summary>
        public IList<RoutePolicyStatementProperties> Statements
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new RoutePolicyPatchableProperties();
                }
                return Properties.Statements;
            }
        }
    }
}
