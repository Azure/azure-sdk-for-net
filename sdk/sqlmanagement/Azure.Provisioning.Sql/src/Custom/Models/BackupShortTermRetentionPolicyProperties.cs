// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning;

namespace Azure.Provisioning.Sql;

internal partial class BackupShortTermRetentionPolicyProperties
{
    private BicepValue<int> _diffBackupIntervalInHours;

    internal BicepValue<int> DiffBackupIntervalInHours
    {
        get
        {
            Initialize();
            return _diffBackupIntervalInHours;
        }
        set
        {
            Initialize();
            _diffBackupIntervalInHours.Assign(value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _diffBackupIntervalInHours = DefineProperty<int>(nameof(DiffBackupIntervalInHours), new string[] { "diffBackupIntervalInHours" });
    }
}
