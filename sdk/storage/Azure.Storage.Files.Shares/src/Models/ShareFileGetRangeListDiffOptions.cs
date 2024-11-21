// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

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
        /// <see href="https://learn.microsoft.com/en-us/azure/storage/files/storage-snapshots-files">
        /// Overview of share snapshots</see>.
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
        /// <see cref="PreviousSnapshot"/> is the older of the two.
        /// For more information on working with share snapshots,
        /// <see href="https://learn.microsoft.com/en-us/azure/storage/files/storage-snapshots-files">
        /// Overview of share snapshots</see>.
        /// </summary>
        public string PreviousSnapshot { get; set; }

        /// <summary>
        /// This header is allowed only when PreviousSnapshot query parameter is set.
        /// Determines whether the changed ranges for a file that has been renamed or moved between the target snapshot (or the live file) and the previous snapshot should be listed.
        /// If the value is true, the valid changed ranges for the file will be returned. If the value is false, the operation will result in a failure with 409 (Conflict) response.
        /// The default value is false.
        /// </summary>
        public bool? IncludeRenames { get; set; }
    }
}
