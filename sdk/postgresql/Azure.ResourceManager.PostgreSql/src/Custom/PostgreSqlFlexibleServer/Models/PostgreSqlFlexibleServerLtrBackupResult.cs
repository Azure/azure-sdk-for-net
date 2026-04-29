// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    // Preserves previous flattened LTR backup result properties.
    [CodeGenSuppress("Status")]
    [CodeGenSuppress("StartOn")]
    public partial class PostgreSqlFlexibleServerLtrBackupResult
    {
        /// <summary> Service-set extensible enum indicating the status of operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.status")]
        public PostgreSqlExecutionStatus? Status
        {
            get => Properties is null ? default(PostgreSqlExecutionStatus?) : Properties.Status;
        }

        /// <summary> Start time of the operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.startTime")]
        public DateTimeOffset? StartOn
        {
            get => Properties is null ? default(DateTimeOffset?) : Properties.StartOn;
        }
    }
}
