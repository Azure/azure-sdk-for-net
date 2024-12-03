// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The MediaStreamingFailed event.
    /// </summary>

    public partial class MediaStreamingFailed : CallAutomationEventBase
    {
        /// <summary>
        /// Reason code.
        /// </summary>
        public MediaEventReasonCode ReasonCode { get; internal set; }

        /// <summary>
        /// Defines the result for MediaStreamingUpdate with the current status and the details about the status.
        /// </summary>
        public MediaStreamingUpdate MediaStreamingUpdate { get; internal set; }

        /// <summary> Initializes a new instance of MediaStreamingFailed. </summary>
        /// <param name="internalEvent"> MediaStreamingFailedInternal event. </param>
        internal MediaStreamingFailed(MediaStreamingFailedInternal internalEvent)
        {
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
            OperationContext = internalEvent.OperationContext;
            ResultInformation = internalEvent.ResultInformation;
            MediaStreamingUpdate = internalEvent.MediaStreamingUpdate;
            ReasonCode = new MediaEventReasonCode(ResultInformation.SubCode.ToString());
        }

        /// <summary>
        /// Deserialize <see cref="MediaStreamingFailed"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="MediaStreamingFailed"/> object.</returns>
        public static MediaStreamingFailed Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return new MediaStreamingFailed(MediaStreamingFailedInternal.DeserializeMediaStreamingFailedInternal(element));
        }
    }
}
