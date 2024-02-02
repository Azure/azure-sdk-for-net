// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.OpenAI;

public partial class AudioTranscriptionOptions
{
    // CUSTOM CODE NOTE:
    // Implement custom serialization code to compose a request with Content-Type:
    // multipart/form-data, which currently cannot be auto-generated.

    internal virtual RequestContent ToRequestContent()
    {
        MultipartFormDataContent content = new();

        content.Add(MultipartContent.Create(DeploymentName), "model", new Dictionary<string, string>());

        if (Optional.IsDefined(ResponseFormat))
        {
            content.Add(MultipartContent.Create(ResponseFormat.ToString()), "response_format", new Dictionary<string, string>());
        }
        if (Optional.IsDefined(Prompt))
        {
            content.Add(MultipartContent.Create(Prompt), "prompt", new Dictionary<string, string>());
        }
        if (Optional.IsDefined(Temperature))
        {
            content.Add(MultipartContent.Create(Temperature.Value), "temperature", new Dictionary<string, string>());
        }
        if (Optional.IsDefined(Language))
        {
            content.Add(MultipartContent.Create(Language), "language", new Dictionary<string, string>());
        }

        string filename = Optional.IsDefined(Filename) ? Filename : "file";
        content.Add(MultipartContent.Create(AudioData), new Dictionary<string, string>()
        {
            ["Content-Disposition"] = $"form-data; name=file; filename={filename}",
            ["Content-Type"] = "text/plain",
        });

        return content;
    }
}
