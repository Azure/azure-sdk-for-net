// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Globalization;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the FlowLogData type. </summary>
    [CodeGenSuppress("TargetResourceGuid")]
    public partial class FlowLogData
    {
        /// <summary> Gets the TargetResourceGuid compatibility property. </summary>
        [WirePath("properties.targetResourceGuid")]
        public Guid? TargetResourceGuid => ResourceGuidCompatibility.Parse(Properties?.TargetResourceGuid);
    }
}
