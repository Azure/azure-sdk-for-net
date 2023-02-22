// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// A collection of the results of performing extractive summarization on a given set of documents.
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
        /// The statistics associated with the results and how these were produced by the service. The value is
        /// <c>null</c> unless <see cref="TextAnalyticsRequestOptions.IncludeStatistics"/> or
        /// <see cref="AnalyzeActionsOptions.IncludeStatistics"/> was used to explicitly request that these were
        /// included as part of the results.
        /// </summary>
        public TextDocumentBatchStatistics Statistics { get; }

        /// <summary>
        /// The version of the text analytics model that was used to generate the results. To learn more about the
        /// supported model versions for each feature, see
        /// <see href="https://learn.microsoft.com/azure/cognitive-services/language-service/concepts/model-lifecycle"/>.
        /// </summary>
        public string ModelVersion { get; }

        /// <summary>
        /// A debugger proxy for the <see cref="ExtractiveSummarizeResultCollection"/> class.
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
