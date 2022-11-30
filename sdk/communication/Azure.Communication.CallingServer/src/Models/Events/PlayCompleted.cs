// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The play completed event.
    /// </summary>
    [CodeGenModel("PlayCompleted", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class PlayCompleted : CallAutomationEventBase
    {
        /// <summary>
        /// Deserialize <see cref="PlayCompleted"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="PlayCompleted"/> object.</returns>
        public static PlayCompleted Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializePlayCompleted(element);
        }
    }
}
