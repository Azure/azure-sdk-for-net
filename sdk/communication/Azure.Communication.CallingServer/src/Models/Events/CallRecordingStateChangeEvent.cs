// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The call recording state change event.
    /// </summary>
    [CodeGenModel("CallRecordingStateChangeEvent", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class CallRecordingStateChangeEvent : CallingServerEventBase
    {
        /// <summary>
        /// Deserialize <see cref="CallRecordingStateChangeEvent"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="CallRecordingStateChangeEvent"/> object.</returns>
        public static CallRecordingStateChangeEvent Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeCallRecordingStateChangeEvent(element);
        }
    }
}
