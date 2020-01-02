// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The result of the recognize PII entities operation on a single
    /// document, containing a collection of the <see cref="NamedEntity"/>
    /// objects containing personally identifiable information that were
    /// found in that document.
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
        /// Gets the collection of named entities containing personally
        /// identifiable information in the input document.
        /// </summary>
        public IReadOnlyCollection<NamedEntity> NamedEntities { get; }
    }
}
