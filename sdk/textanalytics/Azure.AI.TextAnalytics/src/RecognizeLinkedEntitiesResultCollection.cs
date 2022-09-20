// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Collection of <see cref="RecognizeLinkedEntitiesResult"/> objects corresponding
    /// to a batch of documents, and information about the batch operation.
    /// </summary>
    [DebuggerTypeProxy(typeof(RecognizeLinkedEntitiesResultCollectionDebugView))]
    public class RecognizeLinkedEntitiesResultCollection : ReadOnlyCollection<RecognizeLinkedEntitiesResult>
    {
        internal RecognizeLinkedEntitiesResultCollection(IList<RecognizeLinkedEntitiesResult> list, TextDocumentBatchStatistics statistics, string modelVersion) : base(list)
        {
            Statistics = statistics;
            ModelVersion = modelVersion;
        }

        /// <summary>
        /// Gets statistics about the documents and how it was processed
        /// by the service.  This property will have a value when IncludeStatistics
        /// is set to true in the client call.
        /// </summary>
        public TextDocumentBatchStatistics Statistics { get; }

        /// <summary>
        /// Gets the version of the Language service model used by this operation
        /// on this batch of documents.
        /// </summary>
        public string ModelVersion { get; }

        /// <summary>
        /// Debugger Proxy class for <see cref="RecognizeLinkedEntitiesResultCollection"/>.
        /// </summary>
        internal class RecognizeLinkedEntitiesResultCollectionDebugView
        {
            private RecognizeLinkedEntitiesResultCollection BaseCollection { get; }

            public RecognizeLinkedEntitiesResultCollectionDebugView(RecognizeLinkedEntitiesResultCollection collection)
            {
                BaseCollection = collection;
            }

            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public List<RecognizeLinkedEntitiesResult> Items
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
