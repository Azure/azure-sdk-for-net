// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The Call Recording state changed event
    /// </summary>
    public class CallRecordingStateChanged : CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of CallRecordingStateChangedInternal. </summary>
        /// <param name="internalEvent"></param>
        internal CallRecordingStateChanged(CallRecordingStateChangedInternal internalEvent)
        {
            RecordingId = internalEvent.RecordingId;
            State = internalEvent.State;
            StartDateTime = internalEvent.StartDateTime;
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
        }

        /// <summary>
        /// The call recording id
        /// </summary>
        public string RecordingId { get; internal set; }

        /// <summary>
        /// The call recording state.
        /// </summary>
        public RecordingState State { get; set; }

        /// <summary>
        /// The time of the recording started
        /// </summary>
        public DateTimeOffset? StartDateTime { get; internal set; }

        /// <summary>
        /// Deserialize <see cref="CallRecordingStateChanged"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="CallRecordingStateChanged"/> object.</returns>
        public static CallRecordingStateChanged Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = CallRecordingStateChangedInternal.DeserializeCallRecordingStateChangedInternal(element);
            return new CallRecordingStateChanged(internalEvent);
        }
    }
}
