// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Communication.CallAutomation.Models.Events;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The dialog failed event
    /// </summary>
    public class DialogFailed : CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of DialogFailedEvent </summary>
        internal DialogFailed()
        {
        }

        /// <summary> Initializes a new instance of DialogFailedEvent. </summary>
        /// <param name="internalEvent">Internal Representation of the DialogFailedEvent. </param>
        internal DialogFailed(DialogFailedInternal internalEvent)
        {
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
            OperationContext = internalEvent.OperationContext;
            ResultInformation = internalEvent.ResultInformation;
        }

        /// <summary>
        /// Deserialize <see cref="DialogFailed"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="DialogFailed"/> object.</returns>
        public static DialogFailed Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = DialogFailedInternal.DeserializeDialogFailedInternal(element);
            return new DialogFailed(internalEvent);
        }
    }
}
