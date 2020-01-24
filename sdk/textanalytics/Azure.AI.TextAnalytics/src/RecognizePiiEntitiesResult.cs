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
        private IReadOnlyCollection<NamedEntity> _namedEntities;

        internal RecognizePiiEntitiesResult(string id, TextDocumentStatistics statistics, IList<NamedEntity> entities)
            : base(id, statistics)
        {
            _namedEntities = new ReadOnlyCollection<NamedEntity>(entities);
        }

        internal RecognizePiiEntitiesResult(string id, TextAnalyticsError error)
            : base(id, error)
        {
        }

        /// <summary>
        /// Gets the collection of named entities containing personally
        /// identifiable information in the input document.
        /// </summary>
        public IReadOnlyCollection<NamedEntity> NamedEntities
        {
            get
            {
                if (Error.ErrorCode != default)
                {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                    throw new InvalidOperationException($"Cannot access result for this document, due to error {Error.ErrorCode}: {Error.Message}");
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
                }
                return _namedEntities;
            }
        }
    }
}
