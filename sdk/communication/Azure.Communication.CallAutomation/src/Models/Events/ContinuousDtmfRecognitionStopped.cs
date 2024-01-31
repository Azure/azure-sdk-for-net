// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The ContinuousDtmfRecognitionStopped event.
    /// </summary>

    [CodeGenModel("ContinuousDtmfRecognitionStopped", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class ContinuousDtmfRecognitionStopped : CallAutomationEventBase
    {
        /// <summary>
        /// Deserialize <see cref="ContinuousDtmfRecognitionStopped"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="ContinuousDtmfRecognitionStopped"/> object.</returns>
        public static ContinuousDtmfRecognitionStopped Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeContinuousDtmfRecognitionStopped(element);
        }
    }
}
