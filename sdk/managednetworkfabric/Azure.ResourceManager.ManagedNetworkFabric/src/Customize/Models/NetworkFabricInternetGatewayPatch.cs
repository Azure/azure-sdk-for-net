// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.ManagedNetworkFabric.Models
{
    /// <summary> The Internet Gateway patch resource definition. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This compatibility type is obsolete and will be removed in a future version. Use NetworkFabricInternetGatewayPatchContent instead.")]
    public partial class NetworkFabricInternetGatewayPatch : NetworkRackPatch
    {
        /// <summary> Initializes a new instance of <see cref="NetworkFabricInternetGatewayPatch"/>. </summary>
        public NetworkFabricInternetGatewayPatch()
        {
        }

        /// <summary> Initializes a new instance of <see cref="NetworkFabricInternetGatewayPatch"/>. </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <param name="properties"> Resource properties. </param>
        internal NetworkFabricInternetGatewayPatch(IDictionary<string, string> tags, IDictionary<string, BinaryData> additionalBinaryDataProperties, InternetGatewayPatchProperties properties) : base(tags, additionalBinaryDataProperties)
        {
            Properties = properties;
        }

        /// <summary> Resource properties. </summary>
        internal InternetGatewayPatchProperties Properties { get; set; }

        /// <summary> ARM Resource ID of the Internet Gateway Rule. </summary>
        public ResourceIdentifier InternetGatewayRuleId
        {
            get
            {
                return Properties is null ? default : Properties.InternetGatewayRuleId;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new InternetGatewayPatchProperties();
                }
                Properties.InternetGatewayRuleId = value;
            }
        }
    }
}
