// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary> The DialogStateResponse. </summary>
    public class DialogStateResponse
    {
        /// <summary> Initializes a new instance of DialogStateResponse. </summary>
        /// <param name="dialogId"> The dialog ID. </param>
        /// <param name="dialogOptions"> Defines options for dialog. </param>
        /// <param name="dialogInputType"> Determines the type of the dialog. </param>
        /// <param name="operationContext"> The value to identify context of the operation. </param>
        internal DialogStateResponse(string dialogId, DialogOptions dialogOptions, DialogInputType? dialogInputType, string operationContext)
        {
            DialogId = dialogId;
            DialogOptions = dialogOptions;
            DialogInputType = dialogInputType;
            OperationContext = operationContext;
        }

        internal DialogStateResponse(DialogStateResponseInternal dialogStateResponseInternal)
        {
            DialogId = dialogStateResponseInternal.DialogId;
            DialogInputType = dialogStateResponseInternal.DialogInputType;
            OperationContext = dialogStateResponseInternal.OperationContext;
            DialogOptions = new DialogOptions(dialogStateResponseInternal.DialogOptions);
        }
        /// <summary> The dialog ID. </summary>
        public string DialogId { get; }
        /// <summary> Defines options for dialog. </summary>
        public DialogOptions DialogOptions { get; }
        /// <summary> Determines the type of the dialog. </summary>
        public DialogInputType? DialogInputType { get; }
        /// <summary> The value to identify context of the operation. </summary>
        public string OperationContext { get; }
    }
}
