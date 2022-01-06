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
        /// The last write time of the file.  If not provided, the current FileLastWrittenOn associated with the
        /// file will be preserved.
        /// </summary>
        public DateTimeOffset? FileLastWrittenOn { get; set; }
    }
}
