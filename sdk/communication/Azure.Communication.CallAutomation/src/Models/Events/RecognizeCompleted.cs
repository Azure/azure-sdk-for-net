// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;
using System.Text.Json.Serialization;
using System;
using System.Runtime.Serialization;
using System.IO;
using System.Text;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Recognize completed event.
    /// </summary>
    public partial class RecognizeCompleted : CallAutomationEventBase
    {
        /// <summary> The abstract recognize result. </summary>
        public RecognizeResult RecognizeResult { get; }

        /// <summary>
        /// The recognition type.
        /// </summary>
        [CodeGenMember("RecognitionType")]
        [JsonConverter(typeof(EquatableEnumJsonConverter<CallMediaRecognitionType>))]
        public CallMediaRecognitionType RecognitionType { get; set; }

        /// <summary> Initializes a new instance of RecognizeCompleted. </summary>
        internal RecognizeCompleted()
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
        /// <param name="recognizeResult"> Defines the result for general recognizeResult. </param>
        internal RecognizeCompleted(string callConnectionId, string serverCallId, string correlationId, string operationContext, ResultInformation resultInformation, CallMediaRecognitionType recognitionType, RecognizeResult recognizeResult)
        {
            CallConnectionId = callConnectionId;
            ServerCallId = serverCallId;
            CorrelationId = correlationId;
            OperationContext = operationContext;
            ResultInformation = resultInformation;
            RecognitionType = recognitionType;
            RecognizeResult = recognizeResult;
        }

        /// <summary> Initializes a new instance of RecognizeCompletedEvent. </summary>
        /// <param name="internalEvent"> Internal Representation of the RecognizeCompletedEvent. </param>
        internal RecognizeCompleted(RecognizeCompletedInternal internalEvent)
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
        }

        /// <summary>
        /// Deserialize <see cref="RecognizeCompleted"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="RecognizeCompleted"/> object.</returns>
        public static RecognizeCompleted Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            RecognizeCompletedInternal parsedRecognizeCompleted = RecognizeCompletedInternal.DeserializeRecognizeCompletedInternal(element);

            return new RecognizeCompleted(parsedRecognizeCompleted);
        }

        /// <summary>
        /// Serialize <see cref="RecognizeCompleted"/> event.
        /// </summary>
        /// <returns>The serialized json string.</returns>
        public string Serialize()
        {
            string jsonValue = "";

            var options = new JsonWriterOptions
            {
                Indented = true
            };

            JsonConverter jsonConverter = new EquatableEnumJsonConverter<CallMediaRecognitionType>();
            var recognitionTypeOption = new JsonSerializerOptions()
            {
                Converters = { jsonConverter },
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream, options);
            JsonSerializerOptions jsonSeializerOptionForObject = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            jsonSeializerOptionForObject.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
            writer.WriteStartObject();
            writer.WriteString("callConnectionId", CallConnectionId);
            writer.WriteString("serverCallId", ServerCallId);
            writer.WriteString("correlationId", CorrelationId);
            writer.WriteString("operationContext", OperationContext);
            writer.WritePropertyName("resultInformation");
            JsonSerializer.Serialize(writer, ResultInformation, jsonSeializerOptionForObject);
            writer.WritePropertyName("recognitionType");
            JsonSerializer.Serialize(writer, RecognitionType, recognitionTypeOption);

            if (RecognitionType == CallMediaRecognitionType.Dtmf)
            {
                DtmfResult dtmfResult = (DtmfResult)RecognizeResult;
                writer.WritePropertyName("dtmfResult");
                JsonSerializer.Serialize(writer, dtmfResult, jsonSeializerOptionForObject);
            }
            else if (RecognitionType == CallMediaRecognitionType.Choices)
            {
                ChoiceResult choiceResult = (ChoiceResult)RecognizeResult;
                writer.WritePropertyName("choiceResult");
                JsonSerializer.Serialize(writer, choiceResult, jsonSeializerOptionForObject);
            }
            else if (RecognitionType == CallMediaRecognitionType.Speech)
            {
                SpeechResult speechResult = (SpeechResult)RecognizeResult;
                writer.WritePropertyName("speechResult");
                JsonSerializer.Serialize(writer, speechResult, jsonSeializerOptionForObject);
            }

            writer.WriteEndObject();
            writer.Flush();

            jsonValue = Encoding.UTF8.GetString(stream.ToArray());

            return jsonValue;
        }
    }
}
