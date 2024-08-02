// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The create call failed event.
    /// </summary>
    public partial class CreateCallFailed : CallAutomationEventBase
    {
        /// <summary> Initializes a new instance of CreateCallFailed. </summary>
        internal CreateCallFailed()
        {
        }

        internal CreateCallFailed(CreateCallFailedInternal internalEvent)
        {
            OperationContext = internalEvent.OperationContext;
            ResultInformation = internalEvent.ResultInformation;
            CallConnectionId = internalEvent.CallConnectionId;
            ServerCallId = internalEvent.ServerCallId;
            CorrelationId = internalEvent.CorrelationId;
        }

        /// <summary>
        /// Deserialize <see cref="CreateCallFailed"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="CreateCallFailed"/> object.</returns>
        public static CreateCallFailed Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;
            var internalEvent = CreateCallFailedInternal.DeserializeCreateCallFailedInternal(element);
            return new CreateCallFailed(internalEvent);
        }
    }
}
