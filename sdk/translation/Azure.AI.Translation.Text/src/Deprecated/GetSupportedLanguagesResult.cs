// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.AI.Translation.Text
{
    /// <summary> Response for the languages API. </summary>
    public partial class GetSupportedLanguagesResult
    {
        /// <summary> Languages that support dictionary API. </summary>
        [Obsolete("Dictionary is deprecated and will be removed in a future release.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyDictionary<string, SourceDictionaryLanguage> Dictionary { get; }
    }
}
