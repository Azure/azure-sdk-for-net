// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.PostgreSql.FlexibleServers.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers
{
    // Preserves previous flattened LTR backup operation properties.
    [CodeGenSuppress("Status")]
    [CodeGenSuppress("StartOn")]
    public partial class PostgreSqlLtrServerBackupOperationData
    {
        /// <summary> Service-set extensible enum indicating the status of operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.status")]
        public PostgreSqlExecutionStatus? Status
        {
            get => Properties is null ? default(PostgreSqlExecutionStatus?) : Properties.Status;
            set
            {
                if (value.HasValue)
                {
                    if (Properties is null)
                    {
                        Properties = new LtrBackupOperationResponseProperties();
                    }
                    Properties.Status = value.Value;
                }
            }
        }

        /// <summary> Start time of the operation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.startTime")]
        public DateTimeOffset? StartOn
        {
            get => Properties is null ? default(DateTimeOffset?) : Properties.StartOn;
            set
            {
                if (value.HasValue)
                {
                    if (Properties is null)
                    {
                        Properties = new LtrBackupOperationResponseProperties();
                    }
                    Properties.StartOn = value.Value;
                }
            }
        }
    }
}
