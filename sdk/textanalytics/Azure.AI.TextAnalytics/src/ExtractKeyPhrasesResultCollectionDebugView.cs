// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Debugger Proxy class for <see cref="ExtractKeyPhrasesResultCollection"/>.
    /// </summary>
    public class ExtractKeyPhrasesResultCollectionDebugView
    {
        private ExtractKeyPhrasesResultCollection BaseCollection { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtractKeyPhrasesResultCollectionDebugView"/> class.
        /// </summary>
        /// <param name="collection"></param>
        public ExtractKeyPhrasesResultCollectionDebugView(ExtractKeyPhrasesResultCollection collection)
        {
            BaseCollection = collection;
        }

        /// <summary>
        /// Collection of <see cref="ExtractKeyPhrasesResult"/> objects corresponding
        /// to a batch of documents.
        /// </summary>
        public List<ExtractKeyPhrasesResult> Items
        {
            get
            {
                return BaseCollection.ToList();
            }
        }

        /// <summary>
        /// Gets statistics about the documents and how it was processed
        /// by the service.  This property will have a value when IncludeStatistics
        /// is set to true in the client call.
        /// </summary>
        public TextDocumentBatchStatistics Statistics
        {
            get
            {
                return BaseCollection.Statistics;
            }
        }

        /// <summary>
        /// Gets the version of the Text Analytics model used by this operation
        /// on this batch of documents.
        /// </summary>
        public string ModelVersion
        {
            get
            {
                return BaseCollection.ModelVersion;
            }
        }
    }
}
