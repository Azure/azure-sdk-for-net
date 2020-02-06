// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The result of the recognize entities operation on a single document,
    /// containing a collection of the <see cref="CategorizedEntity"/> objects
    /// identified in that document.
    /// </summary>
    public class RecognizeEntitiesResult : TextAnalyticsResult
    {
        internal RecognizeEntitiesResult(string id, TextDocumentStatistics statistics, IList<CategorizedEntity> entities)
            : base(id, statistics)
        {
            Entities = new ReadOnlyCollection<CategorizedEntity>(entities);
        }

        internal RecognizeEntitiesResult(string id, string errorMessage)
            : base(id, errorMessage)
        {
            Entities = Array.Empty<CategorizedEntity>();
        }

        /// <summary>
        /// Gets the collection of named entities identified in the input document.
        /// </summary>
        public IReadOnlyCollection<CategorizedEntity> Entities { get; }
    }
}
