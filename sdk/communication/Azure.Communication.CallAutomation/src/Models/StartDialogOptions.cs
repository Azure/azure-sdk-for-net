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
        /// <param name="botAppId"></param>
        /// <param name="dialogContext"></param>
        public StartDialogOptions(DialogInputType dialogInputType, string botAppId, IDictionary<string, object> dialogContext)
        {
            DialogInputType = dialogInputType;
            BotAppId = botAppId;
            DialogContext = dialogContext;
            DialogId = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// Creates a new instance of the DialogOptions.
        /// </summary>
        /// <param name="dialogInputType"></param>
        /// <param name="botAppId"></param>
        /// <param name="dialogContext"></param>
        /// /// <param name="dialogId"></param>
        public StartDialogOptions(string dialogId, DialogInputType dialogInputType, string botAppId, IDictionary<string, object> dialogContext)
        {
            DialogInputType = dialogInputType;
            BotAppId = botAppId;
            DialogContext = dialogContext;
            DialogId = dialogId;
        }

        /// <summary> Dialog Id</summary>
        public string DialogId { get; }
        /// <summary> Determines the type of the dialog. </summary>
        public DialogInputType DialogInputType { get; }
        /// <summary> The value to identify context of the operation. </summary>
        public string OperationContext { get; set; }
        /// <summary> Bot identifier. </summary>
        public string BotAppId { get; }
        /// <summary> Dialog context. </summary>
        public IDictionary<string, object> DialogContext { get; }
    }
}
