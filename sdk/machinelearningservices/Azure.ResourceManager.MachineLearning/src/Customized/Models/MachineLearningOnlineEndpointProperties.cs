// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore GA public network access enum type over generated Azure.Core.PublicNetworkAccess.
    [CodeGenSuppress("PublicNetworkAccess")]
    public partial class MachineLearningOnlineEndpointProperties
    {
        /// <summary> Enum to determine whether PublicNetworkAccess is Enabled or Disabled. </summary>
        [WirePath("publicNetworkAccess")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningPublicNetworkAccessType? PublicNetworkAccess { get; set; }
    }
}
