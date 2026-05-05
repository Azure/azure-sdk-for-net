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
    /// Request body for the <c>uploadFileRequiredFilename</c> operation. The file part
    /// requires a filename and is sent with content type <c>image/png</c>.
    /// </summary>
    public partial class UploadFileRequiredFilenameRequest
    {
        private const string ContentType = "image/png";

        /// <summary> Initializes a new instance of <see cref="UploadFileRequiredFilenameRequest"/> from a path on disk. </summary>
        public UploadFileRequiredFilenameRequest(string filename, string filePath)
        {
            Argument.AssertNotNullOrEmpty(filename, nameof(filename));
            Argument.AssertNotNullOrEmpty(filePath, nameof(filePath));

            File = new(filePath, ContentType)
            {
                Filename = filename,
            };
        }

        /// <summary> Initializes a new instance of <see cref="UploadFileRequiredFilenameRequest"/> from a stream. </summary>
        public UploadFileRequiredFilenameRequest(string filename, Stream file)
        {
            Argument.AssertNotNullOrEmpty(filename, nameof(filename));
            Argument.AssertNotNull(file, nameof(file));

            File = new(file, ContentType)
            {
                Filename = filename,
            };
        }

        /// <summary> Initializes a new instance of <see cref="UploadFileRequiredFilenameRequest"/> from in-memory data. </summary>
        public UploadFileRequiredFilenameRequest(string filename, BinaryData file)
        {
            Argument.AssertNotNullOrEmpty(filename, nameof(filename));
            Argument.AssertNotNull(file, nameof(file));

            File = new(file, ContentType)
            {
                Filename = filename,
            };
        }

        /// <summary> The file part (filename is required). </summary>
        public FileBinaryContent File { get; }
    }
}
