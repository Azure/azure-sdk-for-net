// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The failed to answer call event.
    /// </summary>
    public partial class AnswerFailed : CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of AnswerFailed. </summary>
        internal AnswerFailed()
        {
        }

        internal AnswerFailed(AnswerFailedInternal internalEvent)
        {
            OperationContext = internalEvent.OperationContext;
            ResultInformation = internalEvent.ResultInformation;
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
        }

        /// <summary>
        /// Deserialize <see cref="AnswerFailed"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="AnswerFailed"/> object.</returns>
        public static AnswerFailed Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;
            var internalEvent = AnswerFailedInternal.DeserializeAnswerFailedInternal(element);
            return new AnswerFailed(internalEvent);
        }
    }
}
