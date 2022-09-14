// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The call transfer failed event.
    /// </summary>
    public partial class CallTransferFailed : CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of CallTransferFailed.</summary>
        /// <param name="internalEvent"> Internal Representation of the CallTransferFailed event. </param>
        internal CallTransferFailed(CallTransferFailedInternal internalEvent)
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
        /// Deserialize <see cref="CallTransferFailed"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="CallTransferFailed"/> object.</returns>
        public static CallTransferFailed Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = CallTransferFailedInternal.DeserializeCallTransferFailedInternal(element);
            return new CallTransferFailed(internalEvent);
        }
    }
}
