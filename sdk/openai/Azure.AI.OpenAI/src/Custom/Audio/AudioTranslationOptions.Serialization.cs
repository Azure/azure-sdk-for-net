// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.IO;

namespace Azure.AI.OpenAI;

public partial class AudioTranslationOptions
{
    // CUSTOM CODE NOTE:
    // Implement custom serialization code to compose a request with Content-Type:
    // multipart/form-data, which currently cannot be auto-generated.

    internal MultipartFormDataBinaryContent ToMultipartContent()
    {
        MultipartFormDataBinaryContent content = new();

        content.Add(AudioData, "file", Filename);

        content.Add(DeploymentName, "model");

        if (Prompt is not null)
        {
            content.Add(Prompt, "prompt");
        }

        if (ResponseFormat is not null)
        {
            content.Add(ResponseFormat.ToString(), "response_format");
        }

        return content;
    }
}
