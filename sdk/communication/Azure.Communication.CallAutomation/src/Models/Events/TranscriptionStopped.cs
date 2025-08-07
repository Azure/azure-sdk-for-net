// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The TranscriptionStopped event.
    /// </summary>

    [CodeGenModel("TranscriptionStopped", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class TranscriptionStopped : CallAutomationEventBase
    {
        /// <summary>
        /// Deserialize <see cref="TranscriptionStopped"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="TranscriptionStopped"/> object.</returns>
        public static TranscriptionStopped Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeTranscriptionStopped(element);
        }
    }
}
