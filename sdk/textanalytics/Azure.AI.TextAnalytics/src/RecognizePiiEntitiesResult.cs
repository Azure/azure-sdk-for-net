// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// </summary>
    public class RecognizePiiEntitiesResult : TextAnalyticsResult
    {
        internal RecognizePiiEntitiesResult(string id, TextDocumentStatistics statistics, IList<NamedEntity> entities)
            : base(id, statistics)
        {
            NamedEntities = new ReadOnlyCollection<NamedEntity>(entities);
        }

        internal RecognizePiiEntitiesResult(string id, string errorMessage)
            : base(id, errorMessage)
        {
            NamedEntities = Array.Empty<NamedEntity>();
        }

        /// <summary>
        /// </summary>
        public IReadOnlyCollection<NamedEntity> NamedEntities { get; }
    }
}
