// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// The hard links of a file, along with the properties of the file.
    /// </summary>
    public class ShareFileLinks
    {
        /// <summary>
        /// The properties of the file.
        /// </summary>
        public ShareFileProperties Properties { get; internal set; }

        /// <summary>
        /// The hard links of the file.
        /// </summary>
        public IReadOnlyList<ShareFileLink> Links { get; internal set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        internal ShareFileLinks() { }
    }

    /// <summary>
    /// FilesModelFactory provides utilities for mocking.
    /// </summary>
    public static partial class FilesModelFactory
    {
        /// <summary>
        /// Creates a new ShareFileLinks instance for mocking.
        /// </summary>
        public static ShareFileLinks ShareFileLinks(
            ShareFileProperties properties,
            IReadOnlyList<ShareFileLink> links)
            => new ShareFileLinks
            {
                Properties = properties,
                Links = links
            };
    }
}
