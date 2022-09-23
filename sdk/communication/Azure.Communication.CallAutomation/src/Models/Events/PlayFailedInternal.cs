// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Play Failed event.
    /// </summary>
    [CodeGenModel("PlayFailed", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    internal partial class PlayFailedInternal : CallAutomationEventBase
    {
        /// <summary>
        /// Deserialize <see cref="PlayFailedInternal"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="PlayFailedInternal"/> object.</returns>
        public static PlayFailedInternal Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializePlayFailedInternal(element);
        }
    }
}
