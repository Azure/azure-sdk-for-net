// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.PrivateDns.Models;
using CodeGenSuppressAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute;

namespace Azure.ResourceManager.PrivateDns
{
    [CodeGenSuppressAttribute("VirtualNetworkIdId")]
    public partial class VirtualNetworkLinkData
    {
        /// <summary> The reference of the virtual network. </summary>
        [WirePath("properties.virtualNetwork.id")]
        public ResourceIdentifier VirtualNetworkId
        {
            get
            {
                string id = Properties is null ? default : Properties.VirtualNetworkIdId;
                return id is null ? default : new ResourceIdentifier(id);
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new VirtualNetworkLinkProperties();
                }
                Properties.VirtualNetworkIdId = value?.ToString();
            }
        }
    }
}
