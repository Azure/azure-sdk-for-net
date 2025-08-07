// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Hold Failed event.
    /// </summary>
    public partial class HoldFailed : CallAutomationEventBase
    {
        /// <summary>
        /// Reason code.
        /// </summary>
        public MediaEventReasonCode ReasonCode { get; internal set; }

        /// <summary> Initializes a new instance of HoldFailed. </summary>
        /// <param name="internalEvent"> HoldFailedInternal event. </param>
        internal HoldFailed(HoldFailedInternal internalEvent)
        {
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
            OperationContext = internalEvent.OperationContext;
            ResultInformation = internalEvent.ResultInformation;
            ReasonCode = new MediaEventReasonCode(ResultInformation.SubCode.ToString());
        }

        /// <summary>
        /// Deserialize <see cref="HoldFailed"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="HoldFailed"/> object.</returns>
        public static HoldFailed Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return new HoldFailed(HoldFailedInternal.DeserializeHoldFailedInternal(element));
        }
    }
}
