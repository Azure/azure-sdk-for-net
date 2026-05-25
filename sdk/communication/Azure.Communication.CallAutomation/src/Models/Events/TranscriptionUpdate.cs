// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    [CodeGenModel("TranscriptionUpdate", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class TranscriptionUpdate : CallAutomationEventBase
    {
        /// <summary>
        /// Deserialize <see cref="TranscriptionUpdate"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="TranscriptionUpdate"/> object.</returns>
        public static TranscriptionUpdate Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeTranscriptionUpdate(element);
        }
    }
}
