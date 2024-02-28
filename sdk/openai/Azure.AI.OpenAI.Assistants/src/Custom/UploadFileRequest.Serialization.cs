// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.OpenAI.Assistants;

internal partial class UploadFileRequest : IUtf8JsonSerializable
{
    /*
     * CUSTOM CODE DESCRIPTION:
     *
     * Manual, custom multipart/form-data serialization needed.
     *
     */

    internal virtual RequestContent ToRequestContent()
    {
        MultipartFormDataContent content = new();

        content.Add(MultipartContent.Create(Purpose.ToString()), "\"purpose\"", new Dictionary<string, string>());
        content.Add(
            MultipartContent.Create(Data),
            name: "file",
            fileName: string.IsNullOrEmpty(Filename) ? "file" : Filename,
            headers: new Dictionary<string, string>());

        return content;
    }
}
