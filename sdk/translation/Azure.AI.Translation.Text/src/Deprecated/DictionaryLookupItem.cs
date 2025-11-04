// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.Translation.Text
{
    /// <summary> Dictionary Lookup Element. </summary>
    [Obsolete("This class is obsolete and will be removed in a future release.")]
    public class DictionaryLookupItem
    {
        /// <summary>
        /// A string giving the normalized form of the source term.
        /// For example, if the request is "JOHN", the normalized form will be "john".
        /// The content of this field becomes the input to lookup examples.
        /// </summary>
        public string NormalizedSource { get; }
        /// <summary>
        /// A string giving the source term in a form best suited for end-user display.
        /// For example, if the input is "JOHN", the display form will reflect the usual
        /// spelling of the name: "John".
        /// </summary>
        public string DisplaySource { get; }
        /// <summary> A list of translations for the source term. </summary>
        public IReadOnlyList<DictionaryTranslation> Translations { get; }
    }
}
