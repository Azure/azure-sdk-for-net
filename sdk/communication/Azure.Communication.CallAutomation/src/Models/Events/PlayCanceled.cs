// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Play Cancelled event.
    /// </summary>
    [CodeGenModel("PlayCanceled", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class PlayCanceled : CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of RecognizeCancelled. </summary>
        /// <param name="eventSource"></param>
        /// <param name="operationContext"></param>
        /// <param name="version"> Used to determine the version of the event. </param>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <param name="publicEventType"> The public event namespace used as the &quot;type&quot; property in the CloudEvent. </param>
        internal PlayCanceled(string eventSource, string operationContext, string version, string callConnectionId, string serverCallId, string correlationId, string publicEventType)
        {
            EventSource = eventSource;
            OperationContext = operationContext;
            Version = version;
            CallConnectionId = callConnectionId;
            ServerCallId = serverCallId;
            CorrelationId = correlationId;
            PublicEventType = publicEventType;
        }

        /// <summary>
        /// Deserialize <see cref="PlayCanceled"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="PlayCanceled"/> object.</returns>
        public static PlayCanceled Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializePlayCancelled(element);
        }
    }
}
