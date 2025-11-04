// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.Translation.Text
{
    /// <summary> Properties ot the source dictionary language. </summary>
    [Obsolete("This class is obsolete and will be removed in a future release.")]
    public class SourceDictionaryLanguage
    {
        /// <summary> Initializes a new instance of SourceDictionaryLanguage. </summary>
        internal SourceDictionaryLanguage() { }

        /// <summary> Display name of the language in the locale requested via Accept-Language header. </summary>
        public string Name { get; }
        /// <summary> Display name of the language in the locale native for this language. </summary>
        public string NativeName { get; }
        /// <summary> Directionality, which is rtl for right-to-left languages or ltr for left-to-right languages. </summary>
        public LanguageDirectionality Directionality { get; }
        /// <summary> List of languages with alterative translations and examples for the query expressed in the source language. </summary>
        public IReadOnlyList<TargetDictionaryLanguage> Translations { get; }
    }
}
