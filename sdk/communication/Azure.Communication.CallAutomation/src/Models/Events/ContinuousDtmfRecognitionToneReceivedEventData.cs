// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The ContinuousDtmfRecognitionToneReceived event.
    /// </summary>

    [CodeGenModel("ContinuousDtmfRecognitionToneReceived", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class ContinuousDtmfRecognitionToneReceivedEventData : CallAutomationEventData
    {
        /// <summary>
        /// Deserialize <see cref="ContinuousDtmfRecognitionToneReceivedEventData"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="ContinuousDtmfRecognitionToneReceivedEventData"/> object.</returns>
        public static ContinuousDtmfRecognitionToneReceivedEventData Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeContinuousDtmfRecognitionToneReceivedEventData(element);
        }
    }
}
