// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.Translation.Text
{
    /// <summary> Properties of the target dictionary language. </summary>
    [Obsolete("This class is obsolete and will be removed in a future release.")]
    public class TargetDictionaryLanguage
    {
        /// <summary> Display name of the language in the locale requested via Accept-Language header. </summary>
        public string Name { get; }
        /// <summary> Display name of the language in the locale native for this language. </summary>
        public string NativeName { get; }
        /// <summary> Directionality, which is rtl for right-to-left languages or ltr for left-to-right languages. </summary>
        public LanguageDirectionality Directionality { get; }
        /// <summary> Language code identifying the target language. </summary>
        public string Code { get; }
    }
}
