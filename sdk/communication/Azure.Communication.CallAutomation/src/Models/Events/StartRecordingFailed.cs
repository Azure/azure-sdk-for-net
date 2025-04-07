// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Communication.CallAutomation.Models.Events
{
    /// <summary>
    /// The start recording failed event.
    /// </summary>
    public class StartRecordingFailed : CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of StartRecordingFailedEvent. </summary>
        internal StartRecordingFailed()
        {
        }

        /// <summary> Initializes a new instance of StartRecordingFailed. </summary>
        /// <param name="internalEvent">Internal Representation of the StartRecordingFailed. </param>
        internal StartRecordingFailed(StartRecordingFailedInternal internalEvent)
        {
            CallConnectionId = internalEvent.CallConnectionId;
            CorrelationId = internalEvent.CorrelationId;
            RecordingId = internalEvent.RecordingId;
        }

        /// <summary> The call recording Id. </summary>
        public string RecordingId { get; }

        /// <summary>
        /// Deserialize <see cref="StartRecordingFailed"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="StartRecordingFailed"/> object.</returns>
        public static StartRecordingFailed Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = StartRecordingFailedInternal.DeserializeStartRecordingFailedInternal(element);
            return new StartRecordingFailed(internalEvent);
        }
    }
}
