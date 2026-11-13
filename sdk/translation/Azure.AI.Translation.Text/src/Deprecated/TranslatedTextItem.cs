// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.AI.Translation.Text
{
    /// <summary> Element containing the translated text. </summary>
    // Partial class to hold deprecated members.
    public partial class TranslatedTextItem
    {
        /// <summary>
        /// Input text in the default script of the source language. sourceText property is present only when
        /// the input is expressed in a script that's not the usual script for the language. For example,
        /// if the input were Arabic written in Latin script, then sourceText.text would be the same Arabic text
        /// converted into Arab script.
        /// </summary>
        [Obsolete("SourceText is deprecated and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SourceText SourceText { get; }
    }
}
