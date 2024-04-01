// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.AI.OpenAI.Assistants;

internal partial class UploadFileRequest
{
    /*
     * CUSTOM CODE DESCRIPTION:
     *
     * Manual, custom multipart/form-data serialization needed.
     *
     */

    internal MultipartFormDataBinaryContent ToMultipartContent()
    {
        MultipartFormDataBinaryContent content = new();
        content.Add(Data, "file", Filename);
        content.Add(Purpose.ToString(), "\"purpose\"");
        return content;
    }
}
