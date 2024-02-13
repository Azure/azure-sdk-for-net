// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.OpenAI;

public partial class AudioTranslation
{
    // CUSTOM CODE NOTE:
    // Implement custom deserialization code to handle the possibility of receiving a response with
    // Content-Type: text/plain instead of the typical application/json.

    internal static AudioTranslation FromResponse(Response response)
    {
        if (response.Headers.ContentType.Contains("text/plain"))
        {
            return new AudioTranslation(response.Content.ToString());
        }
        else
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeAudioTranslation(document.RootElement);
        }
    }
}
