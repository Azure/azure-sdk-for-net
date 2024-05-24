// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Play Started event.
    /// </summary>
    [CodeGenModel("PlayStarted", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class PlayStarted : CallAutomationEventBase
    {
        /// <summary>
        /// Deserialize <see cref="PlayStarted"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="PlayStarted"/> object.</returns>
        public static PlayStarted Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializePlayStarted(element);
        }
    }
}
