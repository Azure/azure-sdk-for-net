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
        /// Path to the file the symbolic link is pointed to.
        /// </summary>
        public string Path { get; internal set; }
    }

    public static partial class SharesModelFactory
    {
        /// <summary>
        /// Creates a new FileSymolicLinkInfo for mocking.
        /// </summary>
        public static ShareFileSymbolicLinkInfo FileSymbolicLinkInfo(string path)
            => new ShareFileSymbolicLinkInfo { Path = path };
    }
}
