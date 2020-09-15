// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// State of a selection mark.
    /// </summary>
    [CodeGenModel("SelectionMarkState")]
    public enum SelectionMarkState
    {
        /// <summary>
        /// Value is selected.
        /// </summary>
        Selected,

        /// <summary>
        /// Values is unselected.
        /// </summary>
        Unselected
    }
}
