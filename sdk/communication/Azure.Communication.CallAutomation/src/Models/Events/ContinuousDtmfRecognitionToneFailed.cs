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
    public partial class ContinuousDtmfRecognitionToneFailed : CallAutomationEventBase
    {
        /// <summary>
        /// Deserialize <see cref="ContinuousDtmfRecognitionToneFailed"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="ContinuousDtmfRecognitionToneFailed"/> object.</returns>
        public static ContinuousDtmfRecognitionToneFailed Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeContinuousDtmfRecognitionToneFailed(element);
        }
    }
}
