// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The call transfer accepted event.
    /// </summary>
    public partial class CallTransferAccepted : CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of CallTransferAccepted.</summary>
        /// <param name="internalEvent"> Internal Representation of the CallTransferAccepted event. </param>
        internal CallTransferAccepted(CallTransferAcceptedInternal internalEvent)
        {
            OperationContext = internalEvent.OperationContext;
            ResultInformation = internalEvent.ResultInformation;
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
        }

        /// <summary> Operation context. </summary>
        public override string OperationContext { get; internal set; }
        /// <summary> Gets the result info. </summary>
        public override ResultInformation ResultInformation { get; internal set; }

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
