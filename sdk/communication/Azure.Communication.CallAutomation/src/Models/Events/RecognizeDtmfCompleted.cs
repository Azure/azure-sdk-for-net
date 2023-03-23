// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;
using System.Text.Json.Serialization;
using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Recognize Dtmf Completed event.
    /// </summary>
    public class RecognizeDtmfCompleted : RecognizeCompleted
    {
        /// <summary> Get the recognize Tone result. </summary>
        public CollectTonesResult CollectTonesResult { get; }
        /// <summary>
        /// The recognition type.
        /// </summary>
        [CodeGenMember("RecognitionType")]
        [JsonConverter(typeof(EquatableEnumJsonConverter<CallMediaRecognitionType>))]
        public CallMediaRecognitionType RecognitionType { get; internal set; }

        /// <summary> Initializes a new instance of RecognizeDtmfCompleted. </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code/sub-code and message from NGC services. </param>
        /// <param name="recognitionType">
        /// Determines the sub-type of the recognize operation.
        /// In case of cancel operation the this field is not set and is returned empty
        /// </param>
        /// <param name="collectTonesResult"> Defines the result for RecognitionType = Choices. </param>
        public RecognizeDtmfCompleted(string callConnectionId, string serverCallId, string correlationId, string operationContext, ResultInformation resultInformation, CallMediaRecognitionType recognitionType, CollectTonesResult collectTonesResult)
        {
            CallConnectionId = callConnectionId;
            ServerCallId = serverCallId;
            CorrelationId = correlationId;
            OperationContext = operationContext;
            ResultInformation = resultInformation;
            RecognitionType = recognitionType;
            CollectTonesResult = collectTonesResult;
        }
    }
}
