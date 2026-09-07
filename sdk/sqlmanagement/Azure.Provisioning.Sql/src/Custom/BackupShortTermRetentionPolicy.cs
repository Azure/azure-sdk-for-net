// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.Sql;

public partial class BackupShortTermRetentionPolicy
{
    // The TypeSpec property is an open numeric union, but the provisioning generator emits
    // a closed enum. Preserve the previously shipped integer contract so arbitrary values
    // and Bicep expressions remain supported.
    /// <summary> Gets or sets the differential backup interval in hours. </summary>
    [CodeGenMember("DiffBackupIntervalInHours")]
    public BicepValue<int> DiffBackupIntervalInHours
    {
        get
        {
            if (Properties is null)
            {
                Properties = new BackupShortTermRetentionPolicyProperties();
            }
            return Properties.DiffBackupIntervalInHours;
        }
        set
        {
            if (Properties is null)
            {
                Properties = new BackupShortTermRetentionPolicyProperties();
            }
            Properties.DiffBackupIntervalInHours = value;
        }
    }

    // Preserve API versions shipped by the reflection-based generator that are not emitted
    // by the TypeSpec-based generator when targeting only the current stable API version.
    public static partial class ResourceVersions
    {
        /// <summary> API version "2021-11-01". </summary>
        public static readonly string V2021_11_01 = "2021-11-01";
        /// <summary> API version "2023-08-01". </summary>
        public static readonly string V2023_08_01 = "2023-08-01";
    }
}
