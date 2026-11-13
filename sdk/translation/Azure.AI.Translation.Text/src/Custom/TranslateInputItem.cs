// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.Translation.Text
{
    /// <summary> Element containing the text for translation. </summary>
    // Custom convenience constructors for the generated TranslateInputItem class
    public partial class TranslateInputItem
    {
        /// <summary> Initializes a new instance of <see cref="TranslateInputItem"/> with optional parameters. </summary>
        /// <param name="text"> Text to translate. </param>
        /// <param name="targets"> Translation target parameters. </param>
        /// <param name="language">
        /// Specifies the language of the input text. Find which languages are available to translate by
        /// looking up supported languages using the translation scope. If the language parameter isn't
        /// specified, automatic language detection is applied to determine the source language.
        ///
        /// You must use the language parameter rather than autodetection when using the dynamic dictionary feature.
        /// Note: the dynamic dictionary feature is case-sensitive.
        /// </param>
        /// <param name="script"> Specifies the script of the input text. </param>
        /// <param name="textType">
        /// Defines whether the text being translated is plain text or HTML text. Any HTML needs to be a well-formed,
        /// complete element. Possible values are: plain (default) or html.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="text"/> or <paramref name="targets"/> is null. </exception>
        public TranslateInputItem(string text, IEnumerable<TranslationTarget> targets, string language = null, string script = null, TextType? textType = null)
            : this(text, targets)
        {
            Language = language;
            Script = script;
            TextType = textType;
        }

        /// <summary> Initializes a new instance of <see cref="TranslateInputItem"/> with a single translation target. </summary>
        /// <param name="text"> Text to translate. </param>
        /// <param name="target"> Translation target parameter. </param>
        /// <param name="language">
        /// Specifies the language of the input text. Find which languages are available to translate by
        /// looking up supported languages using the translation scope. If the language parameter isn't
        /// specified, automatic language detection is applied to determine the source language.
        ///
        /// You must use the language parameter rather than autodetection when using the dynamic dictionary feature.
        /// Note: the dynamic dictionary feature is case-sensitive.
        /// </param>
        /// <param name="script"> Specifies the script of the input text. </param>
        /// <param name="textType">
        /// Defines whether the text being translated is plain text or HTML text. Any HTML needs to be a well-formed,
        /// complete element. Possible values are: plain (default) or html.
        /// </param>
        /// <exception cref="ArgumentNullException"> <paramref name="text"/> or <paramref name="target"/> is null. </exception>
        public TranslateInputItem(string text, TranslationTarget target, string language = null, string script = null, TextType? textType = null)
            : this(text, new[] { target })
        {
            Language = language;
            Script = script;
            TextType = textType;
        }
    }
}
