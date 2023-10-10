// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The call transfer accepted event.
    /// </summary>
    public partial class CallTransferAccepted : CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of CallTransferAccepted. </summary>
        internal CallTransferAccepted()
        {
        }

        /// <summary> Initializes a new instance of CallTransferAccepted event. </summary>
        /// <param name="internalEvent">Internal Representation of the CallTransferAccepted event. </param>
        internal CallTransferAccepted(CallTransferAcceptedInternal internalEvent)
        {
            OperationContext = internalEvent.OperationContext;
            ResultInformation = internalEvent.ResultInformation;
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
            Transferee = internalEvent.Transferee == null ? null : CommunicationIdentifierSerializer.Deserialize(internalEvent.Transferee);
            TransferTarget = internalEvent.TransferTarget == null ? null : CommunicationIdentifierSerializer.Deserialize(internalEvent.TransferTarget);
        }

        /// <summary> Target who the call is transferred to. </summary>
        public CommunicationIdentifier TransferTarget { get; }
        /// <summary> the participant who is being transferred away. </summary>
        public CommunicationIdentifier Transferee { get; }

        /// <summary>
        /// Deserialize <see cref="CallTransferAccepted"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="CallTransferAccepted"/> object.</returns>
        public static CallTransferAccepted Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = CallTransferAcceptedInternal.DeserializeCallTransferAcceptedInternal(element);
            return new CallTransferAccepted(internalEvent);
        }
    }
}
