// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Collection of <see cref="ExtractSummaryResult"/> objects corresponding
    /// to a batch of documents, and information about the batch operation.
    /// </summary>
    [DebuggerTypeProxy(typeof(ExtractSummaryResultCollectionDebugView))]
    public class ExtractSummaryResultCollection : ReadOnlyCollection<ExtractSummaryResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtractSummaryResultCollection"/> class.
        /// </summary>
        internal ExtractSummaryResultCollection(IList<ExtractSummaryResult> list, TextDocumentBatchStatistics statistics, string modelVersion) : base(list)
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
        /// Debugger proxy class for <see cref="ExtractSummaryResultCollection"/>.
        /// </summary>
        internal class ExtractSummaryResultCollectionDebugView
        {
            private ExtractSummaryResultCollection BaseCollection { get; }

            public ExtractSummaryResultCollectionDebugView(ExtractSummaryResultCollection collection)
            {
                BaseCollection = collection;
            }

            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public List<ExtractSummaryResult> Items
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
