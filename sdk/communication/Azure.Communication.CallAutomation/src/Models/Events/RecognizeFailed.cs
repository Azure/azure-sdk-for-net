// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System.Text.Json;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The play completed event.
    /// </summary>
    [CodeGenModel("RecognizeFailed", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class RecognizeFailed : CallAutomationEventWithReasonCodeName
    {
        /// <summary> Initializes a new instance of RecognizeFailedInternal. </summary>
        /// <param name="operationContext"></param>
        /// <param name="resultInformation"></param>
        /// <param name="version"> Used to determine the version of the event. </param>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <param name="publicEventType"> The public event namespace used as the &quot;type&quot; property in the CloudEvent. </param>
        internal RecognizeFailed(string operationContext, ResultInformation resultInformation, string version, string callConnectionId, string serverCallId, string correlationId, string publicEventType)
        {
            OperationContext = operationContext;
            ResultInformation = resultInformation;
            Version = version;
            CallConnectionId = callConnectionId;
            ServerCallId = serverCallId;
            CorrelationId = correlationId;
            PublicEventType = publicEventType;
            ReasonCodeName = new ReasonCodeName(resultInformation.SubCode.ToString());
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

            return DeserializeRecognizeFailed(element);
        }
    }
}
