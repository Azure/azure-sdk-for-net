// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The MediaStreamingFailed event.
    /// </summary>

    [CodeGenModel("MediaStreamingFailed", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class MediaStreamingFailed : CallAutomationEventBase
    {
        /// <summary>
        /// Deserialize <see cref="MediaStreamingFailed"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="MediaStreamingFailed"/> object.</returns>
        public static MediaStreamingFailed Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeMediaStreamingFailed(element);
        }
    }
}
