// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Play Failed event.
    /// </summary>
    public partial class PlayFailed : CallAutomationEventBase
    {
        /// <summary>
        /// Reason code.
        /// </summary>
        public MediaEventReasonCode ReasonCode { get; internal set; }

        /// <summary> Contains the index of the failed play source. </summary>
        public int? FailedPlaySourceIndex { get; internal set; }

        /// <summary> Initializes a new instance of PlayFailed. </summary>
        /// <param name="internalEvent"> PlayFailedInternal event. </param>
        internal PlayFailed(PlayFailedInternal internalEvent)
        {
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
            OperationContext = internalEvent.OperationContext;
            ResultInformation = internalEvent.ResultInformation;
            ReasonCode = new MediaEventReasonCode(ResultInformation.SubCode.ToString());
            FailedPlaySourceIndex = internalEvent.FailedPlaySourceIndex;
        }

        /// <summary>
        /// Deserialize <see cref="PlayFailed"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="PlayFailed"/> object.</returns>
        public static PlayFailed Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return new PlayFailed(PlayFailedInternal.DeserializePlayFailedInternal(element));
        }
    }
}
