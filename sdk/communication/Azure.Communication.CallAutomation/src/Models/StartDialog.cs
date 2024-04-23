// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Dialog Options.
    /// </summary>
    public class StartDialog
    {
        /// <summary>
        /// Creates a new instance of the DialogOptions.
        /// </summary>
        /// <param name="dialog"></param>
        public StartDialog(BaseDialog dialog)
        {
            DialogId = Guid.NewGuid().ToString();
            Dialog = dialog;
        }
        /// <summary>
        /// Creates a new instance of the DialogOptions.
        /// </summary>
        /// <param name="dialogId"></param>
        /// <param name="dialog"></param>
        public StartDialog(string dialogId, BaseDialog dialog)
        {
            DialogId = dialogId;
            Dialog = dialog;
        }

        /// <summary> Dialog Id</summary>
        public string DialogId { get; }
        /// <summary> Determines the type of the dialog. </summary>
        public BaseDialog Dialog { get; }
        /// <summary> The value of the operation callback URI. </summary>
        public string OperationCallbackUri { get; set; }
        /// <summary> The value to identify context of the operation. </summary>
        public string OperationContext { get; set; }
    }
}
