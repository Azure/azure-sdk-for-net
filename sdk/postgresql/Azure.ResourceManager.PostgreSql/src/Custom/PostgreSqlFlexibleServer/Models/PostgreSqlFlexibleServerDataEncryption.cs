// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    public partial class PostgreSqlFlexibleServerDataEncryption
    {
        private PostgreSqlKeyStatus? _primaryEncryptionKeyStatusOverride;
        private bool _primaryEncryptionKeyStatusSet;
        private PostgreSqlKeyStatus? _geoBackupEncryptionKeyStatusOverride;
        private bool _geoBackupEncryptionKeyStatusSet;

        /// <summary> Primary encryption key status. </summary>
        [WirePath("primaryEncryptionKeyStatus")]
        public PostgreSqlKeyStatus? PrimaryEncryptionKeyStatus
        {
            get => _primaryEncryptionKeyStatusSet ? _primaryEncryptionKeyStatusOverride : PrimaryEncryptionKeyStatusInternal;
            set { _primaryEncryptionKeyStatusOverride = value; _primaryEncryptionKeyStatusSet = true; }
        }

        internal PostgreSqlKeyStatus? PrimaryEncryptionKeyStatusInternal { get; }

        /// <summary> Geo-backup encryption key status. </summary>
        [WirePath("geoBackupEncryptionKeyStatus")]
        public PostgreSqlKeyStatus? GeoBackupEncryptionKeyStatus
        {
            get => _geoBackupEncryptionKeyStatusSet ? _geoBackupEncryptionKeyStatusOverride : GeoBackupEncryptionKeyStatusInternal;
            set { _geoBackupEncryptionKeyStatusOverride = value; _geoBackupEncryptionKeyStatusSet = true; }
        }

        internal PostgreSqlKeyStatus? GeoBackupEncryptionKeyStatusInternal { get; }
    }
}
