// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Provisioning.PostgreSql;

public partial class ServerThreatProtectionSettingsModel
{
    /// <summary>
    /// Name of the advanced threat protection settings.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepValue<ThreatProtectionName> ThreatProtectionName
    {
        get => throw new System.NotSupportedException("Use Name instead.");
        set { }
    }
}
