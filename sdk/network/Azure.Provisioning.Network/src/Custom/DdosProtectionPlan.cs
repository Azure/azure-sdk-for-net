// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Provisioning.Resources;

namespace Azure.Provisioning.Network;

public partial class DdosProtectionPlan
{
    private SystemData _systemData;

    // Preserve the output-only system metadata and Bicep path shipped in 1.1.0.
    /// <summary> Gets the SystemData. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public SystemData SystemData
    {
        get
        {
            Initialize();
            return _systemData;
        }
    }

    partial void DefineAdditionalProperties()
    {
        _systemData = DefineModelProperty<SystemData>(nameof(SystemData), new string[] { "systemData" }, isOutput: true);
    }
}
