// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// State of a selection mark. i.e. Selected or Unselected.
    /// </summary>
    public enum SelectionMarkState
    {
        /// <summary>
        /// Value is unselected.
        /// </summary>
        Unselected,

        /// <summary>
        /// Value is selected.
        /// </summary>
        Selected
    }
}
