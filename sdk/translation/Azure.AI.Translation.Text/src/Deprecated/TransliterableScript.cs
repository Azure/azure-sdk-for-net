// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Azure.AI.Translation.Text
{
    /// <summary> Script definition with list of script into which given script can be translitered. </summary>
    public partial class TransliterableScript : LanguageScript
    {
        /// <summary> List of scripts available to convert text to. </summary>
        [Obsolete("TransliterableScript is deprecated and will be removed in a future release. Please use ToScripts instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<LanguageScript> TargetLanguageScripts { get; }
    }
}
