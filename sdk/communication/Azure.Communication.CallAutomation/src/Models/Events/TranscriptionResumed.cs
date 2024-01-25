// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The TranscriptionResumed event.
    /// </summary>

    [CodeGenModel("TranscriptionResumed", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class TranscriptionResumed : CallAutomationEventBase
    {
        /// <summary>
        /// Deserialize <see cref="TranscriptionResumed"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="TranscriptionResumed"/> object.</returns>
        public static TranscriptionResumed Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeTranscriptionResumed(element);
        }
    }
}
