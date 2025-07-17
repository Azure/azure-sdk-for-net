// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The StartRecordingFailed event.
    /// </summary>

    [CodeGenModel("StartRecordingFailed", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class StartRecordingFailed : CallAutomationEventBase
    {
        /// <summary>
        /// Deserialize <see cref="StartRecordingFailed"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="StartRecordingFailed"/> object.</returns>
        public static StartRecordingFailed Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeStartRecordingFailed(element);
        }
    }
}
