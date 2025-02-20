// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The dialog hangup event
    /// </summary>
    public class DialogHangup : CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of DialogHangupEvent </summary>
        internal DialogHangup()
        {
        }

        /// <summary> Initializes a new instance of DialogHangupEvent. </summary>
        /// <param name="internalEvent">Internal Representation of the DialogHangupEvent. </param>
        internal DialogHangup(DialogHangupInternal internalEvent)
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

        /// <summary>
        /// Hangup struct
        /// </summary>
        public object IvrContext { get; }

        /// <summary>
        /// Deserialize <see cref="DialogHangup"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="DialogHangup"/> object.</returns>
        public static DialogHangup Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = DialogHangupInternal.DeserializeDialogHangupInternal(element);
            return new DialogHangup(internalEvent);
        }
    }
}
