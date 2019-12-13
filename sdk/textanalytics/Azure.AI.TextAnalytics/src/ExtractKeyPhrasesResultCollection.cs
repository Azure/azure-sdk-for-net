// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public class ExtractKeyPhrasesResultCollection : ReadOnlyCollection<ExtractKeyPhrasesResult>
    {
        /// <summary>
        /// </summary>
        /// <param name="list"></param>
        /// <param name="statistics"></param>
        /// <param name="modelVersion"></param>
        internal ExtractKeyPhrasesResultCollection(IList<ExtractKeyPhrasesResult> list, TextDocumentBatchStatistics statistics, string modelVersion) : base(list)
        {
            Statistics = statistics;
            ModelVersion = modelVersion;
        }

        /// <summary>
        /// </summary>
        public TextDocumentBatchStatistics Statistics { get; }

        /// <summary>
        /// </summary>
        public string ModelVersion { get; }
    }
}
