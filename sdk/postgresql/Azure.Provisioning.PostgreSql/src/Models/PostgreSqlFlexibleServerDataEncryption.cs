// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning.Primitives;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.PostgreSql;

public partial class PostgreSqlFlexibleServerDataEncryption
{
    private BicepValue<PostgreSqlKeyStatus> _primaryEncryptionKeyStatus;
    private BicepValue<PostgreSqlKeyStatus> _geoBackupEncryptionKeyStatus;

    /// <summary>
    /// The status of the primary encryption key.
    /// </summary>
    [CodeGenMember("PrimaryEncryptionKeyStatus")]
    public BicepValue<PostgreSqlKeyStatus> PrimaryEncryptionKeyStatus
    {
        get { Initialize(); return _primaryEncryptionKeyStatus; }
        set { Initialize(); _primaryEncryptionKeyStatus.Assign(value); }
    }

    /// <summary>
    /// The status of the geo-backup encryption key.
    /// </summary>
    [CodeGenMember("GeoBackupEncryptionKeyStatus")]
    public BicepValue<PostgreSqlKeyStatus> GeoBackupEncryptionKeyStatus
    {
        get { Initialize(); return _geoBackupEncryptionKeyStatus; }
        set { Initialize(); _geoBackupEncryptionKeyStatus.Assign(value); }
    }

    partial void DefineAdditionalProperties()
    {
        _primaryEncryptionKeyStatus = DefineProperty<PostgreSqlKeyStatus>(nameof(PrimaryEncryptionKeyStatus), ["primaryEncryptionKeyStatus"], isOutput: true);
        _geoBackupEncryptionKeyStatus = DefineProperty<PostgreSqlKeyStatus>(nameof(GeoBackupEncryptionKeyStatus), ["geoBackupEncryptionKeyStatus"], isOutput: true);
    }
}
