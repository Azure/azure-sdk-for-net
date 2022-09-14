// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The recognize completed event.
    /// </summary>
    public class RecognizeCompleted : CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of RecognizeCompleted event.</summary>
        /// <param name="internalEvent"> Internal Representation of the RecognizeCompleted event. </param>
        internal RecognizeCompleted(RecognizeCompletedInternal internalEvent)
        {
            OperationContext = internalEvent.OperationContext;
            ResultInformation = internalEvent.ResultInformation;
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
            RecognitionType = internalEvent.RecognitionType;
            CollectTonesResult = internalEvent.CollectTonesResult;
        }

        /// <summary> Operation context. </summary>
        public override string OperationContext { get; internal set; }
        /// <summary> Gets the result info. </summary>
        public override ResultInformation ResultInformation { get; internal set; }
        /// <summary>
        /// Defines the result for RecognitionType = Dtmf
        /// </summary>
        public CollectTonesResult CollectTonesResult { get; internal set; }
        /// <summary>
        /// The recognition type.
        /// </summary>
        public CallMediaRecognitionType RecognitionType { get; internal set; }

        /// <summary>
        /// Deserialize <see cref="RecognizeCompleted"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="RecognizeCompleted"/> object.</returns>
        public static RecognizeCompleted Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = RecognizeCompletedInternal.DeserializeRecognizeCompletedInternal(element);
            return new RecognizeCompleted(internalEvent);
        }
    }
}
