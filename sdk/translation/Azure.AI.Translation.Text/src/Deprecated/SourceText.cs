// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.AI.Translation.Text
{
    /// <summary> Input text in the default script of the source language. </summary>
    [Obsolete("This class is obsolete and will be removed in a future release.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SourceText
    {
        /// <summary> Initializes a new instance of SourceText. </summary>
        internal SourceText() { }

        /// <summary> Input text in the default script of the source language. </summary>
        public string Text { get; }
    }
}
