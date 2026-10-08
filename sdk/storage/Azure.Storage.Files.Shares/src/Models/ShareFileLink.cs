// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// A hard link to a file.
    /// </summary>
    public class ShareFileLink
    {
        /// <summary>
        /// The file ID of the parent directory of the hard link.
        /// </summary>
        public string ParentId { get; internal set; }

        /// <summary>
        /// The name of the hard link.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        internal ShareFileLink() { }
    }

    /// <summary>
    /// FilesModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class FilesModelFactory
    {
        /// <summary>
        /// Creates a new ShareFileLink instance for mocking.
        /// </summary>
        public static ShareFileLink ShareFileLink(
            string parentId,
            string name)
            => new ShareFileLink
            {
                ParentId = parentId,
                Name = name
            };
    }
}
