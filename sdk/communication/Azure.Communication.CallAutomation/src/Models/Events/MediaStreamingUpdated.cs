// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The media streaming started event.
    /// </summary>
    [CodeGenModel("MediaStreamingUpdated", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class MediaStreamingUpdated : CallAutomationEventBase
    {
        /// <summary>
        /// Deserialize <see cref="MediaStreamingUpdated"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="MediaStreamingUpdated"/> object.</returns>
        public static MediaStreamingUpdated Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeMediaStreamingUpdated(element);
        }
    }
}
