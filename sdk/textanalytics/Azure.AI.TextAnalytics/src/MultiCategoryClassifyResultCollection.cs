// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Collection of <see cref="MultiCategoryClassifyResult"/> objects corresponding
    /// to a batch of documents, and information about the batch operation.
    /// </summary>
    [DebuggerTypeProxy(typeof(MultiCategoryClassifyResultCollectionDebugView))]
    public class MultiCategoryClassifyResultCollection : ReadOnlyCollection<MultiCategoryClassifyResult>
    {
        internal MultiCategoryClassifyResultCollection(IList<MultiCategoryClassifyResult> list, TextDocumentBatchStatistics statistics,
            string projectName, string deploymentName) : base(list)
        {
            Statistics = statistics;
            ProjectName = projectName;
            DeploymentName = deploymentName;
        }

        /// <summary>
        /// Gets statistics about the documents and how it was processed
        /// by the service.  This property will have a value when IncludeStatistics
        /// is set to true in the client call.
        /// </summary>
        public TextDocumentBatchStatistics Statistics { get; }

        /// <summary>
        /// Gets the value of the property corresponding to the name of the
        /// target project that produced these results. This should be the same
        /// as the project name set when creating the <see cref="MultiCategoryClassifyAction"/>
        /// object used to start the operation.
        /// </summary>
        public string ProjectName { get; }

        /// <summary>
        /// Gets the value of the property corresponding to the deployment name
        /// of the project that produced these results. This should be the same
        /// as the deployment name set when creating the <see cref="MultiCategoryClassifyAction"/>
        /// object used to start the operation.
        /// </summary>
        public string DeploymentName { get; }

        /// <summary>
        /// Debugger Proxy class for <see cref="MultiCategoryClassifyResultCollection"/>.
        /// </summary>
        internal class MultiCategoryClassifyResultCollectionDebugView
        {
            private MultiCategoryClassifyResultCollection BaseCollection { get; }

            public MultiCategoryClassifyResultCollectionDebugView(MultiCategoryClassifyResultCollection collection)
            {
                BaseCollection = collection;
            }

            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public List<MultiCategoryClassifyResult> Items
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

            public string ProjectName
            {
                get
                {
                    return BaseCollection.ProjectName;
                }
            }

            public string DeploymentName
            {
                get
                {
                    return BaseCollection.DeploymentName;
                }
            }
        }
    }
}
