// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    /// <summary> The Internet Gateway Rules patch resource definition. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This compatibility type is obsolete and will be removed in a future version. Use NetworkFabricInternetGatewayRulePatchContent instead.")]
    public partial class NetworkFabricInternetGatewayRulePatch : NetworkRackPatch
    {
        /// <summary> Initializes a new instance of <see cref="NetworkFabricInternetGatewayRulePatch"/>. </summary>
        public NetworkFabricInternetGatewayRulePatch()
        {
        }

        /// <summary> Initializes a new instance of <see cref="NetworkFabricInternetGatewayRulePatch"/>. </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        internal NetworkFabricInternetGatewayRulePatch(IDictionary<string, string> tags, IDictionary<string, BinaryData> additionalBinaryDataProperties) : base(tags, additionalBinaryDataProperties)
        {
        }
    }
}
