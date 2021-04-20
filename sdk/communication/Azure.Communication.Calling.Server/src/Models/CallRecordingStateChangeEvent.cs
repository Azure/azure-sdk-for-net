// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.Calling.Server
{
    /// <summary>
    /// The call recording state change event.
    /// </summary>
    public class CallRecordingStateChangeEvent : CallEventBase
    {
        /// <summary>
        /// The call recording id
        /// </summary>
        public string RecordingId { get; set; }

        /// <summary>
        /// The call recording state.
        /// </summary>
        public CallRecordingState State { get; set; }

        /// <summary>
        /// The time of the recording started
        /// </summary>
        public DateTimeOffset StartDateTime { get; set; }

        /// <summary>
        /// The conversation id from a out call start recording request
        /// </summary>
        public string ConversationId { get; set; }

        /// <summary> Initializes a new instance of CallRecordingStateChangeEvent. </summary>
        /// <param name="recordingId"> The recording id. </param>
        /// <param name="state"> The state. </param>
        /// <param name="startDateTime"> The startDateTime. </param>
        /// <param name="conversationId"> The conversation id. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="recordingId"/>, <paramref name="state"/>, <paramref name="startDateTime"/>, <paramref name="conversationId"/> is null. </exception>
        public CallRecordingStateChangeEvent(string recordingId, CallRecordingState state, DateTimeOffset startDateTime, string conversationId)
        {
            if (recordingId == null)
            {
                throw new ArgumentNullException(nameof(recordingId));
            }
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }
            if (startDateTime == null)
            {
                throw new ArgumentNullException(nameof(startDateTime));
            }
            if (conversationId == null)
            {
                throw new ArgumentNullException(nameof(conversationId));
            }

            RecordingId = recordingId;
            State = state;
            StartDateTime = startDateTime;
            ConversationId = conversationId;
        }
    }
}
