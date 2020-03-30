// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class FormCheckBox : FormContent
    {
        internal FormCheckBox()
            : base("", new BoundingBox(), 0 /* TODO */)
        {
        }

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
