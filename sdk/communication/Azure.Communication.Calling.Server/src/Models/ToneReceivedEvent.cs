// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.Calling.Server
{
    /// <summary>
    /// The subscribe to tone event
    /// </summary>
    public class ToneReceivedEvent : CallEventBase
    {
        /// <summary>
        /// The event type.
        /// </summary>
        public const string EventType = "Microsoft.Communication.DtmfReceived";
        /// <summary>
        /// The tone info.
        /// </summary>
        public ToneInfo ToneInfo { get; set; }

        /// <summary>
        /// The call leg.id.
        /// </summary>
        public string CallLegId { get; set; }

        /// <summary> Initializes a new instance of ToneReceivedEvent. </summary>
        /// <param name="toneInfo"> The call id. </param>
        /// <param name="callLegId"> The call leg id. </param>
        public ToneReceivedEvent(ToneInfo toneInfo, string callLegId)
        {
            ToneInfo = toneInfo;
            CallLegId = callLegId;
        }
    }
}
