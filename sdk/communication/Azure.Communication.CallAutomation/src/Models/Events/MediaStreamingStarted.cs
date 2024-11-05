// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The MediaStreamingStarted event.
    /// </summary>

    [CodeGenModel("MediaStreamingStarted", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class MediaStreamingStarted : CallAutomationEventBase
    {
        /// <summary>
        /// Deserialize <see cref="MediaStreamingStarted"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="MediaStreamingStarted"/> object.</returns>
        public static MediaStreamingStarted Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeMediaStreamingStarted(element);
        }
    }
}
