// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Provisioning.PostgreSql;

public partial class ServerThreatProtectionSettingsModel
{
    public static partial class ResourceVersions
    {
        /// <summary> API version "2024-08-01". </summary>
        public static readonly string V2024_08_01 = "2024-08-01";
        /// <summary> API version "2022-12-01". </summary>
        public static readonly string V2022_12_01 = "2022-12-01";
        /// <summary> API version "2021-06-01". </summary>
        public static readonly string V2021_06_01 = "2021-06-01";
    }

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
