// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public class RecognizeEntitiesResult : TextAnalysisResult
    {
        internal RecognizeEntitiesResult(string id, TextDocumentStatistics statistics)
            : base(id, statistics)
        {
        }

        internal RecognizeEntitiesResult(string id, string errorMessage)
            : base(id, errorMessage)
        {
        }

        /// <summary>
        /// </summary>
        public ReadOnlyCollection<NamedEntity> NamedEntities { get; }
    }
}
