// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.OracleDatabase.Models
{
    /// <summary> AutonomousDatabaseBackup resource model. </summary>
    public partial class AutonomousDatabaseBackupProperties
    {
        /// <summary> The OCID of the Autonomous Database. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier AutonomousDatabaseOcid { get => new ResourceIdentifier(DatabaseOcid); }
        /// <summary> The OCID of the Autonomous Database backup. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier Ocid { get => new ResourceIdentifier(DatabaseBackupOcid); }
    }
}
