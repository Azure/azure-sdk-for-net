// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Optional parameters for Get Range List Diff.
    /// </summary>
    public class ShareFileGetRangeListDiffOptions
    {
        /// <summary>
        /// Optional. Specifies the range of bytes over which to list ranges, inclusively.
        /// If omitted, then all ranges for the file are returned.
        /// </summary>
        public HttpRange? Range { get; set; }

        /// <summary>
        /// Optionally specifies the share snapshot to retrieve ranges
        /// information from. For more information on working with share snapshots,
        /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/create-share">
        /// Create a snapshot of a share</see>.
        /// </summary>
        public string Snapshot { get; set; }

        /// <summary>
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on getting the range.
        /// </summary>
        public ShareFileRequestConditions Conditions { get; set; }

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
