// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The dialog sensitivity update event
    /// </summary>
    public class DialogSensitivityUpdate : CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of DialogSensitivityUpdate </summary>
        internal DialogSensitivityUpdate()
        {
        }

        /// <summary> Initializes a new instance of DialogSensitivityUpdate. </summary>
        /// <param name="internalEvent">Internal Representation of the DialogSensitivityUpdate. </param>
        internal DialogSensitivityUpdate(DialogSensitivityUpdateInternal internalEvent)
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
        /// Deserialize <see cref="DialogSensitivityUpdate"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="DialogSensitivityUpdate"/> object.</returns>
        public static DialogSensitivityUpdate Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = DialogSensitivityUpdateInternal.DeserializeDialogSensitivityUpdateInternal(element);
            return new DialogSensitivityUpdate(internalEvent);
        }
    }
}
