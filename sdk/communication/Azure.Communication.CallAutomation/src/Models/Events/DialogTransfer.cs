// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The dialog transfer event
    /// </summary>
    public class DialogTransfer : CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of DialogTransferEvent </summary>
        internal DialogTransfer()
        {
        }

        /// <summary> Initializes a new instance of DialogTransferEvent. </summary>
        /// <param name="internalEvent">Internal Representation of the DialogTransferEvent. </param>
        internal DialogTransfer(DialogTransferInternal internalEvent)
        {
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            DialogInputType = internalEvent.DialogInputType;
            CorrelationId = internalEvent.CorrelationId;
            OperationContext = internalEvent.OperationContext;
            ResultInformation = internalEvent.ResultInformation;
            TransferType = internalEvent.TransferType;
            TransferDestination = internalEvent.TransferDestination;
            IvrContext = internalEvent.IvrContext;
            DialogId = internalEvent.DialogId;
        }

        /// <summary> Determines the type of the dialog. </summary>
        public DialogInputType? DialogInputType { get; }
        /// <summary> Dialog Id</summary>
        public string DialogId { get; }
        /// <summary> Transfer Type </summary>
        public string TransferType { get; }
        /// <summary> Transfer Destination </summary>
        public string TransferDestination { get; }
        /// <summary> IVR Context </summary>
        public object IvrContext { get; }

        /// <summary>
        /// Deserialize <see cref="DialogTransfer"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="DialogTransfer"/> object.</returns>
        public static DialogTransfer Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = DialogTransferInternal.DeserializeDialogTransferInternal(element);
            return new DialogTransfer(internalEvent);
        }
    }
}
