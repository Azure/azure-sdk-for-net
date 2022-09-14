// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Communication.CallingServer.Converters;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The Call Recording state changed event internal.
    /// </summary>
    [CodeGenModel("RecordingStateChangedEvent", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    internal partial class CallRecordingStateChangedInternal
    {
        /// <summary>
        /// THe recording state
        /// </summary>
        [JsonConverter(typeof(EquatableEnumJsonConverter<RecordingState>))]
        public RecordingState State { get; set; }
    }
}
