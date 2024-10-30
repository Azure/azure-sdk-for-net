// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Infomation about a Symbolic Link.
    /// Only applicable to NFS files.
    /// </summary>
    public class ShareFileSymbolicLinkInfo
    {
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
        public static ShareFileSymbolicLinkInfo FileSymbolicLinkInfo(string path = default)
            => new ShareFileSymbolicLinkInfo { LinkText = path };
    }
}
