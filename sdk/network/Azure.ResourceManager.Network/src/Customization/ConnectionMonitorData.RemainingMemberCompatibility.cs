// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ConnectionMonitorData type. </summary>
    [CodeGenSuppress("Endpoints")]
    [CodeGenSuppress("Outputs")]
    [CodeGenSuppress("TestConfigurations")]
    [CodeGenSuppress("TestGroups")]
    [CodeGenSuppress("ConnectionMonitorType")]
    public partial class ConnectionMonitorData
    {
        /// <summary> Gets or sets the Endpoints compatibility property. </summary>
        public IReadOnlyList<Models.ConnectionMonitorEndpoint> Endpoints => Properties?.Endpoints as IReadOnlyList<Models.ConnectionMonitorEndpoint>;
        /// <summary> Gets or sets the Outputs compatibility property. </summary>
        public IReadOnlyList<Models.ConnectionMonitorOutput> Outputs => Properties?.Outputs as IReadOnlyList<Models.ConnectionMonitorOutput>;
        /// <summary> Gets or sets the TestConfigurations compatibility property. </summary>
        public IReadOnlyList<Models.ConnectionMonitorTestConfiguration> TestConfigurations => Properties?.TestConfigurations as IReadOnlyList<Models.ConnectionMonitorTestConfiguration>;
        /// <summary> Gets or sets the TestGroups compatibility property. </summary>
        public IReadOnlyList<Models.ConnectionMonitorTestGroup> TestGroups => Properties?.TestGroups as IReadOnlyList<Models.ConnectionMonitorTestGroup>;
        /// <summary> Gets or sets the ConnectionMonitorType compatibility property. </summary>
        public Models.ConnectionMonitorType? ConnectionMonitorType => Properties?.ConnectionMonitorType is null ? default : new Models.ConnectionMonitorType(Properties.ConnectionMonitorType.Value.ToString());
    }
}
