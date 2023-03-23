// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;
using System.Text.Json.Serialization;
using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Recognize Choice completed event.
    /// </summary>
    public class RecognizeChoiceCompleted : RecognizeCompleted
    {
        /// <summary> The recognize choice result. </summary>
        public ChoiceResult ChoiceResult { get; }

        /// <summary>
        /// The recognition type.
        /// </summary>
        [CodeGenMember("RecognitionType")]
        [JsonConverter(typeof(EquatableEnumJsonConverter<CallMediaRecognitionType>))]
        public CallMediaRecognitionType RecognitionType { get; internal set; }

        /// <summary> Initializes a new instance of RecognizeChoiceCompleted. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code/sub-code and message from NGC services. </param>
        /// <param name="recognitionType">
        /// Determines the sub-type of the recognize operation.
        /// In case of cancel operation the this field is not set and is returned empty
        /// </param>
        /// <param name="choiceResult"> Defines the result for RecognitionType = Choices. </param>
        public RecognizeChoiceCompleted(string callConnectionId, string serverCallId, string correlationId, string operationContext, ResultInformation resultInformation, CallMediaRecognitionType recognitionType, ChoiceResult choiceResult)
        {
            CallConnectionId = callConnectionId;
            ServerCallId = serverCallId;
            CorrelationId = correlationId;
            OperationContext = operationContext;
            ResultInformation = resultInformation;
            RecognitionType = recognitionType;
            ChoiceResult = choiceResult;
        }
    }
}
