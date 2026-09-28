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
    // The backing model must retain its incorrectly typed, obsolete ConnectionMonitorType getter
    // for binary compatibility, while MonitorType is its correctly typed serialized property.
    // Neither should be automatically flattened: doing so would either expose the obsolete enum
    // on this resource or add a second public MonitorType property that never existed here.
    // Keep the resource's original ConnectionMonitorType name/type with the explicit getter below.
    [CodeGenSuppress("ConnectionMonitorType")]
    [CodeGenSuppress("MonitorType")]
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

        // Read the canonical backing value directly rather than converting through the obsolete
        // alias. A missing properties object remains null, and deserialization populates the same
        // value used by the backing model's serializer and both of its public getters.
        /// <summary> Type of connection monitor. </summary>
        public Models.ConnectionMonitorType? ConnectionMonitorType => Properties?.MonitorType;
    }
}
