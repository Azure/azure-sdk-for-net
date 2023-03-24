// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Communication.CallAutomation.Models.Events;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The dialog consent event
    /// </summary>
    public class DialogConsent : CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of DialogConsentEvent </summary>
        internal DialogConsent()
        {
        }

        /// <summary> Initializes a new instance of DialogConsentEvent. </summary>
        /// <param name="internalEvent">Internal Representation of the DialogConsentEvent. </param>
        internal DialogConsent(DialogConsentInternal internalEvent)
        {
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            DialogInputType = internalEvent.DialogInputType;
            CorrelationId = internalEvent.CorrelationId;
            OperationContext = internalEvent.OperationContext;
            ResultInformation = internalEvent.ResultInformation;
        }

        /// <summary> Determines the type of the dialog. </summary>
        public DialogInputType? DialogInputType { get; }

        /// <summary>
        /// Deserialize <see cref="DialogConsent"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="DialogConsent"/> object.</returns>
        public static DialogConsent Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = DialogConsentInternal.DeserializeDialogConsentInternal(element);
            return new DialogConsent(internalEvent);
        }
    }
}
