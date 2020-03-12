// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The result of the extract key phrases operation on a document.
    /// </summary>
    public class ExtractKeyPhrasesResult : TextAnalyticsResult
    {
        private readonly IReadOnlyCollection<string> _keyPhrases;

        internal ExtractKeyPhrasesResult(string id, TextDocumentStatistics statistics, IList<string> keyPhrases)
            : base(id, statistics)
        {
            _keyPhrases = new ReadOnlyCollection<string>(keyPhrases);
        }

        internal ExtractKeyPhrasesResult(string id, TextAnalyticsError error) : base(id, error) { }

        /// <summary>
        /// Gets the collection of key phrases identified in the document.
        /// </summary>
        public IReadOnlyCollection<string> KeyPhrases
        {
            get
            {
                if (HasError)
                {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                    throw new InvalidOperationException($"Cannot access result for document {Id}, due to error {Error.Code}: {Error.Message}");
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
                }
                return _keyPhrases;
            }
        }
    }
}
