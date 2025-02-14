// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The TranscriptionFailed event.
    /// </summary>

    [CodeGenModel("TranscriptionFailed", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class TranscriptionFailed : CallAutomationEventBase
    {
        /// <summary>
        /// Deserialize <see cref="TranscriptionFailed"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="TranscriptionFailed"/> object.</returns>
        public static TranscriptionFailed Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeTranscriptionFailed(element);
        }
    }
}
