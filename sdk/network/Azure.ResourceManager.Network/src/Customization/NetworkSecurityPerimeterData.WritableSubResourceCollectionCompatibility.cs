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
    /// <summary> Compatibility declaration for the NetworkSecurityPerimeterData type. </summary>
    [CodeGenSuppress("PerimeterGuid")]
    public partial class NetworkSecurityPerimeterData
    {
        /// <summary> Gets or sets the PerimeterGuid compatibility property. </summary>
        [WirePath("properties.perimeterGuid")]
        public Guid? PerimeterGuid => WritableSubResourceCollectionCompatibility.ParseGuid(Properties?.PerimeterGuid);
    }
}
