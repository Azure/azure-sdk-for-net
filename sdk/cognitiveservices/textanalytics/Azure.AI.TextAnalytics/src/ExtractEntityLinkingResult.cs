// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public class ExtractEntityLinkingResult : TextAnalysisResult
    {
        internal ExtractEntityLinkingResult(string id, TextDocumentStatistics statistics)
            : base(id, statistics)
        {
        }

        internal ExtractEntityLinkingResult(string id, string errorMessage)
            : base(id, errorMessage)
        {
        }

        /// <summary>
        /// </summary>
        public ReadOnlyCollection<LinkedEntity> LinkedEntities { get; }
    }
}
