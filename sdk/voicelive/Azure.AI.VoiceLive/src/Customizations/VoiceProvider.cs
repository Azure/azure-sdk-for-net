// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.AI.VoiceLive
{
    /// <summary>
    /// Base interface for the different voice types supported by the VoiceLive service
    /// </summary>
    public abstract class VoiceProvider
    {
        internal static VoiceProvider DeserializeVoiceProvider(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.TryGetProperty("type"u8, out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "openai":
                        return OpenAIVoice.DeserializeOpenAIVoice(element, options);
                    case "azure-custom":
                    case "azure-standard":
                    case "azure-personal":
                        return AzureVoice.DeserializeAzureVoice(element, options);
                    default:
                        return null;
                }
            }
            return null;
        }
    }
}
