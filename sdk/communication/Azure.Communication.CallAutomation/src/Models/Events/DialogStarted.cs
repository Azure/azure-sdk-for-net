﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Communication.CallAutomation.Models.Events;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The dialog started event
    /// </summary>
    public class DialogStarted : CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of DialogStartedEvent </summary>
        internal DialogStarted()
        {
        }

        /// <summary> Initializes a new instance of DialogStartedEvent. </summary>
        /// <param name="internalEvent">Internal Representation of the DialogStartedEvent. </param>
        internal DialogStarted(DialogStartedInternal internalEvent)
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
        /// Deserialize <see cref="DialogStarted"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="DialogStarted"/> object.</returns>
        public static DialogStarted Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = DialogStartedInternal.DeserializeDialogStartedInternal(element);
            return new DialogStarted(internalEvent);
        }
    }
}
