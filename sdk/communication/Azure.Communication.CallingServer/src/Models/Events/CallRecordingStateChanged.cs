// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Communication.CallingServer.Converters;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The Call Recording state changed event
    /// </summary>
    [CodeGenModel("RecordingStateChangedEvent", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class CallRecordingStateChanged : CallAutomationEventBase
    {
        /// <summary>
        /// THe recording state
        /// </summary>
        [JsonConverter(typeof(EquatableEnumJsonConverter<RecordingState>))]
        public RecordingState State { get; set; }

        /// <summary>
        /// Deserialize <see cref="CallRecordingStateChanged"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="CallRecordingStateChanged"/> object.</returns>
        public static CallRecordingStateChanged Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeCallRecordingStateChanged(element);
        }
    }
}
