// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the EffectiveConnectivityConfiguration type. </summary>
    [CodeGenSuppress("AppliesToGroups")]
    [CodeGenSuppress("Hubs")]
    public partial class EffectiveConnectivityConfiguration
    {
        /// <summary> Gets or sets the AppliesToGroups compatibility property. </summary>
        public IReadOnlyList<ConnectivityGroupItem> AppliesToGroups => Properties?.AppliesToGroups as IReadOnlyList<ConnectivityGroupItem>;
        /// <summary> Gets or sets the Hubs compatibility property. </summary>
        public IReadOnlyList<ConnectivityHub> Hubs => Properties?.Hubs as IReadOnlyList<ConnectivityHub>;
    }
}
