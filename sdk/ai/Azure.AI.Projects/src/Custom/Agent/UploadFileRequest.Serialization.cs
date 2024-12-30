// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Projects;

internal partial class UploadFileRequest : IUtf8JsonSerializable
{
    /*
     * CUSTOM CODE DESCRIPTION:
     *
     * Manual, custom multipart/form-data serialization needed.
     *
     */

    internal virtual MultipartFormDataRequestContent ToMultipartRequestContent()
    {
        MultipartFormDataRequestContent content = new MultipartFormDataRequestContent();
        content.Add(Data, "file", Filename);
        content.Add(Purpose.ToString(), "purpose");
        return content;
    }
}
