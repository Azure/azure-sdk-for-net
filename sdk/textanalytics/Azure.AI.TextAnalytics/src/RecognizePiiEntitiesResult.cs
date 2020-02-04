// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The result of the recognize PII entities operation on a single
    /// document, containing a collection of the <see cref="PiiEntity"/>
    /// objects containing Personally Identifiable Information that were
    /// found in that document.
    /// </summary>
    public class RecognizePiiEntitiesResult : TextAnalyticsResult
    {
        internal RecognizePiiEntitiesResult(string id, TextDocumentStatistics statistics, IList<PiiEntity> entities)
            : base(id, statistics)
        {
            PiiEntities = new ReadOnlyCollection<PiiEntity>(entities);
        }

        internal RecognizePiiEntitiesResult(string id, string errorMessage)
            : base(id, errorMessage)
        {
            PiiEntities = Array.Empty<PiiEntity>();
        }

        /// <summary>
        /// Gets the collection of PII entities containing Personally
        /// Identifiable Information in the input document.
        /// </summary>
        public IReadOnlyCollection<PiiEntity> PiiEntities { get; }
    }
}
