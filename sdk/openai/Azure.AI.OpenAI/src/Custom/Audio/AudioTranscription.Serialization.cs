// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.OpenAI;

public partial class AudioTranscription
{
    // CUSTOM CODE NOTE:
    // Implement custom deserialization code to handle the possibility of receiving a response with
    // Content-Type: text/plain instead of the typical application/json.

    internal static AudioTranscription FromResponse(Response response)
    {
        if (response.Headers.ContentType.Contains("text/plain"))
        {
            return new AudioTranscription(response.Content.ToString());
        }
        else
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeAudioTranscription(document.RootElement);
        }
    }
}
