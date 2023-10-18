// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The dialog completed event
    /// </summary>
    public class DialogCompleted : CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of DialogCompletedEvent </summary>
        internal DialogCompleted()
        {
        }

        /// <summary> Initializes a new instance of DialogCompletedEvent. </summary>
        /// <param name="internalEvent">Internal Representation of the DialogCompletedEvent. </param>
        internal DialogCompleted(DialogCompletedInternal internalEvent)
        {
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            DialogInputType = internalEvent.DialogInputType;
            CorrelationId = internalEvent.CorrelationId;
            OperationContext = internalEvent.OperationContext;
            ResultInformation = internalEvent.ResultInformation;
            DialogId = internalEvent.DialogId;
        }

        /// <summary> Determines the type of the dialog. </summary>
        public DialogInputType? DialogInputType { get; }

        /// <summary> Dialog Id</summary>
        public string DialogId { get; }

        /// <summary>
        /// Deserialize <see cref="DialogCompleted"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="DialogCompleted"/> object.</returns>
        public static DialogCompleted Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = DialogCompletedInternal.DeserializeDialogCompletedInternal(element);
            return new DialogCompleted(internalEvent);
        }
    }
}
