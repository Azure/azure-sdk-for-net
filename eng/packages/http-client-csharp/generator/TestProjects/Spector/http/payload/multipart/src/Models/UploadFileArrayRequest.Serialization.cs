// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel;

using Payload.MultiPart;

namespace Payload.MultiPart._FormData.File
{
    public partial class UploadFileArrayRequest
    {
        internal virtual MultiPartFormContent ToMultipartContent()
        {
            MultiPartFormContent content = new();
            foreach (FileBinaryContent file in Files)
            {
                content.Add("files", file);
            }

            return content;
        }
    }
}
