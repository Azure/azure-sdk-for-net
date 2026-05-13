// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.ResourceManager.Sql.Models;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql
{
    /// <summary> A class representing the ManagedDatabaseRestoreDetail data model. </summary>
    public partial class ManagedDatabaseRestoreDetailData
    {
        /// <summary> Percent completed. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double? PercentCompleted => Properties?.PercentCompleted;

        /// <summary> Number of files detected. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? NumberOfFilesDetected => Properties?.NumberOfFilesDetected;

        /// <summary> List of unrestorable files. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<string> UnrestorableFiles => Properties?.UnrestorableFiles?.Select(f => f.Name).ToList().AsReadOnly();
    }
}
