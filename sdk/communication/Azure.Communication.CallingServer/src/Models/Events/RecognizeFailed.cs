// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The recognize failed event.
    /// </summary>
    public class RecognizeFailed : CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of RecognizeFailed event.</summary>
        /// <param name="internalEvent"> Internal Representation of the RecognizeFailed event. </param>
        internal RecognizeFailed(RecognizeFailedInternal internalEvent)
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
        /// Deserialize <see cref="RecognizeFailed"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="RecognizeFailed"/> object.</returns>
            public static RecognizeFailed Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = RecognizeFailedInternal.DeserializeRecognizeFailedInternal(element);
            return new RecognizeFailed(internalEvent);
        }
    }
}
