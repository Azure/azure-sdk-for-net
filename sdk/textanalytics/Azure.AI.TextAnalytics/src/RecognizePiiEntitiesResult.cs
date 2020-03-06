// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The result of the recognize PII entities operation on a
    /// document, containing a collection of the <see cref="PiiEntity"/>
    /// objects containing Personally Identifiable Information that were
    /// found in that document.
    /// </summary>
    public class RecognizePiiEntitiesResult : TextAnalyticsResult
    {
        private readonly IReadOnlyCollection<PiiEntity> _entities;

        internal RecognizePiiEntitiesResult(string id, TextDocumentStatistics statistics, IList<PiiEntity> entities)
            : base(id, statistics)
        {
            _entities = new ReadOnlyCollection<PiiEntity>(entities);
        }

        internal RecognizePiiEntitiesResult(string id, TextAnalyticsError error) : base(id, error) { }

        /// <summary>
        /// Gets the collection of PII entities containing Personally
        /// Identifiable Information in the document.
        /// </summary>
        public IReadOnlyCollection<PiiEntity> Entities
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
