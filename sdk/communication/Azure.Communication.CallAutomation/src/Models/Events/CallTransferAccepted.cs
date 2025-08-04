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
        /// <summary>
        /// Transferee is the participant who is transferring the call.
        /// </summary>
        public CommunicationIdentifier Transferee { get; }

        /// <summary>
        /// The identity of the target where call should be transferred to.
        /// </summary>
        public CommunicationIdentifier TransferTarget { get; }
        /// <summary> Initializes a new instance of CallTransferAccepted. </summary>
        internal CallTransferAccepted()
        {
        }
        internal CallTransferAccepted(CallTransferAcceptedInternal internalEvent)
        {
            OperationContext = internalEvent.OperationContext;
            ResultInformation = internalEvent.ResultInformation;
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
            Transferee = internalEvent.Transferee == null ? null : CommunicationIdentifierSerializer_2025_06_30.Deserialize(internalEvent.Transferee);
            TransferTarget = internalEvent.TransferTarget == null ? null : CommunicationIdentifierSerializer_2025_06_30.Deserialize(internalEvent.TransferTarget);
        }

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
