// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The ContinuousDtmfRecognitionToneFailed event.
    /// </summary>

    [CodeGenModel("ContinuousDtmfRecognitionToneFailed", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class ContinuousDtmfRecognitionToneFailedEventData : CallAutomationEventData
    {
        /// <summary>
        /// Deserialize <see cref="ContinuousDtmfRecognitionToneFailedEventData"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="ContinuousDtmfRecognitionToneFailedEventData"/> object.</returns>
        public static ContinuousDtmfRecognitionToneFailedEventData Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeContinuousDtmfRecognitionToneFailedEventData(element);
        }
    }
}
