// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The dialog updated event
    /// </summary>
    public class DialogUpdated : CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of DialogUpdatedEvent </summary>
        internal DialogUpdated()
        {
        }

        /// <summary> Initializes a new instance of DialogUpdatedEvent. </summary>
        /// <param name="internalEvent">Internal Representation of the DialogUpdatedEvent. </param>
        internal DialogUpdated(DialogUpdatedInternal internalEvent)
        {
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            DialogInputType = internalEvent.DialogInputType;
            CorrelationId = internalEvent.CorrelationId;
            OperationContext = internalEvent.OperationContext;
            ResultInformation = internalEvent.ResultInformation;
            IvrContext = internalEvent.IvrContext;
            DialogId = internalEvent.DialogId;
        }

        /// <summary> Determines the type of the dialog. </summary>
        public DialogInputType? DialogInputType { get; }
        /// <summary> Dialog Id</summary>
        public string DialogId { get; }
        /// <summary> Updated Type </summary>
        public string UpdatedType { get; }
        /// <summary> Updated Destination </summary>
        public string UpdatedDestination { get; }
        /// <summary> IVR Context </summary>
        public object IvrContext { get; }

        /// <summary>
        /// Deserialize <see cref="DialogUpdated"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="DialogUpdated"/> object.</returns>
        public static DialogUpdated Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = DialogUpdatedInternal.DeserializeDialogUpdatedInternal(element);
            return new DialogUpdated(internalEvent);
        }
    }
}
