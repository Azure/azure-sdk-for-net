// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Optional parameters to set for <see cref="ShareFileClient.SetHttpHeaders(ShareFileSetHttpHeadersOptions, ShareFileRequestConditions, System.Threading.CancellationToken)"/>
    /// and <see cref="ShareFileClient.SetHttpHeadersAsync(ShareFileSetHttpHeadersOptions, ShareFileRequestConditions, System.Threading.CancellationToken)"/>
    /// </summary>
    public class ShareFileSetHttpHeadersOptions
    {
        /// <summary>
        /// Optional. Resizes a file to the specified size.
        /// If the specified byte value is less than the current size
        /// of the file, then all ranges above the specified byte value
        /// are cleared.
        /// </summary>
        public long? NewSize { get; set; }

        /// <summary>
        /// Optional. The standard HTTP header system properties to set.  If not specified, existing values will be cleared.
        /// </summary>
        public ShareFileHttpHeaders HttpHeaders { get; set; }

        /// <summary>
        /// Optional SMB properties to set for the file.
        /// </summary>
        public FileSmbProperties SmbProperties { get; set; }

        /// <summary>
        /// Optional file permission to set for the file.
        /// </summary>
        public ShareFilePermission FilePermission { get; set; }

        /// <summary>
        /// Optional properties to set on NFS files.
        /// Note that this property is only applicable to files created in NFS shares.
        /// </summary>
        public FilePosixProperties PosixProperties { get; set; }
    }
}
