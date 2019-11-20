// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public class NamedEntityResult : TextAnalysisResult
    {
        internal NamedEntityResult(string id, TextDocumentStatistics statistics)
            : base(id, statistics)
        {
        }

        internal NamedEntityResult(string id, string errorMessage)
            : base(id, errorMessage)
        {
        }

        /// <summary>
        /// </summary>
        public ReadOnlyCollection<NamedEntity> NamedEntities { get; }
    }
}
