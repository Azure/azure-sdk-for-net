// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;

namespace Azure.ResourceManager.StreamAnalytics.Models
{
    /// <summary> Describes a blob input data source that contains reference data. </summary>
    public partial class BlobReferenceInputDataSource : ReferenceInputDataSource
    {
         /// <summary> The refresh interval of the blob input data source. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release. Please use FullSnapshotRefreshInterval instead.", false)]
        public string FullSnapshotRefreshRate
        {
            get
            {
                return FullSnapshotRefreshInterval.ToString();
            }
            set
            {
                FullSnapshotRefreshInterval = TimeSpan.Parse(value, CultureInfo.InvariantCulture);
            }
        }
        /// <summary> The interval that the user generates a delta snapshot of this reference blob input data source. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release. Please use DeltaSnapshotRefreshInterval instead.", false)]
        public string DeltaSnapshotRefreshRate
        {
            get
            {
                return DeltaSnapshotRefreshInterval.ToString();
            }
            set
            {
                DeltaSnapshotRefreshInterval = TimeSpan.Parse(value, CultureInfo.InvariantCulture);
            }
        }
    }
}
