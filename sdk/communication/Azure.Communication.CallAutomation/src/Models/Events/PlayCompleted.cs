// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The play completed event.
    /// </summary>
    public partial class PlayCompleted : CallAutomationEventBase
    {
        /// <summary>
        /// Reason code.
        /// </summary>
        public MediaEventReasonCode ReasonCode { get; internal set; }

        /// <summary> Initializes a new instance of PlayCompleted. </summary>
        /// <param name="internalEvent"> PlayCompletedInternal event. </param>
        internal PlayCompleted(PlayCompletedInternal internalEvent)
        {
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
            OperationContext = internalEvent.OperationContext;
            ResultInformation = internalEvent.ResultInformation;
            ReasonCode = new MediaEventReasonCode(ResultInformation.SubCode.ToString());
        }

        /// <summary>
        /// Deserialize <see cref="PlayCompleted"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="PlayCompleted"/> object.</returns>
        public static PlayCompleted Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return new PlayCompleted(PlayCompletedInternal.DeserializePlayCompletedInternal(element));
        }
    }
}
