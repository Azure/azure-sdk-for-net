// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.Calling.Server
{
    /// <summary>
    /// The call state change event.
    /// </summary>
    public class CallLegStateChangedEvent : CallEventBase
    {
        /// <summary>
        /// The event type.
        /// </summary>
        public const string EventType = "Microsoft.Communication.CallLegStateChanged";

        /// <summary>
        /// The conversation id.
        /// </summary>
        public string ConversationId { get; set; }

        /// <summary>
        /// The call leg.id.
        /// </summary>
        public string CallLegId { get; set; }

        /// <summary>
        /// The call state.
        /// </summary>
        public CallState CallState { get; set; }

        /// <summary> Initializes a new instance of CallLegStateChangedEvent. </summary>
        /// <param name="conversationId"> The conversation id. </param>
        /// <param name="callLegId"> The call leg id. </param>
        /// <param name="callState"> The call state. </param>
        public CallLegStateChangedEvent(string conversationId, string callLegId, CallState callState)
        {
            ConversationId = conversationId;
            CallLegId = callLegId;
            CallState = callState;
        }
    }
}
