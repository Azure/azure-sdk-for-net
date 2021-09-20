// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Collection of <see cref="ClassifyCustomCategoryResult"/> objects corresponding
    /// to a batch of documents, and information about the batch operation.
    /// </summary>
    [DebuggerTypeProxy(typeof(ClassifyCustomCategoryResultCollectionDebugView))]
    public class ClassifyCustomCategoryResultCollection : ReadOnlyCollection<ClassifyCustomCategoryResult>
    {
        internal ClassifyCustomCategoryResultCollection(IList<ClassifyCustomCategoryResult> list, TextDocumentBatchStatistics statistics,
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
        /// TODO
        /// </summary>
        public string ProjectName { get; }

        /// <summary>
        /// TODO
        /// </summary>
        public string DeploymentName { get; }

        /// <summary>
        /// Debugger Proxy class for <see cref="ClassifyCustomCategoryResultCollection"/>.
        /// </summary>
        internal class ClassifyCustomCategoryResultCollectionDebugView
        {
            private ClassifyCustomCategoryResultCollection BaseCollection { get; }

            public ClassifyCustomCategoryResultCollectionDebugView(ClassifyCustomCategoryResultCollection collection)
            {
                BaseCollection = collection;
            }

            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public List<ClassifyCustomCategoryResult> Items
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

            public string ModelVersion
            {
                get
                {
                    return BaseCollection.DeploymentName;
                }
            }
        }
    }
}
