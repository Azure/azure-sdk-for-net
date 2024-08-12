// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The SendDtmfFailed event.
    /// </summary>
    public class SendDtmfTonesFailed : CallAutomationEventBase
    {
        internal SendDtmfTonesFailed() { }

        internal SendDtmfTonesFailed(SendDtmfTonesFailedInternal internalEvent)
        {
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
            OperationContext = internalEvent.OperationContext;
            ResultInformation = internalEvent.ResultInformation;
        }

        /// <summary>
        /// Deserialize <see cref="SendDtmfTonesFailed"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="SendDtmfTonesFailed"/> object.</returns>
        public static SendDtmfTonesFailed Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = SendDtmfTonesFailedInternal.DeserializeSendDtmfTonesFailedInternal(element);
            return new SendDtmfTonesFailed(internalEvent);
        }
    }
}
