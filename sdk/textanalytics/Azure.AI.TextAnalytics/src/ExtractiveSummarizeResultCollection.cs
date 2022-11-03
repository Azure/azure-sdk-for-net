// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Collection of <see cref="ExtractiveSummarizeResult"/> objects corresponding
    /// to a batch of documents, and information about the batch operation.
    /// </summary>
    [DebuggerTypeProxy(typeof(ExtractiveSummarizeResultCollectionDebugView))]
    public class ExtractiveSummarizeResultCollection : ReadOnlyCollection<ExtractiveSummarizeResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtractiveSummarizeResultCollection"/> class.
        /// </summary>
        internal ExtractiveSummarizeResultCollection(IList<ExtractiveSummarizeResult> list, TextDocumentBatchStatistics statistics, string modelVersion) : base(list)
        {
            Statistics = statistics;
            ModelVersion = modelVersion;
        }

        /// <summary>
        /// The statistics about the documents batch and how it was processed
        /// by the service. This property will have a value when IncludeStatistics
        /// is set to true in the client call.
        /// </summary>
        public TextDocumentBatchStatistics Statistics { get; }

        /// <summary>
        /// The version of the language service model used by this operation
        /// on this batch of documents.
        /// </summary>
        public string ModelVersion { get; }

        /// <summary>
        /// Debugger proxy class for <see cref="ExtractiveSummarizeResultCollection"/>.
        /// </summary>
        internal class ExtractiveSummarizeResultCollectionDebugView
        {
            private ExtractiveSummarizeResultCollection BaseCollection { get; }

            public ExtractiveSummarizeResultCollectionDebugView(ExtractiveSummarizeResultCollection collection)
            {
                BaseCollection = collection;
            }

            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public List<ExtractiveSummarizeResult> Items
            {
                get
                {
                    return BaseCollection.ToList();
                }
            }

            public TextDocumentBatchStatistics Statistics
            {
                get
                {
                    return BaseCollection.Statistics;
                }
            }

            public string ModelVersion
            {
                get
                {
                    return BaseCollection.ModelVersion;
                }
            }
        }
    }
}
