// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network.Models
{
    [CodeGenSuppress("AppliesToGroups")]
    [CodeGenSuppress("Hubs")]
    public partial class EffectiveConnectivityConfiguration
    {
        public IReadOnlyList<ConnectivityGroupItem> AppliesToGroups => Properties?.AppliesToGroups as IReadOnlyList<ConnectivityGroupItem>;
        public IReadOnlyList<ConnectivityHub> Hubs => Properties?.Hubs as IReadOnlyList<ConnectivityHub>;
    }
}
