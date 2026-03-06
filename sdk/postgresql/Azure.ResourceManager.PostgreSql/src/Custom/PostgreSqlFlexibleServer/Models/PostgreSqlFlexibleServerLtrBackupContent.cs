// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    /// <summary> The request that is made for a long term retention backup. </summary>
    [CodeGenSuppress("PostgreSqlFlexibleServerLtrBackupContent", typeof(PostgreSqlFlexibleServerBackupSettings), typeof(IList<string>))]
    public partial class PostgreSqlFlexibleServerLtrBackupContent : PostgreSqlBackupContent
    {
        /// <summary> Initializes a new instance of <see cref="PostgreSqlFlexibleServerLtrBackupContent"/>. </summary>
        /// <param name="backupSettings"> Backup Settings. </param>
        /// <param name="targetDetailsSasUriList"> List of SAS uri of storage containers where backup data is to be streamed/copied. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="backupSettings"/> or <paramref name="targetDetailsSasUriList"/> is null. </exception>
        public PostgreSqlFlexibleServerLtrBackupContent(PostgreSqlFlexibleServerBackupSettings backupSettings, IList<string> targetDetailsSasUriList) : base(backupSettings, null)
        {
            Argument.AssertNotNull(backupSettings, nameof(backupSettings));
            Argument.AssertNotNull(targetDetailsSasUriList, nameof(targetDetailsSasUriList));

            TargetDetails = new PostgreSqlFlexibleServerBackupStoreDetails(targetDetailsSasUriList);
        }
    }
}
