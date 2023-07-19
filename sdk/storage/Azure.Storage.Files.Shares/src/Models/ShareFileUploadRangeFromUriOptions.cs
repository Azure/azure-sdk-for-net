// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Files.Shares.Models
{
    /// <summary>
    /// Optional parameters for <see cref="ShareFileClient.UploadRangeFromUri(System.Uri, HttpRange, HttpRange, ShareFileUploadRangeFromUriOptions, System.Threading.CancellationToken)"/>.
    /// </summary>
    public class ShareFileUploadRangeFromUriOptions
    {
        /// <summary>
        /// Optional <see cref="ShareFileRequestConditions"/> to add conditions
        /// on creating the file.
        /// </summary>
        public ShareFileRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional.  Source authentication used to access the source blob.
        /// </summary>
        public HttpAuthorization SourceAuthentication { get; set; }

        /// <summary>
        /// Optional.  Specifies if the file last write time should be set to the current time,
        /// or the last write time currently associated with the file should be preserved.
        /// </summary>
        public FileLastWrittenMode? FileLastWrittenMode { get; set; }
    }
}
