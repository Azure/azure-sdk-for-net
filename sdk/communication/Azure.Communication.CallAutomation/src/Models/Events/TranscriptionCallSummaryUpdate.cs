// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The TranscriptionCallSummaryUpdate event.
    /// </summary>

    [CodeGenModel("TranscriptionCallSummaryUpdate", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class TranscriptionCallSummaryUpdate : CallAutomationEventBase
    {
        /// <summary>
        /// Deserialize <see cref="TranscriptionStarted"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="TranscriptionCallSummaryUpdate"/> object.</returns>
        public static TranscriptionCallSummaryUpdate Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeTranscriptionCallSummaryUpdate(element);
        }
    }
}
