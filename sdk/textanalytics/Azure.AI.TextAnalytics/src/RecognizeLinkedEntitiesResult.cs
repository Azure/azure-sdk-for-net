// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The result of the recognize linked entities operation on a single
    /// document, containing a collection of the <see cref="LinkedEntity"/>
    /// objects identified in that document.
    /// </summary>
    public class RecognizeLinkedEntitiesResult : TextAnalyticsResult
    {
        internal RecognizeLinkedEntitiesResult(string id, TextDocumentStatistics statistics, IList<LinkedEntity> linkedEntities)
            : base(id, statistics)
        {
            LinkedEntities = new ReadOnlyCollection<LinkedEntity>(linkedEntities);
        }

        internal RecognizeLinkedEntitiesResult(string id, string errorMessage)
            : base(id, errorMessage)
        {
            LinkedEntities = Array.Empty<LinkedEntity>();
        }

        /// <summary>
        /// Gets the collection of linked entities identified in the input document.
        /// </summary>
        public IReadOnlyCollection<LinkedEntity> LinkedEntities { get; }
    }
}
