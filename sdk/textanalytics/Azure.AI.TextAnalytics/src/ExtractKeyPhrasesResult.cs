// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The result of the extract key phrases operation on a single document,
    /// containing a collection of the key phrases identified in that document.
    /// </summary>
    public class ExtractKeyPhrasesResult : TextAnalyticsResult
    {
        internal ExtractKeyPhrasesResult(string id, TextDocumentStatistics statistics, IList<string> keyPhrases)
            : base(id, statistics)
        {
            KeyPhrases = new ReadOnlyCollection<string>(keyPhrases);
        }

        internal ExtractKeyPhrasesResult(string id, string errorMessage)
            : base(id, errorMessage)
        {
            KeyPhrases = Array.Empty<string>();
        }

        /// <summary>
        /// Gets the collection of key phrases identified in the input document.
        /// </summary>
        public IReadOnlyCollection<string> KeyPhrases { get; }
    }
}
