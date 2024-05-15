// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Connect Failed event.
    /// </summary>
    public partial class ConnectFailed : CallAutomationEventBase
    {
        /// <summary>
        /// Reason code.
        /// </summary>
        public MediaEventReasonCode ReasonCode { get; internal set; }

        /// <summary> Initializes a new instance of ConnectFailed. </summary>
        /// <param name="internalEvent"> ConnectFailedInternal event. </param>
        internal ConnectFailed(ConnectFailedInternal internalEvent)
        {
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
            OperationContext = internalEvent.OperationContext;
            ResultInformation = internalEvent.ResultInformation;
            ReasonCode = new MediaEventReasonCode(ResultInformation.SubCode.ToString());
        }

        /// <summary>
        /// Deserialize <see cref="ConnectFailed"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="ConnectFailed"/> object.</returns>
        public static ConnectFailed Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return new ConnectFailed(ConnectFailedInternal.DeserializeConnectFailedInternal(element));
        }
    }
}
