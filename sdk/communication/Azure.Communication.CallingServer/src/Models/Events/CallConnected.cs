// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The call connected event.
    /// </summary>
    public class CallConnected : CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of CallConnected Event. </summary>
        /// <param name="internalEvent"> Internal Representation of the CallConnected Event. </param>
        internal CallConnected(CallConnectedInternal internalEvent)
        {
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
        }

        /// <summary>
        /// Deserialize <see cref="CallConnected"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="CallConnected"/> object.</returns>
        public static CallConnected Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = CallConnectedInternal.DeserializeCallConnectedInternal(element);
            return new CallConnected(internalEvent);
        }
    }
}
