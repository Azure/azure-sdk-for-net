// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Teams Recording state changed event
    /// </summary>
    [CodeGenModel("TeamsComplianceRecordingStateChanged", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class TeamsComplianceRecordingStateChanged : CallAutomationEventBase
    {
        /// <summary>
        /// The recording state
        /// </summary>
        [JsonConverter(typeof(EquatableEnumJsonConverter<RecordingState>))]
        public RecordingState State { get; set; }

        /// <summary>
        /// Deserialize <see cref="TeamsComplianceRecordingStateChanged"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="TeamsComplianceRecordingStateChanged"/> object.</returns>
        public static TeamsComplianceRecordingStateChanged Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeTeamsComplianceRecordingStateChanged(element);
        }
    }
}
