// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.IO;

using Payload.MultiPart;

namespace Payload.MultiPart._FormData.File
{
    /// <summary>
    /// Request body for the <c>uploadFileSpecificContentType</c> operation. The file
    /// part is sent with content type <c>image/png</c>.
    /// </summary>
    public partial class UploadFileSpecificContentTypeRequest
    {
        /// <summary> Initializes a new instance of <see cref="UploadFileSpecificContentTypeRequest"/> from a path on disk. </summary>
        public UploadFileSpecificContentTypeRequest(string filePath)
        {
            Argument.AssertNotNullOrEmpty(filePath, nameof(filePath));

            File = new(filePath, "image/png");
        }

        /// <summary> Initializes a new instance of <see cref="UploadFileSpecificContentTypeRequest"/> from a stream. </summary>
        public UploadFileSpecificContentTypeRequest(Stream file)
        {
            Argument.AssertNotNull(file, nameof(file));

            File = new(file, "image/png");
        }

        /// <summary> Initializes a new instance of <see cref="UploadFileSpecificContentTypeRequest"/> from in-memory data. </summary>
        public UploadFileSpecificContentTypeRequest(BinaryData file)
        {
            Argument.AssertNotNull(file, nameof(file));

            File = new(file, "image/png");
        }

        /// <summary> The file part. </summary>
        public FileBinaryContent File { get; }
    }
}
