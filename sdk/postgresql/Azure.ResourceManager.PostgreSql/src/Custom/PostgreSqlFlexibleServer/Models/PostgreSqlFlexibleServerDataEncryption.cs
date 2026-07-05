// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    // Preserves previous settable encryption-key status properties while the generated members remain readonly.
    public partial class PostgreSqlFlexibleServerDataEncryption
    {
        /// <summary> Primary encryption key status. </summary>
        [WirePath("primaryEncryptionKeyStatus")]
        public PostgreSqlKeyStatus? PrimaryEncryptionKeyStatus { get; set; }

        /// <summary> Geo-backup encryption key status. </summary>
        [WirePath("geoBackupEncryptionKeyStatus")]
        public PostgreSqlKeyStatus? GeoBackupEncryptionKeyStatus { get; set; }
    }
}
