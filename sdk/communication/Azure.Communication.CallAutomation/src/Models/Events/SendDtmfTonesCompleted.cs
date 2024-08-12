// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The SendDtmfTonesCompleted event.
    /// </summary>

    public class SendDtmfTonesCompleted : CallAutomationEventBase
    {
        internal SendDtmfTonesCompleted() { }

        internal SendDtmfTonesCompleted(SendDtmfTonesCompletedInternal internalEvent)
        {
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
            OperationContext = internalEvent.OperationContext;
            ResultInformation = internalEvent.ResultInformation;
        }

        /// <summary>
        /// Deserialize <see cref="SendDtmfTonesCompleted"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="SendDtmfTonesCompleted"/> object.</returns>
        public static SendDtmfTonesCompleted Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = SendDtmfTonesCompletedInternal.DeserializeSendDtmfTonesCompletedInternal(element);
            return new SendDtmfTonesCompleted(internalEvent);
        }
    }
}
