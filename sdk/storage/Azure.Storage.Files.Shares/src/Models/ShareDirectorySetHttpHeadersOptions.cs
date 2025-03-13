// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Optional parameters for <see cref="ShareDirectoryClient.SetHttpHeaders(ShareDirectorySetHttpHeadersOptions, System.Threading.CancellationToken)"/>
    /// and <see cref="ShareDirectoryClient.SetHttpHeadersAsync(ShareDirectorySetHttpHeadersOptions, System.Threading.CancellationToken)"/>
    /// </summary>
    public class ShareDirectorySetHttpHeadersOptions
    {
        /// <summary>
        /// /// Optional SMB properties to set for the directory.
        /// </summary>
        public FileSmbProperties SmbProperties { get; set; }

        /// <summary>
        /// Optional file permission to set for the directory.
        /// </summary>
        public ShareFilePermission FilePermission { get; set; }

        /// <summary>
        /// Optional properties to set on NFS files.
        /// Note that this property is only applicable to directories created in NFS shares.
        /// </summary>
        public FilePosixProperties PosixProperties { get; set; }
    }
}
