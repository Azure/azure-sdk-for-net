// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.AI.Translation.Text
{
    /// <summary> An object describing the detected language. </summary>
    // Partial class to hold deprecated members.
    public partial class DetectedLanguage
    {
        /// <summary>
        /// A float value indicating the confidence in the result.
        /// The score is between zero and one and a low score indicates a low confidence.
        /// </summary>
        [Obsolete("Confidence is deprecated. Use Score instead.")]
        public float Confidence { get; }
    }
}
