// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

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
        private readonly PiiEntityCollection _entities;

        internal RecognizePiiEntitiesResult(
            string id,
            TextDocumentStatistics statistics,
            PiiEntityCollection entities)
            : base(id, statistics)
        {
            _entities = entities;
        }

        internal RecognizePiiEntitiesResult(string id, TextAnalyticsError error) : base(id, error) { }

        /// <summary>
        /// Gets the collection of PII entities containing Personally
        /// Identifiable Information in the document.
        /// </summary>
        public PiiEntityCollection Entities
        {
            get
            {
                if (HasError)
                {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                    throw new InvalidOperationException($"Cannot access result for document {Id}, due to error {Error.ErrorCode}: {Error.Message}");
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
                }
                return _entities;
            }
        }
    }
}
