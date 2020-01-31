// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The result of the recognize PII entities operation on a single
    /// document, containing a collection of the <see cref="CategorizedEntity"/>
    /// objects containing Personally Identifiable Information that were
    /// found in that document.
    /// </summary>
    public class RecognizePiiEntitiesResult : TextAnalyticsResult
    {
        internal RecognizePiiEntitiesResult(string id, TextDocumentStatistics statistics, IList<CategorizedEntity> entities)
            : base(id, statistics)
        {
            CategorizedEntities = new ReadOnlyCollection<CategorizedEntity>(entities);
        }

        internal RecognizePiiEntitiesResult(string id, TextAnalyticsError error)
            : base(id, error)
        {
            CategorizedEntities = Array.Empty<CategorizedEntity>();
        }

        /// <summary>
        /// Gets the collection of named entities containing Personally
        /// Identifiable Information in the input document.
        /// </summary>
        public IReadOnlyCollection<CategorizedEntity> CategorizedEntities { get; }
    }
}
