// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Dialog Options.
    /// </summary>
    public class StartDialogOptions
    {
        /// <summary>
        /// Creates a new instance of the DialogOptions.
        /// </summary>
        /// <param name="dialogInputType"></param>
        /// <param name="botId"></param>
        /// <param name="dialogContext"></param>
        public StartDialogOptions(DialogInputType dialogInputType, Guid botId, IDictionary<string, object> dialogContext)
        {
            DialogInputType = dialogInputType;
            BotId = botId;
            DialogContext = dialogContext;
        }

        /// <summary> Determines the type of the dialog. </summary>
        public DialogInputType DialogInputType { get; }
        /// <summary> The value to identify context of the operation. </summary>
        public string OperationContext { get; set; }
        /// <summary> Bot identifier. </summary>
        public Guid BotId { get; }
        /// <summary> Dialog context. </summary>
        public IDictionary<string, object> DialogContext { get; }
    }
}
