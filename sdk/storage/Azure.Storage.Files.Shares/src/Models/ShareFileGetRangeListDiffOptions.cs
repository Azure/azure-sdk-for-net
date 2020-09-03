// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Optional parameters for Get Range List Diff.
    /// </summary>
    public class ShareFileGetRangeListDiffOptions : ShareFileGetRangeListOptions
    {
        /// <summary>
        /// Specifies that the response will contain only ranges that were
        /// changed between target file and previous snapshot.  Changed ranges
        /// include both updated and cleared ranges. The target file may be a
        /// snapshot, as long as the snapshot specified by
        /// previousSnapshot is the older of the two.
        /// </summary>
        public string PreviousSnapshot { get; set; }
    }
}
