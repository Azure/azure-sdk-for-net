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

namespace Azure.ResourceManager.Network
{
    [CodeGenSuppress("Endpoints")]
    [CodeGenSuppress("Outputs")]
    [CodeGenSuppress("TestConfigurations")]
    [CodeGenSuppress("TestGroups")]
    [CodeGenSuppress("ConnectionMonitorType")]
    public partial class ConnectionMonitorData
    {
        public IReadOnlyList<Models.ConnectionMonitorEndpoint> Endpoints => Properties?.Endpoints as IReadOnlyList<Models.ConnectionMonitorEndpoint>;
        public IReadOnlyList<Models.ConnectionMonitorOutput> Outputs => Properties?.Outputs as IReadOnlyList<Models.ConnectionMonitorOutput>;
        public IReadOnlyList<Models.ConnectionMonitorTestConfiguration> TestConfigurations => Properties?.TestConfigurations as IReadOnlyList<Models.ConnectionMonitorTestConfiguration>;
        public IReadOnlyList<Models.ConnectionMonitorTestGroup> TestGroups => Properties?.TestGroups as IReadOnlyList<Models.ConnectionMonitorTestGroup>;
        public Models.ConnectionMonitorType? ConnectionMonitorType => Properties?.ConnectionMonitorType is null ? default : new Models.ConnectionMonitorType(Properties.ConnectionMonitorType.Value.ToString());
    }
}
