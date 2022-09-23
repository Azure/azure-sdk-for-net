// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The Play Failed event.
    /// </summary>
    [CodeGenModel("PlayFailed", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class PlayFailed : CallAutomationEventBase
    {
        /// <summary>
        /// Deserialize <see cref="PlayFailed"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="PlayFailed"/> object.</returns>
        public static PlayFailed Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializePlayFailed(element);
        }
    }
}
