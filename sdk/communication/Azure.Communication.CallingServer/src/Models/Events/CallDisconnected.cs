// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The call disconnected event.
    /// </summary>
    public class CallDisconnected : CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of CallDisconnected Event. </summary>
        /// <param name="internalEvent"> Internal Representation of the CallDisconnected Event. </param>
        internal CallDisconnected(CallDisconnectedInternal internalEvent)
        {
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
        }

        /// <summary>
        /// Deserialize <see cref="CallDisconnected"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="CallDisconnected"/> object.</returns>
        public static CallDisconnected Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = CallDisconnectedInternal.DeserializeCallDisconnectedInternal(element);
            return new CallDisconnected(internalEvent);
        }
    }
}
