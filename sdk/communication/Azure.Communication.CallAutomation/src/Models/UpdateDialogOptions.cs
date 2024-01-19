// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Update Dialog Options bag
    /// </summary>
    public class UpdateDialogOptions
    {
        /// <summary>
        /// Creates a new instance of the UpdateDialogOptions.
        /// </summary>
        /// <param name="dialogId"></param>
        /// <param name="dialog"></param>
        public UpdateDialogOptions(string dialogId, DialogUpdateBase dialog)
        {
            DialogId = dialogId;
            Dialog = dialog;
        }
        /// <summary> Dialog Id</summary>
        public string DialogId { get; }
        /// <summary> Determines the type of the dialog. </summary>
        public DialogUpdateBase Dialog { get; }
        /// <summary> The value to identify context of the operation. </summary>
        public string OperationContext { get; set; }
    }
}
