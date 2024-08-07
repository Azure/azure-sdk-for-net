// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The TranscriptionFailed event.
    /// </summary>

    public partial class TranscriptionFailed : CallAutomationEventBase
    {
        /// <summary>
        /// Reason code.
        /// </summary>
        public MediaEventReasonCode ReasonCode { get; internal set; }

        /// <summary>
        /// Defines the result for TranscriptionUpdate with the current status and the details about the status.
        /// </summary>
        public TranscriptionUpdate TranscriptionUpdate { get; }

        /// <summary> Initializes a new instance of TranscriptionFailed. </summary>
        /// <param name="internalEvent"> TranscriptionFailedInternal event. </param>
        internal TranscriptionFailed(TranscriptionFailedInternal internalEvent)
        {
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
            OperationContext = internalEvent.OperationContext;
            ResultInformation = internalEvent.ResultInformation;
            TranscriptionUpdate = internalEvent.TranscriptionUpdate;
            ReasonCode = new MediaEventReasonCode(ResultInformation.SubCode.ToString());
        }

        /// <summary>
        /// Deserialize <see cref="TranscriptionFailed"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="TranscriptionFailed"/> object.</returns>
        public static TranscriptionFailed Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return new TranscriptionFailed(TranscriptionFailedInternal.DeserializeTranscriptionFailedInternal(element));
        }
    }
}
