// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    public partial class PostgreSqlFlexibleServerLtrBackupContent
    {
        /// <summary> Initializes a new instance of <see cref="PostgreSqlFlexibleServerLtrBackupContent"/>. </summary>
        /// <param name="backupSettings"> Backup Settings. </param>
        /// <param name="targetDetails"> Backup store detail for target server. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PostgreSqlFlexibleServerLtrBackupContent(PostgreSqlFlexibleServerBackupSettings backupSettings, PostgreSqlFlexibleServerBackupStoreDetails targetDetails) : base(backupSettings)
        {
            Argument.AssertNotNull(backupSettings, nameof(backupSettings));
            Argument.AssertNotNull(targetDetails, nameof(targetDetails));

            TargetDetails = targetDetails;
        }

        /// <summary> Initializes a new instance of <see cref="PostgreSqlFlexibleServerLtrBackupContent"/>. </summary>
        /// <param name="backupSettings"> Backup Settings. </param>
        /// <param name="sasUriList"> List of SAS uri of storage containers where backup data is to be streamed/copied. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PostgreSqlFlexibleServerLtrBackupContent(PostgreSqlFlexibleServerBackupSettings backupSettings, IEnumerable<string> sasUriList) : base(backupSettings)
        {
            Argument.AssertNotNull(backupSettings, nameof(backupSettings));
            Argument.AssertNotNull(sasUriList, nameof(sasUriList));

            TargetDetails = new PostgreSqlFlexibleServerBackupStoreDetails(sasUriList);
        }
    }
}
