// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// Collection of <see cref="DocumentClassification"/> objects in a document,
    /// and warnings encountered while processing the document.
    /// </summary>
    [DebuggerTypeProxy(typeof(DocumentClassificationCollectionDebugView))]
    public class DocumentClassificationCollection : ReadOnlyCollection<DocumentClassification>
    {
        internal DocumentClassificationCollection(IList<DocumentClassification> documentClassifications, IList<TextAnalyticsWarning> warnings)
            : base(documentClassifications)
        {
            Warnings = new ReadOnlyCollection<TextAnalyticsWarning>(warnings);
        }

        /// <summary>
        /// Warnings encountered while processing the document.
        /// </summary>
        public IReadOnlyCollection<TextAnalyticsWarning> Warnings { get; }

        /// <summary>
        /// Debugger Proxy class for <see cref="DocumentClassificationCollection"/>.
        /// </summary>
        internal class DocumentClassificationCollectionDebugView
        {
            private DocumentClassificationCollection BaseCollection { get; }

            public DocumentClassificationCollectionDebugView(DocumentClassificationCollection collection)
            {
                BaseCollection = collection;
            }

            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public List<DocumentClassification> Items
            {
                get
                {
                    return BaseCollection.ToList();
                }
            }

            public IReadOnlyCollection<TextAnalyticsWarning> Warnings
            {
                get
                {
                    return BaseCollection.Warnings;
                }
            }
        }
    }
}
