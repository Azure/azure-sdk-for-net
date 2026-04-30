// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    public static partial class ArmPostgreSqlModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="PostgreSqlFlexibleServerLtrBackupContent"/>. </summary>
        /// <param name="backupSettings"> Backup Settings. </param>
        /// <param name="targetDetailsSasUriList"> List of SAS uri of storage containers where backup data is to be streamed/copied. </param>
        /// <returns> A new <see cref="PostgreSqlFlexibleServerLtrBackupContent"/> instance for mocking. </returns>
        public static PostgreSqlFlexibleServerLtrBackupContent PostgreSqlFlexibleServerLtrBackupContent(PostgreSqlFlexibleServerBackupSettings backupSettings = null, IEnumerable<string> targetDetailsSasUriList = null)
        {
            PostgreSqlFlexibleServerBackupStoreDetails targetDetails = targetDetailsSasUriList is null
                ? null
                : PostgreSqlFlexibleServerBackupStoreDetails(targetDetailsSasUriList);
            return new PostgreSqlFlexibleServerLtrBackupContent(backupSettings, additionalBinaryDataProperties: null, targetDetails);
        }
    }
}
