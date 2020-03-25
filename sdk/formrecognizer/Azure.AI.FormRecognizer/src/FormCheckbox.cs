// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class FormCheckBox
    {
        internal FormCheckBox()
        {
        }

        /// <summary>
        /// </summary>
        public int PageNumber { get; }

        /// <summary>
        /// </summary>
        public BoundingBox BoundingBox { get; }

        /// <summary>
        /// </summary>
        public float? Confidence { get; }

        /// <summary>
        /// </summary>
        public FormCheckBoxState CheckedState { get; }

        /// <summary>
        /// </summary>
        public bool IsChecked { get { return CheckedState == FormCheckBoxState.Checked; } }

        /// <summary>
        /// </summary>
        public bool IsUnchecked { get { return CheckedState == FormCheckBoxState.Unchecked; } }
    }
}
