// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    [CodeGenSuppress("PrimaryEncryptionKeyStatus")]
    [CodeGenSuppress("GeoBackupEncryptionKeyStatus")]
    public partial class PostgreSqlFlexibleServerDataEncryption
    {
        /// <summary> Status of key used by a server configured with data encryption based on customer managed key, to encrypt the primary storage associated to the server. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("primaryEncryptionKeyStatus")]
        public PostgreSqlKeyStatus? PrimaryEncryptionKeyStatus { get; set; }

        /// <summary> Status of key used by a server configured with data encryption based on customer managed key, to encrypt the geographically redundant storage associated to the server when it is configured to support geographically redundant backups. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("geoBackupEncryptionKeyStatus")]
        public PostgreSqlKeyStatus? GeoBackupEncryptionKeyStatus { get; set; }
    }
}
