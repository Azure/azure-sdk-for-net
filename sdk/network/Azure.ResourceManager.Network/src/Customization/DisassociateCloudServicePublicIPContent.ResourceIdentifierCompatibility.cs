// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    public partial class DisassociateCloudServicePublicIPContent
    {
        /// <summary> ARM ID of the Standalone Public IP to associate. </summary>
        [WirePath("publicIpArmId")]
        public ResourceIdentifier PublicIPArmId => PublicIpArmId;
    }
}
