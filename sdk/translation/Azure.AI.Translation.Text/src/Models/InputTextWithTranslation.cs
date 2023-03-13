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
        /// <summary>
        /// Initializes a new instance of the <see cref="InputTextWithTranslation"/> class.
        /// </summary>
        /// <param name="word">Word to lookup in the dictionary.</param>
        /// <param name="translation">Translation of the word.</param>
        public InputTextWithTranslation(string word, string translation)
        {
            this.Word = word;
            this.Translation = translation;
        }

        /// <summary> Gets or Sets the Text to be translated. </summary>
        public string Word { get; }

        /// <summary> Gets or Sets the Translation of the Text. </summary>
        public string Translation { get; }
    }
}
