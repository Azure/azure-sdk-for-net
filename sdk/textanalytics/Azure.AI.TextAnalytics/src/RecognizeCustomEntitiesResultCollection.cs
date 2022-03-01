// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Collection of <see cref="RecognizeEntitiesResult"/> objects corresponding
    /// to a batch of documents, and information about the batch operation.
    /// </summary>
    [DebuggerTypeProxy(typeof(RecognizeCustomEntitiesResultCollectionDebugView))]
    public class RecognizeCustomEntitiesResultCollection : ReadOnlyCollection<RecognizeEntitiesResult>
    {
        internal RecognizeCustomEntitiesResultCollection(IList<RecognizeEntitiesResult> list, TextDocumentBatchStatistics statistics, string projectName, string deploymentName) : base(list)
        {
            Statistics = statistics;
            DeploymentName = deploymentName;
            ProjectName = projectName;
        }

        /// <summary>
        /// Gets statistics about the documents and how it was processed
        /// by the service.  This property will have a value when IncludeStatistics
        /// is set to true in the client call.
        /// </summary>
        public TextDocumentBatchStatistics Statistics { get; }

        /// <summary>
        /// Gets the value of the property corresponding to the name of the deployment.
        /// </summary>
        public string DeploymentName { get; }

        /// <summary>
        /// Gets the value of the property corresponding to the name of the project.
        /// </summary>
        public string ProjectName { get; }

        /// <summary>
        /// Debugger Proxy class for <see cref="RecognizeCustomEntitiesResultCollection"/>.
        /// </summary>
        internal class RecognizeCustomEntitiesResultCollectionDebugView
        {
            private RecognizeCustomEntitiesResultCollection BaseCollection { get; }

            public RecognizeCustomEntitiesResultCollectionDebugView(RecognizeCustomEntitiesResultCollection collection)
            {
                BaseCollection = collection;
            }

            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public List<RecognizeEntitiesResult> Items
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
