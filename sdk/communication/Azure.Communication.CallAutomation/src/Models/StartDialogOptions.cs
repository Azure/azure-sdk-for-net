// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Dialog Options.
    /// </summary>
    public abstract class StartDialogOptions
    {
        /// <summary>
        /// Creates a new instance of the DialogOptions.
        /// </summary>
        /// <param name="dialogInputType"></param>
        /// <param name="targetParticipant"></param>
        /// <param name="botId"></param>
        /// <param name="dialogContext"></param>
        protected StartDialogOptions(DialogInputType dialogInputType, CommunicationIdentifier targetParticipant, Guid botId, IDictionary<string, string> dialogContext)
        {
            DialogInputType = dialogInputType;
            TargetParticipant = targetParticipant;
            BotId = botId;
            DialogContext = dialogContext;
        }

        /// <summary> Determines the type of the dialog. </summary>
        public DialogInputType DialogInputType { get; }
        /// <summary> The value to identify context of the operation. </summary>
        public string OperationContext { get; set; }
        /// <summary> Target participant of dialog. </summary>
        public CommunicationIdentifier TargetParticipant { get; }
        /// <summary> Bot identifier. </summary>
        public Guid BotId { get; }
        /// <summary> Dialog context. </summary>
        public IDictionary<string, string> DialogContext { get; }
    }
}
