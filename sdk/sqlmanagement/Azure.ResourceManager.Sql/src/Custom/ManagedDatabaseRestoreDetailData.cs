// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    /// <summary> A class representing the ManagedDatabaseRestoreDetail data model. </summary>
    public partial class ManagedDatabaseRestoreDetailData
    {
        /// <summary> Percent completed. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double? PercentCompleted
        {
            get
            {
                if (CompletedPercent.HasValue)
                {
                    return Convert.ToDouble(CompletedPercent.Value);
                }
                else
                {
                    return default;
                }
            }
        }
        /// <summary> Number of files detected. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? NumberOfFilesDetected
        {
            get
            {
                if (NumberOfFilesFound.HasValue)
                {
                    return Convert.ToInt64(NumberOfFilesFound.Value);
                }
                else
                {
                    return default;
                }
            }
        }
        /// <summary> List of unrestorable files. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<string> UnrestorableFiles { get => UnrestorableFileList.Select(f => f.Name).ToList().AsReadOnly(); }
    }
}
