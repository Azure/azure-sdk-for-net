// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Call Recording state changed event
    /// </summary>
    [CodeGenModel("RecordingStateChanged", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class RecordingStateChanged : CallAutomationEventBase
    {
        /// <summary>
        /// THe recording state
        /// </summary>
        [JsonConverter(typeof(EquatableEnumJsonConverter<RecordingState>))]
        public RecordingState State { get; set; }

        /// <summary>
        /// Deserialize <see cref="RecordingStateChanged"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="RecordingStateChanged"/> object.</returns>
        public static RecordingStateChanged Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeRecordingStateChanged(element);
        }
    }
}
