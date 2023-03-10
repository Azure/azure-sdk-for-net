// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.AI.Translation.Text
{
    /// <summary> Input Text Element for Translator Requests. </summary>
    public class InputTextWithTranslation
    {
        /// <summary> Gets or Sets the Text to be translated. </summary>
        public string Text { get; set; }

        /// <summary> Gets or Sets the Translation of the Text. </summary>
        public string Translation { get; set; }
    }
}
