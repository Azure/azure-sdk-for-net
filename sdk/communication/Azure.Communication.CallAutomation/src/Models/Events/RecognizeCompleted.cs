// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.CallAutomation.Converters;
using Azure.Communication.CallAutomation.Models.Events;
using Azure.Core;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The play completed event.
    /// </summary>
    public partial class RecognizeCompleted : CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of RecognizeCompletedInternal. </summary>
        internal RecognizeCompleted()
        {
        }

        /// <summary> Initializes a new instance of RecognizeCompletedInternal. </summary>
        /// <param name="operationContext"></param>
        /// <param name="resultInformation"> Result information defines the code, subcode and message. </param>
        /// <param name="recognitionType">
        /// Determines the sub-type of the recognize operation.
        /// In case of cancel operation the this field is not set and is returned empty
        /// </param>
        /// <param name="collectTonesResult"> Defines the result for RecognitionType = Dtmf. </param>
        /// <param name="version"> Used to determine the version of the event. </param>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <param name="publicEventType"> The public event namespace used as the &quot;type&quot; property in the CloudEvent. </param>
        internal RecognizeCompleted(string operationContext, ResultInformation resultInformation, CallMediaRecognitionType recognitionType, CollectTonesResult collectTonesResult, string version, string callConnectionId, string serverCallId, string correlationId, string publicEventType)
        {
            OperationContext = operationContext;
            ResultInformation = resultInformation;
            RecognitionType = recognitionType;
            CollectTonesResult = collectTonesResult;
            Version = version;
            CallConnectionId = callConnectionId;
            ServerCallId = serverCallId;
            CorrelationId = correlationId;
            PublicEventType = publicEventType;
            ReasonCodeName = new ReasonCodeName(ResultInformation.SubCode.ToString());
        }

        /// <summary> Gets the operation context. </summary>
        public string OperationContext { get; }
        /// <summary> Result information defines the code, subcode and message. </summary>
        public ResultInformation ResultInformation { get; }
        /// <summary> Defines the result for RecognitionType = Dtmf. </summary>
        public CollectTonesResult CollectTonesResult { get; }
        /// <summary> Used to determine the version of the event. </summary>
        public string Version { get; }
        /// <summary> The public event namespace used as the &quot;type&quot; property in the CloudEvent. </summary>
        public string PublicEventType { get; }
        /// <summary> The recognition type. </summary>
        [JsonConverter(typeof(EquatableEnumJsonConverter<CallMediaRecognitionType>))]
        public CallMediaRecognitionType RecognitionType { get; }
        /// <summary> Success reason. </summary>
        public ReasonCodeName ReasonCodeName { get; }

        /// <summary>
        /// Deserialize <see cref="RecognizeCompletedInternal"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="RecognizeCompletedInternal"/> object.</returns>
        public static RecognizeCompleted Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeRecognizeCompleted(element);
        }

        internal static RecognizeCompleted DeserializeRecognizeCompleted(JsonElement element)
        {
            Optional<string> operationContext = default;
            Optional<ResultInformation> resultInformation = default;
            Optional<CallMediaRecognitionType> recognitionType = default;
            Optional<CollectTonesResult> collectTonesResult = default;
            Optional<string> version = default;
            Optional<string> callConnectionId = default;
            Optional<string> serverCallId = default;
            Optional<string> correlationId = default;
            Optional<string> publicEventType = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("operationContext"))
                {
                    operationContext = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("resultInformation"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    resultInformation = ResultInformation.DeserializeResultInformation(property.Value);
                    continue;
                }
                if (property.NameEquals("recognitionType"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    recognitionType = new CallMediaRecognitionType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("collectTonesResult"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    collectTonesResult = CollectTonesResult.DeserializeCollectTonesResult(property.Value);
                    continue;
                }
                if (property.NameEquals("version"))
                {
                    version = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("callConnectionId"))
                {
                    callConnectionId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("serverCallId"))
                {
                    serverCallId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("correlationId"))
                {
                    correlationId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("publicEventType"))
                {
                    publicEventType = property.Value.GetString();
                    continue;
                }
            }
            return new RecognizeCompleted(operationContext.Value, resultInformation.Value, recognitionType, collectTonesResult.Value, version.Value, callConnectionId.Value, serverCallId.Value, correlationId.Value, publicEventType.Value);
        }
    }
}
