// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Network.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declarations for generated members that intentionally hide inherited ARM members. </summary>
    [CodeGenSuppress("Name")]
    public partial class NetworkSecurityPerimeterLinkData
    {
        // The generated member intentionally preserves the service wire shape while hiding an inherited ARM member.
        // TODO: Remove this SDK-side workaround after https://github.com/Azure/azure-sdk-for-net/issues/60023 is fixed.
        /// <summary> The name of the NSP link. </summary>
        [WirePath("name")]
        public new string Name { get; }
    }
}
