// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.CallAutomation
{
    /// <summary> The options of a dialog call. </summary>
    public class DialogOptions
    {
        internal DialogOptions(CommunicationIdentifier targetParticipant, string botAppId, IDictionary<string, object> dialogContext)
        {
            TargetParticipant = targetParticipant;
            BotAppId = botAppId;
            DialogContext = dialogContext;
        }
        internal DialogOptions(DialogOptionsInternal internalObj)
        {
            TargetParticipant = CommunicationIdentifierSerializer.Deserialize(internalObj.TargetParticipant);
            BotAppId = internalObj.BotAppId;
            DialogContext = internalObj.DialogContext;
        }

        /// <summary> Target participant of dialog. </summary>
        public CommunicationIdentifier TargetParticipant { get; }
        /// <summary> Bot identifier. </summary>
        public string BotAppId { get; set; }
        /// <summary> Dialog context. </summary>
        public IDictionary<string, object> DialogContext { get; }
    }
}
