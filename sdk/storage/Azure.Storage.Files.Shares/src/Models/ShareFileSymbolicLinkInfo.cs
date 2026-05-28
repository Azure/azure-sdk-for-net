// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SA1402  // File may only contain a single type

using System;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Infomation about a Symbolic Link.
    /// Only applicable to NFS files.
    /// </summary>
    public class ShareFileSymbolicLinkInfo
    {
        internal ShareFileSymbolicLinkInfo() {}

        /// <summary>
        /// The ETag contains a value which represents the version of the file, in quotes.
        /// </summary>
        public ETag ETag { get; internal set; }

        /// <summary>
        /// Returns the date and time the file was last modified.
        /// </summary>
        public DateTimeOffset LastModified { get; internal set; }

        /// <summary>
        /// Text of the symbolic link.
        /// </summary>
        public string LinkText { get; internal set; }
    }

    public static partial class SharesModelFactory
    {
        /// <summary>
        /// Creates a new FileSymolicLinkInfo for mocking.
        /// </summary>
        public static ShareFileSymbolicLinkInfo FileSymbolicLinkInfo(
            ETag eTag = default,
            DateTimeOffset lastModified = default,
            string linkText = default)
            => new ShareFileSymbolicLinkInfo
            {
                ETag = eTag,
                LastModified = lastModified,
                LinkText = linkText
            };
    }
}
