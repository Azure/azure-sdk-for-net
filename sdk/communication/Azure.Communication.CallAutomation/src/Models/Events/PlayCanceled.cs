// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Play Canceled event.
    /// </summary>
    [CodeGenModel("PlayCanceled", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class PlayCanceled : CallAutomationEventBase
    {
        /// <summary>
        /// Deserialize <see cref="PlayCanceled"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="PlayCanceled"/> object.</returns>
        public static PlayCanceled Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializePlayCanceled(element);
        }
    }
}
