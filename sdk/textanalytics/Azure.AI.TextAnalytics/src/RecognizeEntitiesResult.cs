// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The result of the recognize entities operation on a document,
    /// containing a collection of the <see cref="CategorizedEntity"/> objects
    /// identified in that document.
    /// </summary>
    public class RecognizeEntitiesResult : TextAnalyticsResult
    {
        private readonly IReadOnlyCollection<CategorizedEntity> _entities;

        internal RecognizeEntitiesResult(string id, TextDocumentStatistics statistics, IList<CategorizedEntity> entities)
            : base(id, statistics)
        {
            _entities = new ReadOnlyCollection<CategorizedEntity>(entities);
        }

        internal RecognizeEntitiesResult(string id, TextAnalyticsError error) : base(id, error) { }

        /// <summary>
        /// Gets the collection of named entities identified in the document.
        /// </summary>
        public IReadOnlyCollection<CategorizedEntity> Entities
        {
            get
            {
                if (HasError)
                {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                    throw new InvalidOperationException($"Cannot access result for document {Id}, due to error {Error.Code}: {Error.Message}");
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
                }
                return _entities;
            }
        }
    }
}
