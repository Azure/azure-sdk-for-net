// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    [CodeGenModel("RecognizeCompleted", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class RecognizeCompleted : CallAutomationEventWithReasonCodeName
    {
        /// <summary> Initializes a new instance of RecognizeCompleted. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code/sub-code and message from NGC services. </param>
        /// <param name="recognitionType">
        /// Determines the sub-type of the recognize operation.
        /// In case of cancel operation the this field is not set and is returned empty
        /// </param>
        /// <param name="collectTonesResult"> Defines the result for RecognitionType = Dtmf. </param>
        /// <param name="choiceResult"> Defines the result for RecognitionType = Choices. </param>
        internal RecognizeCompleted(string callConnectionId, string serverCallId, string correlationId, string operationContext, ResultInformation resultInformation, CallMediaRecognitionType recognitionType, CollectTonesResult collectTonesResult, ChoiceResult choiceResult)
        {
            CallConnectionId = callConnectionId;
            ServerCallId = serverCallId;
            CorrelationId = correlationId;
            OperationContext = operationContext;
            ResultInformation = resultInformation;
            RecognitionType = recognitionType;
            CollectTonesResult = collectTonesResult;
            ChoiceResult = choiceResult;
        }

        /// <summary> Initializes a new instance of RecognizeCompleted. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code/sub-code and message from NGC services. </param>
        /// <param name="recognitionType">
        /// Determines the sub-type of the recognize operation.
        /// In case of cancel operation the this field is not set and is returned empty
        /// </param>
        /// <param name="recognizeResult"> Defines the result for RecognitionType = Dtmf. </param>
        public RecognizeCompleted(string callConnectionId, string serverCallId, string correlationId, string operationContext, ResultInformation resultInformation, CallMediaRecognitionType recognitionType, RecognizeResult recognizeResult)
        {
            CallConnectionId = callConnectionId;
            ServerCallId = serverCallId;
            CorrelationId = correlationId;
            OperationContext = operationContext;
            ResultInformation = resultInformation;
            RecognitionType = recognitionType;
            ReasonCode = new ReasonCode(resultInformation.SubCode.ToString());
            if (recognizeResult is CollectTonesResult collectTonesResult)
            {
                CollectTonesResult = collectTonesResult;
            }
            else if (recognizeResult is ChoiceResult choiceResult)
            {
                ChoiceResult = choiceResult;
            }
        }

        /// <summary> Get the recognize result. </summary>
        public RecognizeResult GetRecognizeResult()
        {
            if (RecognitionType == CallMediaRecognitionType.Choices)
            {
                return ChoiceResult;
            }
            else if (RecognitionType == CallMediaRecognitionType.Dtmf)
            {
                return CollectTonesResult;
            }
            return null;
        }

        /// <summary>
        /// The recognition type.
        /// </summary>
        [CodeGenMember("RecognitionType")]
        [JsonConverter(typeof(EquatableEnumJsonConverter<CallMediaRecognitionType>))]
        public CallMediaRecognitionType RecognitionType { get; set; }

        /// <summary>
        /// Deserialize <see cref="RecognizeCompleted"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="RecognizeCompleted"/> object.</returns>
        public static RecognizeCompleted Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            RecognizeCompleted parsedRecognizeCompleted = DeserializeRecognizeCompleted(element);

            if (parsedRecognizeCompleted.RecognitionType == CallMediaRecognitionType.Dtmf)
            {
                return new RecognizeCompleted(parsedRecognizeCompleted.CallConnectionId,
                    parsedRecognizeCompleted.ServerCallId,
                    parsedRecognizeCompleted.CorrelationId,
                    parsedRecognizeCompleted.OperationContext,
                    parsedRecognizeCompleted.ResultInformation,
                    parsedRecognizeCompleted.RecognitionType,
                    parsedRecognizeCompleted.CollectTonesResult);
            }
            else if (parsedRecognizeCompleted.RecognitionType == CallMediaRecognitionType.Choices)
            {
                return new RecognizeCompleted(parsedRecognizeCompleted.CallConnectionId,
                    parsedRecognizeCompleted.ServerCallId,
                    parsedRecognizeCompleted.CorrelationId,
                    parsedRecognizeCompleted.OperationContext,
                    parsedRecognizeCompleted.ResultInformation,
                    parsedRecognizeCompleted.RecognitionType,
                    parsedRecognizeCompleted.ChoiceResult);
            }

            return null;
        }
    }
}
