// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The result of the recognize entities operation on a single document,
    /// containing a collection of the <see cref="NamedEntity"/> objects
    /// identified in that document.
    /// </summary>
    public class RecognizeEntitiesResult : TextAnalyticsResult
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
        /// Gets the collection of named entities identified in the input document.
        /// </summary>
        public IReadOnlyCollection<NamedEntity> NamedEntities { get; }
    }
}
