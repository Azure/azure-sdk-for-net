// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;
using System.Text.Json.Serialization;
using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Recognize completed event.
    /// </summary>
    public partial class RecognizeCompletedEventData : CallAutomationEventData
    {
        /// <summary> The abstract recognize result. </summary>
        public RecognizeResult RecognizeResult { get; }

        private static string SPEECH_DTMF_ERROR = "Speech or Dtmf Recognition return two results!";

        /// <summary>
        /// The recognition type.
        /// </summary>
        [CodeGenMember("RecognitionType")]
        [JsonConverter(typeof(EquatableEnumJsonConverter<CallMediaRecognitionType>))]
        private CallMediaRecognitionType RecognitionType { get; set; }

        /// <summary> Initializes a new instance of RecognizeCompleted. </summary>
        internal RecognizeCompletedEventData()
        {
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
        /// <param name="dtmfResult"> Defines the result for RecognitionType = Dtmf. </param>
        /// <param name="choiceResult"> Defines the result for RecognitionType = Choices. </param>
        /// <param name="speechResult"> Defines the result for RecognitionType = Speech. </param>
        internal RecognizeCompletedEventData(string callConnectionId, string serverCallId, string correlationId, string operationContext, ResultInformation resultInformation, CallMediaRecognitionType recognitionType, DtmfResult dtmfResult, ChoiceResult choiceResult, SpeechResult speechResult)
        {
            CallConnectionId = callConnectionId;
            ServerCallId = serverCallId;
            CorrelationId = correlationId;
            OperationContext = operationContext;
            ResultInformation = resultInformation;
            RecognitionType = recognitionType;

            if (RecognitionType == CallMediaRecognitionType.Dtmf)
            {
                RecognizeResult = dtmfResult;
            }
            else if (RecognitionType == CallMediaRecognitionType.Choices)
            {
                RecognizeResult = choiceResult;
            }
            else if (RecognitionType == CallMediaRecognitionType.Speech || RecognitionType == CallMediaRecognitionType.SpeechOrDtmf)
            {
                RecognizeResult = speechResult;
            }
        }

        /// <summary> Initializes a new instance of RecognizeCompletedEvent. </summary>
        /// <param name="internalEvent"> Internal Representation of the RecognizeCompletedEvent. </param>
        internal RecognizeCompletedEventData(RecognizeCompletedInternal internalEvent)
        {
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
            OperationContext = internalEvent.OperationContext;
            ResultInformation = internalEvent.ResultInformation;
            if (internalEvent.RecognitionType == CallMediaRecognitionType.Dtmf)
            {
                RecognizeResult = internalEvent.DtmfResult;
            }
            else if (internalEvent.RecognitionType == CallMediaRecognitionType.Choices)
            {
                RecognizeResult = internalEvent.ChoiceResult;
            }
            else if (internalEvent.RecognitionType == CallMediaRecognitionType.Speech)
            {
                RecognizeResult = internalEvent.SpeechResult;
            }
            else if (internalEvent.RecognitionType == CallMediaRecognitionType.SpeechOrDtmf)
            {
                if (internalEvent.SpeechResult != null)
                {
                    RecognizeResult = internalEvent.SpeechResult;
                }
                else if (internalEvent.DtmfResult != null)
                {
                    RecognizeResult = internalEvent.DtmfResult;
                }
                else
                {
                    throw new Exception(SPEECH_DTMF_ERROR);
                }
            }
        }

        /// <summary>
        /// Deserialize <see cref="RecognizeCompletedEventData"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="RecognizeCompletedEventData"/> object.</returns>
        public static RecognizeCompletedEventData Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            RecognizeCompletedInternal parsedRecognizeCompleted = RecognizeCompletedInternal.DeserializeRecognizeCompletedInternal(element);

            return new RecognizeCompletedEventData(parsedRecognizeCompleted);
        }
    }
}
