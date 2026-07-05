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
    [System.Obsolete("Use Name instead.", false)]
    public BicepValue<ThreatProtectionName> ThreatProtectionName
    {
        get => (ThreatProtectionName)System.Enum.Parse(typeof(ThreatProtectionName), Name.Value ?? "Default");
        set => throw new System.NotSupportedException("Use Name instead.");
    }
}
