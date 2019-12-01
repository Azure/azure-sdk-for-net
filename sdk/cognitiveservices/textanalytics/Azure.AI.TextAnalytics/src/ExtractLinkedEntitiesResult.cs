// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public class ExtractLinkedEntitiesResult : TextAnalysisResult
    {
        internal ExtractLinkedEntitiesResult(string id, TextDocumentStatistics statistics, IList<LinkedEntity> linkedEntities)
            : base(id, statistics)
        {
            LinkedEntities = new ReadOnlyCollection<LinkedEntity>(linkedEntities);
        }

        internal ExtractLinkedEntitiesResult(string id, string errorMessage)
            : base(id, errorMessage)
        {
        }

        /// <summary>
        /// </summary>
        public ReadOnlyCollection<LinkedEntity> LinkedEntities { get; }
    }
}
