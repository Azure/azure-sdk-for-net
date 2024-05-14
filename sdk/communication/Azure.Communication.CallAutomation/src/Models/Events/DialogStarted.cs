// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

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

        /// <summary>
        /// Initializes a new instance of DialogStartedEvent
        /// </summary>
        /// <param name="callConnectionId"> Call connection ID. </param>
        /// <param name="serverCallId"> Server call ID. </param>
        /// <param name="correlationId"> Correlation ID for event to call correlation. Also called ChainId for skype chain ID. </param>
        /// <param name="operationContext"> Used by customers when calling mid-call actions to correlate the request to the response event. </param>
        /// <param name="resultInformation"> Contains the resulting SIP code/sub-code and message from NGC services. </param>
        /// <param name="dialogId"> Dialog Id. </param>
        /// <param name="dialogInputType"> Type of Dialog. </param>
        internal DialogStarted(string callConnectionId, string serverCallId, string correlationId, string operationContext, ResultInformation resultInformation, string dialogId, DialogInputType dialogInputType)
        {
            CallConnectionId = callConnectionId;
            ServerCallId = serverCallId;
            CorrelationId = correlationId;
            OperationContext = operationContext;
            ResultInformation = resultInformation;
            DialogId = dialogId;
            DialogInputType = dialogInputType;
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
