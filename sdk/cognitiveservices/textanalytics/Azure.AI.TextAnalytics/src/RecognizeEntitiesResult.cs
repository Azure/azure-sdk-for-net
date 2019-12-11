// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public class RecognizeEntitiesResult : TextAnalysisResult
    {
        internal RecognizeEntitiesResult(string id, TextDocumentStatistics statistics, IList<NamedEntity> entities)
            : base(id, statistics)
        {
            NamedEntities = new ReadOnlyCollection<NamedEntity>(entities);
        }

        internal RecognizeEntitiesResult(string id, string errorMessage)
            : base(id, errorMessage)
        {
            NamedEntities = Array.Empty<NamedEntity>();
        }

        /// <summary>
        /// </summary>
        public IReadOnlyCollection<NamedEntity> NamedEntities { get; }
    }
}
