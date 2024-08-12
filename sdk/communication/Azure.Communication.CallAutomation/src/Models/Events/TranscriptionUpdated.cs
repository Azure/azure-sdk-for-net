// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The TranscriptionUpdated event.
    /// </summary>

    [CodeGenModel("TranscriptionUpdated", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class TranscriptionUpdated : CallAutomationEventBase
    {
        /// <summary>
        /// Deserialize <see cref="TranscriptionUpdated"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="TranscriptionUpdated"/> object.</returns>
        public static TranscriptionUpdated Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeTranscriptionUpdated(element);
        }
    }
}
