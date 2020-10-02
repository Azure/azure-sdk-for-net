// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// State of a selection mark.
    /// </summary>
    [CodeGenModel("SelectionMarkState")]
    public enum FormSelectionMarkState
    {
        /// <summary>
        /// Value is selected.
        /// </summary>
        Selected,

        /// <summary>
        /// Value is unselected.
        /// </summary>
        Unselected
    }
}
