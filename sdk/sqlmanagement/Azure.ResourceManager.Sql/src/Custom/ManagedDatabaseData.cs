// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Sql
{
    /// <summary> A class representing the ManagedDatabase data model. </summary>
    public partial class ManagedDatabaseData : TrackedResourceData
    {
        /// <summary> Conditional. If createMode is PointInTimeRestore, this value is required. Specifies the point in time (ISO8601 format) of the source database that will be restored to create the new database. </summary>
        [CodeGenMember("RestorePointInOn")]
        public DateTimeOffset? RestorePointInTime { get; set; }
    }
}
