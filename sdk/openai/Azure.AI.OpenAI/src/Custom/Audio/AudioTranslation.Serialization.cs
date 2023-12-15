// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;

namespace Azure.AI.OpenAI;

public partial class AudioTranslation
{
    // CUSTOM CODE NOTE:
    //   This facilitates split deserialization behavior depending on whether the response is JSON or plain
    //   text.

    internal static AudioTranslation FromResponse(Response response)
    {
        if (response.Headers.ContentType.Contains("text/plain"))
        {
            return new AudioTranslation(
                text: response.Content.ToString(),
                internalAudioTaskLabel: null,
                language: null,
                duration: default,
                segments: null);
        }
        else
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeAudioTranslation(document.RootElement);
        }
    }
}
