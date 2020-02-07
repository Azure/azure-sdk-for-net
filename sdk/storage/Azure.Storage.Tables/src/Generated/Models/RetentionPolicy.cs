// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Storage.Tables.Models
{
    /// <summary> the retention policy. </summary>
    public partial class RetentionPolicy
    {
        /// <summary> Indicates whether a retention policy is enabled for the storage service. </summary>
        public bool Enabled { get; set; }
        /// <summary> Indicates the number of days that metrics or logging or soft-deleted data should be retained. All data older than this value will be deleted. </summary>
        public int? Days { get; set; }
    }
}
