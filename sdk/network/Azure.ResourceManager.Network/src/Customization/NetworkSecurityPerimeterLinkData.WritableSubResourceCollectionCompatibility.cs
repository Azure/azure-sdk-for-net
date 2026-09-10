// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the NetworkSecurityPerimeterLinkData type. </summary>
    [CodeGenSuppress("RemotePerimeterGuid")]
    public partial class NetworkSecurityPerimeterLinkData
    {
        /// <summary> Gets or sets the RemotePerimeterGuid compatibility property. </summary>
        [WirePath("properties.remotePerimeterGuid")]
        public Guid? RemotePerimeterGuid => WritableSubResourceCollectionCompatibility.ParseGuid(Properties?.RemotePerimeterGuid);
    }
}
