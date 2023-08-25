// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The result of the extract key phrases operation on a document.
    /// </summary>
    public class ExtractKeyPhrasesResult : TextAnalyticsResult
    {
        private readonly KeyPhraseCollection _keyPhrases;

        internal ExtractKeyPhrasesResult(
            string id,
            TextDocumentStatistics statistics,
            KeyPhraseCollection keyPhrases)
            : base(id, statistics)
        {
            _keyPhrases = keyPhrases;
        }

        internal ExtractKeyPhrasesResult(string id, TextAnalyticsError error) : base(id, error) { }

        /// <summary>
        /// Gets the collection of key phrases identified in the document.
        /// </summary>
        public KeyPhraseCollection KeyPhrases
        {
            get
            {
                if (HasError)
                {
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
                    throw new InvalidOperationException($"Cannot access result for document {Id}, due to error {Error.ErrorCode}: {Error.Message}");
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations
                }
                return _keyPhrases;
            }
        }
    }
}
