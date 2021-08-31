// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Optional parameters for <see cref="ShareDirectoryClient.GetFilesAndDirectoriesAsync(ShareDirectoryGetFilesAndDirectoriesOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class ShareDirectoryGetFilesAndDirectoriesOptions
    {
        /// <summary>
        /// Optional string that filters the results to return only
        /// files and directories whose name begins with the specified prefix.
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// Optional.  Specifies traits to include in the <see cref="ShareFileItem"/>.
        /// </summary>
        public ShareFileTraits Traits { get; set; } = ShareFileTraits.None;

        /// <summary>
        /// Optional.  Specified that extended info should be included in the <see cref="ShareFileItem"/>.
        /// If set to true, the Content-Length property will be up to date.  Implicitly set to true
        /// if any <see cref="ShareFileTraits"/> are set.
        /// </summary>
        public bool? IncludeExtendedInfo { get; set; }
    }
}
