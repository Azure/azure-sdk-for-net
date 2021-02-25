﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Collection of <see cref="AnalyzeHealthcareEntitiesResult"/> objects corresponding
    /// to a batch of documents, and information about the batch operation.
    /// </summary>
    [DebuggerTypeProxy(typeof(AnalyzeHealthcareEntitiesResultCollectionDebugView))]
    public class AnalyzeHealthcareEntitiesResultCollection : ReadOnlyCollection<AnalyzeHealthcareEntitiesResult>
    {
        /// <summary>
        /// </summary>
        /// <param name="list"></param>
        /// <param name="statistics"></param>
        /// <param name="modelVersion"></param>
        internal AnalyzeHealthcareEntitiesResultCollection(IList<AnalyzeHealthcareEntitiesResult> list, TextDocumentBatchStatistics statistics, string modelVersion) : base(list)
        {
            Statistics = statistics;
            ModelVersion = modelVersion;
        }

        /// <summary>
        /// Gets statistics about the documents batch and how it was processed
        /// by the service.  This property will have a value when IncludeStatistics
        /// is set to true in the client call.
        /// </summary>
        public TextDocumentBatchStatistics Statistics { get; }

        /// <summary>
        /// Gets the version of the Text Analytics model used by this operation
        /// on this batch of documents.
        /// </summary>
        public string ModelVersion { get; }

        /// <summary>
        /// Debugger Proxy class for <see cref="AnalyzeHealthcareEntitiesResultCollection"/>.
        /// </summary>
        internal class AnalyzeHealthcareEntitiesResultCollectionDebugView
        {
            private AnalyzeHealthcareEntitiesResultCollection BaseCollection { get; }

            public AnalyzeHealthcareEntitiesResultCollectionDebugView(AnalyzeHealthcareEntitiesResultCollection collection)
            {
                BaseCollection = collection;
            }

            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public List<AnalyzeHealthcareEntitiesResult> Items
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
