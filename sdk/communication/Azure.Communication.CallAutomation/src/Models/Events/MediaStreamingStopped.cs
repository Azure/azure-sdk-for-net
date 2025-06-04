// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The MediaStreamingStopped event.
    /// </summary>

    [CodeGenModel("MediaStreamingStopped", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class MediaStreamingStopped : CallAutomationEventBase
    {
        /// <summary>
        /// Deserialize <see cref="MediaStreamingStopped"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="MediaStreamingStopped"/> object.</returns>
        public static MediaStreamingStopped Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeMediaStreamingStopped(element);
        }
    }
}
