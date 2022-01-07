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
        /// If the current file last write time should be preseved.
        /// If false, the file last write time will be reset to the current time.
        /// </summary>
        public bool PreserveFileLastWrittenOn { get; set; }
    }
}
