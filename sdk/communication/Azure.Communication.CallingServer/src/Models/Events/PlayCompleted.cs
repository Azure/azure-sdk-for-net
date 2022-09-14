// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The play completed event.
    /// </summary>
    public class PlayCompleted : CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of PlayCompleted.</summary>
        /// <param name="internalEvent"> Internal Representation of the PlayCompleted event. </param>
        internal PlayCompleted(PlayCompletedInternal internalEvent)
        {
            OperationContext = internalEvent.OperationContext;
            ResultInformation = internalEvent.ResultInformation;
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
        }

        /// <summary> Operation context. </summary>
        public override string OperationContext { get; internal set; }
        /// <summary> Gets the result info. </summary>
        public override ResultInformation ResultInformation { get; internal set; }

        /// <summary>
        /// Deserialize <see cref="PlayCompleted"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="PlayCompleted"/> object.</returns>
        public static PlayCompleted Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = PlayCompletedInternal.DeserializePlayCompletedInternal(element);
            return new PlayCompleted(internalEvent);
        }
    }
}
