// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Play Cancelled event.
    /// </summary>
    [CodeGenModel("PlayCancelled", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class PlayCancelled : CallAutomationEventWithReasonCodeName
    {
        /// <summary> Initializes a new instance of RecognizeCancelled. </summary>
        /// <param name="eventSource"></param>
        /// <param name="operationContext"></param>
        /// <param name="resultInformation"></param>
        /// <param name="version"> Used to determine the version of the event. </param>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <param name="publicEventType"> The public event namespace used as the &quot;type&quot; property in the CloudEvent. </param>
        internal PlayCancelled(string eventSource, string operationContext, ResultInformation resultInformation, string version, string callConnectionId, string serverCallId, string correlationId, string publicEventType)
        {
            EventSource = eventSource;
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
        /// Deserialize <see cref="PlayCancelled"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="PlayCancelled"/> object.</returns>
        public static PlayCancelled Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializePlayCancelled(element);
        }
    }
}
