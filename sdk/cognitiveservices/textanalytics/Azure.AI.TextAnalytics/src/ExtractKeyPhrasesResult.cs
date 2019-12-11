// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public class ExtractKeyPhrasesResult : TextAnalysisResult
    {
        internal ExtractKeyPhrasesResult(string id, TextDocumentStatistics statistics, IList<string> keyPhrases)
            : base(id, statistics)
        {
            KeyPhrases = new ReadOnlyCollection<string>(keyPhrases);
        }

        internal ExtractKeyPhrasesResult(string id, string errorMessage)
            : base(id, errorMessage)
        {
            KeyPhrases = EmptyArray<string>.Instance;
        }

        /// <summary>
        /// </summary>
        public IReadOnlyCollection<string> KeyPhrases { get; }
    }
}
