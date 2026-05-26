// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The media streaming update for media streaming events.
    /// </summary>
    [CodeGenModel("MediaStreamingUpdate", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class MediaStreamingUpdate : CallAutomationEventBase
    {
        /// <summary>
        /// Deserialize <see cref="MediaStreamingUpdate"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="MediaStreamingUpdate"/> object.</returns>
        public static MediaStreamingUpdate Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeMediaStreamingUpdate(element);
        }
    }
}
