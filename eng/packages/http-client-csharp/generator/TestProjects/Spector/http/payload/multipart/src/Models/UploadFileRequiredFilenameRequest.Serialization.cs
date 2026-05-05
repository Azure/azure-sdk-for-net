// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel;

using Payload.MultiPart;

namespace Payload.MultiPart._FormData.File
{
    public partial class UploadFileRequiredFilenameRequest
    {
        internal virtual MultiPartFormContent ToMultipartContent()
        {
            MultiPartFormContent content = new();
            content.Add("file", File);

            return content;
        }
    }
}
