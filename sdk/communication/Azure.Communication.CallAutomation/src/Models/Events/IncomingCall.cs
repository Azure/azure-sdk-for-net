// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The add participant failed event.
    /// </summary>
    public class IncomingCall : CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of <see cref="IncomingCall"/>. </summary>
        internal IncomingCall()
        {
        }

        /// <summary> Initializes a new instance of <see cref="IncomingCall"/>. </summary>
        /// <param name="internalEvent">Internal Representation of the IncomingCall. </param>
        internal IncomingCall(IncomingCallInternal internalEvent)
        {
            To = CommunicationIdentifierSerializer.Deserialize(internalEvent.To);
            From = CommunicationIdentifierSerializer.Deserialize(internalEvent.From);
            ServerCallId = internalEvent.ServerCallId;
            CallerDisplayName = internalEvent.CallerDisplayName;
            CustomContext = new CustomCallingContext(internalEvent.CustomContext.SipHeaders, internalEvent.CustomContext.VoipHeaders);
            IncomingCallContext = internalEvent.IncomingCallContext;

            if (internalEvent.OnBehalfOfCallee != null)
            {
                OnBehalfOfCallee = CommunicationIdentifierSerializer.Deserialize(internalEvent.OnBehalfOfCallee);
            }

            CorrelationId = internalEvent.CorrelationId;
        }

        /// <summary> The communication identifier of the target user. </summary>
        public CommunicationIdentifier To { get; }
        /// <summary> The communication identifier of the user who initiated the call. </summary>
        public CommunicationIdentifier From { get; }
        /// <summary> Display name of caller. </summary>
        public string CallerDisplayName { get; }
        /// <summary> Custom Context of Incoming Call. </summary>
        public CustomCallingContext CustomContext { get; }
        /// <summary> Incoming call context. </summary>
        public string IncomingCallContext { get; }
        /// <summary> The communication identifier of the user on behalf of whom the call is made. </summary>
        public CommunicationIdentifier OnBehalfOfCallee { get; }

        /// <summary>
        /// Deserialize <see cref="IncomingCall"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="IncomingCall"/> object.</returns>
        public static IncomingCall Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = IncomingCallInternal.DeserializeIncomingCallInternal(element);
            return new IncomingCall(internalEvent);
        }
    }
}
