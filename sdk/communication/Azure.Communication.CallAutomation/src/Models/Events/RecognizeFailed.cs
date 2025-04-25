// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System.Text.Json;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Recognize failed event.
    /// </summary>
    public partial class RecognizeFailed : CallAutomationEventBase
    {
        /// <summary>
        /// Reason code.
        /// </summary>
        public MediaEventReasonCode ReasonCode { get; internal set; }

        /// <summary> Contains the index of the failed play source. </summary>
        public int? FailedPlaySourceIndex { get; internal set; }

        /// <summary> Initializes a new instance of RecognizeFailed. </summary>
        /// <param name="internalEvent"> RecognizeFailedInternal event </param>
        internal RecognizeFailed(RecognizeFailedInternal internalEvent)
        {
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
            OperationContext = internalEvent.OperationContext;
            ResultInformation = internalEvent.ResultInformation;
            ReasonCode = new MediaEventReasonCode(ResultInformation.SubCode.ToString());
            FailedPlaySourceIndex = internalEvent.FailedPlaySourceIndex;
        }

        /// <summary>
        /// Deserialize <see cref="RecognizeFailed"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="RecognizeFailed"/> object.</returns>
        public static RecognizeFailed Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return new RecognizeFailed(RecognizeFailedInternal.DeserializeRecognizeFailedInternal(element));
        }
    }
}
