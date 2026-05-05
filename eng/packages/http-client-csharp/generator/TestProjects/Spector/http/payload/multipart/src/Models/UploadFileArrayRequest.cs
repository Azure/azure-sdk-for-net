// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel;
using System.Collections.Generic;
using System.Linq;

using Payload.MultiPart;

namespace Payload.MultiPart._FormData.File
{
    /// <summary>
    /// Request body for the <c>uploadFileArray</c> operation. Carries an array of
    /// file parts. The service requires each part to be sent with content type
    /// <c>image/png</c>; callers are responsible for constructing each
    /// <see cref="FileBinaryContent"/> with that media type.
    /// </summary>
    public partial class UploadFileArrayRequest
    {
        /// <summary> Initializes a new instance of <see cref="UploadFileArrayRequest"/>. </summary>
        /// <param name="files"> The file parts to upload. Each must be constructed with content type <c>image/png</c>. </param>
        public UploadFileArrayRequest(IEnumerable<FileBinaryContent> files)
        {
            Argument.AssertNotNull(files, nameof(files));

            Files = files.ToList();
        }

        /// <summary> The list of file parts. </summary>
        public IReadOnlyList<FileBinaryContent> Files { get; }
    }
}
